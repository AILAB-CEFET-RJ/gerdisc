using gerdisc.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using gerdisc.Settings;

namespace gerdisc.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(ISettings settings)
        {
            _emailSettings = settings.EmailSettings;
        }

        public async Task SendEmail(string recipient, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("PPCIC", _emailSettings.Username));
            message.To.Add(new MailboxAddress("", recipient));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
