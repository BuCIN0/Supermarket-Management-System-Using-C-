using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket_mene
{
    public partial class itemlocation : Form
    {
        public itemlocation()
        {
            InitializeComponent();
        }

        private void itemlocation_Load(object sender, EventArgs e)
        {
            String direct = "D:\\UMN\\SEM 2 KULIAH\\Visual Programming\\last project\\Distribution Center\\ItemLocation.txt";
            string[] fileline = File.ReadAllLines(direct);
            foreach (string line in fileline)
            {
                textBox1.AppendText(line + Environment.NewLine);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filepath = "D:\\UMN\\SEM 2 KULIAH\\Visual Programming\\last project\\Distribution Center\\ItemLocation.txt";

                string filefill = textBox1.Text;
            File.WriteAllText(filepath, filefill);
            MessageBox.Show("Items Location Updated");
                
               textBox1.ReadOnly = true;
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
