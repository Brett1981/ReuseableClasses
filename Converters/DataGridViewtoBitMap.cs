using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Re_useable_Classes.Converters
{
    internal sealed class DataGrid2Bitmap
    {
        private const int Src = 0xCC0020;
        //DataGrid2Bitmap.ConvertDG2BMP(DataGridView1, sFilePath);

        [DllImport("gdi32.dll", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool BitBlt
            (
            IntPtr pHdc,
            int iX,
            int iY,
            int iWidth,
            int iHeight,
            IntPtr pHdcSource,
            int iXSource,
            int iYSource,
            Int32 dw);

        public static void ConvertDg2Bmp
            (
            DataGridView dg,
            string sFilePath)
        {
            dg.Refresh();
            dg.Select();

            Graphics g = dg.CreateGraphics();
            var ibitMap = new Bitmap
                (
                dg.ClientSize.Width,
                dg.ClientSize.Height,
                g);
            Graphics iBitMapGr = Graphics.FromImage(ibitMap);
            IntPtr iBitMapHdc = iBitMapGr.GetHdc();
            IntPtr meHdc = g.GetHdc();

            BitBlt
                (
                    iBitMapHdc,
                    0,
                    0,
                    dg.ClientSize.Width,
                    dg.ClientSize.Height,
                    meHdc,
                    0,
                    0,
                    Src);
            g.ReleaseHdc(meHdc);
            iBitMapGr.ReleaseHdc(iBitMapHdc);

            if (sFilePath == "")
            {
                return;
            }
            ibitMap.Save
                (
                    sFilePath,
                    ImageFormat.Bmp);
        }
    }
}