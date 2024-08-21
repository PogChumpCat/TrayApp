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

namespace TrayApp.UI.UserControls
{
    /// <summary>
    /// Interaction logic for AddCmbElm.xaml
    /// </summary>
    public partial class AddCmbElm : UserControl
    {
        public AddCmbElm()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PlaceholderProperty =
    DependencyProperty.Register(
        nameof(Placeholder),
        typeof(string),
        typeof(AddCmbElm),
        new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as AddCmbElm;
            if (control != null)
            {
                control.TblContext.Text = (string)e.NewValue;
            }
        }

        private void TxtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TblContext.Visibility = string.IsNullOrEmpty(TxtInput.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //todo
        }
    }
}
