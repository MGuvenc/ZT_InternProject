namespace ZT_InternProject
{
    partial class Giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.button1 = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.kullanici_adi_l = new System.Windows.Forms.Label();
            this.sifre_l = new System.Windows.Forms.Label();
            this.benihatirla = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.button1, "button1");
            this.button1.CausesValidation = false;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // password
            // 
            resources.ApplyResources(this.password, "password");
            this.password.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.password.CausesValidation = false;
            this.password.Name = "password";
            this.password.UseSystemPasswordChar = true;
            // 
            // username
            // 
            this.username.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.username.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.username.BackColor = System.Drawing.SystemColors.Window;
            this.username.CausesValidation = false;
            this.username.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            resources.ApplyResources(this.username, "username");
            this.username.Name = "username";
            this.username.Tag = "";
            // 
            // kullanici_adi_l
            // 
            resources.ApplyResources(this.kullanici_adi_l, "kullanici_adi_l");
            this.kullanici_adi_l.CausesValidation = false;
            this.kullanici_adi_l.Name = "kullanici_adi_l";
            // 
            // sifre_l
            // 
            resources.ApplyResources(this.sifre_l, "sifre_l");
            this.sifre_l.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.sifre_l.CausesValidation = false;
            this.sifre_l.Name = "sifre_l";
            // 
            // benihatirla
            // 
            resources.ApplyResources(this.benihatirla, "benihatirla");
            this.benihatirla.CausesValidation = false;
            this.benihatirla.Name = "benihatirla";
            this.benihatirla.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button2.CausesValidation = false;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Giris
            // 
            resources.ApplyResources(this, "$this");
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CausesValidation = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.benihatirla);
            this.Controls.Add(this.sifre_l);
            this.Controls.Add(this.kullanici_adi_l);
            this.Controls.Add(this.username);
            this.Controls.Add(this.password);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Giris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label kullanici_adi_l;
        private System.Windows.Forms.Label sifre_l;
        private System.Windows.Forms.CheckBox benihatirla;
        private System.Windows.Forms.Button button2;
    }
}

