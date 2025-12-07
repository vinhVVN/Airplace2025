using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airplace2025.DAL;
using System.Windows.Forms;

namespace Airplace2025.BLL.DAO
{
    public class ClassDAO
    {
        private static ClassDAO instance;
        public static ClassDAO Instance
        {
            get { if (instance == null) instance = new ClassDAO(); return instance; }
            private set => instance = value;
        }
        public ClassDAO() { }

        public DataTable GetClassList()
        {
            string sql = "SELECT * FROM HangVe";
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetClassDetailByFlight(string MaChuyenBay)
        {
            string sql = "SELECT MaHangVe, SoLuong, SoLuongConLai FROM ChiTietHangVe WHERE MaChuyenBay = @MaChuyenBay";
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaChuyenBay", MaChuyenBay);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public void InsertClassInfo(string MaChuyenBay, string MaHangVe, int SoLuong, int SoLuongConLai)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_ThemChiTietHangVe", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaChuyenBay", MaChuyenBay);
                cmd.Parameters.AddWithValue("@MaHangVe", MaHangVe);
                cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
                cmd.Parameters.AddWithValue("@SoLuongConLai", SoLuongConLai);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm chi tiết hạng vé thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm chi tiết hạng vé thất bại, vui lòng kiểm tra lại dữ liệu.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi thêm chi tiết hạng vé: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Lấy cấu hình ghế chi tiết cho chuyến bay: số ghế mỗi hạng
        /// </summary>
        public Dictionary<string, int> GetSeatConfiguration(string MaChuyenBay)
        {
            var config = new Dictionary<string, int>();
            string sql = @"SELECT cthv.MaHangVe, hv.TenHangVe, cthv.SoLuong 
                          FROM ChiTietHangVe cthv 
                          JOIN HangVe hv ON cthv.MaHangVe = hv.MaHangVe 
                          WHERE cthv.MaChuyenBay = @MaChuyenBay
                          ORDER BY hv.TiLeGiaHangVe DESC"; // Từ hạng cao -> thấp

            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaChuyenBay", MaChuyenBay);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string maHangVe = reader["MaHangVe"].ToString();
                        int soLuong = Convert.ToInt32(reader["SoLuong"]);
                        config[maHangVe] = soLuong;
                    }
                }
            }
            return config;
        }

        /// <summary>
        /// Lấy mã hạng vé từ tên hạng vé (CabinClass)
        /// </summary>
        public string GetMaHangVeFromTenHangVe(string tenHangVe)
        {
            if (string.IsNullOrEmpty(tenHangVe)) return "ECO";

            string normalized = tenHangVe.ToUpperInvariant();

            if (normalized.Contains("NHẤT") || normalized.Contains("FIRST"))
                return "FIR";
            if (normalized.Contains("THƯƠNG GIA") || normalized.Contains("BUSINESS"))
                return "BUS";
            if (normalized.Contains("ĐẶC BIỆT") || normalized.Contains("PREMIUM"))
                return "PRE";

            return "ECO"; // Default: Phổ thông
        }

    }
}
