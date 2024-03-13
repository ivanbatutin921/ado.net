using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3 SqlCommand Builder
            string connectionstring = ConfigurationManager.ConnectionStrings["Client_add"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                DataTable
            }




        }
    }
}
