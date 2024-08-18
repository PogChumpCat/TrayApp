using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Win = Microsoft.Win32;


namespace TrayApp.UI.UserControls
{
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
            var dialog = new Win.OpenFileDialog();
            dialog.Filter = "Text documents (.txt)|*.txt";
            var result = dialog.ShowDialog();
            if (result.HasValue == true)
            {
                TxtInput.Text = dialog.FileName;
            }
        }

        private void TextInput_GotFocus(object sender, RoutedEventArgs e)
        {
            Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#579DE5"));
        }

        private void TextInput_LostFocus(object sender, RoutedEventArgs e)
        {
            Border.BorderBrush = new SolidColorBrush(Colors.Gray);
        }


        private void TxtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TblContext.Visibility = string.IsNullOrEmpty(TxtInput.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
