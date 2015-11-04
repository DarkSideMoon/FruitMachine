using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomRouletteLibrary
{
    public static class MethodsExtensions
    {
        public static Int32 RoundToHundrets(this int input)
        {
            string str = input.ToString().Substring(0, 1);
            string newStr = string.Concat(str, "00");

            input = int.Parse(newStr);
            return (Int32)input;
        }
    }
}
