using Business;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semana_07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_click(object sender, RoutedEventArgs e)
        {
            ProductBusiness business = new ProductBusiness();
            dgProduct.ItemsSource = business.Get();
        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            ProductBusiness business = new ProductBusiness();
            string productName = txtProductName.Text;
            dgProductNombre.ItemsSource = business.GetByName(productName);
        }

    }
}