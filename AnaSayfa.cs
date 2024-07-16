using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ZT_InternProject
{
    public partial class AnaSayfa : Form
    {
        private readonly DatabaseHelper dbHelper;
        private readonly string currentUsername;
        private int currentFloor;
        private int currentStudyRoom;

        public AnaSayfa(string username)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            currentUsername = username;
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            LoadFloors();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
        }

        private void LoadFloors()
        {
            string query = "SELECT DISTINCT kat_no FROM masa";
            SqlDataReader reader = dbHelper.ExecuteReader(query, null);
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["kat_no"].ToString());
            }
            reader.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFloor = Convert.ToInt32(comboBox1.SelectedItem);
            LoadStudyRooms(currentFloor);
        }

        private void LoadStudyRooms(int floor)
        {
            comboBox2.Items.Clear();
            string query = "SELECT DISTINCT calisma_odasi_no FROM masa WHERE kat_no = @floor";
            SqlParameter[] parameters = { new SqlParameter("@floor", floor) };
            SqlDataReader reader = dbHelper.ExecuteReader(query, parameters);
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["calisma_odasi_no"].ToString());
            }
            reader.Close();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentStudyRoom = Convert.ToInt32(comboBox2.SelectedItem);
            LoadDesks(currentFloor, currentStudyRoom);
        }

        private void LoadDesks(int floor, int studyRoom)
        {
            scrollablePanel.Controls.Clear();
            string query = "SELECT * FROM masa WHERE kat_no = @floor AND calisma_odasi_no = @studyRoom";
            SqlParameter[] parameters = {
                new SqlParameter("@floor", floor),
                new SqlParameter("@studyRoom", studyRoom)
            };

            SqlDataReader reader = dbHelper.ExecuteReader(query, parameters);
            int index = 0;
            while (reader.Read())
            {
                int deskNo = Convert.ToInt32(reader["masa_no"]);
                Button deskButton = new Button
                {
                    Text = deskNo.ToString(),
                    Width = 60,
                    Height = 60,
                    Location = new Point(10 + (index % 5) * 70, 10 + (index / 5) * 70)
                };
                deskButton.Click += DeskButton_Click;
                scrollablePanel.Controls.Add(deskButton);
                index++;
            }
            reader.Close();
        }

        private void DeskButton_Click(object sender, EventArgs e)
        {
            Button deskButton = (Button)sender;
            int deskNo = Convert.ToInt32(deskButton.Text);
            ReserveDesk(deskNo);
        }

        private void ReserveDesk(int deskNo)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(5);

            string checkQuery = "SELECT * FROM masa_rezervasyon WHERE masa_no = @deskNo AND @currentDate BETWEEN baslangic_tarihi AND bitis_tarihi";
            SqlParameter[] checkParameters = {
                new SqlParameter("@deskNo", deskNo),
                new SqlParameter("@currentDate", DateTime.Now)
            };

            SqlDataReader reader = dbHelper.ExecuteReader(checkQuery, checkParameters);
            if (reader.HasRows)
            {
                MessageBox.Show("This desk is already reserved.");
                reader.Close();
                return;
            }
            reader.Close();

            string insertQuery = "INSERT INTO masa_rezervasyon (p_username, masa_no, baslangic_tarihi, bitis_tarihi) VALUES (@username, @deskNo, @startDate, @endDate)";
            SqlParameter[] insertParameters = {
                new SqlParameter("@username", currentUsername),
                new SqlParameter("@deskNo", deskNo),
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate)
            };

            bool success = dbHelper.ExecuteNonQuery(insertQuery, insertParameters);
            if (success)
            {
                MessageBox.Show("Desk reserved successfully.");
                LoadDesks(currentFloor, currentStudyRoom);
            }
            else
            {
                MessageBox.Show("Failed to reserve the desk.");
            }
        }
    }
}
