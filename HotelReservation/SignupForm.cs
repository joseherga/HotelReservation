using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class SignupForm : Form
    {
        static CallDatabase callDatabase = new CallDatabase();
        SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath());
        SqlCommand cmd;

        UserDashboard ud = new UserDashboard();

        private const string SystemEmail = "ByteLodge.sup@gmail.com";
        private const string SystemPassword = "tpak deuz wmhy nugl";

        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMidName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all required fields.", "Registration Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = $"{firstName} {middleName} {surname}".Replace("  ", " ").Trim();

            // Check duplicates
            try
            {
                con.Open();
                string checkQuery = "SELECT COUNT(*) FROM UserInfo WHERE Email=@Email OR Username=@Username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@Email", email);
                checkCmd.Parameters.AddWithValue("@Username", username);
                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Email or Username already exists.", "Registration Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking duplicates: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                con.Close();
            }

            // Generate OTP and send email
            string otpCode = new Random().Next(100000, 999999).ToString();
            bool otpSent = SendOTPEmail(SystemEmail, SystemPassword, email, otpCode);

            if (!otpSent)
            {
                MessageBox.Show("Failed to send OTP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OTPVerificationForm otpForm = new OTPVerificationForm(otpCode, email);
            otpForm.ShowDialog();

            if (otpForm.Tag != null && otpForm.Tag.ToString() == "Verified")
            {
                try
                {
                    con.Open();
                    string query = @"INSERT INTO UserInfo 
                                    (FirstName, MiddleName, Surname, FullName, Phone, Email, Username, Password, UserType) 
                                    VALUES (@FirstName, @MiddleName, @Surname, @FullName, @Phone, @Email, @Username, @Password, @UserType)";

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleName", middleName);
                    cmd.Parameters.AddWithValue("@Surname", surname);
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", HashPassword(password));
                    cmd.Parameters.AddWithValue("@UserType", "Customer");

                    cmd.ExecuteNonQuery();

                    Session.CurrentUser = new User
                    {
                        FullName = fullName,
                        Email = email,
                        Phone = phone,
                        Role = "Customer"
                    };

                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ud.Show();
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
            else
            {
                MessageBox.Show("OTP verification failed.", "Verification Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool SendOTPEmail(string senderEmail, string senderPassword, string recipientEmail, string otpCode)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtp.EnableSsl = true;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(senderEmail, "Byte Lodge | Hotel Reservation System");
                    mail.To.Add(recipientEmail);
                    mail.Subject = "ByteLodge OTP Verification";
                    mail.Body = $"Hello,\n\n" +
                                $"Thank you for signing up with ByteLodge! 🎉\n" +
                                $"Your One-Time Password (OTP) is: {otpCode}\n\n" +
                                $"Please enter this code in the app to complete your registration.\n" +
                                $"Note: This code will expire in 5 minutes.\n\n" +
                                $"If you didn’t request this, you can safely ignore this email.\n\n" +
                                $"Best regards,\n" +
                                $"ByteLodge Hotel Reservation Team";

                    smtp.Send(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send OTP: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}