using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket_mene
{
    public partial class ReportShowBillTbl : Form
    {
        public ReportShowBillTbl()
        {
            InitializeComponent();
        }

        private void ReportShowBillTbl_Load(object sender, EventArgs e)
        {

        }
        public void SetReportData(DataTable data, string parameterValue)
        {
            BillTbl report = new BillTbl();
            report.SetDataSource(data);

            report.SetParameterValue("bill_id", parameterValue);

            crystalReportViewer1.ReportSource = report;
        }
    }

}
