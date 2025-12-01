using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplace2025.DAL
{
    class DBConnection
    {
        private static string connectionString = "Data Source=(local);Initial Catalog=QuanLyBanVeMayBay;Integrated Security=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        private static DBConnection instance;

        public DBConnection()
        {

        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            return data;
        }

        public static string GetSqlServerName()
        {
            string query = "SELECT @@SERVERNAME;";
            string serverName = null;

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to open connection: {ex.Message}");
                        return null;
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            serverName = result.ToString();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL error while retrieving server name: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Invalid operation: {ex.Message}");
            }

            return serverName;
        }


        public static DBConnection Instance
        {
            get { if (instance == null) instance = new DBConnection(); return instance; }
            private set => instance = value;
        }
        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
    }
}


