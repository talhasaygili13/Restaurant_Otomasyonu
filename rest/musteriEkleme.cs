using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace rest
{
    public partial class musteriEkleme : Form
    {
        //private readonly cMusteriler clients;
        //private readonly frmRezervasyon reservations;
        //private readonly frmPaketSiparis packets;
        //private readonly frmMusteriAra searchClients;
        //private readonly frmMenu menu;

        public musteriEkleme()
        {
            InitializeComponent();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            cMusteriler clients = new cMusteriler();

            if (txtTelefon.Text.Length > 6)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen müşterinin Ad ve Soyad alanlarını doldurunuz ");
                }
                else
                {
                    bool sonuc = clients.MusteriKontrol(txtTelefon.Text);
                    if (!sonuc)
                    {
                        clients.Musteriad = txtMusteriAd.Text;
                        clients.MusteriSoyad = txtMusteriSoyad.Text;
                        clients.Telefon = txtTelefon.Text;
                        clients.Email = txtEmail.Text;
                        clients.Adres = txtAdres.Text;
                        txtMusteriNo.Text = clients.MusteriEkle(clients).ToString();
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri Eklendi");
                        }
                        else
                        {
                            MessageBox.Show("Müşteri Eklenemedi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Müşterinin kaydı daha önce yapıldı");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon numarası giriniz ");
            }
        }


        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            frmPaketSiparis packets = new frmPaketSiparis();

            frmRezervasyon reservations = new frmRezervasyon();

            if (cGenel._musteriEkleme == 0)
            {
                cGenel._musteriEkleme = 1;
                this.Close();
                reservations.Show();
            }
            else if (cGenel._musteriEkleme == 1)
            {
                cGenel._musteriEkleme = 0;
                this.Close();
                packets.Show();
            }
        }

        private void musteriGuncelle_Click(object sender, EventArgs e)
        {
            frmMusteriAra searchClients = new frmMusteriAra();

            cMusteriler clients = new cMusteriler();

            if (txtTelefon.Text.Length > 6)
            {
                if (txtMusteriAd.Text == "" || txtMusteriSoyad.Text == "")
                {
                    MessageBox.Show("Lütfen müşterinin Ad ve Soyad alanlarını doldurunuz ");
                }
                else
                {

                    clients.Musteriad = txtMusteriAd.Text;
                    clients.MusteriSoyad = txtMusteriSoyad.Text;
                    clients.Telefon = txtTelefon.Text;
                    clients.Email = txtEmail.Text;
                    clients.Adres = txtAdres.Text;
                    clients.musteriBilgileriGuncelle(clients);
                    clients.MusteriId = Convert.ToInt32(txtMusteriNo.Text);
                    txtMusteriNo.Text = clients.MusteriEkle(clients).ToString();
                    bool sonuc = clients.musteriBilgileriGuncelle(clients);
                    if (!sonuc)
                    {
                        if (txtMusteriNo.Text != "")
                        {
                            MessageBox.Show("Müşteri bilgileri Güncelendi");
                            foreach (Control item in this.Controls)
                            {
                                if (item is TextBox)
                                {
                                    TextBox text = (TextBox)item;
                                    text.Text = "";
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Müşteri bilgileri güncellenemedi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarılı");
                        this.Close();
                        searchClients.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon numarası giriniz ");
            }
        }

        private void musteriEkleme_Load(object sender, EventArgs e)
        {
            cMusteriler clients = new cMusteriler();

            if (eklemeEkrani)
            {
                btnEkle.Visible = true;
                musteriGuncelle.Visible = false;
            }
            else
            {
                if (cGenel._musteriId > 0)
                {
                    musteriGuncelle.Visible = true;
                    btnEkle.Visible = false;
                    txtMusteriNo.Text = cGenel._musteriId.ToString();
                    clients.musterilerigetirID(Convert.ToInt32(txtMusteriNo.Text), txtMusteriAd, txtMusteriSoyad, txtTelefon,
                        txtAdres, txtEmail);
                }
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();

            frmMusteriAra searchClients = new frmMusteriAra();

            cGenel._musteriEkleme = 1;
            this.Close();
            menu.Show();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            frmMusteriAra searchClients = new frmMusteriAra();

            this.Close();

            searchClients.Show();
        }


        public void ClearControls()
        {
            try
            {
                txtMusteriAd.Text = "";
                txtMusteriAd.Text = string.Empty;
                //txtPassword.Text = string.Empty;
                txtMusteriSoyad.Text = string.Empty;
                txtTelefon.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtMusteriNo.Text = string.Empty;
                txtAdres.Text = string.Empty;
                //fnMessage(false, "");
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
            finally
            {
            }
        }

        public bool eklemeEkrani = false;


        private void musteriGuncelle_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Müşteri güncellemek için tıklayınız.", musteriGuncelle);
        }

        private void btnEkle_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Müşteri eklemek için tıklayınız.", btnEkle);
        }
    }
}