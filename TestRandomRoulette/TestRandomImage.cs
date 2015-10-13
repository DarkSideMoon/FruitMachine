using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomRouletteLibrary;

namespace TestRandomRoulette
{
    [TestClass]
    public class TestRandomImage
    {
        [TestMethod]
        public void TestSearchImages()
        {
            // Average - create new object of MyImage
            MyImage image = new MyImage();

            // Act - search images in folder
            // Will be private method
            var images = image.SearchImages();

            // Assert check images count
            // Need value: 5
            Assert.AreEqual(images.Count, 5);
        }

        [TestMethod] 
        public void TestRandomImageMethod()
        {
            // Average - create new object of MyImage
            // Average - get all images 
            MyImage image = new MyImage();
            var images = image.SearchImages();

            // Act - get random image form directory
            var img = image.GetRandom();

            // Act - delete image wich is same with random
            for (int i = 0; i < images.Count; i++)
                if (img.Name == images[i].Name)
                    images.RemoveAt(i);

            // Assert check is count list of images
            // Need value: 4
            Assert.AreEqual(images.Count, 4);

            // Assert check is random image
            // Need value: random
            foreach (var item in images)
                Assert.AreNotEqual(img, item);
        }
    }
}
