namespace QLLH
{
    partial class frm_QLLH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label9 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnClearData = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbFind = new System.Windows.Forms.GroupBox();
            this.grbTTSV = new System.Windows.Forms.GroupBox();
            this.dtpTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTimeStart = new System.Windows.Forms.DateTimePicker();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNextPage = new System.Windows.Forms.LinkLabel();
            this.lblPrePage = new System.Windows.Forms.LinkLabel();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.cboPage = new System.Windows.Forms.ComboBox();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.numPageSize = new System.Windows.Forms.NumericUpDown();
            this.dgv_DsLopHoc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbFind.SuspendLayout();
            this.grbTTSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DsLopHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(190, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(327, 38);
            this.label9.TabIndex = 3;
            this.label9.Text = "Danh Sách Lớp Học";
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.PaleGreen;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFind.Location = new System.Drawing.Point(284, 20);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(88, 28);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "Tìm Kiếm";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cboSearch
            // 
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Items.AddRange(new object[] {
            "Tìm kiếm theo",
            "Mã",
            "Tên"});
            this.cboSearch.Location = new System.Drawing.Point(118, 22);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(161, 24);
            this.cboSearch.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(10, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnClearData
            // 
            this.btnClearData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearData.BackColor = System.Drawing.Color.PaleGreen;
            this.btnClearData.FlatAppearance.BorderSize = 0;
            this.btnClearData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearData.Location = new System.Drawing.Point(254, 416);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(88, 40);
            this.btnClearData.TabIndex = 12;
            this.btnClearData.Text = "Làm mới";
            this.btnClearData.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.PaleGreen;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDelete.Location = new System.Drawing.Point(43, 416);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 40);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnFix
            // 
            this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFix.BackColor = System.Drawing.Color.PaleGreen;
            this.btnFix.FlatAppearance.BorderSize = 0;
            this.btnFix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFix.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFix.Location = new System.Drawing.Point(254, 352);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(88, 44);
            this.btnFix.TabIndex = 10;
            this.btnFix.Text = "Sửa";
            this.btnFix.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdd.Location = new System.Drawing.Point(43, 352);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 44);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbFind);
            this.splitContainer1.Panel1.Controls.Add(this.grbTTSV);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.lblNextPage);
            this.splitContainer1.Panel2.Controls.Add(this.lblPrePage);
            this.splitContainer1.Panel2.Controls.Add(this.lblTotalPage);
            this.splitContainer1.Panel2.Controls.Add(this.lblPage);
            this.splitContainer1.Panel2.Controls.Add(this.cboPage);
            this.splitContainer1.Panel2.Controls.Add(this.lblPageSize);
            this.splitContainer1.Panel2.Controls.Add(this.numPageSize);
            this.splitContainer1.Panel2.Controls.Add(this.dgv_DsLopHoc);
            this.splitContainer1.Size = new System.Drawing.Size(1154, 626);
            this.splitContainer1.SplitterDistance = 404;
            this.splitContainer1.TabIndex = 2;
            // 
            // grbFind
            // 
            this.grbFind.Controls.Add(this.cboSearch);
            this.grbFind.Controls.Add(this.txtSearch);
            this.grbFind.Controls.Add(this.btnFind);
            this.grbFind.Location = new System.Drawing.Point(13, 30);
            this.grbFind.Name = "grbFind";
            this.grbFind.Size = new System.Drawing.Size(378, 73);
            this.grbFind.TabIndex = 16;
            this.grbFind.TabStop = false;
            this.grbFind.Text = "Tìm kiếm";
            // 
            // grbTTSV
            // 
            this.grbTTSV.Controls.Add(this.dtpTimeEnd);
            this.grbTTSV.Controls.Add(this.label5);
            this.grbTTSV.Controls.Add(this.dtpTimeStart);
            this.grbTTSV.Controls.Add(this.btnClearData);
            this.grbTTSV.Controls.Add(this.btnDelete);
            this.grbTTSV.Controls.Add(this.btnFix);
            this.grbTTSV.Controls.Add(this.btnAdd);
            this.grbTTSV.Controls.Add(this.txtMaKH);
            this.grbTTSV.Controls.Add(this.label7);
            this.grbTTSV.Controls.Add(this.label4);
            this.grbTTSV.Controls.Add(this.txtName);
            this.grbTTSV.Controls.Add(this.label2);
            this.grbTTSV.Controls.Add(this.txtId);
            this.grbTTSV.Controls.Add(this.label1);
            this.grbTTSV.Location = new System.Drawing.Point(13, 120);
            this.grbTTSV.Name = "grbTTSV";
            this.grbTTSV.Size = new System.Drawing.Size(378, 481);
            this.grbTTSV.TabIndex = 15;
            this.grbTTSV.TabStop = false;
            this.grbTTSV.Text = "Thông tin lớp học";
            // 
            // dtpTimeEnd
            // 
            this.dtpTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTimeEnd.Location = new System.Drawing.Point(115, 216);
            this.dtpTimeEnd.Name = "dtpTimeEnd";
            this.dtpTimeEnd.Size = new System.Drawing.Size(250, 22);
            this.dtpTimeEnd.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Time kết thúc";
            // 
            // dtpTimeStart
            // 
            this.dtpTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTimeStart.Location = new System.Drawing.Point(115, 160);
            this.dtpTimeStart.Name = "dtpTimeStart";
            this.dtpTimeStart.Size = new System.Drawing.Size(250, 22);
            this.dtpTimeStart.TabIndex = 13;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaKH.Location = new System.Drawing.Point(115, 279);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(252, 22);
            this.txtMaKH.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã khóa học";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Time bắt đầu";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(115, 104);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(252, 22);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên lớp học";
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(115, 50);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(252, 22);
            this.txtId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã lớp học";
            // 
            // lblNextPage
            // 
            this.lblNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextPage.AutoSize = true;
            this.lblNextPage.Location = new System.Drawing.Point(676, 585);
            this.lblNextPage.Name = "lblNextPage";
            this.lblNextPage.Size = new System.Drawing.Size(21, 16);
            this.lblNextPage.TabIndex = 0;
            this.lblNextPage.TabStop = true;
            this.lblNextPage.Text = ">>";
            this.lblNextPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNextPage_LinkClicked);
            // 
            // lblPrePage
            // 
            this.lblPrePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrePage.AutoSize = true;
            this.lblPrePage.LinkColor = System.Drawing.Color.Blue;
            this.lblPrePage.Location = new System.Drawing.Point(488, 584);
            this.lblPrePage.Name = "lblPrePage";
            this.lblPrePage.Size = new System.Drawing.Size(21, 16);
            this.lblPrePage.TabIndex = 0;
            this.lblPrePage.TabStop = true;
            this.lblPrePage.Text = "<<";
            this.lblPrePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPrePage_LinkClicked);
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Location = new System.Drawing.Point(625, 585);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(42, 16);
            this.lblTotalPage.TabIndex = 0;
            this.lblTotalPage.Text = "/Total";
            // 
            // lblPage
            // 
            this.lblPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(522, 585);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(40, 16);
            this.lblPage.TabIndex = 0;
            this.lblPage.Text = "Page";
            // 
            // cboPage
            // 
            this.cboPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboPage.FormattingEnabled = true;
            this.cboPage.Location = new System.Drawing.Point(567, 581);
            this.cboPage.Name = "cboPage";
            this.cboPage.Size = new System.Drawing.Size(52, 24);
            this.cboPage.TabIndex = 0;
            this.cboPage.SelectedIndexChanged += new System.EventHandler(this.cboPage_SelectedIndexChanged);
            // 
            // lblPageSize
            // 
            this.lblPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(33, 585);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(114, 16);
            this.lblPageSize.TabIndex = 0;
            this.lblPageSize.Text = "Số bản ghi 1 trang";
            // 
            // numPageSize
            // 
            this.numPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numPageSize.Location = new System.Drawing.Point(178, 583);
            this.numPageSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPageSize.Name = "numPageSize";
            this.numPageSize.Size = new System.Drawing.Size(61, 22);
            this.numPageSize.TabIndex = 0;
            this.numPageSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPageSize.ValueChanged += new System.EventHandler(this.numPageSize_ValueChanged);
            // 
            // dgv_DsLopHoc
            // 
            this.dgv_DsLopHoc.AllowUserToAddRows = false;
            this.dgv_DsLopHoc.AllowUserToDeleteRows = false;
            this.dgv_DsLopHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_DsLopHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DsLopHoc.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_DsLopHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DsLopHoc.Location = new System.Drawing.Point(3, 48);
            this.dgv_DsLopHoc.Name = "dgv_DsLopHoc";
            this.dgv_DsLopHoc.RowHeadersWidth = 51;
            this.dgv_DsLopHoc.RowTemplate.Height = 24;
            this.dgv_DsLopHoc.Size = new System.Drawing.Size(732, 513);
            this.dgv_DsLopHoc.TabIndex = 0;
            this.dgv_DsLopHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DsLopHoc_CellClick);
            // 
            // frm_QLLH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1166, 637);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_QLLH";
            this.Text = "frm_QLLH";
            this.Load += new System.EventHandler(this.frm_QLLH_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbFind.ResumeLayout(false);
            this.grbFind.PerformLayout();
            this.grbTTSV.ResumeLayout(false);
            this.grbTTSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DsLopHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DateTimePicker dtpTimeStart;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblNextPage;
        private System.Windows.Forms.LinkLabel lblPrePage;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.ComboBox cboPage;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.NumericUpDown numPageSize;
        private System.Windows.Forms.DataGridView dgv_DsLopHoc;
        private System.Windows.Forms.GroupBox grbFind;
        private System.Windows.Forms.GroupBox grbTTSV;
        private System.Windows.Forms.DateTimePicker dtpTimeEnd;
        private System.Windows.Forms.Label label5;
    }
}