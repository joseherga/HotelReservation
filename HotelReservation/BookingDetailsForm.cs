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
        }

        private void BookingDetailsForm_Load(object sender, EventArgs e)
        {
            if (_userId > 0)
                LoadUserDetails(_userId);
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