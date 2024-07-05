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
            label1.Text = ""+ oto;
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
