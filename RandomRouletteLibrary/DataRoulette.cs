using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RandomRouletteLibrary
{
    public class DataRoulette 
    {
        private MyImage img; 
        private MyNumber numb;

        #region Properties 

        public MyImage GetImage
        {
            get { return img; }
        }

        public MyNumber GetNumber
        {
            get { return numb; }
        }

        public int Number
        {
            get { return numb.CurrentNumb; }
            private set { }
        }

        public string Name
        {
            get { return img.Name; }
            private set { }
        }

        public string PathToImage
        {
            get { return img.PathToFile; }
            private set { }
        }

        public BitmapImage Image
        {
            get { return new BitmapImage(new Uri(img.PathToFile)); }
            private set { }
        }
        #endregion

        #region Constructor
        public DataRoulette()
        {
            numb = new MyNumber();
            img = new MyImage();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Initialize random methods
        /// </summary>
        public void InitializeRandom()
        {
            img.GetRandom();
            numb.GetRandom();
        }
        
        /// <summary>
        /// Method is compare results in game
        /// </summary>
        /// <param name="data1">Data from thread 1</param>
        /// <param name="data2">Data from thread 2</param>
        /// <param name="data3">Data from thread 3</param>
        /// <returns>Return the total amount of points</returns>
        public int CompareResult(DataRoulette data1, DataRoulette data2, DataRoulette data3)
        {
            int res = 0;
            res += img.CheckImages(data1.Name, data2.Name, data3.Name);
            res += numb.CheckNumbers(data1.Number, data2.Number, data3.Number);

            // Value 100 that is jack point. The all images and numbers are same
            if (res == 100)
                return res + 100;

            res += (data1.Number + data2.Number + data3.Number) / 2;
            return res;
        }
        #endregion

    }
}
