using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class BookingDetailsForm : Form
    {
        static CallDatabase callDatabase = new CallDatabase();
        SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath());
        public BookingDetailsForm()
        {
            InitializeComponent();
            dgRooms.CellClick -= dgRooms_CellClick;
            dgRooms.CellClick += dgRooms_CellClick;
        }

        private void BookingDetailsForm_Load(object sender, EventArgs e)
        {
            if (Session.CurrentUser != null)
            {
                txtFullName.Text = Session.CurrentUser.FullName;
                txtEmail.Text = Session.CurrentUser.Email;
                txtPhone.Text = Session.CurrentUser.Phone;

                if (Session.CurrentUser.Role == "Admin")
                {
                    txtFullName.ReadOnly = false;
                    txtEmail.ReadOnly = false;
                    txtPhone.ReadOnly = false;
                    btnProceed.Text = "Create Booking (Admin)";
                }
                else
                {
                    txtFullName.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                }
            }
            else
            {
                MessageBox.Show("No user is currently logged in.");
                this.Close();
                return;
            }

            LoadRoomData();
            LoadGuestOptions(4);
        }

        private void LoadRoomData()
        {
            string query = "SELECT RoomType, Rate FROM Rooms";
            using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    da.Fill(dt);

                    dgRooms.DataSource = dt;
                    dgRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgRooms.ReadOnly = true;
                    dgRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rooms: " + ex.Message);
                }
            }
        }

        private void dgRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgRooms.Rows[e.RowIndex];

            string roomType = dgRooms.Columns.Contains("RoomType") ? row.Cells["RoomType"]?.Value?.ToString() : row.Cells[0]?.Value?.ToString();
            string rate = dgRooms.Columns.Contains("Rate") ? row.Cells["Rate"]?.Value?.ToString() : row.Cells[1]?.Value?.ToString();

            cbRoomType.Text = roomType ?? "";
            txtRate.Text = rate ?? "";
        }

        private void LoadGuestOptions(int maxGuests)
        {
            cbGuests.Items.Clear();
            for (int i = 1; i <= maxGuests; i++)
            {
                cbGuests.Items.Add(i.ToString());
            }
            cbGuests.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser.Role == "Admin")
            {
                MainMenuForm adminMenu = new MainMenuForm();
                adminMenu.Show();
            }
            else
            {
                UserDashboard userDash = new UserDashboard();
                userDash.Show();
            }
            this.Hide();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            DateTime checkIn = dtCheckIn.Value;
            DateTime checkOut = dtCheckOut.Value;

            if (checkIn < DateTime.Today)
            {
                MessageBox.Show("Check-in date must be today or a future date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkOut <= checkIn)
            {
                MessageBox.Show("Check-out date must be after the check-in date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PaymentScreenForm ps = new PaymentScreenForm();

            int guests = Convert.ToInt32(cbGuests.Text);

            ps.FullName = Session.CurrentUser.FullName;
            ps.RoomType = cbRoomType.Text;
            ps.Guest = Convert.ToInt32(cbGuests.SelectedItem.ToString());
            ps.checkIn = dtCheckIn.Value;
            ps.checkOut = dtCheckOut.Value;

            decimal rate;
            decimal.TryParse(txtRate.Text, out rate);
            ps.Rate = rate;

            ps.Show();
            this.Hide();
        }
    }
}