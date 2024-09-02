using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using TrayApp.Properties;

namespace TrayApp.Code.Classes
{
    internal class Root
    {
        public Menu Menu = new Menu();

        public static void Serialize(string filePath, Root root)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                root.Menu.Icon.Save(ms); 
                root.Menu.IconBase64 = Convert.ToBase64String(ms.ToArray());
            }

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

            var tmp = JsonConvert.SerializeObject(root, Formatting.Indented);
            File.WriteAllText(filePath, tmp);
        }

        public static Root Deserialize(string filePath)
        {
            var tmp = File.ReadAllText(filePath);
            var root = JsonConvert.DeserializeObject<Root>(tmp);

            if (!string.IsNullOrEmpty(root.Menu.IconBase64))
            {
                byte[] iconBytes = Convert.FromBase64String(root.Menu.IconBase64);
                using (MemoryStream ms = new MemoryStream(iconBytes))
                {
                    root.Menu.Icon = new Icon(ms);
                    root.Menu.IconBase64 = null;
                }
            }

            foreach (var item in root.Menu.Items)
            {
                if (!string.IsNullOrEmpty(item.ImageBase64))
                {
                    byte[] imageBytes = Convert.FromBase64String(item.ImageBase64);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        item.Image = Image.FromStream(ms);
                        item.ImageBase64 = null;
                    }
                }
            }

            return root;
        }

        public static Image ByteToImage(byte[] byteAr)
        {
            using (MemoryStream ms = new MemoryStream(byteAr))
            {
                return Image.FromStream(ms);
            }

        }
    }

    class FilePath
    {
        public static string name = Environment.UserName;
        public static string desctop = $"C:\\Users\\{name}\\Desktop";
        public static string appDataPath = $"C:\\Users\\{name}\\AppData\\Roaming";
        public static string folderPath = Path.Combine(appDataPath, "TrayApp");
        public static string OldConfig = Path.Combine(folderPath, "OldConfig.json");
        public static string icoPath = Path.Combine(folderPath, "logo.ico");
        public static string imgsPath = Path.Combine(folderPath, "Images");
        public static string filePath = Path.Combine(folderPath, "config.json");
    }

    class Menu
    {
        public string Mouseover { get; set; }
        public string IconBase64 { get; set; }
        public List<Item> Items = new List<Item>();

        [JsonIgnore]
        public Icon Icon { get; set; }
        public string IconPath { get; set; }
    }

    class Item
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string ImageBase64 { get; set; }

        [JsonIgnore]
        public Image Image { get; set; }
        public string ImgPath { get; set; }
    }
}
