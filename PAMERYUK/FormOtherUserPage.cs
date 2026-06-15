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
    public partial class FormOtherUserPage : Form
    {
        public FormOtherUserPage()
        {
            InitializeComponent();
        }

        public string myUsername;
        public Teman Friends;
        private void FormOtherUserPage_Load(object sender, EventArgs e)
        {
            Teman t = new Teman();
            string friendsUsername = Friends.Friend.Username;

            labelPost.Text = Konten.JumlahPost(friendsUsername).ToString();
            labelJumlahTeman.Text = Teman.JumlahTeman(friendsUsername).ToString();

            if (Friends != null)
            {
                labelUsername.Text = "@" + friendsUsername;
                labelName.Text = Friends.Friend.NamaLengkap;

                //pictureBoxProfile.D = profil.FotoProfile;
                string resourcesPathID = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoProfile");
                string fileName = friendsUsername + ".jpg";
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
                buttonNext.Visible = false;
                buttonPrevious.Visible = false;
                #endregion

                if (int.Parse(labelPost.Text) > 0)
                {
                    /* page Counter => saat ini ada di hlmn brp (menenentukan visible button next & prev)
                             * total page => jumlah hlmn yang akan ada ==> sbg indikator/parameter untuk mengetahui total pic
                             * total pic => jumlah post yang ada di 1 halaman ==> default 10 krn 1 hlmn berisi 10 pic box ==> berfungsi sbg max pic index jg
                             */
                    int currentPicIndex = 0, pageCounter = 1, totalPage, totalPic = 0;

                    //membuat list berisi picture path setiap post
                    Konten k = new Konten();
                    List<string> picPath = k.ListFotoKonten(myUsername);
                    while (picPath != null)
                    {
                        //membuat perhitungan untuk total page & total pic
                        totalPage = picPath.Count / 10;
                        if (totalPage == 1 | pageCounter != totalPage) totalPic = picPath.Count % 10;

                        //setting setiap picture box
                        if (currentPicIndex % 10 != totalPic)
                        {
                            //kalau ada page berarti min ada 1 konten, jd tdk perlu if
                            currentPicIndex = DisplayKontenPhoto(pictureBox1, picPath, currentPicIndex);

                            if (totalPic >= 2)
                            {
                                currentPicIndex = DisplayKontenPhoto(pictureBox2, picPath, currentPicIndex);
                            }
                            else if (totalPic >= 3)
                            {
                                currentPicIndex = DisplayKontenPhoto(pictureBox3, picPath, currentPicIndex);
                            }
                            else if (totalPic >= 4)
                            {
                                currentPicIndex = DisplayKontenPhoto(pictureBox4, picPath, currentPicIndex);
                            }
                            else if (totalPic >= 5)
                            {
                                currentPicIndex = DisplayKontenPhoto(pictureBox5, picPath, currentPicIndex);
                            }
                            else if (totalPic >= 6)
                            {
                                currentPicIndex = DisplayKontenPhoto(pictureBox6, picPath, currentPicIndex);
                            }
                            else if (totalPic >= 7)
                            {
                                currentPicIndex = DisplayKontenPhoto(pictureBox7, picPath, currentPicIndex);
                            }
                            else if (totalPic >= 8)
                            {
                                currentPicIndex = DisplayKontenPhoto(pictureBox8, picPath, currentPicIndex);
                            }
                            else if (totalPic >= 9)
                            {
                                currentPicIndex = DisplayKontenPhoto(pictureBox9, picPath, currentPicIndex);
                            }
                            else if (totalPic >= 10)
                            {
                                currentPicIndex = DisplayKontenPhoto(pictureBox10,picPath,currentPicIndex);
                            }
                        }

                        //setting visible button (next & prev)
                        int currentPage = (picPath.Count - (picPath.Count - currentPicIndex)) / 10;
                        if (currentPage == totalPage) buttonNext.Visible = false; //sdh di hlmn terakhir
                        if (totalPage != 1 || currentPage < totalPage) buttonPrevious.Visible = true; //hanya ada 1 hlmn atau tidak sedang berada di halaman terakhir 
                    }
                }
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }

        private int DisplayKontenPhoto (PictureBox pictureBox, List<string> picName, int currentPicIndex)
        {
            // path => create path dr folder2
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoKonten");
            string fullPathKonten = Path.Combine(path, picName[currentPicIndex]);
            pictureBox10.Image = Image.FromFile(fullPathKonten);
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.Visible = true;
            return currentPicIndex++;
        }

        private void buttonChat_Click(object sender, EventArgs e)
        {
            FormChat frm = new FormChat();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void buttonBlokir_Click(object sender, EventArgs e)
        {
            string friendsUsername = Friends.Friend.Username;
            DialogResult dialog = MessageBox.Show("Are you sure you want to block " + friendsUsername + " ?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Teman t = new Teman();
                t.TambahData(myUsername, friendsUsername, "blokir"); //tambah data di mysql untuk  status blokir pada username kedua
                MessageBox.Show("Blocking " + friendsUsername + " success"); //notif berhasil block
                this.Close();
                FormProfileBlock frm = new FormProfileBlock(); // ganti ke form profile block
                frm.Owner = this;
                frm.Friend = Friends; //untuk mencatat other username yang akan di block
                frm.MyUsername = myUsername;
                frm.ShowDialog();
            }
        }

        private void buttonFollow_Click(object sender, EventArgs e)
        {
            string friendsUsername = Friends.Friend.Username;

            Teman t = new Teman();
            t.TambahData(myUsername, friendsUsername, "request"); //tambah data di mysql untuk  status blokir pada username kedua
            MessageBox.Show("Requesting to follow " + friendsUsername); //notif berhasil req follow
            FormProfileBlock frm = new FormProfileBlock(); // ganti ke form profile block
            frm.Owner = this;
            frm.Friend = Friends; //untuk mencatat other username yang akan di block
            frm.MyUsername = myUsername;
            frm.ShowDialog();
            buttonFollow.Text = "Requesting";
            buttonFollow.Enabled = false;
        }
    }
}
