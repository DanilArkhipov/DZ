using System;

namespace CalculatorSeriallization
{
    public class InputData
    {
        public string FirstNumber { get; set; }
        public string Operation { get; set; }
        public string SecondNumber { get; set; }

        public InputData()
        {
            
        }

        public InputData(string fN, string op, string sN)
        {
            FirstNumber = fN;
            Operation = op;
            SecondNumber = sN;
        }
        
    }
}