using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class IOTest
    {
        [TestMethod]
        public void InputParse_IncorrectEnter_InvalidInputExceptionReturned()
        {
            void TmpMethod()
            {
                IO.ParseInput("IncorrectInput");
            }

            Assert.ThrowsException<Exception>(TmpMethod);
        }

        [TestMethod]
        public void InputParse_IncorrectSymbol_InvalidInputExceptionReturned()
        {
            void TmpMethod()
            {
                IO.ParseInput("2 ^ 4");
            }

            Assert.ThrowsException<Exception>(TmpMethod);
        }

        [TestMethod]
        public void InputParse_4plus5_ParsedExpression()
        {
            var ob = IO.ParseInput("4 + 5");
            Assert.AreEqual(4.0, (double) ob[0]);
            Assert.AreEqual(CalcLogic.operators.plus, (CalcLogic.operators) ob[1]);
            Assert.AreEqual(5.0, (double) ob[2]);
        }

        [TestMethod]
        public void InputParse_4minus5_ParsedExpression()
        {
            var ob = IO.ParseInput("4 - 5");
            Assert.AreEqual(4.0, (double) ob[0]);
            Assert.AreEqual(CalcLogic.operators.minus, (CalcLogic.operators) ob[1]);
            Assert.AreEqual(5.0, (double) ob[2]);
        }

        [TestMethod]
        public void InputParse_4mult5_ParsedExpression()
        {
            var ob = IO.ParseInput("4 * 5");
            Assert.AreEqual(4.0, (double) ob[0]);
            Assert.AreEqual(CalcLogic.operators.mult, (CalcLogic.operators) ob[1]);
            Assert.AreEqual(5.0, (double) ob[2]);
        }

        [TestMethod]
        public void InputParse_4div5_ParsedExpression()
        {
            var ob = IO.ParseInput("4 / 5");
            Assert.AreEqual(4.0, (double) ob[0]);
            Assert.AreEqual(CalcLogic.operators.div, (CalcLogic.operators) ob[1]);
            Assert.AreEqual(5.0, (double) ob[2]);
        }

        [TestMethod]
        public void ReturnUnexpectedErrorString_Activate_CorrectWork()
        {
            var expectedStr = "Возникла непредвиденная ошибка";
            var actualStr = IO.ReturnUnexpectedErrorString();
            Assert.AreEqual(expectedStr, actualStr);
        }
    }
}