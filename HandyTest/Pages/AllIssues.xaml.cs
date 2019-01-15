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
using Spire.Doc;
using Spire.Doc.Documents;
using System.ComponentModel;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for AllIssues.xaml
    /// </summary>
    public partial class AllIssues : UserControl
    {
        ObservableCollection<IssuesList> issuesLists = new ObservableCollection<IssuesList>();
        ObservableCollection<CreateReport> createReports = new ObservableCollection<CreateReport>();
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
                int.TryParse(LoadIssuesInfo.GetIssueInfo(activeProject, "ID", Path.GetFileNameWithoutExtension(o.Name)), out issueID);
                allIssuesDataGrid.ItemsSource = issuesLists;
                issuesLists.Add(new IssuesList(Path.GetFileNameWithoutExtension(o.Name), issueID));
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
            if (allIssuesDataGrid.SelectedIndex >= 0)
            {

                selectedIssue = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;

                GetIssueInfo(selectedIssue);

                issueInfoPanel.IsEnabled = true;
                issueInfoPanel.Opacity = 1;

                var issueNumber = allIssuesDataGrid.SelectedCells[1];

                selectedIssueNumber = (issueNumber.Column.GetCellContent(issueNumber.Item) as TextBlock).Text;
                issueInfoPanel.Header = "Issue Info: #" + selectedIssueNumber;
            }

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

        private void DeleteIssue(object sender, RoutedEventArgs e)
        {
            string path = @"..//../Projects/" + activeProject + "/Reports/" + selectedIssue + ".xml";
            if (File.Exists(path))
                File.Delete(path);

            issuesLists.Clear();
            LoadAllIssues(sender, e);
            editButton.IsChecked = false;

            setAuthor.Clear();
            setBuildVersion.Clear();
            SetCurrentData();
            setpriorityCombo.SelectedIndex = 2;
            setreporttypeCombo.SelectedIndex = 1;
            setstateCombo.SelectedIndex = 0;
            setSummary.Clear();
            settextBoxDescription.Clear();
            issueInfoPanel.Header = "Issue info: ";
            //DecreaseIssueCount(); TBD - this might be redundant
        }

        private void DecreaseIssueCount()
        {
            string path = @"..//../Projects/" + activeProject + "/config.txt";
            var tempID = File.ReadAllText(path);
            Int32.TryParse(tempID, out int x);
            File.WriteAllText(path, (x - 1).ToString());
        }

        private void EditIssue()
        {
            string pathToID = @"..//../Projects/" + activeProject + "/config.txt";
            string path = @"..//../Projects/" + activeProject + "/Reports/" + setSummary.Text + ".xml";
            var tempID = LoadIssuesInfo.GetIssueInfo(activeProject, "ID", selectedIssue);
            createReports.Add(new CreateReport(setAuthor.Text, setBuildVersion.Text, setreportDateFile.Text, setpriorityCombo.Text, setreporttypeCombo.Text, setstateCombo.Text));
            new XDocument(
                new XElement("root",
                    new XElement("ID", tempID),
                    new XElement("Author", setAuthor.Text),
                    new XElement("BuildVersion", setBuildVersion.Text),
                    new XElement("Date", setreportDateFile.Text),
                    new XElement("Priority", setpriorityCombo.Text),
                    new XElement("Type", setreporttypeCombo.Text),
                    new XElement("State", setstateCombo.Text),
                    new XElement("Description", settextBoxDescription.Text))
                    )
            .Save(path);
            if (selectedIssue != setSummary.Text)
                File.Delete(@"..//../Projects/" + activeProject + "/Reports/" + selectedIssue + ".xml");

        }

        private void UpdatePriority(object sender, SelectionChangedEventArgs e)
        {
            //EditIssue();
        }

        private void SaveIssueChanges(object sender, RoutedEventArgs e)
        {
            EditIssue();
            issuesLists.Clear();
            LoadAllIssues(sender, e);
        }

        private void CreateReportFile(object sender, RoutedEventArgs e)
        {
            var currentDate = DateTime.Today.ToString("dd-MM-yyyy");
            string pathToReport = @"..//../Projects/" + activeProject + "-Documentation-" + currentDate + ".docx";
            Document summaryReport = new Document();

            Paragraph paragraph = summaryReport.AddSection().AddParagraph();
            paragraph.AppendText("Summary report");
            string pathToTemplate = @"..//../Projects/ReportTemplate.docx";
            summaryReport.LoadFromFile(pathToTemplate);


            #region footer
            HeaderFooter footer = summaryReport.Sections[0].HeadersFooters.Footer;
            Paragraph footerParagraph = footer.AddParagraph();

            footerParagraph.AppendField("Page number", FieldType.FieldPage);
            footerParagraph.AppendText(" of ");
            footerParagraph.AppendField("Number of pages", FieldType.FieldNumPages);
            footerParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
            #endregion

            #region header
            HeaderFooter header = summaryReport.Sections[0].HeadersFooters.Header;
            Paragraph headerParagraph = header.AddParagraph();

            headerParagraph.AppendText(activeProject);
            headerParagraph.ApplyStyle(BuiltinStyle.NoteHeading);
            #endregion

            #region firstPage
            Section firstPage = summaryReport.AddSection();
            Paragraph tableOfContent = firstPage.AddParagraph();

            tableOfContent.AppendTOC(1, 3);

            Paragraph firstItem = firstPage.AddParagraph();
            firstItem.AppendText("1. Introduction");
            firstItem.ApplyStyle(BuiltinStyle.Heading2);

            Paragraph secondItem = firstPage.AddParagraph();
            secondItem.AppendText("2. Materials & Equipment");
            secondItem.ApplyStyle(BuiltinStyle.Heading2);

            Paragraph thirdItem = firstPage.AddParagraph();
            thirdItem.AppendText("3. Test Cases / Testing");
            
            foreach (var item in issuesLists)
            {
                Table table = firstPage.AddTable(true);
                table.ResetCells(2, 2);
            }

            thirdItem.ApplyStyle(BuiltinStyle.Heading2);

            Paragraph fourthItem = firstPage.AddParagraph();
            fourthItem.AppendText("4. Conclusion");
            fourthItem.ApplyStyle(BuiltinStyle.Heading2);

            summaryReport.UpdateTableOfContents();
            #endregion



            summaryReport.SaveToFile(pathToReport, FileFormat.Docx);
        }
    }
}
