using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class OTPVerificationForm : Form
    {
        private string expectedOTP;
        private readonly string recipientEmail;
        private DateTime otpGeneratedTime;

        public OTPVerificationForm()
        {
            InitializeComponent();
        }

        public OTPVerificationForm(string otp, string email) : this()
        {
            expectedOTP = otp ?? string.Empty;
            recipientEmail = email ?? string.Empty;
            otpGeneratedTime = DateTime.Now; // track expiry
        }

        private void OTPVerificationForm_Load(object sender, EventArgs e)
        {
            txtOTP1.TextChanged += OTP_TextChanged;
            txtOTP2.TextChanged += OTP_TextChanged;
            txtOTP3.TextChanged += OTP_TextChanged;
            txtOTP4.TextChanged += OTP_TextChanged;
            txtOTP5.TextChanged += OTP_TextChanged;
            txtOTP6.TextChanged += OTP_TextChanged;

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
        }

        private void OTP_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox currentBox && currentBox.Text.Length == 1)
                this.SelectNextControl(currentBox, true, true, true, true);
        }

        private string GetEnteredOTP()
        {
            return txtOTP1.Text + txtOTP2.Text + txtOTP3.Text +
                   txtOTP4.Text + txtOTP5.Text + txtOTP6.Text;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string enteredCode = GetEnteredOTP();

            if (string.IsNullOrEmpty(expectedOTP))
            {
                MessageBox.Show("No expected OTP available to verify against.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Expiry check (5 minutes)
            if ((DateTime.Now - otpGeneratedTime).TotalMinutes > 5)
            {
                MessageBox.Show("OTP has expired. Please request a new one.",
                    "Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (enteredCode == expectedOTP)
            {
                MessageBox.Show("OTP verified successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            expectedOTP = new Random().Next(100000, 999999).ToString();
            otpGeneratedTime = DateTime.Now; // reset expiry

            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("ByteLodge.sup@gmail.com", "tpak deuz wmhy nugl");
                    smtp.EnableSsl = true;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("ByteLodge150@gmail.com", "Hotel Reservation System");
                    mail.To.Add(recipientEmail);
                    mail.Subject = "Your New OTP Code";
                    mail.Body = $"Your new OTP code is: {expectedOTP}\n\nThis code will expire in 5 minutes.";

                    smtp.Send(mail);
                }

                MessageBox.Show("A new OTP has been sent to your email.",
                    "OTP Resent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to resend OTP: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtOTP1.Clear();
            txtOTP2.Clear();
            txtOTP3.Clear();
            txtOTP4.Clear();
            txtOTP5.Clear();
            txtOTP6.Clear();

            txtOTP1.Focus();
        }
    }
}