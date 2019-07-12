using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using statusReport.Services.Implementation;

namespace statusReport.Utils
{
    public class EmailHelper
    {
        public static void ReportSubmitted(string ccID, string owner, string email, IEmailSender svc, string attachment)
        {
            Task.Run(async () =>
            {
                var sb = new StringBuilder();
                sb.Append($"<h2>Survey Submitted successfully</h2>");
                var timeUtc = DateTime.UtcNow;
                TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime estDate = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
                sb.Append($"<h4>Survey with CCID {ccID} was successfully submitted by {owner} on {estDate.ToLongDateString()} {estDate.ToLongTimeString()} </h4>");
                var body = sb.ToString();
                await SendEmail("Survey submitted successfully", "admin@universalccc.com", email, "", "", body, new List<string>() { attachment }, true, svc);
            });
        }

        public static async Task SendEmail(string subject, string from, string to, string cc, string bcc, string body, List<string> attachments, bool isHTML, IEmailSender svc, String replyTo = "")
        {
            var message = new MailMessage();
            foreach (var objString in attachments)
            {
                if (!string.IsNullOrWhiteSpace(objString))
                {
                    var ms = new MemoryStream(Convert.FromBase64String(objString));
                    ms.Seek(0, SeekOrigin.Begin);
                    var attachment = new Attachment(ms, "Survey.pdf", "application/pdf");
                    message.Attachments.Add(attachment);
                }
            }

            await svc.SendEmailAsync("1", "2", "2");
        }

    }
}
