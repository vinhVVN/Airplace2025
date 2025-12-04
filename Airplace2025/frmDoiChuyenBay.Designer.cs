namespace Airplace2025
{
    partial class frmDoiChuyenBay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbVeCu = new System.Windows.Forms.Label();
            this.lbChuyenBayCu = new System.Windows.Forms.Label();
            this.lbSanBay = new System.Windows.Forms.Label();
            this.lbGiaCu = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSanBayDi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSanBayDen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpNgayDi = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.dgvChuyenBayMoi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lbTongThu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenBayMoi)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 6;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(633, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Xác nhận";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 6;
            this.btnExit.FillColor = System.Drawing.Color.Gray;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(534, 420);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Huỷ";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đổi chuyến bay";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(22, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Mã vé:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(22, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Chuyến bay hiện tại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(22, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Sân bay đi/đến:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(22, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Giá hiện tại:";
            // 
            // lbVeCu
            // 
            this.lbVeCu.AutoSize = true;
            this.lbVeCu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVeCu.ForeColor = System.Drawing.Color.Black;
            this.lbVeCu.Location = new System.Drawing.Point(66, 47);
            this.lbVeCu.Name = "lbVeCu";
            this.lbVeCu.Size = new System.Drawing.Size(51, 17);
            this.lbVeCu.TabIndex = 26;
            this.lbVeCu.Text = "ETK036";
            // 
            // lbChuyenBayCu
            // 
            this.lbChuyenBayCu.AutoSize = true;
            this.lbChuyenBayCu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChuyenBayCu.ForeColor = System.Drawing.Color.Black;
            this.lbChuyenBayCu.Location = new System.Drawing.Point(143, 65);
            this.lbChuyenBayCu.Name = "lbChuyenBayCu";
            this.lbChuyenBayCu.Size = new System.Drawing.Size(44, 17);
            this.lbChuyenBayCu.TabIndex = 27;
            this.lbChuyenBayCu.Text = "CB036";
            // 
            // lbSanBay
            // 
            this.lbSanBay.AutoSize = true;
            this.lbSanBay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSanBay.ForeColor = System.Drawing.Color.Black;
            this.lbSanBay.Location = new System.Drawing.Point(119, 83);
            this.lbSanBay.Name = "lbSanBay";
            this.lbSanBay.Size = new System.Drawing.Size(242, 17);
            this.lbSanBay.TabIndex = 28;
            this.lbSanBay.Text = "Sân bay Thanh Hoá - Sân bay Nam Định";
            // 
            // lbGiaCu
            // 
            this.lbGiaCu.AutoSize = true;
            this.lbGiaCu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaCu.ForeColor = System.Drawing.Color.Black;
            this.lbGiaCu.Location = new System.Drawing.Point(98, 103);
            this.lbGiaCu.Name = "lbGiaCu";
            this.lbGiaCu.Size = new System.Drawing.Size(71, 17);
            this.lbGiaCu.TabIndex = 29;
            this.lbGiaCu.Text = "3.600.000đ";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2Panel1.Controls.Add(this.btnTimKiem);
            this.guna2Panel1.Controls.Add(this.dtpNgayDi);
            this.guna2Panel1.Controls.Add(this.label12);
            this.guna2Panel1.Controls.Add(this.label9);
            this.guna2Panel1.Controls.Add(this.cbSanBayDen);
            this.guna2Panel1.Controls.Add(this.label11);
            this.guna2Panel1.Controls.Add(this.cbSanBayDi);
            this.guna2Panel1.Controls.Add(this.label10);
            this.guna2Panel1.Location = new System.Drawing.Point(510, 134);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(203, 238);
            this.guna2Panel1.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(8, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 21);
            this.label10.TabIndex = 32;
            this.label10.Text = "Từ:";
            // 
            // cbSanBayDi
            // 
            this.cbSanBayDi.BackColor = System.Drawing.Color.Transparent;
            this.cbSanBayDi.BorderRadius = 6;
            this.cbSanBayDi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSanBayDi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSanBayDi.FocusedColor = System.Drawing.Color.Empty;
            this.cbSanBayDi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbSanBayDi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSanBayDi.ItemHeight = 20;
            this.cbSanBayDi.Location = new System.Drawing.Point(12, 48);
            this.cbSanBayDi.Name = "cbSanBayDi";
            this.cbSanBayDi.Size = new System.Drawing.Size(179, 26);
            this.cbSanBayDi.TabIndex = 31;
            // 
            // cbSanBayDen
            // 
            this.cbSanBayDen.BackColor = System.Drawing.Color.Transparent;
            this.cbSanBayDen.BorderRadius = 6;
            this.cbSanBayDen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSanBayDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSanBayDen.FocusedColor = System.Drawing.Color.Empty;
            this.cbSanBayDen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbSanBayDen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSanBayDen.ItemHeight = 20;
            this.cbSanBayDen.Location = new System.Drawing.Point(12, 99);
            this.cbSanBayDen.Name = "cbSanBayDen";
            this.cbSanBayDen.Size = new System.Drawing.Size(179, 26);
            this.cbSanBayDen.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(8, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 21);
            this.label11.TabIndex = 34;
            this.label11.Text = "Đến:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 21);
            this.label9.TabIndex = 35;
            this.label9.Text = "Yêu cầu chuyến bay";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(8, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 21);
            this.label12.TabIndex = 36;
            this.label12.Text = "Ngày khởi hành:";
            // 
            // dtpNgayDi
            // 
            this.dtpNgayDi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dtpNgayDi.BorderRadius = 6;
            this.dtpNgayDi.Checked = true;
            this.dtpNgayDi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpNgayDi.CustomFormat = "Th d, dd thg mm";
            this.dtpNgayDi.FillColor = System.Drawing.Color.White;
            this.dtpNgayDi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDi.Location = new System.Drawing.Point(12, 153);
            this.dtpNgayDi.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayDi.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayDi.Name = "dtpNgayDi";
            this.dtpNgayDi.Size = new System.Drawing.Size(179, 30);
            this.dtpNgayDi.TabIndex = 31;
            this.dtpNgayDi.Value = new System.DateTime(2025, 10, 24, 15, 12, 10, 504);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BorderRadius = 6;
            this.btnTimKiem.FillColor = System.Drawing.Color.Yellow;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Location = new System.Drawing.Point(12, 195);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(89, 30);
            this.btnTimKiem.TabIndex = 31;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvChuyenBayMoi
            // 
            this.dgvChuyenBayMoi.AllowUserToAddRows = false;
            this.dgvChuyenBayMoi.AllowUserToDeleteRows = false;
            this.dgvChuyenBayMoi.AllowUserToResizeColumns = false;
            this.dgvChuyenBayMoi.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvChuyenBayMoi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvChuyenBayMoi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChuyenBayMoi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvChuyenBayMoi.ColumnHeadersHeight = 20;
            this.dgvChuyenBayMoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChuyenBayMoi.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvChuyenBayMoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChuyenBayMoi.Location = new System.Drawing.Point(12, 133);
            this.dgvChuyenBayMoi.Name = "dgvChuyenBayMoi";
            this.dgvChuyenBayMoi.ReadOnly = true;
            this.dgvChuyenBayMoi.RowHeadersVisible = false;
            this.dgvChuyenBayMoi.Size = new System.Drawing.Size(492, 239);
            this.dgvChuyenBayMoi.TabIndex = 31;
            this.dgvChuyenBayMoi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChuyenBayMoi.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvChuyenBayMoi.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvChuyenBayMoi.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvChuyenBayMoi.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvChuyenBayMoi.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvChuyenBayMoi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChuyenBayMoi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvChuyenBayMoi.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvChuyenBayMoi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChuyenBayMoi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvChuyenBayMoi.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvChuyenBayMoi.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvChuyenBayMoi.ThemeStyle.ReadOnly = true;
            this.dgvChuyenBayMoi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvChuyenBayMoi.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChuyenBayMoi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChuyenBayMoi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChuyenBayMoi.ThemeStyle.RowsStyle.Height = 22;
            this.dgvChuyenBayMoi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvChuyenBayMoi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvChuyenBayMoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChuyenBayMoi_CellClick);
            // 
            // lbTongThu
            // 
            this.lbTongThu.AutoSize = true;
            this.lbTongThu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongThu.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTongThu.Location = new System.Drawing.Point(13, 419);
            this.lbTongThu.Name = "lbTongThu";
            this.lbTongThu.Size = new System.Drawing.Size(40, 25);
            this.lbTongThu.TabIndex = 34;
            this.lbTongThu.Text = "0 đ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(12, 399);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Tổng thu:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SlateGray;
            this.label8.Location = new System.Drawing.Point(513, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 45);
            this.label8.TabIndex = 35;
            this.label8.Text = "*Phí thay đổi là:\r\n 374k với chặng bay nội địa\r\n 800k với chặng bay quốc tế";
            // 
            // frmDoiChuyenBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(731, 473);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbTongThu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvChuyenBayMoi);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lbGiaCu);
            this.Controls.Add(this.lbSanBay);
            this.Controls.Add(this.lbChuyenBayCu);
            this.Controls.Add(this.lbVeCu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiChuyenBay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi chuyến bay";
            this.Load += new System.EventHandler(this.frmDoiChuyenBay_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenBayMoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbVeCu;
        private System.Windows.Forms.Label lbChuyenBayCu;
        private System.Windows.Forms.Label lbSanBay;
        private System.Windows.Forms.Label lbGiaCu;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2ComboBox cbSanBayDen;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2ComboBox cbSanBayDi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayDi;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvChuyenBayMoi;
        private System.Windows.Forms.Label lbTongThu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}