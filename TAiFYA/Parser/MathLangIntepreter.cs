﻿using System;
using System.Collections.Generic;
using System.Globalization;
namespace MathLang
{
    public class MathLangIntepreter
    {
        // "культуронезависимый" формат для чисел (с разделителем ".")
        public static readonly NumberFormatInfo NFI = new NumberFormatInfo();
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
        private double ExecuteNode(AstNode node)
        {
            switch (node.Type)
            {
                case AstNodeType.UNKNOWN:
                    throw new IntepreterException(
                    "Неопределенный тип узла AST-дерева");
                case AstNodeType.NUMBER:
                    return double.Parse(node.Text, NFI);
                case AstNodeType.IDENT:
                    if (varTable.ContainsKey(node.Text))
                        return varTable[node.Text];
                    else
                        throw new ParserBaseException(string.Format(
                        "Значение {0} не определено", node.Text));
                case AstNodeType.ADD:
                    return ExecuteNode(node.GetChild(0)) + ExecuteNode(node.GetChild(1));
                case AstNodeType.SUB:
                    return ExecuteNode(node.GetChild(0)) - ExecuteNode(node.GetChild(1));
                case AstNodeType.MUL:
                    return ExecuteNode(node.GetChild(0)) * ExecuteNode(node.GetChild(1));
                case AstNodeType.DIV:
                    return ExecuteNode(node.GetChild(0)) / ExecuteNode(node.GetChild(1));
                case AstNodeType.ASSIGN:
                    varTable[node.GetChild(0).Text] = ExecuteNode(node.GetChild(1));
                    break;
                case AstNodeType.INPUT:
                    Console.Write("input {0}: ", node.GetChild(0).Text);
                    varTable[node.GetChild(0).Text] = double.Parse(Console.ReadLine(), NFI);
                    break;
                case AstNodeType.PRINT:
                    Console.WriteLine(ExecuteNode(node.GetChild(0)).ToString(NFI));
                    break;
                case AstNodeType.BLOCK:
                case AstNodeType.PROGRAM:
                    for (int i = 0; i < node.ChildCount; i++)
                        ExecuteNode(node.GetChild(i));
                    break;
                default:
                    throw new IntepreterException("Неизвестный тип узла AST-дерева");
            }
            return 0;
        }
        // public-метод для вызова интерпретации
        public void Execute()
        {
            ExecuteNode(programNode);
        }
        // статическая реализации предыдузего метода (для удобства)
        public static void Execute(AstNode programNode)
        {
            MathLangIntepreter mei = new MathLangIntepreter(programNode);
            mei.Execute();
        }
    }
}