using System;
using RandomRouletteLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestRandomRoulette
{
    [TestClass]
    public class TestThreadRandom
    {
        [TestMethod]
        public void TestThread()
        {
            DataRoulette data = new DataRoulette();
            ThreadRoulette thread = new ThreadRoulette("Pasha's thread! Cool!");

            // Если раскоментить то все получиться) Урааа) круто)) ахха
            thread.Thrd.Join();

            Assert.IsNotNull(thread.RoulutteData);
        }
    }
}
