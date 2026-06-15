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
//using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;
//using static System.Net.Mime.MediaTypeNames;

namespace PAMERYUK
{
    public partial class FormRegister : Form
    {        
        public FormRegister()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            form.Owner = this;
            form.ShowDialog();
            this.Close();
        }       

        private void FormRegister_Load(object sender, EventArgs e)
        {
            dateTimePickerTglLahir.Value = DateTime.Now;
            comboBoxKota.DataSource = Kota.BacaData();
            comboBoxKota.DisplayMember = "Nama";
            comboBoxKota.SelectedIndex = -1;            
        }        
        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                #region pengecekan inputan
                User tbh = new User();
                //nama lengkap
                if (string.IsNullOrWhiteSpace(textBoxFullName.Text))
                {
                    throw new Exception("Nama lengkap tidak boleh kosong");
                }
                tbh.NamaLengkap = textBoxFullName.Text;

                //no KTP
                if (string.IsNullOrWhiteSpace(textBoxIDNumber.Text))
                {
                    throw new Exception("No KTP tidak boleh kosong");
                }
                else if (!textBoxIDNumber.Text.All(char.IsDigit))
                {
                    throw new Exception("No KTP harus terdiri dari angka");
                }
                else if (textBoxIDNumber.Text.Length != 16)
                {
                    throw new Exception("No KTP harus 16 digit");
                }
                tbh.NoKTP = textBoxIDNumber.Text;

                //username
                if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
                {
                    throw new Exception("Username tidak boleh kosong");
                }
                else
                {
                    if (User.CekUsername(textBoxUsername.Text))
                    {
                        throw new Exception("Username sudah terdaftar");
                    }
                }
                tbh.Username = textBoxUsername.Text;

                //email
                if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
                {
                    throw new Exception("Email tidak boleh kosong");
                }
                tbh.Email = textBoxEmail.Text;

                //password
                if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    throw new Exception("Password tidak boleh kosong");
                }
                tbh.Password = textBoxPassword.Text;

                //tanggal lahir
                if (dateTimePickerTglLahir.Value > DateTime.Now)
                {
                    throw new Exception("Tanggal lahir tidak boleh melebihi tanggal hari ini");
                }
                tbh.TglLahir = dateTimePickerTglLahir.Value.ToString("yyyy-MM-dd");

                //kota
                if (string.IsNullOrWhiteSpace(comboBoxKota.Text))
                {
                    throw new Exception("Kota tidak boleh kosong");
                }
                else if (!Kota.CekKota(comboBoxKota.Text))
                {
                    tbh.Kota = Kota.TambahData(comboBoxKota.Text);
                }
                else
                {
                    comboBoxKota.SelectedIndex = comboBoxKota.FindStringExact(comboBoxKota.Text);
                    tbh.Kota = (Kota)comboBoxKota.SelectedItem;
                }

                //foto
                tbh.FotoDiri = textBoxUsername.Text + ".jpg";
                tbh.FotoProfile = textBoxUsername.Text + ".jpg";
                string pathIDPict = null;
                string pathProfilePict = null;
                if (pictureBoxIDPict.Image != null)
                {
                    pathIDPict = tbh.Username + ".jpg";
                }
                else
                {
                    throw new Exception("ID pict nda boleh kosong");
                }
                if (pictureBoxProfilePict.Image != null)
                {
                    pathProfilePict = tbh.Username + ".jpg";
                }
                else
                {
                    throw new Exception("Profile pict nda boleh kosong");
                }
                #endregion pengecekan inputan

                #region save pict
                //save ID pict ke folder resources
                string resourcesPathID = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoID");
                string fullPathID = Path.Combine(resourcesPathID, pathIDPict);
                if (!Directory.Exists(resourcesPathID))
                {
                    Directory.CreateDirectory(resourcesPathID); // Membuat folder Resources jika belum ada
                }
                pictureBoxIDPict.Image.Save(fullPathID);
                //save profile pict ke folder resources 
                string resourcesPathProfile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoProfile");
                string fullPathProfile = Path.Combine(resourcesPathProfile, pathProfilePict);
                if (!Directory.Exists(resourcesPathProfile))
                {
                    Directory.CreateDirectory(resourcesPathProfile); // Membuat folder Resources jika belum ada
                }
                pictureBoxProfilePict.Image.Save(fullPathProfile);
                #endregion save pict

                User.TambahData(tbh);
                FormUtama frmUtama = (FormUtama)this.Owner;
                frmUtama.UserLogin = tbh;

                FormKisahHidup frm = new FormKisahHidup();
                frm.Owner = this.Owner;
                frm.IsFromRegister = true;
                this.Hide();        
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }        
        private void pictureBoxIDPict_Click(object sender, EventArgs e)
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
                pictureBoxIDPict.Image = croppedImage;
                pictureBoxIDPict.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void pictureBoxProfilePict_Click(object sender, EventArgs e)
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
            }
        }        
    }
}
