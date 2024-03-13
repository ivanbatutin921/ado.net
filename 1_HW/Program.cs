using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {         
            const string connectionstring = "Server = DESKTOP-OMH847S; Database = Event_Poster; Trusted_Connection = True";
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();

            //1 - INSERT
            //SqlCommand insert_clients = new SqlCommand("insert into Clients(FullName,Email,Birthdate,ID_Ivents,ID_Ticket) values('SarahSarah Davis','sarahdavis@gmail.com','1998-02-25',4,4)", conn);
            //int num = insert_clients.ExecuteNonQuery();


            //2 - DELETE
            //SqlCommand delete_clients = new SqlCommand("delete from Clients where id=184", conn);
            //int num = delete_clients.ExecuteNonQuery();

            //3 - UPDATE
            //SqlCommand update_clients = new SqlCommand("update Clients set FullName = 'New Name' where ID=18", conn);
            //int num = update_clients.ExecuteNonQuery();



            conn.Close();
        }
    }
}
