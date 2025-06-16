using MailKit.Security;
using MimeKit;

namespace MedBook.Services
{
    public class EmailManager
    {
        private const string fromTopic = "Администрация MedBook";
        private const string fromAddress = "vyacheslav.nedelko@yandex.ru";
        private const string smtpServer = "smtp.yandex.ru";
        private const string fromPassword = "xvvemudjkguvwfyy";
        public async Task SendMailAsync(string email, string subject, string message)
        {
            using var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(fromTopic, fromAddress));
            emailMessage.To.Add(new MailboxAddress(string.Empty, email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            await client.ConnectAsync(smtpServer, 465, SecureSocketOptions.SslOnConnect);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(fromAddress, fromPassword);
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }
}
