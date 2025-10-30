using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class FilterForm : Form
    {
        public FilterForm()
        {
            InitializeComponent();
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            btnBudgetToggle.Image = CreateArrowIcon(true);
        }

        private Image CreateArrowIcon(bool isDown)
        {
            Bitmap bmp = new Bitmap(20, 20);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Point[] points = isDown ?
                    new Point[] { new Point(5, 7), new Point(15, 7), new Point(10, 13) } :
                    new Point[] { new Point(5, 13), new Point(15, 13), new Point(10, 7) };
                g.FillPolygon(new SolidBrush(Color.FromArgb(0, 102, 102)), points);
            }
            return bmp;
        }

        private void btnBudgetToggle_Click(object sender, EventArgs e)
        {

        }

        private void trackBudget_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void trackBudget_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceLabels();
        }

        private void UpdatePriceLabels()
        {
            if (trackBudget.Value == trackBudget.Minimum)
            {
                lblMaxPrice.Text = string.Format("{0:N0} VND", trackBudget.Maximum * 1000);
                lblMaxPrice.ForeColor = System.Drawing.Color.Black;
                lblMinPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            }else
            {
                lblMaxPrice.Text = string.Format("{0:N0} VND", trackBudget.Value * 1000);
                lblMaxPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
                lblMinPrice.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}
