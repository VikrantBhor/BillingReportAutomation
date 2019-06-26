using Microsoft.AspNetCore.Mvc;
using statusReport.BillingDBModels;
using statusReport.DTO;
using statusReport.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using statusReport.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace statusReport.Controllers
{
    [Route("api/[controller]")]
    public class ReportSummeryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getCRDetails/{id}")]
        public IEnumerable<CRDetails> getCRDetails(int id)
        {
            try
            {
                using (BillingReportContext context = new BillingReportContext())
                {
                    return context.TblReportCr.Where(x => x.ReportId == id).Select(x => new CRDetails()
                    { crName = x.CrName,
                        estimateHrs = (int)x.EstimateHrs,
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

        [HttpGet]
        [Route("getActivityDetails/{id}")]
        public IEnumerable<ActivityDetails> getActivityDetails(int id)
        {
            try
            {
                using (BillingReportContext context = new BillingReportContext())
                {
                    return context.TblReportActivity.Where(x => x.ReportId == id).Select(x => new ActivityDetails()
                    {
                        milestones = x.Milestones,
                        eta = Convert.ToInt32(x.Eta)
                    }
                    ).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("getReportSummeryDetails/{id}")]
        public ReportSummery getReportSummeryDetails(int id)
        {
            try
            {
                using (BillingReportContext context = new BillingReportContext())
                {

                    ReportSummery reportSummery = new ReportSummery();

                    reportSummery = (from RS in context.TblReportSummery
                                     join RSD in context.TblReportSummeryDetails on RS.ReportId equals RSD.ReportId
                                     where RS.ReportId == id
                                     select new ReportSummery
                                     {
                                         clientName = RS.ClientName,
                                         projectName = RS.ProjectName,
                                         projectType = RS.ProjectType,
                                         accomp = RSD.Accomplishments,
                                         clientAwtInfo = RSD.ClientAwtInfo,
                                         onShoreTotalHrs = (int)RSD.OnshoreTotalHrs,
                                         onShoreHrsTillLastWeek = (int)RSD.OnshoreLastWeekHrs,
                                         onShoreHrsCurrentWeek = (int)RSD.OnshoreCurrentWeekHrs,
                                         offShoreTotalHrs = (int)RSD.OnshoreTotalHrs,
                                         offShoreHrsTillLastWeek = (int)RSD.OnshoreLastWeekHrs,
                                         offShoreHrsCurrentWeek = (int)RSD.OnshoreCurrentWeekHrs,
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

                    if (reportSummery.id == 0)
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
                    else
                    {
                        //code for update

                        TblReportSummery tblReportSummery = context.TblReportSummery.SingleOrDefault(x => x.ReportId == reportSummery.id);

                        if (tblReportSummery != null)
                        {
                            tblReportSummery.ClientName = reportSummery.clientName;
                            tblReportSummery.ProjectName = reportSummery.projectName;
                            tblReportSummery.ProjectType = reportSummery.projectType;
                            tblReportSummery.ReportStartDate = Convert.ToDateTime("2019-01-01");
                            tblReportSummery.ProjectEndDate = Convert.ToDateTime("2019-01-01");
                            tblReportSummery.CreatedBy = "UpdateAdmin";
                            tblReportSummery.CreatedDate = DateTime.Now;
                            tblReportSummery.LastUpdatedBy = "UpdateAdmin";
                            tblReportSummery.LastUpdatedDate = DateTime.Now;
                            tblReportSummery.ApprovedBy = "UpdateAdmin";
                            tblReportSummery.ApprovedDate = DateTime.Now;
                            tblReportSummery.Remark = reportSummery.notes;
                            tblReportSummery.IsApproved = true;
                            tblReportSummery.ReportStatus = 4;

                            context.SaveChanges();
                        }

                        TblReportSummeryDetails tblReportSummeryDetails = context.TblReportSummeryDetails.SingleOrDefault(x => x.ReportId == reportSummery.id);

                        if (tblReportSummeryDetails != null)
                        {
                            ///tblReportSummeryDetails.ReportId = report_id;
                            tblReportSummeryDetails.Crid = 1;
                            tblReportSummeryDetails.ActivityId = 1;
                            tblReportSummeryDetails.OnshoreTotalHrs = 1000;
                            tblReportSummeryDetails.OnshoreLastWeekHrs = reportSummery.onShoreHrsTillLastWeek;
                            tblReportSummeryDetails.OnshoreCurrentWeekHrs = 1000;
                            tblReportSummeryDetails.OffShoreTotalHrs = reportSummery.offShoreTotalHrs;
                            tblReportSummeryDetails.OffshoreLastWeekHrs = 1000;
                            tblReportSummeryDetails.OffshoreCurrentWeekHrs = 1000;
                            tblReportSummeryDetails.Accomplishments = reportSummery.accomp;
                            tblReportSummeryDetails.ClientAwtInfo = reportSummery.clientAwtInfo;
                            tblReportSummeryDetails.Notes = reportSummery.notes;

                            context.SaveChanges();
                        }

                        //delete existing entry
                        // db.ProRel.RemoveRange(db.ProRel.Where(c => c.ProjectId == Project_id));
                        context.TblReportCr.RemoveRange(context.TblReportCr.Where(x => x.ReportId == reportSummery.id));

                        foreach (CRDetails cR in reportSummery.crDetails)
                        {
                            TblReportCr tblReportCr = new TblReportCr();

                            tblReportCr.ReportId = reportSummery.id;
                            tblReportCr.CrName = cR.crName;
                            tblReportCr.ActualHrs = cR.actualHrs;
                            tblReportCr.EstimateHrs = cR.estimateHrs;
                            tblReportCr.Status = Convert.ToInt16(cR.status);

                            context.TblReportCr.Add(tblReportCr);

                        }
                        context.SaveChanges();

                        //delete existing entry
                        context.TblReportActivity.RemoveRange(context.TblReportActivity.Where(x => x.ReportId == reportSummery.id));

                        foreach (ActivityDetails AD in reportSummery.activityDetails)
                        {
                            TblReportActivity tblReportActivity = new TblReportActivity();

                            tblReportActivity.ReportId = reportSummery.id;
                            tblReportActivity.Milestones = AD.milestones;
                            tblReportActivity.Eta = AD.eta;

                            context.TblReportActivity.Add(tblReportActivity);

                        }
                        context.SaveChanges();

                        return Ok();
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        [Route("rejectReport/{id}/{remark}")]
        public async Task<IActionResult> RejectReport([FromRoute]int id, [FromRoute] string remark)
        {
            using (BillingReportContext context = new BillingReportContext())
            {
                var report = context.TblReportSummery.Where(i => i.ReportId == id).FirstOrDefault();
                report.ReportStatus = Convert.ToInt32(ReportStatus.Rejected);
                report.Remark = remark;
                context.TblReportSummery.Update(report);
                await context.SaveChangesAsync();

            }
            return Ok();
        }



        [HttpGet]
        [Route("GetComments/{id}")]
        public IEnumerable<userCommends> GetComments( string id)
        {
            try
            {
                List<userCommends> userCommnets = new List<userCommends>();

                using (actitimeContext actitimeContext = HttpContext.RequestServices.GetService(typeof(statusReport.Models.actitimeContext)) as actitimeContext)
                {
                    using (MySqlConnection conn = actitimeContext.GetConnection())
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand(" select* from actitime.user_task_comment where user_id in (select user_id from actitime.user_project where project_id =" + Convert.ToInt32(id) +  ") and task_id in (select id from actitime.task where project_id = " + Convert.ToInt32(id) +")", conn);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        DataTable data = reader.GetSchemaTable();

                        while (reader.Read())
                        {
                           // userCommnets.Add("test");
                        }

                    }

                        return userCommnets;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpGet]
        [Route("getActiTimeHrs/{id}")]
        public int getActiTimeHrs(int id)
        {
            try
            {
                List<string> userCommnets = new List<string>();

                using (actitimeContext actitimeContext = HttpContext.RequestServices.GetService(typeof(statusReport.Models.actitimeContext)) as actitimeContext)
                {
                    using (MySqlConnection conn = actitimeContext.GetConnection())
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("select * from actitime.tt_record where user_id in (select user_id from actitime.user_project where project_id =" + Convert.ToInt32(id) + ") and task_id in (select id from actitime.task where project_id = " + Convert.ToInt32(id) + ")", conn);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        DataTable data = reader.GetSchemaTable();

                        while (reader.Read())
                        {
                            // userCommnets.Add("test");
                        }

                    }

                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}