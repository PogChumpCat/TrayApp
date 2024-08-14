using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrayApp.Code.Classes;
using UserControl = TrayApp.UI.UserControls;

namespace TrayApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            var tray = new Tray();
            tray.InitializeNotifyIcon();

            VerticalScrollBar.Minimum = 0;
            VerticalScrollBar.Maximum = MainScrollViewer.ExtentHeight - MainScrollViewer.ViewportHeight;
            VerticalScrollBar.ViewportSize = MainScrollViewer.ViewportHeight;

            MainScrollViewer.ScrollChanged += MainScrollViewer_ScrollChanged;

            //this.Hide();
        }

        private void MainScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            VerticalScrollBar.Value = MainScrollViewer.VerticalOffset;
        }

        private void VerticalScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainScrollViewer.ScrollToVerticalOffset(e.NewValue);
        }

        public void AddNewElement(string content, Brush backgroundColor)
        {
            var newElement = UserControl.Template.GetAddon();

            DynamicContentPanel.Children.Add(newElement);
            UpdateScrollBar();
        }

        private void UpdateScrollBar()
        {
            MainScrollViewer.UpdateLayout();
            VerticalScrollBar.Minimum = 0;
            VerticalScrollBar.Maximum = MainScrollViewer.ExtentHeight - MainScrollViewer.ViewportHeight;
            VerticalScrollBar.ViewportSize = MainScrollViewer.ViewportHeight;

            VerticalScrollBar.Visibility = VerticalScrollBar.Maximum > 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewElement("hi", Background);
        }
    }
}
