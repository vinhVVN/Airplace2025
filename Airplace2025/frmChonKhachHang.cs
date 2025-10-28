using Airplace2025.BLL.DTO;
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
    public partial class frmChonKhachHang : Form
    {
        private List<KhachHangDTO> _customers;
        public KhachHangDTO SelectedCustomer { get; set; }
        public frmChonKhachHang(List<KhachHangDTO> customers)
        {
            InitializeComponent();
            _customers = customers;
        }

        private void frmChonKhachHang_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCustomers();
        }

        private void SetupDataGridView()
        {
            dgvCustomers.Columns.Clear();
            dgvCustomers.Columns.Add("MaKhachHang", "Mã KH");
            dgvCustomers.Columns.Add("HoTen", "Họ tên");
            dgvCustomers.Columns.Add("NgaySinh", "Ngày sinh");
            dgvCustomers.Columns.Add("CCCD", "CCCD");
            dgvCustomers.Columns.Add("SoDienThoai", "Số ĐT");
            dgvCustomers.Columns.Add("Email", "Email");

            dgvCustomers.Columns["MaKhachHang"].Width = 80;
            dgvCustomers.Columns["HoTen"].Width = 150;
            dgvCustomers.Columns["NgaySinh"].Width = 100;
            dgvCustomers.Columns["CCCD"].Width = 100;
            dgvCustomers.Columns["SoDienThoai"].Width = 100;
            dgvCustomers.Columns["Email"].Width = 150;

            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
        }

        private void LoadCustomers()
        {
            dgvCustomers.Rows.Clear();

            foreach (var customer in _customers)
            {
                dgvCustomers.Rows.Add(
                    customer.MaKhachHang,
                    customer.HoTen,
                    customer.NgaySinh?.ToString("dd/MM/yyyy") ?? "",
                    customer.CCCD,
                    customer.SoDienThoai,
                    customer.Email
                );
            }
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedCustomer = _customers[e.RowIndex];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dgvCustomers.SelectedRows[0].Index;
            SelectedCustomer = _customers[selectedIndex];

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
