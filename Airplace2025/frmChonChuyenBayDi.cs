using Airplace2025.BLL; // for ChuyenBayBLL
using Airplace2025.BLL.DTO; // for ChuyenBayDTO
using Airplace2025.DAL; // for ChuyenBayDAO
using Airplace2025.State; // for PassengerSelectionState
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmChonChuyenBayDi : Form
    {
        private string sanBayDi;
        private string sanBayDen;
        private DateTime ngayDi;
        private DateTime ngayVe;
        private string soLuongHanhKhach;
        private bool isRoundTrip;
        private bool isUpdatingCombos = false;
        private List<string> airportOptions = new List<string>();
        private DataTable airportsDisplayTable; //Nguồn được lưu vào bộ nhớ cache cho việc lọc combo.
        private List<ChuyenBayDTO> currentFlights = new List<ChuyenBayDTO>(); // Lưu danh sách chuyến bay hiện tại để sắp xếp
        private string filterCabin = "Tất cả";
        private decimal filterMaxBudget = decimal.MaxValue;
        private bool filterDirectFlightOnly = false;
        private int filterDepartureTimeSlot = 0; // 0: Any, 1: Morning, 2: Afternoon, 3: Evening
        private int filterArrivalTimeSlot = 0; // 0: Any, 1: Morning, 2: Afternoon, 3: Evening
        private List<string> filterAirlines = new List<string>();
        private List<ChuyenBayDTO> originalFlights = new List<ChuyenBayDTO>(); // Store original unfiltered flights
        private decimal minFlightPrice = 0;
        private decimal maxFlightPrice = 0;

        public frmChonChuyenBayDi(string sanBayDi, string sanBayDen, DateTime ngayDi, DateTime ngayVe, string soLuongHanhKhach, bool isRoundTrip)
        {
            InitializeComponent();
            this.sanBayDi = sanBayDi;
            this.sanBayDen = sanBayDen;
            // Xác thực ngày tháng ngay lập tức để ngăn chặn (người dùng chọn) các ngày trong quá khứ.
            this.ngayDi = ngayDi < DateTime.Today ? DateTime.Today : ngayDi;
            this.ngayVe = ngayVe < DateTime.Today ? DateTime.Today : ngayVe;
            this.soLuongHanhKhach = soLuongHanhKhach;
            this.isRoundTrip = isRoundTrip;
            LoadFlights();
        }

        private void frmChonChuyenBay_Load(object sender, EventArgs e)
        {
            // Tải các sân bay vào hộp tổ hợp (combo box) từ cơ sở dữ liệu
            LoadAirportsToCombos();

            // Hiển thị mã sân bay từ frmDatVe
            if (!string.IsNullOrEmpty(sanBayDi))
            {
                lblFrom.Text = sanBayDi;
                TrySelectComboValue(cbSanBayDi, sanBayDi);
            }

            if (!string.IsNullOrEmpty(sanBayDen) && !string.Equals(sanBayDi, sanBayDen, StringComparison.OrdinalIgnoreCase))
            {
                lblTo.Text = sanBayDen;
                TrySelectComboValue(cbSanBayDen, sanBayDen);
            }

            // Hiển thị ngày đi với format "Th t, dd thg mm"
            // Cho phép chọn từ hôm nay
            dtpNgayDi.MinDate = DateTime.Today;
            dtpNgayVe.MinDate = DateTime.Today;

            // Gán giá trị đã được validate trong constructor
            dtpNgayDi.Value = ngayDi;
            dtpNgayVe.Value = ngayVe;

            dtpDeparture.Text = FormatDate(dtpNgayDi.Value);

            // Hiển thị ngày về với format "Th t, dd thg mm"
            dtpReturn.Text = FormatDate(dtpNgayVe.Value);

            // Hiển thị số lượng hành khách với format "{var} người"
            lblTotalPassengers.Text = FormatPassengerCount(soLuongHanhKhach);

            btnTotalCustomers.Text = FormatTotalPassengerCount(soLuongHanhKhach);
            // Bật/tắt hiển thị theo loại vé
            if (isRoundTrip)
            {
                btnRoundTrip.Checked = true;
                btnOneWay.Checked = false;
                pnlRoundTrip.Visible = true;
                pnlOneWay.Visible = false;
                lblReturn.Visible = true;
                dtpReturn.Visible = true;
            }
            else
            {
                btnRoundTrip.Checked = false;
                btnOneWay.Checked = true;
                pnlRoundTrip.Visible = false;
                pnlOneWay.Visible = true;
                lblReturn.Visible = false;
                dtpReturn.Visible = false;
            }

            pnlChonChuyenBay.Location = new System.Drawing.Point(0, 100);

            // Load chuyến bay từ database
            LoadFlights();
        }

        /// Load airports into cbSanBayDi and cbSanBayDen from database.
        /// Display as "MaSanBay - TenSanBay" and value as MaSanBay.
        private void LoadAirportsToCombos()
        {
            try
            {
                DataTable airports = ChuyenBayDAO.Instance.GetAirports();
                // Build display column
                DataTable buildDisplay(DataTable src)
                {
                    DataTable dt = src.Copy();
                    if (!dt.Columns.Contains("Display"))
                    {
                        dt.Columns.Add("Display", typeof(string));
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        string code = row["MaSanBay"].ToString();
                        string name = row["TenSanBay"].ToString();
                        row["Display"] = string.IsNullOrWhiteSpace(name) ? code : ($"{code} - {name}");
                    }
                    return dt;
                }

                // cache one built table, bind copies/views to each combo
                airportsDisplayTable = buildDisplay(airports);

                cbSanBayDi.DisplayMember = "Display";
                cbSanBayDi.ValueMember = "MaSanBay";
                cbSanBayDi.DataSource = airportsDisplayTable.Copy();

                cbSanBayDen.DisplayMember = "Display";
                cbSanBayDen.ValueMember = "MaSanBay";
                cbSanBayDen.DataSource = airportsDisplayTable.Copy();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi tải danh sách sân bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFromLabel()
        {
            string code = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
            if (!string.IsNullOrWhiteSpace(code))
            {
                lblFrom.Text = code;
            }
        }

        private string GetSelectedAirportCode(object selectedValue, object selectedItem)
        {
            if (selectedValue != null)
            {
                return selectedValue.ToString();
            }
            if (selectedItem != null)
            {
                var text = selectedItem.ToString();
                int dash = text.IndexOf(" - ");
                if (dash > 0) return text.Substring(0, dash).Trim();
                return text.Trim();
            }
            return string.Empty;
        }

        private void TrySelectComboValue(ComboBox combo, string value)
        {
            try
            {
                if (combo.DataSource != null && !string.IsNullOrWhiteSpace(value))
                {
                    combo.SelectedValue = value;
                }
            }
            catch { /* ignore invalid value */ }
        }

        /// <summary>
        /// Format ngày theo định dạng "Th t, dd thg mm" (ví dụ: Th 4, 29 thg 10)
        /// </summary>
        private string FormatDate(DateTime date)
        {
            string[] thuViet = { "CN", "T2", "T3", "T4", "T5", "T6", "T7" };
            string thu = thuViet[(int)date.DayOfWeek];

            return $"{thu}, {date.Day:D2} thg {date.Month:D2}";
        }

        /// <summary>
        /// Format số lượng hành khách theo định dạng "{var} người"
        /// </summary>
        private string FormatPassengerCount(string passengerText)
        {
            if (string.IsNullOrEmpty(passengerText))
                return "1 người";

            // Trích xuất số từ text như "1 hành khách" -> "1"
            string number = ExtractNumberFromText(passengerText);

            return $"{number} người";
        }

        private string FormatTotalPassengerCount(string passengerText)
        {
            if (string.IsNullOrEmpty(passengerText))
                return "1 hành khách";

            // Trích xuất số từ text như "1 hành khách" -> "1"
            string number = ExtractNumberFromText(passengerText);

            return $"{number} hành khách";
        }

        /// <summary>
        /// Trích xuất số từ chuỗi text
        /// </summary>
        private string ExtractNumberFromText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "1";

            // Tìm số đầu tiên trong chuỗi
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    // Tìm số liên tiếp
                    int start = i;
                    while (i < text.Length && char.IsDigit(text[i]))
                    {
                        i++;
                    }
                    return text.Substring(start, i - start);
                }
            }

            return "1"; // Mặc định là 1 nếu không tìm thấy số
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool isExpanded = btnChange.Checked;
            lblDown.Visible = !isExpanded;
            lblUp.Visible = isExpanded;
            pnlChange.Visible = isExpanded;

            // When expanding, reflect the last saved trip type
            if (isExpanded)
            {
                pnlChonChuyenBay.Location = new System.Drawing.Point(0, 306);
                if (isRoundTrip)
                {
                    btnRoundTrip.Checked = true;
                    btnOneWay.Checked = false;
                }
                else
                {
                    btnRoundTrip.Checked = false;
                    btnOneWay.Checked = true;
                }
            } else
            {
                pnlChonChuyenBay.Location = new System.Drawing.Point(0, 100);
            }
        }

        private void btnTotalCustomers_Click(object sender, EventArgs e)
        {
            frmSoLuongKhachHang soLuongKhachHangForm = new frmSoLuongKhachHang();
            // Open as modal to wait for user confirmation
            soLuongKhachHangForm.ShowDialog(this);

            // After dialog closes, refresh displayed totals from shared state
            int total = PassengerSelectionStateTemp.Total;
            btnTotalCustomers.Text = $"{total} Hành khách";
        }

        private void btnRoundTrip_CheckedChanged(object sender, EventArgs e)
        {
            bool isRoundTrip = btnRoundTrip.Checked;
            // Edit panel controls
            lblReturnDate.Visible = isRoundTrip;
            dtpNgayVe.Visible = isRoundTrip;
        }

        private void pnlRoundTrip_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void lblUp_Click(object sender, EventArgs e)
        {

        }

        private void pnlOneWay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void lblDown_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalPassengers_Click(object sender, EventArgs e)
        {

        }

        private void lblPassengers_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpReturn_Click(object sender, EventArgs e)
        {

        }

        private void lblReturn_Click(object sender, EventArgs e)
        {

        }

        private void lblDeparture_Click(object sender, EventArgs e)
        {

        }

        private void dtpDeparture_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTo_Click(object sender, EventArgs e)
        {

        }

        private void lblFrom_Click(object sender, EventArgs e)
        {

        }

        private void pnlThongTinDatCho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblReturnDate_Click(object sender, EventArgs e)
        {

        }

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

        private void cbSanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingCombos) return;
            try
            {
                isUpdatingCombos = true;

                // Determine selected 'from' airport code robustly
                string selectedFromCode = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);

                // Preserve current 'to' code if still valid
                string currentToCode = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);

                // Rebind 'to' combo via a filtered DataView (cannot modify Items when DataSource is set)
                if (airportsDisplayTable != null)
                {
                    string escaped = (selectedFromCode ?? string.Empty).Replace("'", "''");
                    var view = new DataView(airportsDisplayTable);
                    view.RowFilter = string.IsNullOrWhiteSpace(escaped) ? string.Empty : $"MaSanBay <> '{escaped}'";

                    cbSanBayDen.DisplayMember = "Display";
                    cbSanBayDen.ValueMember = "MaSanBay";
                    cbSanBayDen.DataSource = view;

                    if (!string.IsNullOrWhiteSpace(currentToCode) && !string.Equals(currentToCode, selectedFromCode, StringComparison.OrdinalIgnoreCase))
                    {
                        TrySelectComboValue(cbSanBayDen, currentToCode);
                    }
                    else
                    {
                        cbSanBayDen.SelectedIndex = -1;
                    }
                }

                // Update label to reflect selection
                UpdateFromLabel();
            }
            finally
            {
                isUpdatingCombos = false;
            }
            cbSanBayDi.Invalidate();
            UpdateEditButton();
            LoadFlights();
        }

        private void btnOneWay_CheckedChanged(object sender, EventArgs e)
        {
            bool oneWay = btnOneWay.Checked;
            if (oneWay)
            {
                // Edit panel controls
                lblReturnDate.Visible = false;
                dtpNgayVe.Visible = false;
            }
        }

        private void pnlChange_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            PassengerSelectionState.SetAdult(PassengerSelectionStateTemp.Adult);
            PassengerSelectionState.SetChild(PassengerSelectionStateTemp.Child);
            PassengerSelectionState.SetInfant(PassengerSelectionStateTemp.Infant);

            // Lấy dữ liệu từ controls đã chỉnh sửa
            string newSanBayDi = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
            string newSanBayDen = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);
            DateTime newNgayDi = dtpNgayDi.Value;
            DateTime newNgayVe = dtpNgayVe.Value;
            int total = PassengerSelectionStateTemp.Total;
            string newSoLuongHanhKhach = $"{total} hành khách";
            bool newIsRoundTrip = btnRoundTrip.Checked;

            // Đóng form hiện tại
            this.DialogResult = DialogResult.OK;

            // Tạo và hiển thị form mới với dữ liệu đã chỉnh sửa
            frmChonChuyenBayDi newForm = new frmChonChuyenBayDi(
                newSanBayDi,
                newSanBayDen,
                newNgayDi,
                newNgayVe,
                newSoLuongHanhKhach,
                newIsRoundTrip
            );

            this.Hide();
            newForm.ShowDialog();
            this.Close();
        }

        private void dtpNgayDi_ValueChanged(object sender, EventArgs e)
        {
            // Update minimum date for return date picker
            dtpNgayVe.MinDate = dtpNgayDi.Value.Date;

            // If return date is before departure date, set it to departure date
            ValidateReturnDate();
        }

        private void dtpNgayVe_ValueChanged(object sender, EventArgs e)
        {
            ValidateReturnDate();
            //if (btnRoundTrip.Checked)
            //{
            //    SafeLoadFlights();
            //}
        }

        private void ValidateReturnDate()
        {
            if (dtpNgayVe.Value < dtpNgayDi.Value)
            {
                dtpNgayVe.Value = dtpNgayDi.Value;
            }
        }

        private void cbSanBayDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEditButton();
            LoadFlights();
        }

        private void UpdateEditButton()
        {
            btnEditSave.Enabled = ValidateForm();
        }

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
            string fromCode = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
            string toCode = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);
            
            if (string.Equals(fromCode, toCode, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm();
            
            // Truyền giá trị min/max vào FilterForm
            filterForm.SetPriceRange(minFlightPrice, maxFlightPrice);
            
            if (filterForm.ShowDialog(this) == DialogResult.OK)
            {
                // Lấy các giá trị bộ lọc từ FilterForm
                filterCabin = filterForm.SelectedCabin;
                filterMaxBudget = filterForm.MaxBudget;
                filterDirectFlightOnly = filterForm.DirectFlightOnly;
                filterDepartureTimeSlot = filterForm.DepartureTimeSlot;
                filterArrivalTimeSlot = filterForm.ArrivalTimeSlot;
                filterAirlines = filterForm.SelectedAirlines;

                // Reset currentFlights từ originalFlights
                currentFlights = new List<ChuyenBayDTO>(originalFlights);

                // Áp dụng bộ lọc và sắp xếp, sau đó render lại
                ApplyFilters();
                ApplySorting();
                RenderFlights(currentFlights);
            }
        }

        private void pnlChonChuyenBay_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Load chuyến bay từ database dựa trên tiêu chí tìm kiếm
        /// </summary>
        private void LoadFlights()
        {
            try
            {
                // Kiểm tra validation trước khi tìm kiếm
                if (!ValidateForm())
                {
                    // Nếu không hợp lệ, hiển thị danh sách rỗng
                    RenderFlights(new List<ChuyenBayDTO>());
                    return;
                }

                // Lấy thông tin tìm kiếm
                string maSanBayDi = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
                string maSanBayDen = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);
                DateTime ngayDi = dtpNgayDi.Value.Date;

                // Validate date không trong quá khứ
                if (ngayDi < DateTime.Today)
                {
                    dtpNgayDi.Value = DateTime.Today;
                    ngayDi = DateTime.Today;
                }

                // Tính tổng số hành khách cần ghế (không tính em bé)
                int soNguoiLon = PassengerSelectionStateTemp.Adult;
                int soTreEm = PassengerSelectionStateTemp.Child;
                int soGheCan = Math.Max(1, soNguoiLon + soTreEm);

                // Gọi BLL để tìm kiếm chuyến bay
                var flights = ChuyenBayBLL.Instance.TimKiemChuyenBay(maSanBayDi, maSanBayDen, ngayDi, soGheCan);

                // Lưu danh sách chuyến bay gốc (chưa lọc)
                originalFlights = flights != null ? new List<ChuyenBayDTO>(flights) : new List<ChuyenBayDTO>();

                // Lưu danh sách chuyến bay hiện tại
                currentFlights = flights ?? new List<ChuyenBayDTO>();

                // Tính min/max giá vé từ danh sách chuyến bay gốc
                CalculateMinMaxPrice();

                // Cập nhật visibility của các control filter và sort
                UpdateFilterSortVisibility();

                // Áp dụng bộ lọc nếu có
                ApplyFilters();

                // Áp dụng sắp xếp nếu có
                ApplySorting();

                // Render kết quả
                RenderFlights(currentFlights);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi tải chuyến bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Hiển thị danh sách rỗng khi có lỗi
                RenderFlights(new List<ChuyenBayDTO>());
            }
        }

        /// <summary>
        /// Tính min/max giá vé từ danh sách chuyến bay
        /// </summary>
        private void CalculateMinMaxPrice()
        {
            if (originalFlights == null || originalFlights.Count == 0)
            {
                minFlightPrice = 0;
                maxFlightPrice = 0;
                return;
            }

            // Tính giá Economy cho mỗi chuyến bay
            var prices = originalFlights.Select(f => f.GiaEconomy ?? f.GiaCoBan).ToList();
            
            minFlightPrice = prices.Min();
            maxFlightPrice = prices.Max();
        }

        /// <summary>
        /// Cập nhật visibility của các control filter và sort dựa trên có chuyến bay hay không
        /// </summary>
        private void UpdateFilterSortVisibility()
        {
            bool hasFlights = originalFlights != null && originalFlights.Count > 0;
            
            btnFilter.Visible = hasFlights;
            cboSortType.Visible = hasFlights;
            lblSapXep.Visible = hasFlights;
        }

        /// <summary>
        /// Render danh sách chuyến bay lên tlpFlights
        /// </summary>
        private void RenderFlights(List<ChuyenBayDTO> flights)
        {
            try
            {
                // Cấu hình tlpFlights
                tlpFlights.SuspendLayout();
                tlpFlights.Controls.Clear();
                tlpFlights.RowStyles.Clear();
                tlpFlights.AutoScroll = true;
                tlpFlights.ColumnCount = 1;
                tlpFlights.RowCount = 0;
                tlpFlights.Dock = DockStyle.None;
                tlpFlights.ColumnStyles.Clear();
                tlpFlights.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                if (flights == null || flights.Count == 0)
                {
                    // Hiển thị thông báo không tìm thấy chuyến bay
                    Label lblNoFlights = new Label
                    {
                        Text = "Không tìm thấy chuyến bay phù hợp",
                        Font = new Font("Segoe UI", 12, System.Drawing.FontStyle.Regular),
                        ForeColor = Color.Gray,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        Height = 100
                    };
                    tlpFlights.RowCount = 1;
                    tlpFlights.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    tlpFlights.Controls.Add(lblNoFlights, 0, 0);
                }
                else
                {
                    // Thêm từng FlightCard vào tlpFlights
                    foreach (var flight in flights)
                    {
                        var card = new FlightCard();

                        // Tính thời gian bay
                        var duration = flight.NgayGioDen > flight.NgayGioBay 
                            ? (flight.NgayGioDen - flight.NgayGioBay) 
                            : TimeSpan.FromMinutes(Math.Max(0, flight.ThoiGianBay));
                        
                        int hours = (int)duration.TotalHours;
                        int minutes = duration.Minutes;

                        // Kiểm tra có sang ngày hôm sau không
                        bool isNextDay = flight.NgayGioDen.Date > flight.NgayGioBay.Date;

                        // Gán dữ liệu cho card
                        card.DepartureTime = flight.NgayGioBay.ToString("HH:mm");
                        card.DepartureCity = flight.MaSanBayDi;
                        card.DepartureTerminal = ""; // Có thể lấy từ DB nếu có
                        card.ArrivalTime = flight.NgayGioDen.ToString("HH:mm");
                        card.ArrivalCity = flight.MaSanBayDen;
                        card.ArrivalTerminal = ""; // Có thể lấy từ DB nếu có
                        card.Duration = $"⏱ Thời gian bay {hours}h {minutes}phút";
                        card.Airline = $"✈ {flight.MaChuyenBay} Khai thác bởi {flight.TenHangBay}";
                        
                        // Format giá tiền
                        decimal economyPrice = flight.GiaEconomy ?? flight.GiaCoBan;
                        decimal premiumPrice = flight.GiaPremium ?? (flight.GiaCoBan * 1.5m);
                        decimal businessPrice = flight.GiaBusiness ?? (flight.GiaCoBan * 2.5m);

                        card.EconomyPrice = string.Format("{0:#,##0}", economyPrice);
                        card.PremiumPrice = string.Format("{0:#,##0}", premiumPrice);
                        card.BusinessPrice = string.Format("{0:#,##0}", businessPrice);
                        card.EconomyPriceValue = economyPrice;
                        card.PremiumPriceValue = premiumPrice;
                        card.BusinessPriceValue = businessPrice;
                        card.FlightData = flight;
                        card.EconomySeats = flight.GheEconomy ?? flight.SoGheTrong;
                        card.PremiumSeats = flight.GhePremium ?? 0;
                        card.BusinessSeats = flight.GheBusiness ?? 0;

                        // Gán dữ liệu chi tiết cho FlightDetailForm
                        card.DepartureDate = "Khởi hành vào " + flight.NgayGioBay.ToString("dddd, dd 'tháng' MM, yyyy", new System.Globalization.CultureInfo("vi-VN"));
                        card.ArrivalDate = "Đến vào " + flight.NgayGioDen.ToString("dddd, dd 'tháng' MM, yyyy", new System.Globalization.CultureInfo("vi-VN"));
                        card.FlightNumber = flight.MaChuyenBay;
                        card.Aircraft = flight.TenMayBay ?? "N/A";
                        card.IsNextDay = isNextDay;
                        card.DepartureAirport = flight.TenSanBayDi;
                        card.ArrivalAirport = flight.TenSanBayDen;

                        // Cấu hình card
                        card.Margin = new Padding(5, 10, 5, 10);
                        card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                        card.FareSelected += FlightCard_FareSelected;

                        // Thêm row mới vào table
                        tlpFlights.RowCount += 1;
                        tlpFlights.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        tlpFlights.Controls.Add(card, 0, tlpFlights.RowCount - 1);
                    }
                }

                tlpFlights.ResumeLayout();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi hiển thị chuyến bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Áp dụng bộ lọc cho danh sách chuyến bay
        private void ApplyFilters()
        {
            if (originalFlights == null || originalFlights.Count == 0)
            {
                currentFlights = new List<ChuyenBayDTO>();
                return;
            }

            // Bắt đầu từ danh sách gốc
            var filteredFlights = originalFlights.AsEnumerable();

            // Lọc theo Khoang (Cabin)
            if (filterCabin != "Tất cả")
            {
                filteredFlights = filteredFlights.Where(f =>
                {
                    if (filterCabin == "PHỔ THÔNG")
                        return (f.GheEconomy ?? 0) > 0;
                    else if (filterCabin == "PHỔ THÔNG ĐẶC BIỆT")
                        return (f.GhePremium ?? 0) > 0;
                    else if (filterCabin == "THƯƠNG GIA")
                        return (f.GheBusiness ?? 0) > 0;
                    return true;
                });
            }

            // Lọc theo Ngân sách (lấy giá Economy)
            if (filterMaxBudget != decimal.MaxValue)
            {
                filteredFlights = filteredFlights.Where(f =>
                {
                    decimal economyPrice = f.GiaEconomy ?? f.GiaCoBan;
                    return economyPrice <= filterMaxBudget;
                });
            }

            // Lọc theo Chuyến bay thẳng (giả sử ThoiGianBay > 0 là chuyến bay thẳng)
            if (filterDirectFlightOnly)
            {
                filteredFlights = filteredFlights.Where(f => f.ThoiGianBay > 0);
            }

            // Lọc theo Thời gian khởi hành
            if (filterDepartureTimeSlot != 0)
            {
                filteredFlights = filteredFlights.Where(f =>
                {
                    int hour = f.NgayGioBay.Hour;
                    switch (filterDepartureTimeSlot)
                    {
                        case 1: // Morning (00:00 - 11:59)
                            return hour >= 0 && hour < 12;
                        case 2: // Afternoon (12:00 - 17:59)
                            return hour >= 12 && hour < 18;
                        case 3: // Evening (18:00 - 23:59)
                            return hour >= 18 && hour < 24;
                        default:
                            return true;
                    }
                });
            }

            // Lọc theo Thời gian đến
            if (filterArrivalTimeSlot != 0)
            {
                filteredFlights = filteredFlights.Where(f =>
                {
                    int hour = f.NgayGioDen.Hour;
                    switch (filterArrivalTimeSlot)
                    {
                        case 1: // Morning (00:00 - 11:59)
                            return hour >= 0 && hour < 12;
                        case 2: // Afternoon (12:00 - 17:59)
                            return hour >= 12 && hour < 18;
                        case 3: // Evening (18:00 - 23:59)
                            return hour >= 18 && hour < 24;
                        default:
                            return true;
                    }
                });
            }

            // Lọc theo Hãng hàng không
            if (filterAirlines != null && filterAirlines.Count > 0 && !filterAirlines.Contains("All"))
            {
                filteredFlights = filteredFlights.Where(f =>
                    filterAirlines.Any(airline => f.TenHangBay?.Contains(airline) == true)
                );
            }

            currentFlights = filteredFlights.ToList();
        }

        // Áp dụng sắp xếp cho danh sách chuyến bay hiện tại
        private void ApplySorting()
        {
            if (currentFlights == null || currentFlights.Count == 0)
                return;

            string sortType = cboSortType.SelectedItem?.ToString() ?? "Mặc định";

            switch (sortType)
            {
                case "Rẻ nhất":
                    // Sắp xếp theo giá Economy tăng dần
                    currentFlights = currentFlights
                        .OrderBy(f => f.GiaEconomy ?? f.GiaCoBan)
                        .ToList();
                    break;

                case "Thời gian khởi hành tăng dần":
                    // Sắp xếp theo thời gian khởi hành tăng dần
                    currentFlights = currentFlights
                        .OrderBy(f => f.NgayGioBay)
                        .ToList();
                    break;

                case "Thời gian khởi hành giảm dần":
                    // Sắp xếp theo thời gian khởi hành giảm dần
                    currentFlights = currentFlights
                        .OrderByDescending(f => f.NgayGioBay)
                        .ToList();
                    break;

                case "Thời gian bay tăng dần":
                    // Sắp xếp theo thời gian bay tăng dần
                    currentFlights = currentFlights
                        .OrderBy(f => {
                            if (f.NgayGioDen > f.NgayGioBay)
                                return (f.NgayGioDen - f.NgayGioBay).TotalMinutes;
                            return f.ThoiGianBay;
                        })
                        .ToList();
                    break;

                case "Mặc định":
                default:
                    // Không sắp xếp, giữ nguyên thứ tự từ database
                    break;
            }
        }

        // Event handler khi thay đổi kiểu sắp xếp
        private void cboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Áp dụng sắp xếp và render lại
            ApplySorting();
            RenderFlights(currentFlights);
        }

        private void FlightCard_FareSelected(object sender, SelectedFareEventArgs e)
        {
            if (e?.FareInfo == null)
            {
                return;
            }

            void ShowTicketDetails()
            {
                using (var detail = new frmChiTietVe(e.FareInfo))
                {
                    detail.ShowDialog(this);
                }
            }

            if (InvokeRequired)
            {
                BeginInvoke(new Action(ShowTicketDetails));
            }
            else
            {
                ShowTicketDetails();
            }
        }
    }
}
