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
    public class TicketDAO
    {
        private static TicketDAO instance;
        public static TicketDAO Instance
        {
            get { if (instance == null) instance = new TicketDAO(); return instance; }
            private set => instance = value;
        }
        public TicketDAO() { }

        public DataTable TraCuuDatVe(string MaDatVe, string HoTen)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_TraCuuDatVe", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDatVe", MaDatVe);
                cmd.Parameters.AddWithValue("@HoTen", HoTen);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        

        public DataTable GetTicketList()
        {
            string sql = "SELECT MaHangBay, TenHangBay, MoTa FROM HangBay";
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

        public void InsertTicket(string MaHangBay, string TenHangBay, string MoTa)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_ThemHangBay", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHangBay", MaHangBay);
                cmd.Parameters.AddWithValue("@TenHangBay", TenHangBay);
                cmd.Parameters.AddWithValue("@MoTa", MoTa);

                try
                {
                    con.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm hãng bay thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm hãng bay thất bại, vui lòng kiểm tra lại dữ liệu.");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi thêm hãng bay: {ex.Message}");
                }
            }
        }


    }
}
