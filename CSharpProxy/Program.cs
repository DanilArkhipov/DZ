using System;
using System.Threading.Tasks;

namespace CSharpProxy
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var calc = new Calculator();
            Console.WriteLine(await calc.Calculate(Console.ReadLine()));
        }
    }
}