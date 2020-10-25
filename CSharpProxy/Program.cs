using System;

namespace CSharpProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            Console.WriteLine(calc.Calculate(Console.ReadLine()));
        }
    }
}