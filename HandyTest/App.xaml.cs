

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HandyTest.BL;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Threading;

namespace HandyTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;
        ProjectPath pathToProjects = new ProjectPath();
        private static Mutex _mutex = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            const string appName = "HandyTest";

            _mutex = new Mutex(true, appName, out bool createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                Application.Current.Shutdown();
            }
            else
            {
                MainWindow = new MainWindow();
                MainWindow.Closing += MainWindow_Closing;
                ShowMainWindow();
                _notifyIcon = new System.Windows.Forms.NotifyIcon();
                _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
                _notifyIcon.Icon = HandyTest.Properties.Resources.MyIcon;
                _notifyIcon.Visible = true;

                CreateContextMenu();
            }
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip =
              new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Open").Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }
        private void ExitApplication()
        {
            GarbageCollector.DeleteAllScreenshoots(pathToProjects.GetProjectsPath("ScreenshotsPath") + "/");
            _isExit = true;
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        private void ShowMainWindow()
        {
            if (MainWindow.IsVisible)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
                MainWindow.Show();
            }
            else
            {
                //MainWindow.WindowState = WindowState.Maximized;
                MainWindow.ShowActivated = true;
                MainWindow.Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                MainWindow.Hide();
            }
        }


    }

}
