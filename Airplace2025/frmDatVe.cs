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
    public partial class frmDatVe : Form
    {
        // Passenger list
        private List<PassengerInfo> passengerList = new List<PassengerInfo>();

        public frmDatVe()
        {
            InitializeComponent();
        }

        private void frmDatVe_Load(object sender, EventArgs e)
        {
            InitializeControls();
            SetupFlightColumns();
            SetupPassengerColumns();
            AttachPassengerEventHandlers();
        }

        /// <summary>
        /// Initialize search controls with sample data
        /// </summary>
        private void InitializeControls()
        {
            try
            {
                // Airports - Load từ database hoặc list cứng
                cbSanBayDi.Items.AddRange(new string[] { "HAN - Hà Nội", "SGN - Tp.HCM", "DAD - Đà Nẵng", "CTS - Cần Thơ" });
                cbSanBayDen.Items.AddRange(new string[] { "HAN - Hà Nội", "SGN - Tp.HCM", "DAD - Đà Nẵng", "CTS - Cần Thơ" });
                cbSanBayDi.SelectedIndex = 0;
                cbSanBayDen.SelectedIndex = 1;

                // Service Class
                cbServiceClass.SelectedIndex = 0;

                // Hide return date initially
                dtpReturnDate.Visible = rbRoundTrip.Checked;
                lblReturnDate.Visible = rbRoundTrip.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo controls: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Setup columns for flight results DataGridView
        /// </summary>
        private void SetupFlightColumns()
        {
            try
            {
                dgvChuyenBay.Columns.Clear();
                dgvChuyenBay.Columns.Add("MaChuyenBay", "Mã chuyến bay");
                dgvChuyenBay.Columns.Add("HangHang", "Hãng");
                dgvChuyenBay.Columns.Add("GioDi", "Giờ đi");
                dgvChuyenBay.Columns.Add("GioDen", "Giờ đến");
                dgvChuyenBay.Columns.Add("ThoiGianBay", "Thời gian bay");
                dgvChuyenBay.Columns.Add("TinhTrang", "Tình trạng");
                dgvChuyenBay.Columns.Add("GheEconomy", "Ghế Economy");
                dgvChuyenBay.Columns.Add("GhePremium", "Ghế Premium");
                dgvChuyenBay.Columns.Add("GheBusiness", "Ghế Business");
                dgvChuyenBay.Columns.Add("GiaTu", "Giá từ");

                // Set column widths
                dgvChuyenBay.Columns["MaChuyenBay"].Width = 80;
                dgvChuyenBay.Columns["HangHang"].Width = 70;
                dgvChuyenBay.Columns["GioDi"].Width = 60;
                dgvChuyenBay.Columns["GioDen"].Width = 60;
                dgvChuyenBay.Columns["ThoiGianBay"].Width = 80;
                dgvChuyenBay.Columns["TinhTrang"].Width = 80;
                dgvChuyenBay.Columns["GheEconomy"].Width = 70;
                dgvChuyenBay.Columns["GhePremium"].Width = 70;
                dgvChuyenBay.Columns["GheBusiness"].Width = 70;
                dgvChuyenBay.Columns["GiaTu"].Width = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi setup cột: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Setup columns for passenger DataGridView
        /// </summary>
        private void SetupPassengerColumns()
        {
            try
            {
                dgvHanhKhach.Columns.Clear();
                dgvHanhKhach.Columns.Add("STT", "STT");
                dgvHanhKhach.Columns.Add("HoTen", "Họ Tên");
                dgvHanhKhach.Columns.Add("NgaySinh", "Ngày sinh");
                dgvHanhKhach.Columns.Add("LoaiHK", "Loại");
                dgvHanhKhach.Columns.Add("GioiTinh", "Giới tính");
                dgvHanhKhach.Columns.Add("DocNo", "Tài liệu");
                dgvHanhKhach.Columns.Add("Ghe", "Ghế");
                dgvHanhKhach.Columns.Add("HanhLy", "Hành lý (kg)");
                dgvHanhKhach.Columns.Add("Edit", "Sửa");
                dgvHanhKhach.Columns.Add("Delete", "Xóa");

                // Set column widths
                dgvHanhKhach.Columns["STT"].Width = 40;
                dgvHanhKhach.Columns["HoTen"].Width = 120;
                dgvHanhKhach.Columns["NgaySinh"].Width = 90;
                dgvHanhKhach.Columns["LoaiHK"].Width = 60;
                dgvHanhKhach.Columns["GioiTinh"].Width = 60;
                dgvHanhKhach.Columns["DocNo"].Width = 100;
                dgvHanhKhach.Columns["Ghe"].Width = 50;
                dgvHanhKhach.Columns["HanhLy"].Width = 80;
                dgvHanhKhach.Columns["Edit"].Width = 50;
                dgvHanhKhach.Columns["Delete"].Width = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi setup cột hành khách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Attach event handlers for passenger grid
        /// </summary>
        private void AttachPassengerEventHandlers()
        {
            btnThemHanhKhach.Click += BtnThemHanhKhach_Click;
        }

        /// <summary>
        /// Handle Add Passenger button
        /// </summary>
        private void BtnThemHanhKhach_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Find/Create Customer
                using (frmTimKiemKhachHang frmLookup = new frmTimKiemKhachHang())
                {
                    if (frmLookup.ShowDialog() != DialogResult.OK)
                        return;

                    // 2. Add Passenger Details
                    using (frmPassengerDetails frmDetails = new frmPassengerDetails())
                    {
                        if (frmDetails.ShowDialog() != DialogResult.OK)
                            return;

                        // Validate INF constraint
                        if (!ValidatePassengerConstraints(frmDetails.PassengerType))
                            return;

                        // 3. Select Seat
                        using (frmSeatSelection frmSeat = new frmSeatSelection(30, 6))
                        {
                            if (frmSeat.ShowDialog() != DialogResult.OK)
                                return;

                            // Create passenger info
                            PassengerInfo passenger = new PassengerInfo
                            {
                                MaKH = frmLookup.MaKH,
                                HoTen = $"{frmDetails.FirstName} {frmDetails.LastName}",
                                NgaySinh = frmDetails.DateOfBirth,
                                LoaiHK = frmDetails.PassengerType,
                                GioiTinh = frmDetails.Gender,
                                DocNo = frmDetails.DocumentNumber,
                                Ghe = frmSeat.SelectedSeat,
                                HanhLy = (int)frmDetails.AdditionalBaggage,
                                GhiChu = frmDetails.Notes
                            };

                            passengerList.Add(passenger);
                            RefreshPassengerGrid();
                            UpdatePassengerCount();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm hành khách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validate passenger constraints (INF must have ADT)
        /// </summary>
        private bool ValidatePassengerConstraints(string passengerType)
        {
            if (passengerType == "INF")
            {
                int adtCount = passengerList.Count(p => p.LoaiHK == "ADT");
                if (adtCount == 0)
                {
                    MessageBox.Show("Em bé (INF) phải đi kèm ít nhất 1 người lớn (ADT)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int infCount = passengerList.Count(p => p.LoaiHK == "INF");
                if (infCount >= adtCount)
                {
                    MessageBox.Show($"Số em bé không được vượt quá số người lớn.\nHiện có: {adtCount} ADT, {infCount} INF", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Refresh passenger grid
        /// </summary>
        private void RefreshPassengerGrid()
        {
            dgvHanhKhach.Rows.Clear();
            for (int i = 0; i < passengerList.Count; i++)
            {
                PassengerInfo p = passengerList[i];
                dgvHanhKhach.Rows.Add(
                    i + 1,
                    p.HoTen,
                    p.NgaySinh.ToString("dd/MM/yyyy"),
                    p.LoaiHK,
                    p.GioiTinh,
                    p.DocNo,
                    p.Ghe,
                    p.HanhLy,
                    "Sửa",
                    "Xóa"
                );
            }
        }

        /// <summary>
        /// Update passenger count labels
        /// </summary>
        private void UpdatePassengerCount()
        {
            int totalCount = passengerList.Count;
            lblSoLuongVe.Text = totalCount.ToString();
            
            // Calculate total price (simplified)
            int pricePerSeat = 1000000; // 1 triệu/vé
            lblTongTien.Text = (totalCount * pricePerSeat).ToString("N0") + " ₫";
        }

        /// <summary>
        /// Swap departure and destination airports
        /// </summary>
        private void btnSwapAirport_Click(object sender, EventArgs e)
        {
            try
            {
                int tempIndex = cbSanBayDi.SelectedIndex;
                cbSanBayDi.SelectedIndex = cbSanBayDen.SelectedIndex;
                cbSanBayDen.SelectedIndex = tempIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đổi sân bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle trip type change (one-way / round-trip)
        /// </summary>
        private void rbRoundTrip_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool isRoundTrip = rbRoundTrip.Checked;
                dtpReturnDate.Visible = isRoundTrip;
                lblReturnDate.Visible = isRoundTrip;

                if (isRoundTrip)
                {
                    dtpReturnDate.Value = dtpNgayDi.Value.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thay đổi loại vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle double-click on flight result to select it
        /// </summary>
        private void dgvChuyenBay_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvChuyenBay.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn chuyến bay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataGridViewRow row = dgvChuyenBay.SelectedRows[0];

                // Update flight info labels
                string maCB = row.Cells["MaChuyenBay"].Value?.ToString() ?? "-";
                string hang = row.Cells["HangHang"].Value?.ToString() ?? "-";
                string gia = row.Cells["GiaTu"].Value?.ToString() ?? "-";

                lblChuyenBayChon.Text = $"{maCB} ({hang})";
                lblHangVeChon.Text = cbServiceClass.SelectedItem?.ToString() ?? "Economy";
                lblGiaVeChon.Text = gia;

                // Update baggage policy based on selected service class
                UpdateBaggagePolicy(cbServiceClass.SelectedItem?.ToString() ?? "Economy");

                MessageBox.Show($"Đã chọn chuyến bay: {maCB}\nHãng: {hang}\nGiá từ: {gia}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn chuyến bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Update baggage and policy info based on service class
        /// </summary>
        private void UpdateBaggagePolicy(string serviceClass)
        {
            try
            {
                switch (serviceClass.ToLower())
                {
                    case "economy":
                        lblBaggageInfo.Text = "Hành lý: 20kg khoang + 5kg xách tay";
                        lblChangePolicy.Text = "Đổi vé: Miễn phí (lần đầu)";
                        break;
                    case "premium":
                        lblBaggageInfo.Text = "Hành lý: 25kg khoang + 7kg xách tay";
                        lblChangePolicy.Text = "Đổi vé: Miễn phí (2 lần)";
                        break;
                    case "business":
                        lblBaggageInfo.Text = "Hành lý: 30kg khoang + 10kg xách tay";
                        lblChangePolicy.Text = "Đổi vé: Miễn phí (không giới hạn)";
                        break;
                    default:
                        lblBaggageInfo.Text = "Hành lý: Tùy theo hãng";
                        lblChangePolicy.Text = "Đổi vé: Liên hệ hãng hàng không";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật chính sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Passenger info structure
    /// </summary>
    public class PassengerInfo
    {
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string LoaiHK { get; set; } // ADT, CHD, INF
        public string GioiTinh { get; set; }
        public string DocNo { get; set; }
        public string Ghe { get; set; }
        public int HanhLy { get; set; }
        public string GhiChu { get; set; }
    }
}
