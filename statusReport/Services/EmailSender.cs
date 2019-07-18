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
        private readonly IOptions<ManagerSettings> _managerSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings, IOptions<ManagerSettings> managerSettings)
        {
            _emailSettings = emailSettings;
            _managerSettings = managerSettings;
        }
        


        public Task SendEmailAsync(string toEmail, string subject, string message)
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

                var emails = toEmail.Split(';');            
                foreach(var email in emails)
                {
                    mail.To.Add(new MailAddress(email));
                }


                //// Smtp client
                var client = new SmtpClient()
                {
                    Port = _emailSettings.Value.MailPort,
                    DeliveryMethod = SmtpDeliveryMethod.Network,

                    Host = _emailSettings.Value.MailServer,
                    EnableSsl = true,
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
