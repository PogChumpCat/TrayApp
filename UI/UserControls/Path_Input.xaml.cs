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
using Win = Microsoft.Win32;

namespace TrayApp.UI.UserControls
{
    /// <summary>
    /// Interaction logic for Path_Input.xaml
    /// </summary>
    public partial class Path_Input : UserControl
    {

        public Path_Input()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(
                nameof(Placeholder),
                typeof(string),
                typeof(Path_Input),
                new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Path_Input;
            if (control != null)
            {
                control.TblContext.Text = (string)e.NewValue;
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Win.OpenFileDialog
            {
                Filter = "Icon files (.ico)|*.ico|(.png)|*.png|(.json)|*.json"
            };
            var result = dialog.ShowDialog();
            if (result.HasValue == true)
            {
                Input.Text = dialog.FileName;
            }
        }

        private void TxtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TblContext.Visibility = string.IsNullOrEmpty(Input.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
