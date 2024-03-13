using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace _2_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["Client_add"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {                
                    using (SqlCommand command = new SqlCommand("sp_ClentDelete", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@clientId", 191);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                

            }

        }
    }
}
