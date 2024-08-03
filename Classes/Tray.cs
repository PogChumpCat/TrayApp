using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using AutostartManagement;
using Microsoft.Win32;

namespace TrayApp.Classes
{
    internal class Tray
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;
        Root root = new Root();
        public static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string folderPath = Path.Combine(appDataPath, "TrayApp");
        public static string filePath = Path.Combine(folderPath, "config.json");
        public static string icoPath = Path.Combine(folderPath, "Images");
        public bool autoStart = true;   

        public void InitializeNotifyIcon()
        {
            var tmp = "";
            contextMenu = new ContextMenuStrip();


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
                Icon = Properties.Resources.logo,
                Text = $"{root.Menu.Mouseover}",
                Visible = true
            };



            foreach (var menu in root.Menu.Items)
            {
                Image iconImage;
                using (var stream = new FileStream(Path.Combine(icoPath, $"{menu.Title}.png"), FileMode.Open))
                {
                    iconImage = Image.FromStream(stream);
                }

                var item = new ToolStripMenuItem
                {
                    Text = menu.Title,
                    Image = iconImage
                    
                };
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

            var exit = new ToolStripMenuItem
            {
                Text = "exit"
            };

            exit.Click += (sender, e) =>
            {
                this.notifyIcon.Visible = false;
                Application.Exit();
                Environment.Exit(0);
            };
            contextMenu.Items.Add(exit);

            notifyIcon.ContextMenuStrip = contextMenu;
        }
    }
}
