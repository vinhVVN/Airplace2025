namespace Airplace2025
{
    partial class frmChonGhe
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpPassengers = new System.Windows.Forms.GroupBox();
            this.lstPassengers = new System.Windows.Forms.ListBox();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlSeatMap = new System.Windows.Forms.Panel();
            this.pnlFlightInfo = new System.Windows.Forms.Panel();
            this.lblFlightInfo = new System.Windows.Forms.Label();
            this.lblFlightTitle = new System.Windows.Forms.Label();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnChuyenVe = new System.Windows.Forms.Button();
            this.btnChuyenDi = new System.Windows.Forms.Button();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.lblLegend1 = new System.Windows.Forms.Label();
            this.lblLegend2 = new System.Windows.Forms.Label();
            this.lblLegend3 = new System.Windows.Forms.Label();
            this.lblLegendBox1 = new System.Windows.Forms.Label();
            this.lblLegendBox2 = new System.Windows.Forms.Label();
            this.lblLegendBox3 = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpPassengers.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlFlightInfo.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlLegend.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 60);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "CHỌN GHẾ NGỒI";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);

            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnConfirm);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 600);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1000, 60);
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;

            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(850, 10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(120, 40);
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(720, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.Text = "Quay lại";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpPassengers);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 60);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(250, 540);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);

            // 
            // grpPassengers
            // 
            this.grpPassengers.Controls.Add(this.lstPassengers);
            this.grpPassengers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPassengers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPassengers.Location = new System.Drawing.Point(10, 10);
            this.grpPassengers.Name = "grpPassengers";
            this.grpPassengers.Text = "Danh sách hành khách";
            this.grpPassengers.Size = new System.Drawing.Size(230, 520);

            // 
            // lstPassengers
            // 
            this.lstPassengers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPassengers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lstPassengers.ItemHeight = 30;
            this.lstPassengers.Location = new System.Drawing.Point(3, 20);
            this.lstPassengers.Name = "lstPassengers";
            this.lstPassengers.Size = new System.Drawing.Size(224, 497);

            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlSeatMap);
            this.pnlCenter.Controls.Add(this.pnlLegend);
            this.pnlCenter.Controls.Add(this.pnlFlightInfo);
            this.pnlCenter.Controls.Add(this.pnlTabs);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(250, 60);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCenter.Size = new System.Drawing.Size(750, 540);

            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.btnChuyenVe);
            this.pnlTabs.Controls.Add(this.btnChuyenDi);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Height = 40;
            
            // 
            // btnChuyenDi
            // 
            this.btnChuyenDi.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnChuyenDi.Width = 375;
            this.btnChuyenDi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenDi.Text = "CHUYẾN ĐI";
            this.btnChuyenDi.Click += new System.EventHandler(this.btnChuyenDi_Click);

            // 
            // btnChuyenVe
            // 
            this.btnChuyenVe.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnChuyenVe.Width = 375;
            this.btnChuyenVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenVe.Text = "CHUYẾN VỀ";
            this.btnChuyenVe.Click += new System.EventHandler(this.btnChuyenVe_Click);

            // 
            // pnlFlightInfo
            // 
            this.pnlFlightInfo.Controls.Add(this.lblFlightInfo);
            this.pnlFlightInfo.Controls.Add(this.lblFlightTitle);
            this.pnlFlightInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFlightInfo.Height = 60;
            this.pnlFlightInfo.BackColor = System.Drawing.Color.White;
            this.pnlFlightInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            // 
            // lblFlightTitle
            // 
            this.lblFlightTitle.AutoSize = true;
            this.lblFlightTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFlightTitle.Location = new System.Drawing.Point(10, 5);
            this.lblFlightTitle.Text = "SGN ➔ HAN";
            
            // 
            // lblFlightInfo
            // 
            this.lblFlightInfo.AutoSize = true;
            this.lblFlightInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFlightInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblFlightInfo.Location = new System.Drawing.Point(10, 30);
            this.lblFlightInfo.Text = "Vietnam Airlines • VN123 • 25/10/2025 08:00";

            //
            // pnlLegend - Chú thích được vẽ động trong RenderSeatMap
            //
            this.pnlLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLegend.Height = 50;
            this.pnlLegend.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlLegend.Controls.Add(this.lblLegendBox1);
            this.pnlLegend.Controls.Add(this.lblLegend1);
            this.pnlLegend.Controls.Add(this.lblLegendBox2);
            this.pnlLegend.Controls.Add(this.lblLegend2);
            this.pnlLegend.Controls.Add(this.lblLegendBox3);
            this.pnlLegend.Controls.Add(this.lblLegend3);

            // Boxes - Chú thích cơ bản
            this.lblLegendBox1.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.lblLegendBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegendBox1.Size = new System.Drawing.Size(20, 20);
            this.lblLegendBox1.Location = new System.Drawing.Point(10, 15);
            
            this.lblLegend1.Text = "Đang chọn";
            this.lblLegend1.AutoSize = true;
            this.lblLegend1.Location = new System.Drawing.Point(35, 17);

            this.lblLegendBox2.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.lblLegendBox2.Size = new System.Drawing.Size(20, 20);
            this.lblLegendBox2.Location = new System.Drawing.Point(130, 15);
            
            this.lblLegend2.Text = "Đã đặt";
            this.lblLegend2.AutoSize = true;
            this.lblLegend2.Location = new System.Drawing.Point(155, 17);

            this.lblLegendBox3.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblLegendBox3.Size = new System.Drawing.Size(20, 20);
            this.lblLegendBox3.Location = new System.Drawing.Point(220, 15);
            
            this.lblLegend3.Text = "Khác hạng vé (không thể chọn)";
            this.lblLegend3.AutoSize = true;
            this.lblLegend3.Location = new System.Drawing.Point(245, 17);


            // 
            // pnlSeatMap
            // 
            this.pnlSeatMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeatMap.BackColor = System.Drawing.Color.White;
            this.pnlSeatMap.AutoScroll = true;
            
            // Form Setup
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn ghế ngồi - Chỉ được chọn ghế trong hạng vé đã đặt";
            this.Load += new System.EventHandler(this.frmChonGhe_Load);
            
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grpPassengers.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlFlightInfo.ResumeLayout(false);
            this.pnlFlightInfo.PerformLayout();
            this.pnlTabs.ResumeLayout(false);
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpPassengers;
        private System.Windows.Forms.ListBox lstPassengers;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlSeatMap;
        private System.Windows.Forms.Panel pnlFlightInfo;
        private System.Windows.Forms.Label lblFlightInfo;
        private System.Windows.Forms.Label lblFlightTitle;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnChuyenVe;
        private System.Windows.Forms.Button btnChuyenDi;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Label lblLegendBox1;
        private System.Windows.Forms.Label lblLegend1;
        private System.Windows.Forms.Label lblLegendBox2;
        private System.Windows.Forms.Label lblLegend2;
        private System.Windows.Forms.Label lblLegendBox3;
        private System.Windows.Forms.Label lblLegend3;
    }
}
