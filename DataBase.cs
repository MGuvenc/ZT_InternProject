using System.Data.SqlClient;

namespace ZT_InternProject
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=DESKTOP-0570HGU\\MSSQLSERVER01;Initial Catalog=zfu_staj;Integrated Security=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
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
    }
}
