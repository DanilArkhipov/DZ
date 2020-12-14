using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSharpProxy
{
    public class CalculatorExpressionVisitor : ExpressionVisitor
    {
        private readonly ICalculate _calculator;

        public CalculatorExpressionVisitor(ICalculate calculator)
        {
            _calculator = calculator;
        }

        public async Task<double> VisitAsync(ConstantExpression node)
        {
            return (double) node.Value;
        }

        public async Task<double> VisitAsync(BinaryExpression node)
        {
            char operation;
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                {
                    operation = '+';
                    break;
                }
                case ExpressionType.Subtract:
                {
                    operation = '-';
                    break;
                }
                case ExpressionType.Multiply:
                {
                    operation = '*';
                    break;
                }
                case ExpressionType.Divide:
                {
                    operation = '/';
                    break;
                }
                default:
                {
                    throw new Exception();
                }
            }

            var before = new[]
            {
                new Lazy<Task<double>>(VisitAsync((dynamic) node.Left)),
                new Lazy<Task<double>>(VisitAsync((dynamic) node.Right))
            };
            var numbers = await Task.WhenAll(before.Select(x => x.Value));
            var result = await _calculator.CalculateAsync(numbers[0], operation, numbers[1]);
            Console.WriteLine(node);
            return result;
        }
    }
}