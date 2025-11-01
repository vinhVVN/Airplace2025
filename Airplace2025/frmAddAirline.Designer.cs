namespace Airplace2025
{
    partial class frmAddAirline
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
            this.txtTenHangBay = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaHangBay = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thêm Hãng Bay";
            // 
            // txtTenHangBay
            // 
            this.txtTenHangBay.BorderRadius = 6;
            this.txtTenHangBay.BorderThickness = 2;
            this.txtTenHangBay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenHangBay.DefaultText = "";
            this.txtTenHangBay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenHangBay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtTenHangBay.Location = new System.Drawing.Point(31, 151);
            this.txtTenHangBay.Name = "txtTenHangBay";
            this.txtTenHangBay.PlaceholderText = "";
            this.txtTenHangBay.SelectedText = "";
            this.txtTenHangBay.Size = new System.Drawing.Size(179, 25);
            this.txtTenHangBay.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(36, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tên hãng bay:";
            // 
            // txtMaHangBay
            // 
            this.txtMaHangBay.BorderRadius = 6;
            this.txtMaHangBay.BorderThickness = 2;
            this.txtMaHangBay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaHangBay.DefaultText = "";
            this.txtMaHangBay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaHangBay.HoverState.BorderColor = System.Drawing.Color.DarkOrange;
            this.txtMaHangBay.Location = new System.Drawing.Point(31, 86);
            this.txtMaHangBay.Name = "txtMaHangBay";
            this.txtMaHangBay.PlaceholderText = "";
            this.txtMaHangBay.SelectedText = "";
            this.txtMaHangBay.Size = new System.Drawing.Size(179, 25);
            this.txtMaHangBay.TabIndex = 17;
            this.txtMaHangBay.TextChanged += new System.EventHandler(this.txtThoiGianDung_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(36, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Mã hãng bay:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 6;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(469, 98);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 6;
            this.btnExit.FillColor = System.Drawing.Color.Gray;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(469, 142);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "Huỷ";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(249, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.BorderRadius = 6;
            this.txtMoTa.BorderThickness = 2;
            this.txtMoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMoTa.DefaultText = "";
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMoTa.HoverState.BorderColor = System.Drawing.Color.DarkOrange;
            this.txtMoTa.Location = new System.Drawing.Point(252, 86);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.PlaceholderText = "";
            this.txtMoTa.SelectedText = "";
            this.txtMoTa.Size = new System.Drawing.Size(179, 90);
            this.txtMoTa.TabIndex = 25;
            // 
            // frmAddAirline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(561, 202);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtTenHangBay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaHangBay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddAirline";
            this.Text = "Thêm hãng bay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtTenHangBay;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtMaHangBay;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtMoTa;
    }
}