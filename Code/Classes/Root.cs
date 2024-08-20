using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace TrayApp.Code.Classes
{
    internal class Root
    {
        public Menu Menu { get; set; }

        public void Serialize(string filePath, Root root)
        {
            foreach (var item in root.Menu.Items)
            {
                if (item.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        item.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        item.ImageBase64 = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }

            // Серіалізація об'єкту Root у JSON
            var tmp = JsonConvert.SerializeObject(root, Formatting.Indented);
            File.WriteAllText(filePath, tmp);
        }

        public Root Deserialize(string filePath)
        {
            var tmp = File.ReadAllText(filePath);
            var root = JsonConvert.DeserializeObject<Root>(tmp);

            // Десеріалізація кожного зображення з Base64
            foreach (var item in root.Menu.Items)
            {
                if (!string.IsNullOrEmpty(item.ImageBase64))
                {
                    byte[] imageBytes = Convert.FromBase64String(item.ImageBase64);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        item.Image = Image.FromStream(ms);
                    }
                }
            }

            return root;
        }
    }

    class Menu
    {
        public string Mouseover { get; set; }
        public string TrayIcon { get; set; }
        public List<Item> Items { get; set; }

        [JsonIgnore]
        public Icon Icon { get; set; }
        public string IconPath { get; set; }
    }

    class Item
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageBase64 { get; set; }

        [JsonIgnore]
        public Image Image { get; set; }
        public string ImgPath { get; set; }
    }
}
