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
using HandyTest.Pages;
using System.Windows.Navigation;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public ObservableCollection<ProjectList> ProjectsList = new ObservableCollection<ProjectList>();

        WindowSettings set = new WindowSettings();
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
            var currentDate = DateTime.Today.ToString("dd-MM-yyyy");
            if (newProjectName.Text.Length != 0 && !ProjectsList.Any(p => p.Name == newProjectName.Text))
            {
                projectsListDataGrid.ItemsSource = ProjectsList;
                ProjectsList.Add(new ProjectList(newProjectName.Text, currentDate));
                string path = @"../../Projects/";
                string pathToProject = Path.Combine(path, newProjectName.Text);
                Directory.CreateDirectory(pathToProject);
                Directory.CreateDirectory(pathToProject + "/Manual Test");
                Directory.CreateDirectory(pathToProject + "/Automatic Test");
                File.Create(pathToProject + "/Report.docx");
                Close_PopUp(sender, e);

                SortDataGrid(projectsListDataGrid, 2, ListSortDirection.Descending);
            }
            else
            {
                Close_PopUp(sender, e);
            }
        }

        public void ReloadDataGrid()
        {
            SortDataGrid(projectsListDataGrid, 2, ListSortDirection.Descending);
        }


        private void ProjectsListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            string path = @"..//../Projects/";
            var AllFiles = Directory.EnumerateDirectories(path).Select(Path.GetFileNameWithoutExtension);
            foreach (var o in AllFiles)
            {
                var item = new ProjectList(o, Directory.GetCreationTime(path + o).ToString("dd-MM-yyyy"));
                if (!ProjectsList.Contains(item))
                {
                    ProjectsList.Add(item);
                    projectsListDataGrid.ItemsSource = ProjectsList;
                }
            }
            SortDataGrid(projectsListDataGrid, 2, ListSortDirection.Descending);

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
            }
        }

        public void SortDataGrid(DataGrid projectsListDataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Ascending)
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

                projectsListDataGrid.SelectedIndex = 0;

                MakeActiveProjectBtn_Click(makeActiveProjectBtn, new RoutedEventArgs());
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

                Directory.Delete(path, true);
                ProjectsList.Remove(selectedItem);
            }
        }

        private void projectsListDataGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SortDataGrid(projectsListDataGrid, 2, ListSortDirection.Descending);
        }
    }
}

