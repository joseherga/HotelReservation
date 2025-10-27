using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class BookingDetailsForm : Form
    {
        private int _userId;
        static CallDatabase callDatabase = new CallDatabase();
        SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath());
        SqlCommand cmd;
        public BookingDetailsForm(int userId = 0)
        {
            InitializeComponent();
            _userId = userId;

            dgRooms.CellClick -= dgRooms_CellClick;
            dgRooms.CellClick += dgRooms_CellClick;
        }

        private void BookingDetailsForm_Load(object sender, EventArgs e)
        {
            if (_userId > 0) LoadUserDetails(_userId);
            LoadRoomData();
        }

        private void LoadUserDetails(int userId)
        {
            string sql = "SELECT FullName, Email, Phone FROM UserInfo WHERE UserID = @UserID";
            using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                try
                {
                    con.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            int idxFull = r.GetOrdinal("FullName");
                            int idxEmail = r.GetOrdinal("Email");
                            int idxPhone = r.GetOrdinal("Phone");

                            txtFullName.Text = r.IsDBNull(idxFull) ? "" : r.GetString(idxFull);
                            txtEmail.Text = r.IsDBNull(idxEmail) ? "" : r.GetString(idxEmail);
                            txtPhone.Text = r.IsDBNull(idxPhone) ? "" : r.GetString(idxPhone);
                        }
                        else
                        {
                            MessageBox.Show("Registered user not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading user details: " + ex.Message);
                }
            }
        }

        private void LoadRoomData()
        {
            using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
            {
                string query = "SELECT RoomType, Rate FROM Rooms";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
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

            string roomType = null;
            string rate = null;

            if (dgRooms.Columns.Contains("RoomType"))
                roomType = row.Cells["RoomType"]?.Value?.ToString();
            else if (row.Cells.Count > 0)
                roomType = row.Cells[0]?.Value?.ToString();

            if (dgRooms.Columns.Contains("Rate"))
                rate = row.Cells["Rate"]?.Value?.ToString();
            else if (row.Cells.Count > 1)
                rate = row.Cells[1]?.Value?.ToString();

            cbRoomType.Text = roomType ?? "";
            txtRate.Text = rate ?? "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainMenuForm mm = new MainMenuForm();
            mm.Show();
            this.Hide();
        }

        private void ClearBookingFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
        }
    }
}