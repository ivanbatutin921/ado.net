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
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Imaging;

namespace _3_project_picture
{
    
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter adapter = null;
        DataSet DataSet = null;
        string filename = "";
        string conn_string = ConfigurationManager.ConnectionStrings["Book_picture"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(conn_string);
        }

        private void bt_loadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Graphics File|*.png; *.bmp; *.jpg; *.gif";
            if(ofd.ShowDialog() == DialogResult.OK )
            {
                filename = ofd.FileName;
                LoadPicture();
            }
        }

        private void LoadPicture()
        {
            try
            {
                byte[] bytes;
                bytes = CreatCopy();
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Pictures(BookId,Name,Picture) values (@BookId,@Name,@Picture)",conn);

                if (tb_id.Text == null || tb_id.Text.Length == 0) return;
                int index = -1;
                int.TryParse(tb_id.Text, out index);
                if (index == -1) return;
                cmd.Parameters.Add("@BookId", SqlDbType.Int).Value=index;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 255).Value = filename;
                cmd.Parameters.Add("@Picture", SqlDbType.Image, bytes.Length).Value = bytes;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                if(conn != null) conn.Close();
            }
        }

        private byte[] CreatCopy()
        {
            Image img = Image.FromFile(filename);
            int maxWidth=300, maxHeight = 300;
            double ratioX=(double)maxWidth / img.Width;
            double ratioY = (double)maxHeight / img.Height;
            double ratio=Math.Min(ratioX, ratioY);

            int newW = (int)(img.Width * ratio);
            int newH = (int)(img.Height * ratio);
            
            Image mi = new Bitmap(newH, newW);
            Graphics g = Graphics.FromImage(mi);
            g.DrawImage(img, 0, 0, newW, newH);
            MemoryStream ms = new MemoryStream();
            mi.Save(ms, ImageFormat.Jpeg);
            ms.Flush();ms.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(ms);
            byte[] bufer=br.ReadBytes((int)ms.Length);

            return bufer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_id.Text == null || tb_id.Text.Length == 0)
                {
                    MessageBox.Show("Укажите id книги");
                    return;
                }
                int index = -1;
                int.TryParse(tb_id.Text, out index);
                if (index == -1)
                {
                    MessageBox.Show("Укажите id книги в правильном формате");
                    return;                
                }
                adapter = new SqlDataAdapter("select Picture from Pictures where BookId=@id", conn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                adapter.SelectCommand.Parameters.Add("@id",SqlDbType.Int).Value = index;
                DataSet = new DataSet();
                adapter.Fill(DataSet);
                byte[] bytes = (byte[])DataSet.Tables[0].Rows[0]["Picture"];
                MemoryStream ms = new MemoryStream(bytes);
                pictureBox1.Image = Image.FromStream(ms);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                adapter = new SqlDataAdapter("selct * from Pictures", conn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                DataSet = new DataSet();
                adapter.Fill(DataSet, "Picture");
                dataGridView1.DataSource = DataSet.Tables["Picture"];
            }
            catch(Exception ex) 
            {
                MessageBox.Show(Text, ex.Message);
            }
        }
        private void tbIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar <=48 || e.KeyChar >=59)&& e.KeyChar!=8)
                e.Handled = true;
        }
    }
}
