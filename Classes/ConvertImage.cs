using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace TrayApp.Classes
{
    internal class ConvertImage
    {


        public static string ImageToBase64(string imagePath)
        {
            using (Image image = Image.FromFile(imagePath))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Визначення формату зображення за розширенням файлу
                    System.Drawing.Imaging.ImageFormat format = imagePath.EndsWith(".png") ? System.Drawing.Imaging.ImageFormat.Png :
                                                                 imagePath.EndsWith(".jpg") || imagePath.EndsWith(".jpeg") ? System.Drawing.Imaging.ImageFormat.Jpeg :
                                                                 imagePath.EndsWith(".ico") ? System.Drawing.Imaging.ImageFormat.Icon :
                                                                 System.Drawing.Imaging.ImageFormat.Png; // дефолтний формат

                    image.Save(memoryStream, format);
                    byte[] imageBytes = memoryStream.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
        }



        public static Image Base64ToImage(string base64String)
        {
            // Конвертуємо Base64 рядок у масив байтів
            byte[] imageBytes = Convert.FromBase64String(base64String);

            // Використовуємо MemoryStream для створення зображення з байтів
            using (var ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }

    }
}
