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
    public partial class frmMutfak : Form
    {
      //  private readonly cUrunCesitleri productTypes;
       // private readonly cUrunler products;
        private readonly frmMenu menu;

        public frmMutfak()
        {
            InitializeComponent();

             menu = new frmMenu();
        }


        private void frmMutfak_Load(object sender, EventArgs e)
        {
            cUrunler products = new cUrunler();

            cUrunCesitleri productTypes = new cUrunCesitleri();

            productTypes.urunCesitleriniGetir(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;
            lblArama.Visible = true;
            txtArama.Visible = true;
            panelUrun.Visible = false;
            panelAnaKategori.Visible = false;
            lvKategoriler.Visible = false;
            lvGidaListesi.Visible = true;

            products.urunleriListele(lvGidaListesi);
        }


        private void Temizle()
        {
            txtGidaAdi.Clear();
            txtGidaFiyati.Clear();
            txtGidaFiyati.Text = string.Format("{0:##0.00}", 0);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();
            cUrunler products = new cUrunler();

            //if (rbAnaKategori.Checked)
            //{
            //    if (txtKategoriAd.Text.Trim() == "" || txtAciklama.Text.Trim() == "")
            //    {
            //        MessageBox.
            // ("Gıda Adı,Fiyatı ve Kategori seçilmedi.", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        cUrunler c = new cUrunler();
            //       // c.Fiyat = Convert.ToDecimal(txtGidaFiyati.Text);
            //        c.Urunad = txtGidaAdi.Text;
            //        c.Aciklama = "Ürün Eklendi";
            //        c.Urunturno = urunTurNo;
            //        int sonuc = c.urunEkle(c);

            //        if (sonuc != 0)
            //        {
            //            MessageBox.Show("Ürün Eklenmiştir");
            //            cbKategoriler_SelectedIndexChanged(sender, e);
            //            yenile();
            //            Temizle();
            //        }
            //    }
            //}
            //else
            //{
            //    if (txtKategoriAd.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Lütfen bir kategori ismi giriniz.", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    }
            //    else
            //    {
            //        cUrunCesitleri gida = new cUrunCesitleri();
            //        gida.KategoriAd = txtKategoriAd.Text;
            //        gida.Aciklama = txtAciklama.Text;
            //        int sonuc = gida.urunKategoriEkle(gida);
            //        if (sonuc != 0)
            //        {
            //            MessageBox.Show("Kategori Eklenmiştir");
            //            gida.urunCesitleriniGetir(cbKategoriler);
            //            gida.urunCesitleriniGetir(lvKategoriler);
            //            Temizle();
            //        }
            //    }
            //}


            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim() == "" || txtGidaFiyati.Text.Trim() == "" ||
                    cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı,Fiyatı ve Kategori seçilmedi.", "Dikkat, Bilgiler Eksik",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    products.Fiyat = Convert.ToDecimal(txtGidaFiyati.Text);
                    products.Urunad = txtGidaAdi.Text;
                    products.Aciklama = "Ürün Eklendi";
                    products.Urunturno = urunTurNo;
                    int sonuc = products.urunEkle(products);

                    if (sonuc == 0)
                    {
                        MessageBox.Show("Ürün Eklenmiştir");
                        cbKategoriler_SelectedIndexChanged(sender, e);
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriAd.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen bir kategori ismi giriniz.", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    productTypes.KategoriAd = txtKategoriAd.Text;
                    productTypes.Aciklama = txtAciklama.Text;
                    int sonuc = productTypes.urunKategoriEkle(productTypes);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Eklenmiştir");
                        productTypes.urunCesitleriniGetir(cbKategoriler);
                        productTypes.urunCesitleriniGetir(lvKategoriler);
                        Temizle();
                    }
                }
            }
        }

        int urunTurNo = 0;

        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cUrunler products = new cUrunler();

            if (cbKategoriler.SelectedItem.ToString() != "")
            {
                if (cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    products.urunleriListele(lvKategoriler);
                }
                else
                {
                    cUrunCesitleri cesit = (cUrunCesitleri)cbKategoriler.SelectedItem;
                    urunTurNo = cesit.UrunTurNo;
                    products.urunleriListeleByUrunID(lvGidaListesi, urunTurNo);
                }
            }
            else
            {
                MessageBox.Show("Ürünler listelenirken bir sorun oluştu");
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();

            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim() == "" || txtGidaFiyati.Text.Trim() == "" ||
                    cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gıda Adı,Fiyatı ve Kategori seçilmedi.", "Dikkat, Bilgiler Eksik",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cUrunler c = new cUrunler();
                    c.Fiyat = Convert.ToDecimal(txtGidaFiyati.Text);
                    c.Urunad = txtGidaAdi.Text;
                    c.Urunid = Convert.ToInt32(txtUrunId.Text);
                    c.Aciklama = "Ürün Güncellendi";
                    c.Urunturno = urunTurNo;
                    int sonuc = c.urunGuncelle(c);

                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Güncellendi");
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriId.Text == "")
                {
                    MessageBox.Show("Lütfen bir kategori seçiniz.", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    productTypes.KategoriAd = txtKategoriAd.Text;
                    productTypes.Aciklama = txtAciklama.Text;
                    productTypes.UrunTurNo = Convert.ToInt32(txtKategoriId.Text);
                    int sonuc = productTypes.urunKategoriGuncelle(productTypes);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Güncellenmiştir");
                        productTypes.urunCesitleriniGetir(lvKategoriler);
                        Temizle();
                    }
                }
            }
        }

        private void lvGidaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGidaListesi.SelectedItems.Count > 0)
            {
                txtGidaAdi.Text = lvGidaListesi.SelectedItems[0].SubItems[3].Text;
                txtGidaFiyati.Text = lvGidaListesi.SelectedItems[0].SubItems[4].Text;
                txtUrunId.Text = lvGidaListesi.SelectedItems[0].SubItems[0].Text;
                //cbKategoriler.SelectedIndex=Convert.ToInt32(txtUrunId.Text);
            }
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategoriler.SelectedItems.Count > 0)
            {
                txtKategoriAd.Text = lvKategoriler.SelectedItems[0].SubItems[1].Text;
                txtKategoriId.Text = lvKategoriler.SelectedItems[0].SubItems[0].Text;
                txtAciklama.Text = lvKategoriler.SelectedItems[0].SubItems[2].Text;
                //cbKategoriler.SelectedIndex=Convert.ToInt32(txtUrunId.Text);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            cUrunler products = new cUrunler();

            cUrunCesitleri productTypes = new cUrunCesitleri();

            if (rbAltKategori.Checked)
            {
                if (lvGidaListesi.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Ürünü silmek istediğinize emin misiniz?.", "Dikkat, Ürün Silinecek",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        products.Urunid = Convert.ToInt32(txtUrunId.Text);

                        int sonuc = products.urunSil(products, Convert.ToInt32(txtUrunId.Text));

                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün Silinmiştir");
                            //cbKategoriler_SelectedIndexChanged(sender, e);

                            yenile();
                            Temizle();
                        }
                        else
                        {
                            MessageBox.Show("Ürün silinirken bir sorun oluştu");
                        }
                    }


                    else
                    {
                        MessageBox.Show("Ürünü silmek için bir ürün seçiniz.", "Dikkat, Ürün Seçmediniz.",
                            MessageBoxButtons.OK);
                    }
                }
            }

            if (rbAnaKategori.Checked)

            {
                if (lvKategoriler.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Kategori silmek istediğinize emin misiniz?.", "Dikkat, Kategori Silinecek",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int sonuc = productTypes.urunKategoriSil(Convert.ToInt32(txtKategoriId.Text));


                        if (sonuc != 0)
                        {
                            MessageBox.Show("Kategori Silinmiştir");
                            //cUrunler c = new cUrunler();
                            //c.Urunid = Convert.ToInt32(txtKategoriId.Text);
                            //c.urunSil(c,0);
                            productTypes.urunSilKategoriDurum(Convert.ToInt32(txtKategoriId.Text));
                            yenile();
                            Temizle();
                        }
                        else
                        {
                            MessageBox.Show("Kategori silinirken bir hata oluştu");
                        }
                    }
                }
            }
        }


        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Close();
            menu.Show();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            lblArama.Visible = true;
            txtArama.Visible = true;
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                cUrunler u = new cUrunler();
                u.urunleriListeleByUrunAdi(lvGidaListesi, txtArama.Text);
            }
            else
            {
                cUrunCesitleri uc = new cUrunCesitleri();
                uc.urunCesitleriniGetir(lvKategoriler, txtArama.Text);
            }
            //yenile();
        }

        private void rbAltKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            panelAnaKategori.Visible = false;
            lvKategoriler.Visible = false;
            lvGidaListesi.Visible = true;
            yenile();
        }

        private void rbAnaKategori_CheckedChanged(object sender, EventArgs e)
        {
            //panelUrun.Visible = false;
            //panelAnaKategori.Visible = true;
            //lvKategoriler.Visible = true;
            //lvGidaListesi.Visible = false;
            panelUrun.Visible = false;
            panelAnaKategori.Visible = true;
            lvKategoriler.Visible = true;
            lvGidaListesi.Visible = false;
            yenile();
        }

        private void yenile()
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();
            cUrunler products = new cUrunler();

            //cUrunCesitleri uc = new cUrunCesitleri();
            //uc.urunCesitleriniGetir(cbKategoriler);
            //cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            //cbKategoriler.SelectedIndex= 0;
            //uc.urunCesitleriniGetir(lvKategoriler);
            //cUrunler c = new cUrunler();
            //c.urunleriListele(lvGidaListesi);

            productTypes.urunCesitleriniGetir(cbKategoriler);
            productTypes.urunCesitleriniGetir(lvKategoriler);
            products.urunleriListele(lvGidaListesi);
        }

        private void btnSil_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(" Silmek için tıklayınız", btnSil);
        }

        private void btnDegistir_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Güncelleme yapmak için tıklayınız", btnDegistir);
        }

        private void btnEkle_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Yeni ürün eklemek için tıklayınız", btnEkle);
        }
    }
}