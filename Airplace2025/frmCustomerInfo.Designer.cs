namespace Airplace2025
{
    partial class frmCustomerInfo
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirmAll = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDanhXung = new System.Windows.Forms.Label();
            this.lblHo = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.cmbDanhXung = new System.Windows.Forms.ComboBox();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.chkIsRepresentative = new System.Windows.Forms.CheckBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchInstruction = new System.Windows.Forms.Label();
            this.grpPassengerList = new System.Windows.Forms.GroupBox();
            this.lstPassengers = new System.Windows.Forms.ListBox();
            this.pnlHeader.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.grpPassengerList.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1184, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(290, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Controls.Add(this.btnConfirmAll);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 601);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(1184, 60);
            this.pnlActions.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(1052, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnConfirmAll
            // 
            this.btnConfirmAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnConfirmAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmAll.FlatAppearance.BorderSize = 0;
            this.btnConfirmAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmAll.ForeColor = System.Drawing.Color.White;
            this.btnConfirmAll.Location = new System.Drawing.Point(880, 10);
            this.btnConfirmAll.Name = "btnConfirmAll";
            this.btnConfirmAll.Size = new System.Drawing.Size(160, 40);
            this.btnConfirmAll.TabIndex = 0;
            this.btnConfirmAll.Text = "Xác nhận đặt vé";
            this.btnConfirmAll.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.grpPassengerList);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(1184, 541);
            this.pnlMain.TabIndex = 5;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grpInfo);
            this.pnlRight.Controls.Add(this.dgvCustomers);
            this.pnlRight.Controls.Add(this.grpSearch);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(260, 10);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlRight.Size = new System.Drawing.Size(914, 521);
            this.pnlRight.TabIndex = 1;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.tableLayoutPanel1);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInfo.Location = new System.Drawing.Point(10, 240);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(904, 281);
            this.grpInfo.TabIndex = 6;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Thông tin chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblDanhXung, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTen, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNgaySinh, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbDanhXung, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTen, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpNgaySinh, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSDT, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSDT, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCCCD, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCCCD, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDiaChi, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDiaChi, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkIsRepresentative, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(898, 200);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblDanhXung
            // 
            this.lblDanhXung.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDanhXung.AutoSize = true;
            this.lblDanhXung.Location = new System.Drawing.Point(3, 10);
            this.lblDanhXung.Name = "lblDanhXung";
            this.lblDanhXung.Size = new System.Drawing.Size(79, 19);
            this.lblDanhXung.TabIndex = 0;
            this.lblDanhXung.Text = "Danh xưng:";
            // 
            // lblHo
            // 
            this.lblHo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHo.AutoSize = true;
            this.lblHo.Location = new System.Drawing.Point(3, 50);
            this.lblHo.Name = "lblHo";
            this.lblHo.Size = new System.Drawing.Size(30, 19);
            this.lblHo.TabIndex = 1;
            this.lblHo.Text = "Họ:";
            // 
            // lblTen
            // 
            this.lblTen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTen.AutoSize = true;
            this.lblTen.Location = new System.Drawing.Point(452, 50);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(106, 19);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên đệm và tên:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(452, 10);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(73, 19);
            this.lblNgaySinh.TabIndex = 3;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // cmbDanhXung
            // 
            this.cmbDanhXung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDanhXung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDanhXung.FormattingEnabled = true;
            this.cmbDanhXung.Items.AddRange(new object[] {
            "Ông",
            "Bà",
            "Cô",
            "Anh",
            "Chị",
            "Bé trai",
            "Bé gái"});
            this.cmbDanhXung.Location = new System.Drawing.Point(123, 9);
            this.cmbDanhXung.Name = "cmbDanhXung";
            this.cmbDanhXung.Size = new System.Drawing.Size(323, 25);
            this.cmbDanhXung.TabIndex = 0;
            // 
            // txtHo
            // 
            this.txtHo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHo.Location = new System.Drawing.Point(123, 47);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(323, 25);
            this.txtHo.TabIndex = 2;
            // 
            // txtTen
            // 
            this.txtTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTen.Location = new System.Drawing.Point(572, 47);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(323, 25);
            this.txtTen.TabIndex = 3;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(572, 7);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(323, 25);
            this.dtpNgaySinh.TabIndex = 1;
            // 
            // lblSDT
            // 
            this.lblSDT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(3, 90);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(92, 19);
            this.lblSDT.TabIndex = 8;
            this.lblSDT.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSDT.Location = new System.Drawing.Point(123, 87);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(323, 25);
            this.txtSDT.TabIndex = 4;
            // 
            // lblCCCD
            // 
            this.lblCCCD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new System.Drawing.Point(452, 90);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(96, 19);
            this.lblCCCD.TabIndex = 10;
            this.lblCCCD.Text = "CCCD/CMND:";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCCCD.Location = new System.Drawing.Point(572, 87);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(323, 25);
            this.txtCCCD.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(3, 130);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 19);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(123, 127);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(323, 25);
            this.txtEmail.TabIndex = 6;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(452, 130);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(53, 19);
            this.lblDiaChi.TabIndex = 14;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Location = new System.Drawing.Point(572, 127);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(323, 25);
            this.txtDiaChi.TabIndex = 7;
            // 
            // chkIsRepresentative
            // 
            this.chkIsRepresentative.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIsRepresentative.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkIsRepresentative, 3);
            this.chkIsRepresentative.ForeColor = System.Drawing.Color.Red;
            this.chkIsRepresentative.Location = new System.Drawing.Point(123, 168);
            this.chkIsRepresentative.Name = "chkIsRepresentative";
            this.chkIsRepresentative.Size = new System.Drawing.Size(177, 23);
            this.chkIsRepresentative.TabIndex = 15;
            this.chkIsRepresentative.Text = "Là người đại diện liên hệ";
            this.chkIsRepresentative.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCustomers.Location = new System.Drawing.Point(10, 90);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomers.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(904, 150);
            this.dgvCustomers.TabIndex = 5;
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.lblSearchInstruction);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearch.Location = new System.Drawing.Point(10, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(904, 90);
            this.grpSearch.TabIndex = 4;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Tìm kiếm khách hàng";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(550, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 32);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(230, 36);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 27);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearchInstruction
            // 
            this.lblSearchInstruction.AutoSize = true;
            this.lblSearchInstruction.Location = new System.Drawing.Point(20, 39);
            this.lblSearchInstruction.Name = "lblSearchInstruction";
            this.lblSearchInstruction.Size = new System.Drawing.Size(194, 19);
            this.lblSearchInstruction.TabIndex = 0;
            this.lblSearchInstruction.Text = "Nhập SĐT hoặc CCCD/CMND:";
            // 
            // grpPassengerList
            // 
            this.grpPassengerList.Controls.Add(this.lstPassengers);
            this.grpPassengerList.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpPassengerList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPassengerList.Location = new System.Drawing.Point(10, 10);
            this.grpPassengerList.Name = "grpPassengerList";
            this.grpPassengerList.Size = new System.Drawing.Size(250, 521);
            this.grpPassengerList.TabIndex = 0;
            this.grpPassengerList.TabStop = false;
            this.grpPassengerList.Text = "Danh sách hành khách";
            // 
            // lstPassengers
            // 
            this.lstPassengers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPassengers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstPassengers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPassengers.FormattingEnabled = true;
            this.lstPassengers.ItemHeight = 40;
            this.lstPassengers.Location = new System.Drawing.Point(3, 21);
            this.lstPassengers.Name = "lstPassengers";
            this.lstPassengers.Size = new System.Drawing.Size(244, 497);
            this.lstPassengers.TabIndex = 0;
            // 
            // frmCustomerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmCustomerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin khách hàng";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpPassengerList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirmAll;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpPassengerList;
        private System.Windows.Forms.ListBox lstPassengers;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchInstruction;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDanhXung;
        private System.Windows.Forms.Label lblHo;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.ComboBox cmbDanhXung;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.CheckBox chkIsRepresentative;
    }
}