using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Airplace2025.DAL
{
    public class DatVeDAO
    {
        private static DatVeDAO _instance;
        public static DatVeDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatVeDAO();
                return _instance;
            }
        }

        private DatVeDAO() { }

        public string CreateVe(string maChuyenBay, string maHangVe, decimal giaVe, string maNhanVien = null)
        {
            // NV001 is a default staff for online booking (or get from session if logged in)
            if (string.IsNullOrEmpty(maNhanVien))
            {
                if (Airplace2025.Session.IsLoggedIn)
                {
                    maNhanVien = Airplace2025.Session.MaNhanVien;
                }
                else
                {
                    maNhanVien = "NV001";
                }
            }
            
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                
                // Generate MaVe
                string maVe = "VE" + DateTime.Now.Ticks.ToString().Substring(10) + new Random().Next(100, 999).ToString();
                // Ensure unique or handle exception, simplified here

                string query = @"INSERT INTO Ve (MaVe, TinhTrang, GiaVeThucTe, MaChuyenBay, MaHangVe, MaNhanVien) 
                                 VALUES (@MaVe, N'Đã đặt', @GiaVe, @MaChuyenBay, @MaHangVe, @MaNhanVien)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaVe", maVe);
                    cmd.Parameters.AddWithValue("@GiaVe", giaVe);
                    cmd.Parameters.AddWithValue("@MaChuyenBay", maChuyenBay);
                    cmd.Parameters.AddWithValue("@MaHangVe", maHangVe);
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    
                    cmd.ExecuteNonQuery();
                }
                return maVe;
            }
        }

        public string CreateChiTietDatVe(string maVe, string maKhachHang, string maGhe = "ANY")
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                string maDatVe = "ETK" + DateTime.Now.Ticks.ToString().Substring(12) + new Random().Next(1000, 9999).ToString();

                string query = @"INSERT INTO ChiTietDatVe (MaDatVe, NgayDat, MaGhe, MaVe, MaKhachHang, HanhLyThem, GhiChu) 
                                 VALUES (@MaDatVe, GETDATE(), @MaGhe, @MaVe, @MaKhachHang, 0, N'Đặt online')";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDatVe", maDatVe);
                    cmd.Parameters.AddWithValue("@MaGhe", maGhe);
                    cmd.Parameters.AddWithValue("@MaVe", maVe);
                    cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    
                    cmd.ExecuteNonQuery();
                }
                return maDatVe;
            }
        }

        public void DecreaseSeatCount(string maChuyenBay, string maHangVe)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE ChiTietHangVe 
                                 SET SoLuongConLai = SoLuongConLai - 1 
                                 WHERE MaChuyenBay = @MaChuyenBay AND MaHangVe = @MaHangVe AND SoLuongConLai > 0";
                 using (SqlCommand cmd = new SqlCommand(query, conn))
                 {
                     cmd.Parameters.AddWithValue("@MaChuyenBay", maChuyenBay);
                     cmd.Parameters.AddWithValue("@MaHangVe", maHangVe);
                     cmd.ExecuteNonQuery();
                 }
            }
        }
    }
}

