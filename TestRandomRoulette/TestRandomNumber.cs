using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomRouletteLibrary;

namespace TestRandomRoulette
{
    [TestClass]
    public class TestRandomNumber
    {
        [TestMethod]
        public void TestRandomNumb()
        {
            // Average - create object of MyNumber
            MyNumber number = new MyNumber();

            // Act - get random number
            number.GetRandom();

            // Asser - check that numbers is match
            // MyNumber.PreviousNumb = 0;
            Assert.AreEqual(MyNumber.PreviousNumb, 0);

            // Asser - check that numbers is not match
            Assert.AreNotEqual(MyNumber.PreviousNumb, number.GetRandom());
        }
    }
}
