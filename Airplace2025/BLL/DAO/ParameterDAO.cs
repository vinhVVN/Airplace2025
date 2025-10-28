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
    public class ParameterDAO
    {
        private static ParameterDAO instance;
        public static ParameterDAO Instance
        {
            get { if (instance == null) instance = new ParameterDAO(); return instance; }
            private set => instance = value;
        }
        public ParameterDAO() { }

        public DataTable GetParameter()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM ThamSo";
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
