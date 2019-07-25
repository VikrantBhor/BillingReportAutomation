using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using statusReport.BillingDBModels;
using statusReport.DTO;
using statusReport.Models;
using Microsoft.AspNetCore.Mvc;
using statusReport.BillingDBModels;
using statusReport.DTO;
using statusReport.Utils;
using statusReport.Services.Implementation;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statusReport.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private actitimeContext dbContext;
        
        public ReportController(actitimeContext context,IEmailSender _emailSender)
        {
            dbContext = context;
        }

        //// GET: api/<controller>
        //[HttpGet("GetClientList")]
        //public IEnumerable<Customer> GetClientList()
        //{
        //    //try
        //    //{
        //    //    var clientList = dbContext.Customer.ToList();
        //    //    return clientList;

        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //    throw;
        //    //}

        //    actitimeContext context = HttpContext.RequestServices.GetService(typeof(statusReport.Models.actitimeContext)) as actitimeContext;

        //    return context.GetClients();

        //}
        
        [HttpGet("GetProgramType/{id}")]
        public List<Client> GetProgramType(string id)
        {
            List<Client> list = new List<Client>();
            using (actitimeContext context = HttpContext.RequestServices.GetService(typeof(statusReport.Models.actitimeContext)) as actitimeContext)
            {
                using (MySqlConnection conn = context.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from project where customer_Id = "+ Convert.ToInt32(id) + " order by Name", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Client()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString()
                            });
                        }
                    }
                }

            }
            return list;
        }

        [HttpGet("GetClientList")]
        public List<Client> GetClientList()
        {
            List<Client> list = new List<Client>();            
            using (actitimeContext context = HttpContext.RequestServices.GetService(typeof(statusReport.Models.actitimeContext)) as actitimeContext)
            {
            using (MySqlConnection conn = context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from customer order by Name", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Client()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()                           
                        });
                    }
                }
            }

            }
            return list;
        }

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        [HttpPost("SaveReportDetails")]
        public int SaveReportDetails([FromBody]Report reportDetail)
        {
            using (BillingReportContext context = new BillingReportContext())
            {
                TblReportSummery reportSummery = new TblReportSummery();
                reportSummery.ApprovedBy = null;
                reportSummery.ApprovedDate = null;
                reportSummery.ClientName = reportDetail.ClientName;
                reportSummery.CreatedBy = reportDetail.CreatedBy;
                reportSummery.CreatedByEmail = reportDetail.CreatedByEmail;
                reportSummery.CreatedDate = DateTime.Now;
                reportSummery.IsApproved = false;
                reportSummery.LastUpdatedBy = null;
                reportSummery.LastUpdatedDate = null;
                reportSummery.ProjectEndDate = DateTime.Now.AddDays(90);
                reportSummery.ProjectName = reportDetail.ProjectName;
                reportSummery.ProjectType = reportDetail.ProjectType;
                reportSummery.ReportStartDate = reportDetail.ReportStartDate;
                reportSummery.ReportEndDate = reportDetail.ReportEndDate;
                reportSummery.Remark = null;
                reportSummery.ReportStatus = reportDetail.ReportStatus;
                reportSummery.Type = reportDetail.Type;

                context.Add(reportSummery);
                context.SaveChanges();
                int id = reportSummery.ReportId;
                return id;
            }

         }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpGet]
        [Route("reportStatus/{role}/{reportStatus}/{userEmail}")]
        public async Task<IActionResult> GetReport([FromRoute]string role, [FromRoute]int reportStatus,[FromRoute]string userEmail)
        {
            var result = new List<ReportList>();
            using (BillingReportContext context = new BillingReportContext())
            {
                if (role == "TL")
                {
                    if (reportStatus == 0) // Saved
                    {
                        result = (from reportSummary in context.TblReportSummery
                                  where (reportSummary.ReportStatus == Convert.ToInt32(ReportStatus.Saved))
                                  && reportSummary.CreatedByEmail == userEmail
                                  orderby reportSummary.CreatedDate descending
                                  select new ReportList
                                  {
                                      ReportId = reportSummary.ReportId,
                                      ClientName = reportSummary.ClientName,
                                      ProjectName = reportSummary.ProjectName,
                                      ProjectType = reportSummary.ProjectType,
                                      CreatedDate = reportSummary.CreatedDate,
                                      ReportStartDate = reportSummary.ReportStartDate,
                                      ReportEndDate = reportSummary.ReportEndDate
                                  }).ToList();
                    }
                    if (reportStatus == 2) // Rejected
                    {
                        result = (from reportSummary in context.TblReportSummery
                                  where reportSummary.ReportStatus == Convert.ToInt32(ReportStatus.Rejected)
                                  && reportSummary.CreatedByEmail == userEmail
                                  orderby reportSummary.LastUpdatedDate descending
                                  select new ReportList
                                  {
                                      ReportId = reportSummary.ReportId,
                                      ClientName = reportSummary.ClientName,
                                      ProjectName = reportSummary.ProjectName,
                                      ProjectType = reportSummary.ProjectType,
                                      CreatedDate = reportSummary.CreatedDate,
                                      ReportStartDate = reportSummary.ReportStartDate,
                                      ReportEndDate = reportSummary.ReportEndDate,
                                      Remark = reportSummary.Remark
                                  }).ToList();
                    }
                }
                else
                if (role == "Manager")
                {
                    if (reportStatus == 1) // Submitted and Rejected
                    {
                        result = (from reportSummary in context.TblReportSummery
                                  where reportSummary.ReportStatus == Convert.ToInt32(ReportStatus.Created)
                                  orderby reportSummary.LastUpdatedDate descending
                                  select new ReportList
                                  {
                                      ReportId = reportSummary.ReportId,
                                      ClientName = reportSummary.ClientName,
                                      ProjectName = reportSummary.ProjectName,
                                      ProjectType = reportSummary.ProjectType,
                                      CreatedDate = reportSummary.CreatedDate,
                                      SubmittedBy = reportSummary.CreatedBy,
                                      ReportStartDate = reportSummary.ReportStartDate,
                                      ReportEndDate = reportSummary.ReportEndDate,
                                      Remark = reportSummary.Remark
                                  }).ToList();
                    }
                }
            }



            return Ok(result);
        }
    }
}
