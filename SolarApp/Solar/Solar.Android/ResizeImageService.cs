﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Dependency(typeof(Solar.Droid.ResizeImageService))]
namespace Solar.Droid
{
    public class ResizeImageService: Solar.Services.IResizeImageService
    {
        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            // Load the bitmap 
            BitmapFactory.Options options = new BitmapFactory.Options
            {
                InPurgeable = true // inPurgeable is used to free up memory while required
            };// Create object of bitmapfactory's option method for further option use
            Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length, options);
            var originalHeight = originalImage.Height;
            var originalWidth = originalImage.Width;


            float newHeight;
            float newWidth;
            if (originalHeight > originalWidth)
            {
                newHeight = height;
                float ratio = originalHeight / height;
                newWidth = originalWidth / ratio;
            }
            else
            {
                newWidth = width;
                float ratio = originalWidth / width;
                newHeight = originalHeight / ratio;
            }

            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)newWidth, (int)newHeight, true);

            originalImage.Recycle();

            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Compress(Bitmap.CompressFormat.Png, 100, ms);

                resizedImage.Recycle();
                resizedImage.Dispose();
                return ms.ToArray();
            }
        }
    }
}