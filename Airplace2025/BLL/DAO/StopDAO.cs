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
    public class StopDAO
    {
        private static StopDAO instance;
        public static StopDAO Instance
        {
            get { if (instance == null) instance = new StopDAO(); return instance; }
            private set => instance = value;
        }
        public StopDAO() { }

        public void InsertStop(string MaChuyenBay, string MaSanBay, int ThuTu, int ThoiGianDung,
            string GhiChu, int ThoiGianChuyen)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_ThemChanBay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaChuyenBay", MaChuyenBay);
                cmd.Parameters.AddWithValue("@MaSanBay", MaSanBay);
                cmd.Parameters.AddWithValue("@ThuTu", ThuTu);
                cmd.Parameters.AddWithValue("@ThoiGianDung", ThoiGianDung);
                cmd.Parameters.AddWithValue("@GhiChu", GhiChu);
                cmd.Parameters.AddWithValue("@ThoiGianChuyen", ThoiGianChuyen);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm chặn bay thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm chặn bay thất bại, vui lòng kiểm tra lại dữ liệu.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi thêm chặn bay: {ex.Message}");
                }
            }
        }

        public DataTable GetStopsByFlight(string MaChuyenBay)
        {
            string sql = "SELECT * FROM TrungGian s JOIN SanBay p ON s.MaSanBay = p.MaSanBay" +
                " WHERE MaChuyenBay = @MaChuyenBay ORDER BY ThuTu ASC";
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

    }
}
