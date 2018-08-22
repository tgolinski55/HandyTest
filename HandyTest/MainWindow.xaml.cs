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

            //SystemCommands.MaximizeWindow(this);

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
            if (newProjectName.Text.Length != 0)
            {
                var currentDate = DateTime.Today.ToString("dd-MM-yyyy");
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
            var Date = Directory.GetCreationTime(path).ToString("dd-MM-yyyy");
            foreach (var o in AllFiles)
            {
                 ProjectsList.Add(new ProjectList(o, Date));
            }
            projectsListDataGrid.ItemsSource = ProjectsList;
            activeProjectTxtBlock.Text = ProjectsList[0].Name;
        }

        private void MakeActiveProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var data in projectsListDataGrid.SelectedItems)
            {
                ProjectList myData = data as ProjectList;
                activeProjectTxtBlock.Text = myData.Name;
            }
        }

        private void ProjectsListDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            foreach (var data in projectsListDataGrid.SelectedItems)
            {
                ProjectList myData = data as ProjectList;
                activeProjectTxtBlock.Text = myData.Name;
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
