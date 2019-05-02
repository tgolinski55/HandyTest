using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HandyTest.BL
{
    public class ProjectPath
    {
        public string GetProjectsPath(string element)
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
