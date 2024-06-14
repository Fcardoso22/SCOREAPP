using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace SCORE.Services
{
    public class MailgunEmailSender : IEmailSender
    {
        private readonly string _apiKey;
        private readonly string _domain;
        private readonly string _email;
        private readonly string _host;
        private readonly int _port;
        private readonly string _password;

        public MailgunEmailSender(IConfiguration configuration)
        {
            _apiKey = configuration["Mailgun:APIKey"];
            _domain = configuration["Mailgun:Domain"];
            _email = configuration["MailSettings:Mail"];
            _host = configuration["MailSettings:Host"];
            _port = int.Parse(configuration["MailSettings:Port"]);
            _password = configuration["MailSettings:Password"];
        }

        public async Task SendEmailAsync(string email, string subject, string content)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("SCORE", _email));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = content };
            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(_host, _port, false);
                client.Authenticate(_email, _password);

                await client.SendAsync(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}


