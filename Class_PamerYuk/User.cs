using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Class_PamerYuk
{
    public class User
    {
        #region Data Fields
        private string username;
        private string password;
        private string namaLengkap;
        private string tglLahir;
        private string noKTP;
        private string fotoDiri;
        private string fotoProfile;
        private string email;
        private Kota kota; 
        #endregion

        #region Constructors
        public User(string username, string password, string namaLengkap, string tglLahir, string noKTP, string fotoDiri, string fotoProfile, string email, Kota kota)
        {
            this.Username = username;
            this.Password = password;
            this.NamaLengkap = namaLengkap;
            this.TglLahir = tglLahir;
            this.NoKTP = noKTP;
            this.FotoDiri = fotoDiri;
            this.FotoProfile = fotoProfile;
            this.Email = email;
            this.Kota = kota;
        }
        public User()
        {
            this.Username = "";
            this.Password = "";
            this.NamaLengkap = "";
            this.TglLahir = "";
            this.NoKTP = "";
            this.FotoDiri = "";
            this.FotoProfile = "";
            this.Email = "";
            this.Kota = new Kota();
        }
        #endregion Constructors

        #region Properties
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string NamaLengkap { get => namaLengkap; set => namaLengkap = value; }
        public string TglLahir { get => tglLahir; set => tglLahir = value; }
        public string NoKTP { get => noKTP; set => noKTP = value; }
        public string FotoDiri { get => fotoDiri; set => fotoDiri = value; }
        public string FotoProfile { get => fotoProfile; set => fotoProfile = value; }
        public string Email { get => email; set => email = value; }
        public Kota Kota { get => kota; set => kota = value; }
        #endregion Properties

        #region Method
        public static bool CekUsername(string username)
        {
            string perintah = "SELECT EXISTS(SELECT 1 FROM User WHERE Username = '" + username + "');";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(perintah);
            if (hasil.Read())
            {
                if (hasil.GetBoolean(0))
                {
                    return true;//username sudah ada
                }
            }
            return false;
        }
        public static void TambahData(User objtTambah)
        {
            string perintah = "INSERT INTO user (username, password, namaLengkap, tglLahir, noKTP, fotoDiri, fotoProfile, email, Kota_id) " +
                "VALUES ('" + objtTambah.Username + "', '" + objtTambah.Password + "', '" + objtTambah.NamaLengkap + "', '" + objtTambah.TglLahir + "', " +
                "'" + objtTambah.NoKTP + "', '" + objtTambah.FotoDiri + "', '" + objtTambah.FotoProfile + "', '" + objtTambah.Email + "', '" + objtTambah.Kota.KodeKota + "')";
            Koneksi.JalankanPerintahNonQuery(perintah);
        }
        public static User CekLogin(string uid, string pwd)
        {
            string perintah = "SELECT u.*, k.nama FROM user u " +
                "INNER JOIN kota k ON u.kota_id = k.id " +
                "WHERE u.username = '" + uid + "' AND u.password = '" + pwd + "'";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(perintah);
            if (hasil.Read() == true)
            {
                User userLogin = new User();
                userLogin.Username = hasil.GetValue(0).ToString();
                userLogin.Password = hasil.GetValue(1).ToString();
                userLogin.NamaLengkap = hasil.GetValue(2).ToString();
                userLogin.TglLahir = hasil.GetValue(3).ToString();
                userLogin.NoKTP = hasil.GetValue(4).ToString();
                userLogin.FotoDiri = hasil.GetValue(5).ToString();
                userLogin.FotoProfile = hasil.GetValue(6).ToString();
                userLogin.Email = hasil.GetValue(7).ToString();
                userLogin.Kota.KodeKota = int.Parse(hasil.GetValue(8).ToString());
                userLogin.Kota.NamaKota = hasil.GetValue(9).ToString();
                return userLogin;
            }
            else
            {
                return null;
            }
        }
        public static List<User> BacaData(string filter = "", string nilai = "", string unm = "")
        {
            string perintah = "";
            if (filter == "" && nilai == "")
            {
                perintah = "SELECT DISTINCT u.*, k.nama " +
                     "FROM user u " +
                     "INNER JOIN kota k ON u.kota_id = k.id " +
                     "LEFT JOIN kisahhidup kh ON u.username = kh.username " +
                     "LEFT JOIN organisasi o ON kh.Organisasi_id = o.id " +
                     "WHERE u.username != '" + unm + "' ";
            }
            else if (filter != "" && nilai == "")
            {
                perintah = "SELECT DISTINCT u.*, k.nama " +
                     "FROM user u " +
                     "INNER JOIN kota k ON u.kota_id = k.id " +
                     "LEFT JOIN kisahhidup kh ON u.username = kh.username " +
                     "LEFT JOIN organisasi o ON kh.Organisasi_id = o.id " +
                     "WHERE u.username != '" + unm + "' " +
                     "WHERE o.jenis = '" + filter + "'";
            }
            else if (filter != "" && nilai != "")
            {
                perintah = "SELECT DISTINCT u.*, k.nama " +
                     "FROM user u " +
                     "INNER JOIN kota k ON u.kota_id = k.id " +
                     "LEFT JOIN kisahhidup kh ON u.username = kh.username " +
                     "LEFT JOIN organisasi o ON kh.Organisasi_id = o.id " +
                     "WHERE u.username != '" + unm + "' " +
                     "WHERE o.jenis = '" + filter + "' " +
                     "AND (u.username LIKE '%" + nilai + "%' OR u.namalengkap LIKE '%" + nilai + "%' OR o.nama LIKE '%" + nilai + "%')";
            }
            else if (filter == "" && nilai != "")
            {
                perintah = "SELECT DISTINCT u.*, k.nama " +
                     "FROM user u " +
                     "INNER JOIN kota k ON u.kota_id = k.id " +
                     "LEFT JOIN kisahhidup kh ON u.username = kh.username " +
                     "LEFT JOIN organisasi o ON kh.Organisasi_id = o.id " +
                     "WHERE u.username != '" + unm + "' " +
                     "WHERE u.username LIKE '%" + nilai + "%'";
            }

            List<User> listUser = new List<User>();
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(perintah);

            while (hasil.Read())
            {
                User u = new User();
                u.Username = hasil.GetValue(0).ToString();
                u.Password = hasil.GetValue(1).ToString();
                u.NamaLengkap = hasil.GetValue(2).ToString();
                u.TglLahir = hasil.GetValue(3).ToString();
                u.NoKTP = hasil.GetValue(4).ToString();
                u.FotoDiri = hasil.GetValue(5).ToString();
                u.FotoProfile = hasil.GetValue(6).ToString();
                u.Email = hasil.GetValue(7).ToString();
                u.Kota = new Kota();
                u.Kota.KodeKota = int.Parse(hasil.GetValue(8).ToString());
                u.Kota.NamaKota = hasil.GetValue(9).ToString();
                listUser.Add(u);
            }
            return listUser;
        }
        public static List<User> TampilkanProfil()
        {
            string perintah = "select username, namaLengkap, fotoProfile FROM User;";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(perintah);

            List<User> listUser = new List<User>();
            while (hasil.Read())
            {
                User tampung = new User();
                tampung.Username = hasil.GetValue(0).ToString();
                tampung.NamaLengkap = hasil.GetValue(1).ToString();
                tampung.FotoProfile = hasil.GetValue(2).ToString();

                listUser.Add(tampung);
            }
            return listUser;
        }
        public static void UpdateData(User objtUpdate)
        {
            string query = "UPDATE user SET " +
                               "namaLengkap = '" + objtUpdate.NamaLengkap + "', " +
                               "email = '" + objtUpdate.Email + "', " +
                               "password = SHA2('" + objtUpdate.Password + "', 512), " +
                               "tglLahir = '" + objtUpdate.TglLahir + "', " +
                               "kota_id = '" + objtUpdate.Kota.KodeKota + "' " +
                               "WHERE username = '" + objtUpdate.Username + "'";
            Koneksi.JalankanPerintahNonQuery(query);
        }
        public static User GetUserByUsername(string username)
        {
            string query = "SELECT * FROM user WHERE username = '" + username + "'";
            MySqlDataReader reader = Koneksi.JalankanPerintahSelect(query);
            if (reader.Read())
            {
                User user = new User();
                user.Username = reader["username"].ToString();
                user.NamaLengkap = reader["namaLengkap"].ToString();
                user.FotoProfile = reader["fotoProfile"].ToString();
                return user;
            }
            return null;
        }
        public override string ToString()
        {
            return Username;
        }
        #endregion
    }
}
