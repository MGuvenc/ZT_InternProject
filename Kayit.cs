using System;
using System.Data.SqlClient;
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
            string persno = this.persno.Text;
            string mail = this.mail.Text;

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
    }
}
