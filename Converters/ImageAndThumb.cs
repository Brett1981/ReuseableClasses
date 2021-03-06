﻿using System;
using System.Drawing;

namespace Re_useable_Classes.Converters
{
    /*
     * Example USE:
     *          var images = new List<ImageAndThumb>();
                var image = new ImageAndThumb(((string[])(data))[0]);
                images.Add(image);
                listView.ItemSettings.DefaultImage = images[0].Thumb;
     *
     *
     *
     */

    public class ImageAndThumb
    {
        private readonly string _imagePath;
        public Image Big;
        public Image Thumb;

        public ImageAndThumb(string fileName)
        {
            _imagePath = fileName;
            Image image = Image.FromFile(fileName);
            Image thumb = image.GetThumbnailImage
                (
                    200,
                    200,
                    () => false,
                    IntPtr.Zero);
        }

        public Image LoadBigImage()
        {
            Big = Image.FromFile(_imagePath);
            return Big;
        }

        public void UnloadImage()
        {
            Big = null;
        }
    }
}