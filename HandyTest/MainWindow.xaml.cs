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
using Gma.System.MouseKeyHook;
using WindowsInput;
using WindowsInput.Native;
using DesktopWPFAppLowLevelKeyboardHook;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net.Http;
using MahApps.Metro.Controls.Dialogs;
using HtmlAgilityPack;

namespace HandyTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private LowLevelKeyboardListener _listener;
        //string path = "..//../Screenshoots/";
        ScreenCapturer screenCapturer = new ScreenCapturer();
        public static ObservableCollection<ProjectList> ProjectsList { get; set; }
        public static ObservableCollection<LogItems> logItems = new ObservableCollection<LogItems>();
        private readonly BackgroundWorker worker = new BackgroundWorker();
        ValidateTask validateTask = new ValidateTask();
        ExplorativeTestView explorativeTestView = new ExplorativeTestView();
        LoadCurrentProject loadCurrentProject = new LoadCurrentProject();
        LogView LogView = new LogView();
        ProjectPath pathToProjects = new ProjectPath();
        private IKeyboardMouseEvents m_GlobalHook;
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        private const int HOTKEY_ID = 9000;

        #region Virtual keys
        //MODIFIERS:
        private const uint MOD_NONE = 0x0000; //(none)
        private const uint MOD_ALT = 0x0001; //ALT
        private const uint MOD_CONTROL = 0x0002; //CTRL
        private const uint MOD_SHIFT = 0x0004; //SHIFT
        private const uint MOD_WIN = 0x0008; //WINDOWS

        //VIRTUAL KEYS
        private const uint VK_SUBTRACT = 0x6D; //"-" button
        private const uint VK_LEFTMOUSE = 0x01; //LeftMouse
        private const uint VK_CKEY = 0x43; //"C" button
        private const uint VK_VKEY = 0x56; //"V" button
        private const uint VK_ZKEY = 0x5A; //"Z" button
        private const uint VK_ENTERKEY = 0x0D; //"Enter" button
        private const uint VK_BACKSPACEKEY = 0x08; //"Backspace" button
        private const uint VK_DELKEY = 0x2E; //"Delete" button
        private const uint VK_CAPITAL = 0x14; //Caps lock
        private const uint VK_PAUSE = 0x13; //Pause break
        private const uint VK_OEM_3 = 0xC0; //"~"
        #endregion

        public MainWindow()
        {
            if (!validateTask.ValidateLink())
            {
                InitializeComponent();
                PageNavigator.pageSwitcher = this;
                PageNavigator.Switch(new ActivatePage());
            }
            else
            {
                InitializeComponent();
                PageNavigator.pageSwitcher = this;
                PageNavigator.Switch(new HomeView());
            }

        }

        private static readonly HttpClient client = new HttpClient();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();

        }
        public static string GetBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            string path2 = "SS-" + DateTime.Now.ToString("ddMMHHmmss") + ".jpg";
            if (!this.IsActive)
            {
                if (e.KeyPressed >= Key.A && e.KeyPressed <= Key.Z)
                {
                    //Do not log letters
                }
                else
                {
                    if (Keyboard.IsKeyDown(e.KeyPressed))
                    { }
                    else
                    {
                        if (!Directory.Exists(pathToProjects.GetProjectsPath("ScreenshotsPath")))
                            Directory.CreateDirectory(pathToProjects.GetProjectsPath("ScreenshotsPath"));
                        logItems.Add(new LogItems("Key pressed: " + e.KeyPressed.ToString(), DateTime.Now.ToLongTimeString(), path2));
                        screenCapturer.Capture(enmScreenCaptureMode.Screen).Save(pathToProjects.GetProjectsPath("ScreenshotsPath") + "/" + path2, ImageFormat.Jpeg);

                    }
                }

                _listener.UnHookKeyboard();
                _listener.HookKeyboard();

                //GC.Collect();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            GC.Collect();
            _listener.UnHookKeyboard();
        }


        private IntPtr _windowHandle;
        private HwndSource _source;
        protected override void OnSourceInitialized(EventArgs e)
        {

            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source.AddHook(HwndHook);
            //_listener = new LowLevelKeyboardListener();
            //_listener.OnKeyPressed += _listener_OnKeyPressed;

            //_listener.HookKeyboard();

            //Clean all screenshoots every 10minutes
            Task task = new Task(() =>
            {
                while (true)
                {
                    GarbageCollector.DeleteAllScreenshoots(pathToProjects.GetProjectsPath("ScreenshotsPath") + "/");
                    Thread.Sleep(600000);
                }
            });
            task.Start();
            Task checkIfExpired = new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(600000);
                    if (!validateTask.ValidateLink())
                    {
                        MessageBox.Show("Invalid link or task has expired!", "Access denied");
                        Environment.Exit(0);
                    }

                }
            });
            checkIfExpired.Start();

            #region Hotkeys
            //KEYBOARD
            //RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_NONE, VK_SUBTRACT);
            //RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_NONE, VK_LEFTMOUSE);
            //RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_CONTROL, VK_CKEY);
            //RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_CONTROL, VK_VKEY);
            //RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_CONTROL, VK_ZKEY);
            //RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_NONE, VK_ENTERKEY);
            //RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_NONE, VK_BACKSPACEKEY);
            RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_ALT, VK_OEM_3);

            //MOUSE
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseClick += m_GlobalHook_MouseClick;
            #endregion

            LogView.allLogsDataGrid.ItemsSource = logItems;
            base.OnSourceInitialized(e);

        }
        private void m_GlobalHook_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            string path2 = "SS-" + DateTime.Now.ToString("ddMMHHmmss") + ".jpg";
            if (!this.IsActive)
            {

                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    logItems.Add(new LogItems("Left Mouse button was clicked", DateTime.Now.ToLongTimeString(), path2));
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {

                    logItems.Add(new LogItems("Right Mouse button was clicked", DateTime.Now.ToLongTimeString(), path2));
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
                {

                    logItems.Add(new LogItems("Middle Mouse button was clicked", DateTime.Now.ToLongTimeString(), path2));
                }
            }
            try
            {
                if (!Directory.Exists(pathToProjects.GetProjectsPath("ScreenshotsPath")))
                    Directory.CreateDirectory(pathToProjects.GetProjectsPath("ScreenshotsPath"));
                screenCapturer.Capture(enmScreenCaptureMode.Screen).Save(Path.GetFullPath(pathToProjects.GetProjectsPath("ScreenshotsPath") + "/" + path2), ImageFormat.Jpeg);
            }

            catch
            {
                throw;
                //MessageBox.Show("File is in use. Please select different one.", "Error");
            }

            //GC.Collect();
        }
        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            InputSimulator inputSimulator = new InputSimulator();
            string path2 = "SS-" + DateTime.Now.ToString("ddMMHHmmss") + ".jpg";
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
                            handled = true;
                            break;
                        case VK_CKEY:
                            logItems.Add(new LogItems("Key pressed: Ctrl+C", DateTime.Now.ToLongTimeString(), path2));
                            handled = true;
                            break;
                        case VK_VKEY:
                            logItems.Add(new LogItems("Key pressed: Ctrl+V", DateTime.Now.ToLongTimeString(), path2));
                            break;
                        case VK_ZKEY:
                            logItems.Add(new LogItems("Key pressed: Ctrl+Z", DateTime.Now.ToLongTimeString(), path2));
                            handled = true;
                            break;
                        case VK_ENTERKEY:
                            logItems.Add(new LogItems("Key pressed: Enter", DateTime.Now.ToLongTimeString(), path2));
                            handled = true;
                            break;
                        case VK_BACKSPACEKEY:
                            logItems.Add(new LogItems("Key pressed: Backspace", DateTime.Now.ToLongTimeString(), path2));
                            handled = true;
                            break;
                        case VK_DELKEY:
                            logItems.Add(new LogItems("Key pressed: Delete", DateTime.Now.ToLongTimeString(), path2));
                            handled = true;
                            break;
                        case VK_PAUSE:
                            logItems.Add(new LogItems("Key pressed: Pause", DateTime.Now.ToLongTimeString(), path2));
                            handled = true;
                            break;
                        case VK_OEM_3:
                            logItems.Add(new LogItems("Key pressed: Oem3", DateTime.Now.ToLongTimeString(), path2));

                            if (IsWindowOpen<Window>("expWindow"))
                            {
                                //logItems.Add(new LogItems("Key pressed: Subtract", DateTime.Now.ToLongTimeString(), path2));
                                //var num = Application.Current.Windows;
                                //ExplorativeTestView explorativeTestView = new ExplorativeTestView();
                                explorativeTestView.Show();
                                explorativeTestView.activeProject = loadCurrentProject.GetCurrentProject();
                            }
                            else
                            {
                                explorativeTestView.Close();
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
            m_GlobalHook.MouseClick -= m_GlobalHook_MouseClick;
            m_GlobalHook.Dispose();
            base.OnClosed(e);

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
    }
}
