using System;
using System.Linq.Expressions;

namespace CSharpProxy
{
    public class Calculator
    {
        public double Calculate(string input)
        {
            var expression = Converter.Convert(input);
            var lambdaExpression = Expression.Lambda<Func<double>>(expression);
            Func<double> lambdaDelegate = lambdaExpression.Compile();
            return lambdaDelegate();
        }
    }
}