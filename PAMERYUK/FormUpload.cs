using Class_PamerYuk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAMERYUK
{
    public partial class FormUpload : Form
    {
        public FormUpload()
        {
            InitializeComponent();
        }
        public FormUtama main;

        private void FormUpload_Load(object sender, EventArgs e)
        {
            main = (FormUtama)this.MdiParent;
        }

        string GetUniqueFileName(string baseFilePath)
        {
            int count = 1;
            string directory = Path.GetDirectoryName(baseFilePath); // Dapatkan folder file
            string fileName = Path.GetFileNameWithoutExtension(baseFilePath); // Nama file tanpa ekstensi
            string extension = Path.GetExtension(baseFilePath); // Ekstensi file

            string newFilePath = baseFilePath;

            // Periksa keberadaan file
            while (File.Exists(newFilePath))
            {
                // Tambahkan angka ke nama file
                newFilePath = Path.Combine(directory, $"{fileName} ({count}){extension}");
                count++;
            }

            return newFilePath;
        }

        private void pictureBoxKonten_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter =
            "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
            "All files (*.*)|*.*";

            openFileDialog.Title = "Select Photos";

            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Ambil path file yang dipilih
                string imagePath = openFileDialog.FileName;

                // Load gambar asli
                Image originalImage = Image.FromFile(imagePath);

                // Perbaiki orientasi gambar
                Bitmap correctedImage = Konten.CorrectImageOrientation(originalImage, imagePath);

                // Crop gambar menjadi kotak
                Bitmap croppedImage = Konten.CropToSquareWithoutResizing(correctedImage);

                // Tampilkan gambar di PictureBox
                pictureBoxKonten.Image = croppedImage;
                pictureBoxKonten.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            #region Upload Konten
            try
            {
                #region input data
                Konten k = new Konten();

                k.Caption = richTextBoxCaption.Text;

                //foto
                k.Foto = main.UserLogin.Username + ".jpg";
                string pathKontenPict = null;
                if (pictureBoxKonten.Image != null)
                {
                    pathKontenPict = k.Foto;
                }
                else
                {
                    throw new Exception("Isi konten tidak boleh kosong");
                }
                #endregion
                #region save pict
                //save ID pict ke folder resources
                string resourcesPathID = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoKonten");
                string fullPathKonten = Path.Combine(resourcesPathID, pathKontenPict);
                if (!Directory.Exists(resourcesPathID))
                {
                    Directory.CreateDirectory(resourcesPathID); // Membuat folder Resources jika belum ada
                }
                fullPathKonten = GetUniqueFileName(fullPathKonten);
                pictureBoxKonten.Image.Save(fullPathKonten);
                k.Foto = Path.GetFileName(fullPathKonten);

                #endregion save pict
                string username = main.UserLogin.Username;

                Konten.TambahKonten(k, username);

                FormTag frm = new FormTag();
                frm.Owner = this;
                frm.post = k;
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            #endregion
        }
    }
}
