namespace PAMERYUK
{
    partial class FormTag
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
            this.dataGridViewFriends = new System.Windows.Forms.DataGridView();
            this.dataGridViewTagged = new System.Windows.Forms.DataGridView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFriends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagged)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFriends
            // 
            this.dataGridViewFriends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFriends.Location = new System.Drawing.Point(99, 178);
            this.dataGridViewFriends.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewFriends.Name = "dataGridViewFriends";
            this.dataGridViewFriends.RowHeadersWidth = 51;
            this.dataGridViewFriends.RowTemplate.Height = 24;
            this.dataGridViewFriends.Size = new System.Drawing.Size(247, 251);
            this.dataGridViewFriends.TabIndex = 3;
            this.dataGridViewFriends.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFriends_CellContentClick);
            // 
            // dataGridViewTagged
            // 
            this.dataGridViewTagged.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTagged.Location = new System.Drawing.Point(483, 178);
            this.dataGridViewTagged.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTagged.Name = "dataGridViewTagged";
            this.dataGridViewTagged.RowHeadersWidth = 51;
            this.dataGridViewTagged.RowTemplate.Height = 24;
            this.dataGridViewTagged.Size = new System.Drawing.Size(241, 251);
            this.dataGridViewTagged.TabIndex = 4;
            this.dataGridViewTagged.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTagged_CellContentClick);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(604, 147);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 26);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(180, 148);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(166, 26);
            this.textBoxSearch.TabIndex = 7;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // FormTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PAMERYUK.Properties.Resources.TAG___KOSONG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(812, 474);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewTagged);
            this.Controls.Add(this.dataGridViewFriends);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTag";
            this.Text = "Tag";
            this.Load += new System.EventHandler(this.FormTag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFriends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagged)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewFriends;
        private System.Windows.Forms.DataGridView dataGridViewTagged;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}