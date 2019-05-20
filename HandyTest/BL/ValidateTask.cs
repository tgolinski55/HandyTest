using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyTest.BL
{
    public class ValidateTask
    {
        public bool ValidateLink()
        {
            string webContent = "";
            try
            {
                using (var sr = new StreamReader("App.dll"))
                {
                    webContent = sr.ReadLine();
                }
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(webContent);
                var isEnded = Convert.ToBoolean(GetBetween(doc.Text, "ended: ", ","));
                return !isEnded;
            }
            catch
            {
                return false;
            }

        }
        public static string GetBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}
