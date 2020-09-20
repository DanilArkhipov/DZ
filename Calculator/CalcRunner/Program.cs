using System;

namespace CalcRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator.CalcLogic();
            calc.Activate(Console.ReadLine());
        }
    }
}