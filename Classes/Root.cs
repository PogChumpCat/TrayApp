using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;



namespace TrayApp.Classes
{
    internal class Root
    {
        public Menu menu { get; set; }
    }

    struct Menu
    {
        public string mouseover { get; set; }
        public string trayIcon { get; set; }

        public List<Item> items { get; set; }
        [JsonIgnore]
        public Image Image { get; set; }
    }

    struct Item
    {
        public string title { get; set; }
        public string url { get; set; }
    }
}
