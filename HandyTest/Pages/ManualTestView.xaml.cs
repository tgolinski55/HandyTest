using HandyTest.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for ManualTestView.xaml
    /// </summary>
    public partial class ManualTestView : UserControl
    {
        ObservableCollection<ManualTestOptions> ManualTestOpt = new ObservableCollection<ManualTestOptions>();
        public ManualTestView()
        {
            InitializeComponent();
            Loaded += ManualTestDataGrid_Loaded;
            manualTestDataGrid.SelectedIndex = 0;
        }

        
        private void WindowDragMove(object sender, MouseButtonEventArgs e)
        {
            WindowSettings set = new WindowSettings();
            set.Window_MouseDown(sender, e);
        }

        private void PreviousWindowBtn(object sender, RoutedEventArgs e)
        {
            PageNavigator.Switch(new HomeView());
            var mainWindow = new HomeView();
            mainWindow.ReloadDataGrid();
        }

        private void ManualTestDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            manualTestDataGrid.ItemsSource = ManualTestOpt;
            ManualTestOpt.Add(new ManualTestOptions("File checker"));
            ManualTestOpt.Add(new ManualTestOptions("Generate text"));
            ManualTestOpt.Add(new ManualTestOptions("Auto-Clicker"));

        }


        private void FileChecker(object sender, TextChangedEventArgs e)
        {
            if (txtToCheck.Text != txtToCheck2.Text)
            {
                resultLabel.Content = "Files are different!";
                resultLabel.Foreground = Brushes.Red;
            }
            else
            {
                resultLabel.Content = "Files are the same";
                resultLabel.Foreground = Brushes.Green;
            }
        }

        private void ChangeFunction(object sender, SelectionChangedEventArgs e)
        {
            if (manualTestDataGrid.SelectedIndex == 0)
            {
                fileChecker.Visibility = Visibility.Visible;
            }
        }
    }
}
