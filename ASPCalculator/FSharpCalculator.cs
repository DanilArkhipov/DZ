using static FSharpCalc.Calculator;
namespace ASPCalculator

{
    public class FSharpCalculator:ICalculator
    {
        public string Calculate(string firstNumber,string operation, string secondNumber)
        {
            var res = activate(firstNumber, operation, secondNumber);
            return returnStringValue(res);
        }
        
    }
}