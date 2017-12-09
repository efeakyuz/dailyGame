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
    public partial class islemiBul : Form
    {
        public islemiBul()
        {
            InitializeComponent();
            timeHolder.Text = sayiUret(15).ToString();
        }

        int sayiUret(int range)
        {
            Random rnd = new Random();
            int sayi = rnd.Next(range);
            return sayi;
        }

        private void startGame_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
