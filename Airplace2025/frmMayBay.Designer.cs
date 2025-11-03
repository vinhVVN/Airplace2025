namespace Airplace2025
{
    partial class frmMayBay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbTim = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnAddAirplane = new System.Windows.Forms.PictureBox();
            this.txtAirplaneId = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSeat = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbThoiGianBay = new System.Windows.Forms.Label();
            this.lbGiaCoBan = new System.Windows.Forms.Label();
            this.txtAirplaneName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbSanBayDi = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.cbHangBay = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvAirplane = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaMayBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMayBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHangBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHangBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Logo = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnAddAirline = new System.Windows.Forms.PictureBox();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAirlineId = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDescrip = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAirlineName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbTim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAirplane)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirplane)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAirline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTim
            // 
            this.gbTim.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbTim.BorderRadius = 8;
            this.gbTim.Controls.Add(this.btnAddAirplane);
            this.gbTim.Controls.Add(this.txtAirplaneId);
            this.gbTim.Controls.Add(this.txtSeat);
            this.gbTim.Controls.Add(this.lbThoiGianBay);
            this.gbTim.Controls.Add(this.lbGiaCoBan);
            this.gbTim.Controls.Add(this.txtAirplaneName);
            this.gbTim.Controls.Add(this.lbSanBayDi);
            this.gbTim.CustomBorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gbTim.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTim.ForeColor = System.Drawing.Color.Black;
            this.gbTim.Location = new System.Drawing.Point(19, 128);
            this.gbTim.Name = "gbTim";
            this.gbTim.Size = new System.Drawing.Size(423, 166);
            this.gbTim.TabIndex = 2;
            this.gbTim.Text = "Thông tin máy bay";
            // 
            // btnAddAirplane
            // 
            this.btnAddAirplane.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddAirplane.Image = global::Airplace2025.Properties.Resources.add_square_512x512;
            this.btnAddAirplane.Location = new System.Drawing.Point(374, 8);
            this.btnAddAirplane.Name = "btnAddAirplane";
            this.btnAddAirplane.Size = new System.Drawing.Size(37, 25);
            this.btnAddAirplane.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddAirplane.TabIndex = 34;
            this.btnAddAirplane.TabStop = false;
            this.btnAddAirplane.Click += new System.EventHandler(this.btnAddAirplane_Click);
            // 
            // txtAirplaneId
            // 
            this.txtAirplaneId.BorderRadius = 6;
            this.txtAirplaneId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAirplaneId.DefaultText = "";
            this.txtAirplaneId.Enabled = false;
            this.txtAirplaneId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAirplaneId.Location = new System.Drawing.Point(96, 48);
            this.txtAirplaneId.Name = "txtAirplaneId";
            this.txtAirplaneId.PlaceholderText = "";
            this.txtAirplaneId.SelectedText = "";
            this.txtAirplaneId.Size = new System.Drawing.Size(143, 25);
            this.txtAirplaneId.TabIndex = 12;
            // 
            // txtSeat
            // 
            this.txtSeat.BorderRadius = 6;
            this.txtSeat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSeat.DefaultText = "";
            this.txtSeat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSeat.Location = new System.Drawing.Point(65, 124);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.PlaceholderText = "";
            this.txtSeat.SelectedText = "";
            this.txtSeat.Size = new System.Drawing.Size(71, 25);
            this.txtSeat.TabIndex = 10;
            // 
            // lbThoiGianBay
            // 
            this.lbThoiGianBay.AutoSize = true;
            this.lbThoiGianBay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThoiGianBay.ForeColor = System.Drawing.Color.Black;
            this.lbThoiGianBay.Location = new System.Drawing.Point(9, 127);
            this.lbThoiGianBay.Name = "lbThoiGianBay";
            this.lbThoiGianBay.Size = new System.Drawing.Size(52, 17);
            this.lbThoiGianBay.TabIndex = 9;
            this.lbThoiGianBay.Text = "Số ghế:";
            // 
            // lbGiaCoBan
            // 
            this.lbGiaCoBan.AutoSize = true;
            this.lbGiaCoBan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiaCoBan.ForeColor = System.Drawing.Color.Black;
            this.lbGiaCoBan.Location = new System.Drawing.Point(9, 89);
            this.lbGiaCoBan.Name = "lbGiaCoBan";
            this.lbGiaCoBan.Size = new System.Drawing.Size(84, 17);
            this.lbGiaCoBan.TabIndex = 6;
            this.lbGiaCoBan.Text = "Tên máy bay:";
            // 
            // txtAirplaneName
            // 
            this.txtAirplaneName.BorderRadius = 6;
            this.txtAirplaneName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAirplaneName.DefaultText = "";
            this.txtAirplaneName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAirplaneName.Location = new System.Drawing.Point(98, 85);
            this.txtAirplaneName.Name = "txtAirplaneName";
            this.txtAirplaneName.PlaceholderText = "";
            this.txtAirplaneName.SelectedText = "";
            this.txtAirplaneName.Size = new System.Drawing.Size(191, 25);
            this.txtAirplaneName.TabIndex = 0;
            // 
            // lbSanBayDi
            // 
            this.lbSanBayDi.AutoSize = true;
            this.lbSanBayDi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSanBayDi.ForeColor = System.Drawing.Color.Black;
            this.lbSanBayDi.Location = new System.Drawing.Point(9, 53);
            this.lbSanBayDi.Name = "lbSanBayDi";
            this.lbSanBayDi.Size = new System.Drawing.Size(83, 17);
            this.lbSanBayDi.TabIndex = 3;
            this.lbSanBayDi.Text = "Mã máy bay:";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.guna2GroupBox1.BorderRadius = 8;
            this.guna2GroupBox1.Controls.Add(this.btnFind);
            this.guna2GroupBox1.Controls.Add(this.cbHangBay);
            this.guna2GroupBox1.Controls.Add(this.label6);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(19, 12);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(423, 93);
            this.guna2GroupBox1.TabIndex = 12;
            this.guna2GroupBox1.Text = "Tìm kiếm máy bay";
            // 
            // btnFind
            // 
            this.btnFind.BorderRadius = 6;
            this.btnFind.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(311, 51);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(93, 26);
            this.btnFind.TabIndex = 27;
            this.btnFind.Text = "Tìm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cbHangBay
            // 
            this.cbHangBay.BackColor = System.Drawing.Color.Transparent;
            this.cbHangBay.BorderRadius = 6;
            this.cbHangBay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHangBay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHangBay.FocusedColor = System.Drawing.Color.Empty;
            this.cbHangBay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbHangBay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbHangBay.ItemHeight = 20;
            this.cbHangBay.Location = new System.Drawing.Point(87, 51);
            this.cbHangBay.Name = "cbHangBay";
            this.cbHangBay.Size = new System.Drawing.Size(202, 26);
            this.cbHangBay.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Hãng bay:";
            // 
            // dgvAirplane
            // 
            this.dgvAirplane.AllowUserToAddRows = false;
            this.dgvAirplane.AllowUserToDeleteRows = false;
            this.dgvAirplane.AllowUserToResizeColumns = false;
            this.dgvAirplane.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAirplane.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAirplane.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAirplane.ColumnHeadersHeight = 50;
            this.dgvAirplane.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMayBay,
            this.TenMayBay,
            this.SoGhe,
            this.MaHangBay,
            this.TenHangBay,
            this.MoTa,
            this.Logo,
            this.btnEdit,
            this.btnDel});
            this.dgvAirplane.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAirplane.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAirplane.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvAirplane.Location = new System.Drawing.Point(451, 14);
            this.dgvAirplane.Name = "dgvAirplane";
            this.dgvAirplane.ReadOnly = true;
            this.dgvAirplane.RowHeadersVisible = false;
            this.dgvAirplane.RowHeadersWidth = 123;
            this.dgvAirplane.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAirplane.RowTemplate.Height = 60;
            this.dgvAirplane.Size = new System.Drawing.Size(737, 529);
            this.dgvAirplane.TabIndex = 32;
            this.dgvAirplane.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAirplane.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvAirplane.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvAirplane.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.dgvAirplane.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAirplane.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvAirplane.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvAirplane.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.dgvAirplane.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAirplane.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvAirplane.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAirplane.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAirplane.ThemeStyle.HeaderStyle.Height = 50;
            this.dgvAirplane.ThemeStyle.ReadOnly = true;
            this.dgvAirplane.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAirplane.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAirplane.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvAirplane.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvAirplane.ThemeStyle.RowsStyle.Height = 60;
            this.dgvAirplane.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.dgvAirplane.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAirplane.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAirplane_CellClick);
            this.dgvAirplane.SelectionChanged += new System.EventHandler(this.dgvAirplane_SelectionChanged);
            // 
            // MaMayBay
            // 
            this.MaMayBay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaMayBay.DataPropertyName = "MaMayBay";
            this.MaMayBay.FillWeight = 123F;
            this.MaMayBay.HeaderText = "Mã máy bay";
            this.MaMayBay.MinimumWidth = 45;
            this.MaMayBay.Name = "MaMayBay";
            this.MaMayBay.ReadOnly = true;
            this.MaMayBay.Width = 80;
            // 
            // TenMayBay
            // 
            this.TenMayBay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenMayBay.DataPropertyName = "TenMayBay";
            this.TenMayBay.HeaderText = "Tên máy bay";
            this.TenMayBay.Name = "TenMayBay";
            this.TenMayBay.ReadOnly = true;
            this.TenMayBay.Width = 150;
            // 
            // SoGhe
            // 
            this.SoGhe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SoGhe.DataPropertyName = "SoGhe";
            this.SoGhe.HeaderText = "Số ghế";
            this.SoGhe.MinimumWidth = 6;
            this.SoGhe.Name = "SoGhe";
            this.SoGhe.ReadOnly = true;
            this.SoGhe.Width = 50;
            // 
            // MaHangBay
            // 
            this.MaHangBay.DataPropertyName = "MaHangBay";
            this.MaHangBay.HeaderText = "Mã Hãng Bay";
            this.MaHangBay.Name = "MaHangBay";
            this.MaHangBay.ReadOnly = true;
            this.MaHangBay.Visible = false;
            // 
            // TenHangBay
            // 
            this.TenHangBay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenHangBay.DataPropertyName = "TenHangBay";
            this.TenHangBay.HeaderText = "Tên Hãng Bay";
            this.TenHangBay.Name = "TenHangBay";
            this.TenHangBay.ReadOnly = true;
            this.TenHangBay.Width = 120;
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô Tả";
            this.MoTa.Name = "MoTa";
            this.MoTa.ReadOnly = true;
            this.MoTa.Visible = false;
            // 
            // Logo
            // 
            this.Logo.DataPropertyName = "Logo";
            this.Logo.HeaderText = "Logo";
            this.Logo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Logo.Name = "Logo";
            this.Logo.ReadOnly = true;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnEdit.HeaderText = "";
            this.btnEdit.Image = global::Airplace2025.Properties.Resources.noun_pen_6860043;
            this.btnEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ReadOnly = true;
            this.btnEdit.Width = 50;
            // 
            // btnDel
            // 
            this.btnDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnDel.HeaderText = "";
            this.btnDel.Image = global::Airplace2025.Properties.Resources.noun_backspace_8069349;
            this.btnDel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.btnDel.Name = "btnDel";
            this.btnDel.ReadOnly = true;
            this.btnDel.Width = 50;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.guna2GroupBox2.BorderRadius = 8;
            this.guna2GroupBox2.Controls.Add(this.btnAddAirline);
            this.guna2GroupBox2.Controls.Add(this.imgLogo);
            this.guna2GroupBox2.Controls.Add(this.label1);
            this.guna2GroupBox2.Controls.Add(this.txtAirlineId);
            this.guna2GroupBox2.Controls.Add(this.txtDescrip);
            this.guna2GroupBox2.Controls.Add(this.label3);
            this.guna2GroupBox2.Controls.Add(this.label4);
            this.guna2GroupBox2.Controls.Add(this.txtAirlineName);
            this.guna2GroupBox2.Controls.Add(this.label5);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox2.Location = new System.Drawing.Point(19, 321);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(423, 222);
            this.guna2GroupBox2.TabIndex = 33;
            this.guna2GroupBox2.Text = "Thông tin hãng bay";
            // 
            // btnAddAirline
            // 
            this.btnAddAirline.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddAirline.Image = global::Airplace2025.Properties.Resources.add_square_512x512;
            this.btnAddAirline.Location = new System.Drawing.Point(371, 9);
            this.btnAddAirline.Name = "btnAddAirline";
            this.btnAddAirline.Size = new System.Drawing.Size(37, 25);
            this.btnAddAirline.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddAirline.TabIndex = 35;
            this.btnAddAirline.TabStop = false;
            this.btnAddAirline.Click += new System.EventHandler(this.btnAddAirline_Click);
            // 
            // imgLogo
            // 
            this.imgLogo.Image = global::Airplace2025.Properties.Resources.pngaaa_com_791768;
            this.imgLogo.Location = new System.Drawing.Point(326, 107);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(66, 58);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogo.TabIndex = 26;
            this.imgLogo.TabStop = false;
            this.imgLogo.DoubleClick += new System.EventHandler(this.imgLogo_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(339, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Logo:";
            // 
            // txtAirlineId
            // 
            this.txtAirlineId.BorderRadius = 6;
            this.txtAirlineId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAirlineId.DefaultText = "";
            this.txtAirlineId.Enabled = false;
            this.txtAirlineId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAirlineId.Location = new System.Drawing.Point(96, 48);
            this.txtAirlineId.Name = "txtAirlineId";
            this.txtAirlineId.PlaceholderText = "";
            this.txtAirlineId.SelectedText = "";
            this.txtAirlineId.Size = new System.Drawing.Size(167, 25);
            this.txtAirlineId.TabIndex = 12;
            // 
            // txtDescrip
            // 
            this.txtDescrip.BorderRadius = 6;
            this.txtDescrip.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescrip.DefaultText = "";
            this.txtDescrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDescrip.Location = new System.Drawing.Point(12, 140);
            this.txtDescrip.Multiline = true;
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.PlaceholderText = "";
            this.txtDescrip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrip.SelectedText = "";
            this.txtDescrip.Size = new System.Drawing.Size(251, 71);
            this.txtDescrip.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mô tả:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên hãng bay:";
            // 
            // txtAirlineName
            // 
            this.txtAirlineName.BorderRadius = 6;
            this.txtAirlineName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAirlineName.DefaultText = "";
            this.txtAirlineName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAirlineName.Location = new System.Drawing.Point(98, 83);
            this.txtAirlineName.Name = "txtAirlineName";
            this.txtAirlineName.PlaceholderText = "";
            this.txtAirlineName.SelectedText = "";
            this.txtAirlineName.Size = new System.Drawing.Size(165, 25);
            this.txtAirlineName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã hãng bay:";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Airplace2025.Properties.Resources.noun_pen_6860043;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::Airplace2025.Properties.Resources.noun_backspace_8069349;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // frmMayBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 555);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.dgvAirplane);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.gbTim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMayBay";
            this.Text = "frmMayBay";
            this.Load += new System.EventHandler(this.frmMayBay_Load);
            this.gbTim.ResumeLayout(false);
            this.gbTim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAirplane)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAirplane)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddAirline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gbTim;
        private Guna.UI2.WinForms.Guna2TextBox txtSeat;
        private System.Windows.Forms.Label lbThoiGianBay;
        private System.Windows.Forms.Label lbGiaCoBan;
        private Guna.UI2.WinForms.Guna2TextBox txtAirplaneName;
        private System.Windows.Forms.Label lbSanBayDi;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtAirplaneId;
        private Guna.UI2.WinForms.Guna2ComboBox cbHangBay;
        private Guna.UI2.WinForms.Guna2DataGridView dgvAirplane;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2TextBox txtAirlineId;
        private Guna.UI2.WinForms.Guna2TextBox txtDescrip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtAirlineName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMayBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMayBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHangBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHangBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.DataGridViewImageColumn Logo;
        private System.Windows.Forms.DataGridViewImageColumn btnEdit;
        private System.Windows.Forms.DataGridViewImageColumn btnDel;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.PictureBox btnAddAirplane;
        private System.Windows.Forms.PictureBox btnAddAirline;
    }
}