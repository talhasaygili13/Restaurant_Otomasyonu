using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace rest
{
    internal class cMasalar
    {
        #region Fields

        private int _ID;
        private int _KAPASITE;


        private int _SERVISTURU;
        private int _DURUM;
        private int _ONAY;
        private string _MasaBilgi;

        #endregion

        #region Properties

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public int KAPASITE
        {
            get { return _KAPASITE; }
            set { _KAPASITE = value; }
        }

        public int SERVISTURU
        {
            get { return _SERVISTURU; }
            set { _SERVISTURU = value; }
        }


        public int DURUM
        {
            get { return _DURUM; }
            set { _DURUM = value; }
        }

        public int ONAY
        {
            get { return _ONAY; }
            set { _ONAY = value; }
        }

        public string MasaBilgi
        {
            get { return _MasaBilgi; }
            set { _MasaBilgi = value; }
        }

        #endregion


        cGenel gnl = new cGenel();

        public string SessionSum(int state, string masaId)
        {
            string dt = "";

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd =
                new SqlCommand(
                    "Select TARIH,MASAID from adisyon Right Join masa on adisyon.MASAID=masa.ID where masa.DURUM = @durum and adisyon.DURUM=0 and masa.ID=@masaId",
                    con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@masaId", SqlDbType.Int).Value = Convert.ToInt32(masaId);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }

            return dt;
        }

        public int TableGetbyNumber(string TableValue)
        {
            string masa = TableValue;
            int length = masa.Length;
            if (length == 9)
            {
                return Convert.ToInt32(masa.Substring(length - 2, 2));
            }
            else
            {
                return Convert.ToInt32(masa.Substring(length - 1, 1));
            }
        }

        public bool TableGetbyState(int ButtonName, int state)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM from masa where ID=@TableId and DURUM=@state", con);
            cmd.Parameters.Add("@TableId", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@state", SqlDbType.Int).Value = state;
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
            }
            finally
            {
                con.Dispose();
                con.Close();
            }

            return result;
        }

        public void setChangeTableState(string ButtonName, int state)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update masa Set DURUM=@Durum where ID=@MasaNo ", con);
            string masaNo = "";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string masa = ButtonName;
            int uzunluk = masa.Length;
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            if (uzunluk > 8 || uzunluk == 2)
            {
                masaNo = masa.Substring(uzunluk - 2, 2);
            }
            else
            {
                masaNo = masa.Substring(uzunluk - 1, 1);
            }


            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = masaNo;
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }


        public void masaKapasitesiVeDurumGetir(ComboBox cb)
        {
            cb.Items.Clear();
            string durum = "";

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(" Select * from masa", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cMasalar c = new cMasalar();
          
                durum = "Rezerve";


                c._KAPASITE = Convert.ToInt32(dr["KAPASITE"]);

                c._MasaBilgi = "Masa No: " + dr["ID"].ToString() + " Kapasitesi : " + dr["KAPASITE"].ToString();
                c._ID = Convert.ToInt32(dr["ID"]);
                cb.Items.Add(c);
                //  }
            }


            dr.Close();
            con.Dispose();
            con.Close();
        }

        string getDurum(int text)
        {
            switch (text)
            {
                case 1:
                    return "Boş";
                    break;
                case 2:
                    return "Dolu";
                    break;
                case 3:
                    return "Rezerve";
                    break;
                case 4:
                    return "Açık Rezerve";
                    break;
                default:
                    return "Tanımlanmamış durum";
            }
        }

        public void masaDurumGetirLv(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from masa", con);

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
                    lv.Items[sayac].SubItems.Add(dr["KAPASITE"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SERVİSTURU"].ToString());
                    lv.Items[sayac].SubItems.Add(getDurum(Convert.ToInt32(dr["DURUM"])));

                    lv.Items[sayac].SubItems.Add(dr["ONAY"].ToString());
        

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

        public override string ToString()
        {
            return MasaBilgi;
        }
    }
}