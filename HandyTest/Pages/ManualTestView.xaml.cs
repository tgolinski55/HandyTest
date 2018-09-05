using HandyTest.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Shapes;
using System.Drawing.Imaging;
using System.IO;

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
            ManualTestOpt.Add(new ManualTestOptions("Image checker"));
            ManualTestOpt.Add(new ManualTestOptions("Text generator"));
            ManualTestOpt.Add(new ManualTestOptions("Auto-Clicker"));
        }


        private void FileChecker(object sender, TextChangedEventArgs e)
        {
            if (txtToCheck.Text != txtToCheck2.Text)
            {
                resultLabel.Content = "Files are different!";
                resultLabel.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
            {
                resultLabel.Content = "Files are the same";
                resultLabel.Foreground = System.Windows.Media.Brushes.Green;
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

                        imageChecker.IsEnabled = false;
                        imageChecker.Visibility = Visibility.Hidden;

                        textGenerator.IsEnabled = false;
                        textGenerator.Visibility = Visibility.Hidden;


                        break;
                    }
                case 1:
                    {
                        fileChecker.IsEnabled = false;
                        fileChecker.Visibility = Visibility.Hidden;

                        imageChecker.IsEnabled = true;
                        imageChecker.Visibility = Visibility.Visible;

                        textGenerator.IsEnabled = true;
                        textGenerator.Visibility = Visibility.Hidden;
                        break;
                    }
                case 2:
                    {
                        fileChecker.IsEnabled = false;
                        fileChecker.Visibility = Visibility.Hidden;


                        imageChecker.IsEnabled = false;
                        imageChecker.Visibility = Visibility.Hidden;

                        textGenerator.IsEnabled = true;
                        textGenerator.Visibility = Visibility.Visible;
                        break;
                    }
                case 3:
                    {
                        fileChecker.IsEnabled = false;
                        fileChecker.Visibility = Visibility.Hidden;


                        imageChecker.IsEnabled = false;
                        imageChecker.Visibility = Visibility.Hidden;

                        textGenerator.IsEnabled = true;
                        textGenerator.Visibility = Visibility.Hidden;
                        break;
                    }
            }
        }

        static Random randomizeCharTab = new Random();
        private void TextGenerator(object sender, RoutedEventArgs e)
        {
            var charsTab = new List<string>();
            var numbers = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            var letter = new List<string> { "a", "b", "c", " ", " ", " ", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "w", "x", "y", "z", " " };
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

            if (charsRbtn.IsChecked == true || numbersRbtn.IsChecked == true || specialCharsRbtn.IsChecked == true || lettersRbtn.IsChecked == true)
            {

                if (lengthValue.Value != null && lengthValue.Value <= 100000)
                {
                    for (int i = 0; i < lengthValue.Value; i++)
                    {
                        int randomValue = randomizeCharTab.Next(shuffleTab.Count);
                        if (generateTxtBlk.Text.Length < 100000)
                            generateTxtBlk.Text += (string)shuffleTab[randomValue];
                    }
                }

            }
        }

        private void ClearTxtBlk(object sender, RoutedEventArgs e)
        {
            if (generateTxtBlk.Text.Length > 0)
                generateTxtBlk.Text = "";
        }

        private void CopyToClipboard(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(generateTxtBlk.Text);
        }

        private void WarningTextSize(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (lengthValue.Value >= 5000)
                warningTextGen.Visibility = Visibility.Visible;
            else
                warningTextGen.Visibility = Visibility.Hidden;
        }

        private void ErrorTextSize(object sender, SizeChangedEventArgs e)
        {
            if (generateTxtBlk.Text.Length >= 100000)
                errorTextGen.Visibility = Visibility.Visible;
            else
                errorTextGen.Visibility = Visibility.Hidden;
        }

        private void CopyLeftImageFromClipboard(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                // ImageUIElement.Source = Clipboard.GetImage(); // does not work
                testImg.Source = Clipboard.GetImage();
            }
        }

        private void CopyRightImageFromClipboard(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                // ImageUIElement.Source = Clipboard.GetImage(); // does not work
                testImg1.Source = Clipboard.GetImage();
            }
        }

        private void RestetLeftImage(object sender, RoutedEventArgs e)
        {
            ZoomBorder zoomBorder = new ZoomBorder();
            zoomBorder.Reset();
        }
        //public static List<bool> GetHash(Bitmap bmpSource)
        //{
        //    //List<bool> lResult = new List<bool>();
        //    ////create new image with 16x16 pixel
        //    //Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
        //    //for (int j = 0; j < bmpMin.Height; j++)
        //    //{
        //    //    for (int i = 0; i < bmpMin.Width; i++)
        //    //    {
        //    //        //reduce colors to true / false                
        //    //        lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
        //    //    }
        //    //}
        //    //return lResult;
        //}
    }
}
