

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

namespace HandyTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;
        //string path = "..//../Screenshoots/";
        private string GetProjectsPath(string element)
        {
            string pathToConfig = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\HandyTest\\config.xml";
            XmlDocument xmlFile = new XmlDocument();

            if (File.Exists(pathToConfig))
            {
                xmlFile.Load(pathToConfig);
                XmlNodeList xmlNodeList = xmlFile.GetElementsByTagName(element);
                element = xmlNodeList.Item(0).InnerText;
            }
            else
            {
                element = "";
            }
            return element;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Closing += MainWindow_Closing;
            ShowMainWindow();
            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = HandyTest.Properties.Resources.MyIcon;
            _notifyIcon.Visible = true;

            CreateContextMenu();
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
            GarbageCollector.DeleteAllScreenshoots(GetProjectsPath("ScreenshotsPath") + "/");
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
                MainWindow.Activate();
            }
            else
            {
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
