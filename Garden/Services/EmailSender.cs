using System;
using System.IO;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Garden.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Services/smtpsettings.json").Build();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", configuration["e-mail"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.Connect(configuration["host"], Int32.Parse(configuration["port"]), false);
                client.Authenticate(configuration["e-mail"], configuration["password"]);
                client.Send(emailMessage);

                client.Disconnect(true);
            }
            return Task.CompletedTask;
        }
    }
}
