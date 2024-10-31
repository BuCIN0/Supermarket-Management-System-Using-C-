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
    public partial class showFIlteringSeller : Form
    {
        public showFIlteringSeller()
        {
            InitializeComponent();
        }
        String vconn = "Data Source=LAPTOP-S8ODA9JU\\SQLEXPRESS01;Initial Catalog=SUPERMARKET3;Integrated Security=True";
        private void fillcombo2()
        {
            SqlConnection conn = new SqlConnection(vconn);
            conn.Open();

            String query = "SELECT DISTINCT SellerAge FROM SellerTbl";
            SqlCommand cm = new SqlCommand(query, conn);
            SqlDataReader rd = cm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SellerAge", typeof(string));
            dt.Load(rd);
            comboBox1.ValueMember = "SellerAge";
            comboBox1.DataSource = dt;

            conn.Close();
        }


        private void showFIlteringSeller_Load(object sender, EventArgs e)
        {
            fillcombo2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilteringSeller vcr = new FilteringSeller();
            vcr.SetParameterValue("age", comboBox1.SelectedValue);
            crystalReportViewer1.ReportSource = vcr;
        }
    }
}
