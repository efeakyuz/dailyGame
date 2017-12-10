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
        public string[] islemler = new string[4] {"+", "-", "x", "/"};
        public string dogruIslem = "empty";
        public int skor = 0;
        public int remaningTime = 60;
        public double remainingProgress = 100;
        public islemiBul()
        {
            InitializeComponent();
            progressBar1.Value = 100;
        }
        
        string islemUret()
        {
            Random rnd = new Random();
            int islemIndis = rnd.Next(4);
            dogruIslem = islemler[islemIndis];
            return dogruIslem;
        }

        int sayiUret()
        {
            Random rnd = new Random();
            int sayi = rnd.Next(11);
            return sayi;
        }

        public void game()
        {
            dogruIslem = "/";
            int[] sayilar = new int[2] {0,0};
            sayilar[0] = sayiUret();
            sayilar[1] = sayiUret();

            if (dogruIslem == "/")
            {
                while ( sayilar[0] % sayilar[1] != 0 || sayilar[0] == 0 || sayilar[1] == 0)
                {
                    sayilar[0] = sayiUret();
                    sayilar[1] = sayiUret();

                    while (sayilar[0] == sayilar[1])
                    {
                        sayilar[1] = sayiUret();
                    }
                }
            }


            if (dogruIslem == "-")
            {
                if (sayilar[1] == 10 || sayilar[1] == 10)
                {
                    sayilar[1] = 13;
                }
                while (sayilar[0] < sayilar[1])
                {
                    sayilar[0] = sayiUret();
                }
            }
            
            sayi1.Text = sayilar[0].ToString();
            sayi2.Text = sayilar[1].ToString();
            islem.Text = dogruIslem;
            
           
        }

        private void startGame_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            remaningTime = remaningTime - 1;
            if (remainingProgress - 1.66 < 0)
            {
                remainingProgress = 0;
            }
            else
            {
                remainingProgress = remainingProgress - 1.66;
            }
            timeHolder.Text = remaningTime.ToString();
            if (remaningTime < 0)
            {
                timer1.Stop();
                progressBar1.Value = 0;
                //button1.Enabled = true;
                //button2.Enabled = false;
                timeHolder.Text = "Süre Bitti!";
            }
            progressBar1.Value = Convert.ToInt32(remainingProgress);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            game();
            timer1.Interval = 1000;
            timer1.Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dogruIslem == "+")
            {
                skor = skor + 10;
            }
            label4.Text = skor.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dogruIslem == "-")
            {
                skor = skor + 10;
            }
            label4.Text = skor.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dogruIslem == "x")
            {
                skor = skor + 10;
            }
            label4.Text = skor.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dogruIslem == "/")
            {
                skor = skor + 10;
            }
            label4.Text = skor.ToString();
        }
    }
}
