using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace _3._1_project
{
    public partial class Form1 : Form
    {
        SqlDataReader reader;
        DataTable table;
        SqlConnection conn;
        string str_select = "";
        public Form1()
        {
            InitializeComponent();
            string connectionstring = ConfigurationManager.ConnectionStrings["Client_add"].ConnectionString;
            conn = new SqlConnection(connectionstring);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "SELECT [ID],[FullName],[Email],[Birthdate] FROM [dbo].[Clients]";
                comm.Connection = conn;
                dataGridView1.DataSource = null;
                conn.Open();
                table = new DataTable();
                reader= comm.ExecuteReader();
                int line = 0;
                do// row
                {
                    while (reader.Read())
                    {
                        if(line == 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.GetName(i));
                            }
                            line++;
                        }

                        DataRow row = table.NewRow();
                        for (int i = 0;i<reader.FieldCount; i++)
                        {
                            row[i] = reader.GetName(i);
                        }
                        table.Rows.Add(row);
                    }

                } while (reader.NextResult());
                dataGridView1.DataSource= table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally 
            {
                if (conn != null) conn.Close(); 
                if(reader != null) reader.Close();
            }
        }
    }
}
