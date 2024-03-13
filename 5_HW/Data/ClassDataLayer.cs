using _5_HW.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace _5_HW.Data
{
    internal class ClassDataLayer
    {
        public static string ConnectionString { get; private set; } = ConfigurationManager.ConnectionStrings["Company_add"].ConnectionString;

        public static class Customer
        {
            public static CustomerModel ById(int customerID)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("stp_CustomerByID", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    CustomerModel customer = null;
                    while (reader.Read())
                    {
                        int ID = (int)reader[0];
                        string FirstName = (string)reader[1];
                        string LastName = (string)reader[2];
                        DateTime bd = DateTime.Parse(reader[3].ToString());
                        customer = new CustomerModel(ID, FirstName, LastName, bd);
                    }
                    reader.Close();
                    return customer;
                }
            }

            public static List<CustomerModel> All()
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand AllCustomer = new SqlCommand("stp_CustomerALL", conn);
                    AllCustomer.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = AllCustomer.ExecuteReader();
                    List<CustomerModel> customers = new List<CustomerModel>();
                    while (reader.Read())
                    {
                        customers.Add(new CustomerModel((int)reader[0], reader[1].ToString(), reader[2].ToString(), DateTime.Parse(reader[3].ToString())));
                    }
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer);
                    }
                }
                return new List<CustomerModel>();
            }

            public static bool DeleteById(int index)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("stp_CustomerDelete", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", index);
                    command.Parameters.Add("@Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    return true;

                }
            }

            public static int Insert(CustomerModel customer)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("stp_CustomerAdd", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirthdate.ToShortTimeString());

                    command.Parameters.Add("@CustomerID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.ExecuteReader();

                    int customerId = Convert.ToInt32(command.Parameters["@CustomerID"].Value);
                    return customerId;

                }
            }

        }
    }
}
