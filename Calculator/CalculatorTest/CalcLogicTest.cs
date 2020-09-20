using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
namespace CalculatorTest
{
    [TestClass]
    public class CalcLogicTest
    {
        
        [TestMethod]
        public void Div_4div0_ZeroDivisionExceptionReturned()
        {
            var calc = new CalcLogic();
            void TmpMethod()
            {
                calc.Div(4, 0);
            }
            Assert.ThrowsException<DivideByZeroException>(TmpMethod);
        }

        [TestMethod]
        public void Calculate_Double4PlusDouble3_Double7Returned()
        {
            var ob = new object[] {4.0, "+", 3.0};
            var calc = new CalcLogic();
            var res = calc.Calculate(ob);
            Assert.AreEqual(7.0,res);
        }
        [TestMethod]
        public void Calculate_Double4MinusDouble3_Double1Returned()
        {
            var ob = new object[] {4.0, "-", 3.0};
            var calc = new CalcLogic();
            var res = calc.Calculate(ob);
            Assert.AreEqual(1.0,res);
        }
        [TestMethod]
        public void Calculate_Double4MDivisionDouble2_Double2Returned()
        {
            var ob = new object[] {4.0, "/", 2.0};
            var calc = new CalcLogic();
            var res = calc.Calculate(ob);
            Assert.AreEqual(2.0,res);
        }
        [TestMethod]
        public void Calculate_Double4MultDouble3_Double12Returned()
        {
            var ob = new object[] {4.0, "*", 3.0};
            var calc = new CalcLogic();
            var res = calc.Calculate(ob);
            Assert.AreEqual(12.0,res);
        }
        [TestMethod]
        public void Calculate_Double4unexpectedSymbolDouble3_Double1Returned()
        {
            void TmpMethod()
            {
                var ob = new object[] {4.0, "^", 3.0};
                var calc = new CalcLogic();
                var res = calc.Calculate(ob);
            }

            Assert.ThrowsException<Exception> (TmpMethod);
        }

        [TestMethod]
        public void Activate_TestCorrectWorkWithoutAnyExceptions()
        {
            var calc = new CalcLogic();
            bool flag;
            try
            {
                calc.Activate("4 + 124");
                flag = true;
            }
            catch
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }
    }
}