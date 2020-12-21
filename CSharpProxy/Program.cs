using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpProxy
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var calc = new CalculatorRunner(new ServiceCollection().AddSingleton<ICalculate, Calculator>());
            Console.WriteLine(await calc.Activate(Console.ReadLine()));
        }
    }
}