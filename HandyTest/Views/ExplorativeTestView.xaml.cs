using System;
using System.Windows;
using HandyTest.BL;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.IO;
using HandyTest.Pages;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.ComponentModel;
using System.Windows.Media;

namespace HandyTest.Views
{
    /// <summary>
    /// Interaction logic for ExplorativeTestView.xaml
    /// </summary>
    public partial class ExplorativeTestView : Window
    {

        public static ObservableCollection<IssuesList> issuesList = new ObservableCollection<IssuesList>();
        ObservableCollection<CreateReport> createReports = new ObservableCollection<CreateReport>();
        LoadCurrentProject loadCurrentProject = new LoadCurrentProject();
        ProjectPath pathToProjects = new ProjectPath();

        int issueID = 0;
        public ExplorativeTestView()
        {
            InitializeComponent();
            SetCurrentData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;

        }
        private void PreviousWindowBtn(object sender, RoutedEventArgs e)
        {
            this.Hide();
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
            setreporttypeCombo.Items.Add("Automation");
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

        private void ChangeFocusIfTabIsPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                settextBoxDescription.Focus();
                e.Handled = true;
            }
        }
        private void SaveProjectConfig()
        {
            string pathToConfig = pathToProjects.GetProjectsPath("ProjectsPath") + "/" + activeProject + "/";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(pathToConfig, "IssuesNumber.txt"), false))
            {
                outputFile.Write(issueID + 1);
            }
        }
        private int GetProjectConfig()
        {

            string pathToConfig = Path.Combine(pathToProjects.GetProjectsPath("ProjectsPath") + "/" + activeProject + "/", "IssuesNumber.txt");
            if (!File.Exists(pathToConfig))
            {
                //File.Create(pathToConfig);
                //File.WriteAllText(pathToConfig, "1");
                using (StreamWriter outputFile = new StreamWriter(pathToConfig, false))
                {
                    outputFile.Write("0");
                }
            }
            try
            {
                using (StreamReader configFile = new StreamReader(pathToConfig))
                {
                    string addictiveIssueID = configFile.ReadLine();
                    int.TryParse(addictiveIssueID, out issueID);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return issueID;
        }
        private string ValidateEmptyFields()
        {
            var msg = "";
            //if (setAuthor.Text == "")
            //    msg += "Author is required";
            if (setBuildVersion.Text == "")
            {
                if (msg != "")
                    msg += Environment.NewLine;
                msg += "Build version is required";
            }
            if (setSummary.Text == "")
            {
                if (msg != "")
                    msg += Environment.NewLine;
                msg += "Summary is required";
            }

            return msg;
        }
        public string activeProject;
        private void CreateExplorativeReport(object sender, RoutedEventArgs e)
        {
            if (ValidateEmptyFields() != "")
                MessageBox.Show(ValidateEmptyFields(), "Missing key infromations", MessageBoxButton.OKCancel, MessageBoxImage.Stop);
            else
            {
                string path = pathToProjects.GetProjectsPath("ProjectsPath") + "/" + activeProject + "/";
                if (File.Exists(path + "Reports/" + setSummary.Text + ".xml"))
                {
                    MessageBox.Show("Issue with name: '" + setSummary.Text + "' already exists. Please select different name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    GetProjectConfig();
                    createReports.Add(new CreateReport(setAuthor.Text, setBuildVersion.Text, setreportDateFile.Text, setpriorityCombo.Text, setreporttypeCombo.Text, setstateCombo.Text));
                    new XDocument(
                        new XElement("root",
                            new XElement("ID", issueID + 1),
                            new XElement("Author", setAuthor.Text),
                            new XElement("BuildVersion", setBuildVersion.Text),
                            new XElement("Date", setreportDateFile.Text),
                            new XElement("Priority", setpriorityCombo.Text),
                            new XElement("Type", setreporttypeCombo.Text),
                            new XElement("State", "Won't Fix"),
                            new XElement("Description", settextBoxDescription.Text))
                            )
                    .Save(path + "Reports/" + setSummary.Text + ".xml");
                    this.Hide();


                    AllIssues.issuesLists.Add(new IssuesList(setSummary.Text, issueID + 1));
                    summaryValidatorPopup.IsOpen = false;
                    setAuthor.Clear();
                    setBuildVersion.Clear();
                    SetCurrentData();
                    setpriorityCombo.SelectedIndex = 2;
                    setreporttypeCombo.SelectedIndex = 1;
                    setstateCombo.SelectedIndex = 0;
                    setSummary.Clear();
                    settextBoxDescription.Clear();
                    SaveProjectConfig();
                }
            }
        }

        private void SummaryValidator(object sender, KeyEventArgs e)
        {
            string path = pathToProjects.GetProjectsPath("ProjectsPath") + "/" + activeProject + "/Reports";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] AllFiles = dirInfo.GetFiles("*.xml");

            summaryValidator.ItemsSource = null;

            if (setSummary.Text.Length > 0)
            {
                summaryValidator.ItemsSource = null;
                summaryValidatorPopup.IsOpen = true;

                var filteredIssues = issuesList.Where(issues => issues.Name.ToLower().Contains(setSummary.Text.ToLower()));
                summaryValidator.ItemsSource = filteredIssues;

            }
            else
                summaryValidatorPopup.IsOpen = false;
            foreach (var o in AllFiles)
            {
                if (Path.GetFileNameWithoutExtension(o.Name).ToLower() == setSummary.Text.ToLower())
                    createReportBtn.IsEnabled = true;
                else
                    createReportBtn.IsEnabled = true;
            }
        }

        private void LoadIssuesFilter(object sender, RoutedEventArgs e)
        {
            if (summaryValidator.ItemsSource == null)
            {

                string path = pathToProjects.GetProjectsPath("ProjectsPath") + "/" + activeProject + "/Reports";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                FileInfo[] AllFiles = dirInfo.GetFiles("*.xml");


                foreach (var o in AllFiles)
                {
                    int issueID = 0;
                    int.TryParse(LoadIssuesInfo.GetIssueInfo(activeProject, "ID", Path.GetFileNameWithoutExtension(o.Name)), out issueID);

                    if (!issuesList.Contains(new IssuesList(Path.GetFileNameWithoutExtension(o.Name), issueID)))
                        issuesList.Add(new IssuesList(Path.GetFileNameWithoutExtension(o.Name), issueID));
                }
                //summaryValidator.ItemsSource = issuesList;
            }
        }

        private void ClosePopUpOnFoucsLst(object sender, RoutedEventArgs e)
        {
            summaryValidatorPopup.IsOpen = false;
        }

        private void OpenPopUpOnGetFocus(object sender, RoutedEventArgs e)
        {
            summaryValidatorPopup.IsOpen = true;
            issuesList.Clear();
            string path = pathToProjects.GetProjectsPath("ProjectsPath") + "/" + activeProject + "/Reports";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] AllFiles = dirInfo.GetFiles("*.xml");


            foreach (var o in AllFiles)
            {
                int issueID = 0;
                int.TryParse(LoadIssuesInfo.GetIssueInfo(activeProject, "ID", Path.GetFileNameWithoutExtension(o.Name)), out issueID);

                if (!issuesList.Contains(new IssuesList(Path.GetFileNameWithoutExtension(o.Name), issueID)))
                    issuesList.Add(new IssuesList(Path.GetFileNameWithoutExtension(o.Name), issueID));

            }

            //summaryValidator.ItemsSource = issuesList;

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
        }
    }
}
