namespace Airplace2025.Forms
{
    using Guna.UI2.WinForms;
    using System.Windows.Forms;

    partial class frmDatVe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbSearch = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.dtpNgayDi = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbSanBayDen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSanBayDi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvChuyenBay = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabHanhKhach = new System.Windows.Forms.TabPage();
            this.dgvHanhKhach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.gbGhe = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnThemHanhKhach = new Guna.UI2.WinForms.Guna2Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaGhe = new Guna.UI2.WinForms.Guna2TextBox();
            this.gbThongTin = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbLoaiKH = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiaChiKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmailKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSdtKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCCCDKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGioiTinhKH = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgaySinhKH = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTenKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.gbTimKH = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnTimKH = new Guna.UI2.WinForms.Guna2Button();
            this.txtTimKiemKH = new Guna.UI2.WinForms.Guna2TextBox();
            this.tabThanhToan = new System.Windows.Forms.TabPage();
            this.gbThanhToanInfo = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNoiDungPhuThu = new Guna.UI2.WinForms.Guna2TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPhuThu = new Guna.UI2.WinForms.Guna2TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbPhuongThucTT = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gbThongTinChung = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblSoLuongVe = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblGiaVeChon = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblHangVeChon = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblChuyenBayChon = new System.Windows.Forms.Label();
            this.btnGiuCho = new Guna.UI2.WinForms.Guna2Button();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenBay)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabHanhKhach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanhKhach)).BeginInit();
            this.gbGhe.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.gbTimKH.SuspendLayout();
            this.tabThanhToan.SuspendLayout();
            this.gbThanhToanInfo.SuspendLayout();
            this.gbThongTinChung.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbSearch.BorderRadius = 8;
            this.gbSearch.Controls.Add(this.btnTimKiem);
            this.gbSearch.Controls.Add(this.dtpNgayDi);
            this.gbSearch.Controls.Add(this.cbSanBayDen);
            this.gbSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbSearch.Location = new System.Drawing.Point(10, 10);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1180, 80);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.Text = "Tìm kiếm chuyến bay";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BorderRadius = 6;
            this.btnTimKiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(640, 41);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 36);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            // 
            // dtpNgayDi
            // 
            this.dtpNgayDi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dtpNgayDi.BorderRadius = 6;
            this.dtpNgayDi.Checked = true;
            this.dtpNgayDi.FillColor = System.Drawing.Color.White;
            this.dtpNgayDi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDi.Location = new System.Drawing.Point(430, 41);
            this.dtpNgayDi.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayDi.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayDi.Name = "dtpNgayDi";
            this.dtpNgayDi.Size = new System.Drawing.Size(200, 36);
            this.dtpNgayDi.TabIndex = 1;
            this.dtpNgayDi.Value = new System.DateTime(2025, 10, 22, 19, 43, 41, 99);
            // 
            // cbSanBayDen
            // 
            this.cbSanBayDen.BackColor = System.Drawing.Color.Transparent;
            this.cbSanBayDen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbSanBayDen.BorderRadius = 6;
            this.cbSanBayDen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSanBayDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSanBayDen.FocusedColor = System.Drawing.Color.Empty;
            this.cbSanBayDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbSanBayDen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSanBayDen.ItemHeight = 30;
            this.cbSanBayDen.Location = new System.Drawing.Point(220, 41);
            this.cbSanBayDen.Name = "cbSanBayDen";
            this.cbSanBayDen.Size = new System.Drawing.Size(200, 36);
            this.cbSanBayDen.TabIndex = 1;
            // 
            // cbSanBayDi
            // 
            this.cbSanBayDi.BackColor = System.Drawing.Color.Transparent;
            this.cbSanBayDi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbSanBayDi.BorderRadius = 6;
            this.cbSanBayDi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSanBayDi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSanBayDi.FocusedColor = System.Drawing.Color.Empty;
            this.cbSanBayDi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbSanBayDi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSanBayDi.ItemHeight = 30;
            this.cbSanBayDi.Location = new System.Drawing.Point(12, 51);
            this.cbSanBayDi.Name = "cbSanBayDi";
            this.cbSanBayDi.Size = new System.Drawing.Size(200, 36);
            this.cbSanBayDi.TabIndex = 0;
            // 
            // dgvChuyenBay
            // 
            this.dgvChuyenBay.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvChuyenBay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChuyenBay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChuyenBay.ColumnHeadersHeight = 4;
            this.dgvChuyenBay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChuyenBay.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChuyenBay.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvChuyenBay.Location = new System.Drawing.Point(10, 96);
            this.dgvChuyenBay.Name = "dgvChuyenBay";
            this.dgvChuyenBay.RowHeadersVisible = false;
            this.dgvChuyenBay.Size = new System.Drawing.Size(1180, 150);
            this.dgvChuyenBay.TabIndex = 1;
            this.dgvChuyenBay.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChuyenBay.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvChuyenBay.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvChuyenBay.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvChuyenBay.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvChuyenBay.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChuyenBay.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvChuyenBay.ThemeStyle.ReadOnly = false;
            this.dgvChuyenBay.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChuyenBay.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChuyenBay.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvChuyenBay.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChuyenBay.ThemeStyle.RowsStyle.Height = 22;
            this.dgvChuyenBay.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChuyenBay.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabHanhKhach);
            this.tabControl1.Controls.Add(this.tabThanhToan);
            this.tabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControl1.Location = new System.Drawing.Point(10, 251);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1180, 460);
            this.tabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            // 
            // tabHanhKhach
            // 
            this.tabHanhKhach.BackColor = System.Drawing.Color.White;
            this.tabHanhKhach.Controls.Add(this.dgvHanhKhach);
            this.tabHanhKhach.Controls.Add(this.gbGhe);
            this.tabHanhKhach.Controls.Add(this.gbThongTin);
            this.tabHanhKhach.Controls.Add(this.gbTimKH);
            this.tabHanhKhach.Location = new System.Drawing.Point(184, 4);
            this.tabHanhKhach.Name = "tabHanhKhach";
            this.tabHanhKhach.Padding = new System.Windows.Forms.Padding(10);
            this.tabHanhKhach.Size = new System.Drawing.Size(992, 452);
            this.tabHanhKhach.TabIndex = 0;
            this.tabHanhKhach.Text = "Thông tin hành khách";
            // 
            // dgvHanhKhach
            // 
            this.dgvHanhKhach.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvHanhKhach.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHanhKhach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHanhKhach.ColumnHeadersHeight = 4;
            this.dgvHanhKhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHanhKhach.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHanhKhach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvHanhKhach.Location = new System.Drawing.Point(10, 313);
            this.dgvHanhKhach.Name = "dgvHanhKhach";
            this.dgvHanhKhach.RowHeadersVisible = false;
            this.dgvHanhKhach.Size = new System.Drawing.Size(972, 126);
            this.dgvHanhKhach.TabIndex = 3;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHanhKhach.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHanhKhach.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvHanhKhach.ThemeStyle.ReadOnly = false;
            this.dgvHanhKhach.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHanhKhach.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHanhKhach.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvHanhKhach.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHanhKhach.ThemeStyle.RowsStyle.Height = 22;
            this.dgvHanhKhach.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHanhKhach.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // gbGhe
            // 
            this.gbGhe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbGhe.BorderRadius = 8;
            this.gbGhe.Controls.Add(this.btnThemHanhKhach);
            this.gbGhe.Controls.Add(this.label10);
            this.gbGhe.Controls.Add(this.txtMaGhe);
            this.gbGhe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbGhe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbGhe.Location = new System.Drawing.Point(10, 237);
            this.gbGhe.Name = "gbGhe";
            this.gbGhe.Size = new System.Drawing.Size(979, 70);
            this.gbGhe.TabIndex = 2;
            this.gbGhe.Text = "Chi tiết vé";
            // 
            // btnThemHanhKhach
            // 
            this.btnThemHanhKhach.BorderRadius = 6;
            this.btnThemHanhKhach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemHanhKhach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemHanhKhach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemHanhKhach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemHanhKhach.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnThemHanhKhach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThemHanhKhach.ForeColor = System.Drawing.Color.White;
            this.btnThemHanhKhach.Location = new System.Drawing.Point(167, 41);
            this.btnThemHanhKhach.Name = "btnThemHanhKhach";
            this.btnThemHanhKhach.Size = new System.Drawing.Size(142, 25);
            this.btnThemHanhKhach.TabIndex = 18;
            this.btnThemHanhKhach.Text = "Thêm vào danh sách";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Mã ghế";
            // 
            // txtMaGhe
            // 
            this.txtMaGhe.BorderRadius = 6;
            this.txtMaGhe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaGhe.DefaultText = "";
            this.txtMaGhe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaGhe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaGhe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaGhe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaGhe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaGhe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaGhe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaGhe.Location = new System.Drawing.Point(59, 41);
            this.txtMaGhe.Name = "txtMaGhe";
            this.txtMaGhe.PlaceholderText = "Mã ghế";
            this.txtMaGhe.SelectedText = "";
            this.txtMaGhe.Size = new System.Drawing.Size(100, 25);
            this.txtMaGhe.TabIndex = 0;
            // 
            // gbThongTin
            // 
            this.gbThongTin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbThongTin.BorderRadius = 8;
            this.gbThongTin.Controls.Add(this.cbLoaiKH);
            this.gbThongTin.Controls.Add(this.label9);
            this.gbThongTin.Controls.Add(this.txtDiaChiKH);
            this.gbThongTin.Controls.Add(this.label8);
            this.gbThongTin.Controls.Add(this.txtEmailKH);
            this.gbThongTin.Controls.Add(this.label7);
            this.gbThongTin.Controls.Add(this.txtSdtKH);
            this.gbThongTin.Controls.Add(this.label6);
            this.gbThongTin.Controls.Add(this.txtCCCDKH);
            this.gbThongTin.Controls.Add(this.label5);
            this.gbThongTin.Controls.Add(this.cbGioiTinhKH);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.dtpNgaySinhKH);
            this.gbThongTin.Controls.Add(this.label3);
            this.gbThongTin.Controls.Add(this.txtHoTenKH);
            this.gbThongTin.Controls.Add(this.label2);
            this.gbThongTin.Controls.Add(this.label1);
            this.gbThongTin.Controls.Add(this.txtMaKH);
            this.gbThongTin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbThongTin.Location = new System.Drawing.Point(10, 82);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(979, 150);
            this.gbThongTin.TabIndex = 1;
            this.gbThongTin.Text = "Thông tin chi tiết hành khách";
            // 
            // cbLoaiKH
            // 
            this.cbLoaiKH.BackColor = System.Drawing.Color.Transparent;
            this.cbLoaiKH.BorderRadius = 6;
            this.cbLoaiKH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoaiKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiKH.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLoaiKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbLoaiKH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbLoaiKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbLoaiKH.ItemHeight = 30;
            this.cbLoaiKH.Location = new System.Drawing.Point(276, 111);
            this.cbLoaiKH.Name = "cbLoaiKH";
            this.cbLoaiKH.Size = new System.Drawing.Size(100, 36);
            this.cbLoaiKH.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Loại KH:";
            // 
            // txtDiaChiKH
            // 
            this.txtDiaChiKH.BorderRadius = 6;
            this.txtDiaChiKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiaChiKH.DefaultText = "";
            this.txtDiaChiKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiaChiKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiaChiKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiaChiKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiaChiKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiaChiKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiaChiKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiaChiKH.Location = new System.Drawing.Point(822, 79);
            this.txtDiaChiKH.Name = "txtDiaChiKH";
            this.txtDiaChiKH.PlaceholderText = "Địa chỉ";
            this.txtDiaChiKH.SelectedText = "";
            this.txtDiaChiKH.Size = new System.Drawing.Size(150, 25);
            this.txtDiaChiKH.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(774, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Địa chỉ:";
            // 
            // txtEmailKH
            // 
            this.txtEmailKH.BorderRadius = 6;
            this.txtEmailKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmailKH.DefaultText = "";
            this.txtEmailKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmailKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmailKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmailKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmailKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmailKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmailKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmailKH.Location = new System.Drawing.Point(552, 78);
            this.txtEmailKH.Name = "txtEmailKH";
            this.txtEmailKH.PlaceholderText = "Email";
            this.txtEmailKH.SelectedText = "";
            this.txtEmailKH.Size = new System.Drawing.Size(150, 25);
            this.txtEmailKH.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(511, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email:";
            // 
            // txtSdtKH
            // 
            this.txtSdtKH.BorderRadius = 6;
            this.txtSdtKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSdtKH.DefaultText = "";
            this.txtSdtKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSdtKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSdtKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSdtKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSdtKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSdtKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSdtKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSdtKH.Location = new System.Drawing.Point(279, 77);
            this.txtSdtKH.Name = "txtSdtKH";
            this.txtSdtKH.PlaceholderText = "SĐT";
            this.txtSdtKH.SelectedText = "";
            this.txtSdtKH.Size = new System.Drawing.Size(150, 25);
            this.txtSdtKH.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "SĐT:";
            // 
            // txtCCCDKH
            // 
            this.txtCCCDKH.BorderRadius = 6;
            this.txtCCCDKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCCCDKH.DefaultText = "";
            this.txtCCCDKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCCCDKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCCCDKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCCCDKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCCCDKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCCCDKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCCCDKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCCCDKH.Location = new System.Drawing.Point(53, 77);
            this.txtCCCDKH.Name = "txtCCCDKH";
            this.txtCCCDKH.PlaceholderText = "CCCD";
            this.txtCCCDKH.SelectedText = "";
            this.txtCCCDKH.Size = new System.Drawing.Size(150, 25);
            this.txtCCCDKH.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "CCCD:";
            // 
            // cbGioiTinhKH
            // 
            this.cbGioiTinhKH.BackColor = System.Drawing.Color.Transparent;
            this.cbGioiTinhKH.BorderRadius = 6;
            this.cbGioiTinhKH.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGioiTinhKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGioiTinhKH.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGioiTinhKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGioiTinhKH.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbGioiTinhKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbGioiTinhKH.ItemHeight = 30;
            this.cbGioiTinhKH.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbGioiTinhKH.Location = new System.Drawing.Point(71, 111);
            this.cbGioiTinhKH.Name = "cbGioiTinhKH";
            this.cbGioiTinhKH.Size = new System.Drawing.Size(100, 36);
            this.cbGioiTinhKH.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giới tính:";
            // 
            // dtpNgaySinhKH
            // 
            this.dtpNgaySinhKH.BorderRadius = 6;
            this.dtpNgaySinhKH.Checked = true;
            this.dtpNgaySinhKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgaySinhKH.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinhKH.Location = new System.Drawing.Point(559, 45);
            this.dtpNgaySinhKH.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgaySinhKH.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgaySinhKH.Name = "dtpNgaySinhKH";
            this.dtpNgaySinhKH.Size = new System.Drawing.Size(150, 25);
            this.dtpNgaySinhKH.TabIndex = 5;
            this.dtpNgaySinhKH.Value = new System.DateTime(2025, 10, 22, 20, 27, 36, 497);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày sinh:";
            // 
            // txtHoTenKH
            // 
            this.txtHoTenKH.BorderRadius = 6;
            this.txtHoTenKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHoTenKH.DefaultText = "";
            this.txtHoTenKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHoTenKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHoTenKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTenKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHoTenKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTenKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHoTenKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtHoTenKH.Location = new System.Drawing.Point(270, 45);
            this.txtHoTenKH.Name = "txtHoTenKH";
            this.txtHoTenKH.PlaceholderText = "Họ tên";
            this.txtHoTenKH.ReadOnly = true;
            this.txtHoTenKH.SelectedText = "";
            this.txtHoTenKH.Size = new System.Drawing.Size(200, 25);
            this.txtHoTenKH.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã KH:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.BorderRadius = 6;
            this.txtMaKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaKH.DefaultText = "";
            this.txtMaKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKH.Location = new System.Drawing.Point(57, 45);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.PlaceholderText = "";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.SelectedText = "";
            this.txtMaKH.Size = new System.Drawing.Size(150, 25);
            this.txtMaKH.TabIndex = 0;
            // 
            // gbTimKH
            // 
            this.gbTimKH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbTimKH.BorderRadius = 8;
            this.gbTimKH.Controls.Add(this.btnTimKH);
            this.gbTimKH.Controls.Add(this.txtTimKiemKH);
            this.gbTimKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbTimKH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbTimKH.Location = new System.Drawing.Point(10, 3);
            this.gbTimKH.Name = "gbTimKH";
            this.gbTimKH.Size = new System.Drawing.Size(979, 74);
            this.gbTimKH.TabIndex = 0;
            this.gbTimKH.Text = "Tìm kiếm khách hàng";
            // 
            // btnTimKH
            // 
            this.btnTimKH.BorderRadius = 6;
            this.btnTimKH.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKH.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimKH.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnTimKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKH.ForeColor = System.Drawing.Color.White;
            this.btnTimKH.Location = new System.Drawing.Point(220, 43);
            this.btnTimKH.Name = "btnTimKH";
            this.btnTimKH.Size = new System.Drawing.Size(80, 25);
            this.btnTimKH.TabIndex = 1;
            this.btnTimKH.Text = "Tìm";
            // 
            // txtTimKiemKH
            // 
            this.txtTimKiemKH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txtTimKiemKH.BorderRadius = 6;
            this.txtTimKiemKH.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemKH.DefaultText = "";
            this.txtTimKiemKH.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiemKH.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiemKH.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemKH.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemKH.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemKH.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiemKH.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemKH.Location = new System.Drawing.Point(10, 43);
            this.txtTimKiemKH.Name = "txtTimKiemKH";
            this.txtTimKiemKH.PlaceholderText = "CCCD hoặc SĐT";
            this.txtTimKiemKH.SelectedText = "";
            this.txtTimKiemKH.Size = new System.Drawing.Size(200, 25);
            this.txtTimKiemKH.TabIndex = 0;
            // 
            // tabThanhToan
            // 
            this.tabThanhToan.BackColor = System.Drawing.Color.White;
            this.tabThanhToan.Controls.Add(this.gbThanhToanInfo);
            this.tabThanhToan.Controls.Add(this.gbThongTinChung);
            this.tabThanhToan.Location = new System.Drawing.Point(184, 4);
            this.tabThanhToan.Name = "tabThanhToan";
            this.tabThanhToan.Padding = new System.Windows.Forms.Padding(10);
            this.tabThanhToan.Size = new System.Drawing.Size(992, 452);
            this.tabThanhToan.TabIndex = 1;
            this.tabThanhToan.Text = "Thanh toán";
            // 
            // gbThanhToanInfo
            // 
            this.gbThanhToanInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbThanhToanInfo.BorderRadius = 8;
            this.gbThanhToanInfo.Controls.Add(this.lblNhanVien);
            this.gbThanhToanInfo.Controls.Add(this.label19);
            this.gbThanhToanInfo.Controls.Add(this.txtNoiDungPhuThu);
            this.gbThanhToanInfo.Controls.Add(this.label18);
            this.gbThanhToanInfo.Controls.Add(this.txtPhuThu);
            this.gbThanhToanInfo.Controls.Add(this.label17);
            this.gbThanhToanInfo.Controls.Add(this.label16);
            this.gbThanhToanInfo.Controls.Add(this.cbPhuongThucTT);
            this.gbThanhToanInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbThanhToanInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbThanhToanInfo.Location = new System.Drawing.Point(10, 112);
            this.gbThanhToanInfo.Name = "gbThanhToanInfo";
            this.gbThanhToanInfo.Size = new System.Drawing.Size(979, 120);
            this.gbThanhToanInfo.TabIndex = 1;
            this.gbThanhToanInfo.Text = "Thanh toán";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.Location = new System.Drawing.Point(73, 82);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(98, 19);
            this.lblNhanVien.TabIndex = 7;
            this.lblNhanVien.Text = "Mã nhân viên";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 84);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 15);
            this.label19.TabIndex = 6;
            this.label19.Text = "Nhân viên:";
            // 
            // txtNoiDungPhuThu
            // 
            this.txtNoiDungPhuThu.BorderRadius = 6;
            this.txtNoiDungPhuThu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoiDungPhuThu.DefaultText = "";
            this.txtNoiDungPhuThu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNoiDungPhuThu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNoiDungPhuThu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDungPhuThu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDungPhuThu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDungPhuThu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNoiDungPhuThu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDungPhuThu.Location = new System.Drawing.Point(657, 47);
            this.txtNoiDungPhuThu.Name = "txtNoiDungPhuThu";
            this.txtNoiDungPhuThu.PlaceholderText = "Nội dung phụ thu";
            this.txtNoiDungPhuThu.SelectedText = "";
            this.txtNoiDungPhuThu.Size = new System.Drawing.Size(300, 25);
            this.txtNoiDungPhuThu.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(596, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 15);
            this.label18.TabIndex = 4;
            this.label18.Text = "Nội dung:";
            // 
            // txtPhuThu
            // 
            this.txtPhuThu.BorderRadius = 6;
            this.txtPhuThu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhuThu.DefaultText = "";
            this.txtPhuThu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhuThu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhuThu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhuThu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhuThu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhuThu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhuThu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhuThu.Location = new System.Drawing.Point(397, 47);
            this.txtPhuThu.Name = "txtPhuThu";
            this.txtPhuThu.PlaceholderText = "Phụ thu";
            this.txtPhuThu.SelectedText = "";
            this.txtPhuThu.Size = new System.Drawing.Size(150, 25);
            this.txtPhuThu.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(344, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 15);
            this.label17.TabIndex = 2;
            this.label17.Text = "Phụ thu:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 15);
            this.label16.TabIndex = 1;
            this.label16.Text = "Phương thức TT:";
            // 
            // cbPhuongThucTT
            // 
            this.cbPhuongThucTT.BackColor = System.Drawing.Color.Transparent;
            this.cbPhuongThucTT.BorderRadius = 6;
            this.cbPhuongThucTT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPhuongThucTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhuongThucTT.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPhuongThucTT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPhuongThucTT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbPhuongThucTT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbPhuongThucTT.ItemHeight = 30;
            this.cbPhuongThucTT.Location = new System.Drawing.Point(105, 42);
            this.cbPhuongThucTT.Name = "cbPhuongThucTT";
            this.cbPhuongThucTT.Size = new System.Drawing.Size(200, 36);
            this.cbPhuongThucTT.TabIndex = 0;
            // 
            // gbThongTinChung
            // 
            this.gbThongTinChung.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbThongTinChung.BorderRadius = 8;
            this.gbThongTinChung.Controls.Add(this.lblTongTien);
            this.gbThongTinChung.Controls.Add(this.label15);
            this.gbThongTinChung.Controls.Add(this.lblSoLuongVe);
            this.gbThongTinChung.Controls.Add(this.label14);
            this.gbThongTinChung.Controls.Add(this.lblGiaVeChon);
            this.gbThongTinChung.Controls.Add(this.label13);
            this.gbThongTinChung.Controls.Add(this.lblHangVeChon);
            this.gbThongTinChung.Controls.Add(this.label12);
            this.gbThongTinChung.Controls.Add(this.label11);
            this.gbThongTinChung.Controls.Add(this.lblChuyenBayChon);
            this.gbThongTinChung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbThongTinChung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbThongTinChung.Location = new System.Drawing.Point(10, 6);
            this.gbThongTinChung.Name = "gbThongTinChung";
            this.gbThongTinChung.Size = new System.Drawing.Size(979, 100);
            this.gbThongTinChung.TabIndex = 0;
            this.gbThongTinChung.Text = "Thông tin chung";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(280, 69);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(30, 19);
            this.lblTongTien.TabIndex = 9;
            this.lblTongTien.Text = "0 ₫";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(220, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "Tổng tiền:";
            // 
            // lblSoLuongVe
            // 
            this.lblSoLuongVe.AutoSize = true;
            this.lblSoLuongVe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoLuongVe.Location = new System.Drawing.Point(81, 68);
            this.lblSoLuongVe.Name = "lblSoLuongVe";
            this.lblSoLuongVe.Size = new System.Drawing.Size(17, 19);
            this.lblSoLuongVe.TabIndex = 7;
            this.lblSoLuongVe.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 15);
            this.label14.TabIndex = 6;
            this.label14.Text = "Số lượng vé:";
            // 
            // lblGiaVeChon
            // 
            this.lblGiaVeChon.AutoSize = true;
            this.lblGiaVeChon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiaVeChon.Location = new System.Drawing.Point(471, 39);
            this.lblGiaVeChon.Name = "lblGiaVeChon";
            this.lblGiaVeChon.Size = new System.Drawing.Size(15, 19);
            this.lblGiaVeChon.TabIndex = 5;
            this.lblGiaVeChon.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(430, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "Giá vé:";
            // 
            // lblHangVeChon
            // 
            this.lblHangVeChon.AutoSize = true;
            this.lblHangVeChon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHangVeChon.Location = new System.Drawing.Point(273, 42);
            this.lblHangVeChon.Name = "lblHangVeChon";
            this.lblHangVeChon.Size = new System.Drawing.Size(15, 19);
            this.lblHangVeChon.TabIndex = 1;
            this.lblHangVeChon.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Hạng vé:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Chuyến bay:";
            // 
            // lblChuyenBayChon
            // 
            this.lblChuyenBayChon.AutoSize = true;
            this.lblChuyenBayChon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChuyenBayChon.Location = new System.Drawing.Point(83, 42);
            this.lblChuyenBayChon.Name = "lblChuyenBayChon";
            this.lblChuyenBayChon.Size = new System.Drawing.Size(15, 19);
            this.lblChuyenBayChon.TabIndex = 0;
            this.lblChuyenBayChon.Text = "-";
            // 
            // btnGiuCho
            // 
            this.btnGiuCho.BorderRadius = 6;
            this.btnGiuCho.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGiuCho.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGiuCho.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGiuCho.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGiuCho.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnGiuCho.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGiuCho.ForeColor = System.Drawing.Color.White;
            this.btnGiuCho.Location = new System.Drawing.Point(10, 715);
            this.btnGiuCho.Name = "btnGiuCho";
            this.btnGiuCho.Size = new System.Drawing.Size(100, 30);
            this.btnGiuCho.TabIndex = 3;
            this.btnGiuCho.Text = "Giữ chỗ";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BorderRadius = 6;
            this.btnThanhToan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThanhToan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(120, 715);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(187, 30);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "Thanh toán và Xuất vé";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BorderRadius = 6;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(317, 715);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoi.TabIndex = 5;
            this.btnLamMoi.Text = "Làm mới";
            // 
            // frmDatVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 749);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnGiuCho);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgvChuyenBay);
            this.Controls.Add(this.cbSanBayDi);
            this.Controls.Add(this.gbSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmDatVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt Vé Máy Bay";
            this.Load += new System.EventHandler(this.frmDatVe_Load);
            this.gbSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenBay)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabHanhKhach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanhKhach)).EndInit();
            this.gbGhe.ResumeLayout(false);
            this.gbGhe.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbTimKH.ResumeLayout(false);
            this.tabThanhToan.ResumeLayout(false);
            this.gbThanhToanInfo.ResumeLayout(false);
            this.gbThanhToanInfo.PerformLayout();
            this.gbThongTinChung.ResumeLayout(false);
            this.gbThongTinChung.PerformLayout();
            this.ResumeLayout(false);

        }

        
        private Guna2GroupBox gbSearch;
        private Guna2ComboBox cbSanBayDi;
        private Guna2ComboBox cbSanBayDen;
        private Guna2DateTimePicker dtpNgayDi;
        private Guna2Button btnTimKiem;
        private Guna2DataGridView dgvChuyenBay;
        private Guna2TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHanhKhach;
        private System.Windows.Forms.TabPage tabThanhToan;
        private Guna2GroupBox gbTimKH;
        private Guna2TextBox txtTimKiemKH;
        private Guna2Button btnTimKH;
        private Guna2GroupBox gbThongTin;
        private Guna2TextBox txtMaKH;
        private Label label1;
        private Guna2TextBox txtHoTenKH;
        private Label label2;
        private Label label3;
        private Guna2DateTimePicker dtpNgaySinhKH;
        private Label label4;
        private Guna2ComboBox cbGioiTinhKH;
        private Label label5;
        private Guna2TextBox txtCCCDKH;
        private Label label6;
        private Guna2TextBox txtSdtKH;
        private Guna2TextBox txtEmailKH;
        private Label label7;
        private Guna2TextBox txtDiaChiKH;
        private Label label8;
        private Guna2ComboBox cbLoaiKH;
        private Label label9;
        private Guna2GroupBox gbGhe;
        private Guna2TextBox txtMaGhe;
        private Label label10;
        private Guna2Button btnThemHanhKhach;
        private Guna2DataGridView dgvHanhKhach;
        private Guna2GroupBox gbThongTinChung;
        private Label label15;
        private Label lblSoLuongVe;
        private Label label14;
        private Label lblGiaVeChon;
        private Label label13;
        private Label lblHangVeChon;
        private Label label12;
        private Label label11;
        private Label lblChuyenBayChon;
        private Label lblTongTien;
        private Guna2GroupBox gbThanhToanInfo;
        private Label label16;
        private Guna2ComboBox cbPhuongThucTT;
        private Label label17;
        private Guna2TextBox txtPhuThu;
        private Label label18;
        private Guna2TextBox txtNoiDungPhuThu;
        private Label label19;
        private Label lblNhanVien;
        private Guna2Button btnGiuCho;
        private Guna2Button btnThanhToan;
        private Guna2Button btnLamMoi;
    }
}
