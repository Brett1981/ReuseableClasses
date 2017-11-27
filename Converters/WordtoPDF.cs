using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace Re_useable_Classes.Converters
{
    public class WordtoPdf
    {
        private object _missingValue = Missing.Value;
        private Application _word = new Application();

        public void WordtoPdfConvert
            (
            string aOutputPdfFile,
            string aWordDocFile)

        {
            string str;
            Convert
                (
                    aWordDocFile,
                    out str);
        }

        private void Convert
            (
            string wordFileName,
            out string pdfFileName)

        {
            _word.Visible = false;

            _word.ScreenUpdating = false;


// Cast as Object for word Open method  

            object filename = wordFileName;


// Use the dummy value as a placeholder for optional arguments  

            Document doc = _word.Documents.Open
                (
                    ref filename,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue);

            doc.Activate();


            object outputFileName = pdfFileName = Path.ChangeExtension
                                                      (
                                                          wordFileName,
                                                          "pdf");


            object fileFormat = WdSaveFormat.wdFormatPDF;


// Save document into PDF Format 

            doc.SaveAs
                (
                    ref outputFileName,
                    ref fileFormat,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue);


// Close the Word document, but leave the Word application open. 


// doc has to be cast to type _Document so that it will find the 


// correct Close method. 


            object saveChanges = WdSaveOptions.wdDoNotSaveChanges;

            doc.Close
                (
                    ref saveChanges,
                    ref _missingValue,
                    ref _missingValue);

            doc = null;


// word has to be cast to type _Application so that it will find 


// the correct Quit method. 

            _word.Quit
                (
                    ref _missingValue,
                    ref _missingValue,
                    ref _missingValue);

            _word = null;
        }
    }
}
