namespace WebAppHocVienApi.MyModels
{
    public class CHocvien
    {
        public string Mshv { get; set; }
        public string? Tenhv { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public bool? Phai { get; set; }
        public string? Malop { get; set; }
        public string? Tenlop { get; set; }
        public string ngaySinhView
        {
            get
            { 
                return Ngaysinh.Value.ToShortDateString();
            }
        }
        public string phaiView
        {
            get
            {
                return(Phai==true?"Nam":"Nữ");
            }
        }
      
    }
}
