namespace Airplace2025
{
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSwapAirport = new Guna.UI2.WinForms.Guna2Button();
            this.cbServiceClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblServiceClass = new System.Windows.Forms.Label();
            this.rbRoundTrip = new System.Windows.Forms.RadioButton();
            this.rbOneWay = new System.Windows.Forms.RadioButton();
            this.numBaby = new System.Windows.Forms.NumericUpDown();
            this.numChild = new System.Windows.Forms.NumericUpDown();
            this.numAdult = new System.Windows.Forms.NumericUpDown();
            this.lblBaby = new System.Windows.Forms.Label();
            this.lblChild = new System.Windows.Forms.Label();
            this.lblAdult = new System.Windows.Forms.Label();
            this.dtpReturnDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.dtpNgayDi = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbSanBayDen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSanBayDi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTripType = new System.Windows.Forms.Label();
            this.dgvChuyenBay = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlBaggagePolicy = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChangePolicy = new System.Windows.Forms.Label();
            this.lblBaggageInfo = new System.Windows.Forms.Label();
            this.lblPolicyTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabHanhKhach = new System.Windows.Forms.TabPage();
            this.dgvHanhKhach = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnThemHanhKhach = new Guna.UI2.WinForms.Guna2Button();
            this.lblHuongDan = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.numBaby)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenBay)).BeginInit();
            this.pnlBaggagePolicy.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabHanhKhach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanhKhach)).BeginInit();
            this.tabThanhToan.SuspendLayout();
            this.gbThanhToanInfo.SuspendLayout();
            this.gbThongTinChung.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbSearch.BorderRadius = 8;
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.btnSwapAirport);
            this.gbSearch.Controls.Add(this.cbServiceClass);
            this.gbSearch.Controls.Add(this.lblServiceClass);
            this.gbSearch.Controls.Add(this.rbRoundTrip);
            this.gbSearch.Controls.Add(this.rbOneWay);
            this.gbSearch.Controls.Add(this.numBaby);
            this.gbSearch.Controls.Add(this.numChild);
            this.gbSearch.Controls.Add(this.numAdult);
            this.gbSearch.Controls.Add(this.lblBaby);
            this.gbSearch.Controls.Add(this.lblChild);
            this.gbSearch.Controls.Add(this.lblAdult);
            this.gbSearch.Controls.Add(this.dtpReturnDate);
            this.gbSearch.Controls.Add(this.lblReturnDate);
            this.gbSearch.Controls.Add(this.btnTimKiem);
            this.gbSearch.Controls.Add(this.dtpNgayDi);
            this.gbSearch.Controls.Add(this.cbSanBayDen);
            this.gbSearch.Controls.Add(this.cbSanBayDi);
            this.gbSearch.Controls.Add(this.lblTripType);
            this.gbSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbSearch.Location = new System.Drawing.Point(10, 10);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1180, 180);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.Text = "Tìm kiếm chuyến bay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ngày đi";
            // 
            // btnSwapAirport
            // 
            this.btnSwapAirport.BorderRadius = 6;
            this.btnSwapAirport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnSwapAirport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSwapAirport.ForeColor = System.Drawing.Color.White;
            this.btnSwapAirport.Location = new System.Drawing.Point(184, 42);
            this.btnSwapAirport.Name = "btnSwapAirport";
            this.btnSwapAirport.Size = new System.Drawing.Size(35, 30);
            this.btnSwapAirport.TabIndex = 15;
            this.btnSwapAirport.Text = "⇄";
            this.btnSwapAirport.Click += new System.EventHandler(this.btnSwapAirport_Click);
            // 
            // cbServiceClass
            // 
            this.cbServiceClass.BackColor = System.Drawing.Color.Transparent;
            this.cbServiceClass.BorderRadius = 6;
            this.cbServiceClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbServiceClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServiceClass.FocusedColor = System.Drawing.Color.Empty;
            this.cbServiceClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbServiceClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbServiceClass.ItemHeight = 30;
            this.cbServiceClass.Items.AddRange(new object[] {
            "Economy",
            "Premium",
            "Business"});
            this.cbServiceClass.Location = new System.Drawing.Point(940, 41);
            this.cbServiceClass.Name = "cbServiceClass";
            this.cbServiceClass.Size = new System.Drawing.Size(120, 36);
            this.cbServiceClass.TabIndex = 14;
            // 
            // lblServiceClass
            // 
            this.lblServiceClass.AutoSize = true;
            this.lblServiceClass.Location = new System.Drawing.Point(880, 50);
            this.lblServiceClass.Name = "lblServiceClass";
            this.lblServiceClass.Size = new System.Drawing.Size(56, 15);
            this.lblServiceClass.TabIndex = 13;
            this.lblServiceClass.Text = "Hạng vé:";
            // 
            // rbRoundTrip
            // 
            this.rbRoundTrip.AutoSize = true;
            this.rbRoundTrip.Checked = true;
            this.rbRoundTrip.Location = new System.Drawing.Point(615, 50);
            this.rbRoundTrip.Name = "rbRoundTrip";
            this.rbRoundTrip.Size = new System.Drawing.Size(68, 19);
            this.rbRoundTrip.TabIndex = 12;
            this.rbRoundTrip.TabStop = true;
            this.rbRoundTrip.Text = "Khứ hồi";
            this.rbRoundTrip.UseVisualStyleBackColor = true;
            this.rbRoundTrip.CheckedChanged += new System.EventHandler(this.rbRoundTrip_CheckedChanged);
            // 
            // rbOneWay
            // 
            this.rbOneWay.AutoSize = true;
            this.rbOneWay.Location = new System.Drawing.Point(540, 50);
            this.rbOneWay.Name = "rbOneWay";
            this.rbOneWay.Size = new System.Drawing.Size(65, 19);
            this.rbOneWay.TabIndex = 11;
            this.rbOneWay.Text = "1 chiều";
            this.rbOneWay.UseVisualStyleBackColor = true;
            // 
            // numBaby
            // 
            this.numBaby.Location = new System.Drawing.Point(830, 90);
            this.numBaby.Name = "numBaby";
            this.numBaby.Size = new System.Drawing.Size(50, 23);
            this.numBaby.TabIndex = 10;
            // 
            // numChild
            // 
            this.numChild.Location = new System.Drawing.Point(660, 90);
            this.numChild.Name = "numChild";
            this.numChild.Size = new System.Drawing.Size(50, 23);
            this.numChild.TabIndex = 9;
            // 
            // numAdult
            // 
            this.numAdult.Location = new System.Drawing.Point(499, 90);
            this.numAdult.Name = "numAdult";
            this.numAdult.Size = new System.Drawing.Size(50, 23);
            this.numAdult.TabIndex = 8;
            this.numAdult.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBaby
            // 
            this.lblBaby.AutoSize = true;
            this.lblBaby.Location = new System.Drawing.Point(783, 93);
            this.lblBaby.Name = "lblBaby";
            this.lblBaby.Size = new System.Drawing.Size(45, 15);
            this.lblBaby.TabIndex = 7;
            this.lblBaby.Text = "em bé:";
            // 
            // lblChild
            // 
            this.lblChild.AutoSize = true;
            this.lblChild.Location = new System.Drawing.Point(610, 93);
            this.lblChild.Name = "lblChild";
            this.lblChild.Size = new System.Drawing.Size(49, 15);
            this.lblChild.TabIndex = 6;
            this.lblChild.Text = "Trẻ em:";
            // 
            // lblAdult
            // 
            this.lblAdult.AutoSize = true;
            this.lblAdult.Location = new System.Drawing.Point(447, 93);
            this.lblAdult.Name = "lblAdult";
            this.lblAdult.Size = new System.Drawing.Size(50, 15);
            this.lblAdult.TabIndex = 5;
            this.lblAdult.Text = "Ng. lớn:";
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dtpReturnDate.BorderRadius = 6;
            this.dtpReturnDate.Checked = true;
            this.dtpReturnDate.FillColor = System.Drawing.Color.White;
            this.dtpReturnDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(239, 132);
            this.dtpReturnDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpReturnDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(150, 30);
            this.dtpReturnDate.TabIndex = 4;
            this.dtpReturnDate.Value = new System.DateTime(2025, 10, 25, 15, 12, 10, 444);
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(239, 115);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(108, 15);
            this.lblReturnDate.TabIndex = 3;
            this.lblReturnDate.Text = "Ngày về (khứ hồi):";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BorderRadius = 6;
            this.btnTimKiem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(1040, 90);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 36);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtpNgayDi
            // 
            this.dtpNgayDi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dtpNgayDi.BorderRadius = 6;
            this.dtpNgayDi.Checked = true;
            this.dtpNgayDi.FillColor = System.Drawing.Color.White;
            this.dtpNgayDi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDi.Location = new System.Drawing.Point(12, 132);
            this.dtpNgayDi.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayDi.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayDi.Name = "dtpNgayDi";
            this.dtpNgayDi.Size = new System.Drawing.Size(150, 30);
            this.dtpNgayDi.TabIndex = 1;
            this.dtpNgayDi.Value = new System.DateTime(2025, 10, 24, 15, 12, 10, 504);
            // 
            // cbSanBayDen
            // 
            this.cbSanBayDen.BackColor = System.Drawing.Color.Transparent;
            this.cbSanBayDen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbSanBayDen.BorderRadius = 6;
            this.cbSanBayDen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSanBayDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSanBayDen.FocusedColor = System.Drawing.Color.Empty;
            this.cbSanBayDen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbSanBayDen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSanBayDen.ItemHeight = 30;
            this.cbSanBayDen.Location = new System.Drawing.Point(239, 41);
            this.cbSanBayDen.Name = "cbSanBayDen";
            this.cbSanBayDen.Size = new System.Drawing.Size(150, 36);
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
            this.cbSanBayDi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbSanBayDi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSanBayDi.ItemHeight = 30;
            this.cbSanBayDi.Location = new System.Drawing.Point(12, 41);
            this.cbSanBayDi.Name = "cbSanBayDi";
            this.cbSanBayDi.Size = new System.Drawing.Size(150, 36);
            this.cbSanBayDi.TabIndex = 0;
            // 
            // lblTripType
            // 
            this.lblTripType.AutoSize = true;
            this.lblTripType.Location = new System.Drawing.Point(485, 52);
            this.lblTripType.Name = "lblTripType";
            this.lblTripType.Size = new System.Drawing.Size(49, 15);
            this.lblTripType.TabIndex = 3;
            this.lblTripType.Text = "Loại vé:";
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
            this.dgvChuyenBay.ColumnHeadersHeight = 35;
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
            this.dgvChuyenBay.Location = new System.Drawing.Point(10, 196);
            this.dgvChuyenBay.Name = "dgvChuyenBay";
            this.dgvChuyenBay.RowHeadersVisible = false;
            this.dgvChuyenBay.Size = new System.Drawing.Size(750, 150);
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
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChuyenBay.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvChuyenBay.ThemeStyle.ReadOnly = false;
            this.dgvChuyenBay.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChuyenBay.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChuyenBay.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChuyenBay.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChuyenBay.ThemeStyle.RowsStyle.Height = 22;
            this.dgvChuyenBay.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChuyenBay.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChuyenBay.DoubleClick += new System.EventHandler(this.dgvChuyenBay_DoubleClick);
            // 
            // pnlBaggagePolicy
            // 
            this.pnlBaggagePolicy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlBaggagePolicy.BorderRadius = 8;
            this.pnlBaggagePolicy.BorderThickness = 1;
            this.pnlBaggagePolicy.Controls.Add(this.lblChangePolicy);
            this.pnlBaggagePolicy.Controls.Add(this.lblBaggageInfo);
            this.pnlBaggagePolicy.Controls.Add(this.lblPolicyTitle);
            this.pnlBaggagePolicy.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBaggagePolicy.Location = new System.Drawing.Point(767, 196);
            this.pnlBaggagePolicy.Name = "pnlBaggagePolicy";
            this.pnlBaggagePolicy.Size = new System.Drawing.Size(420, 150);
            this.pnlBaggagePolicy.TabIndex = 16;
            // 
            // lblChangePolicy
            // 
            this.lblChangePolicy.AutoSize = true;
            this.lblChangePolicy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblChangePolicy.Location = new System.Drawing.Point(10, 55);
            this.lblChangePolicy.Name = "lblChangePolicy";
            this.lblChangePolicy.Size = new System.Drawing.Size(93, 15);
            this.lblChangePolicy.TabIndex = 2;
            this.lblChangePolicy.Text = "Đổi vé: Miễn phí";
            // 
            // lblBaggageInfo
            // 
            this.lblBaggageInfo.AutoSize = true;
            this.lblBaggageInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBaggageInfo.Location = new System.Drawing.Point(10, 35);
            this.lblBaggageInfo.Name = "lblBaggageInfo";
            this.lblBaggageInfo.Size = new System.Drawing.Size(213, 15);
            this.lblBaggageInfo.TabIndex = 1;
            this.lblBaggageInfo.Text = "Hành lý: 20kg khoang hàng + 5kg xách";
            // 
            // lblPolicyTitle
            // 
            this.lblPolicyTitle.AutoSize = true;
            this.lblPolicyTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPolicyTitle.Location = new System.Drawing.Point(10, 10);
            this.lblPolicyTitle.Name = "lblPolicyTitle";
            this.lblPolicyTitle.Size = new System.Drawing.Size(113, 19);
            this.lblPolicyTitle.TabIndex = 0;
            this.lblPolicyTitle.Text = "Chi tiết hạng vé";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabHanhKhach);
            this.tabControl1.Controls.Add(this.tabThanhToan);
            this.tabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControl1.Location = new System.Drawing.Point(10, 351);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1180, 360);
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
            this.tabHanhKhach.Controls.Add(this.btnThemHanhKhach);
            this.tabHanhKhach.Controls.Add(this.lblHuongDan);
            this.tabHanhKhach.Location = new System.Drawing.Point(184, 4);
            this.tabHanhKhach.Name = "tabHanhKhach";
            this.tabHanhKhach.Padding = new System.Windows.Forms.Padding(10);
            this.tabHanhKhach.Size = new System.Drawing.Size(992, 352);
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
            this.dgvHanhKhach.ColumnHeadersHeight = 35;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHanhKhach.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHanhKhach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHanhKhach.Location = new System.Drawing.Point(10, 82);
            this.dgvHanhKhach.Name = "dgvHanhKhach";
            this.dgvHanhKhach.RowHeadersVisible = false;
            this.dgvHanhKhach.Size = new System.Drawing.Size(972, 260);
            this.dgvHanhKhach.TabIndex = 2;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHanhKhach.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHanhKhach.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHanhKhach.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHanhKhach.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvHanhKhach.ThemeStyle.ReadOnly = false;
            this.dgvHanhKhach.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHanhKhach.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHanhKhach.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvHanhKhach.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHanhKhach.ThemeStyle.RowsStyle.Height = 22;
            this.dgvHanhKhach.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHanhKhach.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnThemHanhKhach
            // 
            this.btnThemHanhKhach.BorderRadius = 6;
            this.btnThemHanhKhach.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnThemHanhKhach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThemHanhKhach.ForeColor = System.Drawing.Color.White;
            this.btnThemHanhKhach.Location = new System.Drawing.Point(10, 45);
            this.btnThemHanhKhach.Name = "btnThemHanhKhach";
            this.btnThemHanhKhach.Size = new System.Drawing.Size(150, 32);
            this.btnThemHanhKhach.TabIndex = 1;
            this.btnThemHanhKhach.Text = "+ Thêm vào danh sách";
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHuongDan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblHuongDan.Location = new System.Drawing.Point(10, 10);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(972, 30);
            this.lblHuongDan.TabIndex = 0;
            this.lblHuongDan.Text = "Nhấn \"Thêm vào danh sách\" để thêm hành khách mới. Bạn sẽ được hướng dẫn tìm/tạo k" +
    "hách hàng, nhập chi tiết và chọn ghế.";
            // 
            // tabThanhToan
            // 
            this.tabThanhToan.BackColor = System.Drawing.Color.White;
            this.tabThanhToan.Controls.Add(this.gbThanhToanInfo);
            this.tabThanhToan.Controls.Add(this.gbThongTinChung);
            this.tabThanhToan.Location = new System.Drawing.Point(184, 4);
            this.tabThanhToan.Name = "tabThanhToan";
            this.tabThanhToan.Padding = new System.Windows.Forms.Padding(10);
            this.tabThanhToan.Size = new System.Drawing.Size(992, 352);
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
            this.txtNoiDungPhuThu.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.txtPhuThu.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.cbPhuongThucTT.FocusedColor = System.Drawing.Color.Empty;
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
            this.Controls.Add(this.pnlBaggagePolicy);
            this.Controls.Add(this.dgvChuyenBay);
            this.Controls.Add(this.gbSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "frmDatVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt Vé Máy Bay";
            this.Load += new System.EventHandler(this.frmDatVe_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaby)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenBay)).EndInit();
            this.pnlBaggagePolicy.ResumeLayout(false);
            this.pnlBaggagePolicy.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabHanhKhach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHanhKhach)).EndInit();
            this.tabThanhToan.ResumeLayout(false);
            this.gbThanhToanInfo.ResumeLayout(false);
            this.gbThanhToanInfo.PerformLayout();
            this.gbThongTinChung.ResumeLayout(false);
            this.gbThongTinChung.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2GroupBox gbSearch;
        private Guna.UI2.WinForms.Guna2Button btnSwapAirport;
        private Guna.UI2.WinForms.Guna2ComboBox cbServiceClass;
        private System.Windows.Forms.Label lblServiceClass;
        private System.Windows.Forms.RadioButton rbRoundTrip;
        private System.Windows.Forms.RadioButton rbOneWay;
        private System.Windows.Forms.NumericUpDown numBaby;
        private System.Windows.Forms.NumericUpDown numChild;
        private System.Windows.Forms.NumericUpDown numAdult;
        private System.Windows.Forms.Label lblBaby;
        private System.Windows.Forms.Label lblChild;
        private System.Windows.Forms.Label lblAdult;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label lblReturnDate;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayDi;
        private Guna.UI2.WinForms.Guna2ComboBox cbSanBayDen;
        private Guna.UI2.WinForms.Guna2ComboBox cbSanBayDi;
        private System.Windows.Forms.Label lblTripType;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChuyenBay;
        private Guna.UI2.WinForms.Guna2Panel pnlBaggagePolicy;
        private System.Windows.Forms.Label lblPolicyTitle;
        private System.Windows.Forms.Label lblBaggageInfo;
        private System.Windows.Forms.Label lblChangePolicy;
        private Guna.UI2.WinForms.Guna2TabControl tabControl1;
        private System.Windows.Forms.TabPage tabHanhKhach;
        private System.Windows.Forms.TabPage tabThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnThemHanhKhach;
        private System.Windows.Forms.Label lblHuongDan;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHanhKhach;
        private Guna.UI2.WinForms.Guna2GroupBox gbThongTinChung;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblSoLuongVe;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblGiaVeChon;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblHangVeChon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblChuyenBayChon;
        private System.Windows.Forms.Label lblTongTien;
        private Guna.UI2.WinForms.Guna2GroupBox gbThanhToanInfo;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2ComboBox cbPhuongThucTT;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2TextBox txtPhuThu;
        private System.Windows.Forms.Label label18;
        private Guna.UI2.WinForms.Guna2TextBox txtNoiDungPhuThu;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnGiuCho;
        private Guna.UI2.WinForms.Guna2Button btnThanhToan;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private System.Windows.Forms.Label label1;
    }
}
