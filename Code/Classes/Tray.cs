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

namespace TrayApp.Code.Classes
{
    internal class Tray

    {

        private NotifyIcon notifyIcon;

        private ContextMenuStrip contextMenu;

        Root root = new Root();

        public bool autoStart = false;



        public void InitializeNotifyIcon()

        {

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

                tmp = Encoding.UTF8.GetString(Properties.Resources.config);

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

            contextMenu = new ContextMenuStrip();

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
                        using (MemoryStream ms = new MemoryStream(Properties.Resources.logoPNG))
                        {
                            item.Image = Image.FromStream(ms);
                        }
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

            notifyIcon.ContextMenuStrip = contextMenu;



            notifyIcon.DoubleClick += (sender, e) =>

            {

                MainWindow window = new MainWindow(true);



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
            contextMenu.Items.Add(exit);

            notifyIcon.ContextMenuStrip = contextMenu;
        }
    }
}
