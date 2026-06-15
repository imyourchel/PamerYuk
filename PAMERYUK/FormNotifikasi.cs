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
    public partial class FormNotifikasi : Form
    {
        public FormNotifikasi()
        {
            InitializeComponent();
        }
        FormUtama frmUtama;
        string searchUsername = "";
        private void FormNotifikasi_Load(object sender, EventArgs e)
        {
            frmUtama = (FormUtama)this.MdiParent; //casting this.MdiParent ke form utama (agar bisa akses member di form utama secara langsung)
            string username = frmUtama.UserLogin.Username; //menyimpan username dari user yang sedang login
            List<Teman> listRequest = Teman.BacaListRequest(username, searchUsername); //menyimpan hasil method baca list request yang ada di class teman
            dataGridViewPermintaanPertemanan.DataSource = listRequest;
            dataGridViewPermintaanPertemanan.Columns["User"].Visible = false;
            dataGridViewPermintaanPertemanan.Columns["TglBerteman"].Visible = false;
            dataGridViewPermintaanPertemanan.Columns["Status"].Visible = false;

            if (dataGridViewPermintaanPertemanan.Columns.Count == 4)
            {
                DataGridViewButtonColumn btnAccept = new DataGridViewButtonColumn();
                btnAccept.Text = "Accept";
                btnAccept.HeaderText = "Action";
                btnAccept.UseColumnTextForButtonValue = true;
                btnAccept.Name = "btnAcceptGrid";
                dataGridViewPermintaanPertemanan.Columns.Add(btnAccept);
            }
            List<Notifikasi> hasil = Notifikasi.GabungNotif(username); // untuk menyimpan gabungan list dari class notifikasi
            List<string> listNotif = hasil.Select(Notifikasi => Notifikasi.IsiNotif).ToList();

            listViewNotifikasi.Items.Clear();
            listViewNotifikasi.View = View.Details;
            listViewNotifikasi.FullRowSelect = true;
            listViewNotifikasi.Columns.Add("Notifikasi", 250, HorizontalAlignment.Left);
            listViewNotifikasi.Columns.Add("Tanggal", 150, HorizontalAlignment.Right);

            foreach (Notifikasi notif in hasil)
            {
                ListViewItem item = new ListViewItem(notif.IsiNotif);
                item.SubItems.Add(notif.Tgl.ToString());
                listViewNotifikasi.Items.Add(item);
            }
        }

        private void dataGridViewPermintaanPertemanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string FriendUsername = dataGridViewPermintaanPertemanan.CurrentRow.Cells["Friend"].Value.ToString();//Friend adalah kolom yang dipanggil untuk diambil datanya pada current row

            //e.ColumnIndex --> kolom yang diklik user
            //buttonUbahGrid --> button yang diciptakan di form load
            if (e.ColumnIndex == dataGridViewPermintaanPertemanan.Columns["btnAcceptGrid"].Index)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to be friend with " + FriendUsername + " ?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    Teman t = new Teman();
                    t.TambahTeman(frmUtama.UserLogin.Username, FriendUsername); //tambah teman di database untuk kedua username tersebut
                    MessageBox.Show(FriendUsername + " is your friend now"); //notif berhasil accept/tambah teman
                }
                FormNotifikasi_Load(this, e);
            }
        }
    }
}
