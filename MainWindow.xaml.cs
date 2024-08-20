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
using TrayApp.UI.UserControls;
using UserControl = TrayApp.UI.UserControls;

namespace TrayApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int amount = 1;  // Зробили полем, замість статичної властивості

        public MainWindow()
        {
            InitializeComponent();
            var tray = new Tray();
            tray.InitializeNotifyIcon();

            VerticalScrollBar.Minimum = 0;
            VerticalScrollBar.Maximum = MainScrollViewer.ExtentHeight - MainScrollViewer.ViewportHeight;
            VerticalScrollBar.ViewportSize = MainScrollViewer.ViewportHeight;

            MainScrollViewer.ScrollChanged += MainScrollViewer_ScrollChanged;
        }

        public MainWindow(bool state) { if (state && !this.IsLoaded) { this.Visibility = Visibility.Visible; } else { this.Visibility = Visibility.Collapsed; } }

        private void MainScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            VerticalScrollBar.Value = MainScrollViewer.VerticalOffset;
        }

        private void VerticalScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainScrollViewer.ScrollToVerticalOffset(e.NewValue);
        }

        public void AddNewElement()
        {
            if (DynamicContentPanel.Children.Count > 0)
            {
                var separator = new Separator
                {
                    Margin = new Thickness(0, 5, 0, 5),
                    Background = Brushes.Gray,
                    Height = 1
                };
                DynamicContentPanel.Children.Add(separator);
            }

            var temp = new Template(amount);  // Передаємо значення amount в конструктор
            DynamicContentPanel.Children.Add(temp);
            amount++;  // Інкрементуємо amount
            UpdateScrollBar();
        }

        public void RemoveElement()
        {
            if (DynamicContentPanel.Children.Count > 0)
            {
                DynamicContentPanel.Children.RemoveAt(DynamicContentPanel.Children.Count - 1);

                if (DynamicContentPanel.Children.Count > 0 && DynamicContentPanel.Children[DynamicContentPanel.Children.Count - 1] is Separator)
                {
                    DynamicContentPanel.Children.RemoveAt(DynamicContentPanel.Children.Count - 1);
                }
                amount--;  // Декрементуємо amount
                UpdateScrollBar();
            }
        }

        private void UpdateScrollBar()
        {
            MainScrollViewer.UpdateLayout();
            VerticalScrollBar.Minimum = 0;
            VerticalScrollBar.Maximum = MainScrollViewer.ExtentHeight - MainScrollViewer.ViewportHeight;
            VerticalScrollBar.ViewportSize = MainScrollViewer.ViewportHeight;

            VerticalScrollBar.Visibility = VerticalScrollBar.Maximum > 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddNewElement();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            RemoveElement();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }

}
