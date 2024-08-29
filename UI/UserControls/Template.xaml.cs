using System;
using System.Windows;
using System.Windows.Controls;

namespace TrayApp.UI.UserControls
{
    /// <summary>
    /// Interaction logic for Template.xaml
    /// </summary>
    public partial class Template : UserControl
    {
        private StackPanel _dynamicContentPanel;
        private StackPanel _mainScrollViewer;
        private StackPanel _verticalScrollBar;

        public Template()
        {
            InitializeComponent();
        }

        // Конструктор для передачі DynamicContentPanel
        public Template(int number, StackPanel dynamicContentPanel) 
        {
            InitializeComponent();
            Number.Text = number.ToString();
            _dynamicContentPanel = dynamicContentPanel;
        }

        public Grid GetAddon()
        {
            return addons;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (_dynamicContentPanel != null)
            {
                int currentIndex = _dynamicContentPanel.Children.IndexOf(this);
                // Видалення цього елемента з DynamicContentPanel
                _dynamicContentPanel.Children.Remove(this);

                // Видалення попереднього роздільника, якщо такий є
                if (currentIndex > 0 && _dynamicContentPanel.Children[currentIndex - 1] is Separator)
                {
                    _dynamicContentPanel.Children.RemoveAt(currentIndex - 1);
                }
                else if (_dynamicContentPanel.Children.Count > 0 && _dynamicContentPanel.Children[0] is Separator)
                {
                    _dynamicContentPanel.Children.RemoveAt(0);
                }
            }
        }
    }
}
