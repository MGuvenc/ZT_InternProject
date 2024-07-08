using System.CodeDom.Compiler;
using System.Windows.Forms;

namespace ZT_InternProject
{
    public partial class Giris : Form
    {
        public int oto = 0;
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            oto++;
            kullanici_adi_l.Text = ""+ oto;
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void kullanici_adi_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Kayit kayit = new Kayit();

            kayit.Visible = true;
            this.Visible = false;
        }
    }
}
