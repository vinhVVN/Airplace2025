namespace Airplace2025
{
    partial class FlightDetailForm
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
            this.flightInfoPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAirline = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFlightNumberTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
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
            this.lblDuration = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblArrivalDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDepartureDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAircraft = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.mainPanel.SuspendLayout();
            this.flightInfoPanel.SuspendLayout();
            this.timelinePanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.mainPanel.BorderRadius = 15;
            this.mainPanel.BorderThickness = 1;
            this.mainPanel.Controls.Add(this.btnConfirm);
            this.mainPanel.Controls.Add(this.flightInfoPanel);
            this.mainPanel.Controls.Add(this.timelinePanel);
            this.mainPanel.Controls.Add(this.lblDuration);
            this.mainPanel.Controls.Add(this.lblArrivalDate);
            this.mainPanel.Controls.Add(this.lblDepartureDate);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.FillColor = System.Drawing.Color.White;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(420, 500);
            this.mainPanel.TabIndex = 0;
            // 
            // flightInfoPanel
            // 
            this.flightInfoPanel.BorderRadius = 8;
            this.flightInfoPanel.Controls.Add(this.lblAircraft);
            this.flightInfoPanel.Controls.Add(this.lblAirline);
            this.flightInfoPanel.Controls.Add(this.lblFlightNumberTitle);
            this.flightInfoPanel.FillColor = System.Drawing.Color.White;
            this.flightInfoPanel.Location = new System.Drawing.Point(25, 365);
            this.flightInfoPanel.Name = "flightInfoPanel";
            this.flightInfoPanel.Size = new System.Drawing.Size(370, 70);
            this.flightInfoPanel.TabIndex = 5;
            // 
            // lblAirline
            // 
            this.lblAirline.BackColor = System.Drawing.Color.Transparent;
            this.lblAirline.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblAirline.Location = new System.Drawing.Point(10, 32);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(167, 17);
            this.lblAirline.TabIndex = 1;
            this.lblAirline.Text = "Khai thác bởi Pacific Airlines ✈";
            // 
            // lblFlightNumberTitle
            // 
            this.lblFlightNumberTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFlightNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightNumberTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblFlightNumberTitle.Location = new System.Drawing.Point(10, 10);
            this.lblFlightNumberTitle.Name = "lblFlightNumberTitle";
            this.lblFlightNumberTitle.Size = new System.Drawing.Size(160, 17);
            this.lblFlightNumberTitle.TabIndex = 0;
            this.lblFlightNumberTitle.Text = "Số hiệu chuyến bay VN 6025";
            // 
            // timelinePanel
            // 
            this.timelinePanel.BorderRadius = 10;
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
            this.timelinePanel.FillColor = System.Drawing.Color.WhiteSmoke;
            this.timelinePanel.Location = new System.Drawing.Point(25, 150);
            this.timelinePanel.Name = "timelinePanel";
            this.timelinePanel.Size = new System.Drawing.Size(370, 200);
            this.timelinePanel.TabIndex = 4;
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
            this.lblNextDay.Click += new System.EventHandler(this.guna2HtmlLabel1_Click);
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
            this.lblFlightDuration.Location = new System.Drawing.Point(45, 85);
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
            // lblDuration
            // 
            this.lblDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.ForeColor = System.Drawing.Color.Black;
            this.lblDuration.Location = new System.Drawing.Point(25, 115);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(143, 17);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "Tổng thời gian 2h 10phút";
            // 
            // lblArrivalDate
            // 
            this.lblArrivalDate.BackColor = System.Drawing.Color.Transparent;
            this.lblArrivalDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrivalDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblArrivalDate.Location = new System.Drawing.Point(25, 95);
            this.lblArrivalDate.Name = "lblArrivalDate";
            this.lblArrivalDate.Size = new System.Drawing.Size(176, 17);
            this.lblArrivalDate.TabIndex = 2;
            this.lblArrivalDate.Text = "Đến vào Thứ Ba, 4 tháng 11, 2025";
            // 
            // lblDepartureDate
            // 
            this.lblDepartureDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartureDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblDepartureDate.Location = new System.Drawing.Point(25, 75);
            this.lblDepartureDate.Name = "lblDepartureDate";
            this.lblDepartureDate.Size = new System.Drawing.Size(214, 17);
            this.lblDepartureDate.TabIndex = 1;
            this.lblDepartureDate.Text = "Khởi hành vào Thứ Hai, 3 tháng 11, 2025";
            // 
            // headerPanel
            // 
            this.headerPanel.BorderRadius = 15;
            this.headerPanel.BorderThickness = 1;
            this.headerPanel.Controls.Add(this.btnClose);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.FillColor = System.Drawing.Color.White;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(420, 60);
            this.headerPanel.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 20;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Gold;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(355, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(254, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hà Nội - TP. Hồ Chí Minh";
            // 
            // lblAircraft
            // 
            this.lblAircraft.BackColor = System.Drawing.Color.Transparent;
            this.lblAircraft.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAircraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblAircraft.Location = new System.Drawing.Point(10, 50);
            this.lblAircraft.Name = "lblAircraft";
            this.lblAircraft.Size = new System.Drawing.Size(71, 17);
            this.lblAircraft.TabIndex = 2;
            this.lblAircraft.Text = "AIRBUS A321";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BorderRadius = 8;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.Location = new System.Drawing.Point(300, 445);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(95, 40);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "ĐÓNG";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // FlightDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 500);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FlightDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlightDetailForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.flightInfoPanel.ResumeLayout(false);
            this.flightInfoPanel.PerformLayout();
            this.timelinePanel.ResumeLayout(false);
            this.timelinePanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDepartureDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArrivalDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDuration;
        private Guna.UI2.WinForms.Guna2Panel timelinePanel;
        private System.Windows.Forms.Panel timelineLine;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFlightDuration;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDepartureTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDepartureAirport;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDepartureTerminal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArrivalTime;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNextDay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArrivalAirport;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblArrivalTerminal;
        private Guna.UI2.WinForms.Guna2CircleButton circleStart;
        private Guna.UI2.WinForms.Guna2CircleButton circleEnd;
        private Guna.UI2.WinForms.Guna2Panel flightInfoPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFlightNumberTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAirline;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAircraft;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
    }
}