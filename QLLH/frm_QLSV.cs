using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLH
{
    public partial class frm_QLSV : Form
    {
        int currentPageIndex = 1;
        int pageSize = 5;//Số dòng hiển thị trên 1 trang
        int pageNumber = 0;
        int rows;//tổng số bản ghi
        private bool sortAscending = false;
        public frm_QLSV()
        {
            InitializeComponent();
        }
        databaseDataContext db = new databaseDataContext();

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

        private void loadData_dgvDSSinhVien()
        {
            var dskh = db.tbl_SinhViens.ToList();
            //dgv_DsSinhVien.DataSource = dskh;
            //dgv_DsSinhVien.FirstDisplayedScrollingColumnIndex = dgv_DsSinhVien.ColumnCount - 1;
            btnFix.Enabled = false;
            btnDelete.Enabled = false;
            rows = dskh.ToList().Count;
            numPageSize.Value = pageSize;
            pageTotal();
        }
        private void frm_QLSV_Load(object sender, EventArgs e)
        {
            loadData_dgvDSSinhVien();           
            cboSearch.SelectedIndex = 0;
        }

        private void dgv_DsSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgv_DsSinhVien.Rows[e.RowIndex];
                txtId.Text = row.Cells["MSSV"].Value.ToString();
                txtId.ReadOnly = true;
                txtName.Text = row.Cells["HoTen"].Value.ToString();
                txtLopQL.Text = row.Cells["LopQL"].Value.ToString();
                dtpDate.Text = row.Cells["NgaySinh"].Value.ToString();
                if (Convert.ToString(row.Cells["GioiTinh"].Value) == "Nữ")
                {
                    cboGioiTinh.SelectedIndex = 0;
                }
                else if (Convert.ToString(row.Cells["GioiTinh"].Value) == "Nam")
                {
                    cboGioiTinh.SelectedIndex = 1;
                }
                txtSDT.Text = row.Cells["SDT"].Value.ToString();
                txtMail.Text = row.Cells["Email"].Value.ToString();
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
                    tbl_SinhVien newObj = new tbl_SinhVien();
                    newObj.MSSV = txtId.Text;
                    newObj.HoTen = txtName.Text;
                    newObj.LopQL = txtLopQL.Text;
                    newObj.NgaySinh  = dtpDate.Value;
                    if(cboGioiTinh.SelectedIndex.ToString()=="0")
                    {
                        newObj.GioiTinh = false;
                    }
                    else if(cboGioiTinh.SelectedIndex.ToString() == "1")
                    {
                        newObj.GioiTinh = true;

                    }
                    newObj.SDT = txtSDT.Text;
                    newObj.Email = txtMail.Text;

                    db.tbl_SinhViens.InsertOnSubmit(newObj);
                    db.SubmitChanges();

                    MessageBox.Show("Thêm sinh viên thành công");
                    loadData_dgvDSSinhVien();
                    btnClearData_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Không được để trông mã sinh viên và tên sinh viên");
                }

            }
            catch (Exception)
            {
                if (db.GetChangeSet().Inserts.Count > 0)
                {
                    foreach (tbl_SinhVien item in db.GetChangeSet().Inserts)
                    {
                        db.tbl_SinhViens.DeleteOnSubmit(item);
                    }
                }

                MessageBox.Show("Thêm sinh viên không thành công");
            }

            txtId.Text = txtName.Text = txtLopQL.Text = dtpDate.Text = cboGioiTinh.Text = txtSDT.Text = txtMail.Text = "";
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            txtId.ReadOnly = false;
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtLopQL.Text = string.Empty;
            dtpDate.Text = string.Empty;
            cboGioiTinh.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtMail.Text = string.Empty;

            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnFix.Enabled = false;
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            try
            {
                var mssv = txtId.Text;
                //code luu tru TT khoa hoc theo DL da edit
                tbl_SinhVien editObj = db.tbl_SinhViens.Where(o => o.MSSV.Equals(mssv)).FirstOrDefault();
                editObj.MSSV = txtId.Text;
                editObj.HoTen = txtName.Text;
                editObj.LopQL = txtLopQL.Text;
                editObj.NgaySinh = dtpDate.Value;
                if (cboGioiTinh.SelectedIndex.ToString() == "0")
                {
                    editObj.GioiTinh = false;
                }
                else if (cboGioiTinh.SelectedIndex.ToString() == "1")
                {
                    editObj.GioiTinh = true;

                }
                editObj.SDT = txtSDT.Text;
                editObj.Email = txtMail.Text;
                MessageBox.Show("Sửa MSSV thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa MSSV không thành công");
            }
            db.SubmitChanges();
            loadData_dgvDSSinhVien();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var mssv = txtId.Text;
                tbl_SinhVien dellObj = db.tbl_SinhViens.Where(o => o.MSSV.Equals(mssv)).FirstOrDefault();
                db.tbl_SinhViens.DeleteOnSubmit(dellObj);
                db.SubmitChanges();
                MessageBox.Show("Xóa sinh viên thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sinh viên không thành công");
            }

            loadData_dgvDSSinhVien();
            btnClearData_Click(sender, e);
        }

        private void numPageSize_ValueChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(numPageSize.Value);
            pageTotal();
        }

        private void cboPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPageIndex = Convert.ToInt32( cboPage.Text);
            var dssv = db.tbl_SinhViens.Skip((currentPageIndex - 1) * pageSize).Take(pageSize).ToList();
            //dgv_DsSinhVien.DataSource = dskh;
            List<SinhVien_ett> listSinhVienEtt = new List<SinhVien_ett>();
            for(int i =0; i<dssv.Count;i++)
            {
                SinhVien_ett sinhVien_ett = new SinhVien_ett(dssv[i]);
                // sinhVien_ett.STT = i + 1;
                sinhVien_ett.STT = (currentPageIndex-1)*pageSize+i+1;
                listSinhVienEtt.Add(sinhVien_ett);
            }
            dgv_DsSinhVien.DataSource = listSinhVienEtt;
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
            List<tbl_SinhVien> dskh = new List<tbl_SinhVien>();

            List<SinhVien_ett> listSinhVienEtt = new List<SinhVien_ett>();


            switch (searchType)
            {
                case EnumSearchType.All:
                    dskh = db.tbl_SinhViens.ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        SinhVien_ett SinhVien_ett = new SinhVien_ett(dskh[i]);
                        // SinhVien_ett.STT = i + 1;
                        SinhVien_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listSinhVienEtt.Add(SinhVien_ett);
                    }
                    dgv_DsSinhVien.DataSource = listSinhVienEtt;
                    break;
                case EnumSearchType.Ma:
                    dskh = db.tbl_SinhViens.Where(o => o.MSSV.Contains(keyword)).ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        SinhVien_ett SinhVien_ett = new SinhVien_ett(dskh[i]);
                        // khoaHoc_ett.STT = i + 1;
                        SinhVien_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listSinhVienEtt.Add(SinhVien_ett);
                    }
                    dgv_DsSinhVien.DataSource = listSinhVienEtt;
                    break;
                case EnumSearchType.Ten:
                    dskh = db.tbl_SinhViens.Where(o => o.HoTen.Contains(keyword)).ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        SinhVien_ett SinhVien_ett = new SinhVien_ett(dskh[i]);
                        // SinhVien_ett.STT = i + 1;
                        SinhVien_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listSinhVienEtt.Add(SinhVien_ett);
                    }
                    dgv_DsSinhVien.DataSource = listSinhVienEtt;
                    break;
                default:
                    break;

            }
        }

        private void dgv_DsSinhVien_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
