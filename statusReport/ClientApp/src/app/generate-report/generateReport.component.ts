import { Document, Paragraph, Packer, TextRun, WidthType, Border, Indent, Image, Media, ImageParagraph, Table } from "docx";
import { formatDate } from '@angular/common';
import * as fs from "fs";
import { reportCR } from "../DTO/ReportCR";
import { reportActivity } from "../DTO/ReportActivity";
import { ReportSummery } from "../DTO/ReportSummery";
import { type } from "os";

export class GenerateReport {
  reportType: string;
  onShoreHoursUtilized: number;
  offShoreHoursUtilized: number;
  onShoreHoursRemaining: number;
  offShoreHoursRemaining: number;
  date: number;
  month: string;

  generateReport(reportSummery: ReportSummery, reportCRDetails: reportCR[], reportActivityDetails: reportActivity[]) {
    const docs = new Document();
    debugger;
    docs.Styles.createParagraphStyle("heading1", "Heading 1").spacing({ before: 150, after: 120 }).size(40).bold().color('999989').font('Segoe');
    docs.Styles.createParagraphStyle("title", "Title").spacing({ before: 150 }).size(50).color('FF0000').bold().underline().font('Segoe');
    docs.Styles.createParagraphStyle("heading2", "Heading 2").spacing({ before: 150, after: 120 }).size(30).color('000080').bold().font('Segoe');
    docs.Styles.createParagraphStyle("heading3", "Heading 3").spacing({ before: 150, after: 120 }).bold().center().font('Segoe');
    docs.Styles.createParagraphStyle("heading5", "Heading 5").spacing({ before: 150, after: 120 }).bold().center().font('Segoe');
    docs.Styles.createParagraphStyle("heading6", "Heading 6").spacing({ before: 150, after: 120 }).left().font('Segoe');

    if (reportSummery.projectType == "Month") {
      docs.addParagraph(new Paragraph("Monthly Summary Report").title().center());
      this.reportType = "Month";
    }
    else {
      docs.addParagraph(new Paragraph("Weekly Summary Report").title().center());
      this.reportType = "Week";
    }

    docs.addParagraph(this.createHeading(reportSummery.clientName +" - "+ reportSummery.projectName).style("123")); //Name of Project
    docs.addParagraph(this.createHeading(new Date(reportSummery.reportStartDate).toDateString().substring(4) + " - " + new Date(reportSummery.reportEndDate).toDateString().substring(4))); //Start and end date of report

    docs.addParagraph(this.createSubHeading("Project Type : " + reportSummery.type));

    if (reportSummery.accomp != null) {
      docs.addParagraph(this.createSubHeading("Accomplishment :"));
      for (let accomplishment of reportSummery.accomp.split('\n')) {
        for (let acc of accomplishment.split(',')) {
          if (acc.length != 0)
            docs.addParagraph(this.createBullet(acc).heading6());
        }
      }
    }

    if (reportCRDetails.length != 0) {
      docs.addParagraph(this.createSubHeading("CR :"));
      docs.addTableOfContents(this.createTableCR(reportCRDetails));
    }

    if (reportActivityDetails.length != 0) {
      docs.addParagraph(this.createSubHeading("Activities due this/next week :"));
      docs.addTableOfContents(this.createTableActivities(reportActivityDetails));
    }

    if (reportSummery.clientAwtInfo != "") {
      docs.addParagraph(this.createSubHeading("Awaiting information from client :"));
      for (let clientAwtInfo of reportSummery.clientAwtInfo.split('\n')) {
        for (let cAI of clientAwtInfo.split(',')) {
          if (cAI.length != 0)
            docs.addParagraph(this.createBullet(cAI).heading6());
        }
      }
    }

    docs.addParagraph(this.createSubHeading("Billing :"));
    docs.addTableOfContents(this.createBillDetails(reportSummery));

    if (reportSummery.notes != "") {
      docs.addParagraph(this.createSubHeading("Notes :"));
      for (let notes of reportSummery.notes.split('\n')) {
        for (let note of notes.split(',')) {
          if (note.length != 0)
            docs.addParagraph(this.createBullet(note).heading6());
        }
      }
    }

    return docs;
  }

  createTableCR(reportCRDetails) {
    if (reportCRDetails.length > 0) {
      const table = new Document().createTable(reportCRDetails.length + 1, 4).setWidth(WidthType.PERCENTAGE, "100%");
      table.getCell(0, 0).addContent(new Paragraph("CR").heading3().center());
      table.getCell(0, 1).addContent(new Paragraph("Estimates (Hrs)").heading3().center());
      table.getCell(0, 2).addContent(new Paragraph("Actual(Hrs)").heading3().center());
      table.getCell(0, 3).addContent(new Paragraph("Status").heading3().center());

      var i = 1;
      for (let cR of reportCRDetails) {
        table.getCell(i, 0).addContent(new Paragraph(cR.crName).heading6().left());
        table.getCell(i, 1).addContent(new Paragraph(cR.estimateHrs).heading6().center());
        table.getCell(i, 2).addContent(new Paragraph(cR.actualHrs).heading6().center());
        table.getCell(i, 3).addContent(new Paragraph(cR.status).heading6().center());
        i++;
      }
      return table;
    }
  }

  createTableActivities(reportActivityDetails) {
    if (reportActivityDetails.length > 0) {
      const table1 = new Document().createTable(reportActivityDetails.length + 1, 3).setWidth(WidthType.PERCENTAGE, "100%");
      table1.getCell(0, 0).addContent(new Paragraph("Sl. No.").heading3().center());
      table1.getCell(0, 1).addContent(new Paragraph("Milestone").heading3().center());
      table1.getCell(0, 2).addContent(new Paragraph("ETA").heading3().center());

      var i = 1;
      for (let rAD of reportActivityDetails) {
        table1.getCell(i, 0).addContent(new Paragraph(i.toString()).heading6().center());
        table1.getCell(i, 1).addContent(new Paragraph(rAD.milestones).heading6().left());
        table1.getCell(i, 2).addContent(new Paragraph(rAD.eta).heading6().center());
        i++;
      }
      return table1;
    }
  }

  createBillDetails(reportSummery) {
    const table2 = new Document().createTable(9, 2).setWidth(WidthType.PERCENTAGE, "100%");

    debugger;
    const monthNames = ["January", "February", "March", "April", "May", "June",
      "July", "August", "September", "October", "November", "December"
    ];

    this.onShoreHoursUtilized = reportSummery.onShoreHrsTillLastWeek + reportSummery.onShoreHrsCurrentWeek;
    this.offShoreHoursUtilized = reportSummery.offShoreHrsTillLastWeek + reportSummery.offShoreHrsCurrentWeek;
    this.onShoreHoursRemaining = reportSummery.onShoreTotalHrs - (this.onShoreHoursUtilized + this.offShoreHoursUtilized);
    this.offShoreHoursRemaining = this.onShoreHoursRemaining; //reportSummery.offShoreTotalHrs - this.offShoreHoursUtilized;

    reportSummery.onShoreHrsTillLastWeek = reportSummery.onShoreHrsTillLastWeek == "" ? 0 : reportSummery.onShoreHrsTillLastWeek;
    reportSummery.onShoreHrsCurrentWeek = reportSummery.onShoreHrsCurrentWeek == "" ? 0 : reportSummery.onShoreHrsCurrentWeek;
    reportSummery.offShoreHrsTillLastWeek = reportSummery.offShoreHrsTillLastWeek == "" ? 0 : reportSummery.offShoreHrsTillLastWeek;
    reportSummery.offShoreHrsTillLastWeek = reportSummery.offShoreHrsTillLastWeek == "" ? 0 : reportSummery.offShoreHrsTillLastWeek;

    if (new Date(reportSummery.reportStartDate).getDate() - 1 == 0) {
      this.month = monthNames[new Date(reportSummery.reportStartDate).getMonth() - 1] == undefined ? monthNames[11] : monthNames[new Date(reportSummery.reportStartDate).getMonth() - 1];
      this.date = new Date(new Date(reportSummery.reportStartDate).getFullYear(), new Date(reportSummery.reportStartDate).getMonth(), 0).getDate();
    }
    else {
      this.month = monthNames[new Date(reportSummery.reportStartDate).getMonth()] ;
      this.date = (new Date(reportSummery.reportStartDate).getDate() - 1);
    }

    table2.getCell(0, 0).addContent(new Paragraph("Activities").heading3());
    table2.getCell(0, 1).addContent(new Paragraph("Duration (in hrs.)").heading5());
    table2.getCell(1, 0).addContent(new Paragraph("Total Budget Hours").heading3().left());
    table2.getCell(1, 1).addContent(new Paragraph(reportSummery.onShoreTotalHrs).heading3());
    table2.getCell(2, 0).addContent(this.createBullet("On-Shore Hours Till " + this.date + " " + this.month).heading6());
    table2.getCell(2, 1).addContent(new Paragraph(reportSummery.onShoreHrsTillLastWeek.toString()).heading5());
    table2.getCell(3, 0).addContent(this.createBullet("On-Shore Hours from " + new Date(reportSummery.reportStartDate).getDate() + " " + monthNames[new Date(reportSummery.reportStartDate).getMonth()] + " to " + new Date(reportSummery.reportEndDate).getDate() + " " + monthNames[new Date(reportSummery.reportEndDate).getMonth()]).heading6());
    table2.getCell(3, 1).addContent(new Paragraph(reportSummery.onShoreHrsCurrentWeek.toString()).heading5());
    table2.getCell(4, 0).addContent(new Paragraph("Total On-Shore Hours Utilized").heading3().left());
    table2.getCell(4, 1).addContent(new Paragraph(this.onShoreHoursUtilized.toString()).heading5());
    //table2.getCell(5, 0).addContent(new Paragraph("Total On-Shore Hours Remaining").heading3().left());
    //table2.getCell(5, 1).addContent(new Paragraph(this.onShoreHoursRemaining.toString()).heading5());
    //table2.getCell(5, 0).addContent(new Paragraph("Total Off-Shore Hours").heading3().left());
    //table2.getCell(5, 1).addContent(new Paragraph(reportSummery.onShoreTotalHrs).heading3());
    table2.getCell(5, 0).addContent(this.createBullet("Off-Shore Hours Till " + + this.date + " " + this.month).heading6());
    table2.getCell(5, 1).addContent(new Paragraph(reportSummery.offShoreHrsTillLastWeek.toString()).heading5());
    table2.getCell(6, 0).addContent(this.createBullet("Off-Shore Hours from " + new Date(reportSummery.reportStartDate).getDate() + " " + monthNames[new Date(reportSummery.reportStartDate).getMonth()] + " to " + new Date(reportSummery.reportEndDate).getDate() + " " + monthNames[new Date(reportSummery.reportEndDate).getMonth()]).heading6());
    table2.getCell(6, 1).addContent(new Paragraph(reportSummery.offShoreHrsCurrentWeek.toString()).heading5());
    table2.getCell(7, 0).addContent(new Paragraph("Total Off-Shore Hours Utilized").heading3().left());
    table2.getCell(7, 1).addContent(new Paragraph(this.offShoreHoursUtilized.toString()).heading5());
    table2.getCell(8, 0).addContent(new Paragraph("Total Off-Shore Hours Remaining").heading3().left());
    table2.getCell(8, 1).addContent(new Paragraph(this.onShoreHoursRemaining.toString()).heading5());

    return table2;
  }

  createHeading(text) {
    return new Paragraph(text).heading1().center();
  }
  createSubHeading(text) {
    return new Paragraph(text).heading2().left();
  }

  splitParagraphIntoBullets(text) {
    return text.split("\n\n");
  }
  createBullet(text) {
    return new Paragraph(text).bullet();
  }
}
