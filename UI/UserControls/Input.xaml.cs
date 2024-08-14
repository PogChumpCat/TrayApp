using System.Windows;
using System.Windows.Controls;

namespace TrayApp.UI.UserControls
{
    public partial class Input : UserControl
    {
        public Input()
        {
            InitializeComponent();
        }

        // DependencyProperty for Placeholder
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register(
                nameof(Placeholder),
                typeof(string),
                typeof(Input),
                new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Input;
            if (control != null)
            {
                control.TblContext.Text = (string)e.NewValue;
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TxtInput.Clear();
            TxtInput.Focus();
        }

        private void TxtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TblContext.Visibility = string.IsNullOrEmpty(TxtInput.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
