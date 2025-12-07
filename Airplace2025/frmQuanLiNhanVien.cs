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
using Airplace2025.DAL;

namespace Airplace2025
{
    public partial class frmQuanLiNhanVien : Form
    {
        string maNhanVienDangChon = "";
        string maNguoiDungDangChon = "";

        // Sử dụng connection string từ DBConnection
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataTable dt = null;

        public frmQuanLiNhanVien()
        {
            InitializeComponent();
        }

        // --- Các sự kiện chưa dùng đến ---
        private void guna2HtmlLabel8_Click(object sender, EventArgs e) { }
        private void guna2TextBox4_TextChanged(object sender, EventArgs e) { }
        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void guna2HtmlLabel6_Click(object sender, EventArgs e) { }
        private void guna2TextBox9_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox10_TextChanged(object sender, EventArgs e) { }


        // --- 1. SỰ KIỆN NÚT THÊM ---
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmThemNhanVien f = new frmThemNhanVien();
            f.ShowDialog();
            LoadData();
        }

        // --- 2. HÀM TẢI DỮ LIỆU ---
        private void LoadData()
        {
            try
            {
                // Sử dụng GetConnection() từ DBConnection
                if (sqlCon == null) sqlCon = DBConnection.GetConnection();

                string query = @"
                    SELECT 
                        nv.*, 
                        tk.TenDangNhap, 
                        vt.TenVaiTro 
                    FROM NhanVien nv
                    LEFT JOIN TaiKhoan tk ON nv.MaNguoiDung = tk.MaNguoiDung
                    LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro";

                adapter = new SqlDataAdapter(query, sqlCon);
                dt = new DataTable();
                adapter.Fill(dt);

                dgvNhanVien.AutoGenerateColumns = false;
                dgvNhanVien.DataSource = dt;

                // --- TỰ TẠO CỘT ẨN NẾU CHƯA CÓ ---
                if (!dgvNhanVien.Columns.Contains("TenDangNhap"))
                {
                    DataGridViewTextBoxColumn colTK = new DataGridViewTextBoxColumn();
                    colTK.Name = "TenDangNhap";
                    colTK.DataPropertyName = "TenDangNhap";
                    colTK.HeaderText = "Tài Khoản";
                    dgvNhanVien.Columns.Add(colTK);
                }

                if (!dgvNhanVien.Columns.Contains("TenVaiTro"))
                {
                    DataGridViewTextBoxColumn colVT = new DataGridViewTextBoxColumn();
                    colVT.Name = "TenVaiTro";
                    colVT.DataPropertyName = "TenVaiTro";
                    colVT.HeaderText = "Chức Vụ";
                    dgvNhanVien.Columns.Add(colVT);
                }

                // --- Đặt tên cột ---
                if (dgvNhanVien.Columns.Contains("MaNhanVien")) dgvNhanVien.Columns["MaNhanVien"].HeaderText = "Mã NV";
                if (dgvNhanVien.Columns.Contains("HoTen")) dgvNhanVien.Columns["HoTen"].HeaderText = "Họ và Tên";
                if (dgvNhanVien.Columns.Contains("NgaySinh")) dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                if (dgvNhanVien.Columns.Contains("GioiTinh")) dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                if (dgvNhanVien.Columns.Contains("DiaChi")) dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                if (dgvNhanVien.Columns.Contains("CCCD")) dgvNhanVien.Columns["CCCD"].HeaderText = "CCCD/CMND";
                if (dgvNhanVien.Columns.Contains("Email")) dgvNhanVien.Columns["Email"].HeaderText = "Email";
                if (dgvNhanVien.Columns.Contains("SoDienThoai")) dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số ĐT";
                if (dgvNhanVien.Columns.Contains("NgayVaoLam")) dgvNhanVien.Columns["NgayVaoLam"].HeaderText = "Ngày Vào Làm";

                if (dgvNhanVien.Columns.Contains("ChanDung")) dgvNhanVien.Columns["ChanDung"].Visible = false;
                if (dgvNhanVien.Columns.Contains("MaNguoiDung")) dgvNhanVien.Columns["MaNguoiDung"].Visible = false;

                if (dgvNhanVien.Columns.Contains("NgaySinh"))
                    dgvNhanVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                if (dgvNhanVien.Columns.Contains("NgayVaoLam"))
                    dgvNhanVien.Columns["NgayVaoLam"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void frmQuanLiNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // --- 3. SỰ KIỆN CLICK VÀO BẢNG ---
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                cboGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();

                if (row.Cells["NgaySinh"].Value != DBNull.Value)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

                if (row.Cells["TenDangNhap"].Value != DBNull.Value)
                    txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                else
                    txtTenDangNhap.Text = "";

                if (row.Cells["TenVaiTro"].Value != DBNull.Value)
                    cboChucVu.Text = row.Cells["TenVaiTro"].Value.ToString();
                else
                    cboChucVu.SelectedIndex = -1;

                maNhanVienDangChon = row.Cells["MaNhanVien"].Value.ToString();

                if (dgvNhanVien.Columns.Contains("MaNguoiDung"))
                {
                    var giaTriO = row.Cells["MaNguoiDung"].Value;
                    if (giaTriO != null && giaTriO != DBNull.Value)
                        maNguoiDungDangChon = giaTriO.ToString();
                    else
                        maNguoiDungDangChon = "";
                }
            }
        }

        // --- 4. SỰ KIỆN NÚT TÌM KIẾM ---
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTuKhoa.Text.Trim();
                // Sử dụng GetConnection() từ DBConnection
                if (sqlCon == null) sqlCon = DBConnection.GetConnection();

                string query = @"
                    SELECT 
                        nv.*, 
                        tk.TenDangNhap, 
                        vt.TenVaiTro 
                      FROM NhanVien nv
                      LEFT JOIN TaiKhoan tk ON nv.MaNguoiDung = tk.MaNguoiDung
                      LEFT JOIN VaiTro vt ON tk.MaVaiTro = vt.MaVaiTro
                      WHERE nv.HoTen LIKE N'%" + tuKhoa + "%'";

                adapter = new SqlDataAdapter(query, sqlCon);
                dt = new DataTable();
                adapter.Fill(dt);
                dgvNhanVien.DataSource = dt;

                if (dt.Rows.Count == 0) MessageBox.Show("Không tìm thấy: " + tuKhoa);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // --- 5. NÚT ĐÓNG ---
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- 6. NÚT XÓA (ĐÃ SỬA: DÙNG DELETE THAY VÌ UPDATE) ---
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (maNhanVienDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
                return;
            }

            DialogResult kq = MessageBox.Show("Xóa nhân viên này sẽ XÓA TOÀN BỘ VÉ do họ bán.\nBạn có chắc chắn không?", "Cảnh báo nghiêm trọng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (kq == DialogResult.Yes)
            {
                SqlConnection conn = null;
                SqlTransaction transaction = null;
                try
                {
                    // Sử dụng GetConnection() từ DBConnection
                    conn = DBConnection.GetConnection();
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    // --- BƯỚC 1: XÓA VÉ (Thay vì update) ---
                    string sqlXoaVe = "DELETE FROM Ve WHERE MaNhanVien = @MaNV";
                    SqlCommand cmdVe = new SqlCommand(sqlXoaVe, conn, transaction);
                    cmdVe.Parameters.AddWithValue("@MaNV", maNhanVienDangChon);
                    cmdVe.ExecuteNonQuery();

                    // --- BƯỚC 2: Xóa Nhân Viên ---
                    string sqlXoaNV = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNV";
                    SqlCommand cmdNV = new SqlCommand(sqlXoaNV, conn, transaction);
                    cmdNV.Parameters.AddWithValue("@MaNV", maNhanVienDangChon);
                    cmdNV.ExecuteNonQuery();

                    // --- BƯỚC 3: Xóa Tài Khoản ---
                    if (maNguoiDungDangChon != "")
                    {
                        string sqlXoaTK = "DELETE FROM TaiKhoan WHERE MaNguoiDung = @MaND";
                        SqlCommand cmdTK = new SqlCommand(sqlXoaTK, conn, transaction);
                        cmdTK.Parameters.AddWithValue("@MaND", maNguoiDungDangChon);
                        cmdTK.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Đã xóa thành công!");
                    LoadData();

                    // Reset
                    maNhanVienDangChon = "";
                    maNguoiDungDangChon = "";
                    txtHoTen.Text = "";
                    txtCCCD.Text = "";
                    txtTuKhoa.Text = "";
                    txtTenDangNhap.Text = "";
                    cboChucVu.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
                finally
                {
                    if (conn != null) conn.Close();
                }
            }
        }

        // --- 7. NÚT CẬP NHẬT ---
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (maNhanVienDangChon == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo");
                return;
            }

            SqlConnection conn = null;
            try
            {
                // Sử dụng GetConnection() từ DBConnection
                conn = DBConnection.GetConnection();
                if (conn.State == ConnectionState.Closed) conn.Open();

                string sqlUpdate = @"UPDATE NhanVien 
                             SET HoTen=@HoTen, CCCD=@CCCD, DiaChi=@DiaChi, 
                                 Email=@Email, SoDienThoai=@SDT, 
                                 GioiTinh=@GioiTinh, NgaySinh=@NgaySinh
                             WHERE MaNhanVien=@MaNV";

                SqlCommand cmd = new SqlCommand(sqlUpdate, conn);

                cmd.Parameters.AddWithValue("@MaNV", maNhanVienDangChon);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
            }
        }
    }
}