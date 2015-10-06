using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Re_useable_Classes.Converters
{
    public class ImageConverter
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save
                (
                    ms,
                    ImageFormat.Gif);
            return ms.ToArray();
        }

        public static string ImageToBase64
            (
            Image image,
            ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save
                    (
                        ms,
                        format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static byte[] ImageToBase64Byte
            (
            Image image,
            ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save
                    (
                        ms,
                        format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            var ms = new MemoryStream
                (
                imageBytes,
                0,
                imageBytes.Length);

            // Convert byte[] to Image
            ms.Write
                (
                    imageBytes,
                    0,
                    imageBytes.Length);
            Image image = Image.FromStream
                (
                    ms,
                    true);
            return image;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return (Image) bf.Deserialize(ms);
            }
            //return returnImage;
        }

        public static byte[] GetBytes(string str)
        {
            var data = new byte[str.Length*2];
            for (int i = 0;
                 i < str.Length;
                 ++i)
            {
                char ch = str[i];
                data[i*2] = (byte) (ch & 0xFF);
                data[i*2 + 1] = (byte) ((ch & 0xFF00) >> 8);
            }

            return data;
        }

        public static string GetString(byte[] bytes)
        {
            var ch = new char[bytes.Length/2];
            for (int i = 0;
                 i < ch.Length;
                 ++i)
            {
                ch[i] = (char) (bytes[i*2] + (bytes[i*2 + 1] << 8));
            }
            return new String(ch);
        }

        public static string ByteArrayToString(byte[] byteArray)
        {
            var hex = new StringBuilder(byteArray.Length*2);
            foreach (byte b in byteArray)
            {
                hex.AppendFormat
                    (
                        "{0:x2}",
                        b);
            }
            return hex.ToString();
        }

        public static byte[] ConvertHexToBytes(string input)
        {
            var result = new byte[(input.Length + 1)/2];
            int offset = 0;
            if (input.Length%2 == 1)
            {
                // If length of input is odd, the first character has an implicit 0 prepended.
                result[0] = (byte) Convert.ToUInt32
                                       (
                                           input[0] + "",
                                           16);
                offset = 1;
            }
            for (int i = 0;
                 i < input.Length/2;
                 i++)
            {
                result[i + offset] = (byte) Convert.ToUInt32
                                                (
                                                    input.Substring
                                                (
                                                    i*2 + offset,
                                                    2),
                                                    16);
            }
            return result;
        }
    }
}
