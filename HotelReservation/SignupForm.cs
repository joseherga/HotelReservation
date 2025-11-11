using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class SignupForm : Form
    {
        static CallDatabase callDatabase = new CallDatabase();
        SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath());
        SqlCommand cmd;

        LoginForm lg = new LoginForm();

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
                MessageBox.Show("Please fill in all required fields, including email.", "Registration Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = $"{firstName} {middleName} {surname}".Replace("  ", " ").Trim();

            // Generate OTP and send email
            string otpCode = new Random().Next(100000, 999999).ToString();
            bool otpSent = SendOTPEmail(email, otpCode);

            if (!otpSent)
            {
                MessageBox.Show("Failed to send OTP. Please check your email and try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show OTP verification form
            OTPVerificationForm otpForm = new OTPVerificationForm(otpCode, email);
            otpForm.ShowDialog();

            // Proceed only if OTP was verified
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
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@UserType", "Customer");

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lg.Show();
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
                MessageBox.Show("OTP verification failed or was cancelled.", "Verification Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool SendOTPEmail(string recipientEmail, string otpCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(recipientEmail))
                    throw new ArgumentNullException(nameof(recipientEmail), "Email address cannot be empty.");

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("yelyah.pmore.1988@gmail.com", "hmlr xgmk nhyt ehph");
                    smtp.EnableSsl = true;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("yelyah.pmore.1988@gmail.com", "Hotel Reservation System");
                    mail.To.Add(recipientEmail);
                    mail.Subject = "Your OTP Code";
                    mail.Body = $"Your OTP code is: {otpCode}\n\nThis code will expire in 5 minutes.";

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

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lg.Show();
            this.Hide();
        }
    }
}
