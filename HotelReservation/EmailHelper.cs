using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace HotelReservation
{
    public static class EmailHelper
    {
        // Centralized system email + app password
        private const string SystemEmail = "ByteLodge.sup@gmail.com";
        private const string SystemPassword = "tpak deuz wmhy nugl"; // Gmail app password

        // Send a plain text email (used for OTP).
        public static bool SendOtp(string recipientEmail, string otpCode)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(SystemEmail, SystemPassword);
                    smtp.EnableSsl = true;

                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(SystemEmail, "Byte Lodge | Hotel Reservation System"),
                        Subject = "ByteLodge OTP Verification",
                        Body = $"Hello,\n\nYour One-Time Password (OTP) is: {otpCode}\n\n" +
                               $"Please enter this code in the app to complete your registration.\n\n" +
                               $"Best regards,\nByteLodge Hotel Reservation Team"
                    };

                    mail.To.Add(recipientEmail);
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

        // Send an email with a PDF receipt attached.
        public static bool SendReceipt(string recipientEmail, string filePath)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(SystemEmail, SystemPassword);
                    smtp.EnableSsl = true;

                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(SystemEmail, "Byte Lodge | Hotel Reservation System"),
                        Subject = "Your Hotel Reservation Receipt",
                        Body = $"Hello,\n\nThank you for your booking with ByteLodge! 🎉\n" +
                               $"Please find your receipt attached.\n\n" +
                               $"Best regards,\nByteLodge Hotel Reservation Team"
                    };

                    mail.To.Add(recipientEmail);
                    mail.Attachments.Add(new Attachment(filePath));

                    smtp.Send(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
