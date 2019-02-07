using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HandyTest.BL
{
    class LoadIssuesInfo
    {
        public static string GetIssueInfo(string projectName, string element, string issueSummary)
        {
            string path = GetProjectsPath("ProjectsPath") + "/" + projectName + "/Reports/" + issueSummary + ".xml";
            XmlDocument xmlFile = new XmlDocument();

            if (File.Exists(path))
            {
                xmlFile.Load(path);
                XmlNodeList xmlNodeList = xmlFile.GetElementsByTagName(element);
                element = xmlNodeList.Item(0).InnerText;
            }
            else
            {
                element = "";
            }
            return element;
        }

        private static string GetProjectsPath(string element)
        {
            string pathToConfig = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\HandyTest\\config.xml";
            XmlDocument xmlFile = new XmlDocument();

            if (File.Exists(pathToConfig))
            {
                xmlFile.Load(pathToConfig);
                XmlNodeList xmlNodeList = xmlFile.GetElementsByTagName(element);
                element = xmlNodeList.Item(0).InnerText;
            }
            else
            {
                element = "";
            }
            return element;
        }
    }
}
