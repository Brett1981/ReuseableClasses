using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Re_useable_Classes.Converters
{
    public static class BitmaptoIcon
    {
        private static readonly byte[] Pngiconheader =
        {
            0,
            0,
            1,
            0,
            1,
            0,
            0,
            0,
            0,
            0,
            1,
            0,
            24,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0
        };

        public static Icon PngIconFromImage
            (
            Image img,
            int size = 16)
        {
            using (var bmp = new Bitmap
                (
                img,
                new Size
                    (
                    size,
                    size)))
            {
                byte[] png;
                using (var fs = new MemoryStream())
                {
                    bmp.Save
                        (
                            fs,
                            ImageFormat.Png);
                    fs.Position = 0;
                    png = fs.ToArray();
                }

                using (var fs = new MemoryStream())
                {
                    if (size >= 256)
                    {
                        size = 0;
                    }
                    Pngiconheader[6] = (byte) size;
                    Pngiconheader[7] = (byte) size;
                    Pngiconheader[14] = (byte) (png.Length & 255);
                    Pngiconheader[15] = (byte) (png.Length/256);
                    Pngiconheader[18] = (byte) (Pngiconheader.Length);

                    fs.Write
                        (
                            Pngiconheader,
                            0,
                            Pngiconheader.Length);
                    fs.Write
                        (
                            png,
                            0,
                            png.Length);
                    fs.Position = 0;
                    return new Icon(fs);
                }
            }
        }
    }
}
