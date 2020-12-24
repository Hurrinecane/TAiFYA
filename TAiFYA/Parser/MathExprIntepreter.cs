using System.Globalization;
namespace MathLang
{
    public class MathExprIntepreter : ParserBase
    {
        // "культуронезависимый" формат для чисел (с разделителем ".")
        public static readonly NumberFormatInfo NFI =
        new NumberFormatInfo();
        // конструктор
        public MathExprIntepreter(string source) : base(source)
        {
        }
// далее идет реализация в виде функций правил грамматики
// NUMBER -> <число> (реализация в грамматике не описана)
public double NUMBER()
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
            return double.Parse(number, NFI);
        }
        // group -> "(" add ")" | NUMBER
        public double Group()
        {
            if (IsMatch("("))
            { // выбираем альтернативу
                Match("("); // это выражение в скобках
                double result = Add();
                Match(")");
                return result;
            }
            else
                return NUMBER(); // это число
        }
        // mult -> group ( ( "*" | "/" ) group )*
        public double Mult()
        {
            double result = Group();
            while (IsMatch("*", "/"))
            { // повторяем нужное кол-во раз
                string oper = Match("*", "/"); // здесь выбор альтернативы
                double temp = Group(); // реализован иначе
                result = oper == "*" ? result * temp
                : result / temp;
            }
            return result;
        }
        // add -> mult ( ( "+" | "-" ) mult )*
        public double Add()
        { // реализация аналогично правилу mult
            double result = Mult();
            while (IsMatch("+", "-"))
            {
                string oper = Match("+", "-");
                double temp = Mult();
                result = oper == "+" ? result + temp
                : result - temp;
            }
            return result;
        }
        // result -> add
        public double Result()
        {
            return Add();
        }
        // метод, вызывающий начальное и правило грамматики и
        // соответствующие вычисления
        public double Execute()
        {
            Skip();
            double result = Result();
            if (End)
                return result;
            else
                throw new ParserBaseException( // разобрали не всю строку
                string.Format("Лишний символ '{0}' (pos={1})",
                Current, Pos)
                );
        }
        // статическая реализации предыдузего метода (для удобства)
        public static double Execute(string source)
        {
            MathExprIntepreter mei = new MathExprIntepreter(source);
            return mei.Execute();
        }
    }
}