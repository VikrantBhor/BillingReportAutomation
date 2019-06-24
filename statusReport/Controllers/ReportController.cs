using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using statusReport.BillingDBModels;
using statusReport.DTO;
using statusReport.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace statusReport.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private actitimeContext dbContext;

        public ReportController(actitimeContext context)
        {
                this.dbContext = context;

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
                    MySqlCommand cmd = new MySqlCommand("select * from project where customer_Id = "+ Convert.ToInt32(id), conn);

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
                MySqlCommand cmd = new MySqlCommand("select * from customer", conn);

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
        public void SaveReportDetails([FromBody]Report reportDetail)
        {
            using (BillingReportContext context = new BillingReportContext())
            {
                TblReportSummery reportSummery = new TblReportSummery();
                reportSummery.ApprovedBy = null;
                reportSummery.ApprovedDate = null;
                reportSummery.ClientName = reportDetail.ClientName;
                reportSummery.CreatedBy = null;
                reportSummery.CreatedDate = null;
                reportSummery.IsApproved = false;
                reportSummery.LastUpdatedBy = null;
                reportSummery.LastUpdatedDate = null;
                reportSummery.ProjectEndDate = DateTime.Now.AddDays(90);
                reportSummery.ProjectName = reportDetail.ProjectName;
                reportSummery.ProjectType = reportDetail.ProjectType;
                reportSummery.ReportStartDate = reportDetail.ReportStartDate;
                reportSummery.Remark = null;
                reportSummery.ReportStatus = null;

                context.Add(reportSummery);
                context.SaveChanges();

               
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
    }
}
