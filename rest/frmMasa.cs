﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    public partial class frmMasa : Form
    {

        public frmMasa()
        {
            InitializeComponent();
        }

        cGenel gnl = new cGenel();


        private void frmMasa_Load(object sender, EventArgs e)
        {
            cMasalar table = new cMasalar();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM,ID from masa", con);
            SqlDataReader dr = null;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "1")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.bos);
                        }

                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2")
                        {
                            DateTime dt1 = Convert.ToDateTime(table.SessionSum(2, dr["ID"].ToString()));
                            DateTime dt2 = DateTime.Now;
                            string st1 = Convert.ToDateTime(table.SessionSum(2, dr["ID"].ToString())).ToShortTimeString();
                            string st2 = DateTime.Now.ToShortTimeString();

                            DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                            DateTime t2 = dt2.AddMinutes((DateTime.Parse(st2).TimeOfDay.TotalMinutes));

                            var fark = t2 - t1;


                            item.Text = String.Format("{0}{1}{2}",
                                            fark.Days > 0 ? string.Format("{0} Gün", fark.Days) : "",
                                            fark.Hours > 0 ? string.Format("{0} Saat", fark.Hours) : "",
                                            fark.Minutes > 0 ? string.Format("{0} Dakika", fark.Minutes) : "")+
                                        "Masa" +
                                        dr["ID"].ToString();


                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.dolu);
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "3")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.reserved);
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "4")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.table); //açık rezerve
                        }
                    }
                }
            }
        }


        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();

            this.Close();
            menu.Show();
        }

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa1.Text.Length;
            cGenel._ButtonValue = btnMasa1.Text.Substring(uzunluk - 5, 5);
            cGenel._ButtonName = btnMasa1.Name;
            this.Close();
            bill.Show();
        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa2.Text.Length;
            cGenel._ButtonValue = btnMasa2.Text.Substring(uzunluk - 5, 5);
            cGenel._ButtonName = btnMasa2.Name;
            this.Close();
            bill.Show();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa3.Text.Length;
            cGenel._ButtonValue = btnMasa3.Text.Substring(uzunluk - 5, 5);
            cGenel._ButtonName = btnMasa3.Name;
            this.Close();
            bill.Show();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa4.Text.Length;
            cGenel._ButtonValue = btnMasa4.Text.Substring(uzunluk - 5, 5);
            cGenel._ButtonName = btnMasa4.Name;
            this.Close();
            bill.Show();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa5.Text.Length;
            cGenel._ButtonValue = btnMasa5.Text.Substring(uzunluk - 5, 5);
            cGenel._ButtonName = btnMasa5.Name;
            this.Close();
            bill.Show();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa6.Text.Length;
            cGenel._ButtonValue = btnMasa6.Text.Substring(uzunluk - 5, 5);
            cGenel._ButtonName = btnMasa6.Name;
            this.Close();
            bill.Show();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa7.Text.Length;
            cGenel._ButtonValue = btnMasa7.Text.Substring(uzunluk - 5, 5);
            cGenel._ButtonName = btnMasa7.Name;
            this.Close();
            bill.Show();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa8.Text.Length;
            cGenel._ButtonValue = btnMasa8.Text.Substring(uzunluk - 5, 5);
            cGenel._ButtonName = btnMasa8.Name;
            this.Close();
            bill.Show();
        }

        private void btnMasa9_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa9.Text.Length;
            cGenel._ButtonValue = btnMasa9.Text.Substring(uzunluk - 5, 5);
            cGenel._ButtonName = btnMasa9.Name;
            this.Close();
            bill.Show();
        }

        private void btnMasa10_Click(object sender, EventArgs e)
        {
            SiparisFrm bill = new SiparisFrm();

            int uzunluk = btnMasa10.Text.Length;
            cGenel._ButtonValue = btnMasa10.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa10.Name;
            this.Close();
            bill.Show();
        }
    }
}