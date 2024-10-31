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
using System.Security.Cryptography;

namespace supermarket_mene
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        String vconn = "Data Source=LAPTOP-S8ODA9JU\\SQLEXPRESS01;Initial Catalog=SUPERMARKET3;Integrated Security=True";

        private void showdata()
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "SELECT p.Proid, c.Catd, p.ProName, p.ProQty, p.ProdPrice, p.ProdCat " +
                           "FROM ProductTbl p " +
                           "JOIN CategoryTbl c ON p.ProdCat = c.CatName";

            SqlCommand show = new SqlCommand(query, conn);
            var name = new SqlDataAdapter(show);

            var dt = new DataTable("ProductTbl");
            name.Fill(dt);

            PRODGV.DataSource = dt;
        }

        private void fillcombo()
        {
            //This method will bind the combobox with the database
            SqlConnection conn = new SqlConnection(vconn);
            conn.Open();

            String query = "select CatName from CategoryTbl";
            SqlCommand cm = new SqlCommand(query, conn);
            SqlDataReader rd = cm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rd);
            ProdCb.ValueMember = "CatName";
            ProdCb.DataSource = dt;

            conn.Close();
        }
        private void fillcombo2()
        {
            //This method will bind the combobox with the database
            SqlConnection conn = new SqlConnection(vconn);
            conn.Open();

            String query = "select CatName from CategoryTbl";
            SqlCommand cm = new SqlCommand(query, conn);
            SqlDataReader rd = cm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rd);
            comboBox2.ValueMember = "CatName";
            comboBox2.DataSource = dt;

            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            showdata();
            fillcombo();
            fillcombo2();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CATEGORYFORM ct = new CATEGORYFORM();
            ct.Show();
            this.Hide();
        }
        // Fungsi untuk mendapatkan nilai Catd terakhir
        private int GetLatestCatd()
        {
            int latestCatd = 0;

            using (SqlConnection conn = new SqlConnection(vconn))
            {
                string query = "SELECT MAX(Catd) FROM CategoryTbl";
                SqlCommand command = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        latestCatd = Convert.ToInt32(result);
                    }
                }
                catch
                {

                }
                finally
                {
                    conn.Close();   
                }
            }

            return latestCatd;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (ProdName.Text == "" || ProdQty.Text == "" || ProdPrice.Text == "" || ProdCb.Text == "")
            {
                MessageBox.Show("Please input the data");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(vconn))
                {
                    string query = "INSERT INTO ProductTbl (ProName, ProQty, ProdPrice, ProdCat, Catd) " +
                        "VALUES (@ProName, @ProQty, @ProdPrice, @ProdCat, @Catd)";
                    SqlCommand add = new SqlCommand(query, conn);

                    add.Parameters.AddWithValue("@ProName", ProdName.Text);
                    add.Parameters.AddWithValue("@ProQty", int.Parse(ProdQty.Text));
                    add.Parameters.AddWithValue("@ProdPrice", decimal.Parse(ProdPrice.Text));
                    add.Parameters.AddWithValue("@ProdCat", ProdCb.Text);
                    add.Parameters.AddWithValue("@Catd", GetLatestCatd());

                    try
                    {
                        conn.Open();
                        add.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil dimasukkan ke ProductTbl");
                    }
                    catch
                    {
                        MessageBox.Show("Terjadi kesalahan saat memasukkan data");
                    }
                    finally
                    {    
                        conn.Close();
                        showdata();
                    }
                }

            }

            
        }

        private void PRODGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ProdId.Text == "" || ProdName.Text == "" || ProdQty.Text == "" || ProdPrice.Text == "" || ProdCb.Text == "")
            {
                MessageBox.Show("Please select the data you want to update");
            }
            else
            {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "update ProductTbl set ProName = @ProName, ProQty = @ProQty," +
                    " ProdPrice = @ProdPrice, ProdCat = @ProdCat WHERE Proid = @Proid";
                SqlCommand update = new SqlCommand(query, conn);
                update.Parameters.AddWithValue("@Proid", int.Parse(ProdId.Text));
                update.Parameters.AddWithValue("@ProName", ProdName.Text);
                update.Parameters.AddWithValue("@ProQty", int.Parse(ProdQty.Text));
                update.Parameters.AddWithValue("@ProdPrice", decimal.Parse(ProdPrice.Text));
                update.Parameters.AddWithValue("@ProdCat", ProdCb.Text);


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

        private void PRODGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Catd.Text = PRODGV.Rows[e.RowIndex].Cells["Catd"].Value.ToString();
            ProdId.Text = PRODGV.Rows[e.RowIndex].Cells["Proid"].Value.ToString();
            ProdName.Text = PRODGV.Rows[e.RowIndex].Cells["ProName"].Value.ToString();
            ProdQty.Text = PRODGV.Rows[e.RowIndex].Cells["ProQty"].Value.ToString();
            ProdPrice.Text = PRODGV.Rows[e.RowIndex].Cells["ProdPrice"].Value.ToString();
            ProdCb.SelectedValue = PRODGV.Rows[e.RowIndex].Cells["ProdCat"].Value;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ProdId.Text = string.Empty; 
            ProdName.Text = string.Empty;
            ProdQty.Text = string.Empty;
            ProdPrice.Text = string.Empty;
            ProdCb.SelectedValue = string.Empty;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (ProdId.Text == "")
            {
                MessageBox.Show("Please select the data you want to delete");
            }
            else
            {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "DELETE FROM ProductTbl WHERE Proid = @Proid";
                SqlCommand delete = new SqlCommand(query, conn);
                delete.Parameters.AddWithValue("@Proid", ProdId.Text);

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

        private void button1_Click(object sender, EventArgs e)
        {
            SellerForm sl = new SellerForm();
            sl.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "Select * from ProductTbl where ProdCat = @ProdCat";
            SqlCommand rd = new SqlCommand(query, conn);
            rd.Parameters.AddWithValue("@ProdCat", comboBox2.SelectedValue);

            try
            {
                conn.Open();
                rd.ExecuteNonQuery();
            } catch
            {
                MessageBox.Show("System Error");
            }finally
            {
                var dt = new DataTable("ProductTbl");
                var name = new SqlDataAdapter(rd);

                name.Fill(dt);
                PRODGV.DataSource = dt;
                conn.Close();
            }
        }

        private void ProdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            showdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellingForm sl = new SellingForm();
            sl.Show();
            this.Hide();
        }

        private void ProdQty_TextChanged(object sender, EventArgs e)
        {

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
