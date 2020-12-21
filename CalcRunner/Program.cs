using System;
using Calculator;

namespace CalcRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var calc = new CalcLogic();
            calc.Activate(Console.ReadLine());
        }
    }
}