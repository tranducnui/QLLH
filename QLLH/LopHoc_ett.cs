using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLH
{
    internal class LopHoc_ett:tbl_LopHoc
    {
        public LopHoc_ett()
        {

        }
        public int STT { get; set; }

        private void BindObject(tbl_LopHoc obj)
        {
            this.MaLH = obj.MaLH;
            this.TenLH = obj.TenLH;
            this.ThoiGianBatDau = obj.ThoiGianBatDau;
            this.ThoiGianKetThuc = obj.ThoiGianKetThuc;
            this.MaKhoaHoc = obj.MaKhoaHoc;
            
        }

        public LopHoc_ett(tbl_LopHoc obj)
        {
            BindObject(obj);
        }
    }
}
