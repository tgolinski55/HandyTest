using HandyTest.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        public string completePath;
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
        public string DisplayedImage
        {
            get { return completePath; }
        }
        private void AllLogsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            previewImage.Source = null;
            var logIndex = allLogsDataGrid.SelectedCells[2];
            var pathToScreen = (logIndex.Column.GetCellContent(logIndex.Item) as TextBlock).Text;
            //ImageSource imageSource = 
            string appDomain = AppDomain.CurrentDomain.BaseDirectory;
            completePath = Path.Combine(appDomain + @"..\..\Screenshoots\" + pathToScreen);
            previewImage.Source = new BitmapImage(new Uri(completePath, UriKind.Absolute));
            previewImageBorder.Reset();
            //previewImage.Source = completePath;
        }
        bool maximized = false;
        private void ResizeUpPreviw(object sender, RoutedEventArgs e)
        {
            if (previewImage.Source == null)
            {

            }
            else
            {

                if (!maximized)
                {
                    previewDockPanel.Width = window.Width;

                    previewDockPanel.Height = window.Height;
                    maximized = true;
                }
                else
                {
                    previewDockPanel.Width = 200;
                    previewDockPanel.Height = 150;
                    maximized = false;
                }
                previewImageBorder.Reset();
            }
        }

        private void ReloadImage(object sender, RoutedEventArgs e)
        {
            previewImageBorder.Reset();
        }
    }
}
