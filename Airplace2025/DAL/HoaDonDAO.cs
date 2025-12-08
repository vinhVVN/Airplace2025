using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Airplace2025.DAL
{
    public class HoaDonDAO
    {
        private static HoaDonDAO _instance;
        public static HoaDonDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HoaDonDAO();
                return _instance;
            }
        }

        private HoaDonDAO() { }

        public string ThanhToanVaXuatVe(string maHoaDon, string phuongThucTT, decimal tongTien, List<string> danhSachMaDatVe)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Tạo Hóa Đơn
                    string queryHoaDon = "INSERT INTO HoaDon (MaHoaDon, PhuongThucThanhToan, TongTien, PhuThu, NoiDungPhuThu) VALUES (@MaHoaDon, @PhuongThucTT, @TongTien, 0, N'')";
                    using (SqlCommand cmd = new SqlCommand(queryHoaDon, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmd.Parameters.AddWithValue("@PhuongThucTT", phuongThucTT);
                        cmd.Parameters.AddWithValue("@TongTien", tongTien);
                        cmd.ExecuteNonQuery();
                    }


                    // 2. Cập nhật ChiTietDatVe và Ve
                    foreach (string maDatVe in danhSachMaDatVe)
                    {
                        // Cập nhật MaHoaDon vào ChiTietDatVe
                        string queryUpdateCTDV = "UPDATE ChiTietDatVe SET MaHoaDon = @MaHoaDon WHERE MaDatVe = @MaDatVe";
                        using (SqlCommand cmd = new SqlCommand(queryUpdateCTDV, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                            cmd.Parameters.AddWithValue("@MaDatVe", maDatVe);
                            cmd.ExecuteNonQuery();
                        }

                        // Lấy MaVe từ ChiTietDatVe để cập nhật Ve
                        string queryGetMaVe = "SELECT MaVe FROM ChiTietDatVe WHERE MaDatVe = @MaDatVe";
                        string maVe = null;
                        using (SqlCommand cmd = new SqlCommand(queryGetMaVe, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaDatVe", maDatVe);
                            object result = cmd.ExecuteScalar();
                            if (result != null) maVe = result.ToString();
                        }

                        if (!string.IsNullOrEmpty(maVe))
                        {
                            // Cập nhật TinhTrang Ve -> 'Đã thanh toán'
                            string queryUpdateVe = "UPDATE Ve SET TinhTrang = N'Đã thanh toán' WHERE MaVe = @MaVe";
                            using (SqlCommand cmd = new SqlCommand(queryUpdateVe, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@MaVe", maVe);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();
                    return danhSachMaDatVe[0];
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public string GenerateNewMaHoaDon()
        {
            // Logic đơn giản để sinh mã HD tự động: HD + yyyyMMdd + Random/Count
            // Để đơn giản cho demo, dùng DateTime ticks hoặc count DB
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM HoaDon", conn))
                {
                    int count = (int)cmd.ExecuteScalar();
                    return "HD" + DateTime.Now.ToString("yyMMdd") + (count + 1).ToString("D4");
                }
            }
        }
    }
}

