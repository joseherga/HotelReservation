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

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a search keyword.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
                {
                    con.Open();
                    string query;
                    SqlDataAdapter adapter;

                    if (string.Equals(Session.CurrentUser.Role, "admin", StringComparison.OrdinalIgnoreCase))
                    {
                        query = @"SELECT ReservationID, FullName, Guest, RoomType, CheckIn, CheckOut, Rate, 
                                 TotalAmount, BookingDate 
                          FROM Reservations 
                          WHERE FullName LIKE @Keyword OR RoomType LIKE @Keyword";
                        adapter = new SqlDataAdapter(query, con);
                    }
                    else
                    {
                        query = @"SELECT ReservationID, FullName, Guest, RoomType, CheckIn, CheckOut, Rate, 
                                 TotalAmount, BookingDate 
                          FROM Reservations 
                          WHERE FullName = @FullName AND 
                                (FullName LIKE @Keyword OR RoomType LIKE @Keyword)";
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
                        query = @"SELECT ReservationID, FullName, Guest, RoomType, CheckIn, CheckOut, Rate, 
                                         TotalAmount, BookingDate 
                                  FROM Reservations";
                        adapter = new SqlDataAdapter(query, con);
                    }
                    else
                    {
                        query = @"SELECT ReservationID, FullName, Guest, RoomType, CheckIn, CheckOut, Rate, 
                                         TotalAmount, BookingDate 
                                  FROM Reservations 
                                  WHERE FullName = @FullName";
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
            if (Session.CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                new AdminDashboardForm().Show();
            else
                new UserDashboard().Show();

            this.Close();
        }
    }
}
