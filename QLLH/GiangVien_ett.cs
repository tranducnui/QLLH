using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLH
{
    internal class GiangVien_ett:tbl_GiangVien
    {
        public int STT { get; set; }
        public string MaGV { get; set; }
        public string HoTen { get; set; }
        public string CCCD { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }


        public GiangVien_ett()
        {

        }
        private void BindObject(tbl_GiangVien obj)
        {
            this.MaGV = obj.MaGV;
            this.HoTen = obj.HoTen;
            this.CCCD = obj.CCCD;
            this.DiaChi = obj.DiaChi;
            
            this.SDT = obj.SDT;
        }

        public GiangVien_ett(tbl_GiangVien obj)
        {
            BindObject(obj);
        }
    }
}
