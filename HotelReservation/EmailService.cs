using System.Net;
using System.Net.Mail;

public static class EmailService
{
    public static void SendOtp(string recipientEmail, string otp)
    {
        string fromEmail = "tres.gutentag@gmail.com";
        string appPassword = "M@Dlife014xDDD";

        var message = new MailMessage(fromEmail, recipientEmail);
        message.Subject = "Your OTP Code";
        message.Body = $"Your one-time password is: {otp}";

        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(fromEmail, appPassword)
        };

        client.Send(message);
    }
}
