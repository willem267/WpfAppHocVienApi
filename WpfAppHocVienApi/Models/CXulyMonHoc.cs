using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq.Expressions;
namespace WpfAppHocVienApi.Models
{
    class CXulyMonHoc
    {
        private static string strUrl = @"https://localhost:7292/api/MonHoc";

        public static List<CMonhoc> getDSMonHOc()
        {
            try
            {
                HttpClient hc = new HttpClient();
                var res = hc.GetFromJsonAsync<List<CMonhoc>>(strUrl);
                res.Wait();
                if (res.IsCompletedSuccessfully == false)
                    return null;
                return res.Result;
            }
            catch
            {
                return null;
            }
        }
        public static bool xoaMonHoc(string mamh)
        {
            try
            {
                HttpClient hc = new HttpClient();
                string url = strUrl + @"/" + mamh;
                var res = hc.DeleteAsync(url);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public static bool themMonHoc(CMonhoc mh)
        {
            try
            {
                HttpClient hc = new HttpClient();
               
                var res = hc.PostAsJsonAsync<CMonhoc>(strUrl, mh);
                res.Wait();
                return res.Result.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public static bool suaMonHoc(CMonhoc mh)
        {
            try
            {
                HttpClient hc = new HttpClient();

                var res = hc.PutAsJsonAsync<CMonhoc>(strUrl, mh);
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
