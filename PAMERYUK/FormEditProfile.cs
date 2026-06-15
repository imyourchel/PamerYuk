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
using Class_PamerYuk;

namespace PAMERYUK
{
    public partial class FormEditProfile : Form
    {
        public FormEditProfile()
        {
            InitializeComponent();
        }

        private void FormEditProfile_Load(object sender, EventArgs e)
        {
            formUtm = (FormUtama)this.MdiParent;
            comboBoxKota.DataSource = Kota.BacaData();
            comboBoxKota.DisplayMember = "Nama";
            comboBoxKota.SelectedIndex = -1;
            textBoxIDNumber.Enabled = false;
            textBoxUsername.Enabled = false;
            

            textBoxFullName.Text = formUtm.UserLogin.NamaLengkap;
            textBoxUsername.Text = formUtm.UserLogin.Username;
            textBoxIDNumber.Text = formUtm.UserLogin.NoKTP;
            textBoxEmail.Text = formUtm.UserLogin.Email;
            textBoxPassword.Text = formUtm.UserLogin.Password;
            dateTimePickerTglLahir.Value = DateTime.Parse(formUtm.UserLogin.TglLahir);
            comboBoxKota.SelectedIndex = comboBoxKota.FindStringExact(formUtm.UserLogin.Kota.NamaKota);
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoProfile");            
            string fullPath = Path.Combine(path, formUtm.UserLogin.FotoProfile);
            pictureBoxProfilePict.Image = Image.FromFile(fullPath);
            pictureBoxProfilePict.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        bool ubhFoto = false;
        private void buttonPicture_Click(object sender, EventArgs e)
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
                pictureBoxProfilePict.Image = croppedImage;
                pictureBoxProfilePict.SizeMode = PictureBoxSizeMode.StretchImage;
                ubhFoto = true;
            }
        }
        FormUtama formUtm;
        private void buttonLogin_Click(object sender, EventArgs e)
        {                        
            string pathProfilePict = formUtm.UserLogin.Username + ".jpg"; ;
            string resourcesPathProfile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoProfile");
            string fullPathProfile = Path.Combine(resourcesPathProfile, pathProfilePict);
            if (!Directory.Exists(resourcesPathProfile))
            {
                Directory.CreateDirectory(resourcesPathProfile); // Membuat folder Resources jika belum ada
            }
            if (ubhFoto == true)
                pictureBoxProfilePict.Image.Save(fullPathProfile);

            formUtm.UserLogin.NamaLengkap = textBoxFullName.Text;
            formUtm.UserLogin.TglLahir = dateTimePickerTglLahir.Value.ToString("yyyy-MM-dd");
            formUtm.UserLogin.Email = textBoxEmail.Text;
            formUtm.UserLogin.Password = textBoxPassword.Text;
            if (!Kota.CekKota(comboBoxKota.Text))
            {
                formUtm.UserLogin.Kota = Kota.TambahData(comboBoxKota.Text);
            }
            else formUtm.UserLogin.Kota = (Kota)comboBoxKota.SelectedItem;
            User.UpdateData(formUtm.UserLogin);
        }
    }
}
