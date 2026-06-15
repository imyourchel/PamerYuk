using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Class_PamerYuk
{
    public class Percakapan
    {
        #region Data Fields
        private User user;
        private User friend;
        private string pesan;
        private string wktKirim; 
        #endregion

        #region Constructors
        public Percakapan(User user, User friend, string pesan, string wktKirim)
        {
            this.User = user;
            this.Friend = friend;
            this.Pesan = pesan;
            this.WktKirim = wktKirim;
        }
        public Percakapan()
        {
            this.User = new User();
            this.Friend = new User();
            this.Pesan = "";
            this.wktKirim = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion Constructors

        #region Properties
        public User User { get => user; set => user = value; }
        public User Friend { get => friend; set => friend = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public string WktKirim { get => wktKirim; set => wktKirim = value; }
        #endregion Properties   

        #region Method
        public void SimpanPesan()
        {
            string query = $@"
                INSERT INTO percakapan (user_pengirim, user_penerima, isipesan, waktukirim)
                VALUES ('{this.User.Username}', '{this.Friend.Username}', '{this.Pesan}', '{this.WktKirim}')";

            Koneksi.JalankanPerintahNonQuery(query);
        }

        public static List<Percakapan> AmbilPesan(User user, User friend)
        {
            List<Percakapan> daftarPesan = new List<Percakapan>();

            string query = $@"
                SELECT user_pengirim, user_penerima, isipesan, waktukirim FROM percakapan
                 WHERE (user_pengirim = '{user.Username}' AND user_penerima = '{friend.Username}')
                    OR (user_pengirim = '{friend.Username}' AND user_penerima = '{user.Username}')
                 ORDER BY waktukirim ASC";

            MySqlDataReader reader = Koneksi.JalankanPerintahSelect(query);

            while (reader.Read())
            {
                Percakapan percakapan = new Percakapan
                {
                    User = User.GetUserByUsername(reader.GetString("user_pengirim")),
                    Friend = User.GetUserByUsername(reader.GetString("user_penerima")),
                    Pesan = reader.GetString("isipesan"),
                    WktKirim = reader.GetDateTime("waktukirim").ToString("yyyy-MM-dd HH:mm:ss")
                };

                daftarPesan.Add(percakapan);
            }

            reader.Close();
            return daftarPesan;
        } 
        #endregion
    }
}
