using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class BookingDetailsForm : Form
    {
        static CallDatabase callDatabase = new CallDatabase();
        private int selectedRoomID = 0;
        private int roomCapacity = 0;

        public BookingDetailsForm()
        {
            InitializeComponent();

            dgRooms.CellClick += dgRooms_CellClick;
            txtGuests.KeyPress += txtGuests_KeyPress;

            txtRoomType.ReadOnly = true;
            txtRate.ReadOnly = true;
        }

        private void BookingDetailsForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            LoadRoomData();
            this.ControlBox = false;
        }

        private void LoadUserInfo()
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("No user is currently logged in.");
                this.Close();
                return;
            }

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

        private void LoadRoomData()
        {
            string query = @"
                SELECT RoomID, RoomNumber, RoomType, Rate, Capacity
                FROM Rooms
                WHERE Status='Available'
                ORDER BY 
                    CASE RoomType
                        WHEN 'Single' THEN 1
                        WHEN 'Double' THEN 2
                        WHEN 'Deluxe' THEN 3
                        WHEN 'Suite' THEN 4
                        ELSE 5
                    END, RoomNumber";

            using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);

                    dgRooms.DataSource = dt;
                    dgRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgRooms.ReadOnly = true;
                    dgRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    if (dgRooms.Columns["RoomID"] != null)
                        dgRooms.Columns["RoomID"].Visible = false;
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
            selectedRoomID = Convert.ToInt32(row.Cells["RoomID"].Value);
            txtRoomType.Text = row.Cells["RoomType"].Value.ToString();
            txtRate.Text = row.Cells["Rate"].Value.ToString();
            roomCapacity = Convert.ToInt32(row.Cells["Capacity"].Value);

            txtGuests.Text = "1";
        }

        private void txtGuests_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
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
                    AND (@CheckIn < CheckOut AND @CheckOut > CheckIn);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                cmd.Parameters.AddWithValue("@CheckOut", checkOut);

                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                new AdminDashboardForm().Show();
            else
                new UserDashboard().Show();

            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (!ValidateBooking(out int guestCount, out DateTime checkIn, out DateTime checkOut))
                return;

            // Create the payment form and pass data
            PaymentScreenForm ps = new PaymentScreenForm
            {
                FullName = txtFullName.Text,
                RoomType = txtRoomType.Text,
                Guest = guestCount,
                checkIn = checkIn,
                checkOut = checkOut,
                Rate = decimal.Parse(txtRate.Text),
                RoomID = selectedRoomID
            };

            // Show the payment form as a dialog (blocks this form until payment is completed)
            ps.ShowDialog();

            // Optional: after payment is done, close the booking form
            this.Close();
        }


        private bool ValidateBooking(out int guestCount, out DateTime checkIn, out DateTime checkOut)
        {
            guestCount = 0;
            checkIn = dtCheckIn.Value.Date;
            checkOut = dtCheckOut.Value.Date;

            if (selectedRoomID == 0)
            {
                MessageBox.Show("Please select a room.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtGuests.Text, out guestCount) || guestCount <= 0)
            {
                MessageBox.Show("Please enter a valid number of guests.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (guestCount > roomCapacity)
            {
                MessageBox.Show($"This room can only accommodate {roomCapacity} guests.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (checkIn < DateTime.Today)
            {
                MessageBox.Show("Check-in date must be today or a future date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (checkOut <= checkIn)
            {
                MessageBox.Show("Check-out date must be after the check-in date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsRoomAvailable(selectedRoomID, checkIn, checkOut))
            {
                MessageBox.Show("This room is already booked for the selected dates.", "Room Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
