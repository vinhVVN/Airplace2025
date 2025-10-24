using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airplace2025.BLL;
using Airplace2025.BLL.DTO;

namespace Airplace2025
{
    public partial class frmDatVe : Form
    {
        // Passenger list
        private List<PassengerInfo> passengerList = new List<PassengerInfo>();

        // Price breakdown and booking info
        private PriceBreakdown priceBreakdown = new PriceBreakdown();
        private BookingInfo bookingInfo = new BookingInfo();

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
            InitializePaymentTab();
        }

        /// <summary>
        /// Initialize search controls with data from database
        /// </summary>
        private void InitializeControls()
        {
            try
            {
                // Load airports from database
                LoadAirports();

                // Load service classes from database
                LoadServiceClasses();

                // Hide return date initially
                dtpReturnDate.Visible = rbRoundTrip.Checked;
                lblReturnDate.Visible = rbRoundTrip.Checked;

                // Set minimum date for date pickers
                dtpNgayDi.MinDate = DateTime.Now.Date;
                dtpReturnDate.MinDate = DateTime.Now.Date.AddDays(1);
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

                cbSanBayDi.Items.Clear();
                cbSanBayDen.Items.Clear();

                foreach (string airport in airports)
                {
                    cbSanBayDi.Items.Add(airport);
                    cbSanBayDen.Items.Add(airport);
                }

                if (cbSanBayDi.Items.Count > 0)
                    cbSanBayDi.SelectedIndex = 0;

                if (cbSanBayDen.Items.Count > 1)
                    cbSanBayDen.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sân bay: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Fallback to hardcoded data
                cbSanBayDi.Items.AddRange(new string[] { "HAN - Nội Bài (Hà Nội)", "SGN - Tân Sơn Nhất (TP.HCM)", "DAD - Đà Nẵng", "CXR - Cam Ranh (Khánh Hòa)" });
                cbSanBayDen.Items.AddRange(new string[] { "HAN - Nội Bài (Hà Nội)", "SGN - Tân Sơn Nhất (TP.HCM)", "DAD - Đà Nẵng", "CXR - Cam Ranh (Khánh Hòa)" });
                cbSanBayDi.SelectedIndex = 0;
                cbSanBayDen.SelectedIndex = 1;
            }
        }

        /// <summary>
        /// Load service classes (hạng vé) from database
        /// </summary>
        private void LoadServiceClasses()
        {
            try
            {
                List<HangVeDTO> serviceClasses = ChuyenBayBLL.Instance.GetFormattedServiceClassList();

                cbServiceClass.DataSource = null;
                cbServiceClass.Items.Clear();

                // Set DataSource để binding
                cbServiceClass.DataSource = serviceClasses;
                cbServiceClass.DisplayMember = "TenHangVe";
                cbServiceClass.ValueMember = "MaHangVe";

                if (cbServiceClass.Items.Count > 0)
                    cbServiceClass.SelectedIndex = 0; // Default to first class (usually Phổ thông)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách hạng vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Fallback to hardcoded data
                cbServiceClass.DataSource = null;
                cbServiceClass.Items.Clear();
                cbServiceClass.Items.AddRange(new string[] { "Phổ thông", "Phổ thông đặc biệt", "Thương gia", "Hạng nhất" });
                cbServiceClass.SelectedIndex = 0;
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
            btnTimKiem.Click += btnTimKiem_Click;
        }

        /// <summary>
        /// Lấy tên hạng vé đã chọn
        /// </summary>
        private string GetSelectedServiceClassName()
        {
            if (cbServiceClass.SelectedItem is HangVeDTO)
            {
                return ((HangVeDTO)cbServiceClass.SelectedItem).TenHangVe;
            }
            else if (cbServiceClass.SelectedItem != null)
            {
                return cbServiceClass.SelectedItem.ToString();
            }
            else
            {
                return "Phổ thông"; // Default
            }
        }

        /// <summary>
        /// Lấy mã hạng vé đã chọn
        /// </summary>
        private string GetSelectedServiceClassCode()
        {
            if (cbServiceClass.SelectedItem is HangVeDTO)
            {
                return ((HangVeDTO)cbServiceClass.SelectedItem).MaHangVe;
            }
            else
            {
                // Fallback: tìm mã từ tên
                string tenHangVe = GetSelectedServiceClassName();
                return ChuyenBayBLL.Instance.GetMaHangVe(tenHangVe);
            }
        }

        /// <summary>
        /// Handle Search Flight button click
        /// </summary>
        

        /// <summary>
        /// Display flight search results in DataGridView
        /// </summary>
        private void DisplayFlightResults(List<ChuyenBayDTO> flights, string hangDichVu)
        {
            dgvChuyenBay.Rows.Clear();

            foreach (var flight in flights)
            {
                // Format time duration
                string thoiGianBay = ChuyenBayBLL.Instance.FormatFlightDuration(flight.ThoiGianBay);

                // Get seat availability by class from ChiTietHangVe
                string gheEconomy = flight.GheEconomy.HasValue ? flight.GheEconomy.Value.ToString() : "-";
                string ghePremium = flight.GhePremium.HasValue ? flight.GhePremium.Value.ToString() : "-";
                string gheBusiness = flight.GheBusiness.HasValue ? flight.GheBusiness.Value.ToString() : "-";

                // Get price based on selected class
                // Nếu không có giá theo hạng, dùng giá cơ bản và nhân với tỉ lệ
                decimal giaHienThi = flight.GiaCoBan;
                decimal tiLeGia = 1.0m;
                
                string lowerHangDichVu = hangDichVu.ToLower();
                
                // Hỗ trợ cả tiếng Việt và tiếng Anh
                if (lowerHangDichVu.Contains("phổ thông") && !lowerHangDichVu.Contains("đặc biệt") || lowerHangDichVu == "economy")
                {
                    giaHienThi = flight.GiaEconomy ?? flight.GiaCoBan;
                    tiLeGia = ChuyenBayBLL.Instance.GetTiLeGiaHangVe(hangDichVu);
                }
                else if (lowerHangDichVu.Contains("đặc biệt") || lowerHangDichVu == "premium")
                {
                    giaHienThi = flight.GiaPremium ?? flight.GiaCoBan;
                    tiLeGia = ChuyenBayBLL.Instance.GetTiLeGiaHangVe(hangDichVu);
                }
                else if (lowerHangDichVu.Contains("thương gia") || lowerHangDichVu == "business")
                {
                    giaHienThi = flight.GiaBusiness ?? flight.GiaCoBan;
                    tiLeGia = ChuyenBayBLL.Instance.GetTiLeGiaHangVe(hangDichVu);
                }
                else if (lowerHangDichVu.Contains("hạng nhất") || lowerHangDichVu == "first")
                {
                    giaHienThi = flight.GiaFirst ?? flight.GiaCoBan;
                    tiLeGia = ChuyenBayBLL.Instance.GetTiLeGiaHangVe(hangDichVu);
                }
                
                // Nếu không có giá riêng cho hạng, tính dựa trên giá cơ bản * tỉ lệ
                if (giaHienThi == flight.GiaCoBan && tiLeGia > 0)
                {
                    giaHienThi = flight.GiaCoBan * tiLeGia;
                }

                dgvChuyenBay.Rows.Add(
                    flight.MaChuyenBay,
                    flight.TenHangBay,
                    flight.NgayGioBay.ToString("HH:mm"),
                    flight.NgayGioDen.ToString("HH:mm"),
                    thoiGianBay,
                    flight.TrangThai,
                    gheEconomy,
                    ghePremium,
                    gheBusiness,
                    giaHienThi.ToString("N0") + " ₫"
                );
            }
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

            // Update price breakdown when passenger count changes
            UpdatePriceBreakdown();
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
                lblHangVeChon.Text = GetSelectedServiceClassName();
                lblGiaVeChon.Text = gia;

                // Update baggage policy based on selected service class
                UpdateBaggagePolicy(GetSelectedServiceClassName());

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
                string lowerClass = serviceClass.ToLower();
                
                // Hỗ trợ cả tiếng Việt và tiếng Anh
                if (lowerClass.Contains("phổ thông") && !lowerClass.Contains("đặc biệt") || lowerClass == "economy")
                {
                    lblBaggageInfo.Text = "Hành lý: 20kg khoang + 5kg xách tay";
                    lblChangePolicy.Text = "Đổi vé: Miễn phí (lần đầu)";
                }
                else if (lowerClass.Contains("đặc biệt") || lowerClass == "premium")
                {
                    lblBaggageInfo.Text = "Hành lý: 25kg khoang + 7kg xách tay";
                    lblChangePolicy.Text = "Đổi vé: Miễn phí (2 lần)";
                }
                else if (lowerClass.Contains("thương gia") || lowerClass == "business")
                {
                    lblBaggageInfo.Text = "Hành lý: 30kg khoang + 10kg xách tay";
                    lblChangePolicy.Text = "Đổi vé: Miễn phí (không giới hạn)";
                }
                else if (lowerClass.Contains("hạng nhất") || lowerClass == "first")
                {
                    lblBaggageInfo.Text = "Hành lý: 40kg khoang + 12kg xách tay";
                    lblChangePolicy.Text = "Đổi vé: Miễn phí (không giới hạn)";
                }
                else
                {
                    lblBaggageInfo.Text = "Hành lý: Tùy theo hãng";
                    lblChangePolicy.Text = "Đổi vé: Liên hệ hãng hàng không";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật chính sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initialize payment tab with PNR, payment methods, and employee info
        /// </summary>
        private void InitializePaymentTab()
        {
            try
            {
                // Generate PNR
                bookingInfo.PNR = GeneratePNR();
                bookingInfo.Status = "Hold";
                bookingInfo.CreatedTime = DateTime.Now;
                bookingInfo.HoldDeadline = DateTime.Now.AddHours(24); // TODO: Từ DB THAMSO.TGDatVeChamNhat
                bookingInfo.EmployeeCode = "NV001";
                bookingInfo.EmployeeName = "Nguyễn Văn A";

                // Populate payment methods
                cbPhuongThucTT.Items.Clear();
                cbPhuongThucTT.Items.AddRange(new string[] {
                    "Tiền mặt",
                    "Thẻ tín dụng/ghi nợ",
                    "Chuyển khoản ngân hàng",
                    "QR Code (VNPay/MoMo/ZaloPay)"
                });
                cbPhuongThucTT.SelectedIndex = 0;

                // Display employee info
                lblNhanVien.Text = $"{bookingInfo.EmployeeCode} - {bookingInfo.EmployeeName}";

                // Attach event handlers
                cbPhuongThucTT.SelectedIndexChanged += CbPhuongThucTT_SelectedIndexChanged;
                btnGiuCho.Click += BtnGiuCho_Click;
                btnThanhToan.Click += BtnThanhToan_Click;
                txtPhuThu.TextChanged += (s, e) => UpdatePriceBreakdown();

                UpdatePriceBreakdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo tab thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Generate PNR (Passenger Name Record) - 6 characters
        /// </summary>
        private string GeneratePNR()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Update price breakdown with detailed calculation
        /// </summary>
        private void UpdatePriceBreakdown()
        {
            try
            {
                int passengerCount = passengerList.Count;

                // Base fare per passenger (từ chuyến bay đã chọn)
                decimal baseFarePerPax = 1000000m; // TODO: Lấy từ giá vé đã chọn
                priceBreakdown.BaseFare = baseFarePerPax * passengerCount;

                // Thuế & phí (20% base fare)
                priceBreakdown.TaxAndFees = priceBreakdown.BaseFare * 0.20m;

                // Phụ thu (từ textbox)
                if (decimal.TryParse(txtPhuThu.Text, out decimal surcharge))
                {
                    priceBreakdown.Surcharges = surcharge;
                }
                else
                {
                    priceBreakdown.Surcharges = 0;
                }

                // Dịch vụ thêm (ghế + hành lý)
                decimal seatFees = 0m; // TODO: Tính từ loại ghế premium
                decimal baggageFees = passengerList.Sum(p => p.HanhLy * 50000m); // 50k/kg
                priceBreakdown.OptionalServices = seatFees + baggageFees;

                // Giảm giá (voucher) - TODO: Implement voucher system
                priceBreakdown.Discount = 0m;

                // VAT (10% của subtotal)
                priceBreakdown.VAT = priceBreakdown.SubTotal * 0.10m;

                // Cập nhật hiển thị
                lblSoLuongVe.Text = passengerCount.ToString();
                lblTongTien.Text = priceBreakdown.Total.ToString("N0") + " ₫";
                lblGiaVeChon.Text = baseFarePerPax.ToString("N0") + " ₫";

                // TODO: Hiển thị breakdown chi tiết trong một label hoặc RichTextBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle payment method selection change
        /// </summary>
        private void CbPhuongThucTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedMethod = cbPhuongThucTT.SelectedItem?.ToString();

                if (selectedMethod == "Thẻ tín dụng/ghi nợ")
                {
                    MessageBox.Show(
                        "Vui lòng chuẩn bị thẻ để thanh toán\n\n" +
                        "Lưu ý: Chúng tôi chỉ lưu 4 số cuối thẻ và tên ngân hàng.\n" +
                        "Không lưu thông tin nhạy cảm.",
                        "Thanh toán thẻ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else if (selectedMethod == "QR Code (VNPay/MoMo/ZaloPay)")
                {
                    MessageBox.Show(
                        $"Quét mã QR để thanh toán\n\n" +
                        $"Số tiền: {priceBreakdown.Total:N0} ₫\n" +
                        $"Nội dung: Thanh toan ve may bay {bookingInfo.PNR}",
                        "Thanh toán QR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle "Giữ chỗ" button - Issue PNR and set hold deadline
        /// </summary>
        private void BtnGiuCho_Click(object sender, EventArgs e)
        {
            try
            {
                if (passengerList.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm hành khách trước khi giữ chỗ",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(lblChuyenBayChon.Text) || lblChuyenBayChon.Text == "-")
                {
                    MessageBox.Show("Vui lòng chọn chuyến bay trước khi giữ chỗ",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // TODO: Lưu vào database với status = "Hold"
                bookingInfo.Status = "Hold";

                string message = $@"
ĐÃ GIỮ CHỖ THÀNH CÔNG!

━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Mã đặt chỗ (PNR): {bookingInfo.PNR}
Trạng thái: {bookingInfo.Status}
Thời hạn giữ chỗ: {bookingInfo.HoldDeadline:dd/MM/yyyy HH:mm}
━━━━━━━━━━━━━━━━━━━━━━━━━━━━

THÔNG TIN CHUYẾN BAY:
{lblChuyenBayChon.Text}
Hạng vé: {lblHangVeChon.Text}
Số hành khách: {passengerList.Count}

CHI TIẾT GIÁ:
Base Fare: {priceBreakdown.BaseFare:N0} ₫
Thuế & Phí: {priceBreakdown.TaxAndFees:N0} ₫
Phụ thu: {priceBreakdown.Surcharges:N0} ₫
Dịch vụ thêm: {priceBreakdown.OptionalServices:N0} ₫
VAT (10%): {priceBreakdown.VAT:N0} ₫
─────────────────────────
TỔNG CỘNG: {priceBreakdown.Total:N0} ₫

Nhân viên: {bookingInfo.EmployeeCode} - {bookingInfo.EmployeeName}
Thời gian: {bookingInfo.CreatedTime:dd/MM/yyyy HH:mm:ss}

⚠ Vui lòng thanh toán trước thời hạn để xuất vé!";

                MessageBox.Show(message,
                    "Giữ chỗ thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi giữ chỗ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle "Thanh toán và Xuất vé" button - Process payment and emit e-ticket
        /// </summary>
        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (passengerList.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm hành khách trước khi thanh toán",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(lblChuyenBayChon.Text) || lblChuyenBayChon.Text == "-")
                {
                    MessageBox.Show("Vui lòng chọn chuyến bay trước khi thanh toán",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Confirm payment
                string confirmMessage = $@"
XÁC NHẬN THANH TOÁN

Tổng tiền: {priceBreakdown.Total:N0} ₫
Phương thức: {cbPhuongThucTT.SelectedItem}

Bạn có chắc chắn muốn thanh toán?";

                DialogResult result = MessageBox.Show(confirmMessage,
                    "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // TODO: Process payment through payment gateway
                    // TODO: Update database status = "Ticketed"
                    // TODO: Send confirmation email

                    bookingInfo.Status = "Ticketed";

                    // Generate e-ticket numbers (format: 739-YYYYMMDDXXX)
                    string eTickets = string.Join(", ",
                        passengerList.Select((p, i) => $"739-{DateTime.Now:yyyyMMdd}{i + 1:000}"));

                    string successMessage = $@"
THANH TOÁN THÀNH CÔNG!

━━━━━━━━━━━━━━━━━━━━━━━━━━━━
Mã đặt chỗ (PNR): {bookingInfo.PNR}
Trạng thái: ĐÃ XUẤT VÉ
Số vé điện tử: {eTickets}
━━━━━━━━━━━━━━━━━━━━━━━━━━━━

BREAKDOWN GIÁ VÉ:
Base Fare ({passengerList.Count} vé): {priceBreakdown.BaseFare:N0} ₫
Thuế & Phí (20%): {priceBreakdown.TaxAndFees:N0} ₫
Phụ thu: {priceBreakdown.Surcharges:N0} ₫
Dịch vụ thêm: {priceBreakdown.OptionalServices:N0} ₫
Giảm giá: -{priceBreakdown.Discount:N0} ₫
VAT (10%): {priceBreakdown.VAT:N0} ₫
─────────────────────────
TỔNG CỘNG: {priceBreakdown.Total:N0} ₫

THANH TOÁN:
Phương thức: {cbPhuongThucTT.SelectedItem}
Nhân viên: {bookingInfo.EmployeeCode} - {bookingInfo.EmployeeName}
Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}

✓ Vé đã được gửi qua email!
✓ Bạn có thể in vé hoặc lưu PDF.";

                    MessageBox.Show(successMessage,
                        "Xuất vé thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // TODO: Show print/email dialog
                    DialogResult printResult = MessageBox.Show(
                        "Bạn có muốn in vé ngay bây giờ?",
                        "In vé",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (printResult == DialogResult.Yes)
                    {
                        // TODO: Implement print ticket functionality
                        MessageBox.Show("Chức năng in vé đang được phát triển", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (cbSanBayDi.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn sân bay đi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbSanBayDen.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn sân bay đến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Prepare search parameters
                SearchFlightParams searchParams = new SearchFlightParams
                {
                    MaSanBayDi = ChuyenBayBLL.Instance.ExtractAirportCode(cbSanBayDi.SelectedItem?.ToString()),
                    MaSanBayDen = ChuyenBayBLL.Instance.ExtractAirportCode(cbSanBayDen.SelectedItem?.ToString()),
                    NgayDi = dtpNgayDi.Value.Date,
                    SoNguoiLon = (int)numAdult.Value,
                    SoTreEm = (int)numChild.Value,
                    SoEmBe = (int)numBaby.Value,
                    HangDichVu = GetSelectedServiceClassName(),
                    LaKhuHoi = rbRoundTrip.Checked
                };

                if (searchParams.LaKhuHoi)
                {
                    searchParams.NgayVe = dtpReturnDate.Value.Date;
                }

                // Show loading
                this.Cursor = Cursors.WaitCursor;
                dgvChuyenBay.Rows.Clear();

                // Search flights
                List<ChuyenBayDTO> flights = ChuyenBayBLL.Instance.SearchFlights(searchParams);

                if (flights.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy chuyến bay phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Display results
                DisplayFlightResults(flights, searchParams.HangDichVu);

                MessageBox.Show($"Tìm thấy {flights.Count} chuyến bay phù hợp", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
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

    /// <summary>
    /// Price breakdown structure
    /// </summary>
    public class PriceBreakdown
    {
        public decimal BaseFare { get; set; }
        public decimal TaxAndFees { get; set; }
        public decimal Surcharges { get; set; }
        public decimal OptionalServices { get; set; }  // Ghế, hành lý
        public decimal Discount { get; set; }
        public decimal VAT { get; set; }

        public decimal SubTotal => BaseFare + TaxAndFees + Surcharges + OptionalServices;
        public decimal Total => SubTotal - Discount + VAT;

        /// <summary>
        /// Get formatted breakdown for display
        /// </summary>
        public string GetFormattedBreakdown()
        {
            return $@"
Base Fare: {BaseFare:N0} ₫
Thuế & Phí: {TaxAndFees:N0} ₫
Phụ thu: {Surcharges:N0} ₫
Dịch vụ thêm: {OptionalServices:N0} ₫
Giảm giá: -{Discount:N0} ₫
VAT (10%): {VAT:N0} ₫
─────────────────────────
TỔNG CỘNG: {Total:N0} ₫";
        }
    }

    /// <summary>
    /// Booking information structure
    /// </summary>
    public class BookingInfo
    {
        public string PNR { get; set; }  // Mã đặt chỗ (6 ký tự)
        public string Status { get; set; }  // Hold, Ticketed, Void
        public DateTime CreatedTime { get; set; }
        public DateTime HoldDeadline { get; set; }  // Từ THAMSO.TGDatVeChamNhat
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
    }
}

