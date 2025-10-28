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

    }
}
