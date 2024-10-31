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
    public partial class formItemSell : Form
    {
        public formItemSell()
        {
            InitializeComponent();
        }
        String vconn = "Data Source=LAPTOP-S8ODA9JU\\SQLEXPRESS01;Initial Catalog=SUPERMARKET3;Integrated Security=True";
        private void showdata()
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "select proid, ProName, ProdPrice, ProQty, ProTotal from ItemSell";
            SqlCommand show = new SqlCommand(query, conn);

            var dt = new DataTable("ItemSell");
            var name = new SqlDataAdapter(show);

            name.Fill(dt);
            ItemSellDGV.DataSource = dt;
        }
        private void fillcombo()
        {
            //This method will bind the combobox with the database
            SqlConnection conn = new SqlConnection(vconn);
            conn.Open();

            String query = "select ProName from ProductTbl";
            SqlCommand cm = new SqlCommand(query, conn);
            SqlDataReader rd = cm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ProName", typeof(string));
            dt.Load(rd);
            ISName.ValueMember = "ProName";
            ISName.DataSource = dt;

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellingForm sf = new SellingForm();
            sf.Show();
            this.Close();
        }

        private void formItemSell_Load(object sender, EventArgs e)
        {
            showdata();
            fillcombo();
        }

        private void ItemSellDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ISIdTb.Text = ItemSellDGV.Rows[e.RowIndex].Cells["proid"].Value.ToString();
            ISName.Text = ItemSellDGV.Rows[e.RowIndex].Cells["ProName"].Value.ToString();
            ISPrice.Text = ItemSellDGV.Rows[e.RowIndex].Cells["ProdPrice"].Value.ToString();
            ISQTY.Text = ItemSellDGV.Rows[e.RowIndex].Cells["ProQty"].Value.ToString();
            ISTotal.Text = ItemSellDGV.Rows[e.RowIndex].Cells["ProTotal"].Value.ToString();
        }

            private void button6_Click(object sender, EventArgs e)
            {
                if (ISIdTb.Text == "" || ISName.Text == "" || ISPrice.Text == "" || ISQTY.Text == "" || ISTotal.Text == "")
                {
                    MessageBox.Show("Please select the data you want to update");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(vconn);
                    String query = "update ItemSell set ProName = @ProName, ProdPrice = @ProdPrice, ProQty = @ProQty, ProTotal = @ProTotal WHERE Proid = @Proid";
                    SqlCommand update = new SqlCommand(query, conn);
                    update.Parameters.AddWithValue("@Proid", int.Parse(ISIdTb.Text));
                    update.Parameters.AddWithValue("@ProName", ISName.Text);
                    update.Parameters.AddWithValue("@ProdPrice", decimal.Parse(ISPrice.Text));
                    update.Parameters.AddWithValue("@ProQty", int.Parse(ISQTY.Text));
                    update.Parameters.AddWithValue("@ProTotal", decimal.Parse(ISTotal.Text));


                    try
                    {
                        conn.Open();
                        update.ExecuteNonQuery();
                        MessageBox.Show("Data berhasil Update");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
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
            if (ISIdTb.Text == "")
            {
                MessageBox.Show("Please select the data you want to delete");
            }
            else
            {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "DELETE FROM ItemSell WHERE Proid = @Proid";
                SqlCommand delete = new SqlCommand(query, conn);
                delete.Parameters.AddWithValue("@Proid", ISIdTb.Text);

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

        private void ISQTY_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ISQTY.Text) && !string.IsNullOrEmpty(ISPrice.Text))
            {
                decimal qty = decimal.Parse(ISQTY.Text);
                decimal price = decimal.Parse(ISPrice.Text);
                decimal total = qty * price;
                ISTotal.Text = total.ToString();
            }
            else
            {
                ISTotal.Text = "";
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SellingForm sf = new SellingForm();
            sf.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
