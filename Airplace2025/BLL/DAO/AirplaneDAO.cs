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
    }
}
