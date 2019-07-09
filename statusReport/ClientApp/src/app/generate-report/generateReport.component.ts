import { Document, Paragraph, Packer, TextRun, WidthType, Border, Indent, Image, Media, ImageParagraph, Table } from "docx";
import { formatDate } from '@angular/common';
import * as fs from "fs";
import { reportCR } from "../DTO/ReportCR";
import { reportActivity } from "../DTO/ReportActivity";
import { ReportSummery } from "../DTO/ReportSummery";
import { type } from "os";

export class GenerateReport {
  reportType: string;
  generateReport(reportSummery: ReportSummery, reportCRDetails: reportCR[], reportActivityDetails: reportActivity[]) {
    const docs = new Document();
    //debugger;
    docs.Styles.createParagraphStyle("heading1", "Heading 1").spacing({ before: 150, after: 120 }).size(40).bold().color('999989');
    docs.Styles.createParagraphStyle("title", "Title").spacing({ before: 150 }).size(50).color('FF0000').bold().underline();
    docs.Styles.createParagraphStyle("heading2", "Heading 2").spacing({ before: 150, after: 120 }).size(30).color('000080').bold();
    docs.Styles.createParagraphStyle("heading3", "Heading 3").spacing({ before: 150, after: 120 }).bold().center();
    docs.Styles.createParagraphStyle("heading5", "Heading 5").spacing({ before: 150, after: 120 }).bold().center();

    if (reportSummery.projectType == "Month") {
      docs.addParagraph(new Paragraph("Monthly Hours Summary Report").title().center());
      this.reportType = "Month";
    }
    else {
      docs.addParagraph(new Paragraph("Weekly Hours Summary Report").title().center());
      this.reportType = "Week";
    }

    docs.addParagraph(this.createHeading("Name of Project")); //Name of Project
    docs.addParagraph(this.createHeading(new Date(reportSummery.reportStartDate).toDateString() + " - " + new Date(reportSummery.reportEndDate).toDateString())); //Start and end date of report

    docs.addParagraph(this.createSubHeading("Project Type : " + reportSummery.projectName));

    docs.addParagraph(this.createSubHeading("Accomplishment :"));
    for (let accomplishment of reportSummery.accomp.split('\n')) {
      for (let acc of accomplishment.split(',')) {
        if (acc != " ")
          docs.addParagraph(this.createBullet(acc));
      }
    }

    docs.addParagraph(this.createSubHeading("CR :"));
    docs.addTableOfContents(this.createTableCR(reportCRDetails));

    docs.addParagraph(this.createSubHeading("Activities due this/next week :"));
    docs.addTableOfContents(this.createTableActivities(reportActivityDetails));

    docs.addParagraph(this.createSubHeading("Awaiting information from client :"));
    for (let clientAwtInfo of reportSummery.clientAwtInfo.split('\n')) {
      for (let cAI of clientAwtInfo.split(',')) {
        if (cAI != " ")
          docs.addParagraph(this.createBullet(cAI));
      }
    }

    docs.addParagraph(this.createSubHeading("Billing :"));
    docs.addTableOfContents(this.createBillDetails(reportSummery));

    docs.addParagraph(this.createSubHeading("Notes :"));
    for (let notes of reportSummery.notes.split('\n')) {
      for (let note of notes.split(',')) {
        if (note != " ")
          docs.addParagraph(this.createBullet(note));
      }
    }

    return docs;
  }

  createTableCR(reportCRDetails) {
    if (reportCRDetails.length > 0) {
      const table = new Document().createTable(reportCRDetails.length + 1, 4).setWidth(WidthType.AUTO, "auto");
      table.getCell(0, 0).addContent(new Paragraph("CR").heading4());
      table.getCell(0, 1).addContent(new Paragraph("Estimates (Hrs)").heading4());
      table.getCell(0, 2).addContent(new Paragraph("Actual(Hrs)").heading4());
      table.getCell(0, 3).addContent(new Paragraph("Status").heading4());

      var i = 1;
      for (let cR of reportCRDetails) {
        debugger;
        table.getCell(i, 0).addContent(new Paragraph(cR.crName).heading5());
        table.getCell(i, 1).addContent(new Paragraph(cR.estimateHrs).heading5());
        table.getCell(i, 2).addContent(new Paragraph(cR.actualHrs).heading5());
        table.getCell(i, 3).addContent(new Paragraph(cR.status).heading5());
        i++;
      }
      return table;
    }
  }

  createTableActivities(reportActivityDetails) {
    if (reportActivityDetails.length > 0) {
      const table1 = new Document().createTable(reportActivityDetails.length + 1, 3).setWidth(WidthType.AUTO, "auto");
      table1.getCell(0, 0).addContent(new Paragraph("Sl. No.").heading4());
      table1.getCell(0, 1).addContent(new Paragraph("Milestone").heading4());
      table1.getCell(0, 2).addContent(new Paragraph("ETA").heading4());

      var i = 1;
      for (let rAD of reportActivityDetails) {
        table1.getCell(i, 0).addContent(new Paragraph(i.toString()).heading5());
        table1.getCell(i, 1).addContent(new Paragraph(rAD.milestones).heading5());
        table1.getCell(i, 2).addContent(new Paragraph(rAD.eta).heading5());
        i++;
      }
      return table1;
    }
  }

  createBillDetails(reportSummery) {
    const table2 = new Document().createTable(11, 2).setWidth(WidthType.AUTO, "auto");

    table2.getCell(0, 0).addContent(new Paragraph("Activities").heading3());
    table2.getCell(0, 1).addContent(new Paragraph("Duration (in hrs.)").heading5());
    table2.getCell(1, 0).addContent(new Paragraph("Total On-Shore Hours").heading3());
    table2.getCell(1, 1).addContent(new Paragraph(reportSummery.onShoreTotalHrs).heading3());
    table2.getCell(2, 0).addContent(this.createBullet("On-Shore Hours Till Last" + this.reportType));
    table2.getCell(2, 1).addContent(new Paragraph(reportSummery.onShoreHrsTillLastWeek).heading5());
    table2.getCell(3, 0).addContent(this.createBullet("On-Shore Hours This" + this.reportType));
    table2.getCell(3, 1).addContent(new Paragraph(reportSummery.onShoreHrsCurrentWeek).heading5());
    table2.getCell(4, 0).addContent(new Paragraph("Total On-Shore Hours Utilized").heading3());
    table2.getCell(4, 1).addContent(new Paragraph(reportSummery.onShoreHrsTillLastWeek + reportSummery.onShoreHrsCurrentWeek).heading5());
    //table2.getCell(5, 0).addContent(new Paragraph("Total On-Shore Hours Remaining").heading3());
    //table2.getCell(5, 1).addContent(new Paragraph("640.75 – 940.75").heading5());
    table2.getCell(6, 0).addContent(new Paragraph("Total On-Shore Hours").heading3());
    table2.getCell(6, 1).addContent(new Paragraph(reportSummery.onShoreTotalHrs).heading3());
    table2.getCell(7, 0).addContent(this.createBullet("On-Shore Hours Till Last" + this.reportType));
    table2.getCell(7, 1).addContent(new Paragraph(reportSummery.onShoreHrsTillLastWeek).heading5());
    table2.getCell(8, 0).addContent(this.createBullet("On-Shore Hours This" + this.reportType));
    table2.getCell(8, 1).addContent(new Paragraph(reportSummery.onShoreHrsCurrentWeek).heading5());
    table2.getCell(9, 0).addContent(new Paragraph("Total On-Shore Hours Utilized").heading3());
    table2.getCell(9, 1).addContent(new Paragraph(reportSummery.onShoreHrsTillLastWeek + reportSummery.onShoreHrsCurrentWeek).heading5());
    //table2.getCell(10, 0).addContent(new Paragraph("Total On-Shore Hours Remaining").heading3());
    //table2.getCell(10, 1).addContent(new Paragraph("640.75 – 940.75").heading5());

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
