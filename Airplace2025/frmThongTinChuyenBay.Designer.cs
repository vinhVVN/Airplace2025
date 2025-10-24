namespace Airplace2025
{
    partial class frmThongTinChuyenBay
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
            this.lbOrigin = new System.Windows.Forms.Label();
            this.lbDepartureTime = new System.Windows.Forms.Label();
            this.lbArrivalTime = new System.Windows.Forms.Label();
            this.lbDestination = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbTimKH = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lbBigCase = new System.Windows.Forms.Label();
            this.lbSmallCase = new System.Windows.Forms.Label();
            this.lbMedia = new System.Windows.Forms.Label();
            this.picMedia = new System.Windows.Forms.PictureBox();
            this.lbPlug = new System.Windows.Forms.Label();
            this.picPlug = new System.Windows.Forms.PictureBox();
            this.lbMeal = new System.Windows.Forms.Label();
            this.picMeal = new System.Windows.Forms.PictureBox();
            this.lbWifi = new System.Windows.Forms.Label();
            this.picWifi = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlItinerary = new System.Windows.Forms.FlowLayoutPanel();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.lbTotalDuration = new System.Windows.Forms.Label();
            this.lbStops = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.gbTimKH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOrigin
            // 
            this.lbOrigin.AutoSize = true;
            this.lbOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrigin.ForeColor = System.Drawing.Color.White;
            this.lbOrigin.Location = new System.Drawing.Point(186, 21);
            this.lbOrigin.Name = "lbOrigin";
            this.lbOrigin.Size = new System.Drawing.Size(41, 16);
            this.lbOrigin.TabIndex = 3;
            this.lbOrigin.Text = "Mã Đi";
            // 
            // lbDepartureTime
            // 
            this.lbDepartureTime.AutoSize = true;
            this.lbDepartureTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDepartureTime.ForeColor = System.Drawing.Color.White;
            this.lbDepartureTime.Location = new System.Drawing.Point(233, 17);
            this.lbDepartureTime.Name = "lbDepartureTime";
            this.lbDepartureTime.Size = new System.Drawing.Size(54, 20);
            this.lbDepartureTime.TabIndex = 6;
            this.lbDepartureTime.Text = "00:00";
            // 
            // lbArrivalTime
            // 
            this.lbArrivalTime.AutoSize = true;
            this.lbArrivalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArrivalTime.ForeColor = System.Drawing.Color.White;
            this.lbArrivalTime.Location = new System.Drawing.Point(449, 17);
            this.lbArrivalTime.Name = "lbArrivalTime";
            this.lbArrivalTime.Size = new System.Drawing.Size(54, 20);
            this.lbArrivalTime.TabIndex = 8;
            this.lbArrivalTime.Text = "00:00";
            // 
            // lbDestination
            // 
            this.lbDestination.AutoSize = true;
            this.lbDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDestination.ForeColor = System.Drawing.Color.White;
            this.lbDestination.Location = new System.Drawing.Point(509, 20);
            this.lbDestination.Name = "lbDestination";
            this.lbDestination.Size = new System.Drawing.Size(53, 16);
            this.lbDestination.TabIndex = 7;
            this.lbDestination.Text = "Mã Đến";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.gbTimKH);
            this.panel1.Controls.Add(this.pnlItinerary);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 575);
            this.panel1.TabIndex = 10;
            // 
            // gbTimKH
            // 
            this.gbTimKH.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.gbTimKH.BorderRadius = 8;
            this.gbTimKH.Controls.Add(this.lbBigCase);
            this.gbTimKH.Controls.Add(this.lbSmallCase);
            this.gbTimKH.Controls.Add(this.lbMedia);
            this.gbTimKH.Controls.Add(this.picMedia);
            this.gbTimKH.Controls.Add(this.lbPlug);
            this.gbTimKH.Controls.Add(this.picPlug);
            this.gbTimKH.Controls.Add(this.lbMeal);
            this.gbTimKH.Controls.Add(this.picMeal);
            this.gbTimKH.Controls.Add(this.lbWifi);
            this.gbTimKH.Controls.Add(this.picWifi);
            this.gbTimKH.Controls.Add(this.label3);
            this.gbTimKH.Controls.Add(this.guna2Separator2);
            this.gbTimKH.Controls.Add(this.label2);
            this.gbTimKH.Controls.Add(this.label1);
            this.gbTimKH.Controls.Add(this.guna2Separator1);
            this.gbTimKH.CustomBorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbTimKH.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTimKH.ForeColor = System.Drawing.Color.White;
            this.gbTimKH.Location = new System.Drawing.Point(715, 16);
            this.gbTimKH.Name = "gbTimKH";
            this.gbTimKH.Size = new System.Drawing.Size(295, 343);
            this.gbTimKH.TabIndex = 1;
            this.gbTimKH.Text = "Thông Tin";
            // 
            // lbBigCase
            // 
            this.lbBigCase.AutoSize = true;
            this.lbBigCase.BackColor = System.Drawing.Color.Transparent;
            this.lbBigCase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBigCase.ForeColor = System.Drawing.Color.Black;
            this.lbBigCase.Location = new System.Drawing.Point(111, 90);
            this.lbBigCase.Name = "lbBigCase";
            this.lbBigCase.Size = new System.Drawing.Size(183, 17);
            this.lbBigCase.TabIndex = 15;
            this.lbBigCase.Text = "32kg 119cm x 119 cm x 81 cm";
            // 
            // lbSmallCase
            // 
            this.lbSmallCase.AutoSize = true;
            this.lbSmallCase.BackColor = System.Drawing.Color.White;
            this.lbSmallCase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSmallCase.ForeColor = System.Drawing.Color.Black;
            this.lbSmallCase.Location = new System.Drawing.Point(131, 50);
            this.lbSmallCase.Name = "lbSmallCase";
            this.lbSmallCase.Size = new System.Drawing.Size(162, 17);
            this.lbSmallCase.TabIndex = 14;
            this.lbSmallCase.Text = "7kg 56cm x 36 cm x 23 cm";
            // 
            // lbMedia
            // 
            this.lbMedia.AutoSize = true;
            this.lbMedia.BackColor = System.Drawing.Color.White;
            this.lbMedia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMedia.ForeColor = System.Drawing.Color.Black;
            this.lbMedia.Location = new System.Drawing.Point(50, 304);
            this.lbMedia.Name = "lbMedia";
            this.lbMedia.Size = new System.Drawing.Size(146, 17);
            this.lbMedia.TabIndex = 13;
            this.lbMedia.Text = "Màn hình giải trí full HD";
            // 
            // picMedia
            // 
            this.picMedia.BackColor = System.Drawing.Color.LawnGreen;
            this.picMedia.Image = global::Airplace2025.Properties.Resources.noun_entertainment_6988208;
            this.picMedia.Location = new System.Drawing.Point(12, 298);
            this.picMedia.Name = "picMedia";
            this.picMedia.Size = new System.Drawing.Size(33, 29);
            this.picMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMedia.TabIndex = 12;
            this.picMedia.TabStop = false;
            // 
            // lbPlug
            // 
            this.lbPlug.AutoSize = true;
            this.lbPlug.BackColor = System.Drawing.Color.White;
            this.lbPlug.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlug.ForeColor = System.Drawing.Color.Black;
            this.lbPlug.Location = new System.Drawing.Point(50, 258);
            this.lbPlug.Name = "lbPlug";
            this.lbPlug.Size = new System.Drawing.Size(142, 17);
            this.lbPlug.TabIndex = 11;
            this.lbPlug.Text = "Ổ cắm điện ở chỗ ngồi";
            // 
            // picPlug
            // 
            this.picPlug.BackColor = System.Drawing.Color.Gold;
            this.picPlug.Image = global::Airplace2025.Properties.Resources.noun_plug_8109468;
            this.picPlug.Location = new System.Drawing.Point(12, 252);
            this.picPlug.Name = "picPlug";
            this.picPlug.Size = new System.Drawing.Size(33, 29);
            this.picPlug.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlug.TabIndex = 10;
            this.picPlug.TabStop = false;
            // 
            // lbMeal
            // 
            this.lbMeal.AutoSize = true;
            this.lbMeal.BackColor = System.Drawing.Color.White;
            this.lbMeal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMeal.ForeColor = System.Drawing.Color.Black;
            this.lbMeal.Location = new System.Drawing.Point(50, 165);
            this.lbMeal.Name = "lbMeal";
            this.lbMeal.Size = new System.Drawing.Size(147, 17);
            this.lbMeal.TabIndex = 9;
            this.lbMeal.Text = "Suất ăn trên chuyến bay";
            // 
            // picMeal
            // 
            this.picMeal.BackColor = System.Drawing.Color.MistyRose;
            this.picMeal.Image = global::Airplace2025.Properties.Resources.noun_meal_8091868;
            this.picMeal.Location = new System.Drawing.Point(12, 159);
            this.picMeal.Name = "picMeal";
            this.picMeal.Size = new System.Drawing.Size(33, 29);
            this.picMeal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMeal.TabIndex = 8;
            this.picMeal.TabStop = false;
            // 
            // lbWifi
            // 
            this.lbWifi.AutoSize = true;
            this.lbWifi.BackColor = System.Drawing.Color.White;
            this.lbWifi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWifi.ForeColor = System.Drawing.Color.Black;
            this.lbWifi.Location = new System.Drawing.Point(50, 210);
            this.lbWifi.Name = "lbWifi";
            this.lbWifi.Size = new System.Drawing.Size(126, 17);
            this.lbWifi.TabIndex = 7;
            this.lbWifi.Text = "Wifi trên chuyến bay";
            // 
            // picWifi
            // 
            this.picWifi.BackColor = System.Drawing.Color.SkyBlue;
            this.picWifi.Image = global::Airplace2025.Properties.Resources.pngwing_com__1_;
            this.picWifi.Location = new System.Drawing.Point(12, 204);
            this.picWifi.Name = "picWifi";
            this.picWifi.Size = new System.Drawing.Size(33, 29);
            this.picWifi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWifi.TabIndex = 6;
            this.picWifi.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(8, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dịch vụ có sẵn";
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Location = new System.Drawing.Point(1, 113);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(293, 14);
            this.guna2Separator2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(8, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hành lý ký gửi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hành lý xách tay";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(1, 72);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(293, 13);
            this.guna2Separator1.TabIndex = 0;
            // 
            // pnlItinerary
            // 
            this.pnlItinerary.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlItinerary.Location = new System.Drawing.Point(14, 16);
            this.pnlItinerary.Name = "pnlItinerary";
            this.pnlItinerary.Size = new System.Drawing.Size(689, 541);
            this.pnlItinerary.TabIndex = 0;
            this.pnlItinerary.WrapContents = false;
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.LineColor = System.Drawing.Color.Silver;
            this.gunaSeparator1.Location = new System.Drawing.Point(307, 18);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(122, 18);
            this.gunaSeparator1.TabIndex = 11;
            // 
            // lbTotalDuration
            // 
            this.lbTotalDuration.AutoSize = true;
            this.lbTotalDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalDuration.ForeColor = System.Drawing.Color.White;
            this.lbTotalDuration.Location = new System.Drawing.Point(347, 9);
            this.lbTotalDuration.Name = "lbTotalDuration";
            this.lbTotalDuration.Size = new System.Drawing.Size(42, 13);
            this.lbTotalDuration.TabIndex = 12;
            this.lbTotalDuration.Text = "1h 30m";
            // 
            // lbStops
            // 
            this.lbStops.AutoSize = true;
            this.lbStops.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStops.ForeColor = System.Drawing.Color.White;
            this.lbStops.Location = new System.Drawing.Point(347, 33);
            this.lbStops.Name = "lbStops";
            this.lbStops.Size = new System.Drawing.Size(41, 13);
            this.lbStops.TabIndex = 13;
            this.lbStops.Text = "1 stops";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Airplace2025.Properties.Resources.noun_x_4572560;
            this.btnClose.Location = new System.Drawing.Point(1010, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 14;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmThongTinChuyenBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1046, 644);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbStops);
            this.Controls.Add(this.lbTotalDuration);
            this.Controls.Add(this.gunaSeparator1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbArrivalTime);
            this.Controls.Add(this.lbDestination);
            this.Controls.Add(this.lbDepartureTime);
            this.Controls.Add(this.lbOrigin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongTinChuyenBay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThongTinChuyenBay";
            this.Load += new System.EventHandler(this.frmThongTinChuyenBay_Load);
            this.panel1.ResumeLayout(false);
            this.gbTimKH.ResumeLayout(false);
            this.gbTimKH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOrigin;
        private System.Windows.Forms.Label lbDepartureTime;
        private System.Windows.Forms.Label lbArrivalTime;
        private System.Windows.Forms.Label lbDestination;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel pnlItinerary;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private System.Windows.Forms.Label lbTotalDuration;
        private System.Windows.Forms.Label lbStops;
        private System.Windows.Forms.PictureBox btnClose;
        private Guna.UI2.WinForms.Guna2GroupBox gbTimKH;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picWifi;
        private System.Windows.Forms.Label lbWifi;
        private System.Windows.Forms.Label lbMeal;
        private System.Windows.Forms.PictureBox picMeal;
        private System.Windows.Forms.Label lbPlug;
        private System.Windows.Forms.PictureBox picPlug;
        private System.Windows.Forms.Label lbMedia;
        private System.Windows.Forms.PictureBox picMedia;
        private System.Windows.Forms.Label lbSmallCase;
        private System.Windows.Forms.Label lbBigCase;
    }
}