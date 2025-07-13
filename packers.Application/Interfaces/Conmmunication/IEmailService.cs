using System.Threading.Tasks;

namespace packers.Application.Interfaces.Conmmunication
{
    public class EmailMessage
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsHtml { get; set; }
    }

    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage message);
    }
}