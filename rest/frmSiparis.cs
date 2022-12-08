using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    public partial class frmSiparis : Form
    {
        public frmSiparis()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
        private void frmSiparis_Load(object sender, EventArgs e)
        {
            lblMasaNo.Text = cGenel._ButtonValue;
            cMasalar ms = new cMasalar();
            tableId = ms.TableGetbyNumber(cGenel._ButtonName);
            if (ms.TableGetbyState(tableId, 2) == true || ms.TableGetbyState(tableId, 4) == true)
            {
                cAdisyon Ad = new cAdisyon();
               AdditionId = Ad.getByAddition(tableId);
                cSiparis orders = new cSiparis();
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

        ArrayList silinenler = new ArrayList();
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMasa frmMasa = new frmMasa();
            this.Close();
            frmMasa.Show();
        }

        private void btn5_Click(object sender, EventArgs e)
        {

        }

        private void btn4_Click(object sender, EventArgs e)
        {

        }
        cUrunCesitleri Uc = new cUrunCesitleri();

        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnAnaYemek1);
        }

        private void btnIcecek2_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnIcecek2);

        }

        private void btnTatli3_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnTatli3);

        }

        private void btnSalata4_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnSalata4);

        }

        private void btnFastFood5_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnFastFood5);

        }

        private void btnCorba6_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnCorba6);

        }

        private void btnMakarna7_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnMakarna7);

        }

        private void btnAraSıcak8_Click(object sender, EventArgs e)
        {
            Uc.getByProductTypes(lvMenu, btnAraSıcak8);

        }
        int sayac = 0;
        int sayac2 = 0;
        private void lvMenu_DoubleClick(object sender, EventArgs e)
         {
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            }
            
            if (lvMenu.Items.Count>0)
            {
                sayac = lvSiparisler.Items.Count;
                lvSiparisler.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparisler.Items[sayac].SubItems.Add(txtAdet.Text);
                lvSiparisler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());
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
             cMasalar masa = new cMasalar();
            cAdisyon newAddition = new cAdisyon();
            cSiparis saveOrder = new cSiparis();
            frmMasa ms = new frmMasa();                                                                                                                          
            bool sonuc = false;
            if (masa.TableGetbyState(tableId, 1) == true)
            {
                newAddition.ServisTurNo = 1;
                newAddition.PersonelId = 1;
                newAddition.MasaId = tableId;
                newAddition.Tarih = DateTime.Now;

                sonuc = newAddition.setByAdditionNew(newAddition);
                masa.setChangeTableState(cGenel._ButtonName, 2);
                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.masaID = tableId;
                        saveOrder.urunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    this.Close();
                    ms.Show();
                }
            }
            else if (masa.TableGetbyState(tableId, 2) == true || masa.TableGetbyState(tableId, 4) == true)
            {
                if (lvYeniEklenenler.Items.Count > 0)
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        saveOrder.masaID = tableId;
                        saveOrder.urunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    if (silinenler.Count > 0)
                    {
                        foreach (string item in silinenler)
                        {
                            saveOrder.setDeleteOrder(Convert.ToInt32(item));
                        }
                    }
                    this.Close();
                    ms.Show();
                }
            }
            else if (masa.TableGetbyState(tableId, 3) == true)
            {
                newAddition.ServisTurNo = 1;
                newAddition.PersonelId = 1;
                newAddition.MasaId = tableId;
                newAddition.Tarih = DateTime.Now;

                sonuc = newAddition.setByAdditionNew(newAddition);
                masa.setChangeTableState(cGenel._ButtonName, 4);
                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.masaID = tableId;
                        saveOrder.urunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonID = newAddition.getByAddition(tableId);
                        saveOrder.adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    this.Close();
                    ms.Show();
                }
            }
            }
         
        private void lvSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (lvSiparisler.Items.Count > 0)
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")

                {
                    cSiparis saveOrder = new cSiparis();
                    saveOrder.setDeleteOrder(Convert.ToInt32(lvSiparisler.Items[0].SubItems[4].Text));

                }
                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        if (lvYeniEklenenler.Items[i].SubItems[4].Text == lvSiparisler.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYeniEklenenler.Items.RemoveAt(i);
                        }
                    }
                }
                lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index);
            }
        }

        private void lblMasaNo_Click(object sender, EventArgs e)
        {

        }

        private void btn9_Click(object sender, EventArgs e)
        {

        }

        private void lvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

         }

        private void lvSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            cUrunCesitleri cu = new cUrunCesitleri();
            if (txtAra.Text != "")
            {
                cu.getByProductSearch(lvMenu, Convert.ToInt32(txtAra.Text));
            }
            else
            {
                txtAra.Text = "";
            }


        }

        private void frmSiparis_Load_1(object sender, EventArgs e)
        {

        }
    }
}
