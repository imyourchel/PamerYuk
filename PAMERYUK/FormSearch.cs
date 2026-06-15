using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Class_PamerYuk;

namespace PAMERYUK
{
    public partial class FormSearch : Form
    {
        string filter = "";
        string nilai = "";
        public FormSearch()
        {
            InitializeComponent();
        }
        private void FormSearch_Load(object sender, EventArgs e)
        {
            FormUtama main = (FormUtama)this.MdiParent;
            List<User> listhasil = User.BacaData(filter, nilai, main.UserLogin.Username);
            dataGridViewSearch.DataSource = listhasil;
            if (dataGridViewSearch.ColumnCount == 9)
            {
                DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn();
                btnDetail.HeaderText = "Action";
                btnDetail.Text = "View Profile";
                btnDetail.UseColumnTextForButtonValue = true;
                btnDetail.Name = "buttonDetailGrid";
                dataGridViewSearch.Columns.Add(btnDetail);
            }
            dataGridViewSearch.DefaultCellStyle.ForeColor = Color.Black;
            dataGridViewSearch.Columns["Username"].Visible = true;
            dataGridViewSearch.Columns["Password"].Visible = false;
            dataGridViewSearch.Columns["namalengkap"].Visible = false;
            dataGridViewSearch.Columns["tgllahir"].Visible = false;
            dataGridViewSearch.Columns["noktp"].Visible = false;
            dataGridViewSearch.Columns["fotodiri"].Visible = false;
            dataGridViewSearch.Columns["fotoprofile"].Visible = false;
            dataGridViewSearch.Columns["email"].Visible = false;
            dataGridViewSearch.Columns["kota"].Visible = false;
        }

        private void comboBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxKategori.SelectedIndex == 0)
            {
                filter = "SD";
            }
            else if (comboBoxKategori.SelectedIndex == 1)
            {
                filter = "SMP";
            }
            else if (comboBoxKategori.SelectedIndex == 2)
            {
                filter = "SMA";
            }
            else if (comboBoxKategori.SelectedIndex == 3)
            {
                filter = "Kuliah";
            }
            else if (comboBoxKategori.SelectedIndex == 4)
            {
                filter = "Tempat Kerja";
            }
            else if (comboBoxKategori.SelectedIndex == 5)
            {
                filter = "Organisasi";
            }
            nilai = textBoxSearch.Text;
            FormSearch_Load(sender, e);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxKategori.SelectedIndex == 0)
            {
                filter = "SD";
            }
            else if (comboBoxKategori.SelectedIndex == 1)
            {
                filter = "SMP";
            }
            else if (comboBoxKategori.SelectedIndex == 2)
            {
                filter = "SMA";
            }
            else if (comboBoxKategori.SelectedIndex == 3)
            {
                filter = "Kuliah";
            }
            else if (comboBoxKategori.SelectedIndex == 4)
            {
                filter = "Tempat Kerja";
            }
            else if (comboBoxKategori.SelectedIndex == 5)
            {
                filter = "Organisasi";
            }
            nilai = textBoxSearch.Text;
            FormSearch_Load(sender, e);
        }

        private void dataGridViewSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
