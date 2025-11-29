namespace Airplace2025
{
    partial class frmThanhToan
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpBookingInfo = new System.Windows.Forms.GroupBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tabPaymentMethods = new System.Windows.Forms.TabControl();
            this.tabCash = new System.Windows.Forms.TabPage();
            this.lblChange = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabTransfer = new System.Windows.Forms.TabPage();
            this.chkTransferConfirmed = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.btnComplete = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.grpBookingInfo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.tabPaymentMethods.SuspendLayout();
            this.tabCash.SuspendLayout();
            this.tabTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeft.Controls.Add(this.grpBookingInfo);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 60);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(300, 490);
            this.pnlLeft.TabIndex = 0;
            // 
            // grpBookingInfo
            // 
            this.grpBookingInfo.Controls.Add(this.lblTotalAmount);
            this.grpBookingInfo.Controls.Add(this.label3);
            this.grpBookingInfo.Controls.Add(this.lblCustomerName);
            this.grpBookingInfo.Controls.Add(this.label2);
            this.grpBookingInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBookingInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBookingInfo.Location = new System.Drawing.Point(10, 10);
            this.grpBookingInfo.Name = "grpBookingInfo";
            this.grpBookingInfo.Size = new System.Drawing.Size(280, 200);
            this.grpBookingInfo.TabIndex = 0;
            this.grpBookingInfo.TabStop = false;
            this.grpBookingInfo.Text = "Thông tin thanh toán";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalAmount.Location = new System.Drawing.Point(6, 110);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(268, 30);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "0 VND";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tổng tiền cần thu";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblCustomerName.Location = new System.Drawing.Point(10, 50);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(106, 20);
            this.lblCustomerName.TabIndex = 3;
            this.lblCustomerName.Text = "Nguyen Van A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khách hàng";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THANH TOÁN";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tabPaymentMethods);
            this.pnlRight.Controls.Add(this.btnComplete);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(300, 60);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(500, 490);
            this.pnlRight.TabIndex = 2;
            // 
            // tabPaymentMethods
            // 
            this.tabPaymentMethods.Controls.Add(this.tabCash);
            this.tabPaymentMethods.Controls.Add(this.tabTransfer);
            this.tabPaymentMethods.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPaymentMethods.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPaymentMethods.Location = new System.Drawing.Point(10, 10);
            this.tabPaymentMethods.Name = "tabPaymentMethods";
            this.tabPaymentMethods.SelectedIndex = 0;
            this.tabPaymentMethods.Size = new System.Drawing.Size(480, 400);
            this.tabPaymentMethods.TabIndex = 0;
            // 
            // tabCash
            // 
            this.tabCash.Controls.Add(this.lblChange);
            this.tabCash.Controls.Add(this.label6);
            this.tabCash.Controls.Add(this.txtCashReceived);
            this.tabCash.Controls.Add(this.label5);
            this.tabCash.Location = new System.Drawing.Point(4, 26);
            this.tabCash.Name = "tabCash";
            this.tabCash.Padding = new System.Windows.Forms.Padding(3);
            this.tabCash.Size = new System.Drawing.Size(472, 370);
            this.tabCash.TabIndex = 0;
            this.tabCash.Text = "Tiền mặt";
            this.tabCash.UseVisualStyleBackColor = true;
            // 
            // lblChange
            // 
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.Green;
            this.lblChange.Location = new System.Drawing.Point(20, 110);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(430, 30);
            this.lblChange.TabIndex = 3;
            this.lblChange.Text = "0 VND";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tiền trả lại (dư):";
            // 
            // txtCashReceived
            // 
            this.txtCashReceived.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashReceived.Location = new System.Drawing.Point(20, 45);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(430, 29);
            this.txtCashReceived.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số tiền đã nhận:";
            // 
            // tabTransfer
            // 
            this.tabTransfer.Controls.Add(this.chkTransferConfirmed);
            this.tabTransfer.Controls.Add(this.label7);
            this.tabTransfer.Controls.Add(this.picQRCode);
            this.tabTransfer.Location = new System.Drawing.Point(4, 26);
            this.tabTransfer.Name = "tabTransfer";
            this.tabTransfer.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransfer.Size = new System.Drawing.Size(472, 370);
            this.tabTransfer.TabIndex = 1;
            this.tabTransfer.Text = "Chuyển khoản (QR)";
            this.tabTransfer.UseVisualStyleBackColor = true;
            // 
            // chkTransferConfirmed
            // 
            this.chkTransferConfirmed.AutoSize = true;
            this.chkTransferConfirmed.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTransferConfirmed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.chkTransferConfirmed.Location = new System.Drawing.Point(136, 325);
            this.chkTransferConfirmed.Name = "chkTransferConfirmed";
            this.chkTransferConfirmed.Size = new System.Drawing.Size(200, 24);
            this.chkTransferConfirmed.TabIndex = 2;
            this.chkTransferConfirmed.Text = "Đã kiểm tra nhận đủ tiền";
            this.chkTransferConfirmed.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Quét mã QR để thanh toán qua VietQR";
            // 
            // picQRCode
            // 
            this.picQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQRCode.Location = new System.Drawing.Point(96, 35);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(280, 280);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRCode.TabIndex = 0;
            this.picQRCode.TabStop = false;
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnComplete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnComplete.FlatAppearance.BorderSize = 0;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(10, 430);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(480, 50);
            this.btnComplete.TabIndex = 1;
            this.btnComplete.Text = "HOÀN TẤT VÀ XUẤT VÉ";
            this.btnComplete.UseVisualStyleBackColor = false;
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán";
            this.pnlLeft.ResumeLayout(false);
            this.grpBookingInfo.ResumeLayout(false);
            this.grpBookingInfo.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.tabPaymentMethods.ResumeLayout(false);
            this.tabCash.ResumeLayout(false);
            this.tabCash.PerformLayout();
            this.tabTransfer.ResumeLayout(false);
            this.tabTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpBookingInfo;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.TabControl tabPaymentMethods;
        private System.Windows.Forms.TabPage tabCash;
        private System.Windows.Forms.TabPage tabTransfer;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox picQRCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkTransferConfirmed;
    }
}
