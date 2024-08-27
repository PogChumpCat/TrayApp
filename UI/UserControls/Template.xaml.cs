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
    /// Interaction logic for Template.xaml
    /// </summary>
    public partial class Template : UserControl
    {
        public Template()
        {

        }

        public Template(int number)
        {
            InitializeComponent();
            Number.Text = number.ToString();
        }

        public Grid GetAddon()
        {
            return addons;
        }
    }
}
