using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_PamerYuk
{
    public class Komen
    {
        #region Data Fields
        private int id;
        private User user;
        private Konten konten;
        private string komentar;
        private string tglKomentar; 
        #endregion

        #region Constructors
        public Komen(int id, User user, Konten konten, string komentar, string tglKomentar)
        {
            this.Id = id;
            this.User = user;
            this.Konten = konten;
            this.Komentar = komentar;
            this.TglKomentar = tglKomentar;
        }
        public Komen()
        {
            this.Id = 0;
            this.User = new User();
            this.Konten = new Konten();
            this.Komentar = "";
            this.TglKomentar = DateTime.Now.ToString("yyyy-MM-dd");
        }
        #endregion Constructors

        #region Properties
        public int Id { get => id; set => id = value; }
        public User User { get => user; set => user = value; }
        public Konten Konten { get => konten; set => konten = value; }
        public string Komentar { get => komentar; set => komentar = value; }
        public string TglKomentar { get => tglKomentar; set => tglKomentar = value; }
        #endregion Properties

        #region Method
        public static List<Komen> BacaListKomen(int idKonten)
        {
            string perintah = "select * from komen km inner join konten k  on km.konten_id = k.id where k.id =" + idKonten + ";";

            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            List<Komen> listHasil = new List<Komen>();

            while (dr.Read())
            {
                Komen k = new Komen();
                k.Id = int.Parse(dr.GetValue(0).ToString());
                k.Komentar = dr.GetValue(1).ToString();
                k.TglKomentar = dr.GetValue(2).ToString();
                k.User.Username = dr.GetValue(3).ToString();
                listHasil.Add(k);
            }
            return listHasil;
        }
        public static int JumlahKomen()
        {
            int jumlahKomen = 0;
            // status is null => berteman
            string perintah = "select count(*) from komen;";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            if (dr.Read())
            {
                jumlahKomen = int.Parse(dr.GetValue(0).ToString());
            }
            return jumlahKomen;
        }

        public static void TambahKomen(int idKomen, string komen, string username, int idKonten)
        {
            string perintah = "INSERT INTO komen (id, komentar, tgl, username, Konten_id) VALUES (" + idKomen + ", '" + komen + "', NOW(), '" + username + "', '" + idKonten + "');";
            Koneksi.JalankanPerintahNonQuery(perintah);
        }
        public static int AmbilIdLastKomen()
        {
            int idLast = 0;
            string perintah = "select id from komen order by id desc limit 1;";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            if (dr.Read())
            {
                string idterakhir = dr.GetValue(0).ToString();
                idLast = int.Parse(idterakhir);
            }
            return idLast;
        } 
        #endregion
    }
}
