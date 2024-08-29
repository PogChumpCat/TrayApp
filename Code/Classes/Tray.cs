using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using AutostartManagement;
using Microsoft.Win32;
using TrayApp.Properties;
using System.Windows.Input;
using WF = System.Windows.Forms;




namespace TrayApp.Code.Classes
{
    internal class Tray
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;
        private ContextMenuStrip settingsMenu;

        Root root = new Root();

        public bool autoStart = false;

        public void InitializeNotifyIcon()
        {
            contextMenu = new ContextMenuStrip();
            settingsMenu = new ContextMenuStrip();



            var tmp = "";
            string name = Environment.UserName;
            string appDataPath = $"C:\\Users\\{name}\\AppData\\Roaming";
            string folderPath = Path.Combine(appDataPath, "TrayApp");
            string icoPath = Path.Combine(folderPath, "logo.ico");
            string imgsPath = Path.Combine(folderPath, "Images");
            string filePath = Path.Combine(folderPath, "config.json");


            try
            {
                tmp = File.ReadAllText(filePath);
            }
            catch
            {
                Directory.CreateDirectory(folderPath);
                Directory.CreateDirectory(imgsPath);
                tmp = Encoding.UTF8.GetString(Resources.config);
                File.WriteAllText(filePath, tmp);
            }


            root = root.Deserialize(filePath);


            notifyIcon = new NotifyIcon
            {
                Text = $"{root.Menu.Mouseover}",
                Visible = true
            };



            if (File.Exists(icoPath))
            {
                notifyIcon.Icon = new Icon(icoPath);
            }

            else
            {
                using (MemoryStream ms = new MemoryStream(Properties.Resources.logo))
                {
                    notifyIcon.Icon = new Icon(ms);
                }

            }


            try
            {
                foreach (var menu in root.Menu.Items)
                {
                    var path = Path.Combine(imgsPath, $"{menu.Title}.png");

                    var item = new ToolStripMenuItem
                    {
                        Text = menu.Title,
                    };


                    if (File.Exists(path))
                    {
                        item.Image = Image.FromFile(path);
                    }

                    else
                    {
                        Root.ByteToImage(Resources.logoPNG);
                    }


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
            }
            catch (Exception ex)
            {
                File.WriteAllText($"\\\\filer01.lktf.dom\\{name}\\Home\\Desktop\\error.txt", $"{ex}");
            }


            var settings = new ToolStripMenuItem
            {
                Text = "Settings",
                Image = Root.ByteToImage(Resources.gear)
            };

            settings.Click += (sender, e) =>
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            };



            var exit = new ToolStripMenuItem
            {
                Text = "exit",
                Image = Resources.sign_out
            };

            exit.Click += (sender, e) =>
            {
                this.notifyIcon.Visible = false;
                Application.Exit();
                Environment.Exit(0);
            };

            settingsMenu.TopLevel = true;
            contextMenu.TopLevel = true;
            settingsMenu.Items.Add(settings);
            settingsMenu.Items.Add(exit);
            notifyIcon.MouseClick += NotifyIcon_MouseClick;
        }



        private void NotifyIcon_MouseClick(object sender, WF.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                contextMenu.Show(WF.Control.MousePosition);
            }

            else if (e.Button == MouseButtons.Right)
            {
                settingsMenu.Show(WF.Control.MousePosition);
            }

        }

    }

}