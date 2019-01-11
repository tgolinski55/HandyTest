using HandyTest.BL;
using System.IO;
using HandyTest.Pages;
using System.Linq;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.ComponentModel;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for AllIssues.xaml
    /// </summary>
    public partial class AllIssues : UserControl
    {
        ObservableCollection<IssuesList> issuesLists = new ObservableCollection<IssuesList>();
        string selectedIssue;
        string selectedIssueNumber;
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
                int issueID = 0;
                int.TryParse(LoadIssuesInfo.GetIssueInfo(activeProject, "ID", Path.GetFileNameWithoutExtension(o.Name)),out issueID);
                allIssuesDataGrid.ItemsSource = issuesLists;
                issuesLists.Add(new IssuesList(Path.GetFileNameWithoutExtension(o.Name),issueID));
                count++;
            }
            SortDataGrid(allIssuesDataGrid, 1, ListSortDirection.Ascending);
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

        private void SelectedIssueChange(object sender, SelectionChangedEventArgs e)
        {
            
            var cellInfo = allIssuesDataGrid.SelectedCells[2];
            selectedIssue = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;

            GetIssueInfo(selectedIssue);

            issueInfoPanel.IsEnabled = true;
            issueInfoPanel.Opacity = 1;

            var issueNumber = allIssuesDataGrid.SelectedCells[1];
            
            selectedIssueNumber = (issueNumber.Column.GetCellContent(issueNumber.Item) as TextBlock).Text;
            issueInfoPanel.Header = "Issue Info: #" + selectedIssueNumber;

        }

        public void SortDataGrid(DataGrid allIssuesDataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Descending)
        {

            if (allIssuesDataGrid.Items.Count > 0)
            {
                var column = allIssuesDataGrid.Columns[columnIndex];
                allIssuesDataGrid.Items.SortDescriptions.Clear();
                allIssuesDataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));
                foreach (var col in allIssuesDataGrid.Columns)
                {
                    col.SortDirection = null;
                }
                column.SortDirection = sortDirection;
                allIssuesDataGrid.Items.Refresh();
            }
            //MakeActiveProjectBtn_Click(makeActiveProjectBtn, new RoutedEventArgs());
        }

        public void GetIssueInfo(string issueSummary)
        {
            setAuthor.Text = LoadIssuesInfo.GetIssueInfo(activeProject, "Author", issueSummary);
            setBuildVersion.Text = LoadIssuesInfo.GetIssueInfo(activeProject, "BuildVersion", issueSummary);
            setreportDateFile.Text = LoadIssuesInfo.GetIssueInfo(activeProject, "Date", issueSummary);

            setpriorityCombo.Text = LoadIssuesInfo.GetIssueInfo(activeProject, "Priority", issueSummary);
            setreporttypeCombo.Text = LoadIssuesInfo.GetIssueInfo(activeProject, "Type", issueSummary);
            setstateCombo.Text = LoadIssuesInfo.GetIssueInfo(activeProject, "State", issueSummary);

            setSummary.Text = issueSummary;
            settextBoxDescription.Text = LoadIssuesInfo.GetIssueInfo(activeProject, "Description", issueSummary);


        }
    }
}
