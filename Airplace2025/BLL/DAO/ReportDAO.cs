using Airplace2025.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplace2025.BLL.DAO
{

    public class ReportDAO
        {
            private static ReportDAO instance;
            public static ReportDAO Instance
            {
                get { if (instance == null) instance = new ReportDAO(); return instance; }
                private set { instance = value; }
            }
            private ReportDAO() { }

            public DataTable GetMonthlySalesReport(DateTime DateStart, DateTime DateEnd)
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_BaoCaoDoanhThu_CSV", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DateStart", DateStart);
                    cmd.Parameters.AddWithValue("@DateEnd", DateEnd);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                return dt;
        }
        }

}
