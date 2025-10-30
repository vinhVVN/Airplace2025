namespace Airplace2025
{
    partial class FilterForm
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
            this.scrollPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.vScrollBar = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFlightCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btnApply = new Guna.UI2.WinForms.Guna2Button();
            this.lblKhoang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlBudget = new Guna.UI2.WinForms.Guna2Panel();
            this.mainPanel.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BorderRadius = 15;
            this.mainPanel.Controls.Add(this.btnApply);
            this.mainPanel.Controls.Add(this.btnReset);
            this.mainPanel.Controls.Add(this.lblFlightCount);
            this.mainPanel.Controls.Add(this.scrollPanel);
            this.mainPanel.Controls.Add(this.btnClose);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Controls.Add(this.vScrollBar);
            this.mainPanel.Location = new System.Drawing.Point(20, 20);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(360, 560);
            this.mainPanel.TabIndex = 0;
            // 
            // scrollPanel
            // 
            this.scrollPanel.BackColor = System.Drawing.Color.White;
            this.scrollPanel.Controls.Add(this.pnlBudget);
            this.scrollPanel.Controls.Add(this.guna2ComboBox1);
            this.scrollPanel.Controls.Add(this.lblKhoang);
            this.scrollPanel.Location = new System.Drawing.Point(15, 60);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(310, 430);
            this.scrollPanel.TabIndex = 2;
            // 
            // vScrollBar
            // 
            this.vScrollBar.BorderRadius = 7;
            this.vScrollBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.vScrollBar.InUpdate = false;
            this.vScrollBar.LargeChange = 10;
            this.vScrollBar.Location = new System.Drawing.Point(330, 60);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.ScrollbarSize = 15;
            this.vScrollBar.Size = new System.Drawing.Size(15, 430);
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 17;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(305, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "✕";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(74, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bộ lọc";
            // 
            // lblFlightCount
            // 
            this.lblFlightCount.BackColor = System.Drawing.Color.Transparent;
            this.lblFlightCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlightCount.ForeColor = System.Drawing.Color.Gray;
            this.lblFlightCount.Location = new System.Drawing.Point(189, 492);
            this.lblFlightCount.Name = "lblFlightCount";
            this.lblFlightCount.Size = new System.Drawing.Size(136, 17);
            this.lblFlightCount.TabIndex = 3;
            this.lblFlightCount.Text = "Có 19 trên 19 chuyến bay";
            // 
            // btnReset
            // 
            this.btnReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.btnReset.BorderRadius = 8;
            this.btnReset.BorderThickness = 3;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnReset.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.btnReset.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.btnReset.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnReset.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.btnReset.Location = new System.Drawing.Point(15, 510);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(140, 40);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "THIẾT LẬP LẠI";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnApply
            // 
            this.btnApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.BorderRadius = 8;
            this.btnApply.BorderThickness = 3;
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApply.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApply.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApply.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApply.FillColor = System.Drawing.SystemColors.Control;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.btnApply.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(185, 510);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(140, 40);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "ÁP DỤNG";
            // 
            // lblKhoang
            // 
            this.lblKhoang.BackColor = System.Drawing.Color.Transparent;
            this.lblKhoang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoang.Location = new System.Drawing.Point(10, 0);
            this.lblKhoang.Name = "lblKhoang";
            this.lblKhoang.Size = new System.Drawing.Size(44, 17);
            this.lblKhoang.TabIndex = 0;
            this.lblKhoang.Text = "Khoang";
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderRadius = 8;
            this.guna2ComboBox1.BorderThickness = 3;
            this.guna2ComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(110)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Items.AddRange(new object[] {
            "Tất cả",
            "PHỔ THÔNG",
            "PHỔ THÔNG ĐẶC BIỆT",
            "THƯƠNG GIA"});
            this.guna2ComboBox1.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.guna2ComboBox1.Location = new System.Drawing.Point(10, 25);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.Size = new System.Drawing.Size(280, 36);
            this.guna2ComboBox1.StartIndex = 0;
            this.guna2ComboBox1.TabIndex = 1;
            // 
            // pnlBudget
            // 
            this.pnlBudget.Location = new System.Drawing.Point(0, 85);
            this.pnlBudget.Name = "pnlBudget";
            this.pnlBudget.Size = new System.Drawing.Size(300, 120);
            this.pnlBudget.TabIndex = 2;
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilterForm";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Panel scrollPanel;
        private Guna.UI2.WinForms.Guna2VScrollBar vScrollBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFlightCount;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Button btnApply;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblKhoang;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2Panel pnlBudget;
    }
}