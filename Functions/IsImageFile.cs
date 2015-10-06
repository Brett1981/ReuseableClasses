using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Re_useable_Classes.Functions
{
    public static class IsImageFile
    {
        public static bool IsRecognisedImageFile(string fileName)
        {
            string targetExtension = Path.GetExtension(fileName);
            if (String.IsNullOrEmpty(targetExtension))
            {
                return false;
            }
            targetExtension = "*" + targetExtension.ToLowerInvariant();

            var recognisedImageExtensions = new List<string>();

            foreach (ImageCodecInfo imageCodec in ImageCodecInfo.GetImageEncoders())
            {
                recognisedImageExtensions.AddRange
                    (
                        imageCodec.FilenameExtension.ToLowerInvariant()
                                  .Split(";".ToCharArray()));
            }

            bool targetFound = false;
            return recognisedImageExtensions.Any(extension => extension.Equals(targetExtension));
        }
    }
}
