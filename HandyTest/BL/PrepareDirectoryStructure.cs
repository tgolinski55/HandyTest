using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HandyTest.BL
{
    public class PrepareDirectoryStructure
    {
        public void CreateSetupDirectories()
        {
            ProjectPath pathToProjects = new ProjectPath();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!File.Exists(path + "HandyTest/config.xml"))
            {
                Directory.CreateDirectory(path + "\\HandyTest");
            }
            if (!Directory.Exists(path + "HandyTest/Projects"))
                Directory.CreateDirectory(path + "\\HandyTest\\Projects");
            if (!Directory.Exists(path + "HandyTest/Screenshots"))
                Directory.CreateDirectory(path + "\\HandyTest\\Screenshots");
            if (pathToProjects.GetProjectsPath("ProjectsPath") == "" || pathToProjects.GetProjectsPath("ScreenshotsPath") == "")
            {
                new XDocument(
                    new XElement("root",
                        new XElement("ProjectsPath", path + "\\HandyTest\\Projects"),
                        new XElement("ScreenshotsPath", path + "\\HandyTest\\Screenshots"))
                        )
                .Save(path + "/HandyTest/config.xml");
            }
        }
    }
}
