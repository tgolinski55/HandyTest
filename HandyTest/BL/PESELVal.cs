using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    public class PESELVal
    {
        public static bool IsValid(string pesel)
        {
            var regex = new Regex("^\\d{11}$");

            if (!regex.IsMatch(pesel))
            {
                return false;
            }

            int checkSum = PESELValidator.Calculate(pesel);
            int lastDigit = pesel.Last() - '0';

            return lastDigit == checkSum;
        }
    }
}

