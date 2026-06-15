namespace PAMERYUK
{
    partial class FormProfileBlock
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
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.labelJumlahTeman = new System.Windows.Forms.Label();
            this.labelPost = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonUnblock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxProfile.Location = new System.Drawing.Point(102, 27);
            this.pictureBoxProfile.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(110, 110);
            this.pictureBoxProfile.TabIndex = 38;
            this.pictureBoxProfile.TabStop = false;
            // 
            // labelJumlahTeman
            // 
            this.labelJumlahTeman.BackColor = System.Drawing.Color.Transparent;
            this.labelJumlahTeman.Font = new System.Drawing.Font("Rockwell", 14F, System.Drawing.FontStyle.Bold);
            this.labelJumlahTeman.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(206)))));
            this.labelJumlahTeman.Location = new System.Drawing.Point(614, 27);
            this.labelJumlahTeman.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelJumlahTeman.Name = "labelJumlahTeman";
            this.labelJumlahTeman.Size = new System.Drawing.Size(56, 24);
            this.labelJumlahTeman.TabIndex = 47;
            this.labelJumlahTeman.Text = "0000";
            this.labelJumlahTeman.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPost
            // 
            this.labelPost.BackColor = System.Drawing.Color.Transparent;
            this.labelPost.Font = new System.Drawing.Font("Rockwell", 14F, System.Drawing.FontStyle.Bold);
            this.labelPost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(206)))));
            this.labelPost.Location = new System.Drawing.Point(449, 27);
            this.labelPost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(56, 24);
            this.labelPost.TabIndex = 46;
            this.labelPost.Text = "0000";
            this.labelPost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(206)))));
            this.labelName.Location = new System.Drawing.Point(217, 57);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(93, 18);
            this.labelName.TabIndex = 45;
            this.labelName.Text = "Rachel R. A.";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Rockwell", 14F, System.Drawing.FontStyle.Bold);
            this.labelUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(206)))));
            this.labelUsername.Location = new System.Drawing.Point(216, 27);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(179, 23);
            this.labelUsername.TabIndex = 44;
            this.labelUsername.Text = "@rachel_rosalind";
            // 
            // buttonUnblock
            // 
            this.buttonUnblock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(206)))));
            this.buttonUnblock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUnblock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUnblock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonUnblock.Location = new System.Drawing.Point(579, 113);
            this.buttonUnblock.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUnblock.Name = "buttonUnblock";
            this.buttonUnblock.Size = new System.Drawing.Size(126, 24);
            this.buttonUnblock.TabIndex = 43;
            this.buttonUnblock.Text = "Unblock";
            this.buttonUnblock.UseVisualStyleBackColor = false;
            this.buttonUnblock.Click += new System.EventHandler(this.buttonUnblock_Click);
            // 
            // FormProfileBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PAMERYUK.Properties.Resources.Other_User_Page_kosong;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(812, 474);
            this.Controls.Add(this.labelJumlahTeman);
            this.Controls.Add(this.labelPost);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonUnblock);
            this.Controls.Add(this.pictureBoxProfile);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormProfileBlock";
            this.Load += new System.EventHandler(this.FormProfileBlock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label labelJumlahTeman;
        private System.Windows.Forms.Label labelPost;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonUnblock;
    }
}