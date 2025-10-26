using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Airplace2025.DAL
{
    /// <summary>
    /// Data Access Layer for KhachHang (Customer)
    /// </summary>
    public class KhachHangDAO
    {
        private static KhachHangDAO _instance;
        public static KhachHangDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KhachHangDAO();
                return _instance;
            }
        }

        private KhachHangDAO() { }

        /// <summary>
        /// Search customer by different criteria
        /// </summary>
        public DataTable SearchCustomer(string searchType, string searchValue)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_TimKiemKhachHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoaiTimKiem", searchType);
                        cmd.Parameters.AddWithValue("@GiaTriTimKiem", searchValue);

                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tìm kiếm khách hàng: {ex.Message}", ex);
            }

            return dt;
        }

        /// <summary>
        /// Smart search - automatically detects search type (CCCD, Phone, Email, or Name)
        /// </summary>
        public DataTable SmartSearchCustomer(string searchValue)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_TimKiemKhachHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GiaTriTimKiem", searchValue);

                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tìm kiếm khách hàng: {ex.Message}", ex);
            }

            return dt;
        }

        /// <summary>
        /// Create new customer
        /// </summary>
        public string CreateCustomer(
            string hoTen,
            DateTime? ngaySinh,
            string gioiTinh,
            string diaChi,
            string cccd,
            string soDienThoai,
            string email,
            string loaiKhachHang = "Red")
        {
            string maKhachHang = null;

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ThemKhachHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@HoTen", hoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh.HasValue ? (object)ngaySinh.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@GioiTinh", string.IsNullOrEmpty(gioiTinh) ? (object)DBNull.Value : gioiTinh);
                        cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(diaChi) ? (object)DBNull.Value : diaChi);
                        cmd.Parameters.AddWithValue("@CCCD", string.IsNullOrEmpty(cccd) ? (object)DBNull.Value : cccd);
                        cmd.Parameters.AddWithValue("@SoDienThoai", string.IsNullOrEmpty(soDienThoai) ? (object)DBNull.Value : soDienThoai);
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                        cmd.Parameters.AddWithValue("@LoaiKhachHang", loaiKhachHang);

                        SqlParameter outputParam = new SqlParameter("@MaKhachHang", SqlDbType.VarChar, 15);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        maKhachHang = outputParam.Value?.ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation
                {
                    if (ex.Message.Contains("UQ_KhachHang_CCCD"))
                        throw new Exception("CCCD đã tồn tại trong hệ thống");
                    else if (ex.Message.Contains("UQ_KhachHang_Email"))
                        throw new Exception("Email đã tồn tại trong hệ thống");
                    else if (ex.Message.Contains("UQ_KhachHang_SoDienThoai"))
                        throw new Exception("Số điện thoại đã tồn tại trong hệ thống");
                    else
                        throw new Exception("Thông tin khách hàng bị trùng lặp");
                }
                throw new Exception($"Lỗi tạo khách hàng: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tạo khách hàng: {ex.Message}", ex);
            }

            return maKhachHang;
        }

        /// <summary>
        /// Get customer by ID
        /// </summary>
        public DataRow GetCustomerById(string maKhachHang)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string query = @"
                        SELECT 
                            MaKhachHang,
                            HoTen,
                            NgaySinh,
                            GioiTinh,
                            DiaChi,
                            CCCD,
                            SoDienThoai,
                            Email,
                            LoaiKhachHang
                        FROM KhachHang
                        WHERE MaKhachHang = @MaKhachHang";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin khách hàng: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Get list of booked seats for a flight
        /// </summary>
        public List<string> GetBookedSeats(string maChuyenBay)
        {
            List<string> bookedSeats = new List<string>();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_LayDanhSachGheDaDat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaChuyenBay", maChuyenBay);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    bookedSeats.Add(reader.GetString(0));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách ghế đã đặt: {ex.Message}", ex);
            }

            return bookedSeats;
        }
    }
}


