using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HandyTest.BL
{
        public class NIPValidator
        {
            public static bool IsValid(string nip)
            {
                var regex = new Regex("^\\d{10}$");
                if (!regex.IsMatch(nip))
                {
                    return false;
                }

                int checkSum = NipCheckSumCalculator.Calculate(nip);

                if (nip.Last() - '0' != checkSum)
                {
                    return false;
                }

                return TaxOffice.Codes.Contains(nip.Substring(0, 3));
            }
        }
}
