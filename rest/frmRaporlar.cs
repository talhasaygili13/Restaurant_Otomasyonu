using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace rest
{

    public partial class frmRaporlar : Form
    {


        public frmRaporlar()
        {
            InitializeComponent();

        }



        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();

            this.Close();
            menu.Show();
        }

        private void btnAnaYemek_Click(object sender, EventArgs e)
        {
            Istatistikler("Ana Yemek Grafiği", 1, Color.Crimson);
        }

        private void btnIcecek_Click(object sender, EventArgs e)
        {
            Istatistikler("İçecekler Grafiği", 2, Color.DarkOrange);
        }


        private void Istatistikler(string gfName, int katId, Color renk)
        {
            cUrunler products = new cUrunler();

            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = renk;
            lvIstatistik.Items.Clear();
            products.urunleriListeleIstatistiklereGoreUrunId(lvIstatistik, dtBaslangic, dtBitis, katId);
            grpIstatistik.Text = gfName;
            if (lvIstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();

                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text,
                        lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilecek İstatistik Yok,Başka bir zamaan dilimi seçiniz.");
            }
        }

        private void btnTatlilar_Click(object sender, EventArgs e)
        {
            Istatistikler("Tatlılar Grafiği", 3, Color.LightBlue);
        }

        private void btnSalatalar_Click(object sender, EventArgs e)
        {
            Istatistikler("Salatalar Grafiği", 4, Color.DarkSeaGreen);
        }

        private void btnFastFood_Click(object sender, EventArgs e)
        {
            Istatistikler("Fast Food Grafiği", 5, Color.DarkSlateBlue);
        }

        private void btnCorba_Click(object sender, EventArgs e)
        {
            Istatistikler("Çorbalar Grafiği", 6, Color.BurlyWood);
        }

        private void btnMakarna_Click(object sender, EventArgs e)
        {
            Istatistikler("Makarnalar Grafiği", 7, Color.DarkMagenta);
        }

        private void btnAraSıcak_Click(object sender, EventArgs e)
        {
            Istatistikler("Ara Sıcaklar Grafiği", 8, Color.SandyBrown);
        }

        private void btnZraporu_Click(object sender, EventArgs e)
        {
            cUrunler products = new cUrunler();

            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = Color.Khaki;
            lvIstatistik.Items.Clear();
            products.urunleriListeleIstatistiklereGore(lvIstatistik, dtBaslangic, dtBitis);
            grpIstatistik.Text = "Tüm Kategoriler";
            if (lvIstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();

                for (int i = 0; i < lvIstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvIstatistik.Items[i].SubItems[0].Text,
                        lvIstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
            {
                MessageBox.Show("Gösterilecek İstatistik Yok. Başka bir zamaan dilimi seçiniz.");
            }
        }


        private void btnAnaYemek_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İstatistikleri Görüntüle", btnAnaYemek);
        }

        private void btnIcecek_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İstatistikleri Görüntüle", btnIcecek);
        }

        private void btnTatlilar_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İstatistikleri Görüntüle", btnTatlilar);
        }

        private void btnSalatalar_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İstatistikleri Görüntüle", btnSalatalar);
        }

        private void btnFastFood_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İstatistikleri Görüntüle", btnFastFood);
        }

        private void btnCorba_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İstatistikleri Görüntüle", btnCorba);
        }

        private void btnMakarna_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İstatistikleri Görüntüle", btnMakarna);
        }

        private void btnAraSıcak_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İstatistikleri Görüntüle", btnAraSıcak);
        }

        private void btnZraporu_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İstatistikleri Görüntüle", btnZraporu);
        }

        private void frmRaporlar_Load(object sender, EventArgs e)
        {

            dtBaslangic.Value = DateTime.Now.AddMonths(-1); 
        }
    }
}