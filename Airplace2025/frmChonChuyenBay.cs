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
    public partial class frmChonChuyenBay : Form
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
        private TableLayoutPanel flightsTable; // Bảng thời gian chạy để lưu trữ các hàng (dòng) FlightCard.

        public frmChonChuyenBay(string sanBayDi, string sanBayDen, DateTime ngayDi, DateTime ngayVe, string soLuongHanhKhach, bool isRoundTrip)
        {
            InitializeComponent();
            this.sanBayDi = sanBayDi;
            this.sanBayDen = sanBayDen;
            // Xác thực ngày tháng ngay lập tức để ngăn chặn (người dùng chọn) các ngày trong quá khứ.
            this.ngayDi = ngayDi < DateTime.Today ? DateTime.Today : ngayDi;
            this.ngayVe = ngayVe < DateTime.Today ? DateTime.Today : ngayVe;
            this.soLuongHanhKhach = soLuongHanhKhach;
            this.isRoundTrip = isRoundTrip;
            //LoadFlights();
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

            // Khởi tạo bảng chuyến bay (TableLayoutPanel) bên trong panel đã có.
            EnsureFlightsTable();

            // Tải danh sách chuyến bay ban đầu.
            SafeLoadFlights();
        }

        /// <summary>
        /// Load airports into cbSanBayDi and cbSanBayDen from database.
        /// Display as "MaSanBay - TenSanBay" and value as MaSanBay.
        /// Keep labels in sync when user changes selection.
        /// </summary>
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

        private void UpdateToLabel()
        {
            string code = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);
            if (!string.IsNullOrWhiteSpace(code)) lblTo.Text = code;
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
            SafeLoadFlights();
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
            frmChonChuyenBay newForm = new frmChonChuyenBay(
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

            // Refresh flights as departure date changes
            SafeLoadFlights();
        }

        private void dtpNgayVe_ValueChanged(object sender, EventArgs e)
        {
            ValidateReturnDate();
            if (btnRoundTrip.Checked)
            {
                SafeLoadFlights();
            }
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
            SafeLoadFlights();
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
            filterForm.ShowDialog(this);
        }

        private void EnsureFlightsTable()
        {
            if (flightsTable != null) return;
            flightsTable = new TableLayoutPanel();
            flightsTable.Name = "flightsTable";
            flightsTable.AutoScroll = true;
            flightsTable.Dock = DockStyle.Fill;
            flightsTable.ColumnCount = 1;
            flightsTable.RowCount = 0;
            flightsTable.ColumnStyles.Clear();
            flightsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            // host inside existing container
            pnlChonChuyenBay.Controls.Add(flightsTable);
            flightsTable.BringToFront();
        }

        private void SafeLoadFlights()
        {
            try
            {
                if (!ValidateForm())
                {
                    RenderFlights(new List<ChuyenBayDTO>());
                    return;
                }

                string from = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
                string to = GetSelectedAirportCode(cbSanBayDen.SelectedValue, cbSanBayDen.SelectedItem);
                DateTime date = dtpNgayDi.Value.Date;

                // Validate date is not in the past before calling BLL
                if (date < DateTime.Today)
                {
                    // Automatically correct to today's date
                    dtpNgayDi.Value = DateTime.Today;
                    date = DateTime.Today;
                }

                int soGheCan = Math.Max(1, PassengerSelectionStateTemp.Adult + PassengerSelectionStateTemp.Child);

                var list = ChuyenBayBLL.Instance.TimKiemChuyenBay(from, to, date, soGheCan);
                RenderFlights(list);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Lỗi tải chuyến bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderFlights(IList<ChuyenBayDTO> flights)
        {
            EnsureFlightsTable();
            flightsTable.SuspendLayout();
            flightsTable.Controls.Clear();
            flightsTable.RowStyles.Clear();
            flightsTable.RowCount = 0;

            foreach (var f in flights)
            {
                var card = new FlightCard();

                card.DepartureTime = f.NgayGioBay.ToString("HH:mm");
                card.DepartureCity = f.MaSanBayDi;
                card.DepartureTerminal = ""; // optional
                card.ArrivalTime = f.NgayGioDen.ToString("HH:mm");
                card.ArrivalCity = f.MaSanBayDen;
                card.ArrivalTerminal = "";
                card.Airline = $"✈ {f.TenHangBay} - {f.TenMayBay}";
                var dur = f.NgayGioDen > f.NgayGioBay ? (f.NgayGioDen - f.NgayGioBay) : TimeSpan.FromMinutes(Math.Max(0, f.ThoiGianBay));
                card.Duration = $"⏱ Thời gian bay {Math.Max(0, (int)dur.TotalHours)}h {Math.Max(0, dur.Minutes)}phút";
                card.EconomyPrice = string.Format("{0:#,##0}", f.GiaCoBan);
                card.PremiumPrice = string.Format("{0:#,##0}", Math.Round(f.GiaCoBan * 1.5m, 0));
                card.BusinessPrice = string.Format("{0:#,##0}", Math.Round(f.GiaCoBan * 2.5m, 0));
                card.EconomySeats = f.SoGheTrong;

                card.Margin = new Padding(20, 10, 20, 10);
                card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                card.Width = flightsTable.ClientSize.Width - 40;

                flightsTable.RowCount += 1;
                flightsTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                flightsTable.Controls.Add(card, 0, flightsTable.RowCount - 1);
            }

            flightsTable.ResumeLayout();
        }
    }
}
