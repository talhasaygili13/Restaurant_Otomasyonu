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
    public partial class frmMenu : Form
    {

        public frmMenu()
        {
            InitializeComponent();
        }



        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            frmAyarlar settings = new frmAyarlar();

            this.Close();
            settings.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMasa table = new frmMasa();

            this.Close();
            table.Show();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            frmRezervasyon reservation = new frmRezervasyon();

            this.Close();
            reservation.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            frmGiris login = new frmGiris();

            this.Close();
            login.Show();
        }


        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            frmMusteriAra clients = new frmMusteriAra();

            this.Close();
            clients.Show();
        }

        private void btnMutfak_Click(object sender, EventArgs e)
        {
            frmMutfak kitchen = new frmMutfak();

            this.Close();
            kitchen.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            frmRaporlar reports = new frmRaporlar();

            this.Close();
            reports.Show();
        }

        private void btnKilit_Click(object sender, EventArgs e)
        {
            rezervasyonKontrol reservationControl = new rezervasyonKontrol();

            this.Close();
            reservationControl.Show();
        }

        private void btnMasalar_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Masalar sayfasına gitmek için tıklayınız", btnMasalar);
        }

        private void btnRezervasyon_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Rezervasyon sayfasına gitmek için tıklayınız", btnRezervasyon);
        }

        private void btnMusteriler_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Müşteriler sayfasına gitmek için tıklayınız", btnMusteriler);
        }

        private void btnMutfak_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Mutfak sayfasına gitmek için tıklayınız", btnMutfak);
        }

        private void btnRaporlar_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Raporlar sayfasına gitmek için tıklayınız", btnRaporlar);
        }

        private void btnAyarlar_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Parola Güncelleme sayfasına gitmek için tıklayınız", btnAyarlar);
        }

        private void btnCikis_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Çıkış yapmak için tıklayınız", btnCikis);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            rezervasyonKontrol reservationControl = new rezervasyonKontrol();
            reservationControl.rezervasyonSilGeçmiş();
            
        }
    }
}