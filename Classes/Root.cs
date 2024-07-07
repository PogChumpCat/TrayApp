using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace TrayApp.Classes
{
    internal class Root
    {
        public Menu menu { get; set; }

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
    }

    struct Menu
    {
        public string mouseover { get; set; }
        public Image icon { get; set; }

        public List<Item> items { get; set; }
    }

    struct Item
    {
        public string title { get; set; }
        public string url { get; set; }
    }
}
