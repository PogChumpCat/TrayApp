using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TrayApp.UI.UserControls;
using System.Windows.Controls.Primitives;

namespace TrayApp.Code.Classes
{
    public class ScrollManager
    {
        private ScrollManager() { }

        public MainWindow _mainWindow; 

        public int amount = 1; 
        public ScrollManager(MainWindow mainWindow) 
        {
            _mainWindow = mainWindow;
            _mainWindow.VerticalScrollBar.Minimum = 0;
            _mainWindow.VerticalScrollBar.Maximum = _mainWindow.MainScrollViewer.ExtentHeight - _mainWindow.MainScrollViewer.ViewportHeight;
            _mainWindow.VerticalScrollBar.ViewportSize = _mainWindow.MainScrollViewer.ViewportHeight;

            _mainWindow.MainScrollViewer.ScrollChanged += MainScrollViewer_ScrollChanged;
        }

        private void MainScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            _mainWindow.VerticalScrollBar.Value = _mainWindow.MainScrollViewer.VerticalOffset;
        }

        public void AddNewElement()
        {
            if (_mainWindow.DynamicContentPanel.Children.Count > 0)
            {
                var separator = new Separator
                {
                    Margin = new Thickness(0, 5, 0, 5),
                    Background = Brushes.Gray,
                    Height = 1
                };
                _mainWindow.DynamicContentPanel.Children.Add(separator);
            }

            var temp = new Template(amount, this);
            _mainWindow.DynamicContentPanel.Children.Add(temp);
            amount++;
            UpdateScrollBar();
        }

        public void RemoveElement()
        {
            if (_mainWindow.DynamicContentPanel.Children.Count > 0)
            {
                _mainWindow.DynamicContentPanel.Children.RemoveAt(_mainWindow.DynamicContentPanel.Children.Count - 1);

                if (_mainWindow.DynamicContentPanel.Children.Count > 0 && _mainWindow.DynamicContentPanel.Children[_mainWindow.DynamicContentPanel.Children.Count - 1] is Separator)
                {
                    _mainWindow.DynamicContentPanel.Children.RemoveAt(_mainWindow.DynamicContentPanel.Children.Count - 1);
                }
                amount--;
                UpdateScrollBar();
            }
        }

        public void RemoveAt(Template _template)
        {
            if (_mainWindow.DynamicContentPanel != null)
            {
                int currentIndex = _mainWindow.DynamicContentPanel.Children.IndexOf(_template);
                _mainWindow.DynamicContentPanel.Children.Remove(_template);

                int i = 0;
                foreach (var child in _mainWindow.DynamicContentPanel.Children)
                {
                    if (child is Template template)
                    {
                        i++;
                        template.Number.Text = i.ToString();
                    }
                }
                amount--;
                if (currentIndex > 0 && _mainWindow.DynamicContentPanel.Children[currentIndex - 1] is Separator)
                {
                    _mainWindow.DynamicContentPanel.Children.RemoveAt(currentIndex - 1);
                }
                else if (_mainWindow.DynamicContentPanel.Children.Count > 0 && _mainWindow.DynamicContentPanel.Children[0] is Separator)
                {
                    _mainWindow.DynamicContentPanel.Children.RemoveAt(0);
                }
                UpdateScrollBar();
            }
        }

        private void UpdateScrollBar()
        {
            _mainWindow.MainScrollViewer.UpdateLayout();
            _mainWindow.VerticalScrollBar.Minimum = 0;
            _mainWindow.VerticalScrollBar.Maximum = _mainWindow.MainScrollViewer.ExtentHeight - _mainWindow.MainScrollViewer.ViewportHeight;
            _mainWindow.VerticalScrollBar.ViewportSize = _mainWindow.MainScrollViewer.ViewportHeight;

            _mainWindow.VerticalScrollBar.Visibility = _mainWindow.VerticalScrollBar.Maximum > 0 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
