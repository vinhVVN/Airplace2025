namespace Airplace2025
{
    partial class frmNangHang
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
            this.txtGiaHienTai = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHangHienTai = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.cbChonChuyen = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHangMoi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtGiaMoi = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTongThu = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nâng Hạng Vé";
            // 
            // txtGiaHienTai
            // 
            this.txtGiaHienTai.BorderRadius = 6;
            this.txtGiaHienTai.BorderThickness = 2;
            this.txtGiaHienTai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGiaHienTai.DefaultText = "";
            this.txtGiaHienTai.Enabled = false;
            this.txtGiaHienTai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaHienTai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtGiaHienTai.Location = new System.Drawing.Point(31, 151);
            this.txtGiaHienTai.Name = "txtGiaHienTai";
            this.txtGiaHienTai.PlaceholderText = "";
            this.txtGiaHienTai.SelectedText = "";
            this.txtGiaHienTai.Size = new System.Drawing.Size(179, 25);
            this.txtGiaHienTai.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(36, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Giá hiện tại:";
            // 
            // txtHangHienTai
            // 
            this.txtHangHienTai.BorderRadius = 6;
            this.txtHangHienTai.BorderThickness = 2;
            this.txtHangHienTai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHangHienTai.DefaultText = "";
            this.txtHangHienTai.Enabled = false;
            this.txtHangHienTai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHangHienTai.HoverState.BorderColor = System.Drawing.Color.DarkOrange;
            this.txtHangHienTai.Location = new System.Drawing.Point(31, 88);
            this.txtHangHienTai.Name = "txtHangHienTai";
            this.txtHangHienTai.PlaceholderText = "";
            this.txtHangHienTai.SelectedText = "";
            this.txtHangHienTai.Size = new System.Drawing.Size(179, 25);
            this.txtHangHienTai.TabIndex = 17;
            this.txtHangHienTai.TextChanged += new System.EventHandler(this.txtThoiGianDung_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(36, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Hạng hiện tại:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BorderRadius = 6;
            this.btnXacNhan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(446, 253);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(103, 30);
            this.btnXacNhan.TabIndex = 23;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 6;
            this.btnExit.FillColor = System.Drawing.Color.Gray;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(340, 253);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Huỷ";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbChonChuyen
            // 
            this.cbChonChuyen.BackColor = System.Drawing.Color.Transparent;
            this.cbChonChuyen.BorderRadius = 6;
            this.cbChonChuyen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbChonChuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChonChuyen.FocusedColor = System.Drawing.Color.Empty;
            this.cbChonChuyen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbChonChuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbChonChuyen.ItemHeight = 20;
            this.cbChonChuyen.Location = new System.Drawing.Point(299, 20);
            this.cbChonChuyen.Name = "cbChonChuyen";
            this.cbChonChuyen.Size = new System.Drawing.Size(224, 26);
            this.cbChonChuyen.TabIndex = 26;
            this.cbChonChuyen.SelectedIndexChanged += new System.EventHandler(this.cbChonChuyen_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(304, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Hạng mới:";
            // 
            // cbHangMoi
            // 
            this.cbHangMoi.BackColor = System.Drawing.Color.Transparent;
            this.cbHangMoi.BorderRadius = 6;
            this.cbHangMoi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHangMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHangMoi.FocusedColor = System.Drawing.Color.Empty;
            this.cbHangMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbHangMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbHangMoi.ItemHeight = 20;
            this.cbHangMoi.Location = new System.Drawing.Point(299, 88);
            this.cbHangMoi.Name = "cbHangMoi";
            this.cbHangMoi.Size = new System.Drawing.Size(179, 26);
            this.cbHangMoi.TabIndex = 28;
            this.cbHangMoi.SelectedIndexChanged += new System.EventHandler(this.cbHangMoi_SelectedIndexChanged);
            // 
            // txtGiaMoi
            // 
            this.txtGiaMoi.BorderRadius = 6;
            this.txtGiaMoi.BorderThickness = 2;
            this.txtGiaMoi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGiaMoi.DefaultText = "";
            this.txtGiaMoi.Enabled = false;
            this.txtGiaMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaMoi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtGiaMoi.Location = new System.Drawing.Point(299, 151);
            this.txtGiaMoi.Name = "txtGiaMoi";
            this.txtGiaMoi.PlaceholderText = "";
            this.txtGiaMoi.SelectedText = "";
            this.txtGiaMoi.Size = new System.Drawing.Size(179, 25);
            this.txtGiaMoi.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(304, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Giá mới:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(31, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Tổng thu:";
            // 
            // lbTongThu
            // 
            this.lbTongThu.AutoSize = true;
            this.lbTongThu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongThu.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbTongThu.Location = new System.Drawing.Point(32, 251);
            this.lbTongThu.Name = "lbTongThu";
            this.lbTongThu.Size = new System.Drawing.Size(40, 25);
            this.lbTongThu.TabIndex = 32;
            this.lbTongThu.Text = "0 đ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SlateGray;
            this.label8.Location = new System.Drawing.Point(301, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "*Chưa bao gồm 100k phí chuyển đổi";
            // 
            // frmNangHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(561, 295);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbTongThu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGiaMoi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbHangMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbChonChuyen);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtGiaHienTai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHangHienTai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNangHang";
            this.Text = "Thêm hãng bay";
            this.Load += new System.EventHandler(this.frmNangHang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtGiaHienTai;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtHangHienTai;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnXacNhan;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2ComboBox cbChonChuyen;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cbHangMoi;
        private Guna.UI2.WinForms.Guna2TextBox txtGiaMoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTongThu;
        private System.Windows.Forms.Label label8;
    }
}