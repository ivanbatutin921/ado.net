using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Asinc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 

        async private Task GetTaskAsync(string filename)
        {
            byte[] data = null;
            using(FileStream fs = File.Open(filename,FileMode.Open))
            {
                data = new byte[fs.Length];
                await fs.ReadAsync(data, 0,(int)fs.Length);
                //textBox1.Text = data.ToString();
                textBox1.Text = System.Text.Encoding.UTF8.GetString(data);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Before asinc");
            await GetTaskAsync("tmp.txt");
            MessageBox.Show("After asinc");


        }
    }
}
