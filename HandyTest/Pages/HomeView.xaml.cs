﻿using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HandyTest.BL;
using System.IO;
using System;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Windows.Controls;
using HandyTest.Views;
using System.Xml.Serialization;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using System.Xml.Linq;
using System.Xml;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public ObservableCollection<ProjectList> ProjectsList = new ObservableCollection<ProjectList>();
        ProjectPath pathToProjects = new ProjectPath();
        LoadCurrentProject loadCurrentProject = new LoadCurrentProject();

        ExplorativeTestView explorativeTestView = new ExplorativeTestView();
        BL.WindowSettings set = new BL.WindowSettings();
        public HomeView()
        {
            InitializeComponent();
            Loaded += ProjectsListDataGrid_Loaded;

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

        private void WindowDragMove(object sender, MouseButtonEventArgs e)
        {

            set.Window_MouseDown(sender, e);
        }
        private void WindowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            set.Label_MouseDoubleClick(sender, e);
        }

        private void UpdateProjectsList(object sender, RoutedEventArgs e)
        {

            var currentDate = DateTime.Now.ToString();
            var displayedDate = DateTime.Now.ToShortDateString();
            if (newProjectName.Text.Length != 0 && !ProjectsList.Any(p => p.Name == newProjectName.Text))
            {
                projectsListDataGrid.ItemsSource = ProjectsList;
                ProjectsList.Add(new ProjectList(newProjectName.Text, displayedDate, currentDate));
                string path = pathToProjects.GetProjectsPath("ProjectsPath") + "/";
                string pathToProject = Path.Combine(path, newProjectName.Text);
                Directory.CreateDirectory(pathToProject);
                //Directory.CreateDirectory(pathToProject + "/Manual Test");
                File.Create(Path.Combine(pathToProject, "IssuesNumber.txt"));
                Directory.CreateDirectory(pathToProject + "/Reports");
                Close_PopUp(sender, e);
                SaveActiveProject();
                ReloadDataGrid();
            }
            else
            {
                MessageBox.Show("Project with name " + newProjectName.Text + " already exists","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            projectsListDataGrid.Items.Refresh();

        }

        public void ReloadDataGrid()
        {
            SortDataGrid(projectsListDataGrid, 3, ListSortDirection.Descending);
        }


        private void ProjectsListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            string path = pathToProjects.GetProjectsPath("ProjectsPath") + "/";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var AllFiles = Directory.EnumerateDirectories(path).Select(Path.GetFileNameWithoutExtension);
            foreach (var o in AllFiles)
            {
                var item = new ProjectList(o, Directory.GetCreationTime(path + o).ToShortDateString(), Directory.GetCreationTime(path + o).ToString());
                if (!ProjectsList.Contains(item))
                {
                    ProjectsList.Add(item);
                    projectsListDataGrid.ItemsSource = ProjectsList;
                }
            }
            ReloadDataGrid();
            LoadCurrentProject();
        }
        public void LoadCurrentProject()
        {
            if (loadCurrentProject.GetCurrentProject() == "")
            {
                projectsListDataGrid.SelectedItem = null;
                activeProjectTxtBlock.Text = null;

                selectProjectGrid.IsEnabled = false;
                selectProjectLabel.Visibility = Visibility.Visible;
            }
            else
            {

                projectsListDataGrid.SelectedIndex = loadCurrentProject.GetCurrentIndex();
                if (projectsListDataGrid.SelectedItem != null)
                {
                    activeProjectTxtBlock.Text = loadCurrentProject.GetCurrentProject();
                    selectProjectGrid.IsEnabled = true;
                }
                else
                {
                    activeProjectTxtBlock.Text = null;
                    selectProjectGrid.IsEnabled = false;
                    selectProjectLabel.Visibility = Visibility.Visible;
                }
            }
        }
        private void MakeActiveProjectBtn_Click(object sender, RoutedEventArgs e)
        {

            if (projectsListDataGrid.SelectedItem != null)
            {
                foreach (var data in projectsListDataGrid.SelectedItems)
                {
                    ProjectList myData = data as ProjectList;
                    activeProjectTxtBlock.Text = myData.Name;
                    activeProjectTxtBlock.ToolTip = myData.Name;
                }
                selectProjectGrid.IsEnabled = true;
                selectProjectLabel.Visibility = Visibility.Hidden;

                SaveActiveProject();
                SetActiveProj();
            }

        }

        public void SaveActiveProject()
        {
            string path = Path.GetFullPath(pathToProjects.GetProjectsPath("ProjectsPath") + "/");
            try
            {
                var indexOfSelectedItem = projectsListDataGrid.SelectedIndex.ToString();
                SaveXml.SaveSelectedProject(activeProjectTxtBlock.Text, path + "ActiveProjectInfo.xml", indexOfSelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SortDataGrid(DataGrid projectsListDataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Descending)
        {

            if (projectsListDataGrid.Items.Count > 0)
            {
                var column = projectsListDataGrid.Columns[columnIndex];
                projectsListDataGrid.Items.SortDescriptions.Clear();
                projectsListDataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));
                foreach (var col in projectsListDataGrid.Columns)
                {
                    col.SortDirection = null;
                }
                column.SortDirection = sortDirection;
                projectsListDataGrid.Items.Refresh();

                //MakeActiveProjectBtn_Click(makeActiveProjectBtn, new RoutedEventArgs());
            }
        }

        private void ProjectsListDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            foreach (var data in projectsListDataGrid.SelectedItems)
            {
                ProjectList myData = data as ProjectList;
                activeProjectTxtBlock.Text = myData.Name;
                activeProjectTxtBlock.ToolTip = myData.Name;
            }

            selectProjectGrid.IsEnabled = true;
            selectProjectLabel.Visibility = Visibility.Hidden;
            SaveActiveProject();
            SetActiveProj();
        }

        private void Close_PopUp(object sender, RoutedEventArgs e)
        {
            createNewProjectPopUp.IsOpen = false;
            wholeGrid.IsEnabled = true;
            wholeGrid.Opacity = 1;
        }

        private void CreateNewProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            createNewProjectPopUp.IsOpen = true;
            newProjectName.Text = "";
            newProjectDescription.Text = "";
            //wholeGrid.IsEnabled = false;
           // wholeGrid.Opacity = 0.7;
        }

        void OpenManualTest(object sender, RoutedEventArgs e)
        {
            PageNavigator.Switch(new ManualTestView());
        }

        void OpenAllIssues(object sender, RoutedEventArgs e)
        {
            AllIssues allIssues = new AllIssues();
            allIssues.activeProject = activeProjectTxtBlock.Text;
            PageNavigator.Switch(allIssues);

        }

        private void DeleteProject()
        {
            var selectedItem = (ProjectList)projectsListDataGrid.SelectedItem;
            ProjectList currentCell = (ProjectList)projectsListDataGrid.CurrentCell.Item;
            string item = currentCell.Name;
            string path = pathToProjects.GetProjectsPath("ProjectsPath") + "/" + item;
            if (selectedItem != null)
            {
                if (item == activeProjectTxtBlock.Text)
                {
                    activeProjectTxtBlock.Text = "";
                    selectProjectGrid.IsEnabled = false;
                    selectProjectLabel.Visibility = Visibility.Visible;
                }
                if (Directory.Exists(path))
                    Directory.Delete(path, true);
                ProjectsList.Remove(selectedItem);
                SaveActiveProject();
                ReloadDataGrid();
            }
        }

        private void DeleteProjectBtn(object sender, RoutedEventArgs e)
        {
            var selectedProjectInfo = projectsListDataGrid.SelectedCells[1];
            var selectedProjectName = (selectedProjectInfo.Column.GetCellContent(selectedProjectInfo.Item) as TextBlock).Text;
            MessageBoxResult message = MessageBox.Show("Are you sure you want to delete " + selectedProjectName + " project?"+ Environment.NewLine+ "Deleted projects cannot be restored.", "Information", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
            if (message == MessageBoxResult.OK)
            {
                DeleteProject();
            }
            else
            {
                //Close msg
            }

        }

        private void ProjectsListDataGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ReloadDataGrid();
        }

        private void OpenExplorativeTest(object sender, RoutedEventArgs e)
        {

            if (IsWindowOpen<Window>("expWindow"))
            {
                //var num = Application.Current.Windows;
                //if (explorativeTestView.IsLoaded)
                //ExplorativeTestView explorativeTestView = new ExplorativeTestView();
                SetActiveProj();
                explorativeTestView.Show();
            }
            else
            {
                explorativeTestView.Close();
            }

        }

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        public void SetActiveProj()
        {
            explorativeTestView.activeProject = activeProjectTxtBlock.Text;
            //explorativeTestView.summaryValidator.ItemsSource = null;
        }

        private void OpenLog(object sender, RoutedEventArgs e)
        {
            PageNavigator.Switch(new LogView());
        }

        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            PageNavigator.Switch(new ConfigurationView());
        }
    }
}

