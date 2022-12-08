using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    internal class cPersonelGorev
    {
        cGenel gnl = new cGenel();

        #region Fields

        private int _personelGoreviId;
        private string _tanim;

        #endregion


        #region Properties

        public int PersonelGoreviId
        {
            get { return _personelGoreviId; }
            set { _personelGoreviId = value; }
        }

        public string Tanim
        {
            get { return _tanim; }
            set { _tanim = value; }
        }

        #endregion

        public void PersonelGoreviGetir(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from personelGorevleri", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cPersonelGorev c = new cPersonelGorev();
                    c._personelGoreviId = Convert.ToInt32(dr["ID"].ToString());
                    c._tanim = dr["GOREV"].ToString();
                    cb.Items.Add(c);
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
                con.Close();
            }
        }


        public string PersonelGorevTanim(int per)
        {
            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select GOREV from personelGorevleri where ID=@perId", con);
            cmd.Parameters.Add("perId", SqlDbType.Int).Value = per;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                sonuc = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            con.Close();


            return sonuc;
        }


        public override string ToString()
        {
            return _tanim;
        }
    }
}