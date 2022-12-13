using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    internal class cUrunCesitleri
    {
        cGenel gnl = new cGenel();

        #region Fields

        private int _UrunTurNo;
        private string _KategoriAd;
        private string _Aciklama;

        #endregion


        #region Properties

        public int UrunTurNo
        {
            get { return _UrunTurNo; }
            set { _UrunTurNo = value; }
        }

        public string KategoriAd
        {
            get { return _KategoriAd; }
            set { _KategoriAd = value; }
        }

        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }

        #endregion


        public void getByProductTypes(ListView Cesitler, Button btn)
        {
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand cmmd =
                new SqlCommand(
                    "Select URUNAD,UCRET,urunler.ID from kategoriler Inner Join urunler on kategoriler.ID=urunler.KATEGORIID where urunler.KATEGORIID=@KATEGORIID",
                    conn);

            string aa = btn.Name;
            int uzunluk = aa.Length;

            cmmd.Parameters.Add("@KATEGORIID", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            char ayrac = ',';
            SqlDataReader dr = cmmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["UCRET"].ToString().Split(',')[0].Trim());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }

        public void getByProductSearch(ListView Cesitler, int txt)
        {
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand cmmd = new SqlCommand("Select * from urunler where ID=@ID ", conn);


            cmmd.Parameters.Add("@ID", SqlDbType.Int).Value = txt;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = cmmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["UCRET"].ToString().Split(',')[0].Trim());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }

            dr.Close();
            conn.Dispose();
            conn.Close();
        }

        //urun cesitlerini getir combobox
        public void urunCesitleriniGetir(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from kategoriler where DURUM=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cUrunCesitleri uc = new cUrunCesitleri();
                    uc._UrunTurNo = Convert.ToInt32(dr["ID"]);
                    uc._KategoriAd = dr["KATEGORIADI"].ToString();
                    uc._Aciklama = dr["ACIKLAMA"].ToString();
                    cb.Items.Add(uc);
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }


        //urun cesitlerini getir listview
        public void urunCesitleriniGetir(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kategoriler where DURUM=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());

                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }


        // urun cesitlerini getir listView arama
        public void urunCesitleriniGetir(ListView lv, string source)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select * from kategoriler where kategoriler.DURUM=0 and KATEGORIADI like '%' + @source + '%' ",
                    con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@source", SqlDbType.VarChar).Value = source;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());

                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }


        //urun cesitlerini ekleme
        public int urunKategoriEkle(cUrunCesitleri u)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand("Insert Into kategoriler(KATEGORIADI,ACIKLAMA) values(@KATEGORIADI,@ACIKLAMA)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("KATEGORIADI", SqlDbType.VarChar).Value = u._KategoriAd;
                cmd.Parameters.Add("ACIKLAMA", SqlDbType.VarChar).Value = u._Aciklama;
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }


        //urun cesitlerini güncelle

        public int urunKategoriGuncelle(cUrunCesitleri u)
        {
            musteriEkleme frm = new musteriEkleme();
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand("Update kategoriler set KATEGORIADI=@KATEGORIADI,ACIKLAMA=@ACIKLAMA where ID=@KATID",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("KATEGORIADI", SqlDbType.VarChar).Value = u._KategoriAd;
                cmd.Parameters.Add("ACIKLAMA", SqlDbType.VarChar).Value = u._Aciklama;
                cmd.Parameters.Add("KATID", SqlDbType.Int).Value = u._UrunTurNo;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();

                frm.Controls.Clear();
            }

            return sonuc;
        }


        //urun cesitlerini sil
        public int urunKategoriSil(int id)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update kategoriler set DURUM = 1 from kategoriler where ID = @KATID ",
                con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("KATID", SqlDbType.Int).Value = id;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return sonuc;
        }


        public void urunSilKategoriDurum(int id)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            // SqlCommand cmd = new SqlCommand("Update kategoriler set DURUM=1  where ID=@KATID", con);
            // SqlCommand cmd = new SqlCommand("update urunler set DURUM=1 from urunler Inner Join kategoriler on kategoriler.ID=KATEGORIID where kategoriler.DURUM=1", con);
            SqlCommand cmmd = new SqlCommand(
                "update urunler set DURUM=1 from urunler Inner Join kategoriler on kategoriler.ID=urunler.KATEGORIID where kategoriler.DURUM=1 and urunler.KATEGORIID=kategoriler.ID",
                con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmmd.Parameters.Add("KATID", SqlDbType.Int).Value = id;
                Convert.ToInt32(cmmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }


        public override string ToString()
        {
            return KategoriAd;
        }
    }
}