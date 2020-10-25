using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace CSharpProxy
{
    public class Converter
    {
        private readonly static char[] operatorsArray = new Char[] {'(', ')', '+', '-', '*', '/'};
        private readonly static char[] delimitersArray = new Char[] {' ', '='};
        internal static Expression Convert()
        {
            throw new NotImplementedException();
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

        private static Queue<Char> ToPostfix(string input)
        {
            var operatorsStack = new Stack<Char>();
            var postfixResult = new Queue<Char>();
            for (int i = 0; i < input.Length; i++)
            {
                if(IsDelimiter(input[i])) continue;
                if (Char.IsDigit(input[i]))
                {
                    while (!IsDelimiter(input[i]) && !IsOperator(input[i]))
                    {
                        postfixResult.Enqueue(input[i]);
                        i++;
                        if (i == input.Length) break;
                    }

                    i--;
                }
                if (IsOperator(input[i])) 
                {
                    if (input[i] == '(') 
                        operatorsStack.Push(input[i]); 
                    else if (input[i] == ')')
                    {
                        char s = operatorsStack.Pop();

                        while (s != '(')
                        {
                            postfixResult.Enqueue(s);
                            s = operatorsStack.Pop();
                        }
                    }
                    else
                    {
                        if (operatorsStack.Count > 0)
                        {
                            if (GetOperatorPriority(input[i]) <= GetOperatorPriority(operatorsStack.Peek()))
                            {
                                postfixResult.Enqueue(operatorsStack.Pop());
                            }
                        }

                        operatorsStack.Push(input[i]);
                    }
                }
            }

            while (operatorsStack.Count > 0)
            {
                postfixResult.Enqueue(operatorsStack.Pop());
            }

            return postfixResult;
        }

        private static Expression ToExpression(Queue<string> input)
        {
            throw new NotImplementedException();
        }
    }
}