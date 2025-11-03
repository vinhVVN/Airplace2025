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
            this.timelinePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.timelineLine = new System.Windows.Forms.Panel();
            this.lblDuration = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblArrivalDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDepartureDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFlightDuration = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDepartureTime = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.mainPanel.SuspendLayout();
            this.timelinePanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.mainPanel.BorderRadius = 15;
            this.mainPanel.BorderThickness = 1;
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
            // timelinePanel
            // 
            this.timelinePanel.BorderRadius = 10;
            this.timelinePanel.Controls.Add(this.lblDepartureTime);
            this.timelinePanel.Controls.Add(this.lblFlightDuration);
            this.timelinePanel.Controls.Add(this.timelineLine);
            this.timelinePanel.FillColor = System.Drawing.Color.WhiteSmoke;
            this.timelinePanel.Location = new System.Drawing.Point(25, 150);
            this.timelinePanel.Name = "timelinePanel";
            this.timelinePanel.Size = new System.Drawing.Size(370, 200);
            this.timelinePanel.TabIndex = 4;
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
    }
}