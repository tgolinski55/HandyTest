using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    public class MailGen
    {
        public string Generate()
        {
            return FirstPart() + DomainPart() + PrefixPart();
        }
        static Random randomizeCharTab = new Random();
        Random random = new Random();
        private string FirstPart()
        {
            var charsTab = new List<string>();
            var numbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            var letter = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "w", "x", "y", "z" };
            string generatedMail = "";

            foreach (var s in numbers)
                charsTab.Add(s);
            foreach (var x in letter)
                charsTab.Add(x);

            for (int i = 0; i < random.Next(3, 11); i++)
            {
            var shuffleTab = charsTab.OrderBy(a => Guid.NewGuid()).ToList();
                int randomValue = randomizeCharTab.Next(shuffleTab.Count);
                generatedMail += (string)shuffleTab[randomValue];
            }
            return generatedMail + "@";
        }

        private string DomainPart()
        {
            var domains = new List<string> { "gmail", "onet", "yahoo", "o2", "roundcube", "zoho", "outlook", "random" };

            var randomDomain = randomizeCharTab.Next(domains.Count);
            return (string)domains[randomDomain];
        }

        private string PrefixPart()
        {
            var prefixes = new List<string> { ".com", ".pl", ".eu", ".de", ".dot", ".it", ".net" };

            var randomPrefix = randomizeCharTab.Next(prefixes.Count);
            return (string)prefixes[randomPrefix];
        }
    }
}
