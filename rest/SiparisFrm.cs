using System;
using System.Collections;
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
    public partial class SiparisFrm : Form
    {
  
        public SiparisFrm()
        {
            InitializeComponent();
        }


        ArrayList silinenler = new ArrayList();

        private void btnAraSıcak_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();

            productTypes.getByProductTypes(lvMenu, btnAraSıcak8);
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMasa table = new frmMasa();

            this.Close();
            table.Show();
        }
        //Hesap İşlemi

        void islem(Object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "btn1":
                    txtAdet.Text += (1).ToString();
                    break;

                case "btn2":
                    txtAdet.Text += (2).ToString();
                    break;

                case "btn3":
                    txtAdet.Text += (3).ToString();
                    break;

                case "btn4":
                    txtAdet.Text += (4).ToString();
                    break;

                case "btn5":
                    txtAdet.Text += (5).ToString();
                    break;

                case "btn6":
                    txtAdet.Text += (6).ToString();
                    break;

                case "btn7":
                    txtAdet.Text += (7).ToString();
                    break;

                case "btn8":
                    txtAdet.Text += (8).ToString();
                    break;

                case "btn9":
                    txtAdet.Text += (9).ToString();
                    break;

                case "btn0":
                    txtAdet.Text += (0).ToString();
                    break;
                default:
                    MessageBox.Show("Sayı Giriniz");
                    break;
            }
        }

        int tableId = 0;
        int AdditionId = 0;

        private void SiparisFrm_Load(object sender, EventArgs e)
        {

            cAdisyon addition = new cAdisyon();
            cSiparis orders = new cSiparis();
            cMasalar tables = new cMasalar();
            cRezervasyon reservation = new cRezervasyon();
            lblMasaNo.Text = cGenel._ButtonValue;
            tableId = tables.TableGetbyNumber(cGenel._ButtonName);
            reservation.rezervasyonGetir(lvAdisyon, tableId);
            if (tables.TableGetbyState(tableId, 2) == true || tables.TableGetbyState(tableId, 4) == true)
            {
                AdditionId = addition.getByAddition(tableId);
                orders.getByOrder(lvSiparisler, AdditionId);
            }


            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);
        }


        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();

            productTypes.getByProductTypes(lvMenu, btnAnaYemek1);
        }

        private void btnIcecek2_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();

            productTypes.getByProductTypes(lvMenu, btnIcecek2);
        }

        private void btnTatlilar3_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();

            productTypes.getByProductTypes(lvMenu, btnTatlilar3);
        }

        private void btnSalatalar4_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();

            productTypes.getByProductTypes(lvMenu, btnSalatalar4);
        }

        private void btnFastFood5_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();

            productTypes.getByProductTypes(lvMenu, btnFastFood5);
        }

        private void btnCorba6_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();

            productTypes.getByProductTypes(lvMenu, btnCorba6);
        }

        private void btnMakarna7_Click(object sender, EventArgs e)
        {
            cUrunCesitleri productTypes = new cUrunCesitleri();

            productTypes.getByProductTypes(lvMenu, btnMakarna7);
        }

        int sayac = 0;
        int sayac2 = 0;

        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            }

            if (lvMenu.Items.Count > 0)
            {
                sayac = lvSiparisler.Items.Count;
                lvSiparisler.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparisler.Items[sayac].SubItems.Add(txtAdet.Text);
                lvSiparisler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) *
                                                        Convert.ToDecimal(txtAdet.Text)).ToString());
                lvSiparisler.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenenler.Items.Count;
                lvSiparisler.Items[sayac].SubItems.Add(sayac2.ToString());


                lvYeniEklenenler.Items.Add(AdditionId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(txtAdet.Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(tableId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());

                sayac2++;
                txtAdet.Text = "";
            }
        }

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            cAdisyon addition = new cAdisyon();
            cSiparis orders = new cSiparis();
            frmMasa table = new frmMasa();
            cMasalar tables = new cMasalar();

            bool sonuc = false;
            if (tables.TableGetbyState(tableId, 1) == true)
            {
                addition.ServisTurNo = 1;
                addition.PersonelId = 1;
                addition.MasaId = tableId;
                addition.Tarih = DateTime.Now;
                sonuc = addition.setByAdditionNew(addition);
                tables.setChangeTableState(cGenel._ButtonName, 2);
                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        orders.masaID = tableId;
                        orders.urunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        orders.AdisyonID = addition.getByAddition(tableId);
                        orders.adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        orders.setSaveOrder(orders);
                    }

                    this.Close();
                    table.Show();
                }
            }
            else if (tables.TableGetbyState(tableId, 2) == true || tables.TableGetbyState(tableId, 4) == true)
            {
                if (lvYeniEklenenler.Items.Count > 0)
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        orders.masaID = tableId;
                        orders.urunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                        orders.AdisyonID = addition.getByAddition(tableId);
                        orders.adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                        orders.setSaveOrder(orders);
                    }

                    if (silinenler.Count > 0)
                    {
                        foreach (string item in silinenler)
                        {
                            orders.setDeleteOrder(Convert.ToInt32(item));
                        }
                    }

                    this.Close();
                    table.Show();
                }
            }
            else if (tables.TableGetbyState(tableId, 3) == true)
            {


                tables.setChangeTableState(cGenel._ButtonName, 4);
                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        orders.masaID = tableId;
                        orders.urunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        orders.AdisyonID = addition.getByAddition(tableId);
                        orders.adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        orders.setSaveOrder(orders);
                    }


                    this.Close();
                    table.Show();
                }
            }
        }

        private void lvSiparisler_DoubleClick(object sender, EventArgs e)
        {
            cSiparis orders = new cSiparis();

            if (lvSiparisler.Items.Count > 0)
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")

                {
                    orders.setDeleteOrder(Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[4].Text));
                }
                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        if (lvYeniEklenenler.Items[i].SubItems[4].Text ==
                            lvSiparisler.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYeniEklenenler.Items.RemoveAt(i);
                        }
                    }
                }

                lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index);
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            if (txtAra.Text != "")
            {
                cUrunCesitleri productTypes = new cUrunCesitleri();

                productTypes.getByProductSearch(lvMenu, Convert.ToInt32(txtAra.Text));
            }
            else
            {
                txtAra.Text = "";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            billfrm bill = new billfrm();

            cGenel._ServisTurNo = 1;
            cGenel._AdisyonId = AdditionId.ToString();
            this.Close();
            bill.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtAdet.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMasa table = new frmMasa();

            this.Close();
            table.Show();
        }


        private void btnAnaYemek1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Ana Yemekleri görüntüle", btnAnaYemek1);
        }

        private void btnIcecek2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("İçecekleri görüntüle", btnIcecek2);
        }

        private void btnTatlilar3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Tatlıları görüntüle", btnTatlilar3);
        }

        private void btnSalatalar4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Salataları görüntüle", btnSalatalar4);
        }

        private void btnFastFood5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Fast Food görüntüle", btnFastFood5);
        }

        private void btnCorba6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Çorbaları görüntüle", btnCorba6);
        }

        private void btnMakarna7_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Makarnaları görüntüle", btnMakarna7);
        }

        private void btnAraSıcak8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Ara Sıcakları görüntüle", btnAraSıcak8);
        }

        private void btnOdeme_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Ödeme yapmak için tıklayınız", btnOdeme);
        }

        private void btnSiparis_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Sipariş oluşturmak için tıklayınız", btnSiparis);
        }

    }
}