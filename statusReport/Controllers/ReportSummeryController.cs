using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using statusReport.BillingDBModels;
using statusReport.ViewModel;

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
        public IEnumerable<CRDetails> getCRDetails()
        {
            try
            {
                using (BillingReportContext context = new BillingReportContext())
                {
                    return context.TblReportCr.Where(x => x.ReportId == 1).Select(x=> new CRDetails ()
                                                                            { crName = x.CrName,
                                                                              estimateHrs =(int) x.EstimateHrs,
                                                                              actualHrs = (int)x.ActualHrs,
                                                                              status = Convert.ToString(x.Status)
                                                                            }
                    ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("[action]")]
        public IEnumerable<ActivityDetails> getActivityDetails()
        {
            try
            {
                using (BillingReportContext context = new BillingReportContext())
                {
                    return context.TblReportActivity.Where(x => x.ReportId == 1).Select(x=> new ActivityDetails()
                                                                                {
                                                                                    milestones= x.Milestones,
                                                                                    eta= Convert.ToInt32(x.Eta)
                                                                                }
                    ).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("[action]")]
        public ReportSummery getReportSummeryDetails()
        {
            try
            {
                using (BillingReportContext context = new BillingReportContext())
                {

                    ReportSummery reportSummery = new ReportSummery();

                    reportSummery = (from RS in context.TblReportSummery
                                  join RSD in context.TblReportSummeryDetails on RS.ReportId equals RSD.ReportId
                                  where RS.ReportId == 21
                                  select new ReportSummery
                                  {
                                      clientName = RS.ClientName,
                                      projectName = RS.ProjectName,
                                      projectType = RS.ProjectType,
                                      accomp = RSD.Accomplishments,
                                      clientAwtInfo = RSD.ClientAwtInfo,
                                      onShoreTotalHrs = (int) RSD.OnshoreTotalHrs,
                                      onShoreHrsTillLastWeek = (int) RSD.OnshoreLastWeekHrs,
                                      onShoreHrsCurrentWeek = (int) RSD.OnshoreCurrentWeekHrs,
                                      offShoreTotalHrs = (int) RSD.OnshoreTotalHrs,
                                      offShoreHrsTillLastWeek = (int) RSD.OnshoreLastWeekHrs,
                                      offShoreHrsCurrentWeek = (int) RSD.OnshoreCurrentWeekHrs,
                                      notes = RSD.Notes
                                  }).SingleOrDefault();


                    return reportSummery;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [HttpPost("saveReportSummery")]
        public ActionResult saveReportSummery([FromBody]ReportSummery reportSummery)
        {
            try
            {
                using (BillingReportContext context = new BillingReportContext())
                {

                    TblReportSummery tblReportSummery = new TblReportSummery();

                    tblReportSummery.ClientName = reportSummery.clientName;
                    tblReportSummery.ProjectName = reportSummery.projectName;
                    tblReportSummery.ProjectType = reportSummery.projectType;
                    tblReportSummery.ReportStartDate = Convert.ToDateTime("2019-01-01");
                    tblReportSummery.ProjectEndDate = Convert.ToDateTime("2019-01-01");
                    tblReportSummery.CreatedBy = "Admin";
                    tblReportSummery.CreatedDate = DateTime.Now;
                    tblReportSummery.LastUpdatedBy = "Admin";
                    tblReportSummery.LastUpdatedDate = DateTime.Now;
                    tblReportSummery.ApprovedBy = "Admin";
                    tblReportSummery.ApprovedDate = DateTime.Now;
                    tblReportSummery.Remark = reportSummery.notes;
                    tblReportSummery.IsApproved = true;
                    tblReportSummery.ReportStatus = 4;

                    context.TblReportSummery.Add(tblReportSummery);
                    context.SaveChanges();

                    var report_id = tblReportSummery.ReportId;

                    TblReportSummeryDetails tblReportSummeryDetails = new TblReportSummeryDetails();

                    tblReportSummeryDetails.ReportId = report_id;
                    tblReportSummeryDetails.Crid = 1;
                    tblReportSummeryDetails.ActivityId = 1;
                    tblReportSummeryDetails.OnshoreTotalHrs = reportSummery.onShoreTotalHrs;
                    tblReportSummeryDetails.OnshoreLastWeekHrs = reportSummery.onShoreHrsTillLastWeek;
                    tblReportSummeryDetails.OnshoreCurrentWeekHrs = reportSummery.onShoreHrsCurrentWeek;
                    tblReportSummeryDetails.OffShoreTotalHrs = reportSummery.offShoreTotalHrs;
                    tblReportSummeryDetails.OffshoreLastWeekHrs = reportSummery.offShoreHrsTillLastWeek;
                    tblReportSummeryDetails.OffshoreCurrentWeekHrs = reportSummery.offShoreHrsCurrentWeek;
                    tblReportSummeryDetails.Accomplishments = reportSummery.accomp;
                    tblReportSummeryDetails.ClientAwtInfo = reportSummery.clientAwtInfo;
                    tblReportSummeryDetails.Notes = reportSummery.notes;

                    context.TblReportSummeryDetails.Add(tblReportSummeryDetails);
                    context.SaveChanges();

                     //first delete all existing record 

                    foreach (CRDetails cR in reportSummery.crDetails)
                    {
                        TblReportCr tblReportCr = new TblReportCr();

                        tblReportCr.ReportId = report_id;
                        tblReportCr.CrName = cR.crName;
                        tblReportCr.ActualHrs = cR.actualHrs;
                        tblReportCr.EstimateHrs = cR.estimateHrs;
                        tblReportCr.Status = Convert.ToInt16(cR.status);

                        context.TblReportCr.Add(tblReportCr);

                    }
                    context.SaveChanges();

                    //first delete all records
                    foreach (ActivityDetails AD in reportSummery.activityDetails)
                    {
                        TblReportActivity tblReportActivity = new TblReportActivity();

                        tblReportActivity.ReportId = report_id;
                        tblReportActivity.Milestones = AD.milestones;
                        tblReportActivity.Eta = AD.eta;

                        context.TblReportActivity.Add(tblReportActivity);

                    }
                    context.SaveChanges();

                    return Ok(); 
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}