using System;
using System.Drawing;
using System.Windows.Forms;

namespace rest
{
    public partial class frmRezervasyon : Form
    {
   
        public frmRezervasyon()
        {
            InitializeComponent();
        }

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            cMasalar table = new cMasalar();

            cMusteriler clients = new cMusteriler();

            lvRezervasyonlar.Visible = false;

            clients.musterleriGetir(lvMusteriler);

            table.masaKapasitesiVeDurumGetir(cbMasa);
            dtTarih.MinDate = DateTime.Today;
            dtTarih.Format = DateTimePickerFormat.Long;
            table.masaDurumGetirLv(listView1);
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();

            this.Close();
            menu.Show();
        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            cMusteriler clients = new cMusteriler();

            clients.musteriGetirAd(lvMusteriler, txtMusteriAd.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            cMusteriler clients = new cMusteriler();

            clients.musteriGetirTlf(lvMusteriler, txtTelefon.Text);
        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            cMusteriler clients = new cMusteriler();

            clients.musteriGetirAdres(lvMusteriler, txtAdres.Text);
        }

        void Temizle()
        {
            txtAdres.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            cMasalar table = new cMasalar();
            cRezervasyon reservations = new cRezervasyon();


            if (lvMusteriler.SelectedItems.Count > 0)
            {
                bool sonuc =
                    reservations.rezarvationAcikMiKontrol(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                if (!sonuc)
                {
                    if (dtTarih.Text != "")
                    {
                        if (cbKisiSayisi.Text != "")
                        {
                            if (table.TableGetbyState(Convert.ToInt32(txtMasaNo.Text), 1))
                            {
                                cAdisyon a = new cAdisyon();
                                a.Tarih = Convert.ToDateTime(dtTarih.Text);
                                a.ServisTurNo = 1;
                                a.MasaId = Convert.ToInt32(txtMasaNo.Text);
                                a.PersonelId = cGenel._personelId;

                                reservations.ClientId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                                reservations.TableId = Convert.ToInt32(txtMasaNo.Text);
                                reservations.Date = Convert.ToDateTime(dtTarih.Text);
                                reservations.ClientCount = Convert.ToInt32(cbKisiSayisi.Text);
                                reservations.Description = txtAciklama.Text;
                                reservations.AdditionId = a.rezervasyonAdisyonAc(a);
                                sonuc = reservations.rezarvationAc(reservations);

                                if (sonuc)
                                {
                                    table.setChangeTableState(txtMasaNo.Text, 3);
                                    MessageBox.Show("Rezervasyon açılmıştır");
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Rezervasyon açılamadı.Lütfen yetkili kişi ile iletişime geçiniz");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Rezervasyon yapılan masa şu an dolu");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen kişi sayısı seçiniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir tarih seçiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Bu müşteri üzerine açık bir rezervasyon bulunmaktadır");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz");
            }
        }


        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {
            dtTarih.Height = 200;
            dtTarih.Text = dtTarih.Value.ToString();
        }

        private void cbMasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKisiSayisi.Enabled = true;
            cbMasa.Text = cbMasa.SelectedItem.ToString();

            cMasalar Kapsitesi = (cMasalar)cbMasa.SelectedItem;
            int kapasite = Kapsitesi.KAPASITE;
            txtMasaNo.Text = Convert.ToString(Kapsitesi.ID);

            cbKisiSayisi.Items.Clear();
            for (int i = 0; i < kapasite; i++)
            {
                cbKisiSayisi.Items.Add(i + 1);
            }
        }

        private void cbKisiSayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKisiSayisi.Text = cbKisiSayisi.SelectedItem.ToString();
        }


        private void btnSiparisKontrol_Click(object sender, EventArgs e)
        {

            frmSiparisKontrol orderControl = new frmSiparisKontrol();
            orderControl.paketSiparis = false;

            this.Close();
            orderControl.Show();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
         

            musteriEkleme addClients = new musteriEkleme();

            addClients.eklemeEkrani = true;
            cGenel._musteriEkleme = 1;
            addClients.rezervasyon = true;
         
            this.Close();
            addClients.Show();
        }

        private void guncelleMusteri_Click(object sender, EventArgs e)
        {
            musteriEkleme addClient = new musteriEkleme();
            addClient.rezervasyon = true;

            if (lvMusteriler.SelectedItems.Count > 0)
            {
                cGenel._musteriEkleme = 0;
                cGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                addClient.btnEkle.Visible = false;
                addClient.musteriGuncelle.Visible = true;
                this.Close();
                addClient.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz");
            }
        }


        private void btnYeniMusteri_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Yeni Müşteri Ekle", btnYeniMusteri);
        }

        private void btnMusteriSec_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Rezervasyon oluştur", btnMusteriSec);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Sipariş kontrol sayfasına girmek için tıklayınız", button3);
        }

        private void guncelleMusteri_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Müşteri Güncelleme sayfasına gitmek için tıklayınızs", guncelleMusteri);
        }

        int museteriId = 0;

        private void lvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cRezervasyon reservations = new cRezervasyon();


            //  m.musteriIdAl(6);

            if (lvMusteriler.SelectedItems.Count > 0)
            {
                lvRezervasyonlar.Visible = true;
                museteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                reservations.rezervasyonGetirMusteriId(lvRezervasyonlar, museteriId);
            }
            else
            {
                lvRezervasyonlar.Visible = false;
            }
        }
    }
}