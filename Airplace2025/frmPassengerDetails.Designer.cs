namespace Airplace2025
{
    partial class frmPassengerDetails
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
            this.gbPersonal = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbTitle = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtLastName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtMiddleName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.cbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.gbDocument = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbDocType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.txtDocNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.chkPassportExpiry = new System.Windows.Forms.CheckBox();
            this.dtpPassportExpiry = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblPassportExpiry = new System.Windows.Forms.Label();
            this.gbTravel = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbPassengerType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPassengerType = new System.Windows.Forms.Label();
            this.txtNationality = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNationality = new System.Windows.Forms.Label();
            this.txtLoyalty = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLoyalty = new System.Windows.Forms.Label();
            this.gbFlight = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtSeat = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSeat = new System.Windows.Forms.Label();
            this.numAdditionalBaggage = new System.Windows.Forms.NumericUpDown();
            this.lblAdditionalBaggage = new System.Windows.Forms.Label();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.gbPersonal.SuspendLayout();
            this.gbDocument.SuspendLayout();
            this.gbTravel.SuspendLayout();
            this.gbFlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdditionalBaggage)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPersonal
            // 
            this.gbPersonal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbPersonal.BorderRadius = 8;
            this.gbPersonal.Controls.Add(this.cbTitle);
            this.gbPersonal.Controls.Add(this.lblTitle);
            this.gbPersonal.Controls.Add(this.txtLastName);
            this.gbPersonal.Controls.Add(this.lblLastName);
            this.gbPersonal.Controls.Add(this.txtFirstName);
            this.gbPersonal.Controls.Add(this.lblFirstName);
            this.gbPersonal.Controls.Add(this.txtMiddleName);
            this.gbPersonal.Controls.Add(this.lblMiddleName);
            this.gbPersonal.Controls.Add(this.dtpDateOfBirth);
            this.gbPersonal.Controls.Add(this.lblDateOfBirth);
            this.gbPersonal.Controls.Add(this.cbGender);
            this.gbPersonal.Controls.Add(this.lblGender);
            this.gbPersonal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbPersonal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbPersonal.Location = new System.Drawing.Point(10, 10);
            this.gbPersonal.Name = "gbPersonal";
            this.gbPersonal.Size = new System.Drawing.Size(720, 200);
            this.gbPersonal.TabIndex = 0;
            this.gbPersonal.Text = "Thông tin cá nhân";
            // 
            // cbTitle
            // 
            this.cbTitle.BackColor = System.Drawing.Color.Transparent;
            this.cbTitle.BorderRadius = 6;
            this.cbTitle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTitle.FocusedColor = System.Drawing.Color.Empty;
            this.cbTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTitle.ItemHeight = 30;
            this.cbTitle.Location = new System.Drawing.Point(100, 45);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(100, 36);
            this.cbTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(10, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(68, 15);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Danh xưng:";
            // 
            // txtLastName
            // 
            this.txtLastName.BorderRadius = 6;
            this.txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastName.DefaultText = "";
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLastName.Location = new System.Drawing.Point(270, 45);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderText = "Họ";
            this.txtLastName.SelectedText = "";
            this.txtLastName.Size = new System.Drawing.Size(220, 30);
            this.txtLastName.TabIndex = 1;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(210, 50);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(26, 15);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Họ:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderRadius = 6;
            this.txtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFirstName.DefaultText = "";
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFirstName.Location = new System.Drawing.Point(540, 45);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderText = "Tên";
            this.txtFirstName.SelectedText = "";
            this.txtFirstName.Size = new System.Drawing.Size(170, 30);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(495, 50);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(28, 15);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "Tên:";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BorderRadius = 6;
            this.txtMiddleName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMiddleName.DefaultText = "";
            this.txtMiddleName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMiddleName.Location = new System.Drawing.Point(100, 89);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.PlaceholderText = "Tên đệm";
            this.txtMiddleName.SelectedText = "";
            this.txtMiddleName.Size = new System.Drawing.Size(220, 30);
            this.txtMiddleName.TabIndex = 3;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Location = new System.Drawing.Point(10, 94);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(55, 15);
            this.lblMiddleName.TabIndex = 4;
            this.lblMiddleName.Text = "Tên đệm:";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.BorderRadius = 6;
            this.dtpDateOfBirth.Checked = true;
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(400, 89);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(160, 30);
            this.dtpDateOfBirth.TabIndex = 4;
            this.dtpDateOfBirth.Value = new System.DateTime(2025, 10, 24, 10, 43, 18, 1);
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(325, 94);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(63, 15);
            this.lblDateOfBirth.TabIndex = 5;
            this.lblDateOfBirth.Text = "Ngày sinh:";
            // 
            // cbGender
            // 
            this.cbGender.BackColor = System.Drawing.Color.Transparent;
            this.cbGender.BorderRadius = 6;
            this.cbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FocusedColor = System.Drawing.Color.Empty;
            this.cbGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbGender.ItemHeight = 30;
            this.cbGender.Location = new System.Drawing.Point(630, 89);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(80, 36);
            this.cbGender.TabIndex = 5;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(570, 94);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(55, 15);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Giới tính:";
            // 
            // gbDocument
            // 
            this.gbDocument.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbDocument.BorderRadius = 8;
            this.gbDocument.Controls.Add(this.cbDocType);
            this.gbDocument.Controls.Add(this.lblDocType);
            this.gbDocument.Controls.Add(this.txtDocNumber);
            this.gbDocument.Controls.Add(this.lblDocNumber);
            this.gbDocument.Controls.Add(this.chkPassportExpiry);
            this.gbDocument.Controls.Add(this.dtpPassportExpiry);
            this.gbDocument.Controls.Add(this.lblPassportExpiry);
            this.gbDocument.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbDocument.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbDocument.Location = new System.Drawing.Point(10, 215);
            this.gbDocument.Name = "gbDocument";
            this.gbDocument.Size = new System.Drawing.Size(720, 100);
            this.gbDocument.TabIndex = 1;
            this.gbDocument.Text = "Thông tin tài liệu";
            // 
            // cbDocType
            // 
            this.cbDocType.BackColor = System.Drawing.Color.Transparent;
            this.cbDocType.BorderRadius = 6;
            this.cbDocType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDocType.FocusedColor = System.Drawing.Color.Empty;
            this.cbDocType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbDocType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbDocType.ItemHeight = 30;
            this.cbDocType.Location = new System.Drawing.Point(120, 45);
            this.cbDocType.Name = "cbDocType";
            this.cbDocType.Size = new System.Drawing.Size(150, 36);
            this.cbDocType.TabIndex = 0;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(10, 50);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(70, 15);
            this.lblDocType.TabIndex = 1;
            this.lblDocType.Text = "Loại tài liệu:";
            // 
            // txtDocNumber
            // 
            this.txtDocNumber.BorderRadius = 6;
            this.txtDocNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDocNumber.DefaultText = "";
            this.txtDocNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDocNumber.Location = new System.Drawing.Point(360, 45);
            this.txtDocNumber.Name = "txtDocNumber";
            this.txtDocNumber.PlaceholderText = "Số tài liệu";
            this.txtDocNumber.SelectedText = "";
            this.txtDocNumber.Size = new System.Drawing.Size(180, 30);
            this.txtDocNumber.TabIndex = 1;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(275, 50);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(61, 15);
            this.lblDocNumber.TabIndex = 2;
            this.lblDocNumber.Text = "Số tài liệu:";
            // 
            // chkPassportExpiry
            // 
            this.chkPassportExpiry.AutoSize = true;
            this.chkPassportExpiry.Location = new System.Drawing.Point(545, 76);
            this.chkPassportExpiry.Name = "chkPassportExpiry";
            this.chkPassportExpiry.Size = new System.Drawing.Size(71, 19);
            this.chkPassportExpiry.TabIndex = 2;
            this.chkPassportExpiry.Text = "Hết hạn:";
            this.chkPassportExpiry.UseVisualStyleBackColor = true;
            // 
            // dtpPassportExpiry
            // 
            this.dtpPassportExpiry.BorderRadius = 6;
            this.dtpPassportExpiry.Checked = true;
            this.dtpPassportExpiry.Enabled = false;
            this.dtpPassportExpiry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpPassportExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPassportExpiry.Location = new System.Drawing.Point(630, 45);
            this.dtpPassportExpiry.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpPassportExpiry.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPassportExpiry.Name = "dtpPassportExpiry";
            this.dtpPassportExpiry.Size = new System.Drawing.Size(80, 30);
            this.dtpPassportExpiry.TabIndex = 3;
            this.dtpPassportExpiry.Value = new System.DateTime(2025, 10, 24, 10, 43, 18, 92);
            // 
            // lblPassportExpiry
            // 
            this.lblPassportExpiry.AutoSize = true;
            this.lblPassportExpiry.Location = new System.Drawing.Point(545, 50);
            this.lblPassportExpiry.Name = "lblPassportExpiry";
            this.lblPassportExpiry.Size = new System.Drawing.Size(81, 15);
            this.lblPassportExpiry.TabIndex = 4;
            this.lblPassportExpiry.Text = "Ngày hết hạn:";
            // 
            // gbTravel
            // 
            this.gbTravel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbTravel.BorderRadius = 8;
            this.gbTravel.Controls.Add(this.cbPassengerType);
            this.gbTravel.Controls.Add(this.lblPassengerType);
            this.gbTravel.Controls.Add(this.txtNationality);
            this.gbTravel.Controls.Add(this.lblNationality);
            this.gbTravel.Controls.Add(this.txtLoyalty);
            this.gbTravel.Controls.Add(this.lblLoyalty);
            this.gbTravel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbTravel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbTravel.Location = new System.Drawing.Point(10, 320);
            this.gbTravel.Name = "gbTravel";
            this.gbTravel.Size = new System.Drawing.Size(720, 100);
            this.gbTravel.TabIndex = 2;
            this.gbTravel.Text = "Thông tin chuyến bay";
            // 
            // cbPassengerType
            // 
            this.cbPassengerType.BackColor = System.Drawing.Color.Transparent;
            this.cbPassengerType.BorderRadius = 6;
            this.cbPassengerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPassengerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPassengerType.FocusedColor = System.Drawing.Color.Empty;
            this.cbPassengerType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbPassengerType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbPassengerType.ItemHeight = 30;
            this.cbPassengerType.Location = new System.Drawing.Point(130, 45);
            this.cbPassengerType.Name = "cbPassengerType";
            this.cbPassengerType.Size = new System.Drawing.Size(200, 36);
            this.cbPassengerType.TabIndex = 0;
            // 
            // lblPassengerType
            // 
            this.lblPassengerType.AutoSize = true;
            this.lblPassengerType.Location = new System.Drawing.Point(10, 50);
            this.lblPassengerType.Name = "lblPassengerType";
            this.lblPassengerType.Size = new System.Drawing.Size(97, 15);
            this.lblPassengerType.TabIndex = 1;
            this.lblPassengerType.Text = "Loại hành khách:";
            // 
            // txtNationality
            // 
            this.txtNationality.BorderRadius = 6;
            this.txtNationality.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNationality.DefaultText = "";
            this.txtNationality.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNationality.Location = new System.Drawing.Point(420, 45);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.PlaceholderText = "VN";
            this.txtNationality.SelectedText = "";
            this.txtNationality.Size = new System.Drawing.Size(50, 30);
            this.txtNationality.TabIndex = 1;
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(335, 50);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(62, 15);
            this.lblNationality.TabIndex = 2;
            this.lblNationality.Text = "Quốc tịch:";
            // 
            // txtLoyalty
            // 
            this.txtLoyalty.BorderRadius = 6;
            this.txtLoyalty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLoyalty.DefaultText = "";
            this.txtLoyalty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLoyalty.Location = new System.Drawing.Point(540, 45);
            this.txtLoyalty.Name = "txtLoyalty";
            this.txtLoyalty.PlaceholderText = "FFP #";
            this.txtLoyalty.SelectedText = "";
            this.txtLoyalty.Size = new System.Drawing.Size(170, 30);
            this.txtLoyalty.TabIndex = 2;
            // 
            // lblLoyalty
            // 
            this.lblLoyalty.AutoSize = true;
            this.lblLoyalty.Location = new System.Drawing.Point(475, 50);
            this.lblLoyalty.Name = "lblLoyalty";
            this.lblLoyalty.Size = new System.Drawing.Size(48, 15);
            this.lblLoyalty.TabIndex = 3;
            this.lblLoyalty.Text = "Loyalty:";
            // 
            // gbFlight
            // 
            this.gbFlight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbFlight.BorderRadius = 8;
            this.gbFlight.Controls.Add(this.txtSeat);
            this.gbFlight.Controls.Add(this.lblSeat);
            this.gbFlight.Controls.Add(this.numAdditionalBaggage);
            this.gbFlight.Controls.Add(this.lblAdditionalBaggage);
            this.gbFlight.Controls.Add(this.txtNotes);
            this.gbFlight.Controls.Add(this.lblNotes);
            this.gbFlight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbFlight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbFlight.Location = new System.Drawing.Point(10, 425);
            this.gbFlight.Name = "gbFlight";
            this.gbFlight.Size = new System.Drawing.Size(720, 120);
            this.gbFlight.TabIndex = 3;
            this.gbFlight.Text = "Thông tin chuyến bay (chi tiết)";
            // 
            // txtSeat
            // 
            this.txtSeat.BorderRadius = 6;
            this.txtSeat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSeat.DefaultText = "";
            this.txtSeat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSeat.Location = new System.Drawing.Point(80, 44);
            this.txtSeat.Name = "txtSeat";
            this.txtSeat.PlaceholderText = "1A";
            this.txtSeat.SelectedText = "";
            this.txtSeat.Size = new System.Drawing.Size(100, 30);
            this.txtSeat.TabIndex = 0;
            // 
            // lblSeat
            // 
            this.lblSeat.AutoSize = true;
            this.lblSeat.Location = new System.Drawing.Point(10, 49);
            this.lblSeat.Name = "lblSeat";
            this.lblSeat.Size = new System.Drawing.Size(31, 15);
            this.lblSeat.TabIndex = 1;
            this.lblSeat.Text = "Ghế:";
            // 
            // numAdditionalBaggage
            // 
            this.numAdditionalBaggage.Location = new System.Drawing.Point(315, 44);
            this.numAdditionalBaggage.Name = "numAdditionalBaggage";
            this.numAdditionalBaggage.Size = new System.Drawing.Size(100, 23);
            this.numAdditionalBaggage.TabIndex = 1;
            // 
            // lblAdditionalBaggage
            // 
            this.lblAdditionalBaggage.AutoSize = true;
            this.lblAdditionalBaggage.Location = new System.Drawing.Point(190, 49);
            this.lblAdditionalBaggage.Name = "lblAdditionalBaggage";
            this.lblAdditionalBaggage.Size = new System.Drawing.Size(106, 15);
            this.lblAdditionalBaggage.TabIndex = 2;
            this.lblAdditionalBaggage.Text = "Hành lý thêm (kg):";
            // 
            // txtNotes
            // 
            this.txtNotes.BorderRadius = 6;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.Location = new System.Drawing.Point(80, 74);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PlaceholderText = "Ghi chú";
            this.txtNotes.SelectedText = "";
            this.txtNotes.Size = new System.Drawing.Size(630, 40);
            this.txtNotes.TabIndex = 2;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(10, 79);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(51, 15);
            this.lblNotes.TabIndex = 3;
            this.lblNotes.Text = "Ghi chú:";
            // 
            // btnLuu
            // 
            this.btnLuu.BorderRadius = 6;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(400, 555);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 35);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BorderRadius = 6;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(560, 555);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(150, 35);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmPassengerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 600);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.gbFlight);
            this.Controls.Add(this.gbTravel);
            this.Controls.Add(this.gbDocument);
            this.Controls.Add(this.gbPersonal);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPassengerDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin hành khách";
            this.gbPersonal.ResumeLayout(false);
            this.gbPersonal.PerformLayout();
            this.gbDocument.ResumeLayout(false);
            this.gbDocument.PerformLayout();
            this.gbTravel.ResumeLayout(false);
            this.gbTravel.PerformLayout();
            this.gbFlight.ResumeLayout(false);
            this.gbFlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdditionalBaggage)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2GroupBox gbPersonal;
        private Guna.UI2.WinForms.Guna2ComboBox cbTitle;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private Guna.UI2.WinForms.Guna2TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private Guna.UI2.WinForms.Guna2TextBox txtMiddleName;
        private System.Windows.Forms.Label lblMiddleName;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblDateOfBirth;
        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
        private System.Windows.Forms.Label lblGender;

        private Guna.UI2.WinForms.Guna2GroupBox gbDocument;
        private Guna.UI2.WinForms.Guna2ComboBox cbDocType;
        private System.Windows.Forms.Label lblDocType;
        private Guna.UI2.WinForms.Guna2TextBox txtDocNumber;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.CheckBox chkPassportExpiry;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpPassportExpiry;
        private System.Windows.Forms.Label lblPassportExpiry;

        private Guna.UI2.WinForms.Guna2GroupBox gbTravel;
        private Guna.UI2.WinForms.Guna2ComboBox cbPassengerType;
        private System.Windows.Forms.Label lblPassengerType;
        private Guna.UI2.WinForms.Guna2TextBox txtNationality;
        private System.Windows.Forms.Label lblNationality;
        private Guna.UI2.WinForms.Guna2TextBox txtLoyalty;
        private System.Windows.Forms.Label lblLoyalty;

        private Guna.UI2.WinForms.Guna2GroupBox gbFlight;
        private Guna.UI2.WinForms.Guna2TextBox txtSeat;
        private System.Windows.Forms.Label lblSeat;
        private System.Windows.Forms.NumericUpDown numAdditionalBaggage;
        private System.Windows.Forms.Label lblAdditionalBaggage;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;

        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
    }
}
