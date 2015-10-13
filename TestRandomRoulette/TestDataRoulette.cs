using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomRouletteLibrary;
using System.Windows.Media.Imaging;

namespace TestRandomRoulette
{
    [TestClass]
    public class TestDataRoulette
    {
        [TestMethod]
        public void TestData()
        {
            // Avarage
            DataRoulette data = new DataRoulette();
            //data.InitializeRandom();

            //var s = data.Name + data.Number + data.PathToImage;

            // Assert - check types of returns values 
            //Assert.AreEqual(data.Image, typeof(BitmapImage));
            //Assert.AreEqual(data.Name, typeof(string));
            //Assert.AreEqual(data.Number, typeof(int));
            //Assert.AreEqual(data.PathToImage, typeof(string));
        }
    }
}
