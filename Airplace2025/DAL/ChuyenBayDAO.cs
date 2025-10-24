using Airplace2025.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Airplace2025.DAL
{
    /// <summary>
    /// Data Access Layer cho ChuyenBay
    /// </summary>
    public class ChuyenBayDAO
    {
        private static ChuyenBayDAO _instance;
        public static ChuyenBayDAO Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ChuyenBayDAO();
                return _instance;
            }
        }

        private ChuyenBayDAO() { }

        /// <summary>
        /// Tìm kiếm chuyến bay theo các tiêu chí
        /// </summary>
        public List<ChuyenBayDTO> SearchFlights(SearchFlightParams searchParams)
        {
            List<ChuyenBayDTO> flights = new List<ChuyenBayDTO>();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_TimKiemChuyenBay", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@MaSanBayDi", searchParams.MaSanBayDi ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaSanBayDen", searchParams.MaSanBayDen ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@NgayDi", searchParams.NgayDi);
                        cmd.Parameters.AddWithValue("@SoHanhKhach", 
                            searchParams.SoNguoiLon + searchParams.SoTreEm + searchParams.SoEmBe);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChuyenBayDTO flight = new ChuyenBayDTO
                                {
                                    MaChuyenBay = reader["MaChuyenBay"].ToString(),
                                    MaSanBayDi = reader["MaSanBayDi"].ToString(),
                                    MaSanBayDen = reader["MaSanBayDen"].ToString(),
                                    TenSanBayDi = reader["TenSanBayDi"].ToString(),
                                    TenSanBayDen = reader["TenSanBayDen"].ToString(),
                                    NgayGioBay = Convert.ToDateTime(reader["NgayGioBay"]),
                                    TrangThai = reader["TrangThai"].ToString(),
                                    TenHangBay = reader["TenHangBay"].ToString(),
                                    SoGheTrong = reader["SoGheTrong"] != DBNull.Value 
                                        ? Convert.ToInt32(reader["SoGheTrong"]) : 0,
                                    GiaCoBan = reader["GiaCoBan"] != DBNull.Value 
                                        ? Convert.ToDecimal(reader["GiaCoBan"]) : 0
                                };

                                // Tính thời gian bay (giả sử có cột ThoiGianBay hoặc tính từ NgayGioDen)
                                if (reader["NgayGioDen"] != DBNull.Value)
                                {
                                    flight.NgayGioDen = Convert.ToDateTime(reader["NgayGioDen"]);
                                    flight.ThoiGianBay = (int)(flight.NgayGioDen - flight.NgayGioBay).TotalMinutes;
                                }

                                flights.Add(flight);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tìm kiếm chuyến bay: {ex.Message}", ex);
            }

            return flights;
        }

        /// <summary>
        /// Lấy chi tiết hạng vé của chuyến bay
        /// </summary>
        public Dictionary<string, ChiTietHangVe> GetHangVeInfo(string maChuyenBay)
        {
            Dictionary<string, ChiTietHangVe> hangVeInfo = new Dictionary<string, ChiTietHangVe>();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string query = @"
                        SELECT 
                            HV.TenHangVe,
                            CTHV.Gia,
                            CTHV.SoLuongConLai,
                            CTHV.SoLuong
                        FROM ChiTietHangVe CTHV
                        INNER JOIN HangVe HV ON CTHV.MaHangVe = HV.MaHangVe
                        WHERE CTHV.MaChuyenBay = @MaChuyenBay";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaChuyenBay", maChuyenBay);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tenHangVe = reader["TenHangVe"].ToString();
                                ChiTietHangVe chiTiet = new ChiTietHangVe
                                {
                                    TenHangVe = tenHangVe,
                                    Gia = Convert.ToDecimal(reader["Gia"]),
                                    SoLuongConLai = Convert.ToInt32(reader["SoLuongConLai"]),
                                    SoLuong = Convert.ToInt32(reader["SoLuong"])
                                };

                                hangVeInfo[tenHangVe] = chiTiet;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin hạng vé: {ex.Message}", ex);
            }

            return hangVeInfo;
        }

        /// <summary>
        /// Lấy danh sách sân bay
        /// </summary>
        public DataTable GetAirports()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    string query = "SELECT MaSanBay, TenSanBay FROM SanBay ORDER BY TenSanBay";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
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
                throw new Exception($"Lỗi lấy danh sách sân bay: {ex.Message}", ex);
            }

            return dt;
        }

        /// <summary>
        /// Lấy danh sách hạng vé từ database
        /// </summary>
        public List<HangVeDTO> GetServiceClasses()
        {
            List<HangVeDTO> hangVeList = new List<HangVeDTO>();

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_LayDanhSachHangVe", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HangVeDTO hangVe = new HangVeDTO
                                {
                                    MaHangVe = reader["MaHangVe"].ToString(),
                                    TenHangVe = reader["TenHangVe"].ToString(),
                                    TiLeGiaHangVe = reader["TiLeGiaHangVe"] != DBNull.Value 
                                        ? Convert.ToDecimal(reader["TiLeGiaHangVe"]) : 1.0m
                                };

                                hangVeList.Add(hangVe);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách hạng vé: {ex.Message}", ex);
            }

            return hangVeList;
        }
    }

    /// <summary>
    /// Class hỗ trợ lưu thông tin chi tiết hạng vé
    /// </summary>
    public class ChiTietHangVe
    {
        public string TenHangVe { get; set; }
        public decimal Gia { get; set; }
        public int SoLuongConLai { get; set; }
        public int SoLuong { get; set; }
    }
}



