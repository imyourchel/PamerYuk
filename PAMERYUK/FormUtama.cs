using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_PamerYuk;

namespace PAMERYUK
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        public User UserLogin;
        public bool login = false;

        private void FormUtama_Load(object sender, EventArgs e)
        {
            Koneksi k = new Koneksi(); //membuka jembatan
            //MessageBox.Show("Koneksi berhasil");
            FormLogin form = new FormLogin();
            form.Owner = this;
            this.Visible = false;
            form.ShowDialog();
            this.IsMdiContainer = true;
            if (login == true)
            {
                labelUsername.Text = "Hai, "+ UserLogin.Username;
                labelUsername.Location = new Point((this.ClientSize.Width - labelUsername.Width) / 2);
            }

            this.WindowState = FormWindowState.Maximized;
        }


        #region Open Other Forms

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormSearch"];
            if (form == null)
            {
                FormSearch opForm = new FormSearch();
                opForm.MdiParent = this;
                opForm.Show();
                opForm.Location = new Point(0, 0);
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void friendsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarTeman"];
            if (form == null)
            {
                FormDaftarTeman opForm = new FormDaftarTeman();
                opForm.MdiParent = this;
                opForm.Show();
                opForm.Location = new Point(0, 0);
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void blockedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormDaftarBlock"];
            if (form == null)
            {
                FormDaftarBlock opForm = new FormDaftarBlock();
                opForm.MdiParent = this;
                opForm.Show();
                opForm.Location = new Point(0, 0);
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormNotifikasi"];
            if (form == null)
            {
                FormNotifikasi opForm = new FormNotifikasi();
                opForm.MdiParent = this;
                opForm.Show();
                opForm.Location = new Point(0, 0);
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormProfile"];
            if (form == null)
            {
                FormProfile opForm = new FormProfile();
                opForm.MdiParent = this;
                opForm.Show();
                opForm.Location = new Point(0, 0);
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormEditProfile"];
            if (form == null)
            {
                FormEditProfile opForm = new FormEditProfile();
                opForm.MdiParent = this;                
                opForm.Show();
                opForm.Location = new Point(0, 0);
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void editLifeHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormKisahHidup"];
            if (form == null)
            {
                FormKisahHidup opForm = new FormKisahHidup();
                opForm.MdiParent = this;
                opForm.Show();
                opForm.Location = new Point(0, 0);
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void uploadPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormUpload"];
            if (form == null)
            {
                FormUpload opForm = new FormUpload();
                opForm.MdiParent = this;
                opForm.Show();
                opForm.Location = new Point(0, 0);
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
        #endregion

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormOtherPost"];
            if (form == null)
            {
                FormOtherPost opForm = new FormOtherPost();
                opForm.MdiParent = this;
                opForm.Show();
                opForm.Location = new Point(0, 0);
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
    }
}
