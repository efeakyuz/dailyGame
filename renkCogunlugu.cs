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
    public partial class renkCogunlugu : Form
    {

        public Color trueAnswer = new Color();
        public int timeRemaining = 60;
        public double remainingProgress = 100;
        public int score = 0;

        public renkCogunlugu()
        {
            InitializeComponent();
            label4.Text = score.ToString();
            button2.Enabled = false;
            progressBar1.Value = 100;
        }
        
        public void game()
        {
            Color[] colours = new Color[10] { Color.Aqua, Color.Black, Color.Red, Color.MidnightBlue, Color.Olive, Color.Chocolate, Color.DarkCyan, Color.DarkGray, Color.DarkOrange, Color.DarkRed };

            Random rnd = new Random();
            int rnd1 = rnd.Next(10);
            int rnd2 = rnd.Next(10);
            while (rnd2 == rnd1)
            {
                rnd2 = rnd.Next(10);
            }
            Color colour1 = colours[rnd1];
            trueAnswer = colour1;
            Color colour2 = colours[rnd2];

            PictureBox[] pics = new PictureBox[15] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15 };

            Random rndArray = new Random();
            for (int i = 0; i < 15; i++)
            {
                int rndIndex = rndArray.Next(i, 15);
                PictureBox temp = pics[i];
                pics[i] = pics[rndIndex];
                pics[rndIndex] = temp;
            }
            for (int j = 0; j < 8; j++)
            {
                pics[j].BackColor = colour1;
            }
            for (int j = 8; j < 15; j++)
            {
                pics[j].BackColor = colour2;
            }
        }
        
        public void check(PictureBox picture)
        {
            if (picture.BackColor == trueAnswer)
            {
                score = score + 10;
                label4.Text = score.ToString();
            }
            else
            {
                timeRemaining = timeRemaining - 5;
                remainingProgress = remainingProgress - 8.3;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            timer1.Interval = 1000;
            changeColors.Interval = 10000;
            timer1.Start();
            changeColors.Start();
            button1.Enabled = false;
            button2.Enabled = true;
            game();
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeHolder.Text = timeRemaining.ToString();
            timeRemaining = timeRemaining - 1;
            progressBar1.Value = Convert.ToInt32(remainingProgress); 
            remainingProgress = remainingProgress - 1.66;
            if(timeRemaining == -1)
            {
                timer1.Stop();
                progressBar1.Value = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            timer1.Stop();
        }

        private void changeColors_Tick(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            check(pictureBox1);
            game();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            check(pictureBox2);
            game();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            check(pictureBox4);
            game();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            check(pictureBox3);
            game();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            check(pictureBox15);
            game();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            check(pictureBox10);
            game();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            check(pictureBox9);
            game();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            check(pictureBox8);
            game();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            check(pictureBox7);
            game();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            check(pictureBox14);
            game();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            check(pictureBox12);
            game();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            check(pictureBox11);
            game();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            check(pictureBox6);
            game();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            check(pictureBox5);
            game();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            check(pictureBox13);
            game();
        }
    }
}
