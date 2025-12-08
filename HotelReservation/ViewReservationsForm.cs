using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class ViewReservationsForm : Form
    {
        // Database helper for connection string
        private static readonly CallDatabase callDatabase = new CallDatabase();

        public ViewReservationsForm()
        {
            InitializeComponent();
        }

        private void ViewReservationsForm_Load(object sender, EventArgs e)
        {
            // Show delete button only for Admin users
            bool isAdmin = Session.CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
            btnDelete.Visible = isAdmin;
            btnDelete.Enabled = isAdmin;

            // Load reservations into grid
            LoadReservations();

            // Disable default close button (forces use of Back button)
            this.ControlBox = false;
        }

        // Load reservations depending on user role
        public void LoadReservations()
        {
            using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
            {
                try
                {
                    con.Open();
                    string query;
                    SqlDataAdapter adapter;

                    if (Session.CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        // Admin sees all reservations
                        query = @"SELECT res.ReservationID, res.FullName, res.Guest, res.RoomType, res.CheckIn, res.CheckOut, 
                                         res.Rate, res.TotalAmount, res.BookingDate,
                                         ISNULL(u.UserType, 'Admin') AS BookedBy
                                  FROM Reservations res
                                  LEFT JOIN UserInfo u ON res.UserID = u.UserID";
                        adapter = new SqlDataAdapter(query, con);
                    }
                    else
                    {
                        // Customers only see their own reservations
                        query = @"SELECT res.ReservationID, res.FullName, res.Guest, res.RoomType, res.CheckIn, res.CheckOut, 
                                         res.Rate, res.TotalAmount, res.BookingDate,
                                         ISNULL(u.UserType, 'Admin') AS BookedBy
                                  FROM Reservations res
                                  LEFT JOIN UserInfo u ON res.UserID = u.UserID
                                  WHERE res.FullName = @FullName";
                        adapter = new SqlDataAdapter(query, con);
                        adapter.SelectCommand.Parameters.AddWithValue("@FullName", Session.CurrentUser.FullName);
                    }

                    // Fill DataTable and bind to DataGridView
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvRegistrations.DataSource = dt;
                    dgvRegistrations.ReadOnly = true;
                    dgvRegistrations.AllowUserToAddRows = false;
                    dgvRegistrations.AllowUserToDeleteRows = false;
                    dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading reservations: {ex.Message}",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Clear search box and reload reservations
            txtSearch.Clear();
            LoadReservations();
            dgvRegistrations.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Only Admin can delete reservations
            if (dgvRegistrations.SelectedRows.Count == 0) return;

            int reservationID = Convert.ToInt32(dgvRegistrations.SelectedRows[0].Cells["ReservationID"].Value);

            // Confirm deletion
            if (MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
                {
                    try
                    {
                        con.Open();

                        // Delete reservation record
                        string query = "DELETE FROM Reservations WHERE ReservationID = @ReservationID";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                        cmd.ExecuteNonQuery();

                        // Update room status back to Available
                        string updateStatus = @"UPDATE Rooms 
                                                SET Status = 'Available' 
                                                WHERE RoomID = (
                                                    SELECT RoomID FROM Reservations WHERE ReservationID = @ReservationID
                                                )";
                        SqlCommand updateCmd = new SqlCommand(updateStatus, con);
                        updateCmd.Parameters.AddWithValue("@ReservationID", reservationID);
                        updateCmd.ExecuteNonQuery();

                        // Refresh grid
                        LoadReservations();
                        MessageBox.Show("Reservation deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting reservation: " + ex.Message);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Close form and return to dashboard
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Search reservations by keyword (FullName or RoomType)
            string keyword = txtSearch.Text.Trim();

            try
            {
                using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
                {
                    con.Open();
                    string query;
                    SqlDataAdapter adapter;

                    if (string.Equals(Session.CurrentUser.Role, "admin", StringComparison.OrdinalIgnoreCase))
                    {
                        // Admin can search across all reservations
                        query = @"SELECT res.ReservationID, res.FullName, res.Guest, res.RoomType, res.CheckIn, res.CheckOut, 
                                         res.Rate, res.TotalAmount, res.BookingDate,
                                         ISNULL(u.UserType, 'Admin') AS BookedBy
                                  FROM Reservations res
                                  LEFT JOIN UserInfo u ON res.UserID = u.UserID
                                  WHERE res.FullName LIKE @Keyword OR res.RoomType LIKE @Keyword";
                        adapter = new SqlDataAdapter(query, con);
                    }
                    else
                    {
                        // Customers can only search their own reservations
                        query = @"SELECT res.ReservationID, res.FullName, res.Guest, res.RoomType, res.CheckIn, res.CheckOut, 
                                         res.Rate, res.TotalAmount, res.BookingDate,
                                         ISNULL(u.UserType, 'Admin') AS BookedBy
                                  FROM Reservations res
                                  LEFT JOIN UserInfo u ON res.UserID = u.UserID
                                  WHERE res.FullName = @FullName
                                    AND (res.FullName LIKE @Keyword OR res.RoomType LIKE @Keyword)";
                        adapter = new SqlDataAdapter(query, con);
                        adapter.SelectCommand.Parameters.AddWithValue("@FullName", Session.CurrentUser.FullName);
                    }

                    adapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    // Fill DataTable and bind to DataGridView
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvRegistrations.DataSource = dt;
                    dgvRegistrations.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Trigger search manually (same as typing in search box)
            txtSearch_TextChanged(sender, e);
        }
    }
}