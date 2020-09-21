using System;

namespace Calculator
{
    public class IO
    {
        private const string StartString = "Введите простое выражение вида число оператор число\nНа следующей строке калькулятор выведет ответ";
        private const string InvalidInputErrorString = "Входные данные иимели неверный формат";
        private const string UnexpectedErrorString = "Возникла непредвиденная ошибка";

        public static void PrintStartString()
        {
            Console.WriteLine(StartString);
        }
        public static object[] ParseInput(string input)
        {
            try
            {
                var tmp = input.Split(' ');
                if (tmp[1] == "+" || tmp[1] == "-" || tmp[1] == "*" || tmp[1] == "/")
                {
                    object[] res = new object[3];
                    res[1] = tmp[1];
                    res[0] = Double.Parse(tmp[0]);
                    res[2] = Double.Parse(tmp[2]);
                    return res;
                }
                else throw new Exception(IO.ReturnInvalidInputErrorString());
            }
            catch
            {
                throw new Exception(IO.ReturnInvalidInputErrorString());
            }
        }

        public static string ReturnInvalidInputErrorString()
        {
            return InvalidInputErrorString;
        }

        public static string ReturnUnexpectedErrorString()
        {
            return UnexpectedErrorString;
        }

        public static void PrintResult(object[] input, double res)
        {
            Console.WriteLine("{0} {1} {2} = {3}",input[0],input[1],input[2],res);
        }
    }
}