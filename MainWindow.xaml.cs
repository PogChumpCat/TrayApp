using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TrayApp.Code.Classes;
using TrayApp.UI.UserControls;

namespace TrayApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int amount = 1;  
        ScrollManager scrollManager;

        public MainWindow()
        {
            InitializeComponent();

            scrollManager = new ScrollManager(this);
            scrollManager.AddNewElement();
        }

        public MainWindow(int amount)
        {

        }

        private void MainScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            VerticalScrollBar.Value = MainScrollViewer.VerticalOffset;
        }

        private void VerticalScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainScrollViewer.ScrollToVerticalOffset(e.NewValue);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            scrollManager.AddNewElement();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            scrollManager.RemoveElement();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //todo
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to load previous setings?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LinkDesigner.ConfigLoader(scrollManager);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LinkDesigner.ConfigSaver(scrollManager);
            }
        }
    }

}
