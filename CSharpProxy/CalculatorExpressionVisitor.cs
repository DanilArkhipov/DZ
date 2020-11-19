using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSharpProxy
{
    public class CalculatorExpressionVisitor:ExpressionVisitor
    {
        static async public Task<double> VisitAsync(Expression node)
        {
            if (node.NodeType == ExpressionType.Constant)
            {
                var tmp = node as ConstantExpression;
                return (double) tmp.Value;
            }
            else
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
                var binaryNode = node as BinaryExpression;
                var before = new Lazy<Task<double>>[]
                {
                    new Lazy<Task<double>>(VisitAsync(binaryNode.Left)),
                    new Lazy<Task<double>>(VisitAsync(binaryNode.Right))
                };
                var numbers = await Task.WhenAll(before.Select(x => x.Value));
                var postRequest = await PostRequestSender.SendPostRequestAsync("https://localhost:5001/",numbers[0], operation, numbers[1]);
                Console.WriteLine(node);
                return postRequest;
            }
            
        }
    }
}