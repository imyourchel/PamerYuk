namespace PAMERYUK
{
    partial class FormUpload
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
            this.richTextBoxCaption = new System.Windows.Forms.RichTextBox();
            this.pictureBoxKonten = new System.Windows.Forms.PictureBox();
            this.buttonNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKonten)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxCaption
            // 
            this.richTextBoxCaption.Location = new System.Drawing.Point(329, 185);
            this.richTextBoxCaption.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxCaption.Name = "richTextBoxCaption";
            this.richTextBoxCaption.Size = new System.Drawing.Size(417, 155);
            this.richTextBoxCaption.TabIndex = 9;
            this.richTextBoxCaption.Text = "";
            // 
            // pictureBoxKonten
            // 
            this.pictureBoxKonten.Location = new System.Drawing.Point(64, 156);
            this.pictureBoxKonten.Name = "pictureBoxKonten";
            this.pictureBoxKonten.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxKonten.TabIndex = 8;
            this.pictureBoxKonten.TabStop = false;
            this.pictureBoxKonten.Click += new System.EventHandler(this.pictureBoxKonten_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(206)))));
            this.buttonNext.Location = new System.Drawing.Point(592, 376);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(154, 30);
            this.buttonNext.TabIndex = 7;
            this.buttonNext.Text = "NEXT";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // FormUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PAMERYUK.Properties.Resources.Upload___KOSONG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(812, 474);
            this.Controls.Add(this.richTextBoxCaption);
            this.Controls.Add(this.pictureBoxKonten);
            this.Controls.Add(this.buttonNext);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormUpload";
            this.Text = "Upload";
            this.Load += new System.EventHandler(this.FormUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKonten)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxCaption;
        private System.Windows.Forms.PictureBox pictureBoxKonten;
        private System.Windows.Forms.Button buttonNext;
    }
}