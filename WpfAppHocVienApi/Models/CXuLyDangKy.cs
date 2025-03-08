using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebAppHocVienApi.MyModels;

namespace WpfAppHocVienApi.Models
{
     class CXuLyDangKy
    {
        private static string strUrl = @"https://localhost:7292/api/DangKy";
        public static List<CHocvien> getDSHV()
        {
            
            try
            {
                HttpClient hc = new HttpClient();
                var res = hc.GetFromJsonAsync<List<CHocvien>>(strUrl);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static List<CHocvien> getDSHVDKMH(string mamh)
        {

            try
            {
                string url = strUrl+@"/"+mamh;
                HttpClient hc = new HttpClient();
                var res = hc.GetFromJsonAsync<List<CHocvien>>(url);
                res.Wait();
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static bool huyDangKy(string mshv, string msmh)
        {
            try
            {
                string url =strUrl+$"/huyDangKy?mshv={mshv}&msmh={msmh}";
                HttpClient hc = new HttpClient();
                var res = hc.DeleteAsync(url);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    }
}
