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
    public partial class FormOtherPost : Form
    {
        public FormOtherPost()
        {
            InitializeComponent();
        }
        FormUtama frmUtama;
        int genIdKomen=0;
        private void FormOtherPost_Load(object sender, EventArgs e)
        {
            int idcontent = 2;
            frmUtama = (FormUtama)this.MdiParent; //casting this.MdiParent ke form utama (agar bisa akses member di form utama secara langsung)
            string username = frmUtama.UserLogin.Username; //menyimpan username dari user yang sedang login
            labelUsername.Text = "@" + username;
            Konten konten = Konten.BacaDataKonten(idcontent); //menyimpan hasil method baca data konten yang ada di class konten
            richTextBoxCaption.Text = konten.Caption + "\n\n" + konten.TglUpload;
            //listBoxCaption.Items.Add(konten.Caption);
            //listBoxCaption.Items.Add(konten.TglUpload);

            LoadKomen(idcontent);//refresh komen (listbox selalu terupdate setiap mengirim komen)
        }

        private void buttonComment_Click(object sender, EventArgs e)
        {
            if (textBoxComment.Text == "")
            {
                MessageBox.Show("Please write a comment before submitting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GenerateIdKomen();
                Komen.TambahKomen(genIdKomen,textBoxComment.Text, frmUtama.UserLogin.Username, 1);
                textBoxComment.Text = "";;
                LoadKomen(1);
            }
        }
        private void LoadKomen(int idcontent)
        {
            listBoxComment.Items.Clear();
            List<Komen> listKomen = Komen.BacaListKomen(idcontent);//menyimpan hasil method baca list komen yang ada di class komen
            foreach (Komen kmn in listKomen)
            {
                listBoxComment.Items.Add("[" + kmn.TglKomentar + "] @" + kmn.User.Username + " : " + kmn.Komentar);
            }
        }
        private void GenerateIdKomen()
        {
            int jumlah = Komen.JumlahKomen();
            if(jumlah == 0)
            {
                genIdKomen = 0;
            }
            else
            {
                genIdKomen = Komen.AmbilIdLastKomen() + 1;
            }
        }
    }
}
