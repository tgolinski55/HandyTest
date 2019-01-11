using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HandyTest.BL
{
    class LoadCurrentProject
    {
        string path = @"..//../Projects/ActiveProjectInfo.xml";
        //string path = @"..//../Projects/xD/Reports/xD.xml";
        XmlDocument xmlFile = new XmlDocument();

        public string GetCurrentProject()
        {
            string projectName;
            if (File.Exists(path))
            {
                xmlFile.Load(path);
                XmlNodeList xmlNodeList = xmlFile.GetElementsByTagName("Project");
                projectName = xmlNodeList.Item(0).InnerText;
            }
            else
            {
                projectName = "";
            }
            return projectName;
        }
        public int GetCurrentIndex()
        {
            int x = 0;
            if (File.Exists(path))
            {
                xmlFile.Load(path);
                XmlNodeList xmlNodeList = xmlFile.GetElementsByTagName("Id");
                string projectIndex = xmlNodeList.Item(0).InnerText;
                int.TryParse(projectIndex, out x);

            }
            else
                x = 0;
            return x;
        }
    }
}
