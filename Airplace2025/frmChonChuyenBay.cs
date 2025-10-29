using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data; // for DataTable
using Airplace2025.DAL; // for ChuyenBayDAO
using Airplace2025.State; // for PassengerSelectionState

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

        public frmChonChuyenBay()
        {
            InitializeComponent();
        }

        public frmChonChuyenBay(string sanBayDi, string sanBayDen, DateTime ngayDi, DateTime ngayVe, string soLuongHanhKhach, bool isRoundTrip)
        {
            InitializeComponent();
            this.sanBayDi = sanBayDi;
            this.sanBayDen = sanBayDen;
            this.ngayDi = ngayDi;
            this.ngayVe = ngayVe;
            this.soLuongHanhKhach = soLuongHanhKhach;
            this.isRoundTrip = isRoundTrip;
        }

        private void frmChonChuyenBay_Load(object sender, EventArgs e)
        {
            // Load airports to combo boxes from database and sync with labels
            LoadAirportsToCombos();

            // Hiển thị mã sân bay từ frmDatVe
            if (!string.IsNullOrEmpty(sanBayDi))
            {
                lblFrom.Text = sanBayDi;
                TrySelectComboValue(cbSanBayDi, sanBayDi);
            }
            
            if (!string.IsNullOrEmpty(sanBayDen))
            {
                lblTo.Text = sanBayDen;
                TrySelectComboValue(cbSanBayDen, sanBayDen);
            }

            // Hiển thị ngày đi với format "Th t, dd thg mm"
            // Cho phép chọn từ hôm nay
            dtpNgayDi.MinDate = DateTime.Today;
            dtpNgayVe.MinDate = DateTime.Today;

            // Gán giá trị nhận từ frmDatVe, đảm bảo không nhỏ hơn hôm nay
            DateTime safeNgayDi = ngayDi < DateTime.Today ? DateTime.Today : ngayDi;
            DateTime safeNgayVe = ngayVe < DateTime.Today ? DateTime.Today : ngayVe;
            dtpNgayDi.Value = safeNgayDi;
            dtpNgayVe.Value = safeNgayVe;

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

                DataTable dtFrom = buildDisplay(airports);
                DataTable dtTo = buildDisplay(airports);

                cbSanBayDi.DisplayMember = "Display";
                cbSanBayDi.ValueMember = "MaSanBay";
                cbSanBayDi.DataSource = dtFrom;

                cbSanBayDen.DisplayMember = "Display";
                cbSanBayDen.ValueMember = "MaSanBay";
                cbSanBayDen.DataSource = dtTo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sân bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateFromLabel()
        {
            string code = GetSelectedAirportCode(cbSanBayDi.SelectedValue, cbSanBayDi.SelectedItem);
            if (!string.IsNullOrWhiteSpace(code)) lblFrom.Text = code;
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
        }

        private void btnTotalCustomers_Click(object sender, EventArgs e)
        {
            frmSoLuongKhachHang soLuongKhachHangForm = new frmSoLuongKhachHang();
            // Open as modal to wait for user confirmation
            soLuongKhachHangForm.ShowDialog(this);

            // After dialog closes, refresh displayed totals from shared state
            int total = PassengerSelectionState.Total;
            lblTotalPassengers.Text = $"{total} người";
            btnTotalCustomers.Text = $"{total} Hành khách";
        }

        private void btnRoundTrip_CheckedChanged(object sender, EventArgs e)
        {
            bool isRoundTrip = btnRoundTrip.Checked;
            lblReturnDate.Visible = isRoundTrip;
            dtpNgayVe.Visible = isRoundTrip;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void cbSanBayDen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbSanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOneWay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pnlChange_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaEditChange_Click(object sender, EventArgs e)
        {

        }
    }
}
