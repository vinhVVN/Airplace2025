using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Thư viện SQL

namespace Airplace2025
{
    public partial class frmThemKhachHang : Form
    {
        // Thay chuỗi kết nối của bạn vào đây
        string strCon = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=QuanLyBanVeMayBay;Integrated Security=True";
        SqlConnection sqlCon = null;

        public frmThemKhachHang()
        {
            InitializeComponent();
        }

        private void frmThemKhachHang_Load(object sender, EventArgs e)
        {
            // Có thể thêm code load dữ liệu cho ComboBox loại khách hàng nếu cần
            // Ví dụ: cboGioiTinh.Items.Add("Nam"); ...
        }

        // --- HÀM 1: TỰ ĐỘNG SINH MÃ KHÁCH HÀNG MỚI ---
        // Logic: Tìm mã lớn nhất (ví dụ KH010), cắt bỏ chữ 'KH', lấy số 10 + 1 = 11, ghép lại thành KH011
        private string TaoMaKhachHangTuDong()
        {
            string maMoi = "KH001"; // Mã mặc định nếu bảng rỗng
            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                SqlCommand cmd = new SqlCommand("SELECT TOP 1 MaKhachHang FROM KhachHang ORDER BY MaKhachHang DESC", sqlCon);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string maCu = result.ToString(); // Ví dụ: KH009
                    // Cắt lấy phần số (bỏ 2 ký tự đầu là KH)
                    int soThuTu = int.Parse(maCu.Substring(2));
                    soThuTu++; // Tăng lên 1

                    // Format lại thành chuỗi: D3 nghĩa là số có 3 chữ số (010)
                    maMoi = "KH" + soThuTu.ToString("D3");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sinh mã: " + ex.Message);
            }
            return maMoi;
        }

        // --- HÀM 2: SỰ KIỆN NÚT THÊM ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu cơ bản
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập tên và số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (sqlCon == null) sqlCon = new SqlConnection(strCon);
                if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();

                // 2. Tạo mã mới
                string maKH = TaoMaKhachHangTuDong();

                // 3. Viết câu lệnh INSERT (Dùng tham số @ để an toàn)
                // Lưu ý: Không insert cột 'TrangThai' vì bảng SQL không có cột đó
                string sqlInsert = "INSERT INTO KhachHang (MaKhachHang, HoTen, NgaySinh, GioiTinh, DiaChi, CCCD, SoDienThoai, Email, LoaiKhachHang) " +
                                   "VALUES (@MaKH, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @CCCD, @SDT, @Email, @LoaiKhach)";

                SqlCommand cmd = new SqlCommand(sqlInsert, sqlCon);

                // 4. Gán giá trị từ các ô nhập liệu vào tham số
                cmd.Parameters.AddWithValue("@MaKH", maKH);
                cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@LoaiKhach", cboLoaiKhach.Text);

                // 5. Thực thi lệnh
                int ketQua = cmd.ExecuteNonQuery();

                if (ketQua > 0)
                {
                    MessageBox.Show("Thêm khách hàng thành công! Mã: " + maKH, "Thông báo");
                    this.Close(); // Đóng form thêm để quay về form chính
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}