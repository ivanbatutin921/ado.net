using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _3._2_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["Academy"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlDataAdapter teacherAdapter = new SqlDataAdapter("select * from [dbo].[Teachers]",conn);

                DataSet db = new DataSet();
                teacherAdapter.Fill(db,"Teachers");
                DataTable teashers = db.Tables["Teachers"];
                foreach (DataRow item in teashers.Rows)
                {
                    var teacherId = item["Id"];
                    var teacherName = item["Name_"] + " " + item["Surname"];
                    var teachersalary = item["Salary"];
                    Console.WriteLine($"{teacherId} {teacherName} {teachersalary}");

                }
            }
            Console.ReadKey();



        }
    }
}
