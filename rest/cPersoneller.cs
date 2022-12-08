using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace rest
{
    internal class cPersoneller
    {
        cGenel gnl = new cGenel();

        #region Fields

        private int _PersonelID;
        private int _PersonelGorevID;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private bool _PersonelDurum;

        #endregion

        #region Properties

        public int PersonelID
        {
            get { return _PersonelID; }
            set { _PersonelID = value; }
        }

        public int PersonelGorevID
        {
            get { return _PersonelGorevID; }
            set { _PersonelGorevID = value; }
        }

        public string PersonelAd
        {
            get { return _PersonelAd; }
            set { _PersonelAd = value; }
        }

        public string PersonelSoyad
        {
            get { return _PersonelSoyad; }
            set { _PersonelSoyad = value; }
        }

        public string PersonelParola
        {
            get { return _PersonelParola; }
            set { _PersonelParola = value; }
        }

        public string PersonelKullaniciAdi
        {
            get { return _PersonelKullaniciAdi; }
            set { _PersonelKullaniciAdi = value; }
        }

        public bool PersonelDurum
        {
            get { return _PersonelDurum; }
            set { _PersonelDurum = value; }
        }

        #endregion


        public bool personelEntryControl(string password, int userId)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personeller where Id=@Id and PAROLA=@password", con);
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = userId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            return result;
        }


        public void personelGetByInformation(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personeller", con);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cPersoneller p = new cPersoneller();
                p._PersonelID = Convert.ToInt32(dr["ID"]);
                p.PersonelGorevID = Convert.ToInt32(dr["GOREVID"]);
                p._PersonelAd = Convert.ToString(dr["AD"]);
                p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                p._PersonelParola = Convert.ToString(dr["PAROLA"]);
                p._PersonelKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
                p._PersonelDurum = Convert.ToBoolean(dr["Durum"]);
                cb.Items.Add(p);
            }

            dr.Close();
            con.Close();
        }

        public override string ToString()
        {
            return PersonelAd + " " + PersonelSoyad;
        }


        public void personelBilgileriniGetirLv(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select personeller.*,personelGorevleri.GOREV from personeller inner join personelGorevleri on personelGorevleri.ID=personeller.GOREVID where personeller.DURUM=0",
                    con);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;
            }

            dr.Close();
            con.Close();
        }


        public void personelBilgileriniGetirFromIdLv(ListView lv, int perID)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select personeller.*,personelGorevleri.GOREV from personeller inner join personelGorevleri on personelGorevleri.ID=personeller.GOREVID where personeller.DURUM=0 and personeller.ID=@perId",
                    con);
            cmd.Parameters.Add("perId", SqlDbType.Int).Value = perID;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;
            }

            dr.Close();
            con.Close();
        }


        public string personelBilgileriGetirIsim(int perId)
        {
            string sonuc = "";

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select AD + SOYAD from personeller personeller where personeller.DURUM=0 and personeller.ID=@perId",
                    con);
            cmd.Parameters.Add("perId", SqlDbType.Int).Value = perId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            con.Close();


            return sonuc;
        }


        public bool personelSifreDegistir(int personelID, string pass)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update personeller set PAROLA=@pass where ID=@perId", con);
            cmd.Parameters.Add("perId", SqlDbType.Int).Value = personelID;
            cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            con.Close();


            return sonuc;
        }


        public bool personelEkle(cPersoneller cp)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    " Insert into personeller(AD,SOYAD,PAROLA,GOREVID) values(@AD,@SOYAD,@PAROLA,@GOREVID)  ", con);
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            con.Close();


            return sonuc;
        }


        public bool personelGuncelle(cPersoneller cp, int perId)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "update personeller set AD=@AD,SOYAD=@SOYAD,PAROLA=@PAROLA,GOREVID=@GOREVID where ID=@perId) ",
                    con);

            cmd.Parameters.Add("perId", SqlDbType.Int).Value = perId;
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            con.Close();


            return sonuc;
        }


        public bool personelSil(int perId)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("update personeller set DURUM=1 where ID=@perId ", con);

            cmd.Parameters.Add("perId", SqlDbType.Int).Value = perId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            con.Close();


            return sonuc;
        }
    }
}