using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    public partial class rezervasyonKontrol : Form
    {
        // private readonly cRezervasyon reservation;
        //  private readonly cMasalar table;
        //private readonly cAdisyon addition;
        //private readonly frmMenu menu;

        public rezervasyonKontrol()
        {
            InitializeComponent();
        }


        DateTime today = DateTime.Today;

        private void rezervasyonKontrol_Load(object sender, EventArgs e)
        {
            cRezervasyon reservation = new cRezervasyon();

            //     DateTime rezarvasyonTime = Convert.ToDateTime(lvRezervasyonKontrol.SelectedItems[0].SubItems[5].Text);
            reservation.rezervasyonKontrol(lvRezervasyonKontrol);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cRezervasyon reservation = new cRezervasyon();

            if (checkBox1.Checked == true)
            {
                reservation.rezervsayonAll(lvRezervasyonKontrol);
                yenileAll();
            }


            else
            {
                reservation.rezervasyonKontrol(lvRezervasyonKontrol);
                yenile();
            }

            rezervasyonSilGeçmiş();
        }

        private void rezervasyonSilGeçmiş()
        {
            cMasalar table = new cMasalar();
            cAdisyon addition = new cAdisyon();
            cRezervasyon reservation = new cRezervasyon();

            for (int i = 0; i < lvRezervasyonKontrol.Items.Count; i++)
            {
                if (Convert.ToDateTime(lvRezervasyonKontrol.Items[i].SubItems[5].Text) < DateTime.Today)
                {
                    if (lvRezervasyonKontrol.Items[0].SubItems[7].Text == "Kapandı")
                    {
                    }
                    else if (lvRezervasyonKontrol.Items[0].SubItems[7].Text == "Açık")
                    {
                        MessageBox.Show("Tarihi geçmiş rezervasyonlar var");
                        reservation.rezarvationClose(Convert.ToInt32(lvRezervasyonKontrol.Items[0].SubItems[2].Text));
                        addition.adisyonKapatKontrol(Convert.ToInt32(lvRezervasyonKontrol.Items[0].SubItems[2].Text),
                            0);
                        table.setChangeTableState(Convert.ToString(lvRezervasyonKontrol.Items[0].SubItems[3].Text),
                            1);
                    }
                }
                else if (Convert.ToDateTime(lvRezervasyonKontrol.Items[i].SubItems[5].Text) == DateTime.Today)
                {
                    table.setChangeTableState(Convert.ToString(lvRezervasyonKontrol.Items[0].SubItems[3].Text), 3);
                }
                else
                {
                    table.setChangeTableState(Convert.ToString(lvRezervasyonKontrol.Items[0].SubItems[3].Text), 1);
                }
            }
        }

        private void yenileAll()
        {
            cRezervasyon reservation = new cRezervasyon();

            reservation.rezervsayonAll(lvRezervasyonKontrol);
        }

        private void yenile()
        {
            cRezervasyon reservation = new cRezervasyon();

            reservation.rezervasyonKontrol(lvRezervasyonKontrol);
        }

        private void kontrolEtYenile()
        {
            if (checkBox1.Checked == true)
            {
                yenileAll();
            }
            else
            {
                yenile();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            cMasalar table = new cMasalar();
            cAdisyon addition = new cAdisyon();
            cRezervasyon reservation = new cRezervasyon();

            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Silmek istedğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    table.setChangeTableState(Convert.ToString(lvRezervasyonKontrol.Items[0].SubItems[3].Text), 1);
                    reservation.rezervasyonKapatKontrol(lvRezervasyonKontrol, Convert.ToInt32(textBox1.Text));
                    addition.adisyonKapat(Convert.ToInt32(Convert.ToInt32(textBox1.Text)), 0);

                    yenile();
                }
            }
            else
            {
                MessageBox.Show("Rezervasyon Seçiniz");
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Close();
            menu.Show();
        }


        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Rezervasyonu kapatmak için tıklayınız", button1);
        }

        private void lvRezervasyonKontrol_MouseClick(object sender, MouseEventArgs e)
        {
            ListView lw = (ListView)sender;

            DateTime value = Convert.ToDateTime(lw.SelectedItems[0].SubItems[5].Text);
            textBox1.Text = lvRezervasyonKontrol.SelectedItems[0].SubItems[2].Text;
            ListViewHitTestInfo lstHitTestInfo = lvRezervasyonKontrol.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Right)
            {
                if (lstHitTestInfo.Item != null)
                {
                    lvRezervasyonKontrol.ContextMenuStrip = contextMenuStrip1;
                }
            }

            if (Convert.ToDateTime(value) > today)
            {
                //MessageBox.Show("Gelecek Rezervasyon");
                kontrolEtYenile();
            }
            else if (Convert.ToDateTime(value) == today)
            {
                // MessageBox.Show("Rezervasyon Bugün");
                kontrolEtYenile();
            }
            else if (Convert.ToDateTime(value) < today)
            {
                // MessageBox.Show("Geçmiş Rezervasyon");
                kontrolEtYenile();
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cMasalar table = new cMasalar();
            cRezervasyon reservation = new cRezervasyon();
            cAdisyon addition = new cAdisyon();

            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Silmek istedğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    table.setChangeTableState(Convert.ToString(lvRezervasyonKontrol.Items[0].SubItems[3].Text), 1);
                    reservation.rezervasyonKapatKontrol(lvRezervasyonKontrol, Convert.ToInt32(textBox1.Text));
                    addition.adisyonKapat(Convert.ToInt32(Convert.ToInt32(textBox1.Text)), 0);

                    yenile();
                }
            }
            else
            {
                MessageBox.Show("Rezervasyon Seçiniz");
            }
        }
    }
}