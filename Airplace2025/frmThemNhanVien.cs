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
using System.IO; // QUAN TRỌNG: Thư viện xử lý ảnh

namespace Airplace2025
{
    public partial class frmThemNhanVien : Form
    {

        public frmThemNhanVien()
        {
            InitializeComponent();
        }

        // Chuỗi kết nối
        string strCon = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=QuanLyBanVeMayBay;Integrated Security=True;";


        // --- 1. HÀM CHUYỂN ẢNH SANG BYTE ---
        private byte[] ChuyenAnhSangByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        // --- 2. HÀM SINH MÃ TỰ ĐỘNG ---
        private string TaoMaTuDong(string tienTo)
        {
            // Sửa lại format: yy (2 số cuối năm) để mã ngắn gọn hơn, tránh lỗi quá ký tự SQL
            // Ví dụ: NV2512011030 (12 ký tự)
            return tienTo + DateTime.Now.ToString("yyMMddHHmmss");
        }

        // --- 3. SỰ KIỆN NÚT CHỌN ẢNH (Kiểm tra tên nút bên Design nhé) ---
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            open.Title = "Chọn ảnh chân dung";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picChanDung.Image = Image.FromFile(open.FileName);
                picChanDung.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // --- 4. SỰ KIỆN NÚT THÊM (QUAN TRỌNG NHẤT) ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            // A. Kiểm tra nhập liệu
            if (txtHoTen.Text == "" || txtCCCD.Text == "" || txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Họ tên, CCCD và Tên đăng nhập!");
                return;
            }

            if (picChanDung.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh chân dung!");
                return;
            }

            SqlConnection sqlCon = null;
            SqlTransaction transaction = null;

            try
            {
                sqlCon = new SqlConnection(strCon);
                sqlCon.Open();
                transaction = sqlCon.BeginTransaction();

                // --- BƯỚC 1: TẠO TÀI KHOẢN ---
                string maNguoiDung = TaoMaTuDong("ND");
                string matKhauMacDinh = "123456";

                // Kiểm tra mã vai trò (Lưu ý: Phải khớp với dữ liệu trong bảng VaiTro của SQL)
                string maVaiTro = "";
                if (cboChucVu.Text == "Quản lí" || cboChucVu.Text == "Admin" || cboChucVu.Text == "Quản lý")
                    maVaiTro = "ADMIN"; // Sửa AD01 thành ADMIN
                else
                    maVaiTro = "STAFF"; // Sửa NV01 thành STAFF

                string sqlTaiKhoan = @"INSERT INTO TaiKhoan (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro) 
                       VALUES (@MaND, @TenDN, HASHBYTES('SHA2_512', CAST(@MatKhau AS VARCHAR(100))), @MaVT)";
                SqlCommand cmdTK = new SqlCommand(sqlTaiKhoan, sqlCon, transaction);
                cmdTK.Parameters.AddWithValue("@MaND", maNguoiDung);
                cmdTK.Parameters.AddWithValue("@TenDN", txtTenDangNhap.Text);
                cmdTK.Parameters.AddWithValue("@MatKhau", matKhauMacDinh);
                cmdTK.Parameters.AddWithValue("@MaVT", maVaiTro);
                cmdTK.ExecuteNonQuery();

                // --- BƯỚC 2: TẠO NHÂN VIÊN ---
                string maNhanVien = TaoMaTuDong("NV");
                byte[] anhByte = ChuyenAnhSangByte(picChanDung.Image);

                string sqlNhanVien = @"INSERT INTO NhanVien 
                    (MaNhanVien, HoTen, NgaySinh, GioiTinh, DiaChi, CCCD, Email, SoDienThoai, NgayVaoLam, ChanDung, MaNguoiDung) 
                    VALUES 
                    (@MaNV, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @CCCD, @Email, @SDT, @NgayLam, @Anh, @MaND_FK)";

                SqlCommand cmdNV = new SqlCommand(sqlNhanVien, sqlCon, transaction);
                cmdNV.Parameters.AddWithValue("@MaNV", maNhanVien);
                cmdNV.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                cmdNV.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                cmdNV.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                cmdNV.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmdNV.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                cmdNV.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmdNV.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmdNV.Parameters.AddWithValue("@NgayLam", dtpNgayVaoLam.Value);
                cmdNV.Parameters.AddWithValue("@MaND_FK", maNguoiDung);

                // --- ĐOẠN SỬA LỖI ẢNH ---
                // Chỉ định rõ kiểu dữ liệu là VarBinary để không bị lỗi "implicit conversion"
                cmdNV.Parameters.Add("@Anh", SqlDbType.VarBinary).Value = anhByte;

                cmdNV.ExecuteNonQuery();

                // --- HOÀN TẤT ---
                transaction.Commit();
                MessageBox.Show("Thêm nhân viên thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                if (transaction != null) transaction.Rollback();
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (sqlCon != null && sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
        }

        // --- 5. SỰ KIỆN NÚT THOÁT ---
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm load form (để trống cũng được)
        private void frmThemNhanVien_Load(object sender, EventArgs e) { }
    }
}