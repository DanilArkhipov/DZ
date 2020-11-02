using System;
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
                var left = Task.Run(() => VisitAsync(binaryNode.Left));
                var right = Task.Run(() => VisitAsync(binaryNode.Right));
                var tasks = await Task.WhenAll(new []{left,right});
                await Task.Yield();
                var result = await PostRequestSender.SendPostRequestAsync(
                    "https://localhost:5001/",
                    tasks[0],
                    operation,
                    tasks[1]);
                Console.WriteLine(binaryNode.ToString());
                return result;
            }
            
        }
    }
}