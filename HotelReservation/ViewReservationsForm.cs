using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class ViewReservationsForm : Form
    {
        private static readonly CallDatabase callDatabase = new CallDatabase();

        public ViewReservationsForm()
        {
            InitializeComponent();
        }

        private void txtSearch_MouseClick_1(object sender, MouseEventArgs e)
        {
           
        }

        private void ViewReservationsForm_Load(object sender, EventArgs e)
        {
            bool isAdmin = Session.CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
            btnDelete.Visible = isAdmin;
            btnDelete.Enabled = isAdmin;

            LoadReservations();
            this.ControlBox = false;
        }

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
                        query = @"SELECT res.ReservationID, res.FullName, res.Guest, res.RoomType, res.CheckIn, res.CheckOut, 
                    res.Rate, res.TotalAmount, res.BookingDate,
                    ISNULL(u.UserType, 'Admin') AS BookedBy
                    FROM Reservations res
                    LEFT JOIN UserInfo u ON res.UserID = u.UserID";
                        adapter = new SqlDataAdapter(query, con);
                    }
                    else
                    {
                        query = @"SELECT res.ReservationID, res.FullName, res.Guest, res.RoomType, res.CheckIn, res.CheckOut, 
                    res.Rate, res.TotalAmount, res.BookingDate,
                    ISNULL(u.UserType, 'Admin') AS BookedBy
                    FROM Reservations res
                    LEFT JOIN UserInfo u ON res.UserID = u.UserID
                    WHERE res.FullName = @FullName";
                        adapter = new SqlDataAdapter(query, con);
                        adapter.SelectCommand.Parameters.AddWithValue("@FullName", Session.CurrentUser.FullName);
                    }


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
            txtSearch.Clear();
            LoadReservations();
            dgvRegistrations.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRegistrations.SelectedRows.Count == 0) return;

            int reservationID = Convert.ToInt32(dgvRegistrations.SelectedRows[0].Cells["ReservationID"].Value);
            if (MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM Reservations WHERE ReservationID = @ReservationID";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ReservationID", reservationID);
                        cmd.ExecuteNonQuery();

                        string updateStatus = @"UPDATE Rooms 
                        SET Status = 'Available' 
                        WHERE RoomID = (
                            SELECT RoomID FROM Reservations WHERE ReservationID = @ReservationID
                        )";
                        SqlCommand updateCmd = new SqlCommand(updateStatus, con);
                        updateCmd.Parameters.AddWithValue("@ReservationID", reservationID);
                        updateCmd.ExecuteNonQuery();

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
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
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
            txtSearch_TextChanged(sender, e);
        }
    }
}
