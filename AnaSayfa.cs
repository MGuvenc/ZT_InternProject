using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace ZT_InternProject
{
    public partial class AnaSayfa : Form
    {
        private readonly DatabaseHelper dbHelper;
        private string currentUsername;
        private int currentFloor;
        private int currentStudyRoom;
        public string CurrentUsername { get => currentUsername; set => currentUsername = value; }

        public AnaSayfa(string username)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            CurrentUsername = username;
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            LoadFloors();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0; 
                comboBox2.SelectedIndex = 0;
            }
            if (UserHasReservation())
            {
                rezervIptal.Visible = true;
            }
        }

        private void LoadFloors()
        {
            string query = "SELECT DISTINCT kat_no FROM masa ORDER BY kat_no";
            bool katnum = false;
            SqlDataReader reader = dbHelper.ExecuteReader(query, null);
            
            while (reader.Read())
            {
                katnum = true;
                comboBox1.Items.Add(reader["kat_no"].ToString());
            }
            reader.Close();
            if (!katnum)
            {
                Label noDesksLabel = new Label
                {
                    Text = "Listelenecek masa bulunamadı..",
                    ForeColor = Color.Red,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };
                scrollablePanel.Controls.Add(noDesksLabel);
            }
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
            string query = @"
                SELECT masa.masa_no, 
                       CASE 
                           WHEN mr.masa_no IS NULL THEN 'available' 
                           ELSE 'reserved' 
                       END AS status
                FROM masa
                LEFT JOIN masa_rezervasyon mr 
                ON masa.masa_no = mr.masa_no 
                AND mr.baslangic_tarihi <= @currentDate 
                AND mr.bitis_tarihi >= @currentDate
                WHERE masa.kat_no = @floor 
                AND masa.calisma_odasi_no = @studyRoom";

            SqlParameter[] parameters = {
                new SqlParameter("@floor", floor),
                new SqlParameter("@studyRoom", studyRoom),
                new SqlParameter("@currentDate", DateTime.Now)
            };

            SqlDataReader reader = dbHelper.ExecuteReader(query, parameters);
            int index = 0;

            while (reader.Read())
            {
                int deskNo = Convert.ToInt32(reader["masa_no"]);
                string status = reader["status"].ToString();

                Button deskButton = new Button
                {
                    Text = deskNo.ToString(),
                    Width = 60,
                    Height = 60,
                    Location = new Point(10 + (index % 10) * 70, 10 + (index / 10) * 70),
                    BackColor = status == "available" ? Color.Green : Color.Red
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

        private bool UserHasReservation()
        {
            string userCheckQuery = "SELECT * FROM masa_rezervasyon WHERE p_username = @username AND @currentDate BETWEEN baslangic_tarihi AND bitis_tarihi";
            SqlParameter[] userCheckParameters = {
        new SqlParameter("@username", CurrentUsername),
        new SqlParameter("@currentDate", DateTime.Now)
    };

            SqlDataReader userCheckReader = dbHelper.ExecuteReader(userCheckQuery, userCheckParameters);
            bool hasReservation = userCheckReader.HasRows;
            userCheckReader.Close();
            return hasReservation;
        }
        private void ReserveDesk(int deskNo)
        {
            DateTime startDate = startDatePicker.Value.Date;
            DateTime endDate = endDatePicker.Value.Date;

            string userCheckQuery = "SELECT * FROM masa_rezervasyon WHERE p_username = @username AND @currentDate BETWEEN baslangic_tarihi AND bitis_tarihi";
            SqlParameter[] userCheckParameters = {
                new SqlParameter("@username", CurrentUsername),
                new SqlParameter("@currentDate", DateTime.Now)
            };

            SqlDataReader userCheckReader = dbHelper.ExecuteReader(userCheckQuery, userCheckParameters);
            if (userCheckReader.HasRows)
            {
                MessageBox.Show("Mevcut rezervasyonunuz bulunuyor!", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userCheckReader.Close();
                return;
            }
            userCheckReader.Close();

            string deskCheckQuery = "SELECT * FROM masa_rezervasyon WHERE masa_no = @deskNo AND @currentDate BETWEEN baslangic_tarihi AND bitis_tarihi";
            SqlParameter[] deskCheckParameters = {
                new SqlParameter("@deskNo", deskNo),
                new SqlParameter("@currentDate", DateTime.Now)
            };

            SqlDataReader deskCheckReader = dbHelper.ExecuteReader(deskCheckQuery, deskCheckParameters);
            if (deskCheckReader.HasRows)
            {
                MessageBox.Show("Masa rezerve edilmiş..", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                deskCheckReader.Close();
                return;
            }
            deskCheckReader.Close();
            if(endDate < startDate)
            {
                MessageBox.Show("Bitiş tarihi, başlangıç tarihinden önce olamaz!", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string insertQuery = "INSERT INTO masa_rezervasyon (p_username, masa_no, baslangic_tarihi, bitis_tarihi) VALUES (@username, @deskNo, @startDate, @endDate)";
                SqlParameter[] insertParameters = {
                    new SqlParameter("@username", CurrentUsername),
                    new SqlParameter("@deskNo", deskNo),
                    new SqlParameter("@startDate", startDate),
                    new SqlParameter("@endDate", endDate)
                };

                try
                {
                    bool success = dbHelper.ExecuteNonQuery(insertQuery, insertParameters);
                    if (success)
                    {
                        MessageBox.Show("Rezervasyon işlemi başarılı!", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rezervIptal.Visible = true;
                        LoadDesks(currentFloor, currentStudyRoom);
                    }
                    else
                    {
                        MessageBox.Show("Rezervasyon başarısız.", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Rezervasyon sırasında bir hata oluştu: {ex.Message}", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Giris giris = new Giris();
            giris.Visible = true;
        }

        private void rezervIptal_Click(object sender, EventArgs e)
        {
            string tableName = "masa_rezervasyon"; // Correct table name
            string setValues = "bitis_tarihi = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            string condition = "p_username = '" + currentUsername + "' AND GETDATE() BETWEEN baslangic_tarihi AND bitis_tarihi";

            DatabaseHelper dbHelper = new DatabaseHelper();

            if (dbHelper.Update(tableName, setValues, condition))
            {
                MessageBox.Show("Rezervasyon iptal edildi!", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rezervIptal.Visible = false;
                LoadDesks(currentFloor, currentStudyRoom);
            }
            else
            {
                MessageBox.Show("Rezervasyon iptali başarısız.", "Ziraat Teknoloji", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}