using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using TicketManagement.Application.Contracts.Infrastructure;
using TicketManagement.Application.Models.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace TicketManagement.Infrastructure.Mail
{
    public class Emailservice : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<Emailservice> _logger { get; }

        public Emailservice(IOptions<EmailSettings> mailSettings, ILogger<Emailservice> logger)
        {
            _emailSettings = mailSettings.Value;
            _logger = logger;
            
        }

        public async Task<bool> SendEmail(Email email)
        {
            // create message
            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromAddress));
            mail.To.Add(MailboxAddress.Parse(email.To));
            mail.Subject = email.Subject;
            mail.Body = new TextPart(TextFormat.Html) { Text = email.Body };

            // send email
            try
            {
                using var smtp = new SmtpClient();
                smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSettings.User, _emailSettings.Password);
                var response = await smtp.SendAsync(mail);
                smtp.Disconnect(true);

                _logger.LogInformation("Email sent");

                return true;

            }
            catch (Exception)
            {
                _logger.LogError("Email sending failed");
                return false;
            }
        }
    }
}