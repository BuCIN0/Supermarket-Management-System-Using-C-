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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace supermarket_mene
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String vconn = "Data Source=LAPTOP-S8ODA9JU\\SQLEXPRESS01;Initial Catalog=SUPERMARKET3;Integrated Security=True";
        public static string SellerName = "";  
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            UnameTb.Text = string.Empty;
            PassTb.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (UnameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Please input the data");
                } else
                {
                    if (RoleCb.SelectedIndex > -1)
                    {
                        if (RoleCb.SelectedItem.ToString() == "ADMIN")
                        {
                            if (UnameTb.Text == "Admin" && PassTb.Text == "Admin")
                            {
                                utama u = new utama();
                                u.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("please input correct username and password");
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Your in the Seller Section");
                            SqlConnection conn = new SqlConnection(vconn);
                            conn.Open();
                            String query = "Select count(8) from SellerTbl where " +
                                "SellerName = @SellerName AND sellerPass = @SellerPass";
                            SqlCommand rd = new SqlCommand(query, conn);
                            rd.Parameters.AddWithValue("@SellerName", UnameTb.Text);
                            rd.Parameters.AddWithValue("@SellerPass", PassTb.Text);

                            try
                            {
                                rd.ExecuteNonQuery();
                            }
                            catch
                            {

                            }
                            finally
                            {
                                var dt = new DataTable("SellerTbl");
                                var name = new SqlDataAdapter(rd);

                                name.Fill(dt);
                                if (dt.Rows[0][0].ToString() == "1")
                                {
                                    SellerName = UnameTb.Text;
                                    SellingForm sf = new SellingForm();
                                    sf.Show();
                                    this.Hide();
                                    conn.Close();
                                }else
                                {
                                    MessageBox.Show("Please input the correct username or password");
                                }
                            
                                //PRODGV1.DataSource = dt;
                            
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a role");
                    }
                }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PassTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.DarkGray;

        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {

            pictureBox3.BackColor = Color.DarkGray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Empty;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Empty;
        }
    }
}
