using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLLH
{
    internal class KhoaHoc_ett:tbl_KhoaHoc
    {
        public int STT { get; set; }

        public KhoaHoc_ett() 
        {
            
        }
        private void BindObject(tbl_KhoaHoc obj)
        {
            this.MaKhoaHoc = obj.MaKhoaHoc;
            this.TenKhoaHoc = obj.TenKhoaHoc;
            this.ThoiGian = obj.ThoiGian;
            this.GioiHanGiangVien = obj.GioiHanGiangVien;
            this.GioiHanSinhVien = obj.GioiHanSinhVien;
            this.KinhPhiDongGop = obj.KinhPhiDongGop;
            this.SoBuoiLyThuyet = obj.SoBuoiLyThuyet;
            this.SoBuoiThucHanh = obj.SoBuoiThucHanh;
        }

        public KhoaHoc_ett(tbl_KhoaHoc obj)
        {
            BindObject(obj);
        }
    }
}
