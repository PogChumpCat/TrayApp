using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace TrayApp.Classes
{
    internal class Tray
    {
        private string username;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;


        public void InitializeNotifyIcon()
        {
            var tmp = "";
            username = Environment.UserName;


            try
            {
                tmp = File.ReadAllText($"C/Users/{username}/AppData/Local/TrayApp/comfig.json");
            }
            catch 
            {
                tmp = Encoding.UTF8.GetString(Properties.Resources.Template);
            }


            Root root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(tmp);

            if(root.menu.icon != null)
            {

            }
           

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("icon.ico", 128, 128);
            notifyIcon.Text = "LKTF-Linkmen";
            notifyIcon.Visible = true;

            contextMenu = new ContextMenuStrip();


            foreach (var menu in root.menu.items)
            {
                var item = new ToolStripMenuItem();
                item.Text = menu.title;
                item.Click += (sender, e) =>
                {
                    System.Diagnostics.Process.Start(menu.url);
                };
            }
        }
    }

}
