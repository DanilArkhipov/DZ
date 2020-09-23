using System;

namespace Calculator
{
    public class CalcLogic
    {
        public enum operators
        {
            plus,
            minus,
            div,
            mult,
            
        }
        public void Activate(string input)
        {
            IO.PrintStartString();
            var inputParsed = IO.ParseInput(input);
            var res = Calculate((double)inputParsed[0],(operators)inputParsed[1],(double)inputParsed[2]);
            IO.PrintResult(inputParsed,res);
        }
        public double Calculate(double d1, operators op,double d2)
        {
            switch (op)
            {
                case operators.plus:
                    return Sum(d1, d2);
                case operators.minus:
                    return Sub(d1, d2);
                case operators.mult:
                    return Mult(d1, d2);
                case operators.div:
                    return Div(d1, d2);
                default:
                    throw new Exception(IO.ReturnUnexpectedErrorString());
            }

        }

        public Double Sum(double d1,double d2)
        {
            return d1 + d2;
        }
        public Double Sub(double d1,double d2)
        {
            return d1 - d2;
        }
        public Double Mult(double d1,double d2)
        {
            return d1 * d2;
        }
        public Double Div(double d1,double d2)
        {
            if(d2!=0)
                return d1 / d2;
            else throw new DivideByZeroException();
        }
    }
}