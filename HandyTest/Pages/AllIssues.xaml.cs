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
using System.Xml;
using Spire.Doc.Fields;
using System.Windows.Data;
using Microsoft.Win32;
using System.Collections.Generic;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for AllIssues.xaml
    /// </summary>
    public partial class AllIssues : UserControl
    {
        public static ObservableCollection<IssuesList> issuesLists = new ObservableCollection<IssuesList>();
        ObservableCollection<CreateReport> createReports = new ObservableCollection<CreateReport>();
        ProjectPath pathToProjects = new ProjectPath();
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
            allIssuesDataGrid.ItemsSource = null;
            issuesLists.Clear();
            allIssuesDataGrid.ItemsSource = issuesLists;
            CollectionViewSource.GetDefaultView(allIssuesDataGrid.ItemsSource).Refresh();
            
            string path = pathToProjects.GetProjectsPath("ProjectsPath") +"/" + activeProject + "/Reports";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            int count = 1;
            FileInfo[] AllFiles = dirInfo.GetFiles("*.xml");

            foreach (var o in AllFiles)
            {
                int issueID = 0;
                int.TryParse(LoadIssuesInfo.GetIssueInfo(activeProject, "ID", Path.GetFileNameWithoutExtension(o.Name)), out issueID);
                //allIssuesDataGrid.ItemsSource = issuesLists;
                
                issuesLists.Add(new IssuesList(Path.GetFileNameWithoutExtension(o.Name), issueID));
                //StatusIndicator(o.Name);
                count++;
            }

            CollectionViewSource.GetDefaultView(allIssuesDataGrid.ItemsSource).Refresh();
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

        private void DeleteConfirm()
        {

            string path = pathToProjects.GetProjectsPath("ProjectsPath") +"/" + activeProject + "/Reports/" + selectedIssue + ".xml";
            if (File.Exists(path))
                File.Delete(path);


        }
        private void DeleteIssue(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("Do you really wan't to delete " + selectedIssue + " test case?", "Information", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);

            if (message == MessageBoxResult.OK)
            {
                DeleteConfirm();
                issuesLists.Clear();
                LoadAllIssues(sender, e);

                setAuthor.Clear();
                setBuildVersion.Clear();
                SetCurrentData();
                setpriorityCombo.SelectedIndex = 2;
                setreporttypeCombo.SelectedIndex = 1;
                setstateCombo.SelectedIndex = 0;
                setSummary.Clear();
                settextBoxDescription.Clear();
                issueInfoPanel.Header = "Issue info: ";
            }
        }

        private void EditIssue()
        {
            string pathToID = pathToProjects.GetProjectsPath("ProjectsPath") +"/" + activeProject + "/config.txt";
            string path = pathToProjects.GetProjectsPath("ProjectsPath") + "/" + activeProject + "/Reports/" + setSummary.Text + ".xml";
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
                File.Delete(pathToProjects.GetProjectsPath("ProjectsPath") + "/" + activeProject + "/Reports/" + selectedIssue + ".xml");
            searchTextField.Text = null;
            filterCounter.Visibility = Visibility.Hidden;
        }

        private void SaveIssueChanges(object sender, RoutedEventArgs e)
        {
            EditIssue();
            issuesLists.Clear();
            LoadAllIssues(sender, e);
        }

        public void CreateReportFile(object sender, RoutedEventArgs e)
        {
            var currentDate = DateTime.Today.ToString("dd-MM-yyyy");
            var fileDialog = new SaveFileDialog();
            fileDialog.DefaultExt = ".docx";
            fileDialog.Filter = "Dokumenty programu Word (.docx)|*.docx";
            Document summaryReport = new Document();
            //string pathToTemplate = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/HandyTest" + "/ReportTemplate.docx";
            string pathToTemplate = "Projects/ReportTemplate.docx";
            summaryReport.LoadFromFile(pathToTemplate);

            try
            {
                if (fileDialog.ShowDialog() == true)
                {

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

                    TextRange projectName = headerParagraph.AppendText(activeProject);
                    projectName.CharacterFormat.Bold = true;
                    projectName.CharacterFormat.FontSize = 12;
                    projectName.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(4485828);

                    headerParagraph.ApplyStyle(BuiltinStyle.NoteHeading);
                    #endregion

                    #region content
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
                    thirdItem.ApplyStyle(BuiltinStyle.Heading2);

                    Table table = firstPage.AddTable(true);
                    table.ResetCells(issuesLists.Count + 1, 4);
                    table.AutoFit(AutoFitBehaviorType.AutoFitToWindow);
                    int counter = 1;

                    TableRow tableHeader = table.Rows[0];
                    Paragraph tableHeaderIDCell = tableHeader.Cells[0].AddParagraph();
                    TextRange text = tableHeaderIDCell.AppendText("ID");
                    text.CharacterFormat.FontSize = 12;
                    text.CharacterFormat.Bold = true;
                    Paragraph tableHeaderNameCell = tableHeader.Cells[1].AddParagraph();
                    text = tableHeaderNameCell.AppendText("Name");
                    text.CharacterFormat.FontSize = 12;
                    text.CharacterFormat.Bold = true;
                    Paragraph tableHeaderStepsCell = tableHeader.Cells[2].AddParagraph();
                    text = tableHeaderStepsCell.AppendText("Steps");
                    text.CharacterFormat.FontSize = 12;
                    text.CharacterFormat.Bold = true;
                    Paragraph tableHeaderStatusCell = tableHeader.Cells[3].AddParagraph();
                    text = tableHeaderStatusCell.AppendText("Status (Yes/No)");
                    text.CharacterFormat.FontSize = 12;
                    text.CharacterFormat.Bold = true;

                    foreach (var item in issuesLists)
                    {
                        TableRow issueIdRow = table.Rows[counter];
                        Paragraph issueId = issueIdRow.Cells[0].AddParagraph();
                        issueId.AppendText(item.Id.ToString());


                        TableRow dataRow = table.Rows[counter];
                        Paragraph issueName = dataRow.Cells[1].AddParagraph();
                        issueName.AppendText(item.Name);

                        TableRow description = table.Rows[counter];
                        Paragraph issueDesc = description.Cells[2].AddParagraph();
                        issueDesc.AppendText(LoadIssuesInfo.GetIssueInfo(activeProject, "Description", item.Name));

                        //tab.ResetCells(2, 2);
                        counter++;
                    }

                    for (int i = 0; i < summaryReport.Sections[1].Tables[0].Rows.Count; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            table.Rows[i].Cells[j].CellFormat.VerticalAlignment = Spire.Doc.Documents.VerticalAlignment.Middle;
                        summaryReport.Sections[1].Tables[0].Rows[i].Cells[0].Width = 8;
                        summaryReport.Sections[1].Tables[0].Rows[i].Cells[1].Width = 47;
                        summaryReport.Sections[1].Tables[0].Rows[i].Cells[2].Width = 35;
                        summaryReport.Sections[1].Tables[0].Rows[i].Cells[3].Width = 10;
                    }


                    Paragraph fifthItem = firstPage.AddParagraph();
                    fifthItem.AppendText("4. Conclusion");
                    fifthItem.ApplyStyle(BuiltinStyle.Heading2);

                    Paragraph fourthItem = firstPage.AddParagraph();
                    fourthItem.AppendText("5. Observations to tests");
                    fourthItem.ApplyStyle(BuiltinStyle.Heading2);

                    summaryReport.UpdateTableOfContents();
                    #endregion


                    var pathToReport = fileDialog.FileName;
                    summaryReport.SaveToFile(pathToReport, FileFormat.Docx);
                }

            }
            catch
            {
                MessageBox.Show("File couldn't be saved because it's opened.", "Error");
            }
        }

        private void SearchTable(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (searchTextField.Text.Length == 0)
            {
                filterCounter.Visibility = Visibility.Hidden;
            }
            else
                filterCounter.Visibility = Visibility.Visible;

            var filteredIssues = issuesLists.Where(issuesLists => issuesLists.Name.Contains(searchTextField.Text));
            allIssuesDataGrid.ItemsSource = filteredIssues;
            filteredTableCount.Text = filteredIssues.Count().ToString();
            allTableCount.Text = issuesLists.Count.ToString();
                SortDataGrid(allIssuesDataGrid, 1, ListSortDirection.Ascending);
        }

    }
}
