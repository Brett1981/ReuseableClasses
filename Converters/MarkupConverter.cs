namespace Re_useable_Classes.Converters
{
    public class MarkupConverter : IMarkupConverter
    {
        private readonly HtmlToRtfConverter _aHtmlToRtfConverter;

        public MarkupConverter(HtmlToRtfConverter aHtmlToRtfConverter)
        {
            _aHtmlToRtfConverter = aHtmlToRtfConverter;
        }

        public string ConvertXamlToHtml(string xamlText)
        {
            return HtmlFromXamlConverter.ConvertXamlToHtml
                (
                    xamlText,
                    false);
        }

        public string ConvertHtmlToXaml(string htmlText)
        {
            return HtmlToXamlConverter.ConvertHtmlToXaml
                (
                    htmlText,
                    true);
        }

        public string ConvertRtfToHtml(string rtfText)
        {
            return RtfToHtmlConverter.ConvertRtfToHtml(rtfText);
        }

        public string ConvertHtmlToRtf(string htmlText)
        {
            return _aHtmlToRtfConverter.ConvertHtmlToRtf(htmlText);
        }
    }
}
