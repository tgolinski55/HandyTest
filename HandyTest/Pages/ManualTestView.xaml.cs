﻿using HandyTest.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace HandyTest.Pages
{
    /// <summary>
    /// Interaction logic for ManualTestView.xaml
    /// </summary>
    public partial class ManualTestView : UserControl
    {
        ObservableCollection<ManualTestOptions> ManualTestOpt = new ObservableCollection<ManualTestOptions>();
        ObservableCollection<string> ImageViewer = new ObservableCollection<string>();
        ObservableCollection<ImageSource> ImageViewerList = new ObservableCollection<ImageSource>();
        public IEnumerable<ManualTestView> ImageViewerer;
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
            ManualTestOpt.Add(new ManualTestOptions("PESEL generator"));
            ManualTestOpt.Add(new ManualTestOptions("NIP generator"));
            ManualTestOpt.Add(new ManualTestOptions("E-mail generator"));
            ManualTestOpt.Add(new ManualTestOptions("Password generator"));
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

                        autoClicker.IsEnabled = false;
                        autoClicker.Visibility = Visibility.Hidden;

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

                        autoClicker.IsEnabled = false;
                        autoClicker.Visibility = Visibility.Hidden;

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

                        autoClicker.IsEnabled = false;
                        autoClicker.Visibility = Visibility.Hidden;

                        break;
                    }
                case 3:
                    {
                        fileChecker.IsEnabled = false;
                        fileChecker.Visibility = Visibility.Hidden;


                        imageChecker.IsEnabled = false;
                        imageChecker.Visibility = Visibility.Hidden;

                        textGenerator.IsEnabled = false;
                        textGenerator.Visibility = Visibility.Hidden;

                        autoClicker.IsEnabled = true;
                        autoClicker.Visibility = Visibility.Visible;

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
                        {
                            if (charsRbtn.IsChecked == true && charsSample.Text == "" && (numbersRbtn.IsChecked == false && lettersRbtn.IsChecked == false && specialCharsRbtn.IsChecked == false))
                                break;
                            generateTxtBlk.Text += (string)shuffleTab[randomValue];
                        }
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
        List<object> imageList = new List<object>();
        List<Bitmap> image2List = new List<Bitmap>();
        private void CopyLeftImageFromClipboard(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                testImg.Source = Clipboard.GetImage();
                //dropDownLeftImageList.ItemsSource = ImageViewerList.ToString();
                //dropDownRightImageList.ItemsSource = ImageViewerList.ToString();

                //ImageViewerList.Add((ImageSource)testImg.Source);
                //if (!imageList.Contains(testImg.Source))
                //    imageList.Add(testImg.Source);

            }
        }
        public static Bitmap ConvertToBitmap(BitmapSource bitmapSource)
        {
            var width = bitmapSource.PixelWidth;
            var height = bitmapSource.PixelHeight;
            var stride = width * ((bitmapSource.Format.BitsPerPixel + 7) / 8);
            var memoryBlockPointer = Marshal.AllocHGlobal(height * stride);
            bitmapSource.CopyPixels(new Int32Rect(0, 0, width, height), memoryBlockPointer, height * stride, stride);
            var bitmap = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, memoryBlockPointer);
            return bitmap;
        }

        private void CopyRightImageFromClipboard(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                testImg1.Source = Clipboard.GetImage();
                //dropDownLeftImageList.ItemsSource = ImageViewer;
                //dropDownRightImageList.ItemsSource = ImageViewer;
                //ImageViewer.Add((ImageViewer.Count).ToString());
                //if (!imageList.Contains(testImg.Source))
                //{

                //    image2List.Add(ConvertToBitmap((BitmapSource)testImg.Source));
                //}
            }
        }

        private void RestetLeftImage(object sender, RoutedEventArgs e)
        {
            ZoomBorder zoomBorder = new ZoomBorder();
            zoomBorder.Initialize(testImg);
        }

        private void ResetRightImage(object sender, RoutedEventArgs e)
        {
            ZoomBorder zoomBorder = new ZoomBorder();
            zoomBorder.Initialize(testImg1);
            //testImg1.Source = null;
        }


        private BitmapImage LoadImageFromFile(string filename)
        {
            using (var fs = File.OpenRead(filename))
            {
                var img = new BitmapImage();
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                // Downscaling to keep the memory footprint low
                img.DecodePixelWidth = (int)SystemParameters.PrimaryScreenWidth;
                img.StreamSource = fs;
                img.EndInit();
                return img;
            }
        }
        private void CompareImages(object sender, RoutedEventArgs e)
        {
            if (testImg.Source != null && testImg1.Source != null)
            {

                var bmp1 = ConvertToBitmap((BitmapSource)testImg.Source);
                var bmp2 = ConvertToBitmap((BitmapSource)testImg1.Source);
                ImageConverter imageConverter = new ImageConverter();

                byte[] btImage1 = new byte[1];
                btImage1 = (byte[])imageConverter.ConvertTo(bmp1, btImage1.GetType());

                byte[] btImage2 = new byte[1];
                btImage2 = (byte[])imageConverter.ConvertTo(bmp2, btImage2.GetType());

                SHA256Managed shaM = new SHA256Managed();
                byte[] hash1 = shaM.ComputeHash(btImage1);
                byte[] hash2 = shaM.ComputeHash(btImage2);

                for (int i = 0; i < hash1.Length && i < hash2.Length; i++)
                {
                    if (hash1[i] != hash2[i])
                        imageCompareLabel.Background = System.Windows.Media.Brushes.Red;
                    else
                        imageCompareLabel.Background = System.Windows.Media.Brushes.Green;
                }
            }
        }

        private void LeftImageDragAndDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Data != null)
            {
                var data = e.Data as DataObject;
                if (data.ContainsFileDropList())
                {
                    var files = data.GetFileDropList();
                    testImg.Source = LoadImageFromFile(files[0]);
                    if (!ImageViewer.Contains(files[0]))
                    {

                        //dropDownLeftImageList.ItemsSource = ImageViewer;
                        //dropDownRightImageList.ItemsSource = ImageViewer;
                        ImageViewer.Add(files[0]);
                    }
                }

            }
        }

        private void RightImageDragAndDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Data != null)
            {
                var data = e.Data as DataObject;
                if (data.ContainsFileDropList())
                {
                    var files = data.GetFileDropList();
                    testImg1.Source = LoadImageFromFile(files[0]);
                    if (!ImageViewer.Contains(files[0]))
                    {
                        //dropDownLeftImageList.ItemsSource = ImageViewer;
                        //dropDownRightImageList.ItemsSource = ImageViewer;
                        ImageViewer.Add(files[0]);
                    }
                }

            }
        }

        private void ChangeImage(object sender, SelectionChangedEventArgs e)
        {
            //ComboBoxItem cmb = dropDownLeftImageList.SelectedItem as ComboBoxItem;
            //string content = cmb.Content.ToString();

            //testImg.Source = (ImageSource)dropDownLeftImageList.SelectedItem;

        }

      
    }
}

