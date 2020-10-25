using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSharpProxy
{
    public class Calculator
    {
        async public Task<double> Calculate(string input)
        {
            var expression = (BinaryExpression)Converter.Convert(input);
            var result = await CalculatorExpressionVisitor.VisitAsync(expression);
            return result;
        }
    }
}