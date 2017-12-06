using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otistik
{
    public partial class EsBulma : Form
    {
        public EsBulma()
        {
            InitializeComponent();
        }

        enum Tiklamalar
        {
            ilkTiklama, ikinciTiklama
        }

        #region Genel Değişkenler
        Tiklamalar tiklama = Tiklamalar.ilkTiklama;
        PictureBox oncekiResim;
        SoundPlayer resimAcSes = new SoundPlayer(Properties.Resources.farkli);
        SoundPlayer ayniSes = new SoundPlayer(Properties.Resources.ayni);
        SoundPlayer farkliSes = new SoundPlayer(Properties.Resources.farkli);
        int kalan;
        int ciftSay;

        #endregion

       
        void ResimleriGizle(params PictureBox[] Resimler)
        {
            if (Resimler.Length == 0)
            {
                Resimler = pZemin.Controls.Cast<PictureBox>().ToArray();
            }


            foreach (PictureBox x in pZemin.Controls)
            {
                x.Image = imageList1.Images[0];
            }
        }
        void ResimleriGoster()
        {
            foreach (PictureBox x in pZemin.Controls)
            {
                x.Image = imageList1.Images[(int)x.Tag];
            }
        }
        void ResimleriDoldur()
        {

            ArrayList Tagler = new ArrayList();
            Random r = new Random();
            for (int i = 0; i < (ciftSay) * 2; i++)
            {
                Tagler.Add((i % ciftSay) + 1);
            }
            foreach (PictureBox x in pZemin.Controls)
            {
                int sansli = r.Next(Tagler.Count);
                x.Tag = Tagler[sansli];
                x.Show();
                Tagler.RemoveAt(sansli);

            }

        }
        private void yenidenbaslat()
        {
            ciftSay = imageList1.Images.Count - 1;
            kalan = ciftSay;
            lblKalan.Text = kalan.ToString();
            ResimleriDoldur();
            ResimleriGizle();
            oncekiResim = null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            yenidenbaslat();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //  (sender as PictureBox).Image = imageList1.Images[(int)(sender as PictureBox).Tag];
            PictureBox simdikiResim = sender as PictureBox;

            #region aynı resimi üst üste tıklamayı önler
            if (oncekiResim == simdikiResim)
            {
                MessageBox.Show("Geçersiz Tıklama");
                return;
            }
            #endregion
            #region resim açma
            simdikiResim.Image = imageList1.Images[(int)simdikiResim.Tag];
            pZemin.Refresh();
            resimAcSes.Play();
            #endregion

            switch (tiklama)
            {
                case Tiklamalar.ilkTiklama:
                    #region resmi yedekler ve bir sonraki tıklama için hazırlık yapar
                    oncekiResim = simdikiResim;
                    tiklama = Tiklamalar.ikinciTiklama;
                    #endregion
                    break;
                case Tiklamalar.ikinciTiklama:
                    Thread.Sleep(500);
                    if (oncekiResim.Tag.ToString() == simdikiResim.Tag.ToString())
                    {
                        #region Resimler Aynıysa
                        oncekiResim.Hide();
                        simdikiResim.Hide();
                        ayniSes.Play();
                        lblKalan.Text = (--kalan).ToString();
                        if (kalan == 0)
                        {
                            MessageBox.Show("Tebrikler!!!");
                            yenidenbaslat();
                        }
                        #endregion
                    }
                    else
                    {
                        #region Resimler Farklıysa
                        ResimleriGizle(oncekiResim, simdikiResim);
                        farkliSes.Play();
                        #endregion
                    }
                    tiklama = Tiklamalar.ilkTiklama;
                    oncekiResim = null;
                    break;
                default:
                    break;

            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ResimleriDoldur();
            ResimleriGoster();
        }

        private void pZemin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnYeniden_Click(object sender, EventArgs e)
        {
            yenidenbaslat();
        }

        private void btnYardim_Click(object sender, EventArgs e)
        {
            ResimleriGoster();
            pZemin.Refresh();
            Thread.Sleep(500);
            ResimleriGizle();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblKalan_Click(object sender, EventArgs e)
        {

        }

        private void EsBulma_Load(object sender, EventArgs e)
        {
            yenidenbaslat();
        }

        private void btnYardim_Click_1(object sender, EventArgs e)
        {
            ResimleriGoster();
            pZemin.Refresh();
            Thread.Sleep(500);
            ResimleriGizle();
        }

        private void btnYeniden_Click_1(object sender, EventArgs e)
        {
            yenidenbaslat();
        }
    }
}
