using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HandyTest.BL
{
    public enum enmScreenCaptureMode
    {
        Screen,
        Window
    }

    class ScreenCapturer
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public Bitmap Capture(enmScreenCaptureMode screenCaptureMode = enmScreenCaptureMode.Window)
        {
            Rectangle bounds;
            //Icon ico = new Icon("../../Resources/Icons/Black/icons8_cursor_32_5Hi_icon.ico");
            if (screenCaptureMode == enmScreenCaptureMode.Screen)
            {
                bounds = Screen.GetBounds(Point.Empty);
                CursorPosition = Cursor.Position;
            }
            else
            {
                var foregroundWindowsHandle = GetForegroundWindow();
                var rect = new Rect();
                GetWindowRect(foregroundWindowsHandle, ref rect);
                bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                CursorPosition = new Point(Cursor.Position.X - rect.Left, Cursor.Position.Y - rect.Top);
            }
            try
            {
                var result = new Bitmap(bounds.Width, bounds.Height);
                using (var g = Graphics.FromImage(result))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    //TODO fix rendering icon on image;
                    //g.DrawIcon(ico, CursorPosition.X - 10, CursorPosition.Y - 5);
                }


                return result;
            }
            catch
            {
                return null;
            }
        }

        public Point CursorPosition
        {
            get;
            protected set;
        }

    }
}
