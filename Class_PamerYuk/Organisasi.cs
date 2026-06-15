using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Class_PamerYuk
{
    public class Organisasi
    {
        #region Data Fields
        private int id;
        private string nama;
        private string jenis;
        private Kota kota; 
        #endregion

        #region Constructors
        public Organisasi(int id, string nama, string jenis, Kota kota)
        {
            this.Id = id;
            this.Nama = nama;
            this.Jenis = jenis;
            this.Kota = kota;
        }
        public Organisasi()
        {
            this.Id = 0;
            this.Nama = "";
            this.Jenis = "";
            this.Kota = new Kota();
        }
        #endregion Constructors

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Jenis { get => jenis; set => jenis = value; }
        public Kota Kota { get => kota; set => kota = value; }
        #endregion Properties

        #region Method
        public static int GenerateIdBaru()
        {
            int idbaru = 1;
            string perintah = "select id from organisasi order by id desc limit 1;";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            if (dr.Read())
            {
                string idterakhir = dr.GetValue(0).ToString();
                idbaru = int.Parse(idterakhir) + 1;
            }
            return idbaru;
        }
        public static void TambahData(Organisasi objtTambah)
        {
            objtTambah.Id = GenerateIdBaru();
            string perintah = "INSERT INTO organisasi (id, nama, jenis, Kota_id) " +
                "VALUES (" + objtTambah.Id + ", '" +
                objtTambah.Nama + "', '" +
                objtTambah.Jenis + "', " +
                objtTambah.Kota.KodeKota + ")";
            Koneksi.JalankanPerintahNonQuery(perintah);
        } 
        #endregion
    }
}