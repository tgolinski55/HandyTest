using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HandyTest.BL;
using System.Windows.Controls;
using System.Windows.Navigation;
using HandyTest.Pages;
using MahApps.Metro.Controls;
using HandyTest.Views;
using System.Linq;

namespace HandyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public ObservableCollection<ProjectList> ProjectsList = new ObservableCollection<ProjectList>();

        public MainWindow()
        {
            InitializeComponent();

            PageNavigator.pageSwitcher = this;
            PageNavigator.Switch(new HomeView());
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(KeyListener);
        }

        private void KeyListener(object sender, KeyEventArgs e)
        {
            ExplorativeTestView explorativeTestView = new ExplorativeTestView();
            LoadCurrentProject loadCurrentProject = new LoadCurrentProject();
            if (e.Key == Key.Subtract)
            {
                if (!IsWindowOpen<Window>("ExplorativeTestView"))
                {
                    explorativeTestView.Show();
                    explorativeTestView.activeProject = loadCurrentProject.GetCurrentProject();
                }
                else
                {
                    explorativeTestView.Close();
                }
            }
        }

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

    }
}
