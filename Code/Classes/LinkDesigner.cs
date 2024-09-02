using System.Drawing;
using System.IO;
using System.Windows;
using Ctrl = System.Windows.Controls;
using TrayApp.UI.UserControls;
using System.Collections.Generic;

namespace TrayApp.Code.Classes
{
    internal class LinkDesigner
    {
        public static Root _Root = new Root();
        public static Root OldRoot = new Root();

        public LinkDesigner()
        {

        }

        public static void ConfigSaver( ScrollManager scroll)
        {
            Tray Tray = new Tray();
            Root root = new Root();


            if (File.Exists(FilePath.filePath))
            {
                File.Delete(FilePath.OldConfig);
                File.Move(FilePath.filePath, FilePath.OldConfig);
            }

           
            var menu = scroll._mainWindow;


            root.Menu.Mouseover = menu.Mouseover?.TxtInput.Text;
            root.Menu.IconPath = menu.IconPath?.Input.Text;
            root.Menu.Icon = new Icon(root.Menu?.IconPath);
            if (!string.IsNullOrEmpty(root.Menu.IconPath) && File.Exists(root.Menu.IconPath))
            {
                root.Menu.Icon = new Icon(root.Menu.IconPath);
            }


            foreach (var child in scroll._mainWindow.DynamicContentPanel.Children)
            {
                if (child is Template template)
                {
                    var item = new Item();
                    item.Title = template.Name.TxtInput.Text;
                    item.Type = template.Type.Text;
                    item.Url = template.Url.TxtInput.Text;
                    item.ImgPath = template.Path?.Input.Text;
                    if (!string.IsNullOrEmpty(item.ImgPath) && File.Exists(item.ImgPath))
                    {
                        item.Image = Image.FromFile(item.ImgPath);
                    }
                    root.Menu.Items.Add(item);           
                }
            }

            if (menu.SavePath.Input.Text != null && menu.SavePath.Input.Text.Trim().Length > 0)
            {
                Root.Serialize(Path.Combine(menu.SavePath?.Input.Text, "config.json"), root);
                Root.Serialize(FilePath.filePath, root);
            }
            else
            {
                Root.Serialize(FilePath.filePath, root);
                Root.Serialize(Path.Combine(FilePath.desctop, "config.json"), root);
            }
            _Root = root;
        }

        public static void ConfigLoader(ScrollManager scroll) 
        {
            if (File.Exists(FilePath.OldConfig))
            {
                OldRoot = Root.Deserialize(FilePath.OldConfig);
            }
            else
            {
                if (MessageBox.Show("You don`t have old settings, do you want to load current?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    OldRoot = Root.Deserialize(FilePath.filePath);
                }
                else{return;}
            }
            var _menu = OldRoot.Menu;
            var menu = scroll._mainWindow;
            var item = OldRoot.Menu.Items;

            menu.Mouseover.TxtInput.Text = _menu.Mouseover;
            menu.IconPath.Input.Text = _menu.IconPath;

            scroll._mainWindow.DynamicContentPanel.Children.Clear();
            foreach(var Item in OldRoot.Menu.Items)
            {
                scroll.AddNewElement();
            }
            int i = 0;
            foreach (var child in scroll._mainWindow.DynamicContentPanel.Children)
            {
                if (child is Template template && !(child is Ctrl.Separator))
                {
                    template.Name.TxtInput.Text = item[i].Title;
                    template.Type.Text = item[i].Type;
                    template.Url.TxtInput.Text = item[i].Url;
                    template.Path.Input.Text = item[i].ImgPath;
                i++;
                }
            }
        }
    }
}
