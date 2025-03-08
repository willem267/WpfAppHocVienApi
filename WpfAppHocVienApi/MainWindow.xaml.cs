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
using WpfAppHocVienApi.UI;

namespace WpfAppHocVienApi
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

        private void MenuMonHoc_Click(object sender, RoutedEventArgs e)
        {
            WindowMonHoc f = new WindowMonHoc();
            f.Show();
               
        }

        private void dkMH_Click(object sender, RoutedEventArgs e)
        {
            WindowDKMH f = new WindowDKMH();
            f.Show();
        }
    }
}