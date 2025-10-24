using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Airplace2025
{
    /// <summary>
    /// Form để thêm/sửa thông tin hành khách chi tiết
    /// Hỗ trợ các trường: Họ, Tên đệm, Tên, Giới tính, Ngày sinh, Quốc tịch, Loại tài liệu, Số tài liệu...
    /// </summary>
    public partial class frmPassengerDetails : Form
    {
        // Passenger data
        public string Title { get; set; } // Mr, Ms, Mrs, etc.
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string DocumentType { get; set; } // CCCD, Passport, etc.
        public string DocumentNumber { get; set; }
        public DateTime? PassportExpiry { get; set; }
        public string PassengerType { get; set; } // ADT, CHD, INF
        public string LoyaltyProgram { get; set; }
        public string SeatNumber { get; set; }
        public decimal AdditionalBaggage { get; set; }
        public string Notes { get; set; }

        public frmPassengerDetails()
        {
            InitializeComponent();
        }

        private void frmPassengerDetails_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void InitializeControls()
        {
            try
            {
                // Title
                cbTitle.Items.AddRange(new string[] { "Mr.", "Ms.", "Mrs.", "Dr.", "Prof." });
                cbTitle.SelectedIndex = 0;

                // Gender
                cbGender.Items.AddRange(new string[] { "Nam", "Nữ", "Khác", "Không khai báo" });
                cbGender.SelectedIndex = 0;

                // Document Type
                cbDocType.Items.AddRange(new string[] { "CCCD", "Passport", "Hộ chiếu", "Bằng lái" });
                cbDocType.SelectedIndex = 0;

                // Passenger Type
                cbPassengerType.Items.AddRange(new string[] { "ADT (Người lớn)", "CHD (Trẻ em)", "INF (Em bé)" });
                cbPassengerType.SelectedIndex = 0;

                // Set default values
                dtpDateOfBirth.Value = DateTime.Now.AddYears(-30);
                dtpPassportExpiry.Value = DateTime.Now.AddYears(5);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xác nhận lưu hành khách
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                ExtractData();

                // Validate passenger type vs age
                if (!ValidatePassengerType())
                {
                    return;
                }

                MessageBox.Show("Lưu thông tin hành khách thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validate dữ liệu nhập
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Họ không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Tên không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDocNumber.Text))
            {
                MessageBox.Show("Số tài liệu không được trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if DOB is valid
            if (dtpDateOfBirth.Value >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate loại hành khách vs tuổi
        /// ADT: >= 18
        /// CHD: 2-18
        /// INF: < 2
        /// </summary>
        private bool ValidatePassengerType()
        {
            DateTime today = DateTime.Now;
            int age = today.Year - dtpDateOfBirth.Value.Year;
            if (dtpDateOfBirth.Value.Date > today.AddYears(-age)) age--;

            string passengerType = cbPassengerType.SelectedItem?.ToString().Substring(0, 3) ?? "ADT";

            bool isValid = false;
            switch (passengerType)
            {
                case "ADT":
                    isValid = age >= 18;
                    break;
                case "CHD":
                    isValid = age >= 2 && age < 18;
                    break;
                case "INF":
                    isValid = age < 2;
                    break;
            }

            if (!isValid)
            {
                MessageBox.Show(
                    $"Tuổi ({age}) không phù hợp với loại hành khách {passengerType}.\n" +
                    "ADT: >= 18, CHD: 2-18, INF: < 2",
                    "Cảnh báo",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                return true; // Allow anyway
            }

            return true;
        }

        /// <summary>
        /// Lấy dữ liệu từ form
        /// </summary>
        private void ExtractData()
        {
            Title = cbTitle.SelectedItem?.ToString() ?? "";
            LastName = txtLastName.Text.Trim();
            FirstName = txtFirstName.Text.Trim();
            MiddleName = txtMiddleName.Text.Trim();
            DateOfBirth = dtpDateOfBirth.Value;
            Gender = cbGender.SelectedItem?.ToString() ?? "";
            Nationality = txtNationality.Text.Trim();
            DocumentType = cbDocType.SelectedItem?.ToString() ?? "";
            DocumentNumber = txtDocNumber.Text.Trim();
            DateTime? PassportExpiry = chkPassportExpiry.Checked ? dtpPassportExpiry.Value : (DateTime?)null;

            PassengerType = cbPassengerType.SelectedItem?.ToString().Substring(0, 3) ?? "ADT";
            LoyaltyProgram = txtLoyalty.Text.Trim();
            SeatNumber = txtSeat.Text.Trim();
            AdditionalBaggage = numAdditionalBaggage.Value;
            Notes = txtNotes.Text.Trim();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Populate form từ passenger data (edit mode)
        /// </summary>
        public void LoadPassengerData(dynamic passenger)
        {
            try
            {
                cbTitle.SelectedItem = passenger.Title ?? "Mr.";
                txtLastName.Text = passenger.LastName ?? "";
                txtFirstName.Text = passenger.FirstName ?? "";
                txtMiddleName.Text = passenger.MiddleName ?? "";
                dtpDateOfBirth.Value = passenger.DateOfBirth;
                cbGender.SelectedItem = passenger.Gender ?? "Nam";
                txtNationality.Text = passenger.Nationality ?? "VN";
                cbDocType.SelectedItem = passenger.DocumentType ?? "CCCD";
                txtDocNumber.Text = passenger.DocumentNumber ?? "";
                chkPassportExpiry.Checked = passenger.PassportExpiry.HasValue;
                if (passenger.PassportExpiry.HasValue)
                {
                    dtpPassportExpiry.Value = passenger.PassportExpiry.Value;
                }
                cbPassengerType.Text = $"{passenger.PassengerType} (Người lớn)";
                txtLoyalty.Text = passenger.LoyaltyProgram ?? "";
                txtSeat.Text = passenger.SeatNumber ?? "";
                numAdditionalBaggage.Value = passenger.AdditionalBaggage;
                txtNotes.Text = passenger.Notes ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPassportExpiry_CheckedChanged(object sender, EventArgs e)
        {
            dtpPassportExpiry.Enabled = chkPassportExpiry.Checked;
        }
    }
}
