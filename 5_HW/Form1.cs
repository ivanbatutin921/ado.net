using _5_HW.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _5_HW.Data.ClassDataLayer;

namespace _5_HW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Controls.RemoveAt(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerModel cl = Customer.ById(Convert.ToInt32(numericUpDown1.Value));
            MessageBox.Show(cl.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["Company_add"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlDataAdapter teacherAdapter = new SqlDataAdapter("select * from [dbo].[Customers]", conn);
                DataSet db = new DataSet();
                teacherAdapter.Fill(db, "Customers");
                DataTable teachers = db.Tables["Customers"];

                dataGridView1.DataSource = teachers; // Привязка данных к DataGridView

                // Необходимо скрыть столбцы, которые не нужны для отображения, или поменять их названия
                //dataGridView1.Columns["Id"].Visible = false; // Пример скрытия столбца по названию
                //dataGridView1.Columns["Name_"].HeaderText = "Name"; // Пример изменения названия столбца
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Customer.DeleteById(Convert.ToInt32(numericUpDown1.Value)))
                MessageBox.Show($"Customer с id {numericUpDown1.Value} удален ");

            
        }
    }
}
