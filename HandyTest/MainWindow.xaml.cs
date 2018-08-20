using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HandyTest.BL;
using HandyTest.Properties;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System;

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
            //SystemCommands.MinimizeWindow(this);

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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }


        //TODO finish popup dragmove
        void pop_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                createNewProjectPopUp.MouseMove += new MouseEventHandler(pop_MouseMove);
                createNewProjectPopUp.PlacementRectangle = new Rect(new Point(e.GetPosition(this).X,
                    e.GetPosition(this).Y), new Point(200, 200));

            }
        }

        private void UpdateProjectsList(object sender, RoutedEventArgs e)
        {
            //projectsListDataGrid.ItemsSource = ProjectsList;
            //ProjectsList.Add(new ProjectList("Die World!"));

            createNewProjectPopUp.IsOpen = true;
            newProjectName.Text = "";
            newProjectDescription.Text = "";

        }

        private void ProjectsListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            projectsListDataGrid.ItemsSource = ProjectsList;
            ProjectsList.Add(new ProjectList("Hello World!"));
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

        private void Close_PopUp (object sender, RoutedEventArgs e)
        {
            createNewProjectPopUp.IsOpen = false;
        }
    }
}
