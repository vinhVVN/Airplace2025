namespace Airplace2025
{
    partial class frmAddAirplane
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
            this.cbHangBay = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaMayBay = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenMayBay = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoGhe = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbHangBay
            // 
            this.cbHangBay.BackColor = System.Drawing.Color.Transparent;
            this.cbHangBay.BorderRadius = 6;
            this.cbHangBay.BorderThickness = 2;
            this.cbHangBay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbHangBay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHangBay.FocusedColor = System.Drawing.Color.Empty;
            this.cbHangBay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbHangBay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbHangBay.ItemHeight = 20;
            this.cbHangBay.Location = new System.Drawing.Point(25, 217);
            this.cbHangBay.Name = "cbHangBay";
            this.cbHangBay.Size = new System.Drawing.Size(281, 26);
            this.cbHangBay.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(30, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Chọn hãng bay:";
            // 
            // txtMaMayBay
            // 
            this.txtMaMayBay.BorderRadius = 6;
            this.txtMaMayBay.BorderThickness = 2;
            this.txtMaMayBay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaMayBay.DefaultText = "";
            this.txtMaMayBay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaMayBay.HoverState.BorderColor = System.Drawing.Color.DarkOrange;
            this.txtMaMayBay.Location = new System.Drawing.Point(25, 94);
            this.txtMaMayBay.Name = "txtMaMayBay";
            this.txtMaMayBay.PlaceholderText = "";
            this.txtMaMayBay.SelectedText = "";
            this.txtMaMayBay.Size = new System.Drawing.Size(96, 25);
            this.txtMaMayBay.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(30, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mã:";
            // 
            // txtTenMayBay
            // 
            this.txtTenMayBay.BorderRadius = 6;
            this.txtTenMayBay.BorderThickness = 2;
            this.txtTenMayBay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenMayBay.DefaultText = "";
            this.txtTenMayBay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenMayBay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtTenMayBay.Location = new System.Drawing.Point(127, 94);
            this.txtTenMayBay.Name = "txtTenMayBay";
            this.txtTenMayBay.PlaceholderText = "";
            this.txtTenMayBay.SelectedText = "";
            this.txtTenMayBay.Size = new System.Drawing.Size(179, 25);
            this.txtTenMayBay.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumBlue;
            this.label4.Location = new System.Drawing.Point(132, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tên máy bay:";
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 6;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(226, 285);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 6;
            this.btnExit.FillColor = System.Drawing.Color.Gray;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(25, 285);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Huỷ";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thêm Máy Bay";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSoGhe
            // 
            this.txtSoGhe.BorderRadius = 6;
            this.txtSoGhe.BorderThickness = 2;
            this.txtSoGhe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoGhe.DefaultText = "";
            this.txtSoGhe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoGhe.HoverState.BorderColor = System.Drawing.Color.DarkOrange;
            this.txtSoGhe.Location = new System.Drawing.Point(25, 154);
            this.txtSoGhe.Name = "txtSoGhe";
            this.txtSoGhe.PlaceholderText = "";
            this.txtSoGhe.SelectedText = "";
            this.txtSoGhe.Size = new System.Drawing.Size(136, 25);
            this.txtSoGhe.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(30, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Số ghế:";
            // 
            // frmAddAirplane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 338);
            this.Controls.Add(this.txtSoGhe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtTenMayBay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaMayBay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbHangBay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddAirplane";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm máy bay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cbHangBay;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtMaMayBay;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtTenMayBay;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtSoGhe;
        private System.Windows.Forms.Label label5;
    }
}