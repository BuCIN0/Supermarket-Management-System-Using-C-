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
using System.Security.Cryptography.X509Certificates;

namespace supermarket_mene
{
    public partial class CATEGORYFORM : Form
    {
        public CATEGORYFORM()
        {
            InitializeComponent();
        }
        String vconn = "Data Source=LAPTOP-S8ODA9JU\\SQLEXPRESS01;Initial Catalog=SUPERMARKET3;Integrated Security=True";

        private void showdata()
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "select Catd, CatName, CatDesc from CategoryTbl";
            SqlCommand show = new SqlCommand(query, conn);

            var dt = new DataTable("CategoryTbl");
            var name = new SqlDataAdapter(show);

            name.Fill(dt);
            CatDGV.DataSource = dt;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (CatNameTb.Text == "" || CatDescTb.Text == "")
            {
                MessageBox.Show("Please input the data");
            }
            else
            {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "insert into CategoryTbl(CatName, CatDesc) values (@CatName, @CatDesc)";
                SqlCommand add = new SqlCommand(query, conn);

                add.Parameters.AddWithValue("@CatName", CatNameTb.Text);
                add.Parameters.AddWithValue("@CatDesc", CatDescTb.Text);


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
        private void CATEGORYFORM_Load(object sender, EventArgs e)
        {
           showdata();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void CatDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CatIdTb.Text = CatDGV.Rows[e.RowIndex].Cells["Catd"].Value.ToString();
            CatNameTb.Text = CatDGV.Rows[e.RowIndex].Cells["CatName"].Value.ToString();
            CatDescTb.Text = CatDGV.Rows[e.RowIndex].Cells["CatDesc"].Value.ToString();
        }

            private void button6_Click(object sender, EventArgs e)
            {
                if (CatIdTb.Text == "" || CatNameTb.Text == "" || CatDescTb.Text == "")
                {
                    MessageBox.Show("Please select the data you want to update");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(vconn);
                    String query = "update CategoryTbl set CatName = @CatName, CatDesc = @CatDesc WHERE Catd = @Catd";
                    SqlCommand update = new SqlCommand(query, conn);
                    update.Parameters.AddWithValue("@Catd", int.Parse(CatIdTb.Text));
                    update.Parameters.AddWithValue("@CatName", CatNameTb.Text);
                    update.Parameters.AddWithValue("@CatDesc", CatDescTb.Text);

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

        private void button7_Click(object sender, EventArgs e)
        {
            if (CatIdTb.Text == "")
            {
                MessageBox.Show("Please select the data you want to delete");
            }
            else
            {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "delete CategoryTbl where Catd = @Catd";
                SqlCommand delete = new SqlCommand(query, conn);
                delete.Parameters.AddWithValue("@Catd", int.Parse(CatIdTb.Text));
                
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

        private void button8_Click(object sender, EventArgs e)
        {
            CatIdTb.Text = string.Empty;
            CatNameTb.Text = string.Empty;
            CatDescTb.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm p = new ProductForm();
            p.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellerForm sf = new SellerForm();
            sf.Show();
            this.Hide();
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

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            
        }
    }
}
