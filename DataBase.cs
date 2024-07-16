using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace ZT_InternProject
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=DESKTOP-0570HGU\\MSSQLSERVER01;Initial Catalog=zfu_staj;Integrated Security=True;";

        public SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanı bağlantısı başarısız.", ex);
            }
        }

        public bool ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            conn.Open();
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public object ExecuteScalar(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public bool Insert(string tableName, string columns, string values)
        {
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            return ExecuteNonQuery(query);
        }

        public bool Update(string tableName, string setValues, string condition)
        {
            string query = $"UPDATE {tableName} SET {setValues} WHERE {condition}";
            return ExecuteNonQuery(query);
        }

        public bool Delete(string tableName, string condition)
        {
            string query = $"DELETE FROM {tableName} WHERE {condition}";
            return ExecuteNonQuery(query);
        }

        public List<int> GetReservedDesks()
        {
            List<int> reservedDesks = new List<int>();
            string query = "SELECT masa_no FROM masa_rezervasyon WHERE GETDATE() BETWEEN baslangic_tarihi AND bitis_tarihi";
            using (SqlDataReader dr = ExecuteReader(query, null))
            {
                while (dr.Read())
                {
                    reservedDesks.Add(Convert.ToInt32(dr["masa_no"]));
                }
            }
            return reservedDesks;
        }

        public int GetTotalDeskCount()
        {
            string query = "SELECT COUNT(*) FROM masa";
            return Convert.ToInt32(ExecuteScalar(query));
        }

        public bool ReserveDesk(int deskNo, string username)
        {
            string query = "INSERT INTO masa_rezervasyon (p_username, masa_no, baslangic_tarihi, bitis_tarihi) VALUES (@username, @deskNo, @startDate, @endDate)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@deskNo", deskNo),
                new SqlParameter("@startDate", DateTime.Now),
                new SqlParameter("@endDate", DateTime.Now.AddHours(1)) // Örneğin 1 saatlik rezervasyon
            };
            return ExecuteNonQuery(query, parameters);
        }
    }
}
