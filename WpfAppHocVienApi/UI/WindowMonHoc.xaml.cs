using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppHocVienApi.Models;

namespace WpfAppHocVienApi.UI
{
    /// <summary>
    /// Interaction logic for WindowMonHoc.xaml
    /// </summary>
    public partial class WindowMonHoc : Window
    {
        public static RoutedUICommand lenhXoa = new RoutedUICommand();
        public static RoutedUICommand lenhThem = new RoutedUICommand();
        public static RoutedUICommand lenhSua = new RoutedUICommand();

        public WindowMonHoc()
        {
            InitializeComponent();
        }
        private void hienThi()
        {
            List<CMonhoc> list = CXulyMonHoc.getDSMonHOc();
            if (list == null)
                MessageBox.Show("éo có");
            else
                dgMonhoc.ItemsSource = list;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienThi();
        }

        private void xoa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (dgMonhoc is null || dgMonhoc.SelectedItem is null)
            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }

        private void xoa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CMonhoc x = dgMonhoc.SelectedItem as CMonhoc;
            if (CXulyMonHoc.xoaMonHoc(x.Msmh) == true)
                hienThi();
            else
                MessageBox.Show("Xóa éo được");
        }

        
        private void them_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            
            e.CanExecute = true;
        }

        private void them_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CMonhoc mh = gridMH.DataContext as CMonhoc;
            if (CXulyMonHoc.themMonHoc(mh) == true)
                hienThi();
            else
                MessageBox.Show("Thêm éo được");
        }

        private void sua_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void sua_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CMonhoc x = gridMH.DataContext as CMonhoc;
            if (CXulyMonHoc.suaMonHoc(x) == true)
                hienThi();
            else
                MessageBox.Show("Sửa éo được");
        }

        private void dgMonhoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            CMonhoc mh = dgMonhoc.SelectedItem as CMonhoc;
            if(mh == null)
            {
                return;
            }
            CMonhoc m = new CMonhoc
            {
                Msmh = mh.Msmh,
                Tenmh = mh.Tenmh,
                Sotiet = mh.Sotiet,
            };
            gridMH.DataContext = m;

        }
    }
}
