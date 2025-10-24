using System;
using System.Windows.Forms;

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

        private void frmCustomerLookup_Load(object sender, EventArgs e)
        {
            cbSearchType.Items.AddRange(new string[] { "CCCD", "Số điện thoại" });
            cbSearchType.SelectedIndex = 0;
            cbGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác", "Không khai báo" });
        }

        /// <summary>
        /// Tìm kiếm khách hàng trong CSDL
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
                // TODO: Tích hợp với database
                // var customer = _service.SearchCustomer(searchValue, cbSearchType.SelectedItem.ToString());

                // Tạm thời hiển thị thông báo
                DialogResult result = MessageBox.Show(
                    $"Không tìm thấy khách hàng với {cbSearchType.SelectedItem}: {searchValue}\n\nBạn có muốn tạo khách hàng mới?",
                    "Tìm kiếm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    EnableCustomerInput();
                }
                else
                {
                    ClearCustomerFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                // TODO: Lưu vào database
                // _service.CreateCustomer(...)

                MaKH = Guid.NewGuid().ToString().Substring(0, 10).ToUpper(); // Temp
                HoTen = txtHoTen.Text;
                CCCD = txtCCCD.Text;
                SDT = txtSDT.Text;
                Email = txtEmail.Text;
                DiaChi = txtDiaChi.Text;
                NgaySinh = dtpNgaySinh.Value;
                GioiTinh = cbGioiTinh.SelectedItem?.ToString() ?? "Không khai báo";

                MessageBox.Show($"Tạo khách hàng thành công!\nMã KH: {MaKH}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("CCCD không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtCCCD.Text.Length != 12)
            {
                MessageBox.Show("CCCD phải có 12 chữ số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtSDT.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại phải có ít nhất 10 chữ số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
