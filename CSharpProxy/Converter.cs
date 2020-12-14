using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CSharpProxy
{
    public class Converter
    {
        private static readonly char[] operatorsArray = {'(', ')', '+', '-', '*', '/'};
        private static readonly char[] delimitersArray = {' ', '='};

        internal static Expression Convert(string input)
        {
            var tmp = ToPostfix(input);
            return ToExpression(tmp);
        }

        private static bool IsOperator(char c)
        {
            return operatorsArray.Contains(c);
        }

        private static int GetOperatorPriority(char c)
        {
            return c switch
            {
                '(' => 0,
                ')' => 1,
                '+' => 2,
                '-' => 2,
                '*' => 3,
                '/' => 4,
                _ => throw new ArgumentException()
            };
        }

        private static bool IsDelimiter(char c)
        {
            return delimitersArray.Contains(c);
        }

        private static Queue<char> ToPostfix(string input)
        {
            var operatorsStack = new Stack<char>();
            var postfixResult = new Queue<char>();
            for (var i = 0; i < input.Length; i++)
            {
                if (IsDelimiter(input[i])) continue;
                if (char.IsDigit(input[i]))
                {
                    while (!IsDelimiter(input[i]) && !IsOperator(input[i]))
                    {
                        postfixResult.Enqueue(input[i]);
                        i++;
                        if (i == input.Length) break;
                    }

                    postfixResult.Enqueue(' ');
                    i--;
                }

                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                    {
                        operatorsStack.Push(input[i]);
                    }
                    else if (input[i] == ')')
                    {
                        var s = operatorsStack.Pop();

                        while (s != '(')
                        {
                            postfixResult.Enqueue(s);
                            s = operatorsStack.Pop();
                        }
                    }
                    else
                    {
                        if (operatorsStack.Count > 0)
                            if (GetOperatorPriority(input[i]) <= GetOperatorPriority(operatorsStack.Peek()))
                                postfixResult.Enqueue(operatorsStack.Pop());

                        operatorsStack.Push(input[i]);
                    }
                }
            }

            while (operatorsStack.Count > 0) postfixResult.Enqueue(operatorsStack.Pop());

            return postfixResult;
        }

        private static Expression ToExpression(Queue<char> input)
        {
            var stack = new Stack<Expression>();
            while (input.Count > 0)
            {
                if (char.IsDigit(input.Peek()))
                {
                    var tmp = new StringBuilder();
                    while (input.Count > 0 && !IsDelimiter(input.Peek()) && !IsOperator(input.Peek()))
                        tmp.Append(input.Dequeue());
                    stack.Push(Expression.Constant(double.Parse(tmp.ToString()), typeof(double)));
                }

                if (IsDelimiter(input.Peek())) input.Dequeue();
                if (IsOperator(input.Peek()))
                {
                    var secondExpression = stack.Pop();
                    var firstExpression = stack.Pop();
                    var newExpression =
                        input.Dequeue() switch
                        {
                            '+' => Expression.Add(firstExpression, secondExpression),
                            '-' => Expression.Subtract(firstExpression, secondExpression),
                            '*' => Expression.Multiply(firstExpression, secondExpression),
                            '/' => Expression.Divide(firstExpression, secondExpression)
                        };
                    stack.Push(newExpression);
                }
            }

            return stack.Pop();
        }
    }
}