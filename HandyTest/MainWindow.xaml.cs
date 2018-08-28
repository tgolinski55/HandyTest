﻿using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HandyTest.BL;
using System.Windows.Controls;
using System.Windows.Navigation;
using HandyTest.Pages;
using MahApps.Metro.Controls;

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
        }

        //// Toolbar and drag window
        //private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        //private void MinimizeCommandHandler(object sender, ExecutedRoutedEventArgs e)
        //{
        //    SystemCommands.MinimizeWindow(this);
        //}
        //private void MaximizeCommandHandler(object sender, ExecutedRoutedEventArgs e)
        //{

        //    if (WindowState == WindowState.Maximized)
        //    {
        //        WindowState = WindowState.Normal;
        //        WindowStyle = WindowStyle.None;
        //        ResizeMode = ResizeMode.CanResizeWithGrip;
        //    }
        //    else
        //    {
        //        WindowStyle = WindowStyle.None;
        //        ResizeMode = ResizeMode.NoResize;
        //        WindowState = WindowState.Maximized;
        //    }
        //}

        //private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (WindowState == WindowState.Maximized)
        //    {
        //        WindowState = WindowState.Normal;
        //        WindowStyle = WindowStyle.None;
        //        ResizeMode = ResizeMode.CanResizeWithGrip;
        //    }
        //    else
        //    {
        //        WindowStyle = WindowStyle.None;
        //        ResizeMode = ResizeMode.NoResize;
        //        WindowState = WindowState.Maximized;
        //    }
        //}

        //private void WindowDragMove(object sender, MouseButtonEventArgs e)
        //{
        //    WindowSettings set = new WindowSettings();
        //    set.Window_MouseDown(sender, e);
        //}

        

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

    }
}
