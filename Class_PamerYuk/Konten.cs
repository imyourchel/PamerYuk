using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Class_PamerYuk
{
    public class Konten
    {
        #region Data Fields
        private int idKonten;
        private User user;
        private string foto;
        private string video;
        private string caption;
        private string tglUpload;
        #endregion

        #region Constructors
        public Konten(int idKonten, User user, string foto, string video, string caption, string tglUpload)
        {
            this.IdKonten = idKonten;
            this.User = user;
            this.Foto = foto;
            this.Video = video;
            this.Caption = caption;
            this.TglUpload = tglUpload;
        }
        public Konten()
        {
            this.IdKonten = 0;
            this.User = new User();
            this.Foto = "";
            this.Video = "";
            this.Caption = "";
            this.TglUpload = DateTime.Now.ToString("yyyy-MM-dd");
        }
        #endregion Constructors

        #region Properties
        public int IdKonten { get => idKonten; set => idKonten = value; }
        public User User { get => user; set => user = value; }
        public string Foto { get => foto; set => foto = value; }
        public string Video { get => video; set => video = value; }
        public string Caption { get => caption; set => caption = value; }
        public string TglUpload { get => tglUpload; set => tglUpload = value; }
        #endregion Properties        

        #region Method

        public static Bitmap CropToSquareWithoutResizing(Image originalImage)
        {
            // Tentukan dimensi persegi berdasarkan sisi terkecil
            int sideLength = Math.Min(originalImage.Width, originalImage.Height);

            // Tentukan titik awal crop (tengah gambar)
            int x = (originalImage.Width - sideLength) / 2;
            int y = (originalImage.Height - sideLength) / 2;

            // Area yang akan di-crop
            Rectangle cropArea = new Rectangle(x, y, sideLength, sideLength);

            // Lakukan crop
            Bitmap croppedImage = new Bitmap(sideLength, sideLength);
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.DrawImage(originalImage, new Rectangle(0, 0, sideLength, sideLength), cropArea, GraphicsUnit.Pixel);
            }

            return croppedImage; // Return cropped image
        }

        public static Bitmap CorrectImageOrientation(Image originalImage, string imagePath)
        {
            using (var img = Image.FromFile(imagePath))
            {
                if (img.PropertyIdList.Contains(0x0112)) // 0x0112 adalah tag EXIF untuk orientasi
                {
                    var orientation = BitConverter.ToUInt16(img.GetPropertyItem(0x0112).Value, 0);

                    switch (orientation)
                    {
                        case 3: // Rotate 180
                            originalImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 6: // Rotate 90
                            originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 8: // Rotate 270
                            originalImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                }
            }
            return new Bitmap(originalImage); // Return image with corrected orientation
        }

        public static void TambahKonten(Konten objTambah, string username)
        {
            objTambah.IdKonten = GenerateIdBaru();
            string perintah = "INSERT INTO Konten (id, caption, foto, video, tglUpload, username)" + "VALUES ('" + objTambah.IdKonten + "', '" + objTambah.Caption + "', '" + objTambah.Foto + "', '" + objTambah.Video + "',Now()" + ", '" + username + "' );";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(perintah);
        }
        public static int GenerateIdBaru()
        {
            int idbaru = 1;
            string perintah = "select id from konten order by id desc limit 1;";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            if (dr.Read())
            {
                string idterakhir = dr.GetValue(0).ToString();
                idbaru = int.Parse(idterakhir) + 1;
            }
            return idbaru;
        }

        public static int JumlahPost(string username)
        {
            int jumlahPost = 0;
            string perintah = "SELECT COUNT(*) FROM Konten where username ='" + username + "';";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            while (dr.Read())
            {
                string post = dr.GetValue(0).ToString();
                jumlahPost = int.Parse(post);
            }
            return jumlahPost;
        }

        public List<string> ListFotoKonten(string username)
        {
            string perintah = "SELECT foto FROM konten where username = '" + username + "' order by tglUpload desc;";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);

            List<string> listPathFoto = new List<string>();
            while (dr.Read())
            {
                listPathFoto.Add(dr.GetValue(0).ToString());
            }
            return listPathFoto;
        }

        public static Konten BacaDataKonten(int id_konten)
        {
            //Fungsi BacaDataKonten bertujuan untuk membaca data konten dari tabel konten di database berdasarkan ID konten tertentu (id_konten)
            string perintah = "select * from konten where id = +" + id_konten + ";";
            MySqlDataReader dr = Koneksi.JalankanPerintahSelect(perintah);
            Konten hasil = new Konten();
            while (dr.Read())
            {
                hasil.IdKonten = int.Parse(dr.GetValue(0).ToString());
                hasil.Caption = dr.GetValue(1).ToString();
                hasil.Foto = dr.GetValue(2).ToString();
                hasil.Video = dr.GetValue(3).ToString();
                hasil.TglUpload = dr.GetValue(4).ToString();
            }
            return hasil;
        }

        #endregion
    }
}
