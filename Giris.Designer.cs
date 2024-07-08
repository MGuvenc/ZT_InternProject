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
            this.sifre = new System.Windows.Forms.TextBox();
            this.kullanici_adi = new System.Windows.Forms.TextBox();
            this.kullanici_adi_l = new System.Windows.Forms.Label();
            this.sifre_l = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sifre
            // 
            resources.ApplyResources(this.sifre, "sifre");
            this.sifre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.sifre.Name = "sifre";
            this.sifre.UseSystemPasswordChar = true;
            // 
            // kullanici_adi
            // 
            this.kullanici_adi.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.kullanici_adi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.kullanici_adi.BackColor = System.Drawing.SystemColors.Window;
            this.kullanici_adi.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            resources.ApplyResources(this.kullanici_adi, "kullanici_adi");
            this.kullanici_adi.Name = "kullanici_adi";
            this.kullanici_adi.Tag = "";
            this.kullanici_adi.TextChanged += new System.EventHandler(this.kullanici_adi_TextChanged);
            // 
            // kullanici_adi_l
            // 
            resources.ApplyResources(this.kullanici_adi_l, "kullanici_adi_l");
            this.kullanici_adi_l.Name = "kullanici_adi_l";
            this.kullanici_adi_l.Click += new System.EventHandler(this.label1_Click);
            // 
            // sifre_l
            // 
            resources.ApplyResources(this.sifre_l, "sifre_l");
            this.sifre_l.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.sifre_l.Name = "sifre_l";
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
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
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.sifre_l);
            this.Controls.Add(this.kullanici_adi_l);
            this.Controls.Add(this.kullanici_adi);
            this.Controls.Add(this.sifre);
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
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.TextBox kullanici_adi;
        private System.Windows.Forms.Label kullanici_adi_l;
        private System.Windows.Forms.Label sifre_l;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
    }
}

