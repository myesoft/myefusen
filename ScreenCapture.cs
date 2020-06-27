using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MyeFusen
{
    public class ScreenCapture
    {
        /// <summary>
        /// プライマリスクリーンの画像を取得する
        /// </summary>
        /// <returns>プライマリスクリーンの画像</returns>
        public static Bitmap CaptureRect(Rectangle rc)
        {
            //プライマリモニタのデバイスコンテキストを取得
            IntPtr hsrcDC = User32.GetDC(IntPtr.Zero);
            
            //Bitmapの作成
            Bitmap bmp = new Bitmap(rc.Width, rc.Height);

            //Graphicsの作成
            Graphics g = Graphics.FromImage(bmp);
            
            //Graphicsのデバイスコンテキストを取得
            IntPtr hdestDC = g.GetHdc();

            //Bitmapに画像をコピーする
            GDI32.BitBlt(hdestDC, 0, 0, bmp.Width, bmp.Height, hsrcDC, rc.Left, rc.Top, GDI32.SRCCOPY | GDI32.CAPTUREBLT);

            //解放
            g.ReleaseHdc(hdestDC);
            g.Dispose();
            User32.ReleaseDC(IntPtr.Zero, hsrcDC);

            return bmp;
        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
        private class GDI32
        {
            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
            public const int CAPTUREBLT = 0x40000000;

            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }
        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr GetDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        }
    }
}
