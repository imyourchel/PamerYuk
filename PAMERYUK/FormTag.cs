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
    public partial class FormTag : Form
    {
        public FormTag()
        {
            InitializeComponent();
        }

        FormUpload frm;
        string searchUsername = "";
        public Konten post;

        private void FormTag_Load(object sender, EventArgs e)
        {
            frm = (FormUpload)this.Owner;

            //menyimpan hasil method baca list blokir yang ada di class teman
            List<string> listTeman = Teman.BacaDataTag(frm.main.UserLogin.Username, searchUsername);
            dataGridViewFriends.Rows.Clear(); dataGridViewFriends.Columns.Clear();
            dataGridViewFriends.Columns.Add("Username", "Username");

            foreach (string item in listTeman) { dataGridViewFriends.Rows.Add(item); }

            //menambahkan button pada masing2 dgv
            if (dataGridViewFriends.Columns.Count == 1)
            {
                DataGridViewButtonColumn btnViewAdd = new DataGridViewButtonColumn();
                btnViewAdd.Text = "Add to Tag";
                btnViewAdd.HeaderText = "Action";
                btnViewAdd.UseColumnTextForButtonValue = true;
                btnViewAdd.Name = "Add";
                dataGridViewFriends.Columns.Add(btnViewAdd);
            }

            if (dataGridViewTagged.Columns.Count == 0)
            {
                dataGridViewTagged.Columns.Add("Username", "Username");
            }
            if (dataGridViewTagged.Columns.Count == 1)
            {
                DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn();
                btnRemove.Text = "Remove from Tag";
                btnRemove.HeaderText = "Action";
                btnRemove.UseColumnTextForButtonValue = true;
                btnRemove.Name = "Remove";
                dataGridViewTagged.Columns.Add(btnRemove);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            searchUsername = textBoxSearch.Text; //mengisi value untuk filter username2
            FormTag_Load(this, e); //reload dgv search setiap kali text box search berubah
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Tag tag = new Tag();
            foreach (DataGridViewRow row in dataGridViewTagged.Rows)
            {
                if (row.Cells[0].Value != null) // Assuming the value you need is in the first cell
                {
                    string fun = row.Cells[0].Value.ToString();
                    tag.TambahData(post.IdKonten, fun);
                }
            }
            MessageBox.Show("Post and tag success");
            this.Close();
        }

        private void dataGridViewFriends_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string FriendUsername = dataGridViewFriends.CurrentRow.Cells["Username"].Value.ToString();
                string value = dataGridViewFriends.CurrentRow.Cells[0].Value.ToString();
                dataGridViewTagged.Rows.Add(value);
                dataGridViewFriends.CurrentRow.Cells[1].ReadOnly = true; //agar user tdk bs tag teman yang sama
                // untuk refresh dgv
                FormTag_Load(this, e);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dataGridViewTagged_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string FriendUsername = dataGridViewTagged.CurrentRow.Cells["Username"].Value.ToString();
                int selectedIndex = dataGridViewFriends.CurrentRow.Index; dataGridViewFriends.Rows.RemoveAt(selectedIndex);
                dataGridViewTagged.Rows.RemoveAt(selectedIndex);

                // untuk refresh dgv
                FormTag_Load(this, e);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
