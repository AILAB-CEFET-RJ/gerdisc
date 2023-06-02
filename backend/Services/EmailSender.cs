using System.Net.Http.Headers;
using System.Text;
using gerdisc.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using gerdisc.Settings;

namespace gerdisc.Services.Professor
{

    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(ISettings settings)
        {
            _emailSettings = settings.EmailSettings;
        }

        public Task SendEmail(string recipient, string subject, string body)
        {
            return Task.Run(() =>
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("PPCIC", _emailSettings.Username));
                message.To.Add(new MailboxAddress("", recipient));
                message.Subject = subject;
                message.Body = new TextPart("plain") { Text = body };

                using (var client = new SmtpClient())
                {
                    client.Connect(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);
                    client.Authenticate(_emailSettings.Username, _emailSettings.Password);
                    client.Send(message);
                    client.Disconnect(true);
                }
            });
        }
    }

}
