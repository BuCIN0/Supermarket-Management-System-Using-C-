using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace supermarket_mene
{
    public partial class utama : Form 
    {
        public utama()
        {
            InitializeComponent();
        }

        private void productFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CATEGORYFORM cf = new CATEGORYFORM();
            cf.MdiParent= this;
            cf.Show();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm pf = new ProductForm();
            pf.MdiParent= this;
            pf.Show();
        }

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellerForm sf = new SellerForm();
            sf.MdiParent= this;
            sf.Show();
        }

        private void productReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportShowProductTbl rpt = new ReportShowProductTbl();
            
            rpt.MdiParent= this;
            rpt.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ASDCat asc = new ASDCat();
            asc.MdiParent= this;
            asc.Show();
        }

        private void sellingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportShowSellerTbl rst = new ReportShowSellerTbl();
            SellerTbl cr = new SellerTbl();
            rst.crystalReportViewer1.ReportSource = cr;
            rst.MdiParent= this;
            rst.Show();
        }

        private void sellingFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellingForm sf = new SellingForm();
            sf.MdiParent= this;
            sf.Show();
        }

        private void logoutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }

        private void sortByAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportShowItemSell rsis = new reportShowItemSell();
            rsis.MdiParent= this;
            rsis.Show();
        }

        private void utama_Load(object sender, EventArgs e)
        {

        }

        private void filteringProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFilteringProduct sfp = new ShowFilteringProduct();
            sfp.MdiParent = this;
            sfp.Show();
             
        }

        private void filteringItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showfilteringitemsell sfi= new showfilteringitemsell();
            sfi.MdiParent= this;
            sfi.Show();
        }

        private void filteringCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void itemLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemlocation il = new itemlocation();
            il.MdiParent = this;
            il.Show();
        }

        private void filteringBySellerNameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sortSellerAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void fIlteringSellerNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showFIlteringSeller sfse = new showFIlteringSeller();
            sfse.MdiParent = this;
            sfse.Show();
        }

        private void manageItemSellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formItemSell fis =new formItemSell();
            fis.MdiParent = this;
            fis.Show();
        }
    }
}
