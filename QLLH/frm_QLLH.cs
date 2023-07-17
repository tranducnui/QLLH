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
    public partial class frm_QLLH : Form
    {
        public frm_QLLH()
        {
            InitializeComponent();
        }

        databaseDataContext db = new databaseDataContext();

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
        private void loadData_dgvDsLopHoc()
        {
            var dslh = db.tbl_LopHocs.ToList();
            //dgv_DsKhoaHoc.DataSource = dskh;
            //dgv_DsKhoaHoc.FirstDisplayedScrollingColumnIndex = dgv_DsKhoaHoc.ColumnCount - 1;
            btnFix.Enabled = false;
            btnDelete.Enabled = false;
            rows = dslh.ToList().Count;
            numPageSize.Value = pageSize;
            pageTotal();
        }
        private void frm_QLLH_Load(object sender, EventArgs e)
        {
            loadData_dgvDsLopHoc();
            cboSearch.SelectedIndex = 0;
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            frm_ThemLopHoc f = new frm_ThemLopHoc();
            //lấy ra form Main
            FormCollection fc = Application.OpenForms;

            foreach(Form form in fc)
            {

                if(form.Name=="frm_Main")
                //lấy ra size của Main_pnl trong frm_Main, gán bằng size của frm_ThemLopHoc

                {
                    var mainPanel = form.Controls[0];
                    f.TopLevel = false;
                    f.Width= mainPanel.Width;
                    f.Height= mainPanel.Height;
                    mainPanel.Controls.Clear();
                    mainPanel.Controls.Add(f);
                    f.Show();
                    break;
                }
            }
        }

        private void dgv_DsLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgv_DsLopHoc.Rows[e.RowIndex];
                txtId.Text = row.Cells["MaLH"].Value.ToString();
                txtId.ReadOnly = true;
                txtName.Text = row.Cells["TenLH"].Value.ToString();
                dtpTimeStart.Text = row.Cells["ThoiGianBatDau"].Value.ToString();
                dtpTimeEnd.Text = row.Cells["ThoiGianKetThuc"].Value.ToString();
                txtMaKH.Text = row.Cells["MaKhoaHoc"].Value.ToString();
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnFix.Enabled = true;
            }
        }

        private void numPageSize_ValueChanged(object sender, EventArgs e)
        {
            pageSize = Convert.ToInt32(numPageSize.Value);
            pageTotal();
        }

        private void cboPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPageIndex = Convert.ToInt32(cboPage.Text);
            var dslh = db.tbl_LopHocs.Skip((currentPageIndex - 1) * pageSize).Take(pageSize).ToList();
            //dgv_DsKhoaHoc.DataSource = dskh;
            List<LopHoc_ett> listLopHocEtt = new List<LopHoc_ett>();
            for (int i = 0; i < dslh.Count; i++)
            {
                LopHoc_ett LopHoc_ett = new LopHoc_ett(dslh[i]);
                // LopHoc_ett.STT = i + 1;
                LopHoc_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                listLopHocEtt.Add(LopHoc_ett);
            }
            dgv_DsLopHoc.DataSource = listLopHocEtt;
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToString();
            EnumSearchType searchType = (EnumSearchType)cboSearch.SelectedIndex;
            List<tbl_LopHoc> dskh = new List<tbl_LopHoc>();

            List<LopHoc_ett> listLopHocEtt = new List<LopHoc_ett>();


            switch (searchType)
            {
                case EnumSearchType.All:
                    dskh = db.tbl_LopHocs.ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        LopHoc_ett LopHoc_ett = new LopHoc_ett(dskh[i]);
                        // LopHoc_ett.STT = i + 1;
                        LopHoc_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listLopHocEtt.Add(LopHoc_ett);
                    }
                    dgv_DsLopHoc.DataSource = listLopHocEtt;
                    break;
                case EnumSearchType.Ma:
                    dskh = db.tbl_LopHocs.Where(o => o.MaLH.Contains(keyword)).ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        LopHoc_ett LopHoc_ett = new LopHoc_ett(dskh[i]);
                        // LopHoc_ett.STT = i + 1;
                        LopHoc_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listLopHocEtt.Add(LopHoc_ett);
                    }
                    dgv_DsLopHoc.DataSource = listLopHocEtt;
                    break;
                case EnumSearchType.Ten:
                    dskh = db.tbl_LopHocs.Where(o => o.TenLH.Contains(keyword)).ToList();
                    for (int i = 0; i < dskh.Count; i++)
                    {
                        LopHoc_ett LopHoc_ett = new LopHoc_ett(dskh[i]);
                        // LopHoc_ett.STT = i + 1;
                        LopHoc_ett.STT = (currentPageIndex - 1) * pageSize + i + 1;
                        listLopHocEtt.Add(LopHoc_ett);
                    }
                    dgv_DsLopHoc.DataSource = listLopHocEtt;
                    break;
                default:
                    break;

            }
        }
    }
}
