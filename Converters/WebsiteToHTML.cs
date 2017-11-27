using System.Threading;
using System.Windows.Forms;

namespace Re_useable_Classes.Converters
{
    public class WebsiteToHtml
    {
        private readonly string _mUrl;
        private WebBrowser _browser;
        private string _mHtml;

        public WebsiteToHtml
            (
            string url,
            string mHtml)
        {
            // With file
            _mUrl = url;
            _mHtml = mHtml;
        }

        public string Generate()
        {
            // Thread
            var mThread = new Thread(_Generate);
            mThread.SetApartmentState(ApartmentState.STA);
            mThread.Start();
            mThread.Join();
            return _mHtml;
        }

        private void _Generate()
        {
            _browser = new WebBrowser
                       {
                           ScrollBarsEnabled = false
                       };

            _browser.Navigate(_mUrl);

            _browser.DocumentCompleted += WebBrowser_DocumentCompleted;

            while (_browser.ReadyState != WebBrowserReadyState.Complete)
            {
            }

            _browser.Dispose();
        }

        private void WebBrowser_DocumentCompleted
            (
            object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            //TODO update SQL Table with Contents of located articles
            string html = _browser.DocumentText;
            _mHtml = html;
        }
    }
}
