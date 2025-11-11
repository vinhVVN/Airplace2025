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

        // Thuộc tính lưu trữ các giá trị bộ lọc
        public string SelectedCabin { get; private set; }
        public decimal MaxBudget { get; private set; }
        public bool DirectFlightOnly { get; private set; }
        public int DepartureTimeSlot { get; private set; } // 0: Any, 1: Morning, 2: Afternoon, 3: Evening
        public int ArrivalTimeSlot { get; private set; } // 0: Any, 1: Morning, 2: Afternoon, 3: Evening
        public List<string> SelectedAirlines { get; private set; }

        // Session: Lưu trạng thái bộ lọc giữa các lần mở FilterForm
        private static bool sessionInitialized = false;
        private static string sessionCabin = "Tất cả";
        private static int sessionBudgetValue = -1; // -1 nghĩa là chưa set
        private static bool sessionDirectFlightOnly = false;
        private static int sessionDepartureTimeSlot = 0;
        private static int sessionArrivalTimeSlot = 0;
        private static bool sessionAllAirlines = true;
        private static bool sessionVietnamAirlines = true;
        private static bool sessionPacificAirlines = true;

        public FilterForm()
        {
            InitializeComponent();
            SelectedAirlines = new List<string>();
        }

        /// <summary>
        /// Thiết lập khoảng giá cho bộ lọc dựa trên giá vé của các chuyến bay
        /// </summary>
        public void SetPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice <= 0 || maxPrice <= 0 || minPrice >= maxPrice)
            {
                // Nếu giá không hợp lệ, sử dụng giá trị mặc định
                trackBudget.Minimum = 3063;
                trackBudget.Maximum = 8776;
            }
            else
            {
                // Chuyển đổi từ VND sang nghìn VND (đơn vị của trackbar)
                int minValue = (int)(minPrice / 1000);
                int maxValue = (int)(maxPrice / 1000);
                
                trackBudget.Minimum = minValue;
                trackBudget.Maximum = maxValue;
            }

            // Restore giá trị từ session hoặc set giá trị mặc định
            if (sessionInitialized && sessionBudgetValue >= trackBudget.Minimum && sessionBudgetValue <= trackBudget.Maximum)
            {
                trackBudget.Value = sessionBudgetValue;
            }
            else
            {
                trackBudget.Value = trackBudget.Maximum;
            }
            
            UpdatePriceLabels();
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
            // Xóa session
            ClearSession();

            // Reset tất cả các control về giá trị mặc định
            cboKhoang.SelectedIndex = 0;
            trackBudget.Value = trackBudget.Maximum;
            rbNoStop.Checked = true;
            rbDepartureAny.Checked = true;
            rbArrivalAny.Checked = true;
            chkAllAirlines.Checked = true;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            SetupForm();
            // Restore session nếu đã có
            RestoreSession();
        }

        /// <summary>
        /// Restore các giá trị từ session
        /// </summary>
        private void RestoreSession()
        {
            if (sessionInitialized)
            {
                // Restore Khoang
                int cabinIndex = cboKhoang.Items.IndexOf(sessionCabin);
                if (cabinIndex >= 0)
                {
                    cboKhoang.SelectedIndex = cabinIndex;
                }
                else
                {
                    cboKhoang.SelectedIndex = 0;
                }

                // Restore Budget (sẽ được cập nhật sau khi SetPriceRange được gọi)
                if (sessionBudgetValue >= 0)
                {
                    // Tạm thời lưu giá trị, sẽ apply sau khi SetPriceRange được gọi
                }

                // Restore Stops
                rbNoStop.Checked = !sessionDirectFlightOnly;
                rbDirectOnly.Checked = sessionDirectFlightOnly;

                // Restore Departure Time
                switch (sessionDepartureTimeSlot)
                {
                    case 0:
                        rbDepartureAny.Checked = true;
                        break;
                    case 1:
                        rbDepartureMorning.Checked = true;
                        break;
                    case 2:
                        rbDepartureAfternoon.Checked = true;
                        break;
                    case 3:
                        rbDepartureEvening.Checked = true;
                        break;
                }

                // Restore Arrival Time
                switch (sessionArrivalTimeSlot)
                {
                    case 0:
                        rbArrivalAny.Checked = true;
                        break;
                    case 1:
                        rbArrivalMorning.Checked = true;
                        break;
                    case 2:
                        rbArrivalAfternoon.Checked = true;
                        break;
                    case 3:
                        rbArrivalEvening.Checked = true;
                        break;
                }

                // Restore Airlines
                chkAllAirlines.Checked = sessionAllAirlines;
                chkVietnamAirlines.Checked = sessionVietnamAirlines;
                chkPacificAirlines.Checked = sessionPacificAirlines;
            }
        }

        /// <summary>
        /// Lưu các giá trị vào session
        /// </summary>
        private void SaveSession()
        {
            sessionInitialized = true;
            sessionCabin = cboKhoang.SelectedItem?.ToString() ?? "Tất cả";
            sessionBudgetValue = trackBudget.Value;
            sessionDirectFlightOnly = rbDirectOnly.Checked;
            
            // Lưu Departure Time Slot
            if (rbDepartureAny.Checked) sessionDepartureTimeSlot = 0;
            else if (rbDepartureMorning.Checked) sessionDepartureTimeSlot = 1;
            else if (rbDepartureAfternoon.Checked) sessionDepartureTimeSlot = 2;
            else if (rbDepartureEvening.Checked) sessionDepartureTimeSlot = 3;

            // Lưu Arrival Time Slot
            if (rbArrivalAny.Checked) sessionArrivalTimeSlot = 0;
            else if (rbArrivalMorning.Checked) sessionArrivalTimeSlot = 1;
            else if (rbArrivalAfternoon.Checked) sessionArrivalTimeSlot = 2;
            else if (rbArrivalEvening.Checked) sessionArrivalTimeSlot = 3;

            // Lưu Airlines
            sessionAllAirlines = chkAllAirlines.Checked;
            sessionVietnamAirlines = chkVietnamAirlines.Checked;
            sessionPacificAirlines = chkPacificAirlines.Checked;
        }

        /// <summary>
        /// Xóa session và reset về giá trị mặc định
        /// </summary>
        private static void ClearSession()
        {
            sessionInitialized = false;
            sessionCabin = "Tất cả";
            sessionBudgetValue = -1;
            sessionDirectFlightOnly = false;
            sessionDepartureTimeSlot = 0;
            sessionArrivalTimeSlot = 0;
            sessionAllAirlines = true;
            sessionVietnamAirlines = true;
            sessionPacificAirlines = true;
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

        private void trackBudget_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void trackBudget_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceLabels();
        }

        private void UpdatePriceLabels()
        {
            // Cập nhật lblMinPrice với giá trị Minimum của trackbar
            lblMinPrice.Text = string.Format("{0:N0} VND", trackBudget.Minimum * 1000);
            
            // Cập nhật lblMaxPrice dựa trên giá trị hiện tại của trackbar
            if (trackBudget.Value == trackBudget.Maximum)
            {
                lblMaxPrice.Text = string.Format("{0:N0} VND", trackBudget.Maximum * 1000);
                lblMaxPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
                lblMinPrice.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lblMaxPrice.Text = string.Format("{0:N0} VND", trackBudget.Value * 1000);
                lblMaxPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
                lblMinPrice.ForeColor = System.Drawing.Color.Black;
            }
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
                    if (ctrl != lblBudget && ctrl != lblStops && ctrl != lblFlightTime &&
                        ctrl != lblAirlines && ctrl != btn)
                    {
                        ctrl.Visible = false;
                    }
                }
            }
            else
            {
                if (panel == pnlBudget) panel.Height = 120;
                else if (panel == pnlStops) panel.Height = 100;
                else if (panel == pnlFlightTime) panel.Height = 280;
                else if (panel == pnlAirlines) panel.Height = 140;

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
            vScrollBar.Maximum = 999;
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

        private void chkAllAirlines_CheckedChanged(object sender, EventArgs e)
        {
            chkPacificAirlines.Checked = chkAllAirlines.Checked;
            chkVietnamAirlines.Checked = chkAllAirlines.Checked;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Lưu giá trị Khoang
            SelectedCabin = cboKhoang.SelectedItem?.ToString() ?? "Tất cả";

            // Lưu giá trị Ngân sách
            MaxBudget = trackBudget.Value * 1000m; // Chuyển từ nghìn sang đơn vị đầy đủ

            // Lưu giá trị Chuyến bay thẳng
            DirectFlightOnly = rbDirectOnly.Checked;

            // Lưu giá trị Thời gian khởi hành
            if (rbDepartureAny.Checked) DepartureTimeSlot = 0;
            else if (rbDepartureMorning.Checked) DepartureTimeSlot = 1;
            else if (rbDepartureAfternoon.Checked) DepartureTimeSlot = 2;
            else if (rbDepartureEvening.Checked) DepartureTimeSlot = 3;

            // Lưu giá trị Thời gian đến
            if (rbArrivalAny.Checked) ArrivalTimeSlot = 0;
            else if (rbArrivalMorning.Checked) ArrivalTimeSlot = 1;
            else if (rbArrivalAfternoon.Checked) ArrivalTimeSlot = 2;
            else if (rbArrivalEvening.Checked) ArrivalTimeSlot = 3;

            // Lưu giá trị Hãng hàng không
            SelectedAirlines.Clear();
            if (chkAllAirlines.Checked)
            {
                SelectedAirlines.Add("All");
            }
            else
            {
                if (chkVietnamAirlines.Checked) SelectedAirlines.Add("Vietnam Airlines");
                if (chkPacificAirlines.Checked) SelectedAirlines.Add("Pacific Airlines");
            }

            // Lưu tất cả giá trị vào session để giữ lại cho lần mở sau
            SaveSession();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FilterForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }
    }
}
