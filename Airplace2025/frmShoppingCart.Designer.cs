namespace Airplace2025
{
    partial class frmShoppingCart
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
            this.mainScrollPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.containerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlArriveFlight = new Guna.UI2.WinForms.Guna2Panel();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.detailsLink = new System.Windows.Forms.LinkLabel();
            this.airlineLabel = new System.Windows.Forms.Label();
            this.durationTime = new System.Windows.Forms.Label();
            this.clockIcon = new System.Windows.Forms.Label();
            this.arrTerminalLabel = new System.Windows.Forms.Label();
            this.arrCodeLabel = new System.Windows.Forms.Label();
            this.arrTimeLabel = new System.Windows.Forms.Label();
            this.linePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.durationLabel = new System.Windows.Forms.Label();
            this.depTerminalLabel = new System.Windows.Forms.Label();
            this.depCodeLabel = new System.Windows.Forms.Label();
            this.depTimeLabel = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblRoute1 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.expandBtn = new System.Windows.Forms.Button();
            this.detailsPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.detailsTitle = new System.Windows.Forms.Label();
            this.timelinePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.circleEnd = new Guna.UI2.WinForms.Guna2CircleButton();
            this.circleStart = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblArrivalTerminal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblArrivalAirport = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNextDay = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblArrivalTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDepartureTerminal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDepartureAirport = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDepartureTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFlightDuration = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timelineLine = new System.Windows.Forms.Panel();
            this.lblFlightNumberTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAirline = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAircraft = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.fareDetailsTitle = new System.Windows.Forms.Label();
            this.fareType = new System.Windows.Forms.Label();
            this.mainScrollPanel.SuspendLayout();
            this.containerPanel.SuspendLayout();
            this.pnlArriveFlight.SuspendLayout();
            this.detailsPanel.SuspendLayout();
            this.timelinePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainScrollPanel
            // 
            this.mainScrollPanel.AutoScroll = true;
            this.mainScrollPanel.Controls.Add(this.containerPanel);
            this.mainScrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainScrollPanel.Location = new System.Drawing.Point(0, 0);
            this.mainScrollPanel.Name = "mainScrollPanel";
            this.mainScrollPanel.Size = new System.Drawing.Size(1265, 749);
            this.mainScrollPanel.TabIndex = 0;
            // 
            // containerPanel
            // 
            this.containerPanel.BackColor = System.Drawing.Color.Transparent;
            this.containerPanel.Controls.Add(this.pnlArriveFlight);
            this.containerPanel.Controls.Add(this.titleLabel);
            this.containerPanel.Location = new System.Drawing.Point(20, 20);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(1054, 1400);
            this.containerPanel.TabIndex = 0;
            // 
            // pnlArriveFlight
            // 
            this.pnlArriveFlight.BackColor = System.Drawing.Color.Transparent;
            this.pnlArriveFlight.BorderRadius = 8;
            this.pnlArriveFlight.Controls.Add(this.detailsPanel);
            this.pnlArriveFlight.Controls.Add(this.expandBtn);
            this.pnlArriveFlight.Controls.Add(this.TypeLabel);
            this.pnlArriveFlight.Controls.Add(this.detailsLink);
            this.pnlArriveFlight.Controls.Add(this.airlineLabel);
            this.pnlArriveFlight.Controls.Add(this.durationTime);
            this.pnlArriveFlight.Controls.Add(this.clockIcon);
            this.pnlArriveFlight.Controls.Add(this.arrTerminalLabel);
            this.pnlArriveFlight.Controls.Add(this.arrCodeLabel);
            this.pnlArriveFlight.Controls.Add(this.arrTimeLabel);
            this.pnlArriveFlight.Controls.Add(this.linePanel);
            this.pnlArriveFlight.Controls.Add(this.durationLabel);
            this.pnlArriveFlight.Controls.Add(this.depTerminalLabel);
            this.pnlArriveFlight.Controls.Add(this.depCodeLabel);
            this.pnlArriveFlight.Controls.Add(this.depTimeLabel);
            this.pnlArriveFlight.Controls.Add(this.lblDate);
            this.pnlArriveFlight.Controls.Add(this.lblRoute1);
            this.pnlArriveFlight.FillColor = System.Drawing.Color.White;
            this.pnlArriveFlight.Location = new System.Drawing.Point(20, 70);
            this.pnlArriveFlight.Name = "pnlArriveFlight";
            this.pnlArriveFlight.ShadowDecoration.Depth = 10;
            this.pnlArriveFlight.ShadowDecoration.Enabled = true;
            this.pnlArriveFlight.Size = new System.Drawing.Size(1000, 453);
            this.pnlArriveFlight.TabIndex = 1;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.TypeLabel.Location = new System.Drawing.Point(750, 15);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(76, 17);
            this.TypeLabel.TabIndex = 14;
            this.TypeLabel.Text = "Phổ Thông";
            // 
            // detailsLink
            // 
            this.detailsLink.AutoSize = true;
            this.detailsLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(170)))));
            this.detailsLink.Location = new System.Drawing.Point(530, 120);
            this.detailsLink.Name = "detailsLink";
            this.detailsLink.Size = new System.Drawing.Size(118, 15);
            this.detailsLink.TabIndex = 13;
            this.detailsLink.TabStop = true;
            this.detailsLink.Text = "Chi tiết hành trình ⧉";
            // 
            // airlineLabel
            // 
            this.airlineLabel.AutoSize = true;
            this.airlineLabel.Location = new System.Drawing.Point(533, 101);
            this.airlineLabel.Name = "airlineLabel";
            this.airlineLabel.Size = new System.Drawing.Size(223, 15);
            this.airlineLabel.TabIndex = 12;
            this.airlineLabel.Text = " ✈️ VN 205 khai thác bởi Vietname Airline";
            // 
            // durationTime
            // 
            this.durationTime.AutoSize = true;
            this.durationTime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationTime.Location = new System.Drawing.Point(555, 68);
            this.durationTime.Name = "durationTime";
            this.durationTime.Size = new System.Drawing.Size(133, 13);
            this.durationTime.TabIndex = 11;
            this.durationTime.Text = "Thời gian bay 2h 10phút";
            // 
            // clockIcon
            // 
            this.clockIcon.AutoSize = true;
            this.clockIcon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockIcon.Location = new System.Drawing.Point(530, 65);
            this.clockIcon.Name = "clockIcon";
            this.clockIcon.Size = new System.Drawing.Size(26, 17);
            this.clockIcon.TabIndex = 10;
            this.clockIcon.Text = "🕐";
            // 
            // arrTerminalLabel
            // 
            this.arrTerminalLabel.AutoSize = true;
            this.arrTerminalLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrTerminalLabel.ForeColor = System.Drawing.Color.Gray;
            this.arrTerminalLabel.Location = new System.Drawing.Point(420, 120);
            this.arrTerminalLabel.Name = "arrTerminalLabel";
            this.arrTerminalLabel.Size = new System.Drawing.Size(53, 13);
            this.arrTerminalLabel.TabIndex = 9;
            this.arrTerminalLabel.Text = "Nhà ga 1";
            // 
            // arrCodeLabel
            // 
            this.arrCodeLabel.AutoSize = true;
            this.arrCodeLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrCodeLabel.Location = new System.Drawing.Point(420, 95);
            this.arrCodeLabel.Name = "arrCodeLabel";
            this.arrCodeLabel.Size = new System.Drawing.Size(43, 20);
            this.arrCodeLabel.TabIndex = 8;
            this.arrCodeLabel.Text = "HAN";
            // 
            // arrTimeLabel
            // 
            this.arrTimeLabel.AutoSize = true;
            this.arrTimeLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrTimeLabel.Location = new System.Drawing.Point(420, 60);
            this.arrTimeLabel.Name = "arrTimeLabel";
            this.arrTimeLabel.Size = new System.Drawing.Size(67, 30);
            this.arrTimeLabel.TabIndex = 7;
            this.arrTimeLabel.Text = "07:05";
            // 
            // linePanel
            // 
            this.linePanel.FillColor = System.Drawing.Color.LightGray;
            this.linePanel.Location = new System.Drawing.Point(180, 75);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(200, 2);
            this.linePanel.TabIndex = 6;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationLabel.ForeColor = System.Drawing.Color.Gray;
            this.durationLabel.Location = new System.Drawing.Point(230, 55);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(58, 13);
            this.durationLabel.TabIndex = 5;
            this.durationLabel.Text = "Bay thẳng";
            this.durationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // depTerminalLabel
            // 
            this.depTerminalLabel.AutoSize = true;
            this.depTerminalLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depTerminalLabel.ForeColor = System.Drawing.Color.Gray;
            this.depTerminalLabel.Location = new System.Drawing.Point(20, 120);
            this.depTerminalLabel.Name = "depTerminalLabel";
            this.depTerminalLabel.Size = new System.Drawing.Size(53, 13);
            this.depTerminalLabel.TabIndex = 4;
            this.depTerminalLabel.Text = "Nhà ga 3";
            // 
            // depCodeLabel
            // 
            this.depCodeLabel.AutoSize = true;
            this.depCodeLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depCodeLabel.Location = new System.Drawing.Point(20, 95);
            this.depCodeLabel.Name = "depCodeLabel";
            this.depCodeLabel.Size = new System.Drawing.Size(40, 20);
            this.depCodeLabel.TabIndex = 3;
            this.depCodeLabel.Text = "SGN";
            // 
            // depTimeLabel
            // 
            this.depTimeLabel.AutoSize = true;
            this.depTimeLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depTimeLabel.Location = new System.Drawing.Point(20, 60);
            this.depTimeLabel.Name = "depTimeLabel";
            this.depTimeLabel.Size = new System.Drawing.Size(67, 30);
            this.depTimeLabel.TabIndex = 2;
            this.depTimeLabel.Text = "04:55";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ForeColor = System.Drawing.Color.Gray;
            this.lblDate.Location = new System.Drawing.Point(250, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(140, 15);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Thứ Ba, 18 tháng 11, 2025";
            // 
            // lblRoute1
            // 
            this.lblRoute1.AutoSize = true;
            this.lblRoute1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute1.Location = new System.Drawing.Point(20, 15);
            this.lblRoute1.Name = "lblRoute1";
            this.lblRoute1.Size = new System.Drawing.Size(201, 20);
            this.lblRoute1.TabIndex = 0;
            this.lblRoute1.Text = "TP. Hồ Chí Minh đến Hà Nội";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.titleLabel.Location = new System.Drawing.Point(20, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(191, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Các chuyến bay";
            // 
            // expandBtn
            // 
            this.expandBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.expandBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expandBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.expandBtn.Location = new System.Drawing.Point(950, 10);
            this.expandBtn.Name = "expandBtn";
            this.expandBtn.Size = new System.Drawing.Size(30, 30);
            this.expandBtn.TabIndex = 15;
            this.expandBtn.Text = "˅";
            this.expandBtn.UseVisualStyleBackColor = true;
            // 
            // detailsPanel
            // 
            this.detailsPanel.BorderRadius = 5;
            this.detailsPanel.Controls.Add(this.fareType);
            this.detailsPanel.Controls.Add(this.fareDetailsTitle);
            this.detailsPanel.Controls.Add(this.timelinePanel);
            this.detailsPanel.Controls.Add(this.detailsTitle);
            this.detailsPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.detailsPanel.Location = new System.Drawing.Point(20, 160);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(960, 293);
            this.detailsPanel.TabIndex = 16;
            // 
            // detailsTitle
            // 
            this.detailsTitle.AutoSize = true;
            this.detailsTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.detailsTitle.Location = new System.Drawing.Point(125, 10);
            this.detailsTitle.Name = "detailsTitle";
            this.detailsTitle.Size = new System.Drawing.Size(122, 17);
            this.detailsTitle.TabIndex = 0;
            this.detailsTitle.Text = "Chi tiết hành trình";
            // 
            // timelinePanel
            // 
            this.timelinePanel.BorderRadius = 10;
            this.timelinePanel.Controls.Add(this.lblAircraft);
            this.timelinePanel.Controls.Add(this.lblFlightNumberTitle);
            this.timelinePanel.Controls.Add(this.lblAirline);
            this.timelinePanel.Controls.Add(this.circleEnd);
            this.timelinePanel.Controls.Add(this.circleStart);
            this.timelinePanel.Controls.Add(this.lblArrivalTerminal);
            this.timelinePanel.Controls.Add(this.lblArrivalAirport);
            this.timelinePanel.Controls.Add(this.lblNextDay);
            this.timelinePanel.Controls.Add(this.lblArrivalTime);
            this.timelinePanel.Controls.Add(this.lblDepartureTerminal);
            this.timelinePanel.Controls.Add(this.lblDepartureAirport);
            this.timelinePanel.Controls.Add(this.lblDepartureTime);
            this.timelinePanel.Controls.Add(this.lblFlightDuration);
            this.timelinePanel.Controls.Add(this.timelineLine);
            this.timelinePanel.FillColor = System.Drawing.Color.Transparent;
            this.timelinePanel.Location = new System.Drawing.Point(18, 30);
            this.timelinePanel.Name = "timelinePanel";
            this.timelinePanel.Size = new System.Drawing.Size(360, 257);
            this.timelinePanel.TabIndex = 6;
            // 
            // circleEnd
            // 
            this.circleEnd.BackColor = System.Drawing.Color.Transparent;
            this.circleEnd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.circleEnd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.circleEnd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.circleEnd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.circleEnd.Enabled = false;
            this.circleEnd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.circleEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.circleEnd.ForeColor = System.Drawing.Color.White;
            this.circleEnd.Location = new System.Drawing.Point(103, 164);
            this.circleEnd.Name = "circleEnd";
            this.circleEnd.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.circleEnd.Size = new System.Drawing.Size(16, 16);
            this.circleEnd.TabIndex = 10;
            this.circleEnd.Text = "guna2CircleButton1";
            // 
            // circleStart
            // 
            this.circleStart.BackColor = System.Drawing.Color.Transparent;
            this.circleStart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.circleStart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.circleStart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.circleStart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.circleStart.Enabled = false;
            this.circleStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(128)))));
            this.circleStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.circleStart.ForeColor = System.Drawing.Color.White;
            this.circleStart.Location = new System.Drawing.Point(103, 20);
            this.circleStart.Name = "circleStart";
            this.circleStart.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.circleStart.Size = new System.Drawing.Size(16, 16);
            this.circleStart.TabIndex = 9;
            this.circleStart.Text = "guna2CircleButton1";
            // 
            // lblArrivalTerminal
            // 
            this.lblArrivalTerminal.BackColor = System.Drawing.Color.Transparent;
            this.lblArrivalTerminal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblArrivalTerminal.Location = new System.Drawing.Point(125, 158);
            this.lblArrivalTerminal.Name = "lblArrivalTerminal";
            this.lblArrivalTerminal.Size = new System.Drawing.Size(47, 15);
            this.lblArrivalTerminal.TabIndex = 8;
            this.lblArrivalTerminal.Text = "Nhà ga 3";
            // 
            // lblArrivalAirport
            // 
            this.lblArrivalAirport.BackColor = System.Drawing.Color.Transparent;
            this.lblArrivalAirport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalAirport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblArrivalAirport.Location = new System.Drawing.Point(125, 135);
            this.lblArrivalAirport.Name = "lblArrivalAirport";
            this.lblArrivalAirport.Size = new System.Drawing.Size(229, 23);
            this.lblArrivalAirport.TabIndex = 7;
            this.lblArrivalAirport.Text = "Sân bay Tân Sơn Nhất, Việt Nam";
            // 
            // lblNextDay
            // 
            this.lblNextDay.BackColor = System.Drawing.Color.Transparent;
            this.lblNextDay.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.lblNextDay.Location = new System.Drawing.Point(125, 115);
            this.lblNextDay.Name = "lblNextDay";
            this.lblNextDay.Size = new System.Drawing.Size(51, 15);
            this.lblNextDay.TabIndex = 6;
            this.lblNextDay.Text = "(+1 ngày)";
            // 
            // lblArrivalTime
            // 
            this.lblArrivalTime.BackColor = System.Drawing.Color.Transparent;
            this.lblArrivalTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.lblArrivalTime.Location = new System.Drawing.Point(125, 90);
            this.lblArrivalTime.Name = "lblArrivalTime";
            this.lblArrivalTime.Size = new System.Drawing.Size(169, 23);
            this.lblArrivalTime.TabIndex = 5;
            this.lblArrivalTime.Text = "01:10 TP. Hồ Chí Minh";
            // 
            // lblDepartureTerminal
            // 
            this.lblDepartureTerminal.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartureTerminal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureTerminal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblDepartureTerminal.Location = new System.Drawing.Point(125, 60);
            this.lblDepartureTerminal.Name = "lblDepartureTerminal";
            this.lblDepartureTerminal.Size = new System.Drawing.Size(49, 15);
            this.lblDepartureTerminal.TabIndex = 4;
            this.lblDepartureTerminal.Text = "Nhà ga 1";
            // 
            // lblDepartureAirport
            // 
            this.lblDepartureAirport.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartureAirport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureAirport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblDepartureAirport.Location = new System.Drawing.Point(125, 37);
            this.lblDepartureAirport.Name = "lblDepartureAirport";
            this.lblDepartureAirport.Size = new System.Drawing.Size(184, 23);
            this.lblDepartureAirport.TabIndex = 3;
            this.lblDepartureAirport.Text = "Sân bay Nội Bài, Việt Nam";
            // 
            // lblDepartureTime
            // 
            this.lblDepartureTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartureTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.lblDepartureTime.Location = new System.Drawing.Point(125, 15);
            this.lblDepartureTime.Name = "lblDepartureTime";
            this.lblDepartureTime.Size = new System.Drawing.Size(104, 23);
            this.lblDepartureTime.TabIndex = 2;
            this.lblDepartureTime.Text = "23:00 HÀ NỘI";
            // 
            // lblFlightDuration
            // 
            this.lblFlightDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblFlightDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightDuration.Location = new System.Drawing.Point(42, 85);
            this.lblFlightDuration.Name = "lblFlightDuration";
            this.lblFlightDuration.Size = new System.Drawing.Size(44, 32);
            this.lblFlightDuration.TabIndex = 1;
            this.lblFlightDuration.Text = "2 giờ 10<br>phút";
            this.lblFlightDuration.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timelineLine
            // 
            this.timelineLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.timelineLine.Location = new System.Drawing.Point(110, 20);
            this.timelineLine.Name = "timelineLine";
            this.timelineLine.Size = new System.Drawing.Size(3, 160);
            this.timelineLine.TabIndex = 0;
            // 
            // lblFlightNumberTitle
            // 
            this.lblFlightNumberTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFlightNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightNumberTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblFlightNumberTitle.Location = new System.Drawing.Point(10, 186);
            this.lblFlightNumberTitle.Name = "lblFlightNumberTitle";
            this.lblFlightNumberTitle.Size = new System.Drawing.Size(160, 17);
            this.lblFlightNumberTitle.TabIndex = 11;
            this.lblFlightNumberTitle.Text = "Số hiệu chuyến bay VN 6025";
            // 
            // lblAirline
            // 
            this.lblAirline.BackColor = System.Drawing.Color.Transparent;
            this.lblAirline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblAirline.Location = new System.Drawing.Point(10, 209);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(167, 17);
            this.lblAirline.TabIndex = 8;
            this.lblAirline.Text = "Khai thác bởi Pacific Airlines ✈";
            // 
            // lblAircraft
            // 
            this.lblAircraft.BackColor = System.Drawing.Color.Transparent;
            this.lblAircraft.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblAircraft.Location = new System.Drawing.Point(10, 232);
            this.lblAircraft.Name = "lblAircraft";
            this.lblAircraft.Size = new System.Drawing.Size(71, 17);
            this.lblAircraft.TabIndex = 9;
            this.lblAircraft.Text = "AIRBUS A321";
            // 
            // fareDetailsTitle
            // 
            this.fareDetailsTitle.AutoSize = true;
            this.fareDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fareDetailsTitle.Location = new System.Drawing.Point(480, 10);
            this.fareDetailsTitle.Name = "fareDetailsTitle";
            this.fareDetailsTitle.Size = new System.Drawing.Size(140, 17);
            this.fareDetailsTitle.TabIndex = 7;
            this.fareDetailsTitle.Text = "Giá vé của Quý khách";
            // 
            // fareType
            // 
            this.fareType.AutoSize = true;
            this.fareType.Location = new System.Drawing.Point(561, 67);
            this.fareType.Name = "fareType";
            this.fareType.Size = new System.Drawing.Size(38, 15);
            this.fareType.TabIndex = 8;
            this.fareType.Text = "label1";
            // 
            // frmShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1265, 749);
            this.Controls.Add(this.mainScrollPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmShoppingCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lựa chọn của quý khách";
            this.mainScrollPanel.ResumeLayout(false);
            this.containerPanel.ResumeLayout(false);
            this.containerPanel.PerformLayout();
            this.pnlArriveFlight.ResumeLayout(false);
            this.pnlArriveFlight.PerformLayout();
            this.detailsPanel.ResumeLayout(false);
            this.detailsPanel.PerformLayout();
            this.timelinePanel.ResumeLayout(false);
            this.timelinePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainScrollPanel;
        private Guna.UI2.WinForms.Guna2Panel containerPanel;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2Panel pnlArriveFlight;
        private System.Windows.Forms.Label lblRoute1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label depTimeLabel;
        private System.Windows.Forms.Label depCodeLabel;
        private System.Windows.Forms.Label depTerminalLabel;
        private System.Windows.Forms.Label durationLabel;
        private Guna.UI2.WinForms.Guna2Panel linePanel;
        private System.Windows.Forms.Label arrTimeLabel;
        private System.Windows.Forms.Label arrCodeLabel;
        private System.Windows.Forms.Label arrTerminalLabel;
        private System.Windows.Forms.Label clockIcon;
        private System.Windows.Forms.Label durationTime;
        private System.Windows.Forms.Label airlineLabel;
        private System.Windows.Forms.LinkLabel detailsLink;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Button expandBtn;
        private Guna.UI2.WinForms.Guna2Panel detailsPanel;
        private System.Windows.Forms.Label detailsTitle;
        private Guna.UI2.WinForms.Guna2Panel timelinePanel;
        private Guna.UI2.WinForms.Guna2CircleButton circleEnd;
        private Guna.UI2.WinForms.Guna2CircleButton circleStart;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArrivalTerminal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArrivalAirport;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNextDay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArrivalTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDepartureTerminal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDepartureAirport;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDepartureTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFlightDuration;
        private System.Windows.Forms.Panel timelineLine;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAircraft;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFlightNumberTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAirline;
        private System.Windows.Forms.Label fareDetailsTitle;
    }
}