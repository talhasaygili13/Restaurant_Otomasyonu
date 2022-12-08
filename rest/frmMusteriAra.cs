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
using TextBox = System.Windows.Forms.TextBox;
using ToolTip = System.Windows.Forms.ToolTip;

namespace rest
{
    public partial class frmMusteriAra : Form
    {
        // private readonly frmMenu menu;
        //private readonly musteriEkleme addClients;
        // private readonly cMusteriler clients;
        //private readonly cPaketler packets;
        //private readonly frmSiparisKontrol orderControl;

        public frmMusteriAra()
        {
            InitializeComponent();
        }



        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();

            this.Close();
            menu.Show();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            musteriEkleme addClients = new musteriEkleme();

            addClients.eklemeEkrani = true;
            cGenel._musteriEkleme = 1;

            this.Close();
            addClients.Show();
        }

        private void frmMusteriAra_Load(object sender, EventArgs e)
        {
            cMusteriler clients = new cMusteriler();

            clients.musterleriGetir(lvMusteriler);
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            musteriEkleme addClients = new musteriEkleme();

            if (lvMusteriler.SelectedItems.Count > 0)
            {
                cGenel._musteriEkleme = 1;
                cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);

                this.Close();

                addClients.eklemeEkrani = false;
                addClients.Show();
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();

            this.Close();
            menu.Show();
        }

        private void txtAdAra_TextChanged(object sender, EventArgs e)
        {
            cMusteriler clients = new cMusteriler();

            clients.musteriGetirAd(lvMusteriler, txtAdAra.Text);
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            cMusteriler clients = new cMusteriler();

            clients.musteriGetirSoyad(lvMusteriler, txtSoyad.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler clients = new cMusteriler();

            clients.musteriGetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void btnAdisyonBul_Click(object sender, EventArgs e)
        {
            cPaketler packets = new cPaketler();

            if (txtAdisyonID.Text != "")
            {
                cGenel._AdisyonId = txtAdisyonID.Text;

                bool sonuc = packets.getCheckOpenAdditionID(Convert.ToInt32(txtAdisyonID.Text));
                if (sonuc)
                {
                    billfrm frm = new billfrm();
                    cGenel._ServisTurNo = 2;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(txtAdisyonID.Text + " nolu Adisyon bulunamadı ");
                }
            }
            else
            {
                MessageBox.Show("Aramak istediğiniz Adisyonu yazınız");
            }
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            frmSiparisKontrol orderControl = new frmSiparisKontrol();

            this.Close();
            orderControl.Show();
        }


        private void btnYeniMusteri_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Müşteri eklemek için tıklayınız", btnYeniMusteri);
        }

        private void btnMusteriGuncelle_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Müşteri güncellemek için tıklayınız", btnMusteriGuncelle);
        }

        private void btnSiparis_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Sipariş Kontrol sayfasına gitmek için tıklayınız", btnSiparis);
        }

        private void btnGoBack_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Önceki sayfaya dönmek için tıklayınız", btnSiparis);
        }
    }
}