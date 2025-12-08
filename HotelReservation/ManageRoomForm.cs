using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class ManageRoomForm : Form
    {
        // Database connection setup using CallDatabase helper
        static CallDatabase cd = new CallDatabase();
        SqlConnection con = new SqlConnection(cd.GetDatabasePath());
        SqlCommand cmd;

        public ManageRoomForm()
        {
            InitializeComponent();

            // Attach event handlers for DataGridView
            dgvRooms.CellClick += dgvRooms_CellClick;              // Handle row clicks
            dgvRooms.DataBindingComplete += dgvRooms_DataBindingComplete; // Style rows after data loads
        }

        // Public method so other forms can refresh room list
        public void RefreshRooms()
        {
            LoadRooms();
        }

        private void ManageRoomForm_Load(object sender, EventArgs e)
        {
            // Configure numeric controls for Rate (price per room)
            numRate.Maximum = 100000;
            numRate.Minimum = 0;
            numRate.Increment = 100;

            // Configure numeric controls for Capacity (number of guests)
            numCapacity.Maximum = 20;
            numCapacity.Minimum = 1;

            // Populate dropdown for room types
            cmbRoomType.Items.AddRange(new string[] {
                "Single Room", "Double Room", "Deluxe Room", "Family Room", "Suite", "President Suite"
            });

            // Populate dropdown for room status options
            cmbStatus.Items.AddRange(new string[] {
                "Available", "Occupied", "Maintenance"
            });

            // Load all room data into the DataGridView
            LoadRooms();
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on header row or empty space
            if (e.RowIndex < 0) return;

            // Get the row that was clicked
            DataGridViewRow row = dgvRooms.Rows[e.RowIndex];

            // Fill form fields with the selected room’s details
            txtRoomNumber.Text = row.Cells["RoomNumber"].Value?.ToString();
            cmbRoomType.Text = row.Cells["RoomType"].Value?.ToString();

            // Safely convert Rate value, fallback to minimum if null/empty
            object rateValue = row.Cells["Rate"].Value;
            numRate.Value = rateValue != DBNull.Value ? Convert.ToDecimal(rateValue) : numRate.Minimum;

            // Safely convert Capacity value, fallback to minimum if null/empty
            object capacityValue = row.Cells["Capacity"].Value;
            numCapacity.Value = capacityValue != DBNull.Value ? Convert.ToInt32(capacityValue) : numCapacity.Minimum;

            // Set Status dropdown to match the selected room’s status
            cmbStatus.Text = row.Cells["Status"].Value?.ToString();
        }

        private void dgvRooms_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Apply color coding based on room status and who booked
            foreach (DataGridViewRow row in dgvRooms.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();
                string bookedBy = row.Cells["BookedBy"].Value?.ToString();

                if (status == "Available")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (status == "Occupied")
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (status == "Maintenance")
                    row.DefaultCellStyle.BackColor = Color.Khaki;

                if (bookedBy == "Admin")
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                else if (bookedBy == "Customer")
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
            }
        }

        private void LoadRooms()
        {
            // Query rooms with reservation and user info
            using (SqlConnection con = new SqlConnection(cd.GetDatabasePath()))
            {
                string query = @"SELECT
                    r.RoomID, r.RoomNumber, r.RoomType, r.Rate,
                    r.Capacity, r.Status, res.CheckIn, res.CheckOut,
                    ISNULL(u.FullName, res.FullName) AS BookerName, ISNULL(u.Email, '') AS BookerEmail,
                    ISNULL(u.UserType, 'Admin') AS BookedBy
                FROM Rooms r
                LEFT JOIN Reservations res ON r.RoomID = res.RoomID
                LEFT JOIN UserInfo u ON res.UserID = u.UserID;";

                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Bind results to DataGridView
                    dgvRooms.DataSource = dt;
                    dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    // Hide RoomID column (internal use only)
                    if (dgvRooms.Columns.Contains("RoomID"))
                        dgvRooms.Columns["RoomID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading rooms: " + ex.Message);
                }
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cd.GetDatabasePath()))
            {
                try
                {
                    // Validate required fields
                    if (string.IsNullOrWhiteSpace(txtRoomNumber.Text) ||
                        string.IsNullOrWhiteSpace(cmbRoomType.Text) ||
                        string.IsNullOrWhiteSpace(cmbStatus.Text))
                    {
                        MessageBox.Show("Please fill in all required fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    con.Open();

                    // Prevent duplicate RoomNumber
                    string checkQuery = "SELECT COUNT(*) FROM Rooms WHERE RoomNumber = @RoomNumber";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@RoomNumber", txtRoomNumber.Text.Trim());
                    int exists = (int)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("Room number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insert new room record
                    string query = @"INSERT INTO Rooms (RoomNumber, RoomType, Rate, Capacity, Status)
                                     VALUES (@RoomNumber, @RoomType, @Rate, @Capacity, @Status)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@RoomNumber", txtRoomNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@RoomType", cmbRoomType.Text);
                    cmd.Parameters.AddWithValue("@Rate", numRate.Value);
                    cmd.Parameters.AddWithValue("@Capacity", (int)numCapacity.Value);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room added successfully.");
                    LoadRooms();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding room: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0) return;

            int roomID = Convert.ToInt32(dgvRooms.SelectedRows[0].Cells["RoomID"].Value);

            using (SqlConnection con = new SqlConnection(cd.GetDatabasePath()))
            {
                try
                {
                    con.Open();
                    // Update selected room record
                    string query = @"UPDATE Rooms SET RoomNumber = @RoomNumber, RoomType = @RoomType,
                                     Rate = @Rate, Capacity = @Capacity, Status = @Status 
                                     WHERE RoomID = @RoomID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@RoomNumber", txtRoomNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@RoomType", cmbRoomType.Text);
                    cmd.Parameters.AddWithValue("@Rate", numRate.Value);
                    cmd.Parameters.AddWithValue("@Capacity", (int)numCapacity.Value);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@RoomID", roomID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room updated successfully.");
                    LoadRooms();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating room: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dgvRooms.SelectedRows[0];
            int roomID = Convert.ToInt32(selectedRow.Cells["RoomID"].Value);
            string status = selectedRow.Cells["Status"].Value?.ToString();

            // Prevent deleting occupied rooms
            if (status == "Occupied")
            {
                MessageBox.Show("This room is currently occupied and cannot be deleted.", "Delete Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(cd.GetDatabasePath()))
            {
                try
                {
                    con.Open();
                    string deleteQuery = "DELETE FROM Rooms WHERE RoomID = @RoomID";
                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@RoomID", roomID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room deleted successfully.");
                    LoadRooms();   // Refresh grid after deletion
                    ClearFields(); // Reset input fields
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting room: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset all input fields
            ClearFields();
        }

        private void ClearFields()
        {
            // Clear textboxes and reset dropdowns/numeric controls
            txtRoomNumber.Clear();

            cmbRoomType.SelectedIndex = -1;
            cmbRoomType.Text = string.Empty;
            numRate.Value = 0;
            numCapacity.Value = 1;
            cmbStatus.SelectedIndex = -1;
            cmbStatus.Text = string.Empty;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Close ManageRoomForm and return to previous screen
            this.Close();
        }
    }
}