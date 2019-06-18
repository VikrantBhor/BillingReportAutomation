using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using statusReport.BillingDBModels;

namespace statusReport.Controllers
{
    [Route("api/[controller]")]
    public class ReportSummeryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IEnumerable<TblReportCr> getCRDetails()
        {
            using (BillingReportContext context = new BillingReportContext())
            {
                return context.TblReportCr.Where(x => x.ReportId == 1).ToList();
            }

        }

        [HttpGet("[action]")]
        public IEnumerable<TblReportActivity> getActivityDetails()
        {
            using (BillingReportContext context = new BillingReportContext())
            {
                return context.TblReportActivity.Where(x => x.ReportId == 1).ToList();
            }

        }
    }
}