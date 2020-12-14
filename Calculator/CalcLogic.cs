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
            mult
        }

        public void Activate(string input)
        {
            IO.PrintStartString();
            var inputParsed = IO.ParseInput(input);
            var res = Calculate((double) inputParsed[0], (operators) inputParsed[1], (double) inputParsed[2]);
            IO.PrintResult(inputParsed, res);
        }

        public double Calculate(double d1, operators op, double d2)
        {
            double res = op switch
            {
                operators.plus => res = Sum(d1, d2),
                operators.minus => res = Sub(d1, d2),
                operators.mult => res = Mult(d1, d2),
                operators.div => res = Div(d1, d2)
            };
            return res;
        }

        public double Sum(double d1, double d2)
        {
            return d1 + d2;
        }

        public double Sub(double d1, double d2)
        {
            return d1 - d2;
        }

        public double Mult(double d1, double d2)
        {
            return d1 * d2;
        }

        public double Div(double d1, double d2)
        {
            if (d2 != 0)
                return d1 / d2;
            throw new DivideByZeroException();
        }
    }
}