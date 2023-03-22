using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagement.Web.Configurations.Email
{
    public class EmailSender : IEmailSender
    {
        public string SmtpEmail { get; set; }

        public string SmtpHost { get; set; }

        public int SmtpPort { get; set; }

        public string? email { get; set; }

        public string? subject { get; set; }

        public string? htmlMessage { get; set; }

        public EmailSender(string SmtpHost, int SmtpPort, string SmtpEmail)
        {
            this.SmtpHost = SmtpHost;
            this.SmtpPort = SmtpPort;
            this.SmtpEmail = SmtpEmail;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage
            {
                From = new MailAddress(SmtpEmail),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(email));

            using (var client = new SmtpClient(SmtpHost,SmtpPort)) 
            { 
                client.Send(message);
            }
            return Task.CompletedTask;
        }
    }
}
