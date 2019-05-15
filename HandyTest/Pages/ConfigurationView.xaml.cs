using HandyTest.BL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : System.Windows.Controls.UserControl
    {
        ProjectPath pathToProjects = new ProjectPath();

        public ConfigurationView()
        {
            InitializeComponent();
            projectsPath.Text = pathToProjects.GetProjectsPath("ProjectsPath");
            screenshootsPath.Text = pathToProjects.GetProjectsPath("ScreenshotsPath");
        }
        //private string GetProjectsPath(string element)
        //{
        //    string pathToConfig = System.IO.Path.GetFullPath(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\HandyTest\\config.xml");
        //    XmlDocument xmlFile = new XmlDocument();

        //    if (File.Exists(pathToConfig))
        //    {
        //        xmlFile.Load(pathToConfig);
        //        XmlNodeList xmlNodeList = xmlFile.GetElementsByTagName(element);
        //        element = xmlNodeList.Item(0).InnerText;
        //    }
        //    else
        //    {
        //        element = "";
        //    }
        //    return element;
        //}
        private void PreviousWindowBtn(object sender, RoutedEventArgs e)
        {
            PageNavigator.Switch(new HomeView());
            var mainWindow = new HomeView();
            mainWindow.ReloadDataGrid();
        }

        private void OpenWidowsDialog(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                //DialogResult result = dialog.ShowDialog();

                string path = pathToProjects.GetProjectsPath("ProjectsPath");
                string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (DialogResult.OK == dialog.ShowDialog())
                {

                    try
                    {
                        Directory.CreateDirectory(dialog.SelectedPath);
                        //projectsPath.Text = dialog.SelectedPath;
                        projectsPath.Text = defaultPath + "\\HandyTest\\Projects";
                        SaveNewPaths();
                    }
                    catch
                    {
                        projectsPath.Text = defaultPath + "\\HandyTest\\Projects";
                        SaveNewPaths();
                    }
                }
            }

        }

        private void OpenSSPathDialog(object sender, RoutedEventArgs e)
        {

            string path = pathToProjects.GetProjectsPath("ProjectsPath");
            string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (var dialog = new FolderBrowserDialog())
            {
                //DialogResult result = dialog.ShowDialog();

                if (DialogResult.OK == dialog.ShowDialog())
                {

                    try
                    {
                        Directory.CreateDirectory(dialog.SelectedPath);
                        screenshootsPath.Text = dialog.SelectedPath;
                        SaveNewPaths();
                    }
                    catch
                    {
                        screenshootsPath.Text = defaultPath + "\\HandyTest\\Screenshots";
                        SaveNewPaths();
                    }
                }
            }
        }

        private void SaveNewPaths()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(path + "HandyTest/config.xml"))
            {
                Directory.CreateDirectory(path + "\\HandyTest");
            }
            new XDocument(
                new XElement("root",
                    new XElement("ProjectsPath", projectsPath.Text),
                    new XElement("ScreenshotsPath", screenshootsPath.Text))
                    )
            .Save(path + "/HandyTest/config.xml");
        }
    }
}
