using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_PamerYuk;

namespace PAMERYUK
{
    public partial class FormChat : Form
    {       
        public string selectedFriendUsername;
        User selectedFriend;
        User currentUser;
        FormUtama formUtm;
        public FormChat()
        {
            InitializeComponent();
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            formUtm = (FormUtama)this.MdiParent;  
            currentUser = formUtm.UserLogin;
            dataGridViewFriends.DataSource = Teman.AmbilDataTeman(currentUser.Username);
            dataGridViewFriends.Columns["User"].Visible = false;
            dataGridViewFriends.Columns["TglBerteman"].Visible = false;
            dataGridViewFriends.Columns["Status"].Visible = false;
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Resources", "PhotoProfile");
            string fullPath = Path.Combine(path, selectedFriendUsername+".jpg");
            pictureBoxProfile.Image = Image.FromFile(fullPath);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            labelUsername.Text = "@"+ selectedFriendUsername;
            selectedFriend = User.GetUserByUsername(selectedFriendUsername);

            if (dataGridViewFriends.ColumnCount >0)
            {
                DataGridViewButtonColumn btnChat = new DataGridViewButtonColumn();
                btnChat.HeaderText = "Action";
                btnChat.Text = "Chat";
                btnChat.UseColumnTextForButtonValue = true;
                btnChat.Name = "buttonChatGrid";
                dataGridViewFriends.Columns.Add(btnChat);
            }
            LoadMessages();
        }                                              
        private void LoadMessages()
        {
            listBoxChat.Items.Clear();
            if (selectedFriend != null)
            {
                List<Percakapan> messages = Percakapan.AmbilPesan(currentUser, selectedFriend);
                foreach (var message in messages)
                {
                    DateTime timestamp = DateTime.Parse(message.WktKirim);
                    string waktu = timestamp.ToString("hh:mm tt, dd/M/yyyy").ToLower();
                    string sender = message.User.Username == currentUser.Username ? "You" : message.User.Username;
                    string displayMessage = $"[{waktu}] {sender}: {message.Pesan}";
                    listBoxChat.Items.Add(displayMessage);
                }
            }
        }        
        private void buttonSend_Click_1(object sender, EventArgs e)
        {
            string newMessage = textBoxChat.Text;
            if (!string.IsNullOrEmpty(newMessage))
            {
                Percakapan message = new Percakapan(currentUser, selectedFriend, newMessage, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                message.SimpanPesan();
                textBoxChat.Clear();
                LoadMessages();
            }
        }

        private void dataGridViewFriends_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewFriends.Columns["buttonChatGrid"].Index)
            {
                selectedFriendUsername = dataGridViewFriends.CurrentRow.Cells["Friend"].Value.ToString();
                FormChat_Load(sender, e);
            }
        }
    }
}
