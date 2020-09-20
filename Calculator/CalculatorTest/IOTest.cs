using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
namespace CalculatorTest
{
    [TestClass]
    public class IOTest
    {
        [TestMethod]
        public void InputParse_IncorrectSymbol_InvalidInputExceptionReturned()
        {
            void TmpMethod()
            {
                IO.ParseInput("2 ^ 256");
            }

            Assert.ThrowsException<Exception>(TmpMethod);
        }
        [TestMethod]
        public void InputParse_IncorrectInput_InvalidInputExceptionReturned()
        {
            void TmpMethod()
            {
                IO.ParseInput("256");
            }

            Assert.ThrowsException<Exception>(TmpMethod);
        }
    }
}