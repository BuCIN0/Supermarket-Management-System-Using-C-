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
using CrystalDecisions.CrystalReports.Engine;


namespace supermarket_mene
{
    public partial class ShowFilteringProduct : Form
    {
        public ShowFilteringProduct()
        {
            InitializeComponent();
        }
        String vconn = "Data Source=LAPTOP-S8ODA9JU\\SQLEXPRESS01;Initial Catalog=SUPERMARKET3;Integrated Security=True";
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
            comboBox1.ValueMember = "CatName";
            comboBox1.DataSource = dt;

            conn.Close();
        }
        private void ShowFilteringProduct_Load(object sender, EventArgs e)
        {
            fillcombo2();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilteringProduct vcr = new FilteringProduct();
            vcr.SetParameterValue("P_Cat", comboBox1.SelectedValue);
            crystalReportViewer1.ReportSource = vcr;

        }
    }
}
