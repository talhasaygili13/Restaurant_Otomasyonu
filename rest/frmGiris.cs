using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace rest
{
    public partial class frmGiris : Form
    {
        // private readonly cPersoneller worker;
        //private readonly cPersonelHareketleri worekrControl;
        // private readonly frmMenu menu;

        public frmGiris()
        {
            InitializeComponent();
        }


        cGenel gnl = new cGenel();

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            cPersoneller worker = new cPersoneller();

            worker.personelGetByInformation(cbKullanici);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Uyarı!!!", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void cbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller p = (cPersoneller)cbKullanici.SelectedItem;
            cGenel._personelId = p.PersonelID;
            cGenel._gorevId = p.PersonelGorevID;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtSifre.UseSystemPasswordChar = false;
                checkBox1.BackgroundImage = Properties.Resources.eye;
                // checkBox1.BackColor = Color.Transparent;
            }
            else if (checkBox1.Checked == false)
            {
                txtSifre.UseSystemPasswordChar = true;
                checkBox1.BackgroundImage = Properties.Resources.openEye;
                // checkBox1.BackColor = Color.Transparent;
            }
        }

        private void Login()
        {
            frmMenu menu = new frmMenu();
            cPersonelHareketleri worekrControl = new cPersonelHareketleri();
            cPersoneller worker = new cPersoneller();

            bool result = worker.personelEntryControl(txtSifre.Text, cGenel._personelId);

            if (result)
            {
                worekrControl.PersonelId = cGenel._personelId;
                worekrControl.Islem = "Giriş Yaptı";
                worekrControl.Tarih = DateTime.Now;
                worekrControl.PersonelActionSave(worekrControl);
                this.Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!!", "Uyarı!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                txtSifre.Clear();
            }
        }


        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }


        private void btnGiris_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Giriş", btnGiris);
        }

        private void btnCikis_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Çıkış", btnCikis);
        }
    }
}