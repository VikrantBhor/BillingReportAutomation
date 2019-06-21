using Microsoft.AspNetCore.Mvc;
using statusReport.BillingDBModels;
using statusReport.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace statusReport.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        //private readonly BillingReportContext dbContext;

        public ReportController()
        {
            //dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("reportStatus/{role}/{reportStatus}")]
        public async Task<IActionResult> GetReport([FromRoute]string role, [FromRoute]int reportStatus = 0)
        {
            var result = new List<ReportList>();
            using (BillingReportContext context = new BillingReportContext())
            {
                if (role == "TL")
                {
                    if (reportStatus == 0) // Saved
                    {
                        result = (from reportSummary in context.TblReportSummery
                                  where reportSummary.ReportStatus == Convert.ToInt32(ReportStatus.Saved)
                                  orderby reportSummary.CreatedDate
                                  select new ReportList
                                  {
                                      ReportId = reportSummary.ReportId,
                                      ClientName = reportSummary.ClientName,
                                      ProjectName = reportSummary.ProjectName,
                                      ProjectType = reportSummary.ProjectType,
                                      CreatedDate = reportSummary.CreatedDate
                                  }).ToList();
                    }
                    if (reportStatus == 3) // Rejected
                    {
                        result = (from reportSummary in context.TblReportSummery
                                  where reportSummary.ReportStatus == Convert.ToInt32(ReportStatus.Rejected)
                                  orderby reportSummary.LastUpdatedDate
                                  select new ReportList
                                  {
                                      ReportId = reportSummary.ReportId,
                                      ClientName = reportSummary.ClientName,
                                      ProjectName = reportSummary.ProjectName,
                                      ProjectType = reportSummary.ProjectType,
                                      CreatedDate = reportSummary.CreatedDate
                                  }).ToList();
                    }
                }
                else
                if (role == "Manager")
                {
                    if (reportStatus == 1) // Submitted and Rejected
                    {
                        result = (from reportSummary in context.TblReportSummery
                                  where reportSummary.ReportStatus == Convert.ToInt32(ReportStatus.Rejected) || reportSummary.ReportStatus == Convert.ToInt32(ReportStatus.Submitted)
                                  orderby reportSummary.LastUpdatedDate
                                  select new ReportList
                                  {
                                      ReportId = reportSummary.ReportId,
                                      ClientName = reportSummary.ClientName,
                                      ProjectName = reportSummary.ProjectName,
                                      ProjectType = reportSummary.ProjectType,
                                      CreatedDate = reportSummary.CreatedDate,
                                      Remark = reportSummary.Remark
                                  }).ToList();
                    }
                }
            }

            return Ok(result);
        }
    }
}