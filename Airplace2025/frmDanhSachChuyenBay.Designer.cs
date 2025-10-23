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
            this.btnClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(0, 34);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(1046, 278);
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
            this.dgvFlight.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFlight.BackgroundColor = System.Drawing.Color.White;
            this.dgvFlight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFlight.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvFlight.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlight.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFlight.ColumnHeadersHeight = 40;
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
            this.dgvFlight.EnableHeadersVisualStyles = false;
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
            this.dgvFlight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlight.Size = new System.Drawing.Size(1046, 326);
            this.dgvFlight.TabIndex = 1;
            this.dgvFlight.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
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
            this.TenSanBayDi.Width = 150;
            // 
            // TenSanBayDen
            // 
            this.TenSanBayDen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenSanBayDen.DataPropertyName = "TenSanBayDen";
            this.TenSanBayDen.HeaderText = "Sân Bay Đến";
            this.TenSanBayDen.Name = "TenSanBayDen";
            this.TenSanBayDen.ReadOnly = true;
            this.TenSanBayDen.Width = 150;
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
            // btnClose
            // 
            this.btnClose.Image = global::Airplace2025.Properties.Resources.noun_x_4572560;
            this.btnClose.Location = new System.Drawing.Point(1013, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            // 
            // frmDanhSachChuyenBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1046, 644);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvFlight);
            this.Controls.Add(this.webView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDanhSachChuyenBay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDanhSachChuyenBay";
            this.Load += new System.EventHandler(this.frmDanhSachChuyenBay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Guna.UI2.WinForms.Guna2DataGridView dgvFlight;
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
        private System.Windows.Forms.PictureBox btnClose;
    }
}