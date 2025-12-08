using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class SignupForm : Form
    {
        // Database connection setup using CallDatabase helper
        static CallDatabase cd = new CallDatabase();
        SqlConnection con = new SqlConnection(cd.GetDatabasePath());

        public SignupForm()
        {
            InitializeComponent(); // Initialize UI components
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            // Collect input values from textboxes
            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMidName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            // Validate required fields
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all required fields.", "Registration Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build full name (handles middle name gracefully)
            string fullName = $"{firstName} {middleName} {surname}".Replace("  ", " ").Trim();

            // Check if username/email already exists in database
            if (IsDuplicateUser(username, email))
                return;

            // Generate OTP and send to email for verification
            string otpCode = new Random().Next(100000, 999999).ToString();
            bool otpSent = EmailHelper.SendOtp(email, otpCode);

            if (!otpSent)
            {
                MessageBox.Show("Failed to send OTP. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show OTP verification form
            OTPVerificationForm otpForm = new OTPVerificationForm(otpCode, email);
            otpForm.ShowDialog();

            // If OTP verified, proceed with registration
            if (otpForm.Tag != null && otpForm.Tag.ToString() == "Verified")
            {
                RegisterUser(firstName, middleName, surname, fullName, phone, email, username, password);
            }
            else
            {
                MessageBox.Show("OTP verification failed.", "Verification Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsDuplicateUser(string username, string email)
        {
            try
            {
                con.Open();
                string checkQuery = "SELECT COUNT(*) FROM UserInfo WHERE Email=@Email OR Username=@Username";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);
                    checkCmd.Parameters.AddWithValue("@Username", username);
                    int exists = (int)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("Email or Username already exists.", "Registration Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking duplicates: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            finally
            {
                con.Close();
            }

            return false;
        }

        private void RegisterUser(string firstName, string middleName, string surname, string fullName,
        string phone, string email, string username, string password)
        {
            try
            {
                con.Open();

                // Insert new user record into database
                string query = @"
                INSERT INTO UserInfo 
                (FirstName, MiddleName, Surname, FullName, Phone, Email, Username, Password, UserType)
                OUTPUT INSERTED.UserID
                VALUES (@FirstName, @MiddleName, @Surname, @FullName, @Phone, @Email, @Username, @Password, @UserType)";

                int newUserID;

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleName", middleName);
                    cmd.Parameters.AddWithValue("@Surname", surname);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", HashPassword(password)); // Securely hash password
                    cmd.Parameters.AddWithValue("@UserType", "Customer");

                    // Get the new UserID from database
                    newUserID = (int)cmd.ExecuteScalar();
                }

                // Store full session including UserID
                Session.CurrentUser = new User
                {
                    UserID = newUserID,
                    FullName = fullName,
                    Email = email,
                    Phone = phone,
                    Role = "Customer"
                };

                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirect to User Dashboard
                new UserDashboard().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel registration and return to login form
            new LoginForm().Show();
            this.Close();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Navigate back to login form
            new LoginForm().Show();
            this.Close();
        }
    }
}