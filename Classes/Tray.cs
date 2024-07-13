using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TrayApp.Classes
{
    internal class Tray
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;
        Root root = new Root();


        public void InitializeNotifyIcon()
        {
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


            root = root.Deserialise(filePath);


            notifyIcon = new NotifyIcon
            {
                Icon = Properties.Resources.logo,/*ConvertImage.Base64ToIcon($"{root.Menu.Icon}")*/
                Text = $"{root.Menu.Mouseover}",
                Visible = true
            };

            contextMenu = new ContextMenuStrip();


            foreach (var menu in root.Menu.Items)
            {
                var item = new ToolStripMenuItem
                {
                    Text = menu.Title
                    
                };
                item.Image = null;
                item.Click += (sender, e) =>
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = menu.Url,
                        
                        UseShellExecute = true
                    });
                };

                contextMenu.Items.Add(item);
            }

            notifyIcon.ContextMenuStrip = contextMenu;
        }
    }
}
