using Guna.UI2.WinForms;
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
        private int scrollOffset = 0;
        private const int SCROLL_AMOUNT = 30;
        public FilterForm()
        {
            InitializeComponent();
        }

        private void SetupForm()
        {
            // Set initial positions as tags for all controls
            foreach (Control ctrl in scrollPanel.Controls)
            {
                ctrl.Tag = ctrl.Top;
            }

            // Enable mouse wheel scrolling
            this.MouseWheel += FilterForm_MouseWheel;
            scrollPanel.MouseWheel += FilterForm_MouseWheel;
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            scrollOffset = e.NewValue;
            foreach (Control ctrl in scrollPanel.Controls)
            {
                ctrl.Top = ctrl.Tag != null ? (int)ctrl.Tag - scrollOffset : ctrl.Top;
            }
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
            SetupForm();
            btnBudgetToggle.Image = CreateArrowIcon(true);
            btnStopsToggle.Image = CreateArrowIcon(true);
            btnFlightTimeToggle.Image = CreateArrowIcon(true);
            trackBudget.Value = trackBudget.Maximum;
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

        private void FilterForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (vScrollBar.Visible)
            {
                int newValue = vScrollBar.Value - (e.Delta / 120 * SCROLL_AMOUNT);
                newValue = Math.Max(vScrollBar.Minimum, Math.Min(newValue, vScrollBar.Maximum));
                vScrollBar.Value = newValue;

                foreach (Control ctrl in scrollPanel.Controls)
                {
                    if (ctrl.Tag == null) ctrl.Tag = ctrl.Top + vScrollBar.Value;
                    ctrl.Top = (int)ctrl.Tag - vScrollBar.Value;
                }
            }
        }

        private void btnBudgetToggle_Click(object sender, EventArgs e)
        {
            ToggleSection(pnlBudget, btnBudgetToggle);
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

        private void btnStopsToggle_Click(object sender, EventArgs e)
        {

        }

        private void ToggleSection(Guna2Panel panel, Guna2ImageButton btn)
        {
            bool isExpanded = panel.Height > 50;
            if (isExpanded)
            {
                panel.Height = 40;
                btn.Image = CreateArrowIcon(false);
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl != lblBudget && ctrl != btn)
                    {
                        ctrl.Visible = false;
                    }
                }
            }
            else
            {
                if (panel == pnlBudget) panel.Height = 120;
                else if (panel == pnlStops) panel.Height = 100;

                btn.Image = CreateArrowIcon(true);
                foreach (Control ctrl in panel.Controls)
                {
                    ctrl.Visible = true;
                }
            }
            UpdateScrollBar(GetTotalContentHeight());
        }

        private void UpdateScrollBar(int contentHeight)
        {
            int visibleHeight = scrollPanel.Height;
            if (contentHeight > visibleHeight)
            {
                vScrollBar.Visible = true;
                vScrollBar.Maximum = contentHeight - visibleHeight + 100;
                vScrollBar.LargeChange = visibleHeight / 10;
            }
            else
            {
                vScrollBar.Visible = false;
            }
        }

        private int GetTotalContentHeight()
        {
            int maxY = 0;
            foreach (Control ctrl in scrollPanel.Controls)
            {
                int bottom = ctrl.Location.Y + ctrl.Height;
                if (bottom > maxY) maxY = bottom;
            }
            return maxY;
        }
    }
}
