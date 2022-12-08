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
    public partial class frmBil : Form
    {
        public  frmBil()
        {
            InitializeComponent();
        }



       

       

        private void frmBil_Load_1(object sender, EventArgs e)
        {
            cSiparis cs = new cSiparis();
            if (cGenel._ServisTurNo == 1)
            {
                lblAdisyonId.Text = cGenel._AdisyonId;
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged_1);
                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3]);

                    }
                    lblToplamTutar.Text = String.Format("0:0.000", toplam);
                    lblOdenecek.Text = String.Format("0:0.000", toplam);
                }

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnGeriDon_Click_1(object sender, EventArgs e)
        {
            btnMasaSiparis frmMasa = new btnMasaSiparis();
            this.Close();
            frmMasa.Show();
        }

        private void txtIndirimTutari_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(lblIndirim.Text) < Convert.ToDecimal(lblToplamTutar))
                {
                    try
                    {
                        lblIndirim.Text = string.Format("0:0.000", Convert.ToDecimal(txtIndirimTutari.Text));
                    }
                    catch (Exception)
                    {

                        lblIndirim.Text = string.Format("0:0.000", 0);
                    }
                }
                else
                {
                    MessageBox.Show("İndirim tutarı toplam tutardan fazla olamaz !!");
                }
            }
            catch (Exception)
            {
                lblIndirim.Text = string.Format("0:0.000", 0);
            }
        }
    }
}
