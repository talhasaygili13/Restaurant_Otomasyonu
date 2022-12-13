using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    internal class cUrunler
    {
        cGenel gnl = new cGenel();

        #region Fields

        private int _urunid;
        private int _urunturno;
        private string _urunad;
        private decimal _fiyat;
        private string _aciklama;

        #endregion


        #region Properties

        public int Urunid
        {
            get { return _urunid; }
            set { _urunid = value; }
        }

        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }

        public string Urunad
        {
            get { return _urunad; }
            set { _urunad = value; }
        }

        public decimal Fiyat
        {
            get { return _fiyat; }
            set { _fiyat = value; }
        }

        public int Urunturno
        {
            get { return _urunturno; }
            set { _urunturno = value; }
        }

        #endregion,

        //urun adına göre listele
        public void urunleriListeleByUrunAdi(ListView lv, string urunAdi)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    " Select urunler.* , KATEGORIADI from urunler Inner Join kategoriler on kategoriler.ID = urunler.KATEGORIID where urunler.DURUM=0 and URUNAD like '%' + @urunAdi + '%'",
                    con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("urunAdi", SqlDbType.VarChar).Value = urunAdi;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["UCRET"].ToString().Split(',')[0].Trim()));
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


        //urun ekle      
        public int urunEkle(cUrunler u)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Insert Into urunler(URUNAD,KATEGORIID,ACIKLAMA,UCRET) values(@urunAd,@katId,@aciklama,@ucret)",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("urunAd", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("katId", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("ucret", SqlDbType.Money).Value = u._fiyat;

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

        //urunler ve kategorileri listele
        public void urunleriListele(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select urunler.* , KATEGORIADI from urunler Inner Join kategoriler on kategoriler.ID=urunler.KATEGORIID where urunler.DURUM =0",
                    con);
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["UCRET"].ToString().Split(',')[0].Trim()));
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


        public int urunGuncelle(cUrunler u)
        {
            musteriEkleme frm = new musteriEkleme();
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Update urunler set URUNAD=@urunad,KATEGORIID=@katID,ACIKLAMA=@aciklama,UCRET=@fiyat where ID=@urunID",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("urunad", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("katID", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("fiyat", SqlDbType.Money).Value = u._fiyat;
                cmd.Parameters.Add("urunID", SqlDbType.Int).Value = u._urunid;
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


        //urunleri sil
        public int urunSil(cUrunler u, int kat)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            string sql = "Update urunler set DURUM=1 where urunler.ID=@urunID ";
            //if (kat == 0)

            //    sql += "KATEGORIID=@urunID";
            //    else sql += "urunler.ID=urunID";

            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("urunID", SqlDbType.Int).Value = u._urunid;
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


        //urunleri Idye göre listele
        public void urunleriListeleByUrunID(ListView lv, int urunId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select urunler.* , KATEGORIADI from urunler Inner Join kategoriler on kategoriler.ID=urunler.KATEGORIID where urunler.DURUM =0 and urunler.KATEGORIID=@urunID ",
                    con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = urunId;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["UCRET"].ToString().Split(',')[0].Trim()));
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


        //bütün ürün kategorilerini getir 2 tarih arası
        public void urunleriListeleIstatistiklereGore(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(
                "Select top 10 urunler.URUNAD , sum(satislar.ADET) as adeti FROM kategoriler Inner Join urunler on kategoriler.ID = urunler.KATEGORIID Inner Join satislar on urunler.ID=satislar.URUNID Inner Join adisyon on satislar.ADISYONID =adisyon.ID where (CONVERT(datetime,TARIH,104) between convert(datetime,@Baslangic,104) and convert(datetime,@Bitis,104)) group by urunler.URUNAD order by adeti desc",
                con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
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


        //belirli kategoriye ait ürünleri listele
        public void urunleriListeleIstatistiklereGoreUrunId(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis,
            int urunKatId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(
                "Select top 10 urunler.URUNAD , sum(satislar.ADET) as adeti FROM kategoriler Inner Join urunler on kategoriler.ID = urunler.KATEGORIID Inner Join satislar on urunler.ID=satislar.URUNID Inner Join adisyon on satislar.ADISYONID =adisyon.ID where (CONVERT(datetime,TARIH,104) between convert(datetime,@Baslangic,104) and convert(datetime,@Bitis,104)) and(urunler.KATEGORIID=@katId) group by urunler.URUNAD order by adeti desc",
                con);
            SqlDataReader dr = null;

            cmd.Parameters.Add("@Baslangic", SqlDbType.VarChar).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.VarChar).Value = Bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = urunKatId;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
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
    }
}