using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HandyTest.BL;
using HandyTest.Properties;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System;
using System.Windows.Media;
using System.Linq;
using System.Data;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Controls;

namespace HandyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<ProjectList> ProjectsList = new ObservableCollection<ProjectList>();


        public MainWindow()
        {
            InitializeComponent();
            Loaded += ProjectsListDataGrid_Loaded;
        }

        // Toolbar and drag window
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
        private void MinimizeCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);

        }
        private void MaximizeCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {

            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.CanResizeWithGrip;
            }
            else
            {
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
            }
            //SystemCommands.MaximizeWindow(this);

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.CanResizeWithGrip;
            }
            else
            {
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void UpdateProjectsList(object sender, RoutedEventArgs e)
        {
                var currentDate = DateTime.Today.ToString("dd-MM-yyyy");
            if (newProjectName.Text.Length != 0 && ProjectsList.Contains(new ProjectList(newProjectName.Text, currentDate)))
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
            }
            else
            {
                Close_PopUp(sender, e);
            }
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
            SortDataGrid(projectsListDataGrid, 1, ListSortDirection.Descending);
            activeProjectTxtBlock.Text = ProjectsList[0].Name;
        }

        private void MakeActiveProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var data in projectsListDataGrid.SelectedItems)
            {
                ProjectList myData = data as ProjectList;
                activeProjectTxtBlock.Text = myData.Name;
                activeProjectTxtBlock.ToolTip = myData.Name;

            }
        }

        void SortDataGrid(DataGrid projectsListDataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Ascending)
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
        }

        private void ProjectsListDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            foreach (var data in projectsListDataGrid.SelectedItems)
            {
                ProjectList myData = data as ProjectList;
                activeProjectTxtBlock.Text = myData.Name;
                activeProjectTxtBlock.ToolTip = myData.Name;
            }
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
    }
}
