using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class LoginForm : Form
    {
        // Database connection setup using CallDatabase helper
        static CallDatabase cd = new CallDatabase();
        SqlConnection con = new SqlConnection(cd.GetDatabasePath());

        public LoginForm()
        {
            InitializeComponent(); // Initialize UI components
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open signup form if user clicks "Sign up" link
            SignupForm signup = new SignupForm();
            signup.Show();
            this.Hide(); // Hide login form while signup is active
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get username and password from textboxes
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;

            // Clean password from invisible characters (extra safety)
            password = CleanPassword(password);

            // Validate input: both fields must be filled
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash password using SHA256 for secure comparison
            string hashedPassword = HashPassword(password);

            try
            {
                con.Open();

                // Query user info by username
                string query = "SELECT UserID, FullName, Email, Phone, UserType, Password FROM UserInfo WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["Password"].ToString().Trim();

                            // Compare stored password with hashed or plain text (fallback for demo data)
                            if (storedPassword == hashedPassword || storedPassword == password)
                            {
                                // Save logged-in user info into Session
                                Session.CurrentUser = new User
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    FullName = reader["FullName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Role = reader["UserType"].ToString()
                                };

                                // Show success message
                                MessageBox.Show($"Welcome back, {Session.CurrentUser.FullName}!", "Login Successful",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Redirect based on role
                                if (Session.CurrentUser.Role == "Admin")
                                    new AdminDashboardForm().Show();
                                else
                                    new UserDashboard().Show();

                                this.Hide(); // Hide login form after successful login
                            }
                            else
                            {
                                // Wrong password
                                MessageBox.Show("Invalid username or password.", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // No user found with that username
                            MessageBox.Show("User not found.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors (e.g., DB connection issues)
                MessageBox.Show("Error during login: " + ex.Message, "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Always close connection after use
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private string CleanPassword(string password)
        {
            if (password == null) return "";

            // Remove whitespace and invisible characters to avoid login issues
            password = password.Trim();
            password = password.Replace(" ", "");
            password = password.Replace("\n", "");
            password = password.Replace("\r", "");
            password = password.Replace("\t", "");
            password = password.Replace("\0", "");

            return password;
        }

        private string HashPassword(string password)
        {
            // Hash password using SHA256 for security
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private void chckBackShowPass_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility when checkbox is clicked
            txtPass.UseSystemPasswordChar = !chckBackShowPass.Checked;
        }
    }
}
