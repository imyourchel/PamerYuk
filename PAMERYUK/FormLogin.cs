using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class_PamerYuk;

namespace PAMERYUK
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister form = new FormRegister();
            form.Owner = this.Owner;
            form.ShowDialog();
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string pwd = textBoxPwd.Text;
            FormUtama form = (FormUtama)this.Owner;
            form.UserLogin = User.CekLogin(username, pwd);
            if (form.UserLogin is null)
            {
                MessageBox.Show("Username atau password tidak cocok. Silakan coba lagi", "PERINGATAN!");
                form.login = false;
            }
            else
            {
                MessageBox.Show("Login Berhasil");
                form.Visible = true;
                this.Close();
                form.login = true;
            }
        }
    }
}
