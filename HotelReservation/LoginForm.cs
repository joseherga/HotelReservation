using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class LoginForm : Form
    {
        static CallDatabase cd = new CallDatabase();
        SqlConnection con = new SqlConnection(cd.GetDatabasePath());
        SqlCommand cmd;
        public LoginForm()
        {
            InitializeComponent();
        }

        public static class CurrentUser
        {
            public static int UserID;
            public static string FullName;
            public static string Email;
            public static string Phone;
            public static string Role;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupForm CustomerPage = new SignupForm();
            CustomerPage.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = 0;

            try
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT UserID FROM UserInfo WHERE Username=@Username AND Password=@Password", con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        userId = Convert.ToInt32(result);
                }

                if (userId > 0)
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM UserInfo WHERE UserID=@UserID", con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            Session.CurrentUser = new User
                            {
                                UserID = userId,
                                FullName = reader["FullName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Role = reader["UserType"].ToString()
                            };
                        }

                        reader.Close();
                        con.Close();

                        MessageBox.Show($"Welcome back, {Session.CurrentUser.FullName}!", "Login Successful",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (Session.CurrentUser.Role == "Admin")
                        {
                            MainMenuForm admin = new MainMenuForm();
                            admin.Show();
                        }
                        else
                        {
                            UserDashboard user = new UserDashboard();
                            user.Show();
                        }

                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void chckBackShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chckBackShowPass.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}
