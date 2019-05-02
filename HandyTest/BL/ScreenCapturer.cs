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
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        const Int32 CURSOR_SHOWING = 0x00000001;

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
                    CURSORINFO pci;
                    pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(CURSORINFO));


                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    //TODO fix rendering icon on image;
                    //g.DrawIcon(ico, CursorPosition.X - 10, CursorPosition.Y - 5);
                    if (GetCursorInfo(out pci))
                    {
                        if (pci.flags == CURSOR_SHOWING)
                        {
                            DrawIcon(g.GetHdc(), Cursor.Position.X - 10, Cursor.Position.Y - 5, pci.hCursor);
                            g.ReleaseHdc();
                        }
                    }
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
