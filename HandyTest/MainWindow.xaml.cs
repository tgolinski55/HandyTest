using System.Windows;
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
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

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
        private const uint VK_SUBTRACT = 0x6D; //"-" button
        private const uint VK_LEFTMOUSE = 0x01; //LeftMouse
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

            //TODO fix
            Thread TH = new Thread(Mousee);
            TH.SetApartmentState(ApartmentState.STA);
            TH.IsBackground = true;
            TH.Start();

        }
        bool isRunning = true;
        private IntPtr _windowHandle;
        private HwndSource _source;
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source.AddHook(HwndHook);
            RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_NONE, VK_SUBTRACT);
            RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_NONE, VK_LEFTMOUSE);


        }
        void Mousee()
        {
            while(isRunning)
            {
                Thread.Sleep(40);
                Application.Current.Dispatcher.Invoke((Action)delegate {
                if ((System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed))
                    MessageBox.Show("Left mouse button was clicked");

                });

            }
        }
        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            uint vkey = (((uint)lParam >> 16) & 0xFFFF);
            int ckey = (((int)lParam >> 16) & 0xFFFF);
            System.Windows.Forms.KeysConverter kc = new System.Windows.Forms.KeysConverter();
            string keyChar = kc.ConvertToString(ckey);
            switch (msg)
            {
                case WM_HOTKEY:

                    switch (vkey)
                    {
                        case VK_SUBTRACT:
                            ExplorativeTestView explorativeTestView = new ExplorativeTestView();
                            LoadCurrentProject loadCurrentProject = new LoadCurrentProject();

                            //MessageBox.Show("Key pressed: " + keyChar + ". With Code: "+vkey);
                            //TODO SAVE keyChar TO LOG FILE! ADD MORE VK
                            ScreenCapturer screenCapturer = new ScreenCapturer();
                            screenCapturer.Capture(enmScreenCaptureMode.Screen).Save("test.jpg", ImageFormat.Jpeg);
                            if (!IsWindowOpen<Window>("ExplorativeTestView"))
                            {
                                explorativeTestView.Show();
                                explorativeTestView.activeProject = loadCurrentProject.GetCurrentProject();
                            }
                            else
                            {
                                explorativeTestView.Close();
                            }
                            break;
                        case VK_LEFTMOUSE:
                            MessageBox.Show("Left mouse button was clicked: " + keyChar);
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
            isRunning = false;
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
