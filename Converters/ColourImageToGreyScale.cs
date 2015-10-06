﻿using System.Drawing;

namespace Re_useable_Classes.Converters
{
    public class ColourImageToGreyScale
    {
        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //make an empty bitmap the same size as original
            var newBitmap = new Bitmap
                (
                original.Width,
                original.Height);

            for (int i = 0;
                 i < original.Width;
                 i++)
            {
                for (int j = 0;
                     j < original.Height;
                     j++)
                {
                    //get the pixel from the original image
                    Color originalColor = original.GetPixel
                        (
                            i,
                            j);

                    //create the grayscale version of the pixel
                    var grayScale = (int) ((originalColor.R*.3) + (originalColor.G*.59)
                                           + (originalColor.B*.11));

                    //create the color object
                    Color newColor = Color.FromArgb
                        (
                            grayScale,
                            grayScale,
                            grayScale);

                    //set the new image's pixel to the grayscale version
                    newBitmap.SetPixel
                        (
                            i,
                            j,
                            newColor);
                }
            }

            return newBitmap;
        }
    }
}
