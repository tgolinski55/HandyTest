using HandyTest.BL;
using System.IO;
using HandyTest.Pages;
using System.Linq;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for AllIssues.xaml
    /// </summary>
    public partial class AllIssues : UserControl
    {
        public AllIssues()
        {
            InitializeComponent();
        }

        private void PreviousWindowBtn(object sender, RoutedEventArgs e)
        {
            PageNavigator.Switch(new HomeView());
            var mainWindow = new HomeView();
            mainWindow.ReloadDataGrid();
        }
        public string activeProject;
        private void LoadAllIssues(object sender, RoutedEventArgs e)
        {
            string path = @"..//../Projects/" + activeProject + "/Reports";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            int count = 1;
            FileInfo[] AllFiles = dirInfo.GetFiles("*.xml");
            foreach (var o in AllFiles)
            {               
                allIssuesTree.Items.Add(Path.GetFileNameWithoutExtension("["+count.ToString()+"] "+o.Name));
                count++;
            }
        }

        private void AddPriorityItems(object sender, RoutedEventArgs e)
        {
            setpriorityCombo.Items.Add("Critical");
            setpriorityCombo.Items.Add("Major");
            setpriorityCombo.Items.Add("Medium");
            setpriorityCombo.Items.Add("Minor");
            setpriorityCombo.Items.Add("Cosmetics");
        }

        private void AddTypeItems(object sender, RoutedEventArgs e)
        {
            setreporttypeCombo.Items.Add("Task");
            setreporttypeCombo.Items.Add("Bug");
            setreporttypeCombo.Items.Add("Feature");
        }

        private void AddStateItems(object sender, RoutedEventArgs e)
        {
            setstateCombo.Items.Add("Submitted");
            setstateCombo.Items.Add("Success");
            setstateCombo.Items.Add("Failure");
            setstateCombo.Items.Add("Won't Fix");
        }
        private void SetCurrentData()
        {
            var currentData = DateTime.Today;
            setreportDateFile.Text = currentData.ToShortDateString();
        }
    }
}
