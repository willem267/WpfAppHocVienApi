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
using System.Windows.Shapes;
using WebAppHocVienApi.MyModels;
using WpfAppHocVienApi.Models;

namespace WpfAppHocVienApi.UI
{
    /// <summary>
    /// Interaction logic for WindowDKMH.xaml
    /// </summary>
    public partial class WindowDKMH : Window
    {
        public WindowDKMH()
        {
            InitializeComponent();
        }
        private void hienThi()
        {
            List<CHocvien> ds = CXuLyDangKy.getDSHVDKMH(cmbMSMH.SelectedValue.ToString());
            List<CHocvien> ds1 = CXuLyDangKy.getDSHV();
            if (ds == null || ds1 == null)
                MessageBox.Show("Ko có dữ liệu");

            else
            {
                List<CHocvien> dshv = new List<CHocvien>();
                foreach (CHocvien ch in ds1)
                {
                    if (ds.Count(t => t.Mshv == ch.Mshv) == 0)
                    {
                        dshv.Add(ch);
                    }
                }
                dgDKMH.ItemsSource = ds;
                cmbMSHV.ItemsSource = dshv;
            }
                
        }
        private void hienThiCmbMonHoc()
        {
            List<CMonhoc> ds =CXulyMonHoc.getDSMonHOc();
            if (ds != null)
            {
                cmbMSMH.ItemsSource= ds;

            }
            else {
                MessageBox.Show("ếu có");
            }

        }
        private void hienThiCmbHocVien()
        {
            List<CHocvien> ds = CXuLyDangKy.getDSHV() ;
            if (ds != null)
            {
                cmbMSHV.ItemsSource = ds;

            }
            else
            {
                MessageBox.Show("ếu có");
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienThiCmbMonHoc();
            hienThiCmbHocVien();
        }

        private void cmbMSMH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMSMH.SelectedItem == null) return;
            hienThi();

            
        }

        private void cmbMSHV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            CMonhoc x = cmbMSMH.SelectedItem as CMonhoc;
            CHocvien x1 = dgDKMH.SelectedItem as CHocvien;
            if(x!=null && x1!=null)
            {
                if (CXuLyDangKy.huyDangKy(x1.Mshv, x.Msmh))
                    hienThi();
                else
                    MessageBox.Show("Ko thể hủy");
                   
            }
        }
    }
}
