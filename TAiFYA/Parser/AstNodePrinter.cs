using System;
using System.Text;
namespace MathLang
{
    public class AstNodePrinter
    {
        public static readonly char ConnectChar = ' ',
        MiddleNodeChar = '{',
        LastNodeChar = '}';

        //public const byte ConnectCharDosCode = 0xB3,
        //MiddleNodeCharDosCode = 0xC3,
        //LastNodeCharDosCode = 0xC0;

        //static AstNodePrinter()
        //{
        //    Encoding dosEncoding = null;
        //    try
        //    {
        //        dosEncoding = Encoding.GetEncoding("cp866");
        //    }
        //    catch { }
        //    if (dosEncoding != null)
        //    {
        //        ConnectChar = dosEncoding.GetChars(
        //        new byte[] { ConnectCharDosCode })[0];
        //        MiddleNodeChar = dosEncoding.GetChars(
        //        new byte[] { MiddleNodeCharDosCode })[0];
        //        LastNodeChar = dosEncoding.GetChars(
        //        new byte[] { LastNodeCharDosCode })[0];
        //    }
        //}

        private static string GetStringSubTree(AstNode node, string indent, bool root)
        {
            if (node == null)
                return "";
            string result = indent;
            if (!root)
                if (node.Index < node.Parent.ChildCount - 1)
                {
                    result += MiddleNodeChar + " ";
                    indent += ConnectChar + " ";
                }
                else
                {
                    result += LastNodeChar + " ";
                    indent += " ";
                }
            result += node + "\n";
            for (int i = 0; i < node.ChildCount; i++)
                result += GetStringSubTree(node.GetChild(i), indent, false);
            return result;
        }
        public static string AstNodeToAdvancedDosStringTree(AstNode node) => GetStringSubTree(node, "", true);
        public static string Print(AstNode node)
        {
            string tree = AstNodeToAdvancedDosStringTree(node);
            return tree;
        }
    }
}