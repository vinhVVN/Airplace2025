using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airplace2025.BLL;
using Airplace2025.BLL.DTO;
using Airplace2025.State;

namespace Airplace2025
{
    public partial class frmDatVe : Form
    {
        // Danh sách đầy đủ sân bay (để lọc hiển thị giữa 2 combobox)
        private List<string> airportOptions = new List<string>();
        // Cờ tránh vòng lặp khi đồng bộ 2 combobox
        private bool isUpdatingCombos = false;
        private const int ADULT_MIN = 1;
        private const int ADULT_MAX = 9;
        private const int CHILD_MIN = 0;
        private const int CHILD_MAX = 8;
        private const int INFANT_MIN = 0;
        private const int TOTAL_PASSENGER_MAX = 9;

        public frmDatVe()
        {
            InitializeComponent();
        }

        private void frmDatVe_Load(object sender, EventArgs e)
        {
            InitializeControls();
            UpdateAllButtons();
            cbSanBayDi_SelectedIndexChanged(sender, e);
            tlpDropDown.Visible = false;
            UpdateSearchButton();
        }

        private void InitializeControls()
        {
            try
            {
                LoadAirports();

                //LoadServiceClasses();

                dtpReturnDate.Visible = btnRoundTrip.Checked;
                lblReturnDate.Visible = btnRoundTrip.Checked;

                // Set minimum date for date pickers
                dtpNgayDi.MinDate = DateTime.Now.Date;
                dtpReturnDate.MinDate = DateTime.Now.Date;

                // Ensure return date is not before departure date
                ValidateReturnDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo controls: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load airports from database
        /// </summary>
        private void LoadAirports()
        {
            try
            {
                List<string> airports = ChuyenBayBLL.Instance.GetFormattedAirportList();

                // Lưu danh sách gốc để lọc giữa 2 combobox
                airportOptions = airports.ToList();

                cbSanBayDi.Items.Clear();
                cbSanBayDen.Items.Clear();

                foreach (string airport in airports)
                {
                    cbSanBayDi.Items.Add(airport);
                    cbSanBayDen.Items.Add(airport);
                }

                // Mặc định: sân bay đi chọn phần tử đầu tiên, sân bay đến chưa chọn
                if (cbSanBayDi.Items.Count > 0)
                    cbSanBayDi.SelectedIndex = 0;

                try
                {
                    cbSanBayDen.SelectedIndex = -1; // không chọn ban đầu
                }
                catch { /* một số phiên bản Guna2 cần StartIndex, fallback bên dưới */ }
                try
                {
                    // Nếu Guna2 hỗ trợ StartIndex
                    cbSanBayDen.StartIndex = -1;
                }
                catch { /* ignore nếu không có thuộc tính */ }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sân bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Fallback to hardcoded data
                string[] fallback = new string[] { "HAN - Nội Bài (Hà Nội)", "SGN - Tân Sơn Nhất (TP.HCM)", "DAD - Đà Nẵng", "CXR - Cam Ranh (Khánh Hòa)" };
                airportOptions = fallback.ToList();
                cbSanBayDi.Items.AddRange(fallback);
                cbSanBayDen.Items.AddRange(fallback);
                cbSanBayDi.SelectedIndex = 0;
                try { cbSanBayDen.SelectedIndex = -1; } catch { }
                try { cbSanBayDen.StartIndex = -1; } catch { }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Kiểm tra validation trước khi xử lý
            if (!ValidateForm())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã sân bay từ combobox
            string sanBayDi = ExtractAirportCode(cbSanBayDi.SelectedItem?.ToString());
            string sanBayDen = ExtractAirportCode(cbSanBayDen.SelectedItem?.ToString());
            
            // Lấy ngày đi và ngày về từ DateTimePicker
            DateTime ngayDi = dtpNgayDi.Value;
            DateTime ngayVe = dtpReturnDate.Value;
            
            // Lấy số lượng hành khách từ btnDropDown.Text
            string soLuongHanhKhach = btnDropDown.Text;
            
            // Xác định loại vé: khứ hồi hay một chiều
            bool isRoundTrip = btnRoundTrip.Checked;

            int adultCount = int.Parse(lblTotalAdult.Text);
            int childCount = int.Parse(lblTotalChild.Text);
            int infantCount = int.Parse(lblTotalInfant.Text);

            PassengerSelectionState.SetAdult(adultCount);
            PassengerSelectionState.SetChild(childCount);
            PassengerSelectionState.SetInfant(infantCount);

            PassengerSelectionStateTemp.SetAdult(adultCount);
            PassengerSelectionStateTemp.SetChild(childCount);
            PassengerSelectionStateTemp.SetInfant(infantCount);

            frmChonChuyenBay frm = new frmChonChuyenBay(sanBayDi, sanBayDen, ngayDi, ngayVe, soLuongHanhKhach, isRoundTrip);
            this.Hide();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
        }

        /// <summary>
        /// Trích xuất mã sân bay từ chuỗi sân bay
        /// Ví dụ: "HAN - Nội Bài (Hà Nội)" -> "HAN"
        /// </summary>
        private string ExtractAirportCode(string airportString)
        {
            if (string.IsNullOrEmpty(airportString))
                return "";

            // Tìm vị trí của dấu " - " để tách mã sân bay
            int dashIndex = airportString.IndexOf(" - ");
            if (dashIndex > 0)
            {
                return airportString.Substring(0, dashIndex).Trim();
            }

            // Nếu không có dấu " - ", trả về toàn bộ chuỗi
            return airportString.Trim();
        }

        private void btnRoundTrip_Click(object sender, EventArgs e)
        {
            bool isRoundTrip = btnRoundTrip.Checked;
            dtpReturnDate.Visible = isRoundTrip;
            lblReturnDate.Visible = isRoundTrip;
            lblRoundTrip.Visible = isRoundTrip;
            lblOneWay.Visible = !isRoundTrip;
            lblDFReturn.Visible = isRoundTrip;
        }

        private void btnDropDown_Click(object sender, EventArgs e)
        {
            bool isDropDown = btnDropDown.Checked;
            tlpDropDown.Visible = isDropDown;
        }

        // ============ ADULT ============
        private void SetAdultCount(int value)
        {
            // Clamp adult
            if (value < ADULT_MIN) value = ADULT_MIN;
            if (value > ADULT_MAX) value = ADULT_MAX;

            int currentChild = GetChildCount();
            int currentInfant = GetInfantCount();

            // Đảm bảo Adult + Child ≤ 9
            if (value + currentChild > TOTAL_PASSENGER_MAX)
            {
                currentChild = TOTAL_PASSENGER_MAX - value;
                SetChildCount(currentChild);
            }

            // Đảm bảo Infant ≤ Adult (em bé không thể nhiều hơn người lớn)
            if (currentInfant > value)
            {
                SetInfantCount(value);
            }

            // Cập nhật UI
            string normalized = value.ToString();
            if (lblTotalAdult.Text != normalized)
                lblTotalAdult.Text = normalized;

            UpdateAdultButtons();
        }

        private void UpdateAdultButtons()
        {
            int adult = GetAdultCount();
            int child = GetChildCount();

            btnMinusAdult.Enabled = adult > ADULT_MIN;
            btnPlusAdult.Enabled = adult < ADULT_MAX && (adult + child) < TOTAL_PASSENGER_MAX;

            btnMinusAdult.Invalidate();
            btnPlusAdult.Invalidate();
        }

        private int GetAdultCount()
        {
            return int.TryParse(lblTotalAdult.Text, out int v) ? v : ADULT_MIN;
        }

        private void btnPlusAdult_Click(object sender, EventArgs e)
        {
            SetAdultCount(GetAdultCount() + 1);
            UpdateAllButtons();
        }

        private void btnMinusAdult_Click(object sender, EventArgs e)
        {
            SetAdultCount(GetAdultCount() - 1);
            UpdateAllButtons();
        }

        private void lblTotalAdult_TextChanged(object sender, EventArgs e)
        {
            SetAdultCount(GetAdultCount());
        }

        // ============ CHILD ============
        private void SetChildCount(int value)
        {
            int currentAdult = GetAdultCount();

            // Clamp child
            if (value < CHILD_MIN) value = CHILD_MIN;
            if (value > CHILD_MAX) value = CHILD_MAX;

            // Đảm bảo Adult + Child ≤ 9
            int maxChild = TOTAL_PASSENGER_MAX - currentAdult;
            if (value > maxChild) value = maxChild;

            // Cập nhật UI
            string normalized = value.ToString();
            if (lblTotalChild.Text != normalized)
                lblTotalChild.Text = normalized;

            UpdateChildButtons();
        }

        private void UpdateChildButtons()
        {
            int adult = GetAdultCount();
            int child = GetChildCount();

            btnMinusChild.Enabled = child > CHILD_MIN;
            btnPlusChild.Enabled = child < CHILD_MAX && (adult + child) < TOTAL_PASSENGER_MAX;

            btnMinusChild.Invalidate();
            btnPlusChild.Invalidate();
        }

        private int GetChildCount()
        {
            return int.TryParse(lblTotalChild.Text, out int v) ? v : CHILD_MIN;
        }

        private void btnPlusChild_Click(object sender, EventArgs e)
        {
            SetChildCount(GetChildCount() + 1);
            UpdateAllButtons();
        }

        private void btnMinusChild_Click(object sender, EventArgs e)
        {
            SetChildCount(GetChildCount() - 1);
            UpdateAllButtons();
        }

        private void lblTotalChild_TextChanged(object sender, EventArgs e)
        {
            SetChildCount(GetChildCount());
        }

        // ============ INFANT ============
        private void SetInfantCount(int value)
        {
            int currentAdult = GetAdultCount();

            // Clamp infant
            if (value < INFANT_MIN) value = INFANT_MIN;

            // Infant không được vượt quá số người lớn
            if (value > currentAdult) value = currentAdult;

            // Cập nhật UI
            string normalized = value.ToString();
            if (lblTotalInfant.Text != normalized)
                lblTotalInfant.Text = normalized;

            UpdateInfantButtons();
        }

        private void UpdateInfantButtons()
        {
            int adult = GetAdultCount();
            int infant = GetInfantCount();

            btnMinusInfant.Enabled = infant > INFANT_MIN;
            btnPlusInfant.Enabled = infant < adult; // Em bé phải ít hơn hoặc bằng người lớn

            btnMinusInfant.Invalidate();
            btnPlusInfant.Invalidate();
        }

        private int GetInfantCount()
        {
            return int.TryParse(lblTotalInfant.Text, out int v) ? v : INFANT_MIN;
        }

        private void btnPlusInfant_Click(object sender, EventArgs e)
        {
            SetInfantCount(GetInfantCount() + 1);
            UpdateAllButtons();
        }

        private void btnMinusInfant_Click(object sender, EventArgs e)
        {
            SetInfantCount(GetInfantCount() - 1);
            UpdateAllButtons();
        }

        private void lblTotalInfant_TextChanged(object sender, EventArgs e)
        {
            SetInfantCount(GetInfantCount());
        }

        // ============ UPDATE ALL ============
        private void UpdateAllButtons()
        {
            UpdateAdultButtons();
            UpdateChildButtons();
            UpdateInfantButtons();
            int currentAdult = GetAdultCount();
            int currentInfant = GetInfantCount();
            int currentChild = GetChildCount();
            btnDropDown.Text = (currentAdult + currentChild + currentInfant).ToString() + " hành khách";
        }

        private void btnOneWay_Click(object sender, EventArgs e)
        {
            bool isOneWay = btnOneWay.Checked;
            dtpReturnDate.Visible = !isOneWay;
            lblReturnDate.Visible = !isOneWay;
            lblRoundTrip.Visible = !isOneWay;
            lblOneWay.Visible = isOneWay;
            lblDFReturn.Visible = !isOneWay;
        }

        private void cbSanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingCombos) return;
            try
            {
                isUpdatingCombos = true;

                string selectedFrom = cbSanBayDi.SelectedItem?.ToString();
                string selectedFromCode = ExtractAirportCode(selectedFrom);

                // Lưu lại lựa chọn hiện tại của Đến (nếu còn hợp lệ sẽ khôi phục)
                string currentTo = cbSanBayDen.SelectedItem?.ToString();

                cbSanBayDen.BeginUpdate();
                cbSanBayDen.Items.Clear();
                foreach (var ap in airportOptions)
                {
                    if (ExtractAirportCode(ap) != selectedFromCode)
                    {
                        cbSanBayDen.Items.Add(ap);
                    }
                }
                cbSanBayDen.EndUpdate();

                // Khôi phục lựa chọn nếu vẫn tồn tại và khác mã sân bay đi
                if (!string.IsNullOrEmpty(currentTo) && ExtractAirportCode(currentTo) != selectedFromCode)
                {
                    int idx = cbSanBayDen.Items.IndexOf(currentTo);
                    if (idx >= 0) cbSanBayDen.SelectedIndex = idx; else cbSanBayDen.SelectedIndex = -1;
                }
                else
                {
                    cbSanBayDen.SelectedIndex = -1;
                }
            }
            finally
            {
                isUpdatingCombos = false;
            }
            cbSanBayDi.Invalidate();
        }

        /// <summary>
        /// Validate and update return date when departure date changes
        /// </summary>
        private void dtpNgayDi_ValueChanged(object sender, EventArgs e)
        {
            // Update minimum date for return date picker
            dtpReturnDate.MinDate = dtpNgayDi.Value.Date;
            
            // If return date is before departure date, set it to departure date
            ValidateReturnDate();
        }

        /// <summary>
        /// Validate return date when it changes
        /// </summary>
        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            ValidateReturnDate();
        }

        /// <summary>
        /// Handle change in destination airport selection
        /// </summary>
        private void cbSanBayDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSearchButton();
        }

        /// <summary>
        /// Ensure return date is not before departure date
        /// </summary>
        private void ValidateReturnDate()
        {
            if (dtpReturnDate.Value < dtpNgayDi.Value)
            {
                dtpReturnDate.Value = dtpNgayDi.Value;
            }
        }

        /// <summary>
        /// Validate all required fields before allowing search
        /// </summary>
        private bool ValidateForm()
        {
            // Kiểm tra sân bay đi đã được chọn
            if (cbSanBayDi.SelectedIndex < 0 || cbSanBayDi.SelectedItem == null)
            {
                return false;
            }

            // Kiểm tra sân bay đến đã được chọn
            if (cbSanBayDen.SelectedIndex < 0 || cbSanBayDen.SelectedItem == null)
            {
                return false;
            }

            // Kiểm tra sân bay đi và đến không được trùng nhau
            string fromCode = ExtractAirportCode(cbSanBayDi.SelectedItem?.ToString());
            string toCode = ExtractAirportCode(cbSanBayDen.SelectedItem?.ToString());
            
            if (!string.IsNullOrEmpty(fromCode) && !string.IsNullOrEmpty(toCode) && 
                string.Equals(fromCode, toCode, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Update search button enabled state based on form validation
        /// </summary>
        private void UpdateSearchButton()
        {
            btnTimKiem.Enabled = ValidateForm();
        }
    }
}

