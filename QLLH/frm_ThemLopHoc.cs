using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLH
{
    public partial class frm_ThemLopHoc : Form
    {
        public frm_ThemLopHoc()
        {
            InitializeComponent();
        }

        databaseDataContext db = new databaseDataContext();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy dữ liệu từ các textbox
                if (txtId.Text != "" && txtName.Text != "")
                {
                    tbl_LopHoc newObj = new tbl_LopHoc();
                    newObj.MaLH = txtId.Text;
                    newObj.TenLH = txtName.Text;
                    newObj.ThoiGianBatDau = dtpTimeStart.Value;
                    newObj.ThoiGianKetThuc = dtpTimeEnd.Value;
                    newObj.MaKhoaHoc = txtIdKH.Text;

                    db.tbl_LopHocs.InsertOnSubmit(newObj);
                    db.SubmitChanges();

                    MessageBox.Show("Thêm lớp học thành công");
                    //loadData_dgvDSLopHoc();
                    //btnClearData_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Không được để trông mã lớp học và tên lớp học");
                }

            }
            catch (Exception)
            {
                if (db.GetChangeSet().Inserts.Count > 0)
                {
                    foreach (tbl_LopHoc item in db.GetChangeSet().Inserts)
                    {
                        db.tbl_LopHocs.DeleteOnSubmit(item);
                    }
                }

                MessageBox.Show("Thêm lớp học không thành công");
            }

            txtId.Text = txtName.Text = txtIdKH.Text =dtpTimeEnd.Text = dtpTimeStart.Text = "";
        }


    }
}
