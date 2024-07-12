using System.Data.SqlClient;
using System.Windows.Forms;
//DESKTOP-0570HGU\MSSQLSERVER01


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

        private void button1_Click(object sender, System.EventArgs e)
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
                    MessageBox.Show("Giriş Başarılı", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AnaSayfa AnaSayfa = new AnaSayfa();

                    AnaSayfa.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Eksik veya hatalı giriş işlemi!", "Ziraat Teknoloji", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Kayit kayit = new Kayit();

            kayit.Visible = true;
            this.Visible = false;
        }
    }
}
