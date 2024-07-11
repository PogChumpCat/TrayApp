using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;



namespace TrayApp.Classes
{
    internal class Root
    {
        public Menu Menu { get; set; }

        public void Serialise(string filePath, Root root)
        {
            var tmp = JsonConvert.SerializeObject(root, Formatting.Indented);
            File.WriteAllText(filePath, tmp);
        }

        public Root Deserialise(string filePath)
        {
            var tmp = File.ReadAllText(filePath);

            var root = JsonConvert.DeserializeObject<Root>(tmp);
            root.Menu.Icon = ConvertImage.Base64ToIcon(root.Menu.TrayIcon);
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
    }

    class Item
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
