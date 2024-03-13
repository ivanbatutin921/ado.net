using System;
using System.Data.SqlClient;
using System.Configuration;

/*
 1.Connection
 2.Query
 3. ExecuteScalar результат функции агрегации
 */

namespace _1_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["Client_add"].ConnectionString;
            using(SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
            }

            //string sqlcommand = "stp_TeacherById";
            //SqlCommand cmd = new SqlCommand(sqlcommand, conn);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            ////SqlParameter ClientID = cmd.Parameters.Add(new SqlParameter("@ClientID", System.Data.SqlDbType.Int)));
            ////ClientID.Value = 9;

            ////1 хранимая процедура stp
            //cmd.Parameters.AddWithValue("@ClientID", 9);
            //SqlDataReader dr = cmd.ExecuteReader();

            //while (dr.Read())
            //{
            //    var feild1 = dr[0];
            //    var feild2 = dr[1];
            //    var feild3 = dr[2];
            //        Console.WriteLine($"{feild1,5} {feild2,15} {feild3,50}");
            //}
            //dr.Close();
            ////2.1 insert client
            //string sqlcommand = "sp_Clientadd";
            //SqlCommand cmd = new SqlCommand(sqlcommand, conn);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@FullName", "Батутин Иван");
            //cmd.Parameters.AddWithValue("@Email", "Батутин Иван");
            //cmd.Parameters.AddWithValue("@Birthdate", DateTime.Now.ToShortDateString());
            //cmd.Parameters.AddWithValue("@ID_Ivents", 15);
            //cmd.Parameters.AddWithValue("@ID_Ticket", 15);

            //SqlParameter ClientID = cmd.Parameters.Add("@ClientID", System.Data.SqlDbType.Int);
            //ClientID.Direction = System.Data.ParameterDirection.Output;
            //cmd.ExecuteNonQuery();
            //int newTeacher = (int)ClientID.Value;
            //Console.WriteLine($"добавлен новый предподаватель. ID: {newTeacher}");

            ////2.2 insert client Output
            //string sqlcommand = "sp_Clientadd_2";
            //SqlCommand cmd = new SqlCommand(sqlcommand, conn);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@FullName", "Батутин Иван");
            //cmd.Parameters.AddWithValue("@Email", "Батутин Иван");
            //cmd.Parameters.AddWithValue("@Birthdate", DateTime.Now.ToShortDateString());
            //cmd.Parameters.AddWithValue("@ID_Ivents", 15);
            //cmd.Parameters.AddWithValue("@ID_Ticket", 15);

            //SqlParameter ClientID = cmd.Parameters.Add("@ClientID", System.Data.SqlDbType.Int);
            //ClientID.Direction = System.Data.ParameterDirection.ReturnValue;
            //cmd.ExecuteNonQuery();
            //int newTeacher = (int)ClientID.Value;
            //Console.WriteLine($"добавлен новый предподаватель. ID: {newTeacher}");


            ////2.2 insert client return
            //string sqlcommand = "sp_Clientadd_2";
            //SqlCommand cmd = new SqlCommand(sqlcommand, conn);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@FullName", "Батутин Иван");
            //cmd.Parameters.AddWithValue("@Email", "Батутин Иван");
            //cmd.Parameters.AddWithValue("@Birthdate", DateTime.Now.ToShortDateString());
            //cmd.Parameters.AddWithValue("@ID_Ivents", 15);
            //cmd.Parameters.AddWithValue("@ID_Ticket", 15);

            //SqlParameter ClientID = cmd.Parameters.Add("@ClientID", System.Data.SqlDbType.Int);
            //ClientID.Direction = System.Data.ParameterDirection.ReturnValue;
            //cmd.ExecuteNonQuery();
            //int newTeacher = (int)cmd.Parameters["ClientID"].Value;
            //Console.WriteLine($"добавлен новый предподаватель. ID: {newTeacher}");





        }
    }
}
