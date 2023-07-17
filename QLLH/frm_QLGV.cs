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
    public partial class frm_QLGV : Form
    {
        public frm_QLGV()
        {
            InitializeComponent();
        }
        int currentPageIndex = 1;
        int pageSize = 5;//Số dòng hiển thị trên 1 trang
        int pageNumber = 0;
        int rows;//tổng số bản ghi
        private bool sortAscending = false;

        void pageTotal()
        {
            pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
            lblTotalPage.Text = "/" + pageNumber.ToString();
            cboPage.Items.Clear();
            if (pageNumber == 0)
            {
                return;
            }
            else
                for (int i = 1; i <= pageNumber; i++)
                {
                    cboPage.Items.Add(i + "");
                }
            cboPage.SelectedIndex = 0;
        }
        databaseDataContext db = new databaseDataContext();

        private void loadData_dgvDsGiangVien()
        {
            var dskh = db.tbl_GiangViens.ToList();
            //dgv_DsKhoaHoc.DataSource = dskh;
            //dgv_DsKhoaHoc.FirstDisplayedScrollingColumnIndex = dgv_DsKhoaHoc.ColumnCount - 1;
            btnFix.Enabled = false;
            btnDelete.Enabled = false;
            rows = dskh.ToList().Count;
            numPageSize.Value = pageSize;
            pageTotal();
        }

        private void frm_QLGV_Load(object sender, EventArgs e)
        {
            loadData_dgvDsGiangVien();
            cboSearch.SelectedIndex = 0;
        }

        private void dgv_DsKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgv_DsGiangVien.Rows[e.RowIndex];
                txtId.Text = row.Cells["MaGV"].Value.ToString();
                txtId.ReadOnly = true;
                txtName.Text = row.Cells["HoTen"].Value.ToString();
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnFix.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy dữ liệu từ các textbox
                if (txtId.Text != "" && txtName.Text != "")
                {
                    tbl_GiangVien newObj = new tbl_GiangVien();
                    newObj.MaGV = txtId.Text;
                    newObj.HoTen = txtName.Text;
                    newObj.SDT = txtSDT.Text;
                    newObj.CCCD = txtCCCD.Text;
                    newObj.DiaChi = txtDiaChi.Text;
                   

                    db.tbl_GiangViens.InsertOnSubmit(newObj);
                    db.SubmitChanges();

                    MessageBox.Show("Thêm giảng viên thành công");
                    loadData_dgvDsGiangVien();
                    btnClearData_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Không được để trông mã giảng viên và tên giảng viên");
                }

            }
            catch (Exception)
            {
                if (db.GetChangeSet().Inserts.Count > 0)
                {
                    foreach (tbl_GiangVien item in db.GetChangeSet().Inserts)
                    {
                        db.tbl_GiangViens.DeleteOnSubmit(item);
                    }
                }

                MessageBox.Show("Thêm giảng viên không thành công");
            }

            txtId.Text = txtName.Text = txtSDT.Text = txtCCCD.Text = txtDiaChi.Text = "";
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            try
            {
                var mgv = txtId.Text;
                //code luu tru TT khoa hoc theo DL da edit
                tbl_GiangVien editObj = db.tbl_GiangViens.Where(o => o.MaGV.Equals(mgv)).FirstOrDefault();
                editObj.MaGV = txtId.Text;
                editObj.HoTen = txtName.Text;
                editObj.CCCD = txtCCCD.Text;
                editObj.SDT = txtSDT.Text;
                editObj.DiaChi = txtDiaChi.Text;
               
                MessageBox.Show("Sửa thông tin giảng viên thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thông tin giảng viên không thành công");
            }
            db.SubmitChanges();
            loadData_dgvDsGiangVien();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var mgv = txtId.Text;
                tbl_GiangVien dellObj = db.tbl_GiangViens.Where(o => o.MaGV.Equals(mgv)).FirstOrDefault();
                db.tbl_GiangViens.DeleteOnSubmit(dellObj);
                db.SubmitChanges();
                MessageBox.Show("Xóa giảng viên thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa giảng viên không thành công");
            }

            loadData_dgvDsGiangVien();
            btnClearData_Click(sender, e);
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            txtId.ReadOnly = false;
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
          
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnFix.Enabled = false;
        }

        private void numPageSize_ValueChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(numPageSize.Value);
            pageTotal();
        }

        private void cboPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPageIndex = Convert.ToInt32(cboPage.Text);
            var dskh = db.tbl_GiangViens.Skip((currentPageIndex - 1) * pageSize).Take(pageSize).ToList();
            //dgv_DsKhoaHoc.DataSource = dskh;
            List<GiangVien_ett> listGiangVienEtt = new List<GiangVien_ett>();
            for (int i = 0; i < dskh.Count; i++)
            {
                GiangVien_ett GiangVien_ett = new GiangVien_ett(dskh[i]);
                // khoaHoc_ett.STT = i + 1;
                GiangVien_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                listGiangVienEtt.Add(GiangVien_ett);
            }
            dgv_DsGiangVien.DataSource = listGiangVienEtt;
        }

        private void lblPrePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentPageIndex == 1)
            {
                MessageBox.Show("Đây là trang đầu tiên");
                return;
            }
            currentPageIndex = Convert.ToInt32(cboPage.Text);
            int targetPageIndex = currentPageIndex - 1;
            cboPage.Text = targetPageIndex.ToString();
        }

        private void lblNextPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentPageIndex == pageNumber)
            {
                MessageBox.Show("Đây là trang cuối cùng");
                return;
            }
            currentPageIndex = Convert.ToInt32(cboPage.Text);
            int targetPageIndex = currentPageIndex + 1;
            cboPage.Text = targetPageIndex.ToString();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToString();
            EnumSearchType searchType = (EnumSearchType)cboSearch.SelectedIndex;
            List<tbl_GiangVien> dskh = new List<tbl_GiangVien>();

            List<GiangVien_ett> listGiangVienEtt = new List<GiangVien_ett>();


            switch (searchType)
            {
                case EnumSearchType.All:
                    dskh = db.tbl_GiangViens.ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        GiangVien_ett GiangVien_ett = new GiangVien_ett(dskh[i]);
                        // khoaHoc_ett.STT = i + 1;
                        GiangVien_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listGiangVienEtt.Add(GiangVien_ett);
                    }
                    dgv_DsGiangVien.DataSource = listGiangVienEtt;
                    break;
                case EnumSearchType.Ma:
                    dskh = db.tbl_GiangViens.Where(o => o.MaGV.Contains(keyword)).ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        GiangVien_ett GiangVien_ett = new GiangVien_ett(dskh[i]);
                        // khoaHoc_ett.STT = i + 1;
                        GiangVien_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listGiangVienEtt.Add(GiangVien_ett);
                    }
                    dgv_DsGiangVien.DataSource = listGiangVienEtt;
                    break;
                case EnumSearchType.Ten:
                    dskh = db.tbl_GiangViens.Where(o => o.HoTen.Contains(keyword)).ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        GiangVien_ett GiangVien_ett = new GiangVien_ett(dskh[i]);
                        // GiangVien_ett.STT = i + 1;
                        GiangVien_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listGiangVienEtt.Add(GiangVien_ett);
                    }
                    dgv_DsGiangVien.DataSource = listGiangVienEtt;
                    break;
                default:
                    break;

            }
        }
    }
}
