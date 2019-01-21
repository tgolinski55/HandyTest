using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    class PESELValidator
    {
        private static readonly int[] _Weight = new[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        public static int Calculate(string pesel)
        {
            int checkSum = pesel.Zip(_Weight, (digit, weight) => (digit - '0') * weight)
                .Sum();

            int lastDigit = checkSum % 10;

            return lastDigit == 0 ? 0 : 10 - lastDigit;
        }
    }
}
