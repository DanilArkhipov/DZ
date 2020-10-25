using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSharpProxy
{
    public class CalculatorExpressionVisitor:ExpressionVisitor
    {
        static async public Task<double> VisitAsync(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                {
                    var tmp = node as ConstantExpression;
                    return (double) tmp.Value;
                }
                case ExpressionType.Add:
                {
                    var tmp = node as BinaryExpression;
                    var result = await PostRequestSender.SendPostRequestAsync(
                        "https://localhost:5001/",
                        await VisitAsync(tmp.Left),
                        '+',
                        await VisitAsync(tmp.Right));
                    return result;
                }
                case ExpressionType.Subtract:
                {
                    var tmp = node as BinaryExpression;
                    var result = await PostRequestSender.SendPostRequestAsync(
                        "https://localhost:5001/",
                        await VisitAsync(tmp.Left),
                        '-',
                        await VisitAsync(tmp.Right));
                    return result;
                }
                case ExpressionType.Multiply:
                {
                    var tmp = node as BinaryExpression;
                    var result = await PostRequestSender.SendPostRequestAsync(
                        "https://localhost:5001/",
                        await VisitAsync(tmp.Left),
                        '*',
                        await VisitAsync(tmp.Right));
                    return result;
                }
                case ExpressionType.Divide:
                {
                    var tmp = node as BinaryExpression;
                    var result = await PostRequestSender.SendPostRequestAsync(
                        "https://localhost:5001/",
                        await VisitAsync(tmp.Left),
                        '/',
                        await VisitAsync(tmp.Right));
                    return result;
                }
                default:
                {
                    throw new Exception();
                }
            }
        }
    }
}