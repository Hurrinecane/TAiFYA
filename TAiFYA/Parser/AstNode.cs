using System.Collections.Generic;
namespace MathLang
{
    public class AstNode
    {
        // тип узла (см. описание ниже)
        public virtual int Type { get; set; }
        // текст, связанный с узлом
        public virtual string Text { get; set; }
        // родительский узел для данного узла дерева
        private AstNode parent = null;
        // потомки (ветви) данного узла дерева
        private IList<AstNode> childs = new List<AstNode>();
        // конструкторы с различными параметрами (для удобства)
        public AstNode(int type, string text, AstNode child1, AstNode child2)
        {
            Type = type;
            Text = text;
            if (child1 != null)
                AddChild(child1);
            if (child2 != null)
                AddChild(child2);
        }
        public AstNode(int type, AstNode child1, AstNode child2)
        : this(type, null, child1, child2)
        {
        }
        public AstNode(int type, AstNode child1)
        : this(type, child1, null)
        {
        }
        public AstNode(int type, string label)
        : this(type, label, null, null)
        {
        }
        public AstNode(int type)
        : this(type, (string)null)
        {
        }
        // метод добавления дочернего узла
        public void AddChild(AstNode child)
        {
            if (child.Parent != null)
            {
                child.Parent.childs.Remove(child);
            }
            childs.Remove(child);
            childs.Add(child);
            child.parent = this;
        }
        // метод удаления дочернего узла
        public void RemoveChild(AstNode child)
        {
            childs.Remove(child);
            if (child.parent == this)
                child.parent = null;
        }
        // метод получения дочернего узла по индексу
        public AstNode GetChild(int index)
        {
            return childs[index];
        }
        // метод добавления дочернего узла
        public int ChildCount
        {
            get
            {
                return childs.Count;
            }
        }
        // родительский узел (свойство)
        public AstNode Parent
        {
            get
            {
                return parent;
            }
            set
            {
                value.AddChild(this);
            }
        }
        // индекс данного узла в дочерних узлах родительского узла
        public int Index
        {
            get
            {
                return Parent == null ? -1
                : Parent.childs.IndexOf(this);
            }
        }
        // представление узла в виде строки
        public override string ToString()
        {
            return Text != null ? Text
            : AstNodeType.AstNodeTypeToString(Type);
        }
    }
    // класс констант для перечисления возможных типов токенов
    public class AstNodeType
    {
        public const int UNKNOWN = 0;
        public const int NUMBER = 1;
        public const int IDENT = 5;
        public const int ADD = 11;
        public const int SUB = 12;
        public const int MPY = 13;
        public const int DIV = 14;
        public const int TRUE = 49;
        public const int FALSE = 50;
        public const int ASSIGN = 51;
        public const int INPUT = 52;
        public const int PRINT = 53;
        public const int OR = 54;
        public const int XOR = 55;
        public const int AND = 56;
        public const int NOT = 57;
        public const int BLOCK = 100;
        public const int PROGRAM = 101;
        public static string AstNodeTypeToString(int type)
        {
            switch (type)
            {
                case UNKNOWN: return "?";
                case NUMBER: return "NUM";
                case IDENT: return "ID";
                case ADD: return "+";
                case SUB: return "-";
                case MPY: return "*";
                case DIV: return "/";
                case TRUE: return "TRUE";
                case FALSE: return "FALSE";
                case ASSIGN: return "=";
                case INPUT: return "input";
                case PRINT: return "print";
                case OR: return "OR";
                case XOR: return "XOR";
                case AND: return "AND";
                case NOT: return "NOT";
                case BLOCK: return "..";
                case PROGRAM: return "main()";
                default: return "";
            }
        }
    }
}