﻿using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using HandyTest.BL;
using System.Windows.Controls;
using System.Windows.Navigation;
using HandyTest.Pages;
using MahApps.Metro.Controls;
using HandyTest.Views;
using System.Linq;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace HandyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ObservableCollection<ProjectList> ProjectsList = new ObservableCollection<ProjectList>();
        private readonly BackgroundWorker worker = new BackgroundWorker();

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int HOTKEY_ID = 9000;

        //Modifiers:
        private const uint MOD_NONE = 0x0000; //(none)
        private const uint MOD_ALT = 0x0001; //ALT
        private const uint MOD_CONTROL = 0x0002; //CTRL
        private const uint MOD_SHIFT = 0x0004; //SHIFT
        private const uint MOD_WIN = 0x0008; //WINDOWS
        //CAPS LOCK:
        private const uint VK_CAPITAL = 0x14;

        public MainWindow()
        {

            InitializeComponent();
           //EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyUpEvent,new KeyEventHandler(keyUp), true);
            PageNavigator.pageSwitcher = this;
            PageNavigator.Switch(new HomeView());
            Loaded += Window_Loaded;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

           
        }
        private IntPtr _windowHandle;
        private HwndSource _source;
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source.AddHook(HwndHook);

            RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_CONTROL, VK_CAPITAL); //CTRL + CAPS_LOCK
        }
        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
            const int WM_HOTKEY = 0x0312;
            
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID:
                            int vkey = (((int)lParam >> 16) & 0xFFFF);
                            if (vkey == VK_CAPITAL)
                            {
                                MessageBox.Show("Caps was pressed!");
                            }
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }
        protected override void OnClosed(EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            UnregisterHotKey(_windowHandle, HOTKEY_ID);
            base.OnClosed(e);
        }
//########################################################


        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Window_Loaded(sender, new RoutedEventArgs());
        }

        private void worker_RunWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
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

        private void keyUp(object sender, KeyEventArgs e)
        {
            //Your code...
            MessageBox.Show("Button " + e.Key + " was pressed.");

        }

    }
}
