using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace HotelReservation
{
    // Static helper class for sending emails (OTP and receipts).
    // Centralizes email logic so other forms don’t need to repeat SMTP setup.
    public static class EmailHelper
    {
        // System email account + app password (used for authentication with Gmail SMTP).
        private const string SystemEmail = "ByteLodge.sup@gmail.com";
        private const string SystemPassword = "tpak deuz wmhy nugl"; // Gmail app password

        // Method to send a plain text email containing an OTP code.
        // Used during registration or verification steps.
        public static bool SendOtp(string recipientEmail, string otpCode)
        {
            try
            {
                // Configure SMTP client for Gmail (port 587 with SSL).
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(SystemEmail, SystemPassword);
                    smtp.EnableSsl = true;

                    // Build the email message with subject and body.
                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(SystemEmail, "Byte Lodge | Hotel Reservation System"),
                        Subject = "ByteLodge OTP Verification",
                        Body = $"Hello,\n\nYour One-Time Password (OTP) is: {otpCode}\n\n" +
                               $"Please enter this code in the app to complete your registration.\n\n" +
                               $"Best regards,\nByteLodge Hotel Reservation Team"
                    };

                    // Add recipient and send the email.
                    mail.To.Add(recipientEmail);
                    smtp.Send(mail);
                }
                return true; // Success
            }
            catch (Exception ex)
            {
                // Show error message if sending fails.
                MessageBox.Show("Failed to send OTP: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Method to send an email with a PDF receipt attached.
        // Used after successful booking/payment.
        public static bool SendReceipt(string recipientEmail, string filePath)
        {
            try
            {
                // Configure SMTP client for Gmail (same setup as OTP).
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(SystemEmail, SystemPassword);
                    smtp.EnableSsl = true;

                    // Build the email message with subject, body, and attachment.
                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(SystemEmail, "Byte Lodge | Hotel Reservation System"),
                        Subject = "Your Hotel Reservation Receipt",
                        Body = $"Hello,\n\nThank you for your booking with ByteLodge! 🎉\n" +
                               $"Please find your receipt attached.\n\n" +
                               $"Best regards,\nByteLodge Hotel Reservation Team"
                    };

                    // Add recipient and attach the receipt PDF.
                    mail.To.Add(recipientEmail);
                    mail.Attachments.Add(new Attachment(filePath));

                    // Send the email.
                    smtp.Send(mail);
                }
                return true; // Success
            }
            catch (Exception ex)
            {
                // Show error message if sending fails.
                MessageBox.Show("Failed to send receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}