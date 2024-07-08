using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace TrayApp.Classes
{
    internal class Tray
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;


        public void InitializeNotifyIcon()
        {
            ConvertImage convertImage = new ConvertImage();
            var tmp = "";
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(appDataPath, "TrayApp");
            string filePath = Path.Combine(folderPath, "config.json");

            try
            {
                tmp = File.ReadAllText(filePath);
            }
            catch 
            {
                Directory.CreateDirectory(folderPath);
                tmp = Encoding.UTF8.GetString(Properties.Resources.config);
                File.WriteAllText(filePath, tmp);
            }


            Root root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(tmp);

            if(root.menu.trayIcon != null)
            {
                var icon = root.menu.trayIcon;
                convertImage.Base64ToImage(icon);
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
