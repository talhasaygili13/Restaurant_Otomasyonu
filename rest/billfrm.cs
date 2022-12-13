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
    public partial class billfrm : Form
    {
      
        public billfrm()
        {
            InitializeComponent();

        }

        int odemeTuru = 0;

        private void billfrm_Load(object sender, EventArgs e)
        {
            cSiparis order = new cSiparis();
            cPaketler packets = new cPaketler();

            if (cGenel._ServisTurNo == 1)
            {
                lblAdisyonId.Text = cGenel._AdisyonId;
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                order.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;

                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }

                    lblToplamTutar.Text = String.Format("{0:0.}", toplam);
                    lblOdenecek.Text = String.Format("{0:0.}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.}", kdv);
                }
                gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
            else if (cGenel._ServisTurNo == 2)
            {
                lblAdisyonId.Text = cGenel._AdisyonId;
                odemeTuru = packets.OdemeTurIdGetir(Convert.ToInt32(lblAdisyonId.Text));
                txtIndirimTutari.TextChanged += new EventHandler(txtIndirimTutari_TextChanged);
                order.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));

                if (odemeTuru == 1)
                {
                    rbNakit.Checked = true;
                }
                else if (odemeTuru == 2)
                {
                    rbKredKarti.Checked = true;
                }
                else if (odemeTuru == 3)
                {
                    rbTicket.Checked = true;
                }


                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }

                    lblToplamTutar.Text = String.Format("{0:0.}", toplam);
                    lblOdenecek.Text = String.Format("{0:0.}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.}", kdv);
                }

                gbIndirim.Visible = true;
                txtIndirimTutari.Clear();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            this.Close();
            bill.Show();
        }

        private void txtIndirimTutari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtIndirimTutari.Text) < Convert.ToDecimal(lblToplamTutar.Text))
                {
                    try
                    {
                        lblIndirim.Text = string.Format("{0:0.}", Convert.ToDecimal(txtIndirimTutari.Text));
                    }
                    catch (Exception)
                    {
                        lblIndirim.Text = string.Format("{0:0.}", 0);
                    }
                }
                else
                {
                    MessageBox.Show("İndirim tutarı toplam tutardan fazla olamaz !!");
                }
            }
            catch (Exception)
            {
                lblIndirim.Text = string.Format("{0:0.}", 0);
            }
        }

        private void chkIndirim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIndirim.Checked)
            {
                gbIndirimTutar.Visible = true;
                txtIndirimTutari.Clear();
            }
            else
            {
                gbIndirimTutar.Visible = false;
                txtIndirimTutari.Clear();
            }
        }

        private void lvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lblIndirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblIndirim.Text) > 0)
            {
                decimal odenecek = 0;
                lblOdenecek.Text = lblToplamTutar.Text;
                odenecek = Convert.ToDecimal(lblOdenecek.Text) - Convert.ToDecimal(lblIndirim.Text);
                lblOdenecek.Text = string.Format("{0:0.}", odenecek);
            }

            decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
            lblKdv.Text = string.Format("{0:0.}", kdv);
        }


        private void hesapOzet_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Show();
        }

        Font Baslik = new Font("Verdana", 15, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 12, FontStyle.Regular);
        Font icerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);


        private void hesapKapatma(object sender, EventArgs e)
        {
            cMasalar masalar = new cMasalar();
            cRezervasyon reservation = new cRezervasyon();
            cOdeme pay = new cOdeme();
            cPaketler packets = new cPaketler();
            cAdisyon addittion = new cAdisyon();
            frmMenu menu = new frmMenu();

            int odemeTurId = 0;
            int musteriId = 0;
            if (cGenel._ServisTurNo == 1)
            {
                int masaId = masalar.TableGetbyNumber(cGenel._ButtonName);


                if (masalar.TableGetbyState(masaId, 4) == true)
                {
                    musteriId = reservation.getByClientIdFromRezervasyon(masaId);
                }
                else
                {
                    musteriId = 1;
                }

                if (rbNakit.Checked)
                {
                    odemeTurId = 1;
                }
                else if (rbKredKarti.Checked)
                {
                    odemeTurId = 2;
                }
                else if (rbTicket.Checked)
                {
                    odemeTurId = 3;
                }
                else
                {
                    MessageBox.Show("Lütfen İşlemlerinizi Kontrol Ediniz");
                    return;
                }


                pay.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                pay.OdemeTurId = odemeTurId;
                pay.MusteriId = musteriId;
                pay.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                pay.KdvTutari = Convert.ToDecimal(lblKdv.Text);
                pay.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                pay.Indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = pay.billClose(pay);
                if (result)
                {
                    MessageBox.Show("Hesap Kapatıldı");
                    masalar.setChangeTableState(Convert.ToString(masaId), 1);
                    cRezervasyon cr = new cRezervasyon();

                    cr.rezarvationClose(Convert.ToInt32(lblAdisyonId.Text));
                    cAdisyon ca = new cAdisyon();
                    ca.adisyonKapat(Convert.ToInt32(lblAdisyonId.Text), 0);

                    this.Close();
                    frmMasa frm = new frmMasa();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap Kapatılırken Bir Sorun Oluştu");
                }
            }
            else if (cGenel._ServisTurNo == 2)
            {
                pay.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                pay.OdemeTurId = odemeTuru;

                pay.MusteriId = 1; // Paket Sipariş ID gelecek
                pay.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                pay.KdvTutari = Convert.ToDecimal(lblKdv.Text);
                pay.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                pay.Indirim = Convert.ToDecimal(lblIndirim.Text);

                bool result = pay.billClose(pay);
                if (result)
                {
                    addittion.adisyonKapat(Convert.ToInt32(lblAdisyonId.Text), 1);

                    packets.OrderServiceClose(Convert.ToInt32(lblAdisyonId.Text));
                    MessageBox.Show("Hesap Kapatıldı");

                    this.Close();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Hesap Kapatılırken Bir Sorun Oluştu");
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Itadakimasu RESTAURANT", Baslik, sb, 260, 100, sf);
            e.Graphics.DrawString("--------------------------------", altBaslik, sb, 300, 130, sf);
            e.Graphics.DrawString(" Ürün Adı                Adet                Fiyat", altBaslik, sb, 150, 250, sf);
            e.Graphics.DrawString("---------------------------------------------", altBaslik, sb, 150, 280, sf);

            for (int i = 0; i < lvUrunler.Items.Count; i++)
            {
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[0].Text, icerik, sb, 150, 300 + i * 30, sf);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[1].Text, icerik, sb, 350, 300 + i * 30, sf);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[2].Text, icerik, sb, 420, 300 + i * 30, sf);
            }

            e.Graphics.DrawString("------------------------------------------------", altBaslik, sb, 150,
                300 + 30 * lvUrunler.Items.Count, sf);
            e.Graphics.DrawString("İndirim Tutarı  : ---" + lblIndirim.Text + "TL", altBaslik, sb, 250,
                300 + 30 * (lvUrunler.Items.Count + 1), sf);
            e.Graphics.DrawString("KDV Tutarı      : ---" + lblKdv.Text + "TL", altBaslik, sb, 250,
                300 + 30 * (lvUrunler.Items.Count + 2), sf);
            e.Graphics.DrawString("Toplam Tutar    : ---" + lblToplamTutar.Text + "TL", altBaslik, sb, 250,
                300 + 30 * (lvUrunler.Items.Count + 3), sf);
            e.Graphics.DrawString("Ödediğiniz Tutar: ---" + lblOdenecek.Text + "TL", altBaslik, sb, 250,
                300 + 30 * (lvUrunler.Items.Count + 4), sf);
        }


        private void hesapOzet_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Hesap Özetini Görmek İçin Tıklayınız", hesapOzet);
        }

        private void hesapKapat_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Hesap Ödemek İçin Tıklayınız", hesapKapat);
        }
    }
}