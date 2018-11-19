namespace Re_useable_Classes.Converters
{
    public interface IMarkupConverter
    {
        string ConvertXamlToHtml(string xamlText);

        string ConvertHtmlToXaml(string htmlText);

        string ConvertRtfToHtml(string rtfText);

        string ConvertHtmlToRtf(string htmlText);
    }
}