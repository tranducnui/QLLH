using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLH
{
    internal class SinhVien_ett:tbl_SinhVien
    {
        public int STT { get; set; }
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public string LopQL { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }

        public string Email { get; set; }

        public SinhVien_ett()
        {

        }
        private void BindObject(tbl_SinhVien obj)
        {
            this.MSSV = obj.MSSV;
            this.HoTen = obj.HoTen;
            this.LopQL = obj.LopQL;
            this.NgaySinh = obj.NgaySinh;
            switch(obj.GioiTinh)
            {
                case true:
                    this.GioiTinh = "Nam";
                    break;
                case false:
                    this.GioiTinh = "Nữ";
                    break;
            }
            this.SDT = obj.SDT;
            this.Email = obj.Email;
        }

        public SinhVien_ett(tbl_SinhVien obj)
        {
            BindObject(obj);
        }
    }
}
