using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class OTPVerificationForm : Form
    {
        // Expected OTP value to compare against
        private string expectedOTP;

        // Email address where OTP was sent
        private readonly string recipientEmail;

        // Track when OTP was generated (used for expiry check)
        private DateTime otpGeneratedTime;

        // Countdown timer (in seconds) – 5 minutes = 300 seconds
        private int remainingSeconds = 300;

        public OTPVerificationForm()
        {
            InitializeComponent(); // Initialize UI components
        }

        // Constructor that accepts OTP and recipient email
        public OTPVerificationForm(string otp, string email) : this()
        {
            expectedOTP = otp ?? string.Empty;       // store OTP or empty if null
            recipientEmail = email ?? string.Empty;  // store email or empty if null
            otpGeneratedTime = DateTime.Now;         // record time OTP was generated
        }

        private void OTPVerificationForm_Load(object sender, EventArgs e)
        {
            // Attach TextChanged events for each OTP textbox
            txtOTP1.TextChanged += OTP_TextChanged;
            txtOTP2.TextChanged += OTP_TextChanged;
            txtOTP3.TextChanged += OTP_TextChanged;
            txtOTP4.TextChanged += OTP_TextChanged;
            txtOTP5.TextChanged += OTP_TextChanged;
            txtOTP6.TextChanged += OTP_TextChanged;

            // Show message depending on whether recipient email is available
            if (!string.IsNullOrEmpty(recipientEmail))
            {
                MessageBox.Show($"An OTP has been sent to {recipientEmail}. Please enter it below.",
                    "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No recipient email was provided for the OTP.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Initialize countdown label
            lblCountdown.Text = "OTP expires in 05:00";
            lblCountdown.Visible = true;

            // Reset countdown and start timer
            remainingSeconds = 300;
            otpTimer.Start();
        }

        private void OTP_TextChanged(object sender, EventArgs e)
        {
            // Automatically move to next textbox once a digit is entered
            if (sender is TextBox currentBox && currentBox.Text.Length == 1)
                this.SelectNextControl(currentBox, true, true, true, true);
        }

        // Combine all textbox values into one string
        private string GetEnteredOTP()
        {
            return txtOTP1.Text + txtOTP2.Text + txtOTP3.Text +
                   txtOTP4.Text + txtOTP5.Text + txtOTP6.Text;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string enteredCode = GetEnteredOTP();

            // Check if expected OTP exists
            if (string.IsNullOrEmpty(expectedOTP))
            {
                MessageBox.Show("No expected OTP available to verify against.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Expiry check (valid for 5 minutes)
            if ((DateTime.Now - otpGeneratedTime).TotalMinutes > 5)
            {
                MessageBox.Show("OTP has expired. Please request a new one.",
                    "Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Compare entered OTP with expected OTP
            if (enteredCode == expectedOTP)
            {
                MessageBox.Show("OTP verified successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tag form as verified so parent can check result
                this.Tag = "Verified";
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkResend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Generate new random 6-digit OTP
            expectedOTP = new Random().Next(100000, 999999).ToString();
            otpGeneratedTime = DateTime.Now; // reset expiry timer

            try
            {
                // Configure SMTP client for Gmail
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("ByteLodge.sup@gmail.com", "tpak deuz wmhy nugl");
                    smtp.EnableSsl = true;

                    // Build email message with new OTP
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("ByteLodge150@gmail.com", "Hotel Reservation System");
                    mail.To.Add(recipientEmail);
                    mail.Subject = "Your New OTP Code";
                    mail.Body = $"Your new OTP code is: {expectedOTP} \nThis code will expire in 5 minutes.";

                    smtp.Send(mail); // Send email
                }

                MessageBox.Show("A new OTP has been sent to your email.",
                    "OTP Resent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Show error if sending fails
                MessageBox.Show("Failed to resend OTP: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Reset countdown on resend
            remainingSeconds = 300;
            lblCountdown.Text = "OTP expires in 05:00";
            otpTimer.Start();
            btnVerify.Enabled = true; // re-enable Verify button

            // Clear all OTP textboxes for fresh input
            txtOTP1.Clear();
            txtOTP2.Clear();
            txtOTP3.Clear();
            txtOTP4.Clear();
            txtOTP5.Clear();
            txtOTP6.Clear();

            // Focus back on first textbox
            txtOTP1.Focus();
        }

        private void otpTimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            // Format as mm:ss
            TimeSpan ts = TimeSpan.FromSeconds(remainingSeconds);
            lblCountdown.Text = $"OTP expires in {ts.Minutes:D2}:{ts.Seconds:D2}";

            // Warns user visually when under 1 minute
            if (remainingSeconds <= 60)
                lblCountdown.ForeColor = System.Drawing.Color.Red;
            else
                lblCountdown.ForeColor = System.Drawing.Color.Black;

            // When expired
            if (remainingSeconds <= 0)
            {
                otpTimer.Stop();
                btnVerify.Enabled = false; // disable Verify button
                lblCountdown.Text = "OTP is expired.";
            }
        }
    }
}