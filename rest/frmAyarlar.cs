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
    public partial class frmAyarlar : Form
    {
        // private readonly cPersoneller worker;
        //   private readonly cPersonelGorev workerMission;
        // private readonly frmMenu menu;

        public frmAyarlar()
        {
            InitializeComponent();
        }



        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            this.Close();
            menu.Show();
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            cPersonelGorev workerMission = new cPersonelGorev();

            cPersoneller worker = new cPersoneller();

            string gorev = workerMission.PersonelGorevTanim(cGenel._gorevId);
            if (gorev == "Mudur")
            {
                worker.personelGetByInformation(cbPersonel);
                workerMission.PersonelGoreviGetir(cbGorevi);
                worker.personelBilgileriniGetirLv(lvPersoneller);
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnBilgiDegistir.Enabled = false;
                btnEkle.Enabled = false;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                txtSifre.ReadOnly = true;
                txtSifreTekrar.ReadOnly = true;
                lblBilgi.Text = "Mevki :Müdür / Yetki Sınırsız /Kullanıcı :" +
                                worker.personelBilgileriGetirIsim(cGenel._personelId);
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                lblBilgi.Text = "Mevki : Çalışan / Yetki Sınırlı / Kullanıcı : " +
                                worker.personelBilgileriGetirIsim(cGenel._personelId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cPersoneller worker = new cPersoneller();

            if (txtYeniSifre.Text.Trim() != "" || txtYeniSifreTekrar.Text.Trim() != "")
            {
                if (txtYeniSifre.Text == txtYeniSifreTekrar.Text)
                {
                    if (txtPersonelId.Text != "")
                    {
                        bool sonuc = worker.personelSifreDegistir(Convert.ToInt32(txtPersonelId.Text), txtYeniSifre.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre değiştirme işlemi başarıyla gerçekleştirildi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz!");
                    }
                }
                else
                {
                    MessageBox.Show("Girdiğiniz Şifreler Eşleştirilemedi!!");
                }
            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız!!");
            }
        }

        private void cbGorevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersonelGorev c = (cPersonelGorev)cbGorevi.SelectedItem;
            txtGorevID.Text = Convert.ToString(c.PersonelGoreviId);
        }

        private void cbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller c = (cPersoneller)cbPersonel.SelectedItem;
            txtPersonelId.Text = Convert.ToString(c.PersonelID);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }

            btnYeni.Enabled = false;
            btnEkle.Enabled = true;
            btnBilgiDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtSifre.ReadOnly = false;
            txtSifreTekrar.ReadOnly = false;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Silmek istedğinize emin misiniz?", "UYARI", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cPersoneller c = new cPersoneller();
                    bool sonuc = c.personelSil(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text));
                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt silindi");
                        c.personelBilgileriniGetirLv(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silinirken bir hata oluştu!!");
                    }
                }
                else
                {
                    MessageBox.Show("Bir kayıt seçiniz!!");
                }
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            cPersoneller worker = new cPersoneller();

            if (txtAd.Text != "" & txtSoyad.Text != "" & txtSifre.Text != "" & txtSifreTekrar.Text != "" &
                txtGorevID.Text.Trim() != "")
            {
                if (txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim() & (txtSifre.Text.Length >= 5) &
                    (txtSifreTekrar.Text.Length >= 5))
                {
                    worker.PersonelAd = txtAd.Text.Trim();
                    worker.PersonelSoyad = txtSoyad.Text.Trim();
                    worker.PersonelParola = txtSifre.Text.Trim();
                    worker.PersonelGorevID = Convert.ToInt32(txtGorevID.Text);
                    bool sonuc = worker.personelEkle(worker);
                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt Başarıyla Eklenmiştir");
                        worker.personelBilgileriniGetirLv(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Eklenirken bir sorun oluştu!!");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil");
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız");
            }
        }

        private void btnBilgiDegistir_Click(object sender, EventArgs e)
        {
            cPersoneller worker = new cPersoneller();

            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (txtAd.Text.Trim() != "" || txtSoyad.Text.Trim() != "" || txtSifre.Text.Trim() != "" ||
                    txtSifreTekrar.Text != "" || txtGorevID.Text != "")
                {
                    if (txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim() & (txtSifre.Text.Length >= 5) &
                        (txtSifreTekrar.Text.Length >= 5))
                    {
                        worker.PersonelAd = txtAd.Text.Trim();
                        worker.PersonelSoyad = txtSoyad.Text.Trim();
                        worker.PersonelParola = txtSifre.Text.Trim();
                        worker.PersonelGorevID = Convert.ToInt32(txtGorevID.Text);
                        bool sonuc = worker.personelGuncelle(worker, Convert.ToInt32(txtPersonelId.Text));
                        if (sonuc)
                        {
                            MessageBox.Show("Kayıt Başarıyla Eklenmiştir");
                            worker.personelBilgileriniGetirLv(lvPersoneller);
                        }
                        else
                        {
                            MessageBox.Show("Kayıt Eklenirken bir sorun oluştu!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler aynı değil");
                    }
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmayınız");
                }
            }
            else
            {
                MessageBox.Show("Kayıt Seçiniz");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cPersoneller worker = new cPersoneller();

            if (textBox7.Text.Trim() != "" || textBox6.Text.Trim() != "")
            {
                if (textBox7.Text == textBox6.Text)
                {
                    if (cGenel._personelId.ToString() != "")
                    {
                        bool sonuc = worker.personelSifreDegistir(Convert.ToInt32(cGenel._personelId), textBox6.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre değiştirme işlemi başarıyla gerçekleştirildi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel Seçiniz!");
                    }
                }
                else
                {
                    MessageBox.Show("Girdiğiniz Şifreler Eşleştirilemedi!!");
                }
            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız!!");
            }
        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                btnSil.Enabled = true;
                txtPersonelId.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
                cbGorevi.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text) - 1;
                txtAd.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;
                txtSoyad.Text = lvPersoneller.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                btnSil.Enabled = false;
            }
        }

        private void btnClearText_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtGorevID.Text = "";
            txtPersID.Text = "";
            cbGorevi.Text = "";
        }


        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Şifrenizi güncellemek için tıklyaınız", button1);
        }

        private void btnYeni_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Müşteri eklemel için tıklayınız", btnYeni);
        }

        private void btnEkle_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Bilgileri onayla ve kaydet", btnEkle);
        }

        private void btnSil_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Kaydı silmek için tıklayınız", btnSil);
        }

        private void btnBilgiDegistir_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Bilgileri güncellemek için tıklayınız", btnBilgiDegistir);
        }

        private void btnClearText_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Bilgileri temizlemek için tıklayınız", btnClearText);
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Şifrenizi güncellemek için tıklyaınız", button6);
        }
    }
}