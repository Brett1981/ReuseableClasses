using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Re_useable_Classes.Converters
{
    public class HtmlToRtfConverter
    {
        public string ConvertHtmlToRtf(string htmlText)
        {
            if (htmlText != null)
            {
                string xamlText = HtmlToXamlConverter.ConvertHtmlToXaml
                    (
                        htmlText,
                        false);

                return ConvertXamlToRtf(xamlText);
            }

            return null;
        }

        private string ConvertXamlToRtf(string xamlText)
        {
            var richTextBox = new RichTextBox();
            if (string.IsNullOrEmpty(xamlText))
            {
                return "";
            }

            var textRange = new TextRange
                (
                richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd);

            //Create a MemoryStream of the xaml content

            using (var xamlMemoryStream = new MemoryStream())
            {
                using (var xamlStreamWriter = new StreamWriter(xamlMemoryStream))
                {
                    xamlStreamWriter.Write(xamlText);
                    xamlStreamWriter.Flush();
                    xamlMemoryStream.Seek
                        (
                            0,
                            SeekOrigin.Begin);

                    //Load the MemoryStream into TextRange ranging from start to end of RichTextBox.
                    textRange.Load
                        (
                            xamlMemoryStream,
                            DataFormats.Xaml);
                }
            }

            using (var rtfMemoryStream = new MemoryStream())
            {
                textRange = new TextRange
                    (
                    richTextBox.Document.ContentStart,
                    richTextBox.Document.ContentEnd);
                textRange.Save
                    (
                        rtfMemoryStream,
                        DataFormats.Rtf);
                rtfMemoryStream.Seek
                    (
                        0,
                        SeekOrigin.Begin);
                using (var rtfStreamReader = new StreamReader(rtfMemoryStream))
                {
                    return rtfStreamReader.ReadToEnd();
                }
            }
        }
    }
}
