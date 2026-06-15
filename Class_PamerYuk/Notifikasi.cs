using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_PamerYuk
{
    public class Notifikasi
    {
        #region Data Fields
        private string isiNotif;
        private DateTime tgl;
        #endregion

        #region Properties
        public string IsiNotif { get => isiNotif; set => isiNotif = value; }
        public DateTime Tgl { get => tgl; set => tgl = value; }
        #endregion

        #region Method

        public Notifikasi()
        {
            IsiNotif = isiNotif;
            Tgl = tgl;
        }
        public Notifikasi(string isiNotif, DateTime tgl)
        {
            IsiNotif = "";
            Tgl = DateTime.Now;
        }
        public static List<Notifikasi> BacaTagKonten(string myUsername)
        {
            string perintah = "select k.username as 'Pembuat konten', k.tglUpload as 'Tanggal' " +
                "from konten k inner join tag t on k.id=t.konten_id " +
                "where t.username='" + myUsername + "';";

            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            List<Notifikasi> listHasil = new List<Notifikasi>();

            while (dr.Read())
            {
                Notifikasi n = new Notifikasi();
                n.IsiNotif = dr.GetValue(0).ToString() + " mentioned you in their post\t";
                n.Tgl = DateTime.Parse(dr.GetValue(1).ToString());
                listHasil.Add(n);
            }
            return listHasil;
        }
        public static List<Notifikasi> BacaKomen(string myUsername)
        {
            string perintah = "select km.username, km.komentar, km.tgl from konten k inner join komen km where k.username='" + myUsername + "' and km.username!='" + myUsername + "';";

            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            List<Notifikasi> listHasil = new List<Notifikasi>();

            while (dr.Read())
            {
                Notifikasi n = new Notifikasi();
                n.IsiNotif = dr.GetValue(0).ToString() + " commented : " + dr.GetValue(1).ToString();
                n.Tgl = DateTime.Parse(dr.GetValue(2).ToString());
                listHasil.Add(n);
            }
            return listHasil;
        }
        public static List<Notifikasi> BacaUlangTahun(string myUsername)
        {
            string perintah = "select t.username2, now() from user u inner join teman t on u.username=t.username2 where t.tglBerteman is not null and DAY(u.tglLahir)=DAY(CURDATE()) and MONTH(u.tglLahir)=MONTH(CURDATE()) and t.username1='" + myUsername + "';";

            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            List<Notifikasi> listHasil = new List<Notifikasi>();

            while (dr.Read())
            {
                Notifikasi n = new Notifikasi();
                n.IsiNotif = dr.GetValue(0).ToString() + " is birthday today!!!\t";
                n.Tgl = DateTime.Parse(dr.GetValue(1).ToString());
                listHasil.Add(n);
            }
            return listHasil;
        }
        public static List<Notifikasi> GabungNotif(string myUsername)
        {
            List<Notifikasi> listHasil = new List<Notifikasi>();
            listHasil = BacaTagKonten(myUsername);
            listHasil.AddRange(BacaUlangTahun(myUsername));
            listHasil.AddRange(BacaKomen(myUsername));
            listHasil.Sort((x, y) => y.Tgl.CompareTo(x.Tgl));

            return listHasil;
        } 
        #endregion
    }
}
