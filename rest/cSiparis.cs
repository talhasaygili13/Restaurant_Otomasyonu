using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace rest
{
    internal class cSiparis
    {
        cGenel gnl = new cGenel();


        #region Fields

        private int _Id;
        private int _AdisyonID;
        private int _urunId;
        private int _adet;
        private int _masaID;

        #endregion

        #region Properties

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int AdisyonID
        {
            get { return _AdisyonID; }
            set { _AdisyonID = value; }
        }

        public int urunId
        {
            get { return _urunId; }
            set { _urunId = value; }
        }

        public int adet
        {
            get { return _adet; }
            set { _adet = value; }
        }

        public int masaID
        {
            get { return _masaID; }
            set { _masaID = value; }
        }

        #endregion


        //Siparişleri getir
        public void getByOrder(ListView lv, int AdisyonId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select urunler.URUNAD,urunler.UCRET, satislar.ID,satislar.URUNID,satislar.ADET from satislar Inner Join urunler on satislar.URUNID=Urunler.ID Where ADISYONID=@AdisyonId",
                    con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = AdisyonId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems
                        .Add(Convert.ToString(Convert.ToDecimal(dr["UCRET"].ToString().Split(',')[0].Trim()) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());
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

        public bool setSaveOrder(cSiparis Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Insert Into satislar(ADISYONID,URUNID,ADET,MASAID) values(@AdisyonNo,@UrunId,@Adet,@masaId)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("AdisyonNo", SqlDbType.Int).Value = Bilgiler._AdisyonID;
                cmd.Parameters.Add("UrunId", SqlDbType.Int).Value = Bilgiler._urunId;
                cmd.Parameters.Add("Adet", SqlDbType.Int).Value = Bilgiler._adet;
                cmd.Parameters.Add("masaId", SqlDbType.Int).Value = Bilgiler._masaID;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
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

        public void setDeleteOrder(int satisId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete from satislar where ID=@SatisId", con);

            cmd.Parameters.Add("@SatisId", SqlDbType.Int).Value = satisId;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }


        public decimal GenelToplamBul(int musteriId)
        {
            decimal genelToplam = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(
                " select sum(dbo.satislar.ADET * dbo.urunler.UCRET) as ucret from dbo.musteriler inner join dbo.paketSiparis on dbo.musteriler.ID=paketSiparis.MUSTERIID inner join adisyon on adisyon.ID=paketSiparis.ADISYONID inner join satislar on dbo.satislar.ADISYONID =adisyon.ID inner join dbo.urunler on dbo.satislar.URUNID=dbo.urunler.ID where (dbo.paketSiparis.MUSTERIID = @musteriId) and (dbo.paketSiparis.DURUM =0)",
                con);
            cmd.Parameters.Add("musteriId", SqlDbType.Int).Value = musteriId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                genelToplam = Convert.ToDecimal(cmd.ExecuteScalar());
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


            return genelToplam;
        }


        public void adisyonPaketSiparisDetaylari(ListView lv, int adisyonId)
        {
            lv.Items.Clear();
            decimal genelToplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(
                "select satislar.ID as satisID,urunler.URUNAD,urunler.UCRET,satislar.ADET from satislar Inner join adisyon on adisyon.ID=satislar.ADISYONID inner join urunler on urunler.ID=satislar.URUNID where satislar.ADISYONID=@adisyonId",
                con);
            cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonId;
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                int i = 0;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lv.Items.Add(dr["satisId"].ToString());
                    lv.Items[i].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[i].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[i].SubItems.Add(dr["UCRET"].ToString().Split(',')[0].Trim());
                    i++;
                }
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
    }
}