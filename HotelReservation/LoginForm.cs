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
        static CallDatabase cd = new CallDatabase();
        SqlConnection con = new SqlConnection(cd.GetDatabasePath());

        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupForm signup = new SignupForm();
            signup.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;

            // Clean password from invisible characters
            password = CleanPassword(password);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = HashPassword(password);

            try
            {
                con.Open();

                string query = "SELECT UserID, FullName, Email, Phone, UserType, Password FROM UserInfo WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["Password"].ToString().Trim();

                            // Check both hashed and plain text password
                            if (storedPassword == hashedPassword || storedPassword == password)
                            {
                                Session.CurrentUser = new User
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    FullName = reader["FullName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Role = reader["UserType"].ToString()
                                };

                                MessageBox.Show($"Welcome back, {Session.CurrentUser.FullName}!", "Login Successful",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (Session.CurrentUser.Role == "Admin")
                                    new AdminDashboardForm().Show();
                                else
                                    new UserDashboard().Show();

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


        private string CleanPassword(string password)
        {
            if (password == null) return "";

            // Remove ALL whitespace & invisible characters
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
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private void chckBackShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chckBackShowPass.Checked;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
