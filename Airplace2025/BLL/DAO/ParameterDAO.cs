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

        public bool UpdateParameter(
            int maxTransitCount,
            string minFlightTime,
            string minTransitDuration,
            string maxTransitDuration,
            int latestBookingDays,
            int latestCancelDays)
        {
            string query = @"
                UPDATE dbo.ThamSo 
                SET 
                    SoSanBayTrungGianToiDa = @MaxTransitCount, 
                    ThoiGianBayToiThieu = @MinFlightTime, 
                    ThoiGianDungToiThieu = @MinTransitDuration, 
                    ThoiGianDungToiDa = @MaxTransitDuration,
                    ThoiGianDatVeChamNhat = @LatestBookingDays,
                    ThoiGianHuyChamNhat = @LatestCancelDays
                WHERE ID = 1"; // Giả sử hàng tham số duy nhất có ID = 1

            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);

                // Thêm các tham số (Parameters) để tránh SQL Injection
                cmd.Parameters.AddWithValue("@MaxTransitCount", maxTransitCount);
                cmd.Parameters.AddWithValue("@MinFlightTime", minFlightTime);
                cmd.Parameters.AddWithValue("@MinTransitDuration", minTransitDuration);
                cmd.Parameters.AddWithValue("@MaxTransitDuration", maxTransitDuration);
                cmd.Parameters.AddWithValue("@LatestBookingDays", latestBookingDays);
                cmd.Parameters.AddWithValue("@LatestCancelDays", latestCancelDays);

                try
                {
                    con.Open();
                    // ExecuteNonQuery trả về số dòng bị ảnh hưởng
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi tại đây (tùy chọn)
                    Console.WriteLine("Lỗi UpdateParameter: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
