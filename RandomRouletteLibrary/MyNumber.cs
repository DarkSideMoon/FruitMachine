using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomRouletteLibrary
{
    public class MyNumber
    {
        #region Properties
        public int CurrentNumb { get; set; }
        public static int PreviousNumb { get; set; }
        public static int CurrentResult { get; set; }
        #endregion

        #region Constructor
        public MyNumber()
        {
            CurrentNumb = 0;
            PreviousNumb = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Random numbers
        /// </summary>
        /// <returns>Return random number</returns>
        public int GetRandom()
        {
            Random random = new Random();
            PreviousNumb = CurrentNumb;
            CurrentNumb = random.Next(0, 100);
            return CurrentNumb;
        }

        public static int SumDivByTwo(int one, int two, int three)
        {
            return (one + two + three) / 2;
        }

        /// <summary>
        /// Compare numbers
        /// </summary>
        /// <param name="num1">Number 1</param>
        /// <param name="num2">Number 2</param>
        /// <param name="num3">Number 3</param>
        /// <returns>>Return the total amount of points</returns>
        internal int CheckNumbers(int num1, int num2, int num3)
        {
            if ((num1 >= 50 && num2 >= 50) ||
                (num2 >= 50 && num3 >= 50) ||
                (num1 >= 50 && num3 >= 50))
            {
                CurrentResult = 40;
                return 40;
            }
            if ((num1 >= 90 && num2 >= 90) ||
                (num2 >= 90 && num3 >= 90) ||
                (num1 >= 90 && num3 >= 90))
            {
                CurrentResult = 60;
                return 60;
            }
            if (num1 == num2 && num1 == num3 && num2 == num3)
            {
                CurrentResult = 80;
                return 80;
            }
            if ((num1 <= 50 && num2 <= 50) ||
                (num2 <= 50 && num3 <= 50) ||
                (num1 <= 50 && num3 <= 50))
            {
                CurrentResult = -110;
                return -110;
            }
            else
            {
                CurrentResult = -100;
                return -100;
            }
        }
        #endregion
    }
}
