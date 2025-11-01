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
    public class AirplaneDAO
    {
        private static AirplaneDAO instance;
        public static AirplaneDAO Instance
        {
            get { if (instance == null) instance = new AirplaneDAO(); return instance; }
            private set => instance = value;
        }
        public AirplaneDAO() { }

        public DataTable GetAirplaneByAirline(string MaHangBay)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_SearchAirplaneByAirline", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHangBay", MaHangBay);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetAirplanes_Airline(string TenHangBay)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_LayDanhSachMayBayTheoHangBay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenHangBay", TenHangBay);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


        public bool UpdateAirplaneAndAirline(string MaMayBay, string TenMayBayMoi, int SoGheMoi, string MaHangBayMoi,
            string TenHangBayMoi, string MoTaMoi, byte[] LogoMoi)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_CapNhatMayBayVaHangBay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaMayBay", MaMayBay);
                cmd.Parameters.AddWithValue("@TenMayBayMoi", TenMayBayMoi);
                cmd.Parameters.AddWithValue("@SoGheMoi", SoGheMoi);
                cmd.Parameters.AddWithValue("@MaHangBayMoi", MaHangBayMoi);
                cmd.Parameters.AddWithValue("@TenHangBayMoi", TenHangBayMoi);
                cmd.Parameters.AddWithValue("@MoTaMoi", MoTaMoi);
                cmd.Parameters.AddWithValue("@LogoMoi", LogoMoi);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật máy bay và hãng bay thất bại, vui lòng kiểm tra lại dữ liệu.");
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi cập nhật: {ex.Message}");
                    return false;
                }
            }
            
        }


        public void DeleteAirplane(string MaMayBay)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteAirplane", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaMayBay", MaMayBay);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xoá máy bay thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xoá máy bay thất bại, vui lòng kiểm tra lại dữ liệu.");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi khi xoá máy bay: {ex.Message}");
                }
            }
        }

    }
}
