using System;
using System.Globalization;
using System.IO;

namespace Re_useable_Classes.Converters
{
    public static class TypeConverters
    {
        public static bool ByteArrayToFile
            (
            string fileName,
            byte[] byteArray)
        {
            try
            {
                // Open file for reading
                var fileStream = new FileStream
                    (
                    fileName,
                    FileMode.Create,
                    FileAccess.Write);

                // Writes a block of bytes
                fileStream.Write
                    (
                        byteArray,
                        0,
                        byteArray.Length);

                // Close file stream
                fileStream.Close();

                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
            return false;
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        public static string ConvertUStoUkDateFormat(string aUsDate)
        {
            DateTimeFormatInfo usDtfi = new CultureInfo
                (
                "en-US",
                false).DateTimeFormat;
            DateTimeFormatInfo ukDtfi = new CultureInfo
                (
                "en-GB",
                false).DateTimeFormat;
            string result = Convert.ToDateTime
                (
                    aUsDate,
                    usDtfi)
                                   .ToString(ukDtfi.ShortDatePattern);
            return result;
        }

        public static byte[] StreamFile(string fileName)
        {
            // Open file
            var fs = new FileStream
                (
                fileName,
                FileMode.Open,
                FileAccess.Read);

            // ByteArray
            var imageData = new byte[fs.Length];

            // Read block of bytes
            fs.Read
                (
                    imageData,
                    0,
                    Convert.ToInt32(fs.Length));

            // Close it
            fs.Close();

            // Return the byte data
            return imageData;
        }
    }
}