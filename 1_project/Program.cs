using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


/*
 1.Connection
 2.Query
 3.
 */

namespace _1_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionstring = "Server = DESKTOP-OMH847S; Database = P_11_Company; Trusted_Connection = True";
            //  1
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = connectionstring;

            //  2
            ////////Conect////////
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();

            ////////Query////////
            #region Select Customers
            //1-table
            //string sql = "select* from Customers";
            //SqlCommand cmd = new SqlCommand(sql, conn);
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    var feild1 = reader[0];
            //    var feild2 = reader[1];
            //    var feild3 = reader[2];
            //    Console.WriteLine($"{feild1,5} {feild2,15} {feild3,50}");

            //}
            //Console.ReadKey();
            #endregion

            //2 - скалярное значение
            //SqlCommand all_salary = new SqlCommand("select sum(Salary) as allSalar from Employee",conn);
            //object rez=all_salary.ExecuteScalar();
            //Console.WriteLine(rez);
            //Console.ReadKey();


            //3 - удаление(delete)
            SqlCommand delete_customer = new SqlCommand("delete from Customers where id=1", conn);
            int num = delete_customer.ExecuteNonQuery();
            Console.WriteLine(num);
            Console.ReadKey();

            conn.Close();                        
        }
    }
}
