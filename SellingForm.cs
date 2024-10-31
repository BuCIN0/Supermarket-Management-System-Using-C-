using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket_mene
{
    public partial class SellingForm : Form
    {
        public SellingForm()
        {
            InitializeComponent();
        }
        String vconn = "Data Source=LAPTOP-S8ODA9JU\\SQLEXPRESS01;Initial Catalog=SUPERMARKET3;Integrated Security=True";
        private void showdata()
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "select Proid,ProName, ProdPrice from ProductTbl";
            SqlCommand show = new SqlCommand(query, conn);

            var dt = new DataTable("ProductTbl");
            var name = new SqlDataAdapter(show);

            name.Fill(dt);
            PRODGV1.DataSource = dt;
        }
        private void showdatabill()
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "select Billid, SellerName, BillDate, TotAmt from BillTbl";
            SqlCommand show = new SqlCommand(query, conn);

            var dt = new DataTable("BillTbl");
            var name = new SqlDataAdapter(show);

            name.Fill(dt);
            BillsDGV.DataSource = dt;
        }

        private void fillcombo2()
        {
            
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
        private void SellingForm_Load(object sender, EventArgs e)
        {
            showdata();
            showdatabill();
            fillcombo2();
            SellerNamelbl.Text = Form1.SellerName;
        }

        private void PRODGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            proid.Text = PRODGV1.Rows[e.RowIndex].Cells["Proid"].Value.ToString();
            ProdName.Text = PRODGV1.Rows[e.RowIndex].Cells["ProName"].Value.ToString();
            ProdPrice.Text = PRODGV1.Rows[e.RowIndex].Cells["ProdPrice"].Value.ToString();
        }

        private void Datelbl_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Datelbl.Text = DateTime.Today.ToString("dd/MM/yyyy");

        }
        decimal grandtotal = 0;
        int n = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            
            if (ProdName.Text == "" || ProdQty.Text == "")
            {
                MessageBox.Show("Missing data");
            }
            else
            {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "insert into ItemSell(proid, ProName, ProdPrice, ProQty, ProTotal) values (@proid, @ProName, @ProdPrice, @ProQty, @ProTotal)";
                SqlCommand add = new SqlCommand(query, conn);
                String query1 = "insert into ItemSellCustomer(proid, ProName, ProdPrice, ProQty, ProTotal) values (@proid, @proName, @ProdPrice, @ProQty, @ProTotal)";
                SqlCommand add1 = new SqlCommand(query1, conn);

                add.Parameters.AddWithValue("@proid", Convert.ToInt16(proid.Text));
                add.Parameters.AddWithValue("@ProName", ProdName.Text);
                add.Parameters.AddWithValue("@ProdPrice", Convert.ToDecimal(ProdPrice.Text));
                add.Parameters.AddWithValue("@ProQty", Convert.ToInt16(ProdQty.Text));
                add.Parameters.AddWithValue("@ProTotal", Convert.ToDecimal(ProdPrice.Text) * Convert.ToDecimal(ProdQty.Text));

                
                decimal total = Convert.ToDecimal(ProdPrice.Text) * Convert.ToDecimal(ProdQty.Text);
                DataGridViewRow nr = new DataGridViewRow();
                nr.CreateCells(ORDERDGV);
                nr.Cells[0].Value = proid.Text;
                nr.Cells[1].Value = ProdName.Text;
                nr.Cells[2].Value = ProdPrice.Text;
                nr.Cells[3].Value = ProdQty.Text;
                nr.Cells[4].Value = Convert.ToDecimal(ProdPrice.Text) * Convert.ToDecimal(ProdQty.Text);
                ORDERDGV.Rows.Add(nr);
                n++;
                grandtotal = grandtotal + total;
                Amttlbl.Text = ""+grandtotal;
                add1.Parameters.AddWithValue("@proid", Convert.ToInt16(nr.Cells[0].Value));
                add1.Parameters.AddWithValue("@ProName", nr.Cells[1].Value);
                add1.Parameters.AddWithValue("@ProdPrice", Convert.ToDecimal(nr.Cells[2].Value));
                add1.Parameters.AddWithValue("@ProQty", Convert.ToInt16(nr.Cells[3].Value));
                add1.Parameters.AddWithValue("@ProTotal", nr.Cells[4].Value);

                proid.Text = string.Empty;
                ProdQty.Text = string.Empty;
                ProdPrice.Text = string.Empty;
                ProdName.Text = string.Empty;


                try
                {
                    conn.Open();
                    add.ExecuteNonQuery();
                    add1.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil dimasukan");
                }
                catch
                {
                    MessageBox.Show("terjadi kesalahan input data");
                }
                finally
                {
                    conn.Close(); 
                }
            }
        }

        private void deletecustomeritem()
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "DELETE FROM ItemSellCustomer";
            SqlCommand delete = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                delete.ExecuteNonQuery();
                MessageBox.Show("Data berhasil dihapus");
            }
            catch
            {
                MessageBox.Show("Terjadi kesalahan dalam sistem");
            }
            finally
            {
                conn.Close();
                //showdata();
            }

        }
        private void addcustomeritem()
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "insert into ItemSellCustomer(proid, ProName, ProdPrice, ProQty, ProTotal) values (@proid, @proName, @ProdPrice, @ProQty, @ProTotal)";
            SqlCommand add = new SqlCommand(query, conn);

            
            add.Parameters.AddWithValue("@proid", Convert.ToInt16(proid.Text));
            add.Parameters.AddWithValue("@ProName", ProdName);
            add.Parameters.AddWithValue("@ProdPrice", Convert.ToDecimal(ProdPrice.Text));
            add.Parameters.AddWithValue("@ProQty", Convert.ToInt16(ProdQty));
            add.Parameters.AddWithValue("@ProTotal", Convert.ToDecimal(ProdPrice.Text) * Convert.ToDecimal(ProdQty.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
                SqlConnection conn = new SqlConnection(vconn);
                String query = "insert into BillTbl(SellerName, BillDate, TotAmt) values (@SellerName, @BillDate, @TotAmt)";
                SqlCommand add = new SqlCommand(query, conn);

                add.Parameters.AddWithValue("@SellerName", SellerNamelbl.Text);
                add.Parameters.AddWithValue("@BillDate", Datelbl.Text);
                add.Parameters.AddWithValue("@TotAmt", decimal.Parse(Amttlbl.Text));

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
                    showdatabill();
                }
            
            
        }

        private void BillsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FAMILYSUPERMARKET", 
                new Font("Century Gothic", 25, FontStyle.Bold), Brushes.BlueViolet, new Point(230));
            e.Graphics.DrawString("Bill ID : " + BillsDGV.SelectedRows[0].Cells[0].Value.ToString(), 
                new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 70));
            e.Graphics.DrawString("Seller Name : " + BillsDGV.SelectedRows[0].Cells[1].Value.ToString(), 
                new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 100));
            e.Graphics.DrawString("Date : " + BillsDGV.SelectedRows[0].Cells[2].Value.ToString(), 
                new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 130));
            e.Graphics.DrawString("Total Amount : " + BillsDGV.SelectedRows[0].Cells[3].Value.ToString(), 
                new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 160));
        }



        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = BillsDGV.SelectedRows;

            DataTable selectedData = ((DataTable)BillsDGV.DataSource).Clone();

            foreach (DataGridViewRow row in selectedRows)
            {
                DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                selectedData.ImportRow(dataRow);
            }

            string parameterValue = selectedData.Rows[0]["billid"].ToString(); 

            ReportShowBillTbl reportForm = new ReportShowBillTbl();

            reportForm.SetReportData(selectedData, parameterValue);


            reportForm.Show();

            this.Hide();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            showdata();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(vconn);
            String query = "Select Proid, ProName, ProdPrice from ProductTbl where ProdCat = @ProdCat";
            SqlCommand rd = new SqlCommand(query, conn);
            rd.Parameters.AddWithValue("@ProdCat", comboBox2.SelectedValue);

            try
            {
                conn.Open();
                rd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("System Error");
            }
            finally
            {
                var dt = new DataTable("ProductTbl");
                var name = new SqlDataAdapter(rd);

                name.Fill(dt);
                PRODGV1.DataSource = dt;
                conn.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }

        private void ORDERDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (BillsDGV.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus baris terpilih?",
                    "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int rowIndex = BillsDGV.SelectedRows[0].Index;

                    string Billid = BillsDGV.Rows[rowIndex].Cells["Billid"].Value.ToString();

                    BillsDGV.Rows.RemoveAt(rowIndex);

                    using (SqlConnection conn = new SqlConnection(vconn))
                    {
                        string query = "DELETE FROM BillTbl WHERE Billid = @Billid";
                        SqlCommand deleteCommand = new SqlCommand(query, conn);
                        deleteCommand.Parameters.AddWithValue("@Billid", Billid);

                        try
                        {
                            conn.Open();
                            deleteCommand.ExecuteNonQuery();
                            MessageBox.Show("Baris berhasil dihapus");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih baris yang ingin dihapus");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            deletecustomeritem();
        }

        private void Amttlbl_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formItemSell itemSell= new formItemSell();
            itemSell.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            formItemSell itemSell = new formItemSell();
            itemSell.Show();
            this.Close();
        }
    }
}
