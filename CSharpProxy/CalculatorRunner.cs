using System;
using System.Linq.Expressions;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CSharpProxy
{
    public class CalculatorRunner
    {
        private readonly IServiceCollection _services;

        public CalculatorRunner(IServiceCollection services)
        {
            _services = services;
        }
        
        async public Task<double> Activate(string input)
        {
            var expression = (BinaryExpression)Converter.Convert(input);
            var expressionVisitor = new CalculatorExpressionVisitor(_services.BuildServiceProvider().GetService<ICalculate>());
            var result = await expressionVisitor.VisitAsync(expression);
            return result;
        }    
        
    }
}