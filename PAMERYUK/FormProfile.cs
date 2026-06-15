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
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }
        FormUtama main;
        private int currentStartIndex;
        private int totalImages;
        private List<PictureBox> pictureBoxes;
        private void FormProfile_Load(object sender, EventArgs e)
        {
            main = (FormUtama)this.MdiParent;
            string username = main.UserLogin.Username;
            Teman t = new Teman();

            labelPost.Text = Konten.JumlahPost(username).ToString();
            labelJumlahTeman.Text = Teman.JumlahTeman(username).ToString();

            if (main.UserLogin != null)
            {
                labelUsername.Text = "@" + main.UserLogin.Username;
                labelName.Text = main.UserLogin.NamaLengkap;

                //pictureBoxProfile.D = profil.FotoProfile;
                string resourcesPathID = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoProfile");
                string fileName = main.UserLogin.Username + ".jpg";
                string fullPath = Path.Combine(resourcesPathID, fileName);

                //Load picture profile
                pictureBoxProfile.Image = Image.FromFile(fullPath);
                pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;

                //Post

                #region Setting visible pic box jd false
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                #endregion

                // Inisialisasi list untuk menyimpan referensi semua PictureBox
                pictureBoxes = new List<PictureBox>
                {
                    pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                    pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10
                };
                //LoadAndSortImageFiles();
                // Hitung total gambar yang tersedia di folder PhotoKonten
                totalImages = CountImagesInResources();

                // Mulai dari indeks terbesar
                currentStartIndex = totalImages;

                // Tampilkan gambar pertama kali
                LoadImages();
               
            }
            else
            {
                MessageBox.Show("User data not found");
            }
        }
        private int CountImagesInResources()
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoKonten");
            if (!Directory.Exists(path))
                return 0;

            // Hitung jumlah file dengan ekstensi .jpg di folder
            return Directory.GetFiles(path, "*.jpg").Length;
        }

        private void LoadImages()
        {
            Konten k = new Konten();
            List<string> picPath = k.ListFotoKonten(main.UserLogin.Username);
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoKonten");
            if (!Directory.Exists(path))
                return;
            
            // Reset semua PictureBox
            foreach (PictureBox pb in pictureBoxes)
            {
                pb.Image = null;
                pb.Visible = false;
            }

            // Load 10 gambar dari indeks saat ini
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                int imageIndex = currentStartIndex - i - 1;

                // Check if index is valid
                if (imageIndex >= 0 && imageIndex < picPath.Count)  // or picPath.Length if it's an array
                {
                    string filePath = Path.Combine(path, picPath[imageIndex]);

                    if (File.Exists(filePath))
                    {
                        try
                        {
                            pictureBoxes[i].Image = Image.FromFile(filePath);
                            pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBoxes[i].Visible = true;

                        }
                        catch (Exception ex)
                        {
                            // Handle image loading errors
                            Console.WriteLine($"Error loading image: {ex.Message}");
                        }
                    }
                }
            }
            // Update visibility tombol Previous dan Next
            buttonPrevious.Enabled = currentStartIndex < totalImages;
            buttonNext.Enabled = currentStartIndex > 10;
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormEditProfile frm = new FormEditProfile();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentStartIndex < totalImages)
            {
                buttonPrevious.Visible = true;
                currentStartIndex += 10;
                if (currentStartIndex > totalImages)
                {
                    currentStartIndex = totalImages;
                }
                LoadImages();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentStartIndex > 10)
            {
                buttonNext.Visible = true;
                currentStartIndex -= 10;
                LoadImages();
            }
        }
    }
}
