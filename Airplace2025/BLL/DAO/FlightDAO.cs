using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Airplace2025.BLL;
using Airplace2025.DAL;

namespace Airplace2025.BLL.DAO
{
    public class FlightDAO
    {
        private static FlightDAO instance;
        public static FlightDAO Instance
        {
            get { if (instance == null) instance = new FlightDAO(); return instance; }
            private set => instance = value;
        }
        public FlightDAO() { }

        public void UpdateFlightSchedule(string MaChuyenBay, DateTime NgayGioBay, string TrangThai)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_CapNhatLichBay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaChuyenBay", MaChuyenBay);
                cmd.Parameters.AddWithValue("@NgayGioBayMoi", NgayGioBay);
                cmd.Parameters.AddWithValue("@TrangThaiMoi", TrangThai);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật chuyến bay thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chuyến bay thất bại, vui lòng kiểm tra lại dữ liệu.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi cập nhật: {ex.Message}");
                }
            }
        }

        public DataTable InsertFlight(string MaSanBayDi, string MaSanBayDen, DateTime NgayGioBay, int ThoiGianBay,
           decimal GiaCoBan, string MaMayBay, string TrangThai)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_ThemChuyenBay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaSanBayDi", MaSanBayDi);
                cmd.Parameters.AddWithValue("@MaSanBayDen", MaSanBayDen);
                cmd.Parameters.AddWithValue("@NgayGioBay", NgayGioBay);
                cmd.Parameters.AddWithValue("@ThoiGianBay", ThoiGianBay);
                cmd.Parameters.AddWithValue("@GiaCoBan", GiaCoBan);
                cmd.Parameters.AddWithValue("@MaMayBay", MaMayBay);
                cmd.Parameters.AddWithValue("@TrangThai", TrangThai);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable SearchFlightByInfo(string info)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_SearchFlightByInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@string", info);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetFlightList(string TrangThai)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_LayDanhSachChuyenBay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrangThai", TrangThai);


                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public FlightResult GetFlightDetail(string maChuyenBay)
        {
            var result = new FlightResult();
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_LayChiTietChuyenBay", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaChuyenBay", maChuyenBay);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Đọc bảng 1: thông tin chính
                    if (reader.HasRows)
                    {
                        reader.Read();
                        result.ThongTin = new FlightDetail
                        {
                            MaChuyenBay = reader["MaChuyenBay"].ToString(),
                            MaSanBayDi = reader["MaSanBayDi"].ToString(),
                            TenSanBayDi = reader["TenSanBayDi"].ToString(),
                            MaSanBayDen = reader["MaSanBayDen"].ToString(),
                            TenSanBayDen = reader["TenSanBayDen"].ToString(),
                            NgayGioBay = Convert.ToDateTime(reader["NgayGioBay"]),
                            NgayGioDen = Convert.ToDateTime(reader["NgayGioDen"]),
                            ThoiGianBay = Convert.ToInt32(reader["ThoiGianBay"]),
                            TongThoiGianDung = Convert.ToInt32(reader["TongThoiGianDung"]),
                            TongThoiGianHanhTrinh = Convert.ToInt32(reader["TongThoiGianHanhTrinh"]),
                            SoDiemDung = Convert.ToInt32(reader["SoDiemDung"]),
                            TenMayBay = reader["TenMayBay"].ToString(),
                            TenHangBay = reader["TenHangBay"].ToString(),
                            Logo = FlightDetail.ConvertByteArraytoImage(reader["Logo"])
                        };
                    }

                    // Đọc bảng 2: Danh sách trung gian
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            result.dsTrungGian.Add(new TrungGianChiTiet
                            {
                                TenHangBay = reader["TenHangBay"].ToString(),
                                ThuTu = Convert.ToInt32(reader["ThuTu"]),
                                MaSanBay = reader["MaSanBay"].ToString(),
                                TenSanBay = reader["TenSanBay"].ToString(),
                                ThoiGianDung = Convert.ToInt32(reader["ThoiGianDung"]),
                                GhiChu = reader["GhiChu"].ToString(),
                                Logo = FlightDetail.ConvertByteArraytoImage(reader["Logo"]),
                                ThoiGianChuyen = Convert.ToInt32(reader["ThoiGianChuyen"])
                            });
                        }
                    }
                }
            }

            return result;

        }
    }
}
