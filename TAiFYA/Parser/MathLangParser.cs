namespace MathLang
{
    public class MathLangParser : ParserBase
    {
        // конструктор
        public MathLangParser(string source)
        : base(source)
        {
        }
        // далее идет реализация в виде функций правил грамматики
        // NUMBER -> <число>
        public AstNode NUMBER()
        {
            string number = "";
            while (Current == '.' || char.IsDigit(Current))
            {
                number += Current;
                Next();
            }
            if (number.Length == 0)
                throw new ParserBaseException(
                string.Format("Ожидалось число (pos={0})", Pos));
            Skip();
            return new AstNode(AstNodeType.NUMBER, number);
        }
        // IDENT -> <идентификатор>
        public AstNode IDENT()
        {
            string identifier = "";
            if (char.IsLetter(Current))
            {
                identifier += Current;
                Next();
                while (char.IsLetterOrDigit(Current))
                {
                    identifier += Current;
                    Next();
                }
            }
            else
                throw new ParserBaseException(string.Format("Ожидался идентификатор (pos={0})", Pos));
            Skip();
            if (identifier == "true")
                return new AstNode(AstNodeType.TRUE, identifier);
            else
            if (identifier == "false")
                return new AstNode(AstNodeType.FALSE, identifier);
            return new AstNode(AstNodeType.IDENT, identifier);
        }
        // group -> "(" term ")" | IDENT | NUMBER
        public AstNode Group()
        {
            if (IsMatch("("))
            { // выбираем альтернативу
                Match("("); // это выражение в скобках
                AstNode result = Term();
                Match(")");
                return result;
            }
            else if (char.IsLetter(Current))
            {
                int pos = Pos; // это идентификатор
                return IDENT();
            }
            else
                return NUMBER(); // число
        }
        public AstNode Boolean()
        {
            AstNode result = Group();
            while (IsMatch("true", "false", "or", "xor", "and", "not"))
            { // повторяем нужное кол-во раз
                string oper = Match("true", "false", "or", "xor", "and", "not"); // здесь выбор альтернативы
                AstNode temp = Group(); // реализован иначе
                switch (oper)
                {
                    case "true":
                        result = new AstNode(AstNodeType.TRUE, result, temp);
                        break;
                    case "false":
                        result = new AstNode(AstNodeType.FALSE, result, temp);
                        break;
                    case "or":
                        result = new AstNode(AstNodeType.OR, result, temp);
                        break;
                    case "xor":
                        result = new AstNode(AstNodeType.XOR, result, temp);
                        break;
                    case "and":
                        result = new AstNode(AstNodeType.AND, result, temp);
                        break;
                    case "not":
                        result = new AstNode(AstNodeType.NOT, result, temp);
                        break;
                }
            }
            return result;
        }

        // mult -> group ( ( "*" | "/" ) group )*
        public AstNode Mult()
        {
            AstNode result = Boolean();
            while (IsMatch("*", "/"))
            { // повторяем нужное кол-во раз
                string oper = Match("*", "/"); // здесь выбор альтернативы
                AstNode temp = Boolean(); // реализован иначе
                result = oper == "*" ? new AstNode(AstNodeType.MPY, result, temp)
                : new AstNode(AstNodeType.DIV, result, temp);
            }
            return result;
        }
        // add -> mult ( ( "+" | "-" ) mult )*
        public AstNode Add()
        { // реализация аналогично правилу mult
            AstNode result = Mult();
            while (IsMatch("+", "-"))
            {
                string oper = Match("+", "-");
                AstNode temp = Mult();
                result = oper == "+" ? new AstNode(AstNodeType.ADD, result, temp) : new AstNode(AstNodeType.SUB, result, temp);
            }
            return result;
        }
        // term -> add
        public AstNode Term()
        {
            return Add();
        }
        // expr -> "print" term | "input" IDENT | IDENT "=" term
        public AstNode Expr()
        {
            AstNode identifier = IDENT();
            Match(":="); // это операция присвоения значения
            AstNode value = Term();
            return new AstNode(AstNodeType.ASSIGN, identifier, value);
        }
        // program -> ( expr )*
        public AstNode Program()
        {
            AstNode programNode = new AstNode(AstNodeType.PROGRAM);
            while (!End) // повторяем до конца входной строки
                programNode.AddChild(Expr());
            return programNode;
        }
        // result -> program
        public AstNode Result()
        {
            return Program();
        }
        // метод, вызывающий начальное и правило грамматики и
        // соответствующий парсинг
        public AstNode Parse()
        {
            Skip();
            AstNode result = Result();
            if (End)
                return result;
            else
                throw new ParserBaseException( // разобрали не всю строку
                string.Format("Лишний символ '{0}' (pos={1})", Current, Pos)
                );
        }
        // статическая реализации предыдущего метода (для удобства)
        public static AstNode Parse(string source)
        {
            MathLangParser mlp = new MathLangParser(source);
            return mlp.Parse();
        }
    }
}