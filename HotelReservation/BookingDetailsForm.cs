using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class BookingDetailsForm : Form
    {
        // Static reference to CallDatabase for connection string
        static CallDatabase callDatabase = new CallDatabase();

        // Track the selected room and its capacity
        private int selectedRoomID = 0;
        private int roomCapacity = 0;

        // Reference to ManageRoomForm so we can refresh after booking
        private ManageRoomForm manageRoomForm;

        public BookingDetailsForm()
        {
            InitializeComponent();

            // Attach event handlers for room selection and guest input validation
            dgRooms.CellClick += dgRooms_CellClick;
            txtGuests.KeyPress += txtGuests_KeyPress;

            // Room type and rate are auto-filled, so keep them read-only
            txtRoomType.ReadOnly = true;
            txtRate.ReadOnly = true;
        }

        private void BookingDetailsForm_Load(object sender, EventArgs e)
        {
            // Load user info and available rooms when form opens
            LoadUserInfo();
            LoadRoomData();

            // Disable the default close button (X) for controlled navigation
            this.ControlBox = false;
        }

        private void LoadUserInfo()
        {
            // If no user is logged in, stop and close the form
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("No user is currently logged in.");
                this.Close();
                return;
            }

            // Fill textboxes with current user info
            txtFullName.Text = Session.CurrentUser.FullName;
            txtEmail.Text = Session.CurrentUser.Email;
            txtPhone.Text = Session.CurrentUser.Phone;

            // Admins can edit user info and create bookings for others
            if (Session.CurrentUser.Role == "Admin")
            {
                txtFullName.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtPhone.ReadOnly = false;
                btnProceed.Text = "Create Booking (Admin)";
            }
            else
            {
                // Regular users cannot edit their info
                txtFullName.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtPhone.ReadOnly = true;
            }
        }

        private void LoadRoomData()
        {
            // Query to load only available rooms, ordered by type then number
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

                    // Bind results to DataGridView
                    dgRooms.DataSource = dt;
                    dgRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgRooms.ReadOnly = true;
                    dgRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    // Hide RoomID column (used internally, not for display)
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
            // Ignore clicks on headers or empty space
            if (e.RowIndex < 0) return;

            // Get selected row and fill details
            var row = dgRooms.Rows[e.RowIndex];
            selectedRoomID = Convert.ToInt32(row.Cells["RoomID"].Value);
            txtRoomType.Text = row.Cells["RoomType"].Value.ToString();
            txtRate.Text = row.Cells["Rate"].Value.ToString();
            roomCapacity = Convert.ToInt32(row.Cells["Capacity"].Value);

            // Default guest count to 1
            txtGuests.Text = "1";
        }

        private void txtGuests_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits in guest count textbox
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            // Check if room is free for the selected dates
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
                return count == 0; // true if no overlapping reservations
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close form without saving
            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            // Validate booking details before proceeding
            if (!ValidateBooking(out int guestCount, out DateTime checkIn, out DateTime checkOut))
                return;

            // Create booking object for payment form
            ChoosePaymentMethodForm chooseForm = new ChoosePaymentMethodForm
            {
                FullName = txtFullName.Text,
                RoomType = txtRoomType.Text,
                Guest = guestCount,
                CheckIn = checkIn,
                CheckOut = checkOut,
                Rate = decimal.Parse(txtRate.Text),
                RoomID = selectedRoomID
            };

            // Show payment form as a dialog
            var result = chooseForm.ShowDialog();

            // Only update room status if payment succeeded
            if (result == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
                {
                    try
                    {
                        con.Open();
                        string updateRoomStatus = "UPDATE Rooms SET Status = 'Occupied' WHERE RoomID = @RoomID";
                        SqlCommand statusCmd = new SqlCommand(updateRoomStatus, con);
                        statusCmd.Parameters.AddWithValue("@RoomID", selectedRoomID);
                        statusCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating room status: " + ex.Message);
                    }
                }

                // Refresh ManageRoomForm if it’s open
                manageRoomForm?.RefreshRooms();
            }

            // Close booking form after process
            this.Close();
        }

        private bool ValidateBooking(out int guestCount, out DateTime checkIn, out DateTime checkOut)
        {
            guestCount = 0;
            checkIn = dtCheckIn.Value.Date;
            checkOut = dtCheckOut.Value.Date;

            // Ensure a room is selected
            if (selectedRoomID == 0)
            {
                MessageBox.Show("Please select a room.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate guest count input
            if (!int.TryParse(txtGuests.Text, out guestCount) || guestCount <= 0)
            {
                MessageBox.Show("Please enter a valid number of guests.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if guest count exceeds room capacity
            if (guestCount > roomCapacity)
            {
                MessageBox.Show($"This room can only accommodate {roomCapacity} guests.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check-in must be today or later
            if (checkIn < DateTime.Today)
            {
                MessageBox.Show("Check-in date must be today or a future date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check-out must be after check-in
            if (checkOut <= checkIn)
            {
                MessageBox.Show("Check-out date must be after the check-in date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verify room availability for selected dates
            if (!IsRoomAvailable(selectedRoomID, checkIn, checkOut))
            {
                MessageBox.Show("This room is already booked for the selected dates.", "Room Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // Booking is valid
        }
    }
}