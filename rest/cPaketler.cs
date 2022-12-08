using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest
{
    internal class cPaketler
    {
        cGenel gnl = new cGenel();

        #region Fields

        private int _ID;
        private int _AdditionID;
        private int _ClientID;
        private string _Description;
        private int _State;
        private int _PayTypeid;

        #endregion


        #region Properties

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int AdditionID
        {
            get { return _AdditionID; }
            set { _AdditionID = value; }
        }

        public int ClientID
        {
            get { return _ClientID; }
            set { _ClientID = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public int State
        {
            get { return _State; }
            set { _State = value; }
        }

        public int PayTypeid
        {
            get { return _PayTypeid; }
            set { _PayTypeid = value; }
        }

        #endregion

        // Paket Servisi Açma
        public bool OrderServiceOpen(cPaketler order)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Insert Into paketSiparis(ADISYONID,MUSTERIID,ODEMETURID,ACIKLAMA)values(@ADISYONID,@MUSTERIID,@ODEMETURID,@ACIKLAMA)",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ADISYONID", SqlDbType.Int).Value = order._AdditionID;
                cmd.Parameters.Add("@MUSTERIID", SqlDbType.Int).Value = order._ClientID;
                cmd.Parameters.Add("@ODEMETURID", SqlDbType.Int).Value = order._PayTypeid;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = order._Description;
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

        // PAket Servisi Kapatma
        public void OrderServiceClose(int AdditionID)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Update paketSiparis set paketSiparis.DURUM=1 from paketSiparis Inner Join adisyon on paketSiparis.ADISYONID=adisyon.ID where paketSiparis.ADISYONID=@AdditionID",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@AdditionID", SqlDbType.Int).Value = AdditionID;

                Convert.ToBoolean(cmd.ExecuteNonQuery());
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

// Açılan adisyon ve paket sipariş ait ön girilen odeme tur ıd
        public int OdemeTurIdGetir(int additionId)
        {
            int odemeTurID = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select paketSiparis.ODEMETURID from paketSiparis Inner Join adisyon on paketSiparis.ADISYONID=adisyon.ID where adisyon.ID=@additionId ",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@additionId", SqlDbType.Int).Value = additionId;

                odemeTurID = Convert.ToInt32(cmd.ExecuteScalar());
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

            return odemeTurID;
        }

        // Sipariş Kontrol için musteriye ait olan en son adisyon nosunu getirme

        // bir müşteriye ait 2 tane siparisin açık olamayacağını belirtiyoruz.
        public int musteriSonAdisyonIDGetir(int musteriID)
        {
            int no = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    " Select adisyon.ID from adisyon Inner Join adisyon on paketSiparis.ADISYONID=Adisyon.ID where (adisyon.DURUM=0) and (paketSiparis.DURUM=0) and paketSiparis.MUSTERIID=@musteriID",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@musteriID", SqlDbType.Int).Value = musteriID;

                no = Convert.ToInt32(cmd.ExecuteScalar());
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

            return no;
        }

        // Musteri Arama Ekranında Adisyonbul butonu adisyon açık mı değil mi kontrol et
        public bool getCheckOpenAdditionID(int additionID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from adisyon where (DURUM=0) and (ID=@additionID)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@additionID", SqlDbType.Int).Value = additionID;

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