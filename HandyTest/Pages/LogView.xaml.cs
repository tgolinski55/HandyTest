using HandyTest.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        public ObservableCollection<LogItems> logItems = new ObservableCollection<LogItems>();
        public LogView()
        {
            InitializeComponent();
        }

        private void PreviousWindowBtn(object sender, RoutedEventArgs e)
        {
                PageNavigator.Switch(new HomeView());
                var mainWindow = new HomeView();
                mainWindow.ReloadDataGrid();
        }

        private void LogItems_Loaded(object sender, RoutedEventArgs e)
        {
            allLogsDataGrid.ItemsSource = MainWindow.logItems;
            //allLogsDataGrid.ItemsSource = logItems;
        }

        public void AddToLog(string action, string date, string source)
        {
            logItems.Add(new LogItems(action, date, source));
        }

    }
}
