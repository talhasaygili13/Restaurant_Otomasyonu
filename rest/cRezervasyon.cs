using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace rest
{
    internal class cRezervasyon
    {
        cGenel gnl = new cGenel();

        #region Fields

        private int _ID;
        private int _TableId;
        private int _ClientId;
        private DateTime _Date;
        private int _ClientCount;
        private string _Description;
        private int _AdditionId;

        #endregion

        #region Properties

        public int TableId
        {
            get { return _TableId; }
            set { _TableId = value; }
        }

        public int ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public int AdditionId
        {
            set { _AdditionId = value; }
            get { return _AdditionId; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int ClientCount
        {
            get { return _ClientCount; }
            set { _ClientCount = value; }
        }

        #endregion


        //MusteriId masa numarasına göre
        public int getByClientIdFromRezervasyon(int tableId)
        {
            int clientId = 0;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    " Select top 1 MUSTERIID from rezarvasyonlar where MASAID=@masaId order by MUSTERIID desc", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("masaId", SqlDbType.Int).Value = tableId;

                clientId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }


            return clientId;
        }

        // hesap kapatırken masayı boşalt
        public bool rezarvationClose(int adisyonID)
        {
            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update rezarvasyonlar set DURUM=1 where ADISYONID=@adisyonId ", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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


            return result;
        }


        //Rezervasyonları getir
        public void musteriIdGetirFromRezervasyon(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand cmmd =
                new SqlCommand(
                    "Select rezarvasyonlar.MUSTERIID,(AD + SOYAD) as musteri from rezarvasyonlar Inner Join musteriler On rezarvasyonlar.MUSTERIID=musteriler.ID where rezarvasyonlar.DURUM = 0",
                    conn);


            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = cmmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["musteri"].ToString());
                i++;
            }

            dr.Close();
            conn.Dispose();
            conn.Close();
        }


        //eski rezervasyonları getir
        public void eskiRezervasyonlariGetir(ListView lv, int musteriId)
        {
            lv.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand cmmd = new SqlCommand(
                "Select rezarvasyonlar.MUSTERIID,AD,SOYAD,ADISYONID,TARIH from rezarvasyonlar Inner Join musteriler On rezarvasyonlar.MUSTERIID=musteriler.ID where rezarvasyonlar.MUSTERIID=@musteriId and rezarvasyonlar.DURUM = 0 order by rezarvasyonlar.ID Desc",
                conn);

            cmmd.Parameters.Add("musteriId", SqlDbType.Int).Value = musteriId;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlDataReader dr = cmmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["TARIH"].ToString());
                lv.Items[i].SubItems.Add(dr["ADISYONID"].ToString());

                i++;
            }

            dr.Close();
            conn.Dispose();
            conn.Close();
        }


        // en son rezervasyon tarihini getir
        public DateTime enSonRezervasyonTarihi(int musteriId)
        {
            DateTime tarih = DateTime.Now;
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand cmmd =
                new SqlCommand(
                    "Select TARIH from rezarvasyonlar where rezarvasyonlar.MUSTERIID=@musteriId and rezarvasyonlar.DURUM = 1 order by rezarvasyonlar.ID Desc",
                    conn);

            cmmd.Parameters.Add("musteriId", SqlDbType.Int).Value = musteriId;

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            tarih = Convert.ToDateTime(cmmd.ExecuteScalar());


            conn.Dispose();
            conn.Close();

            return tarih;
        }


        // acik rezervasyon sayisini getir
        public int acikRezervasyonSayisi()
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select count(*) from rezarvasyonlar where rezarvasyonlar.DURUM = 0", con);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            con.Dispose();
            con.Close();
            return sonuc;
        }


        //rezervasyon acik mi kontrol
        public bool rezarvationAcikMiKontrol(int musteriId)
        {
            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select top 1 rezarvasyonlar.ID from rezarvasyonlar where MUSTERIID=@musteriId and DURUM=0 order by ID desc ",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("musteriId", SqlDbType.Int).Value = musteriId;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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

            return result;
        }


        //rezervasyon ac
        public bool rezarvationAc(cRezervasyon r)
        {
            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Insert Into rezarvasyonlar(MUSTERIID,MASAID,ADISYONID,KISISAYISI,TARIH,ACIKLAMA,DURUM) values(@MUSTERIID,@MASAID,@ADISYONID,@KISISAYISI,@TARIH,@ACIKLAMA,0)",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("MUSTERIID", SqlDbType.Int).Value = r._ClientId;
                cmd.Parameters.Add("MASAID", SqlDbType.Int).Value = r._TableId;
                cmd.Parameters.Add("ADISYONID", SqlDbType.Int).Value = r._AdditionId;
                cmd.Parameters.Add("KISISAYISI", SqlDbType.Int).Value = r._ClientCount;
                cmd.Parameters.Add("TARIH", SqlDbType.Date).Value = r._Date;
                cmd.Parameters.Add("ACIKLAMA", SqlDbType.VarChar).Value = r._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
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

            return result;
        }


        //rezerve masanın ıd getir
        public int rezerveMasaIdGetir(ListView lv, int musteriId)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select rezarvasyonlar.MASAID from rezarvasyonlar INNER JOIN adisyon on rezarvasyonlar.ADISYONID=adisyon.ID where (rezarvasyonlar.DURUM = 1) and adisyon.DURUM=0 and rezarvasyonlar.MUSTERIID=@musteriId",
                    con);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                cmd.Parameters.Add("musteriId", SqlDbType.Int).Value = musteriId;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            con.Dispose();
            con.Close();
            return sonuc;
        }


        public void rezervasyonGetir(ListView lv, int masaId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from rezarvasyonlar where MASAID=@masaId", con);

            SqlDataReader dr = null;


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                cmd.Parameters.Add("masaId", SqlDbType.Int).Value = masaId;

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MASAID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KISISAYISI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TARIH"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToBoolean(dr["DURUM"]) ? "Kapandı" : "Açık");

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


        public void rezervasyonGetirMusteriId(ListView lv, int mId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from rezarvasyonlar where MUSTERIID=@mId", con);

            SqlDataReader dr = null;


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;

                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MASAID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KISISAYISI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TARIH"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToBoolean(dr["DURUM"]) ? "Kapandı" : "Açık");

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


        public void rezervasyonKontrol(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from rezarvasyonlar where DURUM=0", con);

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
                    lv.Items[sayac].SubItems.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MASAID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KISISAYISI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TARIH"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToBoolean(dr["DURUM"]) ? "Kapandı" : "Açık");

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


        public void rezerv(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(
                "Select * from rezarvasyonlar where (CONVERT(datetime,TARIH,104) between convert(datetime,@Baslangic,104) and convert(datetime,@Bitis,104)) ",
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
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MASAID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KISISAYISI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TARIH"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToBoolean(dr["DURUM"]) ? "Kapandı" : "Açık");

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


        public void rezervsayonAll(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from rezarvasyonlar", con);

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
                    lv.Items[sayac].SubItems.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["MASAID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KISISAYISI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TARIH"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToBoolean(dr["DURUM"]) ? "Kapandı" : "Açık");

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


        public bool rezervasyonKapatKontrol(ListView lv, int adisyonID)
        {
            lv.Items.Clear();
            bool result = false;


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update rezarvasyonlar set DURUM=1 where ADISYONID=@adisyonId ", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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


            return result;
        }
    }
}