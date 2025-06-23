using System.Net;
using System.Net.Mail;
using Packer.Application.Config;
using Packer.Application.Interfaces.Conmmunication;
using Microsoft.Extensions.Options;

namespace Packer.Infrastructure.Services.Communication
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig _emailConfig;

        public EmailService(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task SendEmailAsync(EmailMessage message)
        {
            using var client = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.SmtpPort)
            {
                EnableSsl = _emailConfig.EnableSsl,
                Credentials = new NetworkCredential(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword)
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailConfig.FromEmail, _emailConfig.FromName),
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = message.IsHtml
            };

            mailMessage.To.Add(message.To);

            await client.SendMailAsync(mailMessage);
        }
    }
}