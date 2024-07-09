namespace ZT_InternProject
{
    partial class Kayit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kayit));
            this.kayit_ol = new System.Windows.Forms.Button();
            this.giris_yap = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.surname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.persno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // kayit_ol
            // 
            this.kayit_ol.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.kayit_ol.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.kayit_ol.Location = new System.Drawing.Point(106, 285);
            this.kayit_ol.Name = "kayit_ol";
            this.kayit_ol.Size = new System.Drawing.Size(187, 36);
            this.kayit_ol.TabIndex = 0;
            this.kayit_ol.Text = "KAYIT OL";
            this.kayit_ol.UseVisualStyleBackColor = false;
            this.kayit_ol.Click += new System.EventHandler(this.kayit_ol_Click);
            // 
            // giris_yap
            // 
            this.giris_yap.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.giris_yap.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.giris_yap.Location = new System.Drawing.Point(106, 327);
            this.giris_yap.Name = "giris_yap";
            this.giris_yap.Size = new System.Drawing.Size(187, 36);
            this.giris_yap.TabIndex = 1;
            this.giris_yap.Text = "GİRİŞ YAP";
            this.giris_yap.UseVisualStyleBackColor = false;
            this.giris_yap.Click += new System.EventHandler(this.giris_yap_Click);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.name.Location = new System.Drawing.Point(184, 94);
            this.name.MaxLength = 50;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(109, 22);
            this.name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(103, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.Location = new System.Drawing.Point(103, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Soyad:";
            // 
            // surname
            // 
            this.surname.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.surname.Location = new System.Drawing.Point(184, 122);
            this.surname.MaxLength = 50;
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(109, 22);
            this.surname.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label3.Location = new System.Drawing.Point(103, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kullaıcı Adı:";
            // 
            // username
            // 
            this.username.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.username.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.username.Location = new System.Drawing.Point(184, 150);
            this.username.MaxLength = 50;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(109, 22);
            this.username.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label4.Location = new System.Drawing.Point(103, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Şifre:";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.password.Location = new System.Drawing.Point(184, 178);
            this.password.MaxLength = 50;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(109, 22);
            this.password.TabIndex = 8;
            this.password.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label5.Location = new System.Drawing.Point(103, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Personel No:";
            // 
            // persno
            // 
            this.persno.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.persno.Location = new System.Drawing.Point(184, 206);
            this.persno.MaxLength = 50;
            this.persno.Name = "persno";
            this.persno.Size = new System.Drawing.Size(109, 22);
            this.persno.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label6.Location = new System.Drawing.Point(103, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mail:";
            // 
            // mail
            // 
            this.mail.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.mail.Location = new System.Drawing.Point(184, 234);
            this.mail.MaxLength = 75;
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(109, 22);
            this.mail.TabIndex = 12;
            // 
            // Kayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(413, 443);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.persno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.giris_yap);
            this.Controls.Add(this.kayit_ol);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Kayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ziraat Teknoloji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kayit_ol;
        private System.Windows.Forms.Button giris_yap;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox persno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mail;
    }
}