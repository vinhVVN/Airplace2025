namespace Airplace2025
{
    partial class frmPriceDetails
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
            this.components = new System.ComponentModel.Container();
            this.borderless = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.contentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.adultPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.arrowAdultLabel = new System.Windows.Forms.Label();
            this.priceAdultLabel = new System.Windows.Forms.Label();
            this.adultSubLabel = new System.Windows.Forms.Label();
            this.detailsAdultPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.detailsAdultFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.categoryAdultPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.categoryLabelPrice = new System.Windows.Forms.Label();
            this.categoryAdultLabel = new System.Windows.Forms.Label();
            this.confirmButton = new Guna.UI2.WinForms.Guna2Button();
            this.pricePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.totalDescLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.closeButton = new Guna.UI2.WinForms.Guna2Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.adultPanel.SuspendLayout();
            this.detailsAdultPanel.SuspendLayout();
            this.detailsAdultFlow.SuspendLayout();
            this.categoryAdultPanel.SuspendLayout();
            this.pricePanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // borderless
            // 
            this.borderless.BorderRadius = 12;
            this.borderless.ContainerControl = this;
            this.borderless.DockIndicatorTransparencyValue = 0.6D;
            this.borderless.TransparentWhileDrag = true;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BorderRadius = 12;
            this.mainPanel.Controls.Add(this.contentPanel);
            this.mainPanel.Controls.Add(this.confirmButton);
            this.mainPanel.Controls.Add(this.pricePanel);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.FillColor = System.Drawing.Color.White;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.ShadowDecoration.Depth = 15;
            this.mainPanel.ShadowDecoration.Enabled = true;
            this.mainPanel.Size = new System.Drawing.Size(750, 600);
            this.mainPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Controls.Add(this.adultPanel);
            this.contentPanel.Controls.Add(this.detailsAdultPanel);
            this.contentPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.contentPanel.Location = new System.Drawing.Point(0, 150);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.contentPanel.Size = new System.Drawing.Size(750, 370);
            this.contentPanel.TabIndex = 3;
            this.contentPanel.WrapContents = false;
            // 
            // adultPanel
            // 
            this.adultPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.adultPanel.BorderThickness = 1;
            this.adultPanel.Controls.Add(this.arrowAdultLabel);
            this.adultPanel.Controls.Add(this.priceAdultLabel);
            this.adultPanel.Controls.Add(this.adultSubLabel);
            this.adultPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adultPanel.FillColor = System.Drawing.Color.White;
            this.adultPanel.Location = new System.Drawing.Point(25, 20);
            this.adultPanel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.adultPanel.Name = "adultPanel";
            this.adultPanel.Size = new System.Drawing.Size(1050, 60);
            this.adultPanel.TabIndex = 0;
            // 
            // arrowAdultLabel
            // 
            this.arrowAdultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.arrowAdultLabel.AutoSize = true;
            this.arrowAdultLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrowAdultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.arrowAdultLabel.Location = new System.Drawing.Point(1010, 15);
            this.arrowAdultLabel.Name = "arrowAdultLabel";
            this.arrowAdultLabel.Size = new System.Drawing.Size(23, 25);
            this.arrowAdultLabel.TabIndex = 2;
            this.arrowAdultLabel.Text = "˅";
            // 
            // priceAdultLabel
            // 
            this.priceAdultLabel.AutoSize = true;
            this.priceAdultLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceAdultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.priceAdultLabel.Location = new System.Drawing.Point(850, 18);
            this.priceAdultLabel.Name = "priceAdultLabel";
            this.priceAdultLabel.Size = new System.Drawing.Size(121, 21);
            this.priceAdultLabel.TabIndex = 1;
            this.priceAdultLabel.Text = "5.672.000 VND";
            // 
            // adultSubLabel
            // 
            this.adultSubLabel.AutoSize = true;
            this.adultSubLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adultSubLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.adultSubLabel.Location = new System.Drawing.Point(15, 18);
            this.adultSubLabel.Name = "adultSubLabel";
            this.adultSubLabel.Size = new System.Drawing.Size(101, 21);
            this.adultSubLabel.TabIndex = 0;
            this.adultSubLabel.Text = "1 Người lớn";
            // 
            // detailsAdultPanel
            // 
            this.detailsAdultPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.detailsAdultPanel.BorderThickness = 1;
            this.detailsAdultPanel.Controls.Add(this.detailsAdultFlow);
            this.detailsAdultPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.detailsAdultPanel.Location = new System.Drawing.Point(25, 85);
            this.detailsAdultPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.detailsAdultPanel.Name = "detailsAdultPanel";
            this.detailsAdultPanel.Padding = new System.Windows.Forms.Padding(15);
            this.detailsAdultPanel.Size = new System.Drawing.Size(1050, 100);
            this.detailsAdultPanel.TabIndex = 1;
            this.detailsAdultPanel.Visible = false;
            // 
            // detailsAdultFlow
            // 
            this.detailsAdultFlow.AutoScroll = true;
            this.detailsAdultFlow.AutoSize = true;
            this.detailsAdultFlow.Controls.Add(this.categoryAdultPanel);
            this.detailsAdultFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsAdultFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.detailsAdultFlow.Location = new System.Drawing.Point(15, 15);
            this.detailsAdultFlow.Name = "detailsAdultFlow";
            this.detailsAdultFlow.Size = new System.Drawing.Size(1020, 70);
            this.detailsAdultFlow.TabIndex = 0;
            this.detailsAdultFlow.WrapContents = false;
            // 
            // categoryAdultPanel
            // 
            this.categoryAdultPanel.Controls.Add(this.categoryLabelPrice);
            this.categoryAdultPanel.Controls.Add(this.categoryAdultLabel);
            this.categoryAdultPanel.FillColor = System.Drawing.Color.Transparent;
            this.categoryAdultPanel.Location = new System.Drawing.Point(0, 10);
            this.categoryAdultPanel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.categoryAdultPanel.Name = "categoryAdultPanel";
            this.categoryAdultPanel.Size = new System.Drawing.Size(990, 50);
            this.categoryAdultPanel.TabIndex = 0;
            // 
            // categoryLabelPrice
            // 
            this.categoryLabelPrice.AutoSize = true;
            this.categoryLabelPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabelPrice.Location = new System.Drawing.Point(840, 10);
            this.categoryLabelPrice.Name = "categoryLabelPrice";
            this.categoryLabelPrice.Size = new System.Drawing.Size(98, 17);
            this.categoryLabelPrice.TabIndex = 1;
            this.categoryLabelPrice.Text = "4.198.000 VND";
            // 
            // categoryAdultLabel
            // 
            this.categoryAdultLabel.AutoSize = true;
            this.categoryAdultLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryAdultLabel.Location = new System.Drawing.Point(10, 10);
            this.categoryAdultLabel.Name = "categoryAdultLabel";
            this.categoryAdultLabel.Size = new System.Drawing.Size(180, 17);
            this.categoryAdultLabel.TabIndex = 0;
            this.categoryAdultLabel.Text = "Phí vận chuyển hàng không";
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.confirmButton.BorderRadius = 8;
            this.confirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.confirmButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.confirmButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.confirmButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.confirmButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.confirmButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Location = new System.Drawing.Point(285, 530);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(25, 10, 25, 20);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(180, 50);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "ĐÓNG";
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // pricePanel
            // 
            this.pricePanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pricePanel.BorderThickness = 1;
            this.pricePanel.Controls.Add(this.totalDescLabel);
            this.pricePanel.Controls.Add(this.totalPriceLabel);
            this.pricePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pricePanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pricePanel.Location = new System.Drawing.Point(0, 70);
            this.pricePanel.Name = "pricePanel";
            this.pricePanel.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pricePanel.Size = new System.Drawing.Size(750, 80);
            this.pricePanel.TabIndex = 1;
            // 
            // totalDescLabel
            // 
            this.totalDescLabel.BackColor = System.Drawing.Color.Transparent;
            this.totalDescLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDescLabel.ForeColor = System.Drawing.Color.Gray;
            this.totalDescLabel.Location = new System.Drawing.Point(25, 15);
            this.totalDescLabel.Name = "totalDescLabel";
            this.totalDescLabel.Size = new System.Drawing.Size(429, 36);
            this.totalDescLabel.TabIndex = 1;
            this.totalDescLabel.Text = "Giá vé<br>Tổng giá cho tất cả các hành khách (đã bao gồm thuế, phí và chiết khấu)" +
    ".";
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.totalPriceLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.totalPriceLabel.Location = new System.Drawing.Point(485, 15);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(240, 40);
            this.totalPriceLabel.TabIndex = 0;
            this.totalPriceLabel.Text = "11.227.000 VND";
            this.totalPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.closeButton);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(750, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BorderRadius = 20;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.closeButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.closeButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.closeButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.closeButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(695, 15);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(40, 40);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "✕";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(25, 18);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(211, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "💰 Chi tiết giá vé";
            // 
            // frmPriceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(750, 600);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "frmPriceDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết giá vé";
            this.mainPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.adultPanel.ResumeLayout(false);
            this.adultPanel.PerformLayout();
            this.detailsAdultPanel.ResumeLayout(false);
            this.detailsAdultPanel.PerformLayout();
            this.detailsAdultFlow.ResumeLayout(false);
            this.categoryAdultPanel.ResumeLayout(false);
            this.categoryAdultPanel.PerformLayout();
            this.pricePanel.ResumeLayout(false);
            this.pricePanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm borderless;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;
        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private Guna.UI2.WinForms.Guna2Button closeButton;
        private Guna.UI2.WinForms.Guna2Panel pricePanel;
        private System.Windows.Forms.Label totalPriceLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel totalDescLabel;
        private Guna.UI2.WinForms.Guna2Button confirmButton;
        private System.Windows.Forms.FlowLayoutPanel contentPanel;
        private Guna.UI2.WinForms.Guna2Panel adultPanel;
        private System.Windows.Forms.Label adultSubLabel;
        private System.Windows.Forms.Label priceAdultLabel;
        private System.Windows.Forms.Label arrowAdultLabel;
        private Guna.UI2.WinForms.Guna2Panel detailsAdultPanel;
        private System.Windows.Forms.FlowLayoutPanel detailsAdultFlow;
        private Guna.UI2.WinForms.Guna2Panel categoryAdultPanel;
        private System.Windows.Forms.Label categoryAdultLabel;
        private System.Windows.Forms.Label categoryLabelPrice;
    }
}