using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace MathLang
{
    public class MathLangIntepreter
    {
        // таблица переменных
        private Dictionary<string, double> varTable = new Dictionary<string, double>();
        // корневой узел AST-дерева программы
        private AstNode programNode = null;
        // конструктор
        public MathLangIntepreter(AstNode programNode)
        {
            if (programNode.Type != AstNodeType.PROGRAM)
                throw new IntepreterException("AST-дерево не является программой");
            this.programNode = programNode;
        }
        // рекурсивный метод, который вызывается для каждого узла дерева
        private string GenerateNode(AstNode node, int lvl, string s)
        {
            switch (node.Type)
            {
                case AstNodeType.UNKNOWN:
                    throw new IntepreterException("Неопределенный тип узла AST-дерева");
                case AstNodeType.NUMBER:
                    return "LOAD =" + node.Text;
                case AstNodeType.IDENT:
                    return "LOAD " + node.Text;
                case AstNodeType.TRUE:
                    return "LOAD  " + 1;
                case AstNodeType.FALSE:
                    return "LOAD " + 0;
                case AstNodeType.ADD:
                    return GenerateNode(node.GetChild(1), lvl, s) + Environment.NewLine + "STORE ~" + (++lvl).ToString() + Environment.NewLine + GenerateNode(node.GetChild(0), lvl, s) + Environment.NewLine + "ADD ~" + (lvl--).ToString();
                case AstNodeType.SUB:
                    return GenerateNode(node.GetChild(1), lvl, s) + Environment.NewLine + "STORE ~" + (++lvl).ToString() + Environment.NewLine + GenerateNode(node.GetChild(0), lvl, s) + Environment.NewLine + "SUB ~" + (lvl--).ToString();
                case AstNodeType.MPY:
                    return GenerateNode(node.GetChild(1), lvl, s) + Environment.NewLine + "STORE ~" + (++lvl).ToString() + Environment.NewLine + GenerateNode(node.GetChild(0), lvl, s) + Environment.NewLine + "MPY ~" + (lvl--).ToString();
                case AstNodeType.DIV:
                    return GenerateNode(node.GetChild(1), lvl, s) + Environment.NewLine + "STORE ~" + (++lvl).ToString() + Environment.NewLine + GenerateNode(node.GetChild(0), lvl, s) + Environment.NewLine + "DIV ~" + (lvl--).ToString();
                case AstNodeType.ASSIGN:
                    return GenerateNode(node.GetChild(1), lvl, s) + Environment.NewLine + "STORE " + node.GetChild(0).Text + Environment.NewLine + Environment.NewLine;
                case AstNodeType.BLOCK:
                case AstNodeType.PROGRAM:
                    for (int i = 0; i < node.ChildCount; i++)
                        s += GenerateNode(node.GetChild(i), lvl, s);
                    return s;
                default:
                    throw new IntepreterException("Неизвестный тип узла AST-дерева");
            }
        }
        // public-метод для вызова интерпретации
        private string Generate()
        {
            return GenerateNode(programNode, 0, "");
        }
        // статическая реализации предыдузего метода (для удобства)
        public static string Execute(AstNode programNode)
        {
            MathLangIntepreter mei = new MathLangIntepreter(programNode);
            return mei.Generate();
        }
        public static string OptimizeGeneratedString(string s)
        {
            #region rule 3
            const string rule3RegFilter = @"(STORE(\s\S+\s)LOAD(?:\2))";

            var strMas = Regex.Split(s, rule3RegFilter);
            for (int i = 0; i < strMas.Length; i++)
                if (Regex.IsMatch(strMas[i], rule3RegFilter))
                {
                    bool chek = false;
                    for (int j = i + 2; j < strMas.Length; j++)
                        chek = Regex.IsMatch(strMas[j], strMas[i + 1]);
                    if (!chek)
                        strMas[i] = strMas[i + 1] = null;
                    else
                        strMas[i + 1] = null;
                    i++;
                }
            s = null;
            foreach (var item in strMas)
                s += item;
            #endregion

            #region rule 4
            const string rule4RegFilter = @"(LOAD)(\s\S+\s)(STORE)(\s\S+\s)(LOAD\s\S+\s)(?!STORE(\4))";

            strMas = Regex.Split(s, rule4RegFilter);
            if (strMas.Length > 1)
            {
                for (int i = 6; i < strMas.Length; i++)
                    if (Regex.IsMatch(strMas[i], strMas[3] + strMas[4]))
                    {
                        var tmpstr = Regex.Split(strMas[i], "(" + strMas[3] + strMas[4] + ")");
                        tmpstr[0] = Regex.Replace(tmpstr[0], strMas[4], strMas[2]);

                        strMas[i] = null;
                        foreach (var item in tmpstr)
                            strMas[i] += item;
                        break;
                    }
                    else
                        strMas[i] = Regex.Replace(strMas[i], strMas[4], strMas[2]);
                strMas[1] = strMas[2] = strMas[3] = strMas[4] = null;
            }

            s = null;
            foreach (var item in strMas)
                s += item;
            #endregion

            #region swap
            const string swapRegFilter = @"(LOAD\s\S+\sADD\s\S+\s)|(LOAD\s\S+\sMPY\s\S+\s)";
            const string SwapRegSubFilter = @"(LOAD\s)(\S+\s)(?:(ADD\s)|(MPY\s))(\S+\s)";

            strMas = Regex.Split(s, swapRegFilter);
            for (int i = 0; i < strMas.Length; i++)
            {
                var subStrMas = Regex.Split(strMas[i], SwapRegSubFilter);
                if (subStrMas.Length > 1)
                {
                    string tmp = subStrMas[2];
                    subStrMas[2] = subStrMas[4];
                    subStrMas[4] = tmp;

                    strMas[i] = null;
                    foreach (var item1 in subStrMas)
                        strMas[i] += item1;
                }
            }
            s = null;
            foreach (var item in strMas)
                s += item;
            #endregion

            return s;
        }
    }
}