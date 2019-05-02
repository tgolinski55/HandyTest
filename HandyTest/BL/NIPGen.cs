using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    public class NIPGen
    {
        private readonly Random _random;

        public NIPGen()
        {
            _random = new Random();
        }

        private string GenerateRandomNumbers(int numbersCount)
        {
            int maxValue = (int)Math.Pow(10, numbersCount);
            string format = "D" + numbersCount;

            return _random.Next(maxValue).ToString(format);
        }

        public string Generate()
        {
            var nipNumberBuilder = new StringBuilder();

            string taxOfficePrefix = TaxOfficeCodes.Codes[_random.Next(TaxOfficeCodes.Codes.Length)];

            nipNumberBuilder.Append(taxOfficePrefix);

            nipNumberBuilder.Append(GenerateRandomNumbers(6));

            int checksum = ValidateNIP.CheckIfNipIsCorrect(nipNumberBuilder.ToString());

            while (checksum == 10)
            {
                // change last number, check sum must be different from 10
                nipNumberBuilder.Remove(nipNumberBuilder.Length - 1, 1);
                nipNumberBuilder.Append(_random.Next(10).ToString());

                checksum = ValidateNIP.CheckIfNipIsCorrect(nipNumberBuilder.ToString());
            }

            nipNumberBuilder.Append(checksum);

            return nipNumberBuilder.ToString();
        }

    }
}
