using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace StudentTesting.Application.Utils
{
    public static class ConvertType
    {
        public static BitmapImage ConvertBitmapToImageSource(Bitmap bitmap)
        {
            using var ms = new MemoryStream();

            bitmap.Save(ms, ImageFormat.Bmp);
            ms.Position = 0;
            BitmapImage bitmapimage = new BitmapImage();

            bitmapimage.BeginInit();
            bitmapimage.StreamSource = ms;
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapimage.EndInit();

            return bitmapimage;
        }

        public static string[] ConvertStringToMassiveString(string s)
        {
            return s
                .Select(x => x.ToString())
                .ToArray();
        }
    }
}
