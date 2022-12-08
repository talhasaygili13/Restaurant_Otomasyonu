using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace rest
{
    internal class cMusteriler
    {
        cGenel gnl = new cGenel();

        #region Fields

        private int _musteriId;
        private string _musteriad;
        private string _musterisoyad;
        private string _telefon;
        private string _adres;
        private string _email;

        #endregion

        #region Properties

        public int MusteriId
        {
            get { return _musteriId; }
            set { _musteriId = value; }
        }

        public string Musteriad
        {
            get { return _musteriad; }
            set { _musteriad = value; }
        }

        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }

        public string Adres
        {
            get { return _adres; }
            set { _adres = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string MusteriSoyad
        {
            get { return _musterisoyad; }
            set { _musterisoyad = value; }
        }

        #endregion


        public bool MusteriKontrol(string tlf)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "MusteriKontrol";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@telefon", SqlDbType.VarChar).Value = tlf;
            cmd.Parameters.Add("@sonuc", SqlDbType.Int);
            cmd.Parameters["@sonuc"].Direction = ParameterDirection.Output;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    sonuc = Convert.ToBoolean(cmd.Parameters["@sonuc"].Value);
                }
                catch (SqlException ex)
                {
                    string hata = ex.Message;
                }
                finally
                {
                    //con.Dispose();
                    con.Close();
                }
            }

            return sonuc;
        }


        public int MusteriEkle(cMusteriler m)
        {
            //musteriEkleme frm = new musteriEkleme();
            //foreach (Control item in frm.Controls)
            //{
            //    if (item is TextBox)
            //    {
            //        TextBox tbox = (TextBox)item;
            //        tbox.Clear();
            //    }
            //}
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Insert Into musteriler(AD,SOYAD,TELEFON,ADRES,EMAIL) values(@ad,@soyad,@telefon,@adres,@email); select SCOPE_IDENTITY()",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("ad", SqlDbType.VarChar).Value = m._musteriad;
                cmd.Parameters.Add("soyad", SqlDbType.VarChar).Value = m._musterisoyad;
                cmd.Parameters.Add("telefon", SqlDbType.VarChar).Value = m._telefon;
                cmd.Parameters.Add("adres", SqlDbType.VarChar).Value = m._adres;
                cmd.Parameters.Add("email", SqlDbType.VarChar).Value = m._email;
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


        public bool musteriBilgileriGuncelle(cMusteriler m)
        {
            musteriEkleme frm = new musteriEkleme();
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Update musteriler set AD=@ad,SOYAD=@soyad,TELEFON=@telefon,ADRES=@adres,EMAIL=@email where ID=@musteriId",
                    con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("ad", SqlDbType.VarChar).Value = m._musteriad;
                cmd.Parameters.Add("soyad", SqlDbType.VarChar).Value = m._musterisoyad;
                cmd.Parameters.Add("telefon", SqlDbType.VarChar).Value = m._telefon;
                cmd.Parameters.Add("adres", SqlDbType.VarChar).Value = m._adres;
                cmd.Parameters.Add("email", SqlDbType.VarChar).Value = m._email;
                cmd.Parameters.Add("musteriId", SqlDbType.Int).Value = m._musteriId;
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

                frm.Controls.Clear();
            }


            return sonuc;
        }


        public void musterleriGetir(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteriler", con);

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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());
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


        // müşterileri idye göre getir
        public void musterilerigetirID(int musteriId, TextBox ad, TextBox soyad, TextBox tlf, TextBox adres,
            TextBox email)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteriler where ID=@musteriID", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriID", SqlDbType.Int).Value = musteriId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ad.Text = dr["AD"].ToString();
                        soyad.Text = dr["SOYAD"].ToString();
                        tlf.Text = dr["TELEFON"].ToString();
                        adres.Text = dr["ADRES"].ToString();
                        email.Text = dr["EMAIL"].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            dr.Close();
            con.Dispose();
            con.Close();
        }


        public void musteriGetirAd(ListView lv, string musteriAd)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteriler where AD like @musteriAd + '%'", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriAd", SqlDbType.VarChar).Value = musteriAd;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                        lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());

                        sayac++;
                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            dr.Close();
            con.Dispose();
            con.Close();
        }


        public void musteriGetirSoyad(ListView lv, string MusteriSoyad)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteriler where SOYAD like @MusteriSoyad + '%'", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("MusteriSoyad", SqlDbType.VarChar).Value = MusteriSoyad;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                        lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());

                        sayac++;
                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            dr.Close();
            con.Dispose();
            con.Close();
        }


        public void musteriGetirTlf(ListView lv, string tlf)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteriler where TELEFON like @tlf + '%'", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("tlf", SqlDbType.VarChar).Value = tlf;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                        lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());

                        sayac++;
                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            dr.Close();
            con.Dispose();
            con.Close();
        }


        public void musteriGetirAdres(ListView lv, string adres)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteriler where ADRES like @adres + '%'", con);

            SqlDataReader dr = null;
            cmd.Parameters.Add("adres", SqlDbType.VarChar).Value = adres;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int sayac = 0;
                    while (dr.Read())
                    {
                        lv.Items.Add(Convert.ToInt32(dr["ID"]).ToString());
                        lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());

                        sayac++;
                    }
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }

            dr.Close();
            con.Dispose();
            con.Close();
        }


        public void musteriIdAl(int musteriID)

        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select MUSTERIID from rezarvasyonlar", con);

            SqlDataReader dr = null;


            try
            {
                if (con.State == ConnectionState.Closed)

                    con.Open();

                cmd.Parameters.Add("musteriID", SqlDbType.Int).Value = musteriID;
                dr = cmd.ExecuteReader();
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