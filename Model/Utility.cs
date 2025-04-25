using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Programowanie_Projekt.Model
{
    internal class Utility
    {
        public static byte[] ImageToByteArray(FileStream file)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public static BitmapImage ByteArrayToBitmapImage(byte[] byteArray)
        {   if(byteArray.Length==0)
            {
                return null;
            }
            MemoryStream memory = new MemoryStream(byteArray);
            BitmapImage imgSource = new BitmapImage();
            imgSource.BeginInit();
            imgSource.StreamSource = memory;
            imgSource.EndInit();
            return imgSource;
        }
    }
}

