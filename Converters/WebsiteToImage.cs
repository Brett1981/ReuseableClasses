using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Re_useable_Classes.Converters
{
    public static class BitmapExtensions
    {
        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            return codecs.FirstOrDefault(codec => codec.FormatID == format.Guid);

            // Return
        }

        public static void SaveJpg100
            (
            this Bitmap bmp,
            string filename)
        {
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter
                (
                Encoder.Quality,
                100L);
            bmp.Save
                (
                    filename,
                    GetEncoder(ImageFormat.Jpeg),
                    encoderParameters);
        }

        public static void SaveJpg100
            (
            this Bitmap bmp,
            Stream stream)
        {
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter
                (
                Encoder.Quality,
                100L);
            bmp.Save
                (
                    stream,
                    GetEncoder(ImageFormat.Jpeg),
                    encoderParameters);
        }
    }

    public class WebsiteToImage
    {
        private readonly string _mFileName = string.Empty;
        private readonly string _mUrl;
        private Bitmap _mBitmap;

        public WebsiteToImage(string url)
        {
            // Without file
            _mUrl = url;
        }

        public WebsiteToImage
            (
            string url,
            string fileName)
        {
            // With file
            _mUrl = url;
            _mFileName = fileName;
        }

        public Bitmap Generate()
        {
            // Thread
            var mThread = new Thread(_Generate);
            mThread.SetApartmentState(ApartmentState.STA);
            mThread.Start();
            mThread.Join();
            return _mBitmap;
        }

        private void _Generate()
        {
            var browser = new WebBrowser
                          {
                              ScrollBarsEnabled = false
                          };
            browser.Navigate(_mUrl);
            browser.DocumentCompleted += WebBrowser_DocumentCompleted;

            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            browser.Dispose();
        }

        private void WebBrowser_DocumentCompleted
            (
            object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            // Capture
            var browser = (WebBrowser) sender;
            if (browser.Document != null && browser.Document.Body != null)
            {
                browser.ClientSize = new Size
                    (
                    browser.Document.Body.ScrollRectangle.Width,
                    browser.Document.Body.ScrollRectangle.Bottom);
                browser.ScrollBarsEnabled = false;
                _mBitmap = new Bitmap
                    (
                    browser.Document.Body.ScrollRectangle.Width,
                    browser.Document.Body.ScrollRectangle.Bottom);
            }
            browser.BringToFront();
            browser.DrawToBitmap
                (
                    _mBitmap,
                    browser.Bounds);

            // Save as file?
            if (_mFileName.Length > 0)
            {
                // Save
                _mBitmap.SaveJpg100(_mFileName);
            }
        }
    }
}
