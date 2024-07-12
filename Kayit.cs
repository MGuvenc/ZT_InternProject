using System;
using System.Windows.Forms;

namespace ZT_InternProject
{
    public partial class Kayit : Form
    {
        DatabaseHelper dbHelper;
        public Kayit()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void giris_yap_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            this.Visible = false;
            giris.Visible = true;
        }

        private void kayit_ol_Click(object sender, EventArgs e)
        {
            string name = this.name.Text;
            string surname = this.surname.Text;
            string username = this.username.Text;
            string pass = this.password.Text;
            string persnoStr = this.persno.Text;
            string mail = this.mail.Text;

            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(surname) &&
                !string.IsNullOrEmpty(username) &&
                !string.IsNullOrEmpty(pass) &&
                !string.IsNullOrEmpty(persnoStr) &&
                !string.IsNullOrEmpty(mail))
            {
                if (int.TryParse(persnoStr, out int persno))
                {
                    string columns = "name, surname, username, pass, regno, access, mail";
                    string values = $"'{name}','{surname}','{username}','{pass}',{persno}, 1,'{mail}'";

                    bool iskayit = dbHelper.Insert("signup", columns, values);

                    if (iskayit)
                    {
                        MessageBox.Show("Kayıt başarılı!", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt başarısız!", "Ziraat Teknoloji", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Personel numarası geçerli bir max 11 haneli sayı olmalıdır!", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayın!", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
