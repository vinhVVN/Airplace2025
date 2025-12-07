using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Airplace2025
{
    public partial class frmQuanLiKhachhang : Form
    {
        // 1. Khai báo biến cờ hiệu để kiểm soát sự kiện
        bool isLoaded = false;

        // Chuỗi kết nối
        string strCon = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=QuanLyBanVeMayBay;Integrated Security=True";
        SqlConnection sqlCon = null;

        public frmQuanLiKhachhang()
        {
            InitializeComponent();
        }

        private void frmQuanLiKhachhang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            LoadData();
            LoadComboboxID();

        }

        // --- HÀM MỚI: Đặt tên cột tiếng Việt cho đẹp ---
        private void DatTenCot()
        {
            // Kiểm tra xem bảng có dữ liệu chưa để tránh lỗi
            if (dgvKhachHang.Columns.Count > 0)
            {
                dgvKhachHang.Columns["MaKhachHang"].HeaderText = "Mã KH";
                dgvKhachHang.Columns["HoTen"].HeaderText = "Họ và Tên";
                dgvKhachHang.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                dgvKhachHang.Columns["GioiTinh"].HeaderText = "Giới Tính";
                dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                dgvKhachHang.Columns["CCCD"].HeaderText = "CCCD/CMND";
                dgvKhachHang.Columns["SoDienThoai"].HeaderText = "Số ĐT";
                dgvKhachHang.Columns["Email"].HeaderText = "Email";
                dgvKhachHang.Columns["LoaiKhachHang"].HeaderText = "Loại Khách";

                // Tùy chỉnh độ rộng cột nếu muốn (Optional)
                dgvKhachHang.Columns["HoTen"].Width = 150;
                dgvKhachHang.Columns["Email"].Width = 150;
            }
        }

        private void LoadData()
        {
            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM KhachHang", sqlCon);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);

                dgvKhachHang.DataSource = dt;

                // GỌI HÀM ĐỔI TÊN CỘT NGAY SAU KHI GÁN DỮ LIỆU
                DatTenCot();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadComboboxID()
        {
            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                SqlCommand cmd = new SqlCommand("SELECT MaKhachHang FROM KhachHang", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                isLoaded = false; // Tắt cờ
                cboTimKiemID.DataSource = dt;
                cboTimKiemID.DisplayMember = "MaKhachHang";
                cboTimKiemID.ValueMember = "MaKhachHang";
                cboTimKiemID.SelectedIndex = -1;
                isLoaded = true; // Bật cờ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Combobox: " + ex.Message);
            }
        }

        private void cboTimKiemID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoaded == false) return;
            if (cboTimKiemID.SelectedIndex == -1 || cboTimKiemID.SelectedValue == null) return;

            try
            {
                string maKH = cboTimKiemID.SelectedValue.ToString();
                ShowDataByQuery("SELECT * FROM KhachHang WHERE MaKhachHang = '" + maKH + "'");
            }
            catch (Exception) { }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadData();
                isLoaded = false;
                cboTimKiemID.SelectedIndex = -1;
                isLoaded = true;
                return;
            }

            string query = "SELECT * FROM KhachHang WHERE " +
                           "HoTen LIKE N'%" + tuKhoa + "%' OR " +
                           "SoDienThoai LIKE '%" + tuKhoa + "%' OR " +
                           "CCCD LIKE '%" + tuKhoa + "%'";
            ShowDataByQuery(query);
        }

        private void ShowDataByQuery(string query)
        {
            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKhachHang.DataSource = dt;

                // GỌI HÀM ĐỔI TÊN CỘT CẢ Ở ĐÂY NỮA
                DatTenCot();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                if (row.Cells[1].Value != null) txtTenKhachHang.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "") dtpNgaySinh.Value = Convert.ToDateTime(row.Cells[2].Value);
                if (row.Cells[3].Value != null) cboGioiTinh.Text = row.Cells[3].Value.ToString();
                if (row.Cells[4].Value != null) txtDiaChi.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value != null) txtCCCD.Text = row.Cells[5].Value.ToString();
                if (row.Cells[6].Value != null) txtSDT.Text = row.Cells[6].Value.ToString();
                if (row.Cells[7].Value != null) txtEmail.Text = row.Cells[7].Value.ToString();
                if (row.Cells[8].Value != null) cboLoaiKhach.Text = row.Cells[8].Value.ToString();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e) // Nút Thêm
        {
            frmThemKhachHang f = new frmThemKhachHang();
            f.ShowDialog();
            LoadData();
            LoadComboboxID();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null || dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();

            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                string sqlUpdate = "UPDATE KhachHang SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, " +
                                   "DiaChi=@DiaChi, CCCD=@CCCD, SoDienThoai=@SDT, Email=@Email, LoaiKhachHang=@LoaiKhach " +
                                   "WHERE MaKhachHang = @MaKH";

                SqlCommand cmd = new SqlCommand(sqlUpdate, sqlCon);
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@HoTen", txtTenKhachHang.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@LoaiKhach", cboLoaiKhach.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    LoadData();
                }
                else MessageBox.Show("Cập nhật thất bại!", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Cập nhật: " + ex.Message);
            }
        }

        // --- Nút Xóa (Đã fix lỗi ràng buộc) ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow == null || dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa!", "Thông báo");
                return;
            }

            string maKH = dgvKhachHang.CurrentRow.Cells[0].Value.ToString();
            string tenKH = dgvKhachHang.CurrentRow.Cells[1].Value.ToString();

            if (MessageBox.Show("CẢNH BÁO: Xóa khách hàng [" + tenKH + "] sẽ xóa toàn bộ LỊCH SỬ ĐẶT VÉ của họ.\nBạn có chắc chắn muốn xóa không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                    if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                    // BƯỚC 1: Xóa dữ liệu trong bảng ChiTietDatVe trước
                    string sqlDeleteChild = "DELETE FROM ChiTietDatVe WHERE MaKhachHang = @MaKH";
                    SqlCommand cmdChild = new SqlCommand(sqlDeleteChild, sqlCon);
                    cmdChild.Parameters.AddWithValue("@MaKH", maKH);
                    cmdChild.ExecuteNonQuery();

                    // BƯỚC 2: Xóa dữ liệu trong bảng KhachHang sau
                    string sqlDeleteParent = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKH";
                    SqlCommand cmdParent = new SqlCommand(sqlDeleteParent, sqlCon);
                    cmdParent.Parameters.AddWithValue("@MaKH", maKH);

                    if (cmdParent.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        LoadData();
                        LoadComboboxID();
                        txtTenKhachHang.Clear(); txtSDT.Clear(); txtDiaChi.Clear(); txtCCCD.Clear(); txtEmail.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Các hàm thừa giữ lại để tránh lỗi Designer
        private void label1_Click(object sender, EventArgs e) { }
        private void guna2GroupBox2_Click(object sender, EventArgs e) { }
    }
}