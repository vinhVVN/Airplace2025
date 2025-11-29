using Airplace2025.BLL;
using Airplace2025.BLL.DTO;
using Airplace2025.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Airplace2025
{
    public partial class frmCustomerInfo : Form
    {
        // Return a list of customers corresponding to the passengers
        public List<KhachHangDTO> SelectedCustomers { get; private set; }
        // Return the representative customer (used for booking contact)
        public KhachHangDTO RepresentativeCustomer { get; private set; }

        // Enums to track passenger types internally
        private enum PassengerType
        {
            Adult,
            Child,
            Infant
        }

        private class PassengerEntry
        {
            public int Index { get; set; }
            public string DisplayName { get; set; }
            public PassengerType Type { get; set; }
            public KhachHangDTO CustomerData { get; set; }
            public bool IsCompleted { get; set; }
            public bool IsRepresentative { get; set; }

            public override string ToString()
            {
                string status = IsCompleted ? "✓" : "⚠";
                string rep = IsRepresentative ? "★ " : "";
                string info = CustomerData != null ? $" - {CustomerData.HoTen}" : "";
                return $"{status} {rep}{DisplayName}{info}";
            }
        }

        private List<PassengerEntry> _passengerEntries;
        private PassengerEntry _currentEntry;
        private bool _isChangingSelection = false;

        public frmCustomerInfo()
        {
            InitializeComponent();
            InitializeCustomComponents();
            SetupEventHandlers();
            InitializePassengerList();
        }

        private void InitializeCustomComponents()
        {
            // UI Initial State
            dgvCustomers.Visible = false;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;

            // Custom Draw for ListBox to make it look better
            lstPassengers.DrawMode = DrawMode.OwnerDrawFixed;
            lstPassengers.DrawItem += LstPassengers_DrawItem;
        }

        private void SetupEventHandlers()
        {
            // Search
            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnSearch_Click(s, e); };

            // Grid Selection
            dgvCustomers.CellClick += DgvCustomers_CellClick;

            // Actions
            btnConfirmAll.Click += BtnConfirmAll_Click;
            btnCancel.Click += BtnCancel_Click;

            // List Navigation
            lstPassengers.SelectedIndexChanged += LstPassengers_SelectedIndexChanged;

            // Auto-save current input when focus leaves text boxes
            txtHo.Leave += (s, e) => SaveCurrentEntryToMemory();
            txtTen.Leave += (s, e) => SaveCurrentEntryToMemory();
            txtSDT.Leave += (s, e) => SaveCurrentEntryToMemory();
            txtCCCD.Leave += (s, e) => SaveCurrentEntryToMemory();
            txtEmail.Leave += (s, e) => SaveCurrentEntryToMemory();
            txtDiaChi.Leave += (s, e) => SaveCurrentEntryToMemory();
            cmbDanhXung.SelectedIndexChanged += (s, e) => SaveCurrentEntryToMemory();
            dtpNgaySinh.ValueChanged += (s, e) => SaveCurrentEntryToMemory();

            // Representative Checkbox
            chkIsRepresentative.Click += ChkIsRepresentative_Click;
        }

        private void ChkIsRepresentative_Click(object sender, EventArgs e)
        {
            if (_isChangingSelection || _currentEntry == null) return;

            // If user tries to uncheck the current representative, prevent it (must select another to change)
            // OR allow it and validate at the end. 
            // Logic: User clicked Checkbox.
            
            if (chkIsRepresentative.Checked)
            {
                // Set current as Representative
                _currentEntry.IsRepresentative = true;

                // Uncheck all others
                foreach (var entry in _passengerEntries)
                {
                    if (entry != _currentEntry)
                        entry.IsRepresentative = false;
                }
            }
            else
            {
                // User unchecked it.
                _currentEntry.IsRepresentative = false;
            }

            // Refresh list to show Star icon
            lstPassengers.Refresh();
        }

        private void InitializePassengerList()
        {
            _passengerEntries = new List<PassengerEntry>();
            int index = 0;

            // Load from PassengerSelectionState
            int adultCount = PassengerSelectionState.Adult;
            int childCount = PassengerSelectionState.Child;
            int infantCount = PassengerSelectionState.Infant;

            for (int i = 1; i <= adultCount; i++)
            {
                _passengerEntries.Add(new PassengerEntry
                {
                    Index = index++,
                    DisplayName = $"Người lớn {i}",
                    Type = PassengerType.Adult,
                    CustomerData = null,
                    IsCompleted = false,
                    IsRepresentative = (i == 1) // Default first adult is representative
                });
            }

            for (int i = 1; i <= childCount; i++)
            {
                _passengerEntries.Add(new PassengerEntry
                {
                    Index = index++,
                    DisplayName = $"Trẻ em {i}",
                    Type = PassengerType.Child,
                    CustomerData = null,
                    IsCompleted = false,
                    IsRepresentative = false
                });
            }

            for (int i = 1; i <= infantCount; i++)
            {
                _passengerEntries.Add(new PassengerEntry
                {
                    Index = index++,
                    DisplayName = $"Em bé {i}",
                    Type = PassengerType.Infant,
                    CustomerData = null,
                    IsCompleted = false,
                    IsRepresentative = false
                });
            }

            RefreshPassengerList();
            
            if (_passengerEntries.Count > 0)
                lstPassengers.SelectedIndex = 0;
        }

        private void RefreshPassengerList()
        {
            int selectedIndex = lstPassengers.SelectedIndex;
            lstPassengers.Items.Clear();
            foreach (var entry in _passengerEntries)
            {
                lstPassengers.Items.Add(entry); // Uses ToString()
            }
            
            if (selectedIndex >= 0 && selectedIndex < lstPassengers.Items.Count)
                lstPassengers.SelectedIndex = selectedIndex;
        }

        private void LstPassengers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isChangingSelection) return;

            // Save previous if exists (handled by events, but double check)
            if (_currentEntry != null)
            {
                SaveCurrentEntryToMemory();
            }

            if (lstPassengers.SelectedItem is PassengerEntry selectedEntry)
            {
                _currentEntry = selectedEntry;
                LoadEntryToForm(selectedEntry);
            }
        }

        private void LoadEntryToForm(PassengerEntry entry)
        {
            _isChangingSelection = true;

            // Update Title Group to indicate requirements
            string typeName = entry.Type == PassengerType.Adult ? "Người lớn (>12 tuổi)" :
                              entry.Type == PassengerType.Child ? "Trẻ em (2-12 tuổi)" : "Em bé (<2 tuổi)";
            grpInfo.Text = $"Thông tin: {entry.DisplayName} - {typeName}";

            // Representative Logic
            chkIsRepresentative.Checked = entry.IsRepresentative;
            chkIsRepresentative.Enabled = (entry.Type == PassengerType.Adult);

            // Clear fields first
            ClearInputFields();

            // Load data if exists
            if (entry.CustomerData != null)
            {
                FillFormWithCustomer(entry.CustomerData);
            }

            // Reset Grid and Search
            dgvCustomers.Visible = false;
            txtSearch.Clear();
            
            // Focus appropriate field
            if (entry.CustomerData == null)
                txtSearch.Focus();
            else
                txtHo.Focus();

            _isChangingSelection = false;
        }

        private void SaveCurrentEntryToMemory()
        {
            if (_isChangingSelection || _currentEntry == null) return;

            // Create or Update DTO object
            if (_currentEntry.CustomerData == null)
                _currentEntry.CustomerData = new KhachHangDTO();

            var cust = _currentEntry.CustomerData;
            cust.HoTen = (txtHo.Text.Trim() + " " + txtTen.Text.Trim()).Trim();
            
            // Map Title to Gender
            string title = cmbDanhXung.SelectedItem?.ToString();
            if (title == "Ông" || title == "Anh" || title == "Bé trai")
                cust.GioiTinh = "Nam";
            else if (title == "Bà" || title == "Cô" || title == "Chị" || title == "Bé gái")
                cust.GioiTinh = "Nữ";
            else
                cust.GioiTinh = "Khác";

            cust.NgaySinh = dtpNgaySinh.Value;
            cust.SoDienThoai = txtSDT.Text.Trim();
            cust.CCCD = txtCCCD.Text.Trim();
            cust.Email = txtEmail.Text.Trim();
            cust.DiaChi = txtDiaChi.Text.Trim();
            cust.LoaiKhachHang = "Red"; // Default

            // Check simple completion
            bool hasName = !string.IsNullOrWhiteSpace(cust.HoTen);
            _currentEntry.IsCompleted = hasName;
            
            // (IsRepresentative is updated via Checkbox Click event directly)

            // Soft Refresh List (redraw item text)
            int index = _passengerEntries.IndexOf(_currentEntry);
            if (index >= 0 && index < lstPassengers.Items.Count)
            {
                // Invalidate to trigger DrawItem
                lstPassengers.Invalidate(lstPassengers.GetItemRectangle(index));
            }
        }

        private void FillFormWithCustomer(KhachHangDTO customer)
        {
            string fullName = customer.HoTen;
            if (!string.IsNullOrEmpty(fullName))
            {
                int firstSpaceIndex = fullName.IndexOf(' ');
                if (firstSpaceIndex > 0)
                {
                    txtHo.Text = fullName.Substring(0, firstSpaceIndex);
                    txtTen.Text = fullName.Substring(firstSpaceIndex + 1);
                }
                else
                {
                    txtHo.Text = fullName;
                    txtTen.Text = "";
                }
            }

            // Try to match Gender to Combo
            if (customer.GioiTinh == "Nam")
                cmbDanhXung.SelectedItem = (_currentEntry.Type == PassengerType.Infant || _currentEntry.Type == PassengerType.Child) ? "Bé trai" : "Ông";
            else if (customer.GioiTinh == "Nữ")
                cmbDanhXung.SelectedItem = (_currentEntry.Type == PassengerType.Infant || _currentEntry.Type == PassengerType.Child) ? "Bé gái" : "Bà";
            else
                cmbDanhXung.SelectedIndex = -1;

            if (customer.NgaySinh.HasValue)
                dtpNgaySinh.Value = customer.NgaySinh.Value;
            
            txtSDT.Text = customer.SoDienThoai;
            txtCCCD.Text = customer.CCCD;
            txtEmail.Text = customer.Email;
            txtDiaChi.Text = customer.DiaChi;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword)) return;

            try
            {
                var results = KhachHangBLL.Instance.SmartSearchCustomer(keyword);
                if (results != null && results.Count > 0)
                {
                    dgvCustomers.DataSource = results;
                    dgvCustomers.Visible = true;
                    SetupGridColumns();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCustomers.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && _currentEntry != null)
            {
                var customer = (KhachHangDTO)dgvCustomers.Rows[e.RowIndex].DataBoundItem;
                // Copy data to form
                FillFormWithCustomer(customer);
                // Set ID to link existing
                _currentEntry.CustomerData = customer; 
                SaveCurrentEntryToMemory();
            }
        }

        private void BtnConfirmAll_Click(object sender, EventArgs e)
        {
            SaveCurrentEntryToMemory(); // Ensure last edit is saved

            // Validate All
            List<string> errors = new List<string>();
            SelectedCustomers = new List<KhachHangDTO>();
            RepresentativeCustomer = null;
            int repCount = 0;

            foreach (var entry in _passengerEntries)
            {
                var cust = entry.CustomerData;
                
                // 1. Basic Info Check
                if (cust == null || string.IsNullOrWhiteSpace(cust.HoTen))
                {
                    errors.Add($"{entry.DisplayName}: Chưa nhập họ tên.");
                    continue;
                }
                if (string.IsNullOrWhiteSpace(entry.CustomerData.GioiTinh))
                {
                    errors.Add($"{entry.DisplayName}: Chưa chọn danh xưng/giới tính.");
                }

                // 2. Age Check
                if (cust.NgaySinh.HasValue)
                {
                    int age = DateTime.Now.Year - cust.NgaySinh.Value.Year;
                    if (DateTime.Now < cust.NgaySinh.Value.AddYears(age)) age--;

                    if (entry.Type == PassengerType.Adult && age < 12)
                        errors.Add($"{entry.DisplayName}: Tuổi phải từ 12 trở lên (Hiện tại: {age})");
                    
                    if (entry.Type == PassengerType.Child && (age < 2 || age >= 12))
                        errors.Add($"{entry.DisplayName}: Tuổi phải từ 2 đến dưới 12 (Hiện tại: {age})");

                    if (entry.Type == PassengerType.Infant && age >= 2)
                        errors.Add($"{entry.DisplayName}: Tuổi phải dưới 2 (Hiện tại: {age})");
                }
                else
                {
                     errors.Add($"{entry.DisplayName}: Chưa nhập ngày sinh.");
                }

                // Check Representative
                if (entry.IsRepresentative)
                {
                    repCount++;
                    RepresentativeCustomer = cust;
                    
                    // Rep must have Contact Info
                    if (string.IsNullOrWhiteSpace(cust.SoDienThoai))
                        errors.Add($"{entry.DisplayName} (Người đại diện): Phải có số điện thoại.");
                }

                // 3. Create in DB if new (no ID)
                if (string.IsNullOrEmpty(cust.MaKhachHang))
                {
                    try
                    {
                        // Call BLL to create
                        string newId = KhachHangBLL.Instance.CreateCustomer(cust);
                        cust.MaKhachHang = newId;
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"{entry.DisplayName}: Lỗi lưu dữ liệu - {ex.Message}");
                    }
                }

                SelectedCustomers.Add(cust);
            }

            if (repCount == 0)
            {
                errors.Add("Vui lòng chọn 1 Người đại diện liên hệ (Người lớn).");
            }
            else if (repCount > 1)
            {
                 errors.Add("Chỉ được chọn 1 Người đại diện liên hệ.");
            }

            if (errors.Count > 0)
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin:\n" + string.Join("\n", errors), 
                    "Thông tin chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Success
            // Tạm thời logic đặt vé sẽ được xử lý bởi form cha sau khi nhận DialogResult.OK
            // Nếu muốn chuyển sang form thanh toán ngay lập tức, cần thông tin về chuyến bay và ghế
            // Giả sử form cha sẽ nhận kết quả và mở form thanh toán
            
            // Tuy nhiên, nếu yêu cầu là mở form thanh toán từ đây:
            // 1. Cần có cơ chế tạo vé (Booking) trước.
            // 2. Cần truyền thông tin Booking sang form Thanh Toán.
            
            // Vì hiện tại form này chưa có thông tin Chuyến Bay/Ghế, ta sẽ giữ nguyên việc trả về OK
            // Form cha (frmDatVe hoặc frmChonGhe) sẽ nhận List<KhachHangDTO> và tiến hành tạo vé -> mở frmThanhToan
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ClearInputFields()
        {
            cmbDanhXung.SelectedIndex = -1;
            txtHo.Clear();
            txtTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Clear();
            txtCCCD.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
        }
        
        private void SetupGridColumns()
        {
            // Hide internal columns or unrelated ones
             if (dgvCustomers.Columns["MaKhachHang"] != null) dgvCustomers.Columns["MaKhachHang"].HeaderText = "Mã KH";
             if (dgvCustomers.Columns["HoTen"] != null) dgvCustomers.Columns["HoTen"].HeaderText = "Họ tên";
             if (dgvCustomers.Columns["SDT"] != null) dgvCustomers.Columns["SDT"].HeaderText = "SĐT";
        }

        // Custom Draw for ListBox to show checkmarks or colors
        private void LstPassengers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            
            PassengerEntry entry = (PassengerEntry)lstPassengers.Items[e.Index];
            
            Brush textBrush = Brushes.Black;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                textBrush = Brushes.White;
            }
            else if (!entry.IsCompleted)
            {
                textBrush = Brushes.Red; // Highlight incomplete
            }

            e.Graphics.DrawString(entry.ToString(), e.Font, textBrush, e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}