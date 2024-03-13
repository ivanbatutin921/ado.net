using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace _1._2_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionSring = ConfigurationManager.ConnectionStrings["PV921_1"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionSring))// устанавливаем соединение через using, и закрываем на выходе.
            {
                connection.Open();
                SqlDataAdapter customerAdapter = new SqlDataAdapter("SELECT * FROM[dbo].[Customers]", connection);
                SqlCommandBuilder customerCmdBilder = new SqlCommandBuilder(customerAdapter); //принимает адаптер на вход.

                DataSet dbDataSet = new DataSet();


                customerAdapter.Fill(dbDataSet, "Customers");// с именем таблицы


                DataTable customers = dbDataSet.Tables["Customers"];
                //добавляем первичный ключ
                customers.PrimaryKey = new DataColumn[] { customers.Columns["id"] };

                DataRow userToDelete = customers.Rows.Find(5);
                if (userToDelete != null)
                {
                    userToDelete.Delete();
                }

                //DataRow newcustomerRow = customers.NewRow();
                //newcustomerRow["FirstName"] = "Ella_1";
                //newcustomerRow["LastName"] = "Chornogor_1";
                //newcustomerRow["DateOfBirth"] = "1980-01-01";
                // customers.Rows.Add(newcustomerRow);
                customerAdapter.Update(dbDataSet, "Customers");

                customers.Clear();
                customerAdapter.Fill(dbDataSet, "Customers");


                foreach (DataRow customerRow in customers.Rows)
                {
                    var customerID = customerRow["id"];
                    var customerName = customerRow["FirstName"] + " " + customerRow["LastName"];
                    var birthDate = customerRow["DateOfBirth"];
                    Console.WriteLine($"{customerID}  {customerName} \t {birthDate}");
                }

            }
            Console.ReadKey();
        }
    
    }
}
