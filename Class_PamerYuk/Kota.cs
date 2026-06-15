using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Class_PamerYuk
{
    public class Kota
    {
        #region Data Fields
        private int kodeKota;
        private string namaKota; 
        #endregion

        #region Constructors
        public Kota(int kode, string kota)
        {
            this.KodeKota = kode;
            this.NamaKota = kota;
        }
        public Kota()
        {
            this.KodeKota = 0;
            this.NamaKota = "";
        }
        #endregion Constructors

        #region Properties
        public int KodeKota { get => kodeKota; set => kodeKota = value; }
        public string NamaKota { get => namaKota; set => namaKota = value; }
        #endregion Properties

        #region Method
        public static List<Kota> BacaData()
        {
            string perintah = "SELECT * FROM kota";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);
            List<Kota> listHasil = new List<Kota>();
            while (dr.Read())
            {
                string tampungKode = dr.GetValue(0).ToString();
                string tampungNama = dr.GetValue(1).ToString();

                Kota tampung = new Kota(int.Parse(tampungKode), tampungNama);
                listHasil.Add(tampung);
            }
            return listHasil;
        }
        public override string ToString()
        {
            return this.NamaKota;
        }
        public static bool CekKota(string kota)
        {
            string perintah = "SELECT EXISTS(SELECT 1 FROM Kota WHERE nama = '" + kota + "');";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(perintah);
            if (hasil.Read())
            {
                if (hasil.GetBoolean(0))
                {
                    return true;
                }
            }
            return false;
        }
        public static Kota TambahData(string nKota)
        {
            string getMaxCodeQuery = "SELECT IFNULL(MAX(id), 0) + 1 FROM kota";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(getMaxCodeQuery);
            int Kode = 1;
            if (hasil.Read())
            {
                Kode = hasil.GetInt32(0);
            }
            Kota add = new Kota(Kode, nKota);
            string perintah = "INSERT INTO kota (id, Nama) VALUES ('" + add.KodeKota + "', '" + add.NamaKota + "')";
            Koneksi.JalankanPerintahNonQuery(perintah);
            return add;
        } 
        #endregion
    }
}
