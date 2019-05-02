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
            ProjectPath pathToProjects = new ProjectPath();
            string path = pathToProjects.GetProjectsPath("ProjectsPath") + "/" + projectName + "/Reports/" + issueSummary + ".xml";
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
    }
}
