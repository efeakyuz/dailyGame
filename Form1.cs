using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otistik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            islemiBul islem = new islemiBul();
            islem.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EsBulma esbulma = new EsBulma();
            esbulma.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            renkCogunlugu renk = new renkCogunlugu();
            renk.Show();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            islemiBul islem = new islemiBul();
            islem.Show();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            Dörtİslem dort = new Dörtİslem();
            dort.Show();
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            EsBulma esbulma = new EsBulma();
            esbulma.Show();
        }

        
    }
}
