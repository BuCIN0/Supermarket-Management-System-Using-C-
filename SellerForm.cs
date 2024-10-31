using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket_mene
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }
        String vconn = "Data Source=LAPTOP-S8ODA9JU\\SQLEXPRESS01;Initial Catalog=SUPERMARKET3;Integrated Security=True";

        private void showdata()
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "select Sellerid, SellerName, SellerAge, SellerPhone," +
                " SellerPass from SellerTbl";
            SqlCommand show = new SqlCommand(query, conn);

            var dt = new DataTable("SellerTbl");
            var name = new SqlDataAdapter(show);

            name.Fill(dt);
            SellerDGV.DataSource = dt;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Sname.Text == "" || Sage.Text == "" || Sphone.Text == "" || Spass.Text == "")
            {
                MessageBox.Show("Please input the data");
            }
            else
            {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "insert into SellerTbl(SellerName, SellerAge, SellerPhone, SellerPass) " +
                    "values (@SellerName, @SellerAge, @SellerPhone, @SellerPass)";
                SqlCommand add = new SqlCommand(query, conn);

                add.Parameters.AddWithValue("@SellerName", Sname.Text);
                add.Parameters.AddWithValue("@SellerAge", int.Parse(Sage.Text));
                add.Parameters.AddWithValue("@SellerPhone",Sphone.Text);
                add.Parameters.AddWithValue("@SellerPass", Spass.Text);


                try
                {
                    conn.Open();
                    add.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dimasukan");
                }
                catch
                {
                    MessageBox.Show("terjadi kesalahan input data");
                }
                finally
                {
                    conn.Close();
                    showdata();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Sid.Text = SellerDGV.Rows[e.RowIndex].Cells["Sellerid"].Value.ToString();
            Sname.Text = SellerDGV.Rows[e.RowIndex].Cells["SellerName"].Value.ToString();
            Sage.Text = SellerDGV.Rows[e.RowIndex].Cells["SellerAge"].Value.ToString();
            Sphone.Text = SellerDGV.Rows[e.RowIndex].Cells["SellerPhone"].Value.ToString();
            Spass.Text = SellerDGV.Rows[e.RowIndex].Cells["SellerPass"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CATEGORYFORM  cat = new CATEGORYFORM();
            cat.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductForm pd = new ProductForm();
            pd.Show();
            this.Hide();
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            if (Sid.Text == "" || Sname.Text == "" || Sage.Text == "" || Sphone.Text == "" || Spass.Text == "")
            {
                MessageBox.Show("Please select the data you want to update");
            }
            else
            {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "update SellerTbl set SellerName = @SellerName, " +
                    "SellerAge = @SellerAge, SellerPhone = @SellerPhone, SellerPass = @SellerPass WHERE Sellerid = @Sellerid";
                SqlCommand update = new SqlCommand(query, conn);
                update.Parameters.AddWithValue("@Sellerid", int.Parse(Sid.Text));
                update.Parameters.AddWithValue("@SellerName", Sname.Text);
                update.Parameters.AddWithValue("@SellerAge", int.Parse(Sage.Text));
                update.Parameters.AddWithValue("@SellerPhone", Sphone.Text);
                update.Parameters.AddWithValue("@SellerPass", Spass.Text);


                try
                {
                    conn.Open();
                    update.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil Update");
                }
                catch
                {
                    MessageBox.Show("System Error");
                }
                finally
                {
                    conn.Close();
                    showdata();
                }
            }
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            showdata(); 
        }
        

        private void button7_Click(object sender, EventArgs e)
        {
            if (Sid.Text == "")
            {
                MessageBox.Show("Please select the data you want to delete");
            }
            else
            {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "delete SellerTbl where Sellerid = @Sellerid";
                SqlCommand delete = new SqlCommand(query, conn);
                delete.Parameters.AddWithValue("@Sellerid", int.Parse(Sid.Text));

                try
                {
                    conn.Open();
                    delete.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dihapus");
                }
                catch
                {
                    MessageBox.Show("System Error");
                }
                finally
                {
                    conn.Close();
                    showdata();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellingForm sf = new SellingForm();
            sf.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
