using Class_PamerYuk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAMERYUK
{
    public partial class FormDaftarTeman : Form
    {
        public FormDaftarTeman()
        {
            InitializeComponent();
        }
        FormUtama frmUtama;
        string searchUsername = "";
        private void FormDaftarTeman_Load(object sender, EventArgs e)
        {
            frmUtama = (FormUtama)this.MdiParent; //casting this.MdiParent ke form utama (agar bisa akses member di form utama secara langsung)
            string username = frmUtama.UserLogin.Username; //menyimpan username dari user yang sedang login
            List<Teman> listTeman = Teman.BacaListTeman(username, searchUsername); //menyimpan hasil method baca list teman yang ada di class teman
            dataGridViewSearch.DataSource = listTeman;
            dataGridViewSearch.Columns["User"].Visible = false;
            dataGridViewSearch.Columns["TglBerteman"].Visible = false;
            dataGridViewSearch.Columns["Status"].Visible = false;

            //membuat button hapus teman dan chat
            if (dataGridViewSearch.Columns.Count == 4)
            {
                DataGridViewButtonColumn btnHapus = new DataGridViewButtonColumn();
                btnHapus.Text = "Unfollow";
                btnHapus.HeaderText = "Action";
                btnHapus.UseColumnTextForButtonValue = true;
                btnHapus.Name = "btnHapusGrid";
                dataGridViewSearch.Columns.Add(btnHapus);

                DataGridViewButtonColumn btnChat = new DataGridViewButtonColumn();
                btnChat.Text = "Chat";
                btnChat.HeaderText = "Action";
                btnChat.UseColumnTextForButtonValue = true;
                btnChat.Name = "btnChatGrid";
                dataGridViewSearch.Columns.Add(btnChat);

                DataGridViewButtonColumn btnViewProfile = new DataGridViewButtonColumn();
                btnViewProfile.Text = "View Profile";
                btnViewProfile.HeaderText = "Action";
                btnViewProfile.UseColumnTextForButtonValue = true;
                btnViewProfile.Name = "btnViewProfileGrid";
                dataGridViewSearch.Columns.Add(btnViewProfile);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            searchUsername = textBoxSearch.Text; //mengisi value untuk filter username2
            FormDaftarTeman_Load(this, e); //reload dgv search setiap kali text box search berubah
        }

        private void dataGridViewSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string FriendUsername = dataGridViewSearch.CurrentRow.Cells["Friend"].Value.ToString();//Friend adalah kolom yang dipanggil untuk diambil datanya pada current row

            //e.ColumnIndex --> kolom yang diklik user
            //buttonUbahGrid --> button yang diciptakan di form load
            if (e.ColumnIndex == dataGridViewSearch.Columns["btnHapusGrid"].Index)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to unfollow " + FriendUsername + " ?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Teman t = new Teman();
                    t.HapusTeman(FriendUsername, frmUtama.UserLogin.Username); //hapus data teman dengan kedua username tsb 
                    MessageBox.Show("Unfollow " + FriendUsername + " success"); //notif berhasil unfollow
                }
                FormDaftarTeman_Load(this, e);
            }
            if (e.ColumnIndex == dataGridViewSearch.Columns["btnChatGrid"].Index)
            {
                FormChat form = new FormChat();
                // Set MdiParent ke FormUtama, bukan Owner
                form.MdiParent = this.MdiParent;  // atau bisa juga form.MdiParent = frmUtama;
                form.selectedFriendUsername = FriendUsername;
                form.Show();  // Gunakan Show() bukan ShowDialog() untuk MDI child
                FormDaftarTeman_Load(sender, e);
            }
            if (e.ColumnIndex == dataGridViewSearch.Columns["btnViewProfileGrid"].Index)
            {
                FormUtama main;
                //Cara mendapatkan objek Teman yang dipilih dalam dgv
                Teman Friend = (Teman)dataGridViewSearch.Rows[e.RowIndex].DataBoundItem;
                FormOtherUserPage frm = new FormOtherUserPage(); // ganti ke form profile block
                frm.Owner = this;
                frm.Friends = Friend; //untuk mencatat other username yang akan di unblock
                frm.myUsername = frmUtama.UserLogin.Username;
                frm.ShowDialog();
                FormDaftarTeman_Load(sender, e);
            }
        }
    }
}
