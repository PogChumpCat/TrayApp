using System;
using System.Windows;
using System.Windows.Controls;
using TrayApp.Code.Classes;

namespace TrayApp.UI.UserControls
{
    /// <summary>
    /// Interaction logic for Template.xaml
    /// </summary>
    public partial class Template : UserControl
    {
        private ScrollManager _scroll;

        public Template()
        {
            InitializeComponent();
        }

        public Template(int amount, ScrollManager scroll) 
        {
            InitializeComponent();
            Number.Text = amount.ToString();
            _scroll = scroll;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            _scroll.RemoveAt(this);
        }
    }
}
