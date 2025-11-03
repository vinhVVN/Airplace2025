namespace Airplace2025
{
    partial class frmDanhSachChuyenBay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.dgvFlight = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cbTrangThai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaChuyenBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanBayDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanBayDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGioBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHangBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaCoBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGheTrong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBook = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlight)).BeginInit();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(0, 34);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(1200, 278);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // dgvFlight
            // 
            this.dgvFlight.AllowUserToAddRows = false;
            this.dgvFlight.AllowUserToDeleteRows = false;
            this.dgvFlight.AllowUserToResizeColumns = false;
            this.dgvFlight.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvFlight.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlight.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFlight.ColumnHeadersHeight = 40;
            this.dgvFlight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvFlight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChuyenBay,
            this.TenSanBayDi,
            this.TenSanBayDen,
            this.NgayGioBay,
            this.TenHangBay,
            this.GiaCoBan,
            this.TrangThai,
            this.SoGheTrong,
            this.colBook,
            this.colDetail});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlight.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFlight.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvFlight.Location = new System.Drawing.Point(0, 314);
            this.dgvFlight.Name = "dgvFlight";
            this.dgvFlight.ReadOnly = true;
            this.dgvFlight.RowHeadersVisible = false;
            this.dgvFlight.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dgvFlight.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFlight.RowTemplate.Height = 40;
            this.dgvFlight.RowTemplate.ReadOnly = true;
            this.dgvFlight.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFlight.Size = new System.Drawing.Size(1200, 326);
            this.dgvFlight.TabIndex = 1;
            this.dgvFlight.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFlight.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvFlight.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvFlight.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvFlight.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvFlight.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvFlight.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvFlight.ThemeStyle.HeaderStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dgvFlight.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFlight.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.dgvFlight.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvFlight.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvFlight.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvFlight.ThemeStyle.ReadOnly = true;
            this.dgvFlight.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvFlight.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFlight.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvFlight.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvFlight.ThemeStyle.RowsStyle.Height = 40;
            this.dgvFlight.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.dgvFlight.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvFlight.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlight_CellClick);
            this.dgvFlight.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvFlight_CellFormatting);
            this.dgvFlight.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvFlight_CellPainting);
            this.dgvFlight.SelectionChanged += new System.EventHandler(this.dgvFlight_SelectionChanged);
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.cbTrangThai.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cbTrangThai.BorderRadius = 6;
            this.cbTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.FocusedColor = System.Drawing.Color.Empty;
            this.cbTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTrangThai.ItemHeight = 20;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Theo lịch trình",
            "Đang bay",
            "Đã hạ cánh",
            "Bị hoãn",
            "Bị huỷ"});
            this.cbTrangThai.Location = new System.Drawing.Point(87, 5);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(200, 26);
            this.cbTrangThai.StartIndex = 0;
            this.cbTrangThai.TabIndex = 3;
            this.cbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbTrangThai_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trạng thái";
            // 
            // MaChuyenBay
            // 
            this.MaChuyenBay.DataPropertyName = "MaChuyenBay";
            this.MaChuyenBay.HeaderText = "Mã Chuyến Bay";
            this.MaChuyenBay.Name = "MaChuyenBay";
            this.MaChuyenBay.ReadOnly = true;
            this.MaChuyenBay.Visible = false;
            // 
            // TenSanBayDi
            // 
            this.TenSanBayDi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenSanBayDi.DataPropertyName = "TenSanBayDi";
            this.TenSanBayDi.HeaderText = "Sân Bay Đi";
            this.TenSanBayDi.Name = "TenSanBayDi";
            this.TenSanBayDi.ReadOnly = true;
            this.TenSanBayDi.Width = 200;
            // 
            // TenSanBayDen
            // 
            this.TenSanBayDen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenSanBayDen.DataPropertyName = "TenSanBayDen";
            this.TenSanBayDen.HeaderText = "Sân Bay Đến";
            this.TenSanBayDen.Name = "TenSanBayDen";
            this.TenSanBayDen.ReadOnly = true;
            this.TenSanBayDen.Width = 200;
            // 
            // NgayGioBay
            // 
            this.NgayGioBay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NgayGioBay.DataPropertyName = "NgayGioBay";
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.NgayGioBay.DefaultCellStyle = dataGridViewCellStyle3;
            this.NgayGioBay.HeaderText = "Ngày Giờ Bay";
            this.NgayGioBay.Name = "NgayGioBay";
            this.NgayGioBay.ReadOnly = true;
            this.NgayGioBay.Width = 91;
            // 
            // TenHangBay
            // 
            this.TenHangBay.DataPropertyName = "TenHangBay";
            this.TenHangBay.HeaderText = "Tên Hãng Bay";
            this.TenHangBay.Name = "TenHangBay";
            this.TenHangBay.ReadOnly = true;
            // 
            // GiaCoBan
            // 
            this.GiaCoBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GiaCoBan.DataPropertyName = "GiaCoBan";
            dataGridViewCellStyle4.Format = "N0";
            this.GiaCoBan.DefaultCellStyle = dataGridViewCellStyle4;
            this.GiaCoBan.HeaderText = "Giá Cơ Bản";
            this.GiaCoBan.Name = "GiaCoBan";
            this.GiaCoBan.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // SoGheTrong
            // 
            this.SoGheTrong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SoGheTrong.DataPropertyName = "SoGheTrong";
            this.SoGheTrong.HeaderText = "Số Ghế Trống";
            this.SoGheTrong.Name = "SoGheTrong";
            this.SoGheTrong.ReadOnly = true;
            this.SoGheTrong.Width = 80;
            // 
            // colBook
            // 
            this.colBook.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.colBook.DefaultCellStyle = dataGridViewCellStyle5;
            this.colBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colBook.HeaderText = "";
            this.colBook.Name = "colBook";
            this.colBook.ReadOnly = true;
            this.colBook.Text = "Book Ticket";
            this.colBook.UseColumnTextForButtonValue = true;
            this.colBook.Width = 5;
            // 
            // colDetail
            // 
            this.colDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.colDetail.DefaultCellStyle = dataGridViewCellStyle6;
            this.colDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDetail.HeaderText = "";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDetail.Text = "Details";
            this.colDetail.UseColumnTextForButtonValue = true;
            this.colDetail.Width = 17;
            // 
            // frmDanhSachChuyenBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 644);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.dgvFlight);
            this.Controls.Add(this.webView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDanhSachChuyenBay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDanhSachChuyenBay";
            this.Load += new System.EventHandler(this.frmDanhSachChuyenBay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Guna.UI2.WinForms.Guna2DataGridView dgvFlight;
        private Guna.UI2.WinForms.Guna2ComboBox cbTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChuyenBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanBayDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanBayDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGioBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHangBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaCoBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGheTrong;
        private System.Windows.Forms.DataGridViewButtonColumn colBook;
        private System.Windows.Forms.DataGridViewButtonColumn colDetail;
    }
}