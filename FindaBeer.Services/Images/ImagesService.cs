using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace FindaBeer.Services.Images
{
    public sealed class ImagesService
    {
        public Image CropCenter(Image image, int width, int height)
        {
            int left = 0;
            int top = 0;
            int srcWidth = width;
            int srcHeight = height;
            Bitmap finalImage = new Bitmap(width, height);

            finalImage.MakeTransparent();

            double croppedHeightToWidth = (double)height / width;
            double croppedWidthToHeight = (double)width / height;

            if (image.Width > image.Height)
            {
                srcWidth = (int)(Math.Round(image.Height * croppedWidthToHeight));
                if (srcWidth < image.Width)
                {
                    srcHeight = image.Height;
                    left = (image.Width - srcWidth) / 2;
                }
                else
                {
                    srcHeight = (int)Math.Round(image.Height * ((double)image.Width / srcWidth));
                    srcWidth = image.Width;
                    top = (image.Height - srcHeight) / 2;
                }
            }
            else
            {
                srcHeight = (int)(Math.Round(image.Width * croppedHeightToWidth));
                if (srcHeight < image.Height)
                {
                    srcWidth = image.Width;
                    top = (image.Height - srcHeight) / 2;
                }
                else
                {
                    srcWidth = (int)Math.Round(image.Width * ((double)image.Height / srcHeight));
                    srcHeight = image.Height;
                    left = (image.Width - srcWidth) / 2;
                }
            }

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                new Rectangle(left, top, srcWidth, srcHeight), GraphicsUnit.Pixel);
            }

            return finalImage;
        }

        public Image FromBase64(string base64)
        {
            if (base64.Contains("data:image"))
                base64 = base64.Substring(base64.IndexOf(',') + 1);

            byte[] imageBytes = Convert.FromBase64String(base64);
            MemoryStream ms = new MemoryStream(imageBytes);
            Image image = Image.FromStream(ms, true, true);
            return image;
        }

        public string ToBase64(Image image)
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }
}
