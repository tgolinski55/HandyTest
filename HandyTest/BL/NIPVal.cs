using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    internal class NipCheckSumCalculator
    {
        readonly static int[] _Weight = new[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };

        public static int Calculate(string nip)
        {
            int checkSum = nip.Zip(_Weight, (digit, weight) => (digit - '0') * weight)
                .Sum();

            return checkSum % 11;
        }
    }
}

