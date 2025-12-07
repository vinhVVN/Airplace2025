using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airplace2025.DAL;
using System.Windows;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;

namespace Airplace2025.BLL.DAO
{
    public class LogDAO
    {
        private static LogDAO instance;
        public static LogDAO Instance
        {
            get { if (instance == null) instance = new LogDAO(); return instance; }
            private set => instance = value;
        }

        private LogDAO() { }

        // Hàm ghi log (Dùng ở mọi nơi trong phần mềm)
        public void GhiNhatKy(string hanhDong, string chiTiet)
        {
            try
            {
                string query = "INSERT INTO NhatKyHoatDong (TenDangNhap, HanhDong, ChiTiet, ThoiGian) VALUES (@User, @Action, @Detail, GETDATE())";

                // Lấy tên người dùng hiện tại từ Session (nếu chưa đăng nhập thì ghi 'System' hoặc 'Guest')
                string user = !string.IsNullOrEmpty(Session.TenDangNhap) ? Session.TenDangNhap : "John Doe";

                using (SqlConnection con = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@User", user);
                    cmd.Parameters.AddWithValue("@Action", hanhDong);
                    cmd.Parameters.AddWithValue("@Detail", chiTiet);

                    try
                    {
                        con.Open();

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine("Ghi log thành công!");
                        }
                        else
                        {
                            Console.WriteLine("Ghi log thất bại!");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Lỗi khi thêm hãng bay: {ex.Message}");
                    }
                }
            }
            catch
            {
                // Ghi log thất bại thì bỏ qua, không làm crash chương trình chính
            }
        }

        //  Hàm lấy danh sách log có bộ lọc (Dùng cho Admin)
        public DataTable LayNhatKyHoatDong(string timKiem, DateTime tuNgay, DateTime denNgay)
        {
            // Query tìm kiếm theo Tên đăng nhập hoặc Hành động
            string query = @"
                SELECT MaNhatKy, ThoiGian, TenDangNhap, HanhDong, ChiTiet 
                FROM NhatKyHoatDong
                WHERE ThoiGian BETWEEN @TuNgay AND @DenNgay
                AND (TenDangNhap LIKE @TuKhoa OR HanhDong LIKE @TuKhoa OR ChiTiet LIKE @TuKhoa)
                ORDER BY ThoiGian DESC"; // Mới nhất lên đầu

            // Thêm thời gian cuối ngày cho 'denNgay' (23:59:59) để lấy trọn ngày
            DateTime denNgayFull = new DateTime(denNgay.Year, denNgay.Month, denNgay.Day, 23, 59, 59);

            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgayFull);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + timKiem + "%");

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //  Lấy danh sách tất cả nhân viên (để đổ vào Combobox lọc nếu cần)
        public DataTable GetListUsers()
        { 
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT Distinct TenDangNhap FROM TaiKhoan", con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }

}
