using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using AutostartManagement;

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

        static bool registerShortcutForAllUser = false;
        AutostartManager autostartManager = new AutostartManager(Application.ProductName, Application.ExecutablePath, registerShortcutForAllUser);


        public void InitializeNotifyIcon()
        {
            autostartManager.IsAutostartEnabled();
            autostartManager.EnableAutostart();
            var tmp = "";

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
