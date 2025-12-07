using Airplace2025.BLL.DAO;
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
        private static Dictionary<string, bool> sessionAirlineStates = new Dictionary<string, bool>();

        // Danh sách checkbox hãng bay động
        private List<Guna2CheckBox> airlineCheckBoxes = new List<Guna2CheckBox>();
        private DataTable airlineData;

        // Lưu giá min/max thực tế từ kết quả tìm kiếm
        private decimal actualMinPrice = 0;
        private decimal actualMaxPrice = 0;

        public FilterForm()
        {
            InitializeComponent();
            SelectedAirlines = new List<string>();
        }

        /// <summary>
        /// Lấy danh sách hãng bay từ database thông qua BLL
        /// </summary>
        private void LoadAirlinesFromDatabase()
        {
            try
            {
                // Sử dụng AirlineDAO để lấy danh sách hãng bay
                airlineData = AirlineDAO.Instance.GetAirlineList();
                CreateAirlineCheckBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hãng bay: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tạo động các checkbox cho mỗi hãng bay
        /// </summary>
        private void CreateAirlineCheckBoxes()
        {
            // Xóa các checkbox cũ (nếu có)
            foreach (var chk in airlineCheckBoxes)
            {
                pnlAirlines.Controls.Remove(chk);
                chk.Dispose();
            }
            airlineCheckBoxes.Clear();

            if (airlineData == null || airlineData.Rows.Count == 0)
                return;

            int startY = 45; // Vị trí bắt đầu sau checkbox "Chọn tất cả"
            int spacing = 30; // Khoảng cách giữa các checkbox

            // Cập nhật vị trí checkbox "Chọn tất cả"
            chkAllAirlines.Location = new Point(10, startY);
            startY += spacing;

            foreach (DataRow row in airlineData.Rows)
            {
                string maHangBay = row["MaHangBay"].ToString();
                string tenHangBay = row["TenHangBay"].ToString();

                Guna2CheckBox chk = new Guna2CheckBox
                {
                    AutoSize = true,
                    Name = $"chk_{maHangBay}",
                    Text = tenHangBay,
                    Tag = maHangBay, // Lưu mã hãng bay trong Tag
                    Location = new Point(10, startY),
                    Checked = true,
                    CheckedState = { 
                        BorderColor = Color.FromArgb(255, 193, 7),
                        BorderRadius = 0,
                        BorderThickness = 0,
                        FillColor = Color.FromArgb(255, 193, 7)
                    },
                    UncheckedState = {
                        BorderColor = Color.FromArgb(125, 137, 149),
                        BorderRadius = 0,
                        BorderThickness = 0,
                        FillColor = Color.FromArgb(125, 137, 149)
                    }
                };

                // Khởi tạo session state cho hãng bay mới nếu chưa có
                if (!sessionAirlineStates.ContainsKey(maHangBay))
                {
                    sessionAirlineStates[maHangBay] = true;
                }

                // Hook mouse wheel cho checkbox mới
                chk.MouseWheel += FilterForm_MouseWheel;

                airlineCheckBoxes.Add(chk);
                pnlAirlines.Controls.Add(chk);
                startY += spacing;
            }

            // Điều chỉnh chiều cao panel Airlines
            int newHeight = startY + 20;
            pnlAirlines.Height = newHeight;

            // Cập nhật lại layout và scrollbar
            RecalculateLayout();
        }

        /// <summary>
        /// Thiết lập khoảng giá cho bộ lọc dựa trên giá vé của các chuyến bay
        /// </summary>
        public void SetPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice <= 0 || maxPrice <= 0 || minPrice >= maxPrice)
            {
                // Nếu giá không hợp lệ, sử dụng giá trị mặc định
                actualMinPrice = 3063000;
                actualMaxPrice = 8776000;
                trackBudget.Minimum = 3063;
                trackBudget.Maximum = 8776;
            }
            else
            {
                // Lưu giá thực tế (VND)
                actualMinPrice = minPrice;
                actualMaxPrice = maxPrice;
                
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

            // Enable mouse wheel scrolling cho tất cả các control
            this.MouseWheel += FilterForm_MouseWheel;
            scrollPanel.MouseWheel += FilterForm_MouseWheel;
            
            // Hook mouse wheel cho tất cả child controls để scroll hoạt động ở mọi nơi
            HookMouseWheelToAllControls(scrollPanel);
        }

        /// <summary>
        /// Hook mouse wheel event cho tất cả child controls để scroll hoạt động khi hover bất kỳ control nào
        /// </summary>
        private void HookMouseWheelToAllControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.MouseWheel += FilterForm_MouseWheel;
                if (ctrl.HasChildren)
                {
                    HookMouseWheelToAllControls(ctrl);
                }
            }
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            scrollOffset = e.NewValue;
            ApplyScroll();
        }

        private void ApplyScroll()
        {
            foreach (Control ctrl in scrollPanel.Controls)
            {
                if (ctrl.Tag != null)
                {
                    ctrl.Top = (int)ctrl.Tag - scrollOffset;
                }
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
            
            // Reset tất cả checkbox hãng bay
            chkAllAirlines.Checked = true;
            foreach (var chk in airlineCheckBoxes)
            {
                chk.Checked = true;
            }
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            SetupForm();
            // Load danh sách hãng bay từ database
            LoadAirlinesFromDatabase();
            // Restore session nếu đã có
            RestoreSession();
            // Cập nhật scrollbar sau khi load xong tất cả
            RecalculateLayout();
        }

        /// <summary>
        /// Tính toán lại layout và cập nhật scrollbar
        /// </summary>
        private void RecalculateLayout()
        {
            // Sắp xếp lại vị trí các panel theo thứ tự từ trên xuống
            int currentY = 70; // Bắt đầu sau lblKhoang và cboKhoang

            // Panel Budget
            pnlBudget.Location = new Point(0, currentY);
            currentY += pnlBudget.Height + 10;

            // Panel Stops
            pnlStops.Location = new Point(0, currentY);
            currentY += pnlStops.Height + 10;

            // Panel Flight Time
            pnlFlightTime.Location = new Point(0, currentY);
            currentY += pnlFlightTime.Height + 10;

            // Panel Airlines
            pnlAirlines.Location = new Point(0, currentY);
            currentY += pnlAirlines.Height + 20;

            // Cập nhật scrollbar dựa trên tổng chiều cao thực tế
            int totalContentHeight = currentY;
            int visibleHeight = scrollPanel.Height;

            if (totalContentHeight > visibleHeight)
            {
                vScrollBar.Visible = true;
                vScrollBar.Minimum = 0;
                vScrollBar.Maximum = totalContentHeight - visibleHeight + vScrollBar.LargeChange;
                vScrollBar.Value = 0;
            }
            else
            {
                vScrollBar.Visible = false;
                vScrollBar.Value = 0;
            }

            // Reset scroll position
            scrollOffset = 0;
            foreach (Control ctrl in scrollPanel.Controls)
            {
                ctrl.Tag = ctrl.Top;
            }
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

                // Restore Airlines - động từ session
                chkAllAirlines.Checked = sessionAllAirlines;
                foreach (var chk in airlineCheckBoxes)
                {
                    string maHangBay = chk.Tag?.ToString();
                    if (!string.IsNullOrEmpty(maHangBay) && sessionAirlineStates.ContainsKey(maHangBay))
                    {
                        chk.Checked = sessionAirlineStates[maHangBay];
                    }
                }
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

            // Lưu Airlines - động
            sessionAllAirlines = chkAllAirlines.Checked;
            foreach (var chk in airlineCheckBoxes)
            {
                string maHangBay = chk.Tag?.ToString();
                if (!string.IsNullOrEmpty(maHangBay))
                {
                    sessionAirlineStates[maHangBay] = chk.Checked;
                }
            }
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
            // Reset tất cả hãng bay về checked
            foreach (var key in sessionAirlineStates.Keys.ToList())
            {
                sessionAirlineStates[key] = true;
            }
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
                newValue = Math.Max(vScrollBar.Minimum, Math.Min(newValue, vScrollBar.Maximum - vScrollBar.LargeChange));
                vScrollBar.Value = newValue;
                scrollOffset = newValue;
                ApplyScroll();
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
            // lblMinPrice: Hiển thị giá RẺ NHẤT trong các chuyến bay tìm được
            lblMinPrice.Text = string.Format("{0:N0} VND", actualMinPrice);
            lblMinPrice.ForeColor = System.Drawing.Color.Black;
            
            // lblMaxPrice: Hiển thị giá ĐẮT NHẤT trong các chuyến bay tìm được
            lblMaxPrice.Text = string.Format("{0:N0} VND", actualMaxPrice);
            lblMaxPrice.ForeColor = System.Drawing.Color.FromArgb(0, 102, 102);
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
                else if (panel == pnlFlightTime) panel.Height = 340;
                else if (panel == pnlAirlines) panel.Height = pnlAirlines.Height; // Giữ nguyên chiều cao đã tính

                btn.Image = CreateArrowIcon(true);
                foreach (Control ctrl in panel.Controls)
                {
                    ctrl.Visible = true;
                }
            }
            RecalculateLayout();
        }

        private void UpdateScrollBar(int contentHeight)
        {
            int visibleHeight = scrollPanel.Height;
            if (contentHeight > visibleHeight)
            {
                vScrollBar.Visible = true;
                vScrollBar.Maximum = contentHeight - visibleHeight + vScrollBar.LargeChange;
                vScrollBar.LargeChange = Math.Max(10, visibleHeight / 10);
            }
            else
            {
                vScrollBar.Visible = false;
                vScrollBar.Value = 0;
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

        private void chkAllAirlines_CheckedChanged(object sender, EventArgs e)
        {
            // Đồng bộ tất cả checkbox hãng bay với checkbox "Chọn tất cả"
            foreach (var chk in airlineCheckBoxes)
            {
                chk.Checked = chkAllAirlines.Checked;
            }
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

            // Lưu giá trị Hãng hàng không - động
            SelectedAirlines.Clear();
            if (chkAllAirlines.Checked)
            {
                SelectedAirlines.Add("All");
            }
            else
            {
                foreach (var chk in airlineCheckBoxes)
                {
                    if (chk.Checked)
                    {
                        // Thêm tên hãng bay vào danh sách
                        SelectedAirlines.Add(chk.Text);
                    }
                }
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
