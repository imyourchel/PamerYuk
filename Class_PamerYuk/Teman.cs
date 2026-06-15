using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_PamerYuk
{
    public class Teman
    {
        #region Data Fields
        private User user;
        private User friend;
        private string status;
        private string tglBerteman;
        #endregion

        #region Constructor
        public Teman(User user, User friend, string status, string tglBerteman)
        {
            this.User = user;
            this.Friend = friend;
            this.Status = status;
            this.TglBerteman = tglBerteman;
        }
        public Teman()
        {
            this.User = new User();
            this.Friend = new User();
            this.Status = "";
            this.TglBerteman = "";
        }
        #endregion

        #region Properties
        public User User { get => user; set => user = value; }
        public User Friend { get => friend; set => friend = value; }
        public string Status { get => status; set => status = value; }
        public string TglBerteman { get => tglBerteman; set => tglBerteman = value; }

        #endregion

        #region Method
        public static List<Teman> BacaDataTeman(string myUsername, string friendUsername = "", string status = "Is Null", bool useUsername2 = true)
        {
            string connector;
            if (useUsername2) connector = "username2";
            else connector = "username1";

            //query
            string perintah = "SELECT u.*, k.id FROM teman t INNER JOIN user u ON t." + connector + " = u.username inner join kota k on u.Kota_id = k.id WHERE t.username1 = '" + myUsername + "'";

            //status is null => status berteman
            if (status == "Is Null") perintah += " and status IS NULL";
            else perintah += "and status = '" + status + "';";
            if (friendUsername != "") perintah += " and u.username like '%" + friendUsername + "%'";
            perintah += ";"; MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah); List<Teman> listHasil = new List<Teman>();
            while (dr.Read())
            {
                User cu = new User();
                cu.Username = dr.GetValue(0).ToString();
                cu.NamaLengkap = dr.GetValue(2).ToString();
                cu.TglLahir = dr.GetDateTime(3).ToString();
                cu.NoKTP = dr.GetValue(4).ToString();
                cu.FotoDiri = dr.GetValue(5).ToString();
                cu.FotoProfile = dr.GetValue(6).ToString();
                cu.Kota.NamaKota = dr.GetValue(7).ToString();

                Teman t = new Teman();
                if (useUsername2) t.Friend = cu;
                else t.User = cu;

                listHasil.Add(t);
            }

            return listHasil;
        }

        public static List<string> BacaDataTag(string myUsername, string friendUsername = "")
        {
            //query
            string perintah = "select * from teman where username1 = '" + myUsername + "' ";
            if (friendUsername != "") perintah += "and username2 like '%" + friendUsername + "%' ";
            perintah += "and status Is Null;";

            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            List<string> listHasil = new List<string>();

            while (dr.Read())
            {
                listHasil.Add(dr.GetString(1));
            }
            return listHasil;
        }

        public static List<Teman> BacaListTeman(string myUsername, string friendUsername = "")
        {
            //untuk menampilkan jumlah list teman
            string perintah = "SELECT username2 as 'Username' FROM teman where tglBerteman is not null and username1 = '" + myUsername + "'";
            if (friendUsername == "")
            {
                perintah += ";";
            }
            else
            {
                perintah += "and username2 like'%" + friendUsername + "%'";
            }
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            List<Teman> listHasil = new List<Teman>();

            while (dr.Read())
            {
                Teman t = new Teman();
                t.Friend.Username = dr.GetValue(0).ToString();
                listHasil.Add(t);
            }
            return listHasil;
        }

        public void HapusTeman(string friendUsername, string myUsername)
        {
            string perintah = "DELETE FROM teman WHERE username1 in('" + friendUsername + "', '" + myUsername + "') and username2 in('" + friendUsername + "', '" + myUsername + "');";
            Koneksi.JalankanPerintahNonQuery(perintah);
        }

        public void TambahData(string myUsername, string friendUsername, string status)
        {
            string perintah = "INSERT INTO teman(username1, username2, status) VALUES('" + myUsername + "', '" + friendUsername + "', '" + status + "');";
            Koneksi.JalankanPerintahNonQuery(perintah);
        }

        public void TambahTeman(string myUsername, string friendUsername)
        //untuk menambahkan jumlah teman di dalam database 
        {
            string perintah = "UPDATE teman SET status= NULL, tglBerteman=CURRENT_DATE WHERE username1='" + myUsername + "'and username2='" + friendUsername + "';" +
                "INSERT INTO teman(username1, username2, tglBerteman) VALUES('" + friendUsername + "', '" + myUsername + "', CURRENT_DATE);";
            Koneksi.JalankanPerintahNonQuery(perintah);
        }
        
        public void UpdateUnblokir(string friendUsername, string myUsername)
        {
            string perintah = "DELETE FROM teman WHERE username1 in('" + friendUsername + "', '" + myUsername + "') and username2 in('" + friendUsername + "', '" + myUsername + "');";
            Koneksi.JalankanPerintahNonQuery(perintah);
        }

        public static int JumlahTeman(string username)
        {
            int jumlahTeman = 0;
            // status is null => berteman
            string perintah = "SELECT COUNT(*) FROM Teman WHERE (username1 = '" + username + "' or username2 = '" + username + "') and status IS NULL;";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            if (dr.Read())
            {
                jumlahTeman = int.Parse(dr.GetValue(0).ToString());
            }
            return jumlahTeman;
        }

        public static List<Teman> AmbilDataTeman(string username)
        {
            string perintah = "SELECT * FROM teman WHERE username1 = '" + username + "' AND status IS NULL";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);
            List<Teman> listHasil = new List<Teman>();
            while (dr.Read())
            {
                Teman t = new Teman();
                t.User.Username = dr.GetValue(0).ToString();
                t.Friend.Username = dr.GetValue(1).ToString();
                DateTime tanggal = dr.GetDateTime(2);
                t.TglBerteman = tanggal.ToString("yyyy-MM-dd");
                t.Status = dr.GetValue(3).ToString();
                listHasil.Add(t);
            }
            return listHasil;
        }

        public static List<Teman> BacaListRequest(string myUsername, string friendUsername = "")
        {
            //untuk mendapatkan list user yang mengirim permintaan pertemanan ke seorang user (myUsername)
            string perintah = "SELECT username2 as 'Username' FROM teman where status = 'request' and username1 = '" + myUsername + "'";
            if (friendUsername == "")
            {
                perintah += ";";
            }
            else
            {
                perintah += "and username2 like'%" + friendUsername + "%'";
            }
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            List<Teman> listHasil = new List<Teman>();

            while (dr.Read())
            {
                Teman t = new Teman();
                t.Friend.Username = dr.GetValue(0).ToString();
                listHasil.Add(t);
            }

            return listHasil;
        }
        #endregion
    }
}
