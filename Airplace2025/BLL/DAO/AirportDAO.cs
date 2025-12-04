using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airplace2025.DAL;

namespace Airplace2025.BLL.DAO
{
    public class AirportDAO
    {
        private static AirportDAO instance;
        public static AirportDAO Instance
        {
            get { if (instance == null) instance = new AirportDAO(); return instance; }
            private set => instance = value;
        }
        public AirportDAO() { }

        public DataTable GetAirportList()
        {
            string sql = "SELECT MaSanBay, TenSanBay FROM SanBay";
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


        public string GetCountryByAirportCode(string maSanBay)
        {
            string sql = "SELECT QuocGia FROM SanBay WHERE MaSanBay = @MaSanBay";
            DataTable dt = new DataTable();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaSanBay", maSanBay);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            object result = dt.Rows[0];
            return result != null ? result.ToString() : "Việt Nam"; // Mặc định VN nếu lỗi
        }
    }
}
