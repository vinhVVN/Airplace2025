using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Airplace2025.BLL;
using Airplace2025.BLL.DTO;

namespace Airplace2025
{
    /// <summary>
    /// Form để tìm khách hàng hoặc tạo khách hàng mới
    /// </summary>
    public partial class frmTimKiemKhachHang : Form
    {
        // Data để trả về
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string CCCD { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }

        public frmTimKiemKhachHang()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tìm kiếm khách hàng trong CSDL (Smart Search - tự động detect loại)
        /// </summary>
        private void btnTim_Click(object sender, EventArgs e)
        {
            string searchValue = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Smart search - auto-detect search type
                List<KhachHangDTO> customers = KhachHangBLL.Instance.SmartSearchCustomer(searchValue);

                // Detect what type was searched for pre-filling
                string detectedType = DetectSearchType(searchValue);

                if (customers.Count == 0)
                {
                    // No customer found
                    DialogResult result = MessageBox.Show(
                        $"Không tìm thấy khách hàng với thông tin: {searchValue}\n\nBạn có muốn tạo khách hàng mới?",
                        "Tìm kiếm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        EnableCustomerInput();
                        // Pre-fill search value based on detected type
                        PreFillCustomerData(searchValue, detectedType);
                    }
                    else
                    {
                        ClearCustomerFields();
                    }
                }
                else if (customers.Count == 1)
                {
                    // Found exactly one customer
                    LoadCustomerData(customers[0]);
                    MessageBox.Show("Đã tìm thấy khách hàng!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Multiple customers found - let user choose
                    frmChonKhachHang frmChon = new frmChonKhachHang(customers);
                    if (frmChon.ShowDialog() == DialogResult.OK && frmChon.SelectedCustomer != null)
                    {
                        LoadCustomerData(frmChon.SelectedCustomer);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Detect search type from input value
        /// </summary>
        private string DetectSearchType(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "Unknown";

            value = value.Trim();
            
            // Check if numeric
            bool isNumeric = value.All(char.IsDigit);
            
            if (isNumeric && value.Length == 12)
                return "CCCD";
            else if (isNumeric && value.Length >= 10 && value.Length <= 11)
                return "Phone";
            else if (value.Contains("@"))
                return "Email";
            else
                return "Name";
        }

        /// <summary>
        /// Pre-fill customer data based on detected search type
        /// </summary>
        private void PreFillCustomerData(string value, string detectedType)
        {
            switch (detectedType)
            {
                case "CCCD":
                    txtCCCD.Text = value;
                    break;
                case "Phone":
                    txtSDT.Text = value;
                    break;
                case "Email":
                    txtEmail.Text = value;
                    break;
                case "Name":
                    txtHoTen.Text = value;
                    break;
            }
        }

        /// <summary>
        /// Load customer data into form
        /// </summary>
        private void LoadCustomerData(KhachHangDTO customer)
        {
            MaKH = customer.MaKhachHang;
            HoTen = customer.HoTen;
            CCCD = customer.CCCD;
            SDT = customer.SoDienThoai;
            Email = customer.Email;
            DiaChi = customer.DiaChi;
            NgaySinh = customer.NgaySinh ?? DateTime.Now.AddYears(-30);
            GioiTinh = customer.GioiTinh ?? "Nam";

            txtHoTen.Text = customer.HoTen;
            txtCCCD.Text = customer.CCCD;
            txtSDT.Text = customer.SoDienThoai;
            txtEmail.Text = customer.Email;
            txtDiaChi.Text = customer.DiaChi;
            dtpNgaySinh.Value = customer.NgaySinh ?? DateTime.Now.AddYears(-30);
            cbGioiTinh.SelectedItem = customer.GioiTinh ?? "Nam";

            // Make fields readonly
            txtHoTen.ReadOnly = true;
            txtCCCD.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            cbGioiTinh.Enabled = false;
            btnTaoMoi.Enabled = false;
            btnChon.Enabled = true; // Enable btnChon when customer data is loaded
        }

        /// <summary>
        /// Bật nhập liệu cho khách hàng mới
        /// </summary>
        private void EnableCustomerInput()
        {
            txtHoTen.ReadOnly = false;
            txtCCCD.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            dtpNgaySinh.Enabled = true;
            cbGioiTinh.Enabled = true;
            btnTaoMoi.Enabled = true;
            btnChon.Enabled = false; // Disable btnChon when creating new customer
        }

        /// <summary>
        /// Xóa thông tin khách hàng
        /// </summary>
        private void ClearCustomerFields()
        {
            txtHoTen.Text = "";
            txtCCCD.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            cbGioiTinh.SelectedIndex = 0;
            txtHoTen.ReadOnly = true;
            txtCCCD.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            dtpNgaySinh.Enabled = false;
            cbGioiTinh.Enabled = false;
            btnTaoMoi.Enabled = false;
            btnChon.Enabled = true; // Enable btnChon when clearing fields
        }

        /// <summary>
        /// Tạo khách hàng mới
        /// </summary>
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            if (!ValidateCustomerInput())
            {
                return;
            }

            try
            {
                // Create customer DTO
                KhachHangDTO newCustomer = new KhachHangDTO
                {
                    HoTen = txtHoTen.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cbGioiTinh.SelectedItem?.ToString(),
                    DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim(),
                    CCCD = string.IsNullOrWhiteSpace(txtCCCD.Text) ? null : txtCCCD.Text.Trim(),
                    SoDienThoai = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    LoaiKhachHang = "Red" // Default customer type
                };

                // Create customer in database
                string maKhachHang = KhachHangBLL.Instance.CreateCustomer(newCustomer);

                // Set return values
                MaKH = maKhachHang;
                HoTen = newCustomer.HoTen;
                CCCD = newCustomer.CCCD;
                SDT = newCustomer.SoDienThoai;
                Email = newCustomer.Email;
                DiaChi = newCustomer.DiaChi;
                NgaySinh = newCustomer.NgaySinh ?? DateTime.Now;
                GioiTinh = newCustomer.GioiTinh;

                MessageBox.Show($"Đã tạo khách hàng mới thành công!\nMã KH: {MaKH}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tạo khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xác nhận chọn khách hàng
        /// </summary>
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc tạo khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HoTen = txtHoTen.Text;
            CCCD = txtCCCD.Text;
            SDT = txtSDT.Text;
            Email = txtEmail.Text;
            DiaChi = txtDiaChi.Text;
            NgaySinh = dtpNgaySinh.Value;
            GioiTinh = cbGioiTinh.SelectedItem?.ToString() ?? "Không khai báo";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Validate thông tin khách hàng
        /// </summary>
        private bool ValidateCustomerInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate CCCD if provided (can be null for children)
            if (!string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                if (txtCCCD.Text.Length != 12)
                {
                    MessageBox.Show("CCCD phải có 12 chữ số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                
                if (!txtCCCD.Text.All(char.IsDigit))
                {
                    MessageBox.Show("CCCD chỉ được chứa số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Validate phone number if provided (can be null for children)
            if (!string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                if (txtSDT.Text.Length < 10 || txtSDT.Text.Length > 15)
                {
                    MessageBox.Show("Số điện thoại phải có từ 10-15 chữ số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!txtSDT.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Validate email if provided (can be null)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Email không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
