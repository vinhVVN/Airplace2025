namespace Airplace2025
{
    partial class frmNhatKyHoatDong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.dgvLog = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dtpTuNgay.BorderRadius = 6;
            this.dtpTuNgay.Checked = true;
            this.dtpTuNgay.CustomFormat = "";
            this.dtpTuNgay.FillColor = System.Drawing.Color.White;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTuNgay.ForeColor = System.Drawing.Color.Black;
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(109, 19);
            this.dtpTuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(180, 26);
            this.dtpTuNgay.TabIndex = 62;
            this.dtpTuNgay.Value = new System.DateTime(2025, 10, 24, 15, 12, 10, 504);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dtpDenNgay.BorderRadius = 6;
            this.dtpDenNgay.Checked = true;
            this.dtpDenNgay.CustomFormat = "";
            this.dtpDenNgay.FillColor = System.Drawing.Color.White;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDenNgay.ForeColor = System.Drawing.Color.Black;
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(496, 16);
            this.dtpDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(180, 26);
            this.dtpDenNgay.TabIndex = 61;
            this.dtpDenNgay.Value = new System.DateTime(2025, 10, 24, 15, 12, 10, 504);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "Ngày bắt đầu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(393, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 64;
            this.label2.Text = "Ngày kết thúc:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.txtTimKiem.BorderRadius = 6;
            this.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiem.DefaultText = "";
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.IconLeft = global::Airplace2025.Properties.Resources.magnifying_glass;
            this.txtTimKiem.Location = new System.Drawing.Point(15, 62);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập từ khóa (tên user, hành động...)";
            this.txtTimKiem.SelectedText = "";
            this.txtTimKiem.Size = new System.Drawing.Size(416, 25);
            this.txtTimKiem.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTimKiem.TabIndex = 65;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.BorderRadius = 6;
            this.btnFind.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(12, 102);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(91, 31);
            this.btnFind.TabIndex = 66;
            this.btnFind.Text = "Lọc dữ liệu";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToResizeColumns = false;
            this.dgvLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgvLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvLog.ColumnHeadersHeight = 30;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLog.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLog.Location = new System.Drawing.Point(12, 149);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLog.Size = new System.Drawing.Size(685, 360);
            this.dgvLog.TabIndex = 67;
            this.dgvLog.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLog.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLog.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLog.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLog.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLog.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLog.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLog.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvLog.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLog.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLog.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLog.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvLog.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvLog.ThemeStyle.ReadOnly = true;
            this.dgvLog.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLog.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLog.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLog.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLog.ThemeStyle.RowsStyle.Height = 22;
            this.dgvLog.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLog.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // frmNhatKyHoatDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(709, 521);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.dtpDenNgay);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhatKyHoatDong";
            this.Text = "Log";
            this.Load += new System.EventHandler(this.frmNhatKyHoatDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTuNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLog;
    }
}