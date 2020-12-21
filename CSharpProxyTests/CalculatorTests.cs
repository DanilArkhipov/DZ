using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using CSharpProxy;
using Microsoft.Extensions.DependencyInjection;
using static FSharpCalc.Calculator;

namespace CSharpProxyTests
{
    public class CalculatorTests
    {
        class LocalCalculator:ICalculate
        {
            public Task<double> CalculateAsync(double num1, char ch, double num2)
            {
                return  Task.Factory.StartNew
                    (()=>Convert.ToDouble
                (FSharpCalc.Calculator.returnStringValue
                (FSharpCalc.Calculator.activate
                (num1.ToString(), ch.ToString(), num2.ToString()))));
            }
        }
        public async Task<double> RemoteCalc(string input)
        {
            var calculator = new CalculatorRunner(new ServiceCollection().AddSingleton<ICalculate,Calculator>());
            return await calculator.Activate(input);
        }
        public async Task<double> LocalCalc(string input)
        {
            var calculator = new CalculatorRunner(new ServiceCollection().AddSingleton<ICalculate,LocalCalculator>());
            return await calculator.Activate(input);
        }
        
        [Theory]
        [InlineData("25+34")]
        [InlineData("25/25/24")]
        [InlineData("(25+34)-74")]
        [InlineData("(25+34)/2+32")]
        [InlineData("(25+34)/2+32*2")]
        [InlineData("(25+34)/2+32*(24+37/3)")]
        [InlineData("(25+34)/2+32*(24+37)/3")]
        [InlineData("((25+34)/2+32*(24+37)/3)/2")]
        [InlineData("(2,08+3,14)/2")]
        [InlineData("((2,08+3,14)*2)/4")]
        public async  void Test_CSharpProxy_IsRemoteCalcWorkingSimilarLikeLocalCalc(string input)
        {
            Assert.Equal(await LocalCalc(input),await RemoteCalc(input));
        }
    }
}