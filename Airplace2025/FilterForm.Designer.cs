namespace Airplace2025
{
    partial class FilterForm
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
            this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnApply = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.lblFlightCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.scrollPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlAirlines = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAirlines = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlFlightTime = new Guna.UI2.WinForms.Guna2Panel();
            this.rbArrivalEvening = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbArrivalAfternoon = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbArrivalMorning = new Guna.UI2.WinForms.Guna2RadioButton();
            this.pnlGioDi = new System.Windows.Forms.Panel();
            this.rbDepartureEvening = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbDepartureAfternoon = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbDepartureMorning = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbDepartureAny = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblDepartureTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.rbArrivalAny = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblArrivalTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFlightTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlStops = new Guna.UI2.WinForms.Guna2Panel();
            this.rbDirectOnly = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbNoStop = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblStops = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlBudget = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMaxPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMinPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.trackBudget = new Guna.UI2.WinForms.Guna2TrackBar();
            this.lblBudget = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboKhoang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblKhoang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.vScrollBar = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.chkAllAirlines = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkPacificAirlines = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkVietnamAirlines = new Guna.UI2.WinForms.Guna2CheckBox();
            this.mainPanel.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.pnlAirlines.SuspendLayout();
            this.pnlFlightTime.SuspendLayout();
            this.pnlGioDi.SuspendLayout();
            this.pnlStops.SuspendLayout();
            this.pnlBudget.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BorderRadius = 15;
            this.mainPanel.Controls.Add(this.btnApply);
            this.mainPanel.Controls.Add(this.btnReset);
            this.mainPanel.Controls.Add(this.lblFlightCount);
            this.mainPanel.Controls.Add(this.scrollPanel);
            this.mainPanel.Controls.Add(this.btnClose);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.vScrollBar);
            this.mainPanel.FillColor = System.Drawing.Color.White;
            this.mainPanel.Location = new System.Drawing.Point(20, 20);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(360, 560);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // btnApply
            // 
            this.btnApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.BorderRadius = 8;
            this.btnApply.BorderThickness = 3;
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApply.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApply.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApply.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApply.FillColor = System.Drawing.SystemColors.Control;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(185, 510);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(140, 40);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "ÁP DỤNG";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnReset
            // 
            this.btnReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.btnReset.BorderRadius = 8;
            this.btnReset.BorderThickness = 3;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnReset.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.btnReset.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.btnReset.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnReset.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnReset.Location = new System.Drawing.Point(15, 510);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(140, 40);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "THIẾT LẬP LẠI";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblFlightCount
            // 
            this.lblFlightCount.BackColor = System.Drawing.Color.Transparent;
            this.lblFlightCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightCount.ForeColor = System.Drawing.Color.Gray;
            this.lblFlightCount.Location = new System.Drawing.Point(189, 492);
            this.lblFlightCount.Name = "lblFlightCount";
            this.lblFlightCount.Size = new System.Drawing.Size(136, 17);
            this.lblFlightCount.TabIndex = 3;
            this.lblFlightCount.Text = "Có 19 trên 19 chuyến bay";
            // 
            // scrollPanel
            // 
            this.scrollPanel.BackColor = System.Drawing.Color.White;
            this.scrollPanel.Controls.Add(this.pnlAirlines);
            this.scrollPanel.Controls.Add(this.pnlFlightTime);
            this.scrollPanel.Controls.Add(this.pnlStops);
            this.scrollPanel.Controls.Add(this.pnlBudget);
            this.scrollPanel.Controls.Add(this.cboKhoang);
            this.scrollPanel.Controls.Add(this.lblKhoang);
            this.scrollPanel.Location = new System.Drawing.Point(15, 60);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(310, 430);
            this.scrollPanel.TabIndex = 2;
            // 
            // pnlAirlines
            // 
            this.pnlAirlines.Controls.Add(this.chkVietnamAirlines);
            this.pnlAirlines.Controls.Add(this.chkPacificAirlines);
            this.pnlAirlines.Controls.Add(this.chkAllAirlines);
            this.pnlAirlines.Controls.Add(this.lblAirlines);
            this.pnlAirlines.Location = new System.Drawing.Point(0, 660);
            this.pnlAirlines.Name = "pnlAirlines";
            this.pnlAirlines.Size = new System.Drawing.Size(300, 140);
            this.pnlAirlines.TabIndex = 5;
            // 
            // lblAirlines
            // 
            this.lblAirlines.BackColor = System.Drawing.Color.Transparent;
            this.lblAirlines.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirlines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblAirlines.Location = new System.Drawing.Point(10, 10);
            this.lblAirlines.Name = "lblAirlines";
            this.lblAirlines.Size = new System.Drawing.Size(114, 19);
            this.lblAirlines.TabIndex = 0;
            this.lblAirlines.Text = "Hãng hàng không";
            // 
            // pnlFlightTime
            // 
            this.pnlFlightTime.Controls.Add(this.rbArrivalEvening);
            this.pnlFlightTime.Controls.Add(this.rbArrivalAfternoon);
            this.pnlFlightTime.Controls.Add(this.rbArrivalMorning);
            this.pnlFlightTime.Controls.Add(this.pnlGioDi);
            this.pnlFlightTime.Controls.Add(this.rbArrivalAny);
            this.pnlFlightTime.Controls.Add(this.lblArrivalTime);
            this.pnlFlightTime.Controls.Add(this.guna2HtmlLabel2);
            this.pnlFlightTime.Controls.Add(this.lblFlightTime);
            this.pnlFlightTime.Location = new System.Drawing.Point(0, 315);
            this.pnlFlightTime.Name = "pnlFlightTime";
            this.pnlFlightTime.Size = new System.Drawing.Size(300, 373);
            this.pnlFlightTime.TabIndex = 4;
            // 
            // rbArrivalEvening
            // 
            this.rbArrivalEvening.AutoSize = true;
            this.rbArrivalEvening.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbArrivalEvening.CheckedState.BorderThickness = 0;
            this.rbArrivalEvening.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbArrivalEvening.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbArrivalEvening.CheckedState.InnerOffset = -4;
            this.rbArrivalEvening.Location = new System.Drawing.Point(10, 305);
            this.rbArrivalEvening.Name = "rbArrivalEvening";
            this.rbArrivalEvening.Size = new System.Drawing.Size(106, 17);
            this.rbArrivalEvening.TabIndex = 12;
            this.rbArrivalEvening.Text = "18:00 - 23:59 Tối";
            this.rbArrivalEvening.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbArrivalEvening.UncheckedState.BorderThickness = 2;
            this.rbArrivalEvening.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbArrivalEvening.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbArrivalAfternoon
            // 
            this.rbArrivalAfternoon.AutoSize = true;
            this.rbArrivalAfternoon.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbArrivalAfternoon.CheckedState.BorderThickness = 0;
            this.rbArrivalAfternoon.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbArrivalAfternoon.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbArrivalAfternoon.CheckedState.InnerOffset = -4;
            this.rbArrivalAfternoon.Location = new System.Drawing.Point(10, 275);
            this.rbArrivalAfternoon.Name = "rbArrivalAfternoon";
            this.rbArrivalAfternoon.Size = new System.Drawing.Size(118, 17);
            this.rbArrivalAfternoon.TabIndex = 11;
            this.rbArrivalAfternoon.Text = "12:00 - 17:59 Chiều";
            this.rbArrivalAfternoon.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbArrivalAfternoon.UncheckedState.BorderThickness = 2;
            this.rbArrivalAfternoon.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbArrivalAfternoon.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbArrivalMorning
            // 
            this.rbArrivalMorning.AutoSize = true;
            this.rbArrivalMorning.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbArrivalMorning.CheckedState.BorderThickness = 0;
            this.rbArrivalMorning.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbArrivalMorning.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbArrivalMorning.CheckedState.InnerOffset = -4;
            this.rbArrivalMorning.Location = new System.Drawing.Point(10, 245);
            this.rbArrivalMorning.Name = "rbArrivalMorning";
            this.rbArrivalMorning.Size = new System.Drawing.Size(116, 17);
            this.rbArrivalMorning.TabIndex = 10;
            this.rbArrivalMorning.Text = "00:00 - 11:59 Sáng";
            this.rbArrivalMorning.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbArrivalMorning.UncheckedState.BorderThickness = 2;
            this.rbArrivalMorning.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbArrivalMorning.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // pnlGioDi
            // 
            this.pnlGioDi.Controls.Add(this.rbDepartureEvening);
            this.pnlGioDi.Controls.Add(this.rbDepartureAfternoon);
            this.pnlGioDi.Controls.Add(this.rbDepartureMorning);
            this.pnlGioDi.Controls.Add(this.rbDepartureAny);
            this.pnlGioDi.Controls.Add(this.lblDepartureTime);
            this.pnlGioDi.Location = new System.Drawing.Point(7, 43);
            this.pnlGioDi.Name = "pnlGioDi";
            this.pnlGioDi.Size = new System.Drawing.Size(200, 148);
            this.pnlGioDi.TabIndex = 9;
            // 
            // rbDepartureEvening
            // 
            this.rbDepartureEvening.AutoSize = true;
            this.rbDepartureEvening.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDepartureEvening.CheckedState.BorderThickness = 0;
            this.rbDepartureEvening.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDepartureEvening.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbDepartureEvening.CheckedState.InnerOffset = -4;
            this.rbDepartureEvening.Location = new System.Drawing.Point(3, 116);
            this.rbDepartureEvening.Name = "rbDepartureEvening";
            this.rbDepartureEvening.Size = new System.Drawing.Size(106, 17);
            this.rbDepartureEvening.TabIndex = 11;
            this.rbDepartureEvening.Text = "18:00 - 23:59 Tối";
            this.rbDepartureEvening.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDepartureEvening.UncheckedState.BorderThickness = 2;
            this.rbDepartureEvening.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDepartureEvening.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbDepartureAfternoon
            // 
            this.rbDepartureAfternoon.AutoSize = true;
            this.rbDepartureAfternoon.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDepartureAfternoon.CheckedState.BorderThickness = 0;
            this.rbDepartureAfternoon.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDepartureAfternoon.Location = new System.Drawing.Point(3, 86);
            this.rbDepartureAfternoon.Name = "rbDepartureAfternoon";
            this.rbDepartureAfternoon.Size = new System.Drawing.Size(112, 17);
            this.rbDepartureAfternoon.TabIndex = 10;
            this.rbDepartureAfternoon.Text = "2:00 - 17:59 Chiều";
            this.rbDepartureAfternoon.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDepartureAfternoon.UncheckedState.BorderThickness = 2;
            this.rbDepartureAfternoon.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDepartureAfternoon.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbDepartureMorning
            // 
            this.rbDepartureMorning.AutoSize = true;
            this.rbDepartureMorning.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDepartureMorning.CheckedState.BorderThickness = 0;
            this.rbDepartureMorning.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDepartureMorning.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbDepartureMorning.CheckedState.InnerOffset = -4;
            this.rbDepartureMorning.Location = new System.Drawing.Point(3, 56);
            this.rbDepartureMorning.Name = "rbDepartureMorning";
            this.rbDepartureMorning.Size = new System.Drawing.Size(116, 17);
            this.rbDepartureMorning.TabIndex = 9;
            this.rbDepartureMorning.Text = "00:00 - 11:59 Sáng";
            this.rbDepartureMorning.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDepartureMorning.UncheckedState.BorderThickness = 2;
            this.rbDepartureMorning.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDepartureMorning.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbDepartureAny
            // 
            this.rbDepartureAny.AutoSize = true;
            this.rbDepartureAny.Checked = true;
            this.rbDepartureAny.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDepartureAny.CheckedState.BorderThickness = 0;
            this.rbDepartureAny.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDepartureAny.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbDepartureAny.CheckedState.InnerOffset = -4;
            this.rbDepartureAny.Location = new System.Drawing.Point(3, 26);
            this.rbDepartureAny.Name = "rbDepartureAny";
            this.rbDepartureAny.Size = new System.Drawing.Size(115, 17);
            this.rbDepartureAny.TabIndex = 8;
            this.rbDepartureAny.TabStop = true;
            this.rbDepartureAny.Text = "Không có tùy chọn";
            this.rbDepartureAny.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDepartureAny.UncheckedState.BorderThickness = 2;
            this.rbDepartureAny.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDepartureAny.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // lblDepartureTime
            // 
            this.lblDepartureTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartureTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureTime.Location = new System.Drawing.Point(3, 1);
            this.lblDepartureTime.Name = "lblDepartureTime";
            this.lblDepartureTime.Size = new System.Drawing.Size(81, 17);
            this.lblDepartureTime.TabIndex = 7;
            this.lblDepartureTime.Text = "Giờ khởi hành";
            // 
            // rbArrivalAny
            // 
            this.rbArrivalAny.AutoSize = true;
            this.rbArrivalAny.Checked = true;
            this.rbArrivalAny.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.rbArrivalAny.CheckedState.BorderThickness = 0;
            this.rbArrivalAny.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.rbArrivalAny.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbArrivalAny.CheckedState.InnerOffset = -4;
            this.rbArrivalAny.Location = new System.Drawing.Point(10, 215);
            this.rbArrivalAny.Name = "rbArrivalAny";
            this.rbArrivalAny.Size = new System.Drawing.Size(115, 17);
            this.rbArrivalAny.TabIndex = 8;
            this.rbArrivalAny.TabStop = true;
            this.rbArrivalAny.Text = "Không có tùy chọn";
            this.rbArrivalAny.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbArrivalAny.UncheckedState.BorderThickness = 2;
            this.rbArrivalAny.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbArrivalAny.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // lblArrivalTime
            // 
            this.lblArrivalTime.BackColor = System.Drawing.Color.Transparent;
            this.lblArrivalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalTime.Location = new System.Drawing.Point(10, 190);
            this.lblArrivalTime.Name = "lblArrivalTime";
            this.lblArrivalTime.Size = new System.Drawing.Size(53, 17);
            this.lblArrivalTime.TabIndex = 7;
            this.lblArrivalTime.Text = "Giờ đến";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(0, 0);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel2.TabIndex = 0;
            this.guna2HtmlLabel2.Text = null;
            // 
            // lblFlightTime
            // 
            this.lblFlightTime.BackColor = System.Drawing.Color.Transparent;
            this.lblFlightTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.lblFlightTime.Location = new System.Drawing.Point(10, 10);
            this.lblFlightTime.Name = "lblFlightTime";
            this.lblFlightTime.Size = new System.Drawing.Size(88, 19);
            this.lblFlightTime.TabIndex = 0;
            this.lblFlightTime.Text = "Thời gian bay";
            // 
            // pnlStops
            // 
            this.pnlStops.Controls.Add(this.rbDirectOnly);
            this.pnlStops.Controls.Add(this.rbNoStop);
            this.pnlStops.Controls.Add(this.lblStops);
            this.pnlStops.Location = new System.Drawing.Point(0, 205);
            this.pnlStops.Name = "pnlStops";
            this.pnlStops.Size = new System.Drawing.Size(300, 100);
            this.pnlStops.TabIndex = 3;
            // 
            // rbDirectOnly
            // 
            this.rbDirectOnly.AutoSize = true;
            this.rbDirectOnly.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDirectOnly.CheckedState.BorderThickness = 0;
            this.rbDirectOnly.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDirectOnly.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbDirectOnly.CheckedState.InnerOffset = -4;
            this.rbDirectOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDirectOnly.Location = new System.Drawing.Point(10, 70);
            this.rbDirectOnly.Name = "rbDirectOnly";
            this.rbDirectOnly.Size = new System.Drawing.Size(143, 17);
            this.rbDirectOnly.TabIndex = 3;
            this.rbDirectOnly.Text = "Chỉ có chuyến bay thẳng";
            this.rbDirectOnly.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDirectOnly.UncheckedState.BorderThickness = 2;
            this.rbDirectOnly.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDirectOnly.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbNoStop
            // 
            this.rbNoStop.AutoSize = true;
            this.rbNoStop.Checked = true;
            this.rbNoStop.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbNoStop.CheckedState.BorderThickness = 0;
            this.rbNoStop.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbNoStop.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbNoStop.CheckedState.InnerOffset = -4;
            this.rbNoStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbNoStop.Location = new System.Drawing.Point(10, 45);
            this.rbNoStop.Name = "rbNoStop";
            this.rbNoStop.Size = new System.Drawing.Size(115, 17);
            this.rbNoStop.TabIndex = 2;
            this.rbNoStop.TabStop = true;
            this.rbNoStop.Text = "Không có tùy chọn";
            this.rbNoStop.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbNoStop.UncheckedState.BorderThickness = 2;
            this.rbNoStop.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbNoStop.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // lblStops
            // 
            this.lblStops.BackColor = System.Drawing.Color.Transparent;
            this.lblStops.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStops.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.lblStops.Location = new System.Drawing.Point(11, 18);
            this.lblStops.Name = "lblStops";
            this.lblStops.Size = new System.Drawing.Size(141, 19);
            this.lblStops.TabIndex = 0;
            this.lblStops.Text = "Số sân bay nối chuyến";
            // 
            // pnlBudget
            // 
            this.pnlBudget.Controls.Add(this.lblMaxPrice);
            this.pnlBudget.Controls.Add(this.lblMinPrice);
            this.pnlBudget.Controls.Add(this.trackBudget);
            this.pnlBudget.Controls.Add(this.lblBudget);
            this.pnlBudget.Location = new System.Drawing.Point(0, 75);
            this.pnlBudget.Name = "pnlBudget";
            this.pnlBudget.Size = new System.Drawing.Size(300, 120);
            this.pnlBudget.TabIndex = 2;
            // 
            // lblMaxPrice
            // 
            this.lblMaxPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblMaxPrice.Location = new System.Drawing.Point(180, 80);
            this.lblMaxPrice.Name = "lblMaxPrice";
            this.lblMaxPrice.Size = new System.Drawing.Size(87, 17);
            this.lblMaxPrice.TabIndex = 4;
            this.lblMaxPrice.Text = "8.776.000 VND";
            // 
            // lblMinPrice
            // 
            this.lblMinPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblMinPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPrice.Location = new System.Drawing.Point(10, 80);
            this.lblMinPrice.Name = "lblMinPrice";
            this.lblMinPrice.Size = new System.Drawing.Size(87, 17);
            this.lblMinPrice.TabIndex = 3;
            this.lblMinPrice.Text = "3.063.000 VND";
            // 
            // trackBudget
            // 
            this.trackBudget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBudget.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.trackBudget.Location = new System.Drawing.Point(10, 50);
            this.trackBudget.Maximum = 8776;
            this.trackBudget.Minimum = 3063;
            this.trackBudget.Name = "trackBudget";
            this.trackBudget.Size = new System.Drawing.Size(270, 23);
            this.trackBudget.TabIndex = 2;
            this.trackBudget.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.trackBudget.Value = 3063;
            this.trackBudget.ValueChanged += new System.EventHandler(this.trackBudget_ValueChanged);
            this.trackBudget.Scroll += new System.Windows.Forms.ScrollEventHandler(this.trackBudget_Scroll);
            // 
            // lblBudget
            // 
            this.lblBudget.BackColor = System.Drawing.Color.Transparent;
            this.lblBudget.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblBudget.Location = new System.Drawing.Point(10, 10);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(67, 19);
            this.lblBudget.TabIndex = 0;
            this.lblBudget.Text = "Ngân sách";
            // 
            // cboKhoang
            // 
            this.cboKhoang.BackColor = System.Drawing.Color.Transparent;
            this.cboKhoang.BorderRadius = 8;
            this.cboKhoang.BorderThickness = 3;
            this.cboKhoang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboKhoang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboKhoang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoang.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboKhoang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboKhoang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboKhoang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboKhoang.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.cboKhoang.ItemHeight = 30;
            this.cboKhoang.Items.AddRange(new object[] {
            "Tất cả",
            "PHỔ THÔNG",
            "PHỔ THÔNG ĐẶC BIỆT",
            "THƯƠNG GIA"});
            this.cboKhoang.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.cboKhoang.Location = new System.Drawing.Point(10, 25);
            this.cboKhoang.Name = "cboKhoang";
            this.cboKhoang.Size = new System.Drawing.Size(280, 36);
            this.cboKhoang.StartIndex = 0;
            this.cboKhoang.TabIndex = 1;
            // 
            // lblKhoang
            // 
            this.lblKhoang.BackColor = System.Drawing.Color.Transparent;
            this.lblKhoang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoang.Location = new System.Drawing.Point(10, 0);
            this.lblKhoang.Name = "lblKhoang";
            this.lblKhoang.Size = new System.Drawing.Size(44, 17);
            this.lblKhoang.TabIndex = 0;
            this.lblKhoang.Text = "Khoang";
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 17;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(305, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(74, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bộ lọc";
            // 
            // vScrollBar
            // 
            this.vScrollBar.BorderRadius = 7;
            this.vScrollBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.vScrollBar.InUpdate = false;
            this.vScrollBar.LargeChange = 10;
            this.vScrollBar.Location = new System.Drawing.Point(330, 60);
            this.vScrollBar.Maximum = 400;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.ScrollbarSize = 15;
            this.vScrollBar.Size = new System.Drawing.Size(15, 430);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // chkAllAirlines
            // 
            this.chkAllAirlines.AutoSize = true;
            this.chkAllAirlines.Checked = true;
            this.chkAllAirlines.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.chkAllAirlines.CheckedState.BorderRadius = 0;
            this.chkAllAirlines.CheckedState.BorderThickness = 0;
            this.chkAllAirlines.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.chkAllAirlines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllAirlines.Location = new System.Drawing.Point(10, 45);
            this.chkAllAirlines.Name = "chkAllAirlines";
            this.chkAllAirlines.Size = new System.Drawing.Size(189, 17);
            this.chkAllAirlines.TabIndex = 1;
            this.chkAllAirlines.Text = "Chọn tất cả các hãng hàng không";
            this.chkAllAirlines.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAllAirlines.UncheckedState.BorderRadius = 0;
            this.chkAllAirlines.UncheckedState.BorderThickness = 0;
            this.chkAllAirlines.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAllAirlines.CheckedChanged += new System.EventHandler(this.chkAllAirlines_CheckedChanged);
            // 
            // chkPacificAirlines
            // 
            this.chkPacificAirlines.AutoSize = true;
            this.chkPacificAirlines.Checked = true;
            this.chkPacificAirlines.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.chkPacificAirlines.CheckedState.BorderRadius = 0;
            this.chkPacificAirlines.CheckedState.BorderThickness = 0;
            this.chkPacificAirlines.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.chkPacificAirlines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPacificAirlines.Location = new System.Drawing.Point(10, 75);
            this.chkPacificAirlines.Name = "chkPacificAirlines";
            this.chkPacificAirlines.Size = new System.Drawing.Size(94, 17);
            this.chkPacificAirlines.TabIndex = 2;
            this.chkPacificAirlines.Text = "Pacific Airlines";
            this.chkPacificAirlines.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkPacificAirlines.UncheckedState.BorderRadius = 0;
            this.chkPacificAirlines.UncheckedState.BorderThickness = 0;
            this.chkPacificAirlines.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkVietnamAirlines
            // 
            this.chkVietnamAirlines.AutoSize = true;
            this.chkVietnamAirlines.Checked = true;
            this.chkVietnamAirlines.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.chkVietnamAirlines.CheckedState.BorderRadius = 0;
            this.chkVietnamAirlines.CheckedState.BorderThickness = 0;
            this.chkVietnamAirlines.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.chkVietnamAirlines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVietnamAirlines.Location = new System.Drawing.Point(10, 105);
            this.chkVietnamAirlines.Name = "chkVietnamAirlines";
            this.chkVietnamAirlines.Size = new System.Drawing.Size(100, 17);
            this.chkVietnamAirlines.TabIndex = 3;
            this.chkVietnamAirlines.Text = "Vietnam Airlines";
            this.chkVietnamAirlines.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkVietnamAirlines.UncheckedState.BorderRadius = 0;
            this.chkVietnamAirlines.UncheckedState.BorderThickness = 0;
            this.chkVietnamAirlines.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilterForm";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FilterForm_Paint);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            this.pnlAirlines.ResumeLayout(false);
            this.pnlAirlines.PerformLayout();
            this.pnlFlightTime.ResumeLayout(false);
            this.pnlFlightTime.PerformLayout();
            this.pnlGioDi.ResumeLayout(false);
            this.pnlGioDi.PerformLayout();
            this.pnlStops.ResumeLayout(false);
            this.pnlStops.PerformLayout();
            this.pnlBudget.ResumeLayout(false);
            this.pnlBudget.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Panel scrollPanel;
        private Guna.UI2.WinForms.Guna2VScrollBar vScrollBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFlightCount;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Button btnApply;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKhoang;
        private Guna.UI2.WinForms.Guna2ComboBox cboKhoang;
        private Guna.UI2.WinForms.Guna2Panel pnlBudget;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBudget;
        private Guna.UI2.WinForms.Guna2TrackBar trackBudget;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMinPrice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaxPrice;
        private Guna.UI2.WinForms.Guna2Panel pnlStops;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStops;
        private Guna.UI2.WinForms.Guna2RadioButton rbNoStop;
        private Guna.UI2.WinForms.Guna2RadioButton rbDirectOnly;
        private Guna.UI2.WinForms.Guna2Panel pnlFlightTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFlightTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArrivalTime;
        private Guna.UI2.WinForms.Guna2RadioButton rbArrivalAny;
        private System.Windows.Forms.Panel pnlGioDi;
        private Guna.UI2.WinForms.Guna2RadioButton rbDepartureEvening;
        private Guna.UI2.WinForms.Guna2RadioButton rbDepartureAfternoon;
        private Guna.UI2.WinForms.Guna2RadioButton rbDepartureMorning;
        private Guna.UI2.WinForms.Guna2RadioButton rbDepartureAny;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDepartureTime;
        private Guna.UI2.WinForms.Guna2RadioButton rbArrivalMorning;
        private Guna.UI2.WinForms.Guna2RadioButton rbArrivalAfternoon;
        private Guna.UI2.WinForms.Guna2RadioButton rbArrivalEvening;
        private Guna.UI2.WinForms.Guna2Panel pnlAirlines;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAirlines;
        private Guna.UI2.WinForms.Guna2CheckBox chkAllAirlines;
        private Guna.UI2.WinForms.Guna2CheckBox chkPacificAirlines;
        private Guna.UI2.WinForms.Guna2CheckBox chkVietnamAirlines;
    }
}