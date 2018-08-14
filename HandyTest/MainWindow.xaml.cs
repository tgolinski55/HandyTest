using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HandyTest.BL;

namespace HandyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<ProjectList> ProjectsList = new ObservableCollection<ProjectList>();

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

        private void ProjectsListDataGrid_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            projectsListDataGrid.ItemsSource = ProjectsList;
            ProjectsList.Add(new ProjectList("test"));
        }

        private void ProjectsListDataGrid_Loaded(object sender, RoutedEventArgs e)
        {         
            projectsListDataGrid.ItemsSource = ProjectsList;
            ProjectsList.Add(new ProjectList("test"));
        }
    }
}
