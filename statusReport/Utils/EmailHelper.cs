using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using statusReport.BillingDBModels;
using statusReport.Common;
using statusReport.Services.Implementation;
using statusReport.ViewModel;

namespace statusReport.Utils
{
    public class EmailHelper
    {
        private static IOptions<ManagerSettings> _managerSettings;
        public EmailHelper(IOptions<ManagerSettings> managerSettings)
        {
            _managerSettings = managerSettings;
        }
       
        public static void ReportSaved(string email, IEmailSender svc, string attachment,ReportSummery reportSummery)
        {
            Task.Run(async () =>
            {
                var sb = new StringBuilder();
                sb.Append($"<h2>Report has been saved successfully</h2>");
                sb.Append($"<h4>Client Name:  {reportSummery.clientName}</h4>");
                sb.Append($"<h4>Project Name:  {reportSummery.projectName}</h4>");
                sb.Append($"<h4>Report Type:  {reportSummery.projectType}</h4>");
                var body = sb.ToString();
                await SendEmail("Report saved!", "", email, "", "", body, new List<string>() { attachment }, true, svc);
            });
        }

        public static void ReportSubmitted(string email, IEmailSender svc, string attachment, ReportSummery reportSummery)
        {
            Task.Run(async () =>
            {
                var sb = new StringBuilder();
                sb.Append($"<h2>Report has been submitted successfully</h2>");
                sb.Append($"<h4>Client Name:  {reportSummery.clientName}</h4>");
                sb.Append($"<h4>Project Name:  {reportSummery.projectName}</h4>");
                sb.Append($"<h4>Report Type:  {reportSummery.projectType}</h4>");
                //email = email + ";" + _managerSettings.Value.ManagerEmail;                
                var body = sb.ToString();
                await SendEmail("Report submitted!", "", email, "", "", body, new List<string>() { attachment }, true, svc);
            });
        }

        public static void ReportRejected(string email, IEmailSender svc, string attachment,string remark,TblReportSummery reportSummery)
        {
            Task.Run(async () =>
            {
                var sb = new StringBuilder();
                sb.Append($"<h2>Report has been Rejected</h2>");
                sb.Append($"<h4>Client Name:  {reportSummery.ClientName}</h4>");
                sb.Append($"<h4>Project Name:  {reportSummery.ProjectName}</h4>");
                sb.Append($"<h4>Report Type:  {reportSummery.ProjectType}</h4>");
                //email = email + ";" + _managerSettings.Value.ManagerEmail;
                var body = sb.ToString();
                await SendEmail("Report Rejected!", "", email, "", "", body, new List<string>() { attachment }, true, svc);
            });
        }

        public static void ReportUploaded(string email, IEmailSender svc, string attachment, TblReportSummery reportSummery)
        {
            Task.Run(async () =>
            {
                var sb = new StringBuilder();
                sb.Append($"<h2>Report has been Uploaded</h2>");
                sb.Append($"<h4>Client Name:  {reportSummery.ClientName}</h4>");
                sb.Append($"<h4>Project Name:  {reportSummery.ProjectName}</h4>");
                sb.Append($"<h4>Report Type:  {reportSummery.ProjectType}</h4>");
                //email = email + ";" + _managerSettings.Value.ManagerEmail;
                var body = sb.ToString();
                await SendEmail("Report Uploaded!", "", email, "", "", body, new List<string>() { attachment }, true, svc);
            });
        }




        public static async Task SendEmail(string subject, string from, string toEmail, string cc, string bcc, string body, List<string> attachments, bool isHTML, IEmailSender svc, String replyTo = "")
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

            await svc.SendEmailAsync(toEmail, subject, body);
        }

    }
}
