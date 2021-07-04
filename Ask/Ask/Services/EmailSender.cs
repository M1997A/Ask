using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public AuthMessageSenderOptions Options { get; }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await Execute(Options.SendGridKey, subject, htmlMessage, email);
        }
        public async Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage
            {
                Subject = subject,
                From = new EmailAddress("made319006@gmail.com", "Ask"),
                PlainTextContent = message,
                HtmlContent = message

            };
            msg.AddTo(new EmailAddress(email));
            msg.SetClickTracking(false, false);
            await client.SendEmailAsync(msg);
        }
    }
}
