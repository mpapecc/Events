using Events.Application.Options;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace Events.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSection smtpSection;

        public EmailSender(IOptions<SmtpSection> smtpSection)
        {
            this.smtpSection = smtpSection.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(null, this.smtpSection.From));
            message.To.Add(new MailboxAddress(null, email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = htmlMessage };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(this.smtpSection.Smtp, this.smtpSection.Port);
            await smtp.AuthenticateAsync(this.smtpSection.Username, this.smtpSection.Password);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}
