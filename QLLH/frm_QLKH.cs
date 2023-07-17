using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;

namespace QLLH
{
    public partial class frm_QLKH : Form
    {
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
            if(pageNumber==0)
            {
                return;
            }
            else
            for(int i =1;i<= pageNumber;i++)
            {
                cboPage.Items.Add(i + "");
            }    
            cboPage.SelectedIndex= 0;
        }
        databaseDataContext db = new databaseDataContext();
        public frm_QLKH()
        {
            InitializeComponent();
        }
        private void loadData_dgvDSKhoaHoc()
        {
            var dskh = db.tbl_KhoaHocs.ToList();
            //dgv_DsKhoaHoc.DataSource = dskh;
            //dgv_DsKhoaHoc.FirstDisplayedScrollingColumnIndex = dgv_DsKhoaHoc.ColumnCount - 1;
            btnFix.Enabled = false;
            btnDelete.Enabled = false;
            rows = dskh.ToList().Count;
            numPageSize.Value = pageSize;
            pageTotal();
        }
        private void frm_QLKH_Load(object sender, EventArgs e)
        { 
            loadData_dgvDSKhoaHoc();
            cboSearch.SelectedIndex = 0;
        }
        private void dgv_DsKhoaHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgv_DsKhoaHoc.Rows[e.RowIndex];
                txtId.Text = row.Cells["MaKhoaHoc"].Value.ToString();
                txtId.ReadOnly = true;
                txtLimitGV.Text = row.Cells["GioiHanGiangVien"].Value.ToString();
                txtLimitSV.Text = row.Cells["GioiHanSinhVien"].Value.ToString();
                txtLT.Text = row.Cells["SoBuoiLyThuyet"].Value.ToString();
                txtMoney.Text = row.Cells["KinhPhiDongGop"].Value.ToString();
                txtName.Text = row.Cells["TenKhoaHoc"].Value.ToString();
                txtTH.Text = row.Cells["SoBuoiThucHanh"].Value.ToString();
                txtTime.Text = row.Cells["ThoiGian"].Value.ToString();
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnFix.Enabled = true;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //xử lý thêm 
            try
            {
                //lấy dữ liệu từ các textbox
                if (txtId.Text != "" && txtName.Text != "")
                {
                    tbl_KhoaHoc newObj = new tbl_KhoaHoc();
                    newObj.MaKhoaHoc = txtId.Text;
                    newObj.TenKhoaHoc = txtName.Text;
                    newObj.ThoiGian = txtTime.Text;
                    newObj.GioiHanGiangVien = Convert.ToInt32(txtLimitGV.Text);
                    newObj.GioiHanSinhVien = Convert.ToInt32(txtLimitSV.Text);
                    newObj.KinhPhiDongGop = Convert.ToInt32(txtMoney.Text);
                    newObj.SoBuoiThucHanh = Convert.ToInt32(txtTH.Text);
                    newObj.SoBuoiLyThuyet = Convert.ToInt32(txtLT.Text);

                    db.tbl_KhoaHocs.InsertOnSubmit(newObj);
                    db.SubmitChanges();

                    MessageBox.Show("Thêm khóa học thành công");
                    loadData_dgvDSKhoaHoc();
                    btnClearData_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Không được để trông mã khóa học và tên khóa học");
                }

            }
            catch (Exception)
            {
                if(db.GetChangeSet().Inserts.Count>0)
                {
                    foreach(tbl_KhoaHoc item in db.GetChangeSet().Inserts)
                    {
                        db.tbl_KhoaHocs.DeleteOnSubmit(item);
                    }
                }

                MessageBox.Show("Thêm khóa học không thành công");
            }

            txtId.Text = txtLimitGV.Text=txtLimitSV.Text=txtLT.Text =txtMoney.Text =txtName.Text =txtTH.Text =txtTime.Text ="";
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            try
            {
                var mkh = txtId.Text;
                //code luu tru TT khoa hoc theo DL da edit
                tbl_KhoaHoc editObj = db.tbl_KhoaHocs.Where(o => o.MaKhoaHoc.Equals(mkh)).FirstOrDefault();
                editObj.MaKhoaHoc = txtId.Text;
                editObj.TenKhoaHoc = txtName.Text;
                editObj.ThoiGian = txtTime.Text;
                editObj.GioiHanGiangVien = Convert.ToInt32(txtLimitGV.Text);
                editObj.GioiHanSinhVien = Convert.ToInt32(txtLimitSV.Text);
                editObj.KinhPhiDongGop = Convert.ToInt32(txtMoney.Text);
                editObj.SoBuoiThucHanh = Convert.ToInt32(txtTH.Text);
                editObj.SoBuoiLyThuyet = Convert.ToInt32(txtLT.Text);
                MessageBox.Show("Sửa khóa học thành công");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sửa khóa học không thành công");
            }
            db.SubmitChanges();
            loadData_dgvDSKhoaHoc();

        }
       
        private void btnClearData_Click(object sender, EventArgs e)
        {
            txtId.ReadOnly = false;
            txtId.Text = string.Empty;
            txtLimitGV.Text = string.Empty;
            txtLimitSV.Text = string.Empty;
            txtLT.Text = string.Empty;
            txtMoney.Text = string.Empty;
            txtName.Text = string.Empty;
            txtTH.Text = string.Empty;
            txtTime.Text = string.Empty;

            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnFix.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var mkh = txtId.Text;
                tbl_KhoaHoc dellObj = db.tbl_KhoaHocs.Where(o => o.MaKhoaHoc.Equals(mkh)).FirstOrDefault();
                db.tbl_KhoaHocs.DeleteOnSubmit(dellObj);
                db.SubmitChanges();
                MessageBox.Show("Xóa khóa học thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa khóa học không thành công");
            }
            
            loadData_dgvDSKhoaHoc();
            btnClearData_Click(sender, e);

            
        }

        private void numPageSize_ValueChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(numPageSize.Value);
            pageTotal();
        }

        private void cboPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPageIndex = Convert.ToInt32(cboPage.Text);
            var dskh = db.tbl_KhoaHocs.Skip((currentPageIndex - 1) * pageSize).Take(pageSize).ToList();
            //dgv_DsKhoaHoc.DataSource = dskh;
            List<KhoaHoc_ett> listKhoaHocEtt = new List<KhoaHoc_ett>();
            for (int i = 0; i < dskh.Count; i++)
            {
                KhoaHoc_ett khoaHoc_ett = new KhoaHoc_ett(dskh[i]);
                // khoaHoc_ett.STT = i + 1;
                khoaHoc_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                listKhoaHocEtt.Add(khoaHoc_ett);
            }
            dgv_DsKhoaHoc.DataSource = listKhoaHocEtt;
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
            //var dskh = db.tbl_KhoaHocs.Skip((targetPageIndex - 1) * pageSize).Take(pageSize).ToList();
            //dgv_DsKhoaHoc.DataSource = dskh;
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
            //var dskh = db.tbl_KhoaHocs.Skip((targetPageIndex - 1) * pageSize).Take(pageSize).ToList();
            //dgv_DsKhoaHoc.DataSource = dskh;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToString();
            EnumSearchType searchType = (EnumSearchType)cboSearch.SelectedIndex;
            List<tbl_KhoaHoc> dskh = new List<tbl_KhoaHoc>();

            List<KhoaHoc_ett> listKhoaHocEtt = new List<KhoaHoc_ett>();


            switch (searchType)
            {
                case EnumSearchType.All:
                    dskh = db.tbl_KhoaHocs.ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        KhoaHoc_ett khoaHoc_ett = new KhoaHoc_ett(dskh[i]);
                        // khoaHoc_ett.STT = i + 1;
                        khoaHoc_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listKhoaHocEtt.Add(khoaHoc_ett);
                    }
                    dgv_DsKhoaHoc.DataSource = listKhoaHocEtt;
                    break;
                case EnumSearchType.Ma:
                    dskh = db.tbl_KhoaHocs.Where(o => o.MaKhoaHoc.Contains(keyword)).ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        KhoaHoc_ett khoaHoc_ett = new KhoaHoc_ett(dskh[i]);
                        // khoaHoc_ett.STT = i + 1;
                        khoaHoc_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listKhoaHocEtt.Add(khoaHoc_ett);
                    }
                    dgv_DsKhoaHoc.DataSource = listKhoaHocEtt;
                    break;
                case EnumSearchType.Ten:
                    dskh = db.tbl_KhoaHocs.Where(o => o.TenKhoaHoc.Contains(keyword)).ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        KhoaHoc_ett khoaHoc_ett = new KhoaHoc_ett(dskh[i]);
                        // khoaHoc_ett.STT = i + 1;
                        khoaHoc_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listKhoaHocEtt.Add(khoaHoc_ett);
                    }
                    dgv_DsKhoaHoc.DataSource = listKhoaHocEtt;
                    break;
                default:
                    break;

            }
        }

        private void dgv_DsKhoaHoc_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //xử lý sắp xếp theo toàn bộ DL

            //List<KhoaHoc_ett> crrData = (List<KhoaHoc_ett>)dgv_DsKhoaHoc.DataSource;

            List<tbl_KhoaHoc> dskh = db.tbl_KhoaHocs.ToList();
            List<KhoaHoc_ett> listKhoaHocEtt = new List<KhoaHoc_ett>();
            for (int i = 0; i < dskh.Count; i++)
            {
                KhoaHoc_ett khoaHoc_ett = new KhoaHoc_ett(dskh[i]);
                // khoaHoc_ett.STT = i + 1;
                khoaHoc_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                listKhoaHocEtt.Add(khoaHoc_ett);
            }

            List<KhoaHoc_ett> newData = new List<KhoaHoc_ett>();



            if (sortAscending)
            {
                newData = listKhoaHocEtt.OrderBy(dgv_DsKhoaHoc.Columns[e.ColumnIndex].DataPropertyName).ToList();
                for (int i = 0; i < newData.Count; i++)
                {
                    newData[i].STT = (currentPageIndex - 1) * pageSize + i + 1;
                }
            }
            else
            {
                newData = listKhoaHocEtt.OrderBy(dgv_DsKhoaHoc.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
                for (int i = 0; i < newData.Count; i++)
                {
                    newData[i].STT = (currentPageIndex - 1) * pageSize + i + 1;
                }
            }

            newData = newData.Skip((currentPageIndex - 1) * pageSize).Take(pageSize).ToList();
            dgv_DsKhoaHoc.DataSource = newData;
            sortAscending = !sortAscending;
        }
    }
}
