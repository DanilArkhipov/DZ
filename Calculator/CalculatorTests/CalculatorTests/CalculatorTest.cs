using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void SumTest()
        {
            var calc = new Calculator.Calculator();
            Assert.AreEqual(5.0, calc.Sum("2", "3"));
            Assert.AreEqual(0, calc.Sum("0", "0"));
            Assert.AreEqual(-2.234, calc.Sum("-1", "-1,234"));
        }
        [TestMethod]
        public void SubTest()
        {
            var calc = new Calculator.Calculator();
            Assert.AreEqual(5.0, calc.Sub("4,0", "-1"));
            Assert.AreEqual(5.0, calc.Sub("10,0", "5"));
        }
        [TestMethod]
        public void MultTest()
        {
            var calc = new Calculator.Calculator();
            Assert.AreEqual(0, calc.Mult("4", "0"));
            Assert.AreEqual(15, calc.Mult("-5", "-3"));
            Assert.AreEqual(-15, calc.Mult("-5", "3"));
            Assert.AreEqual(15, calc.Mult("5", "3"));
        }
        [TestMethod]
        public void DivTest()
        {
            var calc = new Calculator.Calculator();
            Assert.AreEqual(0, calc.Div("0", "2,5"));
            Assert.AreEqual(5, calc.Div("0,5", "0,1"));
        }
    }
}
