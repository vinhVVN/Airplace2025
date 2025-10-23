namespace Airplace2025
{
    partial class StopControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbThoiLuong = new System.Windows.Forms.Label();
            this.pnlTimeline = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "STOP";
            // 
            // lbThoiLuong
            // 
            this.lbThoiLuong.AutoSize = true;
            this.lbThoiLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThoiLuong.Location = new System.Drawing.Point(617, 10);
            this.lbThoiLuong.Name = "lbThoiLuong";
            this.lbThoiLuong.Size = new System.Drawing.Size(52, 16);
            this.lbThoiLuong.TabIndex = 1;
            this.lbThoiLuong.Text = "1 hr 30";
            // 
            // pnlTimeline
            // 
            this.pnlTimeline.BackColor = System.Drawing.Color.White;
            this.pnlTimeline.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTimeline.Location = new System.Drawing.Point(0, 0);
            this.pnlTimeline.Name = "pnlTimeline";
            this.pnlTimeline.Size = new System.Drawing.Size(30, 35);
            this.pnlTimeline.TabIndex = 2;
            this.pnlTimeline.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTimeline_Paint);
            // 
            // StopControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.pnlTimeline);
            this.Controls.Add(this.lbThoiLuong);
            this.Controls.Add(this.label1);
            this.Name = "StopControl";
            this.Size = new System.Drawing.Size(689, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbThoiLuong;
        private System.Windows.Forms.Panel pnlTimeline;
    }
}
