using gerdisc.Infrastructure.Providers.Interfaces;
using gerdisc.Settings;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace gerdisc.Infrastructure.Providers
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
            using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

                var message = new MailMessage(_emailSettings.SenderEmail, recipient, subject, body);

                await client.SendMailAsync(message);
            }
        }
    }
}
