using Microsoft.Extensions.Options;
using statusReport.Common;
using statusReport.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace statusReport.Services
{
    public class EmailSender : IEmailSender
    {
        private IOptions<EmailSettings>  _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential(_emailSettings.Value.Sender, _emailSettings.Value.Password);

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.Value.Sender, _emailSettings.Value.SenderName),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress("ankur.gautam@atidan.com"));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = _emailSettings.Value.MailPort,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = _emailSettings.Value.MailServer,
                    EnableSsl = false,
                    Credentials = credentials
                };

                // Send it...         
                client.Send(mail);
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}
