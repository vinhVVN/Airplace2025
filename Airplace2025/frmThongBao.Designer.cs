namespace Airplace2025
{
    partial class frmThongBao
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
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnSend = new Guna.UI2.WinForms.Guna2Button();
            this.txtTieuDe = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông báo đến các khách hàng";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.BackColor = System.Drawing.Color.White;
            this.guna2Separator1.FillColor = System.Drawing.Color.RoyalBlue;
            this.guna2Separator1.Location = new System.Drawing.Point(12, 41);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(298, 11);
            this.guna2Separator1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tiêu đề:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MediumBlue;
            this.label7.Location = new System.Drawing.Point(14, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nội dung:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.BorderRadius = 6;
            this.txtNoiDung.BorderThickness = 2;
            this.txtNoiDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoiDung.DefaultText = "";
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNoiDung.ForeColor = System.Drawing.Color.Black;
            this.txtNoiDung.Location = new System.Drawing.Point(17, 154);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.PlaceholderText = "";
            this.txtNoiDung.SelectedText = "";
            this.txtNoiDung.Size = new System.Drawing.Size(288, 208);
            this.txtNoiDung.TabIndex = 17;
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 6;
            this.btnExit.FillColor = System.Drawing.Color.Gray;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(130, 373);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Huỷ";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSend
            // 
            this.btnSend.BorderRadius = 6;
            this.btnSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(225, 373);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 30);
            this.btnSend.TabIndex = 19;
            this.btnSend.Text = "Gửi";
            this.btnSend.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.BorderRadius = 6;
            this.txtTieuDe.BorderThickness = 2;
            this.txtTieuDe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTieuDe.DefaultText = "";
            this.txtTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTieuDe.ForeColor = System.Drawing.Color.Black;
            this.txtTieuDe.Location = new System.Drawing.Point(12, 92);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.PlaceholderText = "";
            this.txtTieuDe.SelectedText = "";
            this.txtTieuDe.Size = new System.Drawing.Size(288, 25);
            this.txtTieuDe.TabIndex = 20;
            // 
            // frmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(324, 412);
            this.Controls.Add(this.txtTieuDe);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmThemTrungGian_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtNoiDung;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private Guna.UI2.WinForms.Guna2TextBox txtTieuDe;
    }
}