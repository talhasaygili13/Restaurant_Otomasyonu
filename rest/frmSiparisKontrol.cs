using System;
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
    public partial class frmSiparisKontrol : Form
    {
        // private readonly cAdisyon addition;
        // private readonly billfrm bill;
        // private readonly cSiparis order;
//        private readonly frmMenu menu;

        public frmSiparisKontrol()
        {
            InitializeComponent();
        }


        private void frmSiparisKontrol_Load(object sender, EventArgs e)
        {
            cAdisyon addition = new cAdisyon();

            int butonSayisi = addition.paketAdisyonBulAdedi();
            addition.acikPaketAdisyonlar(lvMusteriler);

            int alt = 50;
            int sol = 1;
            int bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonSayisi)));

            for (int i = 1; i <= butonSayisi; i++)
            {
                Button btn = new Button();


                btn.AutoSize = false;
                btn.Size = new Size(170, 80);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Name = lvMusteriler.Items[i - 1].SubItems[0].Text;
                btn.Text = lvMusteriler.Items[i - 1].SubItems[1].Text;
                btn.Font = new Font(btn.Font.FontFamily.Name, 18);
                btn.Location = new Point(sol, alt);
                this.Controls.Add(btn);

                sol += btn.Width + 5;
                if (i == 2)
                {
                    sol = 1;
                    alt += 50;
                }

                btn.Click += new EventHandler(butonGoster);
                btn.MouseEnter += new EventHandler(bilgileriGoster);
            }
        }


        protected void butonGoster(object sender, EventArgs e)
        {
            cAdisyon addition = new cAdisyon();
            billfrm bill = new billfrm();

            Button dinamikButon = (sender as Button);
            cGenel._ServisTurNo = 2;
            cGenel._AdisyonId = Convert.ToString(addition.musterininSonAdisyonId(Convert.ToInt32(dinamikButon.Name)));
            bill.Show();
        }

        protected void bilgileriGoster(object sender, EventArgs e)
        {
            cSiparis order = new cSiparis();

            cAdisyon addition = new cAdisyon();

            Button dinamikButon = (sender as Button);

            addition.musteriDetaylar(lvMusteriDetaylari, Convert.ToInt32(dinamikButon.Name));
            sonSiparisTarihi();
            lvSatisDetaylari.Items.Clear();
            cGenel._ServisTurNo = 2;
            cGenel._AdisyonId = Convert.ToString(addition.musterininSonAdisyonId(Convert.ToInt32(dinamikButon.Name)));
            lblGenelToplam.Text = order.GenelToplamBul(Convert.ToInt32(dinamikButon.Name)).ToString() + " " + "TL";
        }

        void sonSiparisTarihi()
        {
            if (lvMusteriDetaylari.Items.Count > 0)
            {
                int s = lvMusteriDetaylari.Items.Count;
                lblSonSiparisTarihi.Text = lvMusteriDetaylari.Items[s - 1].SubItems[3].Text;
                txtToplamTutar.Text = s + " " + "Adet";
            }
        }

        void toplam()
        {
            int kayitSayisi = lvSatisDetaylari.Items.Count;
            decimal toplam = 0;
            for (int i = 0; i < kayitSayisi; i++)
            {
                toplam += Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[2].Text) *
                          Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[3].Text);
            }

            lblToplamSiparis.Text = toplam.ToString() + " " + "TL";
        }

        private void lvMusteriDetaylari_SelectedIndexChanged(object sender, EventArgs e)
        {
            cSiparis order = new cSiparis();

            if (lvMusteriDetaylari.SelectedItems.Count > 0)
            {
                order.adisyonPaketSiparisDetaylari(lvSatisDetaylari,
                    Convert.ToInt32(lvMusteriDetaylari.SelectedItems[0].SubItems[4].Text));
                toplam();
                //lblGenelToplam.Text = c.GenelToplamBul(Convert.ToInt32(lvMusteriDetaylari.SelectedItems[0].SubItems[0].Text)).ToString() + " TL";
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();

            this.Close();
            menu.Show();
        }
    }
}