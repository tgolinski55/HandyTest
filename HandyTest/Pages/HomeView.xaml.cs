using System.Windows;
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

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public ObservableCollection<ProjectList> ProjectsList = new ObservableCollection<ProjectList>();
        ExplorativeTestView explorativeTestView = new ExplorativeTestView();

        LoadCurrentProject loadCurrentProject = new LoadCurrentProject();
        public event EventHandler Changed;
        private string getCurrentProject;
        BL.WindowSettings set = new BL.WindowSettings();
        public HomeView()
        {
            InitializeComponent();
            Loaded += ProjectsListDataGrid_Loaded;
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
                string path = @"../../Projects/";
                string pathToProject = Path.Combine(path, newProjectName.Text);
                Directory.CreateDirectory(pathToProject);
                Directory.CreateDirectory(pathToProject + "/Manual Test");
                File.Create(Path.Combine(pathToProject,"config.txt"));
                Directory.CreateDirectory(pathToProject + "/Reports");
                Close_PopUp(sender, e);
                SaveActiveProject();
                ReloadDataGrid();

            }
            else
            {
                Close_PopUp(sender, e);
            }
            projectsListDataGrid.Items.Refresh();
            
        }

        public void ReloadDataGrid()
        {
            SortDataGrid(projectsListDataGrid, 3, ListSortDirection.Descending);
        }


        private void ProjectsListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            string path = @"..//../Projects/";
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
            }

        }

        public void SaveActiveProject()
        {
            string path = @"..//../Projects/";
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
            wholeGrid.IsEnabled = false;
            wholeGrid.Opacity = 0.7;
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


        private void DeleteProjectBtn(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ProjectList)projectsListDataGrid.SelectedItem;
            ProjectList currentCell = (ProjectList)projectsListDataGrid.CurrentCell.Item;
            string item = currentCell.Name;
            string path = @"..//../Projects/" + item;
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

                ReloadDataGrid();
            }
        }

        private void ProjectsListDataGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ReloadDataGrid();
        }

        private void OpenExplorativeTest(object sender, RoutedEventArgs e)
        {

            if (!IsWindowOpen<Window>("ExplorativeTestView"))
            {
                explorativeTestView.Show();
                SetActiveProj();
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
        }

    }
}

