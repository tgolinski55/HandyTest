using HandyTest.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            switch (manualTestDataGrid.SelectedIndex)
            {
                case 0:
                    {
                        fileChecker.IsEnabled = true;
                        fileChecker.Visibility = Visibility.Visible;

                        textGenerator.IsEnabled = false;
                        textGenerator.Visibility = Visibility.Hidden;
                        break;
                    }
                case 1:
                    {
                        fileChecker.IsEnabled = false;
                        fileChecker.Visibility = Visibility.Hidden;

                        textGenerator.IsEnabled = true;
                        textGenerator.Visibility = Visibility.Visible;
                        break;
                    }
            }
        }

        static Random randomizeCharTab = new Random();
        private void TextGenerator(object sender, RoutedEventArgs e)
        {
            var charsTab = new List<string>();
            var numbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            var letter = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "w", "x", "y", "z" };
            var specialChar = new List<string> { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "{", "}", "[", "]", ",", ".", ";", ":", "|", "\\", "~" };
            if (numbersRbtn.IsChecked == true)
            {
                foreach (var n in numbers)
                    charsTab.Add(n);
            }
            if (lettersRbtn.IsChecked == true)
            {
                foreach (var l in letter)
                    charsTab.Add(l);
            }
            if (specialCharsRbtn.IsChecked == true)
            {
                foreach (var s in specialChar)
                    charsTab.Add(s);
            }
            if (charsRbtn.IsChecked == true)
            {
                foreach (var c in charsSample.Text)
                    charsTab.Add(c.ToString());
            }
            var shuffleTab = charsTab.OrderBy(a => Guid.NewGuid()).ToList();
            
            if (lengthValue.Value != null && lengthValue.Value<100000)
            {
                for (int i = 0; i < lengthValue.Value; i++)
                {
                    int randomValue = randomizeCharTab.Next(shuffleTab.Count);
                    generateTxtBlk.Text += (string)shuffleTab[randomValue];
                }
            }
            Clipboard.SetText(generateTxtBlk.Text);
        }

        private void ClearTxtBlk(object sender, RoutedEventArgs e)
        {
            if(generateTxtBlk.Text.Length > 0)
            generateTxtBlk.Text = "";
        }

        private void TooglePreview(object sender, RoutedEventArgs e)
        {
            if (previewResult.Visibility == Visibility.Visible)
            {
                previewResult.Visibility = Visibility.Hidden;
            }
            else
                previewResult.Visibility = Visibility.Visible;
        }
    }
}
