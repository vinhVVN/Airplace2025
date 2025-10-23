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
            this.pnlItinerary = new System.Windows.Forms.FlowLayoutPanel();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.lbTotalDuration = new System.Windows.Forms.Label();
            this.lbStops = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
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
            this.panel1.Controls.Add(this.pnlItinerary);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 575);
            this.panel1.TabIndex = 10;
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
    }
}