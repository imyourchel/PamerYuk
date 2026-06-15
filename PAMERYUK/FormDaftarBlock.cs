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
    public partial class FormDaftarBlock : Form
    {
        public FormDaftarBlock()
        {
            InitializeComponent();
        }

        FormUtama main;
        string searchUsername = ""; //untuk filter username2,
        
        private void FormDaftarBlock_Load(object sender, EventArgs e)
        {
            //casting this.MdiParent ke form utama (agar bisa akses member di form utama secara langsung)
            main = (FormUtama)this.MdiParent; 

            //menyimpan hasil method baca list blokir yang ada di class teman
            List<Teman> listBlokir = Teman.BacaDataTeman(main.UserLogin.Username, searchUsername, "blokir");

            dataGridViewSearch.DataSource = listBlokir;

            //hide column yang tidak diperlukan
            dataGridViewSearch.Columns["User"].Visible = false;
            dataGridViewSearch.Columns["TglBerteman"].Visible = false;
            dataGridViewSearch.Columns["Status"].Visible = false;

            //menambahkan button view profile dan unblock pada dgv
            if (dataGridViewSearch.Columns.Count == 4)
            {
                DataGridViewButtonColumn btnViewProfile = new DataGridViewButtonColumn();
                btnViewProfile.Text = "View Profile";
                btnViewProfile.HeaderText = "Action";
                btnViewProfile.UseColumnTextForButtonValue = true;
                btnViewProfile.Name = "btnViewProfileGrid";
                dataGridViewSearch.Columns.Add(btnViewProfile);

                DataGridViewButtonColumn btnBlokir = new DataGridViewButtonColumn();
                btnBlokir.Text = "Unblocked";
                btnBlokir.HeaderText = "Status";
                btnBlokir.UseColumnTextForButtonValue = true;
                btnBlokir.Name = "btnBlokirGrid";
                dataGridViewSearch.Columns.Add(btnBlokir);
            }
        }


        private void dataGridViewSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Friend adalah kolom yang dipanggil untuk diambil datanya pada current row
            string FriendUsername = dataGridViewSearch.CurrentRow.Cells["Friend"].Value.ToString();

            //e.ColumnIndex --> kolom yang diklik user
            //buttonUbahGrid --> button yang diciptakan di form load
            if (e.ColumnIndex == dataGridViewSearch.Columns["btnViewProfileGrid"].Index)
            {
                //Cara mendapatkan objek Teman yang dipilih dalam dgv
                Teman Friend = (Teman)dataGridViewSearch.Rows[e.RowIndex].DataBoundItem;
                FormProfileBlock frm = new FormProfileBlock(); // ganti ke form profile block
                frm.Owner = this;
                frm.Friend = Friend; //untuk mencatat other username yang akan di unblock
                frm.MyUsername = main.UserLogin.Username;
                frm.ShowDialog();

                // untuk refresh dgv
                FormDaftarBlock_Load(this, e);
            }

            else if (e.ColumnIndex == dataGridViewSearch.Columns["btnBlokirGrid"].Index)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to unblock " + FriendUsername + " ?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Teman t = new Teman();
                    t.UpdateUnblokir(main.UserLogin.Username , FriendUsername); //update data di mysql untuk menghapus status blokir pada kedua username tersebut
                    MessageBox.Show("Unblocking "+FriendUsername+" success"); //notif berhasil unblock
                }
                FormDaftarBlock_Load(this, e);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            searchUsername = textBoxSearch.Text; //mengisi value untuk filter username2
            FormDaftarBlock_Load(this, e); //reload dgv search setiap kali text box search berubah
        }
    }
}
