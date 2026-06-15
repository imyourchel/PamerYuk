namespace PAMERYUK
{
    partial class FormNotifikasi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewPermintaanPertemanan = new System.Windows.Forms.DataGridView();
            this.listViewNotifikasi = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermintaanPertemanan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPermintaanPertemanan
            // 
            this.dataGridViewPermintaanPertemanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPermintaanPertemanan.Location = new System.Drawing.Point(72, 217);
            this.dataGridViewPermintaanPertemanan.Name = "dataGridViewPermintaanPertemanan";
            this.dataGridViewPermintaanPertemanan.RowHeadersWidth = 62;
            this.dataGridViewPermintaanPertemanan.RowTemplate.Height = 28;
            this.dataGridViewPermintaanPertemanan.Size = new System.Drawing.Size(391, 410);
            this.dataGridViewPermintaanPertemanan.TabIndex = 2;
            this.dataGridViewPermintaanPertemanan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPermintaanPertemanan_CellContentClick);
            // 
            // listViewNotifikasi
            // 
            this.listViewNotifikasi.HideSelection = false;
            this.listViewNotifikasi.Location = new System.Drawing.Point(542, 217);
            this.listViewNotifikasi.Name = "listViewNotifikasi";
            this.listViewNotifikasi.Size = new System.Drawing.Size(608, 410);
            this.listViewNotifikasi.TabIndex = 3;
            this.listViewNotifikasi.UseCompatibleStateImageBehavior = false;
            // 
            // FormNotifikasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PAMERYUK.Properties.Resources.Notifikasi___KOSONG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1218, 729);
            this.Controls.Add(this.listViewNotifikasi);
            this.Controls.Add(this.dataGridViewPermintaanPertemanan);
            this.DoubleBuffered = true;
            this.Name = "FormNotifikasi";
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.FormNotifikasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPermintaanPertemanan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPermintaanPertemanan;
        private System.Windows.Forms.ListView listViewNotifikasi;
    }
}