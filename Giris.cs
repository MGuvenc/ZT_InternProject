using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ZT_InternProject
{
    public partial class Giris : Form
    {
        DatabaseHelper dbHelper;

        public Giris()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Text;
            bool beni_hatirla = benihatirla.Checked;

            string query = "SELECT * FROM signup WHERE username=@username AND pass=@password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            using (SqlDataReader dr = dbHelper.ExecuteReader(query, parameters))
            {
                if (dr.Read())
                {
                    string per_id = dr["id"].ToString();
                    string per_username = dr["username"].ToString();
                    string per_persno = dr["regno"].ToString();
                    string per_access = dr["access"].ToString();
                    string per_lastlog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string columns = "p_id, p_username, p_regno, p_access, lastlog";
                    string values = $"'{per_id}','{per_username}','{per_persno}','{per_access}','{per_lastlog}'";

                    bool islogin = dbHelper.Insert("p_login", columns, values);

                    if (islogin)
                    {
                        MessageBox.Show("Giriş Başarılı", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AnaSayfa anaSayfa = new AnaSayfa(per_username);
                        anaSayfa.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Eksik veya hatalı giriş işlemi!", "Ziraat Teknoloji", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kayit kayit = new Kayit
            {
                Visible = true
            };
            this.Visible = false;
        }
    }
}
