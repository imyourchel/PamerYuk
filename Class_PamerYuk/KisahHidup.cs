using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Class_PamerYuk
{
    public class KisahHidup
    {
        #region Data Fields
        private User user;
        private Organisasi organisasi;
        private string thAwal;
        private string thAkhir;
        private string deskripsi; 
        #endregion

        #region Constructors
        public KisahHidup(User user, Organisasi organisasi, string thAwal, string thAkhir, string deskripsi)
        {
            this.User = user;
            this.Organisasi = organisasi;
            this.ThAwal = thAwal;
            this.ThAkhir = thAkhir;
            this.Deskripsi = deskripsi;
        }
        public KisahHidup()
        {
            this.User = new User();
            this.Organisasi = new Organisasi();
            this.ThAwal = "";
            this.ThAkhir = "";
            this.Deskripsi = "";
        }
        #endregion Constructors

        #region Properties
        public User User { get => user; set => user = value; }
        public Organisasi Organisasi { get => organisasi; set => organisasi = value; }
        public string ThAwal { get => thAwal; set => thAwal = value; }
        public string ThAkhir { get => thAkhir; set => thAkhir = value; }
        public string Deskripsi { get => deskripsi; set => deskripsi = value; }
        #endregion Properties   

        #region Method
        public static void TambahData(KisahHidup objtTambah)
        {
            string perintah = "INSERT INTO kisahhidup (Organisasi_id, username, thawal, thakhir, deskripsi) " +
                "VALUES ('" + objtTambah.Organisasi.Id + "', '" +
                objtTambah.User.Username + "', '" +
                objtTambah.ThAwal + "', '" +
                objtTambah.ThAkhir + "', '" +
                objtTambah.Deskripsi + "')";
            Koneksi.JalankanPerintahNonQuery(perintah);
        }
        public static List<KisahHidup> BacaData(User usr)
        {
            List<KisahHidup> daftarKisahHidup = new List<KisahHidup>();

            string perintah = "SELECT h.*, o.nama, o.jenis, k.nama FROM kisahhidup h INNER JOIN organisasi o ON h.organisasi_id = o.id INNER JOIN kota k ON o.kota_id = k.id WHERE username = '" + usr.Username + "';";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);
            while (dr.Read())
            {
                KisahHidup kh = new KisahHidup();
                kh.Organisasi = new Organisasi();
                kh.Organisasi.Id = int.Parse(dr.GetValue(0).ToString());
                kh.Organisasi.Nama = dr.GetValue(5).ToString();
                kh.Organisasi.Jenis = dr.GetValue(6).ToString();
                kh.Organisasi.Kota.NamaKota = dr.GetValue(7).ToString();

                kh.User = new User();
                kh.User.Username = dr.GetValue(1).ToString();
                kh.ThAwal = dr.GetValue(2).ToString();
                kh.ThAkhir = dr.GetValue(3).ToString();
                kh.Deskripsi = dr.GetValue(4).ToString();
                daftarKisahHidup.Add(kh);
            }
            return daftarKisahHidup;
        } 
        #endregion
    }
}
