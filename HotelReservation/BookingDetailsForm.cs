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
            this.ControlBox = false;
        }

        private bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            using (SqlConnection conn = new SqlConnection(callDatabase.GetDatabasePath()))
            {
                conn.Open();
                string query = @"
            SELECT COUNT(*)
            FROM Reservations
            WHERE RoomID = @RoomID
            AND (
                    @CheckIn < CheckOut
                AND @CheckOut > CheckIn
                );";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                cmd.Parameters.AddWithValue("@CheckOut", checkOut);

                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
        }

        private void LoadRoomData()
        {
            string query = "SELECT RoomID, RoomType, Rate FROM Rooms";
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

            int roomId = Convert.ToInt32(row.Cells["RoomID"].Value);
            cbRoomType.Tag = roomId;   

            cbRoomType.Text = row.Cells["RoomType"].Value.ToString();
            txtRate.Text = row.Cells["Rate"].Value.ToString();
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
            }
            else
            {
                UserDashboard userDash = new UserDashboard();
            }
            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            DateTime checkIn = dtCheckIn.Value;
            DateTime checkOut = dtCheckOut.Value;

            if (checkIn < DateTime.Today)
            {
                MessageBox.Show("Check-in date must be today or a future date.", "Invalid Date",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkOut <= checkIn)
            {
                MessageBox.Show("Check-out date must be after the check-in date.", "Invalid Date",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbRoomType.Tag == null)
            {
                MessageBox.Show("Please select a room.");
                return;
            }

            int roomId = Convert.ToInt32(cbRoomType.Tag);

            if (!IsRoomAvailable(roomId, checkIn, checkOut))
            {
                MessageBox.Show("This room is already booked for the selected dates.",
                                "Room Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PaymentScreenForm ps = new PaymentScreenForm();
            ps.FullName = Session.CurrentUser.FullName;
            ps.RoomType = cbRoomType.Text;
            ps.Guest = Convert.ToInt32(cbGuests.SelectedItem.ToString());
            ps.checkIn = checkIn;
            ps.checkOut = checkOut;

            decimal rate;
            decimal.TryParse(txtRate.Text, out rate);
            ps.Rate = rate;

            ps.RoomID = roomId;

            ps.Show();
            this.Close();
        }
    }
}