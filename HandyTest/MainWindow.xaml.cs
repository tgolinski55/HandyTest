using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HandyTest.BL;
using HandyTest.Properties;
using System.IO;
using System.Web;
using System.Collections.Generic;

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
            SystemCommands.MaximizeWindow(this);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void UpdateProjectsList(object sender, ExceptionRoutedEventArgs e)
        {
        }

        private void ProjectsListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {         
            projectsListDataGrid.ItemsSource = ProjectsList;
            ProjectsList.Add(new ProjectList("Hello World!"));          
            ProjectsList.Add(new ProjectList("Hello World2!"));          
            ProjectsList.Add(new ProjectList("Hello World3!"));          
        }

        private void makeActiveProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var data in projectsListDataGrid.SelectedItems)
            {
                ProjectList myData = data as ProjectList;
                activeProjectTxtBlock.Text = myData.Name;
            }
        }

        private void projectsListDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }
    }
}
