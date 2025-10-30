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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnApply = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.lblFlightCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.scrollPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBudget = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMaxPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMinPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.trackBudget = new Guna.UI2.WinForms.Guna2TrackBar();
            this.btnBudgetToggle = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblBudget = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblKhoang = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.vScrollBar = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.pnlStops = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnStopsToggle = new Guna.UI2.WinForms.Guna2ImageButton();
            this.rbNoStop = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbDirectOnly = new Guna.UI2.WinForms.Guna2RadioButton();
            this.mainPanel.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.pnlBudget.SuspendLayout();
            this.pnlStops.SuspendLayout();
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
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
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
            // scrollPanel
            // 
            this.scrollPanel.BackColor = System.Drawing.Color.White;
            this.scrollPanel.Controls.Add(this.pnlStops);
            this.scrollPanel.Controls.Add(this.pnlBudget);
            this.scrollPanel.Controls.Add(this.guna2ComboBox1);
            this.scrollPanel.Controls.Add(this.lblKhoang);
            this.scrollPanel.Location = new System.Drawing.Point(15, 60);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(310, 430);
            this.scrollPanel.TabIndex = 2;
            // 
            // pnlBudget
            // 
            this.pnlBudget.Controls.Add(this.lblMaxPrice);
            this.pnlBudget.Controls.Add(this.lblMinPrice);
            this.pnlBudget.Controls.Add(this.trackBudget);
            this.pnlBudget.Controls.Add(this.btnBudgetToggle);
            this.pnlBudget.Controls.Add(this.lblBudget);
            this.pnlBudget.Location = new System.Drawing.Point(0, 75);
            this.pnlBudget.Name = "pnlBudget";
            this.pnlBudget.Size = new System.Drawing.Size(300, 120);
            this.pnlBudget.TabIndex = 2;
            // 
            // lblMaxPrice
            // 
            this.lblMaxPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblMaxPrice.Location = new System.Drawing.Point(180, 80);
            this.lblMaxPrice.Name = "lblMaxPrice";
            this.lblMaxPrice.Size = new System.Drawing.Size(87, 17);
            this.lblMaxPrice.TabIndex = 4;
            this.lblMaxPrice.Text = "8.776.000 VND";
            // 
            // lblMinPrice
            // 
            this.lblMinPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblMinPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinPrice.Location = new System.Drawing.Point(10, 80);
            this.lblMinPrice.Name = "lblMinPrice";
            this.lblMinPrice.Size = new System.Drawing.Size(87, 17);
            this.lblMinPrice.TabIndex = 3;
            this.lblMinPrice.Text = "3.063.000 VND";
            // 
            // trackBudget
            // 
            this.trackBudget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBudget.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.trackBudget.Location = new System.Drawing.Point(10, 50);
            this.trackBudget.Maximum = 8776;
            this.trackBudget.Minimum = 3063;
            this.trackBudget.Name = "trackBudget";
            this.trackBudget.Size = new System.Drawing.Size(270, 23);
            this.trackBudget.TabIndex = 2;
            this.trackBudget.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.trackBudget.Value = 3063;
            this.trackBudget.ValueChanged += new System.EventHandler(this.trackBudget_ValueChanged);
            this.trackBudget.Scroll += new System.Windows.Forms.ScrollEventHandler(this.trackBudget_Scroll);
            // 
            // btnBudgetToggle
            // 
            this.btnBudgetToggle.BackColor = System.Drawing.Color.Transparent;
            this.btnBudgetToggle.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnBudgetToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBudgetToggle.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnBudgetToggle.Image = ((System.Drawing.Image)(resources.GetObject("btnBudgetToggle.Image")));
            this.btnBudgetToggle.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnBudgetToggle.ImageRotate = 0F;
            this.btnBudgetToggle.ImageSize = new System.Drawing.Size(15, 15);
            this.btnBudgetToggle.Location = new System.Drawing.Point(265, 8);
            this.btnBudgetToggle.Name = "btnBudgetToggle";
            this.btnBudgetToggle.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnBudgetToggle.Size = new System.Drawing.Size(20, 20);
            this.btnBudgetToggle.TabIndex = 1;
            this.btnBudgetToggle.Click += new System.EventHandler(this.btnBudgetToggle_Click);
            // 
            // lblBudget
            // 
            this.lblBudget.BackColor = System.Drawing.Color.Transparent;
            this.lblBudget.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblBudget.Location = new System.Drawing.Point(10, 10);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(67, 19);
            this.lblBudget.TabIndex = 0;
            this.lblBudget.Text = "Ngân sách";
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
            // pnlStops
            // 
            this.pnlStops.Controls.Add(this.rbDirectOnly);
            this.pnlStops.Controls.Add(this.rbNoStop);
            this.pnlStops.Controls.Add(this.btnStopsToggle);
            this.pnlStops.Controls.Add(this.guna2HtmlLabel1);
            this.pnlStops.Location = new System.Drawing.Point(0, 205);
            this.pnlStops.Name = "pnlStops";
            this.pnlStops.Size = new System.Drawing.Size(300, 100);
            this.pnlStops.TabIndex = 3;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(11, 18);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(141, 19);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Số sân bay nối chuyến";
            // 
            // btnStopsToggle
            // 
            this.btnStopsToggle.BackColor = System.Drawing.Color.Transparent;
            this.btnStopsToggle.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnStopsToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopsToggle.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnStopsToggle.Image = ((System.Drawing.Image)(resources.GetObject("btnStopsToggle.Image")));
            this.btnStopsToggle.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnStopsToggle.ImageRotate = 0F;
            this.btnStopsToggle.ImageSize = new System.Drawing.Size(15, 15);
            this.btnStopsToggle.Location = new System.Drawing.Point(265, 8);
            this.btnStopsToggle.Name = "btnStopsToggle";
            this.btnStopsToggle.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnStopsToggle.Size = new System.Drawing.Size(20, 20);
            this.btnStopsToggle.TabIndex = 1;
            this.btnStopsToggle.Click += new System.EventHandler(this.btnStopsToggle_Click);
            // 
            // rbNoStop
            // 
            this.rbNoStop.AutoSize = true;
            this.rbNoStop.Checked = true;
            this.rbNoStop.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbNoStop.CheckedState.BorderThickness = 0;
            this.rbNoStop.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbNoStop.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbNoStop.CheckedState.InnerOffset = -4;
            this.rbNoStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbNoStop.Location = new System.Drawing.Point(10, 45);
            this.rbNoStop.Name = "rbNoStop";
            this.rbNoStop.Size = new System.Drawing.Size(115, 17);
            this.rbNoStop.TabIndex = 2;
            this.rbNoStop.TabStop = true;
            this.rbNoStop.Text = "Không có tùy chọn";
            this.rbNoStop.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbNoStop.UncheckedState.BorderThickness = 2;
            this.rbNoStop.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbNoStop.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbDirectOnly
            // 
            this.rbDirectOnly.AutoSize = true;
            this.rbDirectOnly.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDirectOnly.CheckedState.BorderThickness = 0;
            this.rbDirectOnly.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(180)))), ((int)(((byte)(65)))));
            this.rbDirectOnly.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbDirectOnly.CheckedState.InnerOffset = -4;
            this.rbDirectOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDirectOnly.Location = new System.Drawing.Point(10, 70);
            this.rbDirectOnly.Name = "rbDirectOnly";
            this.rbDirectOnly.Size = new System.Drawing.Size(143, 17);
            this.rbDirectOnly.TabIndex = 3;
            this.rbDirectOnly.Text = "Chỉ có chuyến bay thẳng";
            this.rbDirectOnly.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbDirectOnly.UncheckedState.BorderThickness = 2;
            this.rbDirectOnly.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbDirectOnly.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
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
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            this.pnlBudget.ResumeLayout(false);
            this.pnlBudget.PerformLayout();
            this.pnlStops.ResumeLayout(false);
            this.pnlStops.PerformLayout();
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
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBudget;
        private Guna.UI2.WinForms.Guna2ImageButton btnBudgetToggle;
        private Guna.UI2.WinForms.Guna2TrackBar trackBudget;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMinPrice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaxPrice;
        private Guna.UI2.WinForms.Guna2Panel pnlStops;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ImageButton btnStopsToggle;
        private Guna.UI2.WinForms.Guna2RadioButton rbNoStop;
        private Guna.UI2.WinForms.Guna2RadioButton rbDirectOnly;
    }
}