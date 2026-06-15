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
    public partial class FormKisahHidup : Form
    {
        public bool IsFromRegister;
        public FormKisahHidup()
        {
            InitializeComponent();
        }

        private void comboBoxTypeInstution_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormKisahHidup_Load(object sender, EventArgs e)
        {
            int butNormalW = buttonAdd.Size.Width;
            int butNormalH = buttonAdd.Size.Height;
            FormUtama frmUtama;
            if (IsFromRegister == true)
            {
                buttonAdd.Size = new Size((buttonAdd.Size.Width - buttonLogin.Size.Width) - 25, buttonLogin.Size.Height);
                frmUtama = (FormUtama)this.Owner;
            }
            else
            {
                buttonAdd.Size = new Size(butNormalW, butNormalH);
                this.Location = new Point(0, 0);
                frmUtama = (FormUtama)this.MdiParent;
            }
            listBoxKisahHidup.Items.Clear();
            List<KisahHidup> dpy = KisahHidup.BacaData(frmUtama.UserLogin);
            if (dpy != null)
            {
                foreach (KisahHidup kh in dpy)
                {
                    listBoxKisahHidup.Items.Add(kh.Organisasi.Nama + ", " + kh.Organisasi.Kota.NamaKota + " (" + kh.ThAwal + " - " + kh.ThAkhir + ")\n");
                }
            }
            dateTimePickerStart.Value = DateTime.Now;
            dateTimePickerEnd.Value = DateTime.Now;
            comboBoxTypeInstution.SelectedIndex = -1;
            richTextBoxDescription.Text = "";
            comboBoxPlaceInstitution.DataSource = Kota.BacaData();
            comboBoxPlaceInstitution.DisplayMember = "Nama";
            comboBoxPlaceInstitution.SelectedIndex = -1;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region pengecekan inputan
                if (string.IsNullOrWhiteSpace(textBoxInstutionName.Text))
                {
                    throw new Exception("Nama Institusi tidak boleh kosong");
                }
                if (string.IsNullOrWhiteSpace(comboBoxPlaceInstitution.Text))
                {
                    throw new Exception("Kota tidak boleh kosong");
                }
                if (string.IsNullOrWhiteSpace(comboBoxTypeInstution.Text))
                {
                    throw new Exception("Jenis Organisasi tidak boleh kosong");
                }
                if (dateTimePickerStart.Value > DateTime.Now)
                {
                    throw new Exception("Tanggal mulai tidak boleh melebihi tanggal hari ini");
                }
                if (dateTimePickerStart.Value > dateTimePickerEnd.Value)
                {
                    throw new Exception("Tanggal berakhir tidak boleh melebihi tanggal mulai");
                }
                #endregion pengecekan inputan
                FormUtama frmUtama = (FormUtama)this.Owner;
                KisahHidup tbh = new KisahHidup();
                tbh.User = frmUtama.UserLogin;

                Organisasi organisasi = new Organisasi();
                organisasi.Nama = textBoxInstutionName.Text;
                organisasi.Kota = (Kota)comboBoxPlaceInstitution.SelectedItem;
                organisasi.Jenis = comboBoxTypeInstution.Text;
                Organisasi.TambahData(organisasi);

                tbh.Organisasi = organisasi;
                tbh.ThAwal = dateTimePickerStart.Value.ToString("yyyy-MM-dd");
                tbh.ThAkhir = dateTimePickerEnd.Value.ToString("yyyy-MM-dd");
                tbh.Deskripsi = richTextBoxDescription.Text;

                KisahHidup.TambahData(tbh);
                FormKisahHidup_Load(sender, e);
                MessageBox.Show("Data berhasil disimpan", "Informasi");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            IsFromRegister = false;
            FormLogin frm = new FormLogin();
            frm.Owner = this.Owner;
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}
