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
    public partial class FormProfileBlock : Form
    {
        public FormProfileBlock()
        {
            InitializeComponent();
        }

        FormUtama main;
        public Teman Friend;
        public string MyUsername;

        private void FormProfileBlock_Load(object sender, EventArgs e)
        {
            //display yang dibutuhkan
            labelUsername.Text = "@"+Friend.Friend.Username;
            labelName.Text = Friend.Friend.NamaLengkap;
            labelPost.Text = Konten.JumlahPost(Friend.Friend.Username).ToString();
            labelJumlahTeman.Text = "0";

            //load photo profile
            string resourcesPathID = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoProfile");
            string fileName = Friend.Friend.FotoProfile;
            string fullPath = Path.Combine(resourcesPathID, fileName);

            // Memuat gambar dari file
            pictureBoxProfile.Image = Image.FromFile(fullPath);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void buttonUnblock_Click(object sender, EventArgs e)
        {
            Teman t = new Teman();

            //update data di mysql untuk menghapus status blokir pada kedua username tersebut
            t.UpdateUnblokir(MyUsername, Friend.Friend.Username); 
            
            //close form profile block biar bisa format display nya pindah ke other user page
            this.Close();

            //notif berhasil unblock
            MessageBox.Show("Unblocking " + Friend.Friend.Username + " success");

            // ganti ke form other user page
            FormOtherUserPage frm = new FormOtherUserPage();
            frm.Owner = this;
            frm.myUsername = MyUsername;
            frm.Friends = Friend;
            frm.ShowDialog();
        }
    }
}
