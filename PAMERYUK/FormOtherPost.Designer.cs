namespace PAMERYUK
{
    partial class FormOtherPost
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.buttonComment = new System.Windows.Forms.Button();
            this.listBoxComment = new System.Windows.Forms.ListBox();
            this.listBoxCaption = new System.Windows.Forms.ListBox();
            this.pictureBoxPost = new System.Windows.Forms.PictureBox();
            this.richTextBoxCaption = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.labelUsername.Location = new System.Drawing.Point(90, 166);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(274, 29);
            this.labelUsername.TabIndex = 19;
            this.labelUsername.Text = "@rachel_rosalind0410";
            // 
            // textBoxComment
            // 
            this.textBoxComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxComment.Location = new System.Drawing.Point(498, 615);
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(421, 35);
            this.textBoxComment.TabIndex = 18;
            // 
            // buttonComment
            // 
            this.buttonComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonComment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(206)))));
            this.buttonComment.Location = new System.Drawing.Point(927, 615);
            this.buttonComment.Name = "buttonComment";
            this.buttonComment.Size = new System.Drawing.Size(188, 43);
            this.buttonComment.TabIndex = 17;
            this.buttonComment.Text = "COMMENT";
            this.buttonComment.UseVisualStyleBackColor = false;
            this.buttonComment.Click += new System.EventHandler(this.buttonComment_Click);
            // 
            // listBoxComment
            // 
            this.listBoxComment.Font = new System.Drawing.Font("Arial", 8F);
            this.listBoxComment.FormattingEnabled = true;
            this.listBoxComment.ItemHeight = 18;
            this.listBoxComment.Location = new System.Drawing.Point(496, 226);
            this.listBoxComment.Name = "listBoxComment";
            this.listBoxComment.Size = new System.Drawing.Size(616, 364);
            this.listBoxComment.TabIndex = 16;
            // 
            // listBoxCaption
            // 
            this.listBoxCaption.Font = new System.Drawing.Font("Arial", 8F);
            this.listBoxCaption.FormattingEnabled = true;
            this.listBoxCaption.ItemHeight = 18;
            this.listBoxCaption.Location = new System.Drawing.Point(96, 546);
            this.listBoxCaption.Name = "listBoxCaption";
            this.listBoxCaption.Size = new System.Drawing.Size(322, 112);
            this.listBoxCaption.TabIndex = 15;
            // 
            // pictureBoxPost
            // 
            this.pictureBoxPost.Location = new System.Drawing.Point(96, 202);
            this.pictureBoxPost.Name = "pictureBoxPost";
            this.pictureBoxPost.Size = new System.Drawing.Size(324, 332);
            this.pictureBoxPost.TabIndex = 14;
            this.pictureBoxPost.TabStop = false;
            // 
            // richTextBoxCaption
            // 
            this.richTextBoxCaption.Location = new System.Drawing.Point(96, 546);
            this.richTextBoxCaption.Name = "richTextBoxCaption";
            this.richTextBoxCaption.Size = new System.Drawing.Size(322, 112);
            this.richTextBoxCaption.TabIndex = 20;
            this.richTextBoxCaption.Text = "";
            // 
            // FormOtherPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PAMERYUK.Properties.Resources.POSTINGAN_ORG_LAIN___KOSONG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1218, 729);
            this.Controls.Add(this.richTextBoxCaption);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.buttonComment);
            this.Controls.Add(this.listBoxComment);
            this.Controls.Add(this.listBoxCaption);
            this.Controls.Add(this.pictureBoxPost);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormOtherPost";
            this.Load += new System.EventHandler(this.FormOtherPost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Button buttonComment;
        private System.Windows.Forms.ListBox listBoxComment;
        private System.Windows.Forms.ListBox listBoxCaption;
        private System.Windows.Forms.PictureBox pictureBoxPost;
        private System.Windows.Forms.RichTextBox richTextBoxCaption;
    }
}