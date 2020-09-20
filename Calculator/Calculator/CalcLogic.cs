using System;

namespace Calculator
{
    public class CalcLogic
    {
        public void Activate(string input)
        {
            IO.PrintStartString();
            var inputParsed = IO.ParseInput(input);
            var res = Calculate(inputParsed);
            IO.PrintResult(inputParsed,res);
        }
        public double Calculate(object[] input)
        {
            var d1 = (double)input[0] ;
            var d2 = (double) input[2];
            switch (input[1])
            {
                case "+":
                    return Sum(d1, d2);
                case "-":
                    return Sub(d1, d2);
                case "*":
                    return Mult(d1, d2);
                case "/":
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