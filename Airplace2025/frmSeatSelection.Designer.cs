namespace Airplace2025
{
    partial class frmSeatSelection
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
            this.lblSelected = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblSelected
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSelected.Location = new System.Drawing.Point(10, 10);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(150, 19);
            this.lblSelected.TabIndex = 0;
            this.lblSelected.Text = "Ghế đã chọn: (chưa chọn)";

            // frmSeatSelection
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.lblSelected);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeatSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Ghế";
            //this.Load += new System.EventHandler(this.frmSeatSelection_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public System.Windows.Forms.Label lblSelected;
    }
}
