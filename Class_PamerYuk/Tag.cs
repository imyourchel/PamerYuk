using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_PamerYuk
{
    public class Tag
    {
        #region Data Fields
        private Konten konten;
        private User user;
        #endregion

        #region Constructors
        public Tag(Konten konten, User user)
        {
            this.Konten = konten;
            this.User = user;
        }
        public Tag()
        {
            this.Konten = new Konten();
            this.User = new User();
        }
        #endregion Constructors

        #region Properties
        public Konten Konten { get => konten; set => konten = value; }
        public User User { get => user; set => user = value; }
        #endregion Properties

        #region Method
        public void TambahData(int IdKonten, string friendUsername)
        {
            string perintah = "INSERT INTO tag (Konten_id, username) VALUES ('" + IdKonten + "', '" + friendUsername + "');";
            Koneksi.JalankanPerintahNonQuery(perintah);
        }
        #endregion
    }
}
