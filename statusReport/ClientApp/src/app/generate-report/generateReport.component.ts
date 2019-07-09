import { Document, Paragraph, Packer, TextRun, WidthType, Border, Indent, Image, Media, ImageParagraph, Table } from "docx";
import { formatDate } from '@angular/common';
import * as fs from "fs";
import { reportCR } from "../DTO/ReportCR";
import { reportActivity } from "../DTO/ReportActivity";
import { ReportSummery } from "../DTO/ReportSummery";

export class GenerateReport {
  generateReport(reportSummery: ReportSummery,reportCRDetails: reportCR[], reportActivityDetails: reportActivity[]) {
    const docs = new Document();

    debugger;
    docs.Styles.createParagraphStyle("heading1", "Heading 1").spacing({ before: 150, after: 120 }).size(40).bold().color('999989');
    docs.Styles.createParagraphStyle("title", "Title").spacing({ before: 150 }).size(50).bold();
    docs.Styles.createParagraphStyle("heading2", "Heading 2").spacing({ before: 150, after: 120 }).size(30).color('999980').bold();
    docs.Styles.createParagraphStyle("heading3", "Heading 3").spacing({ before: 150, after: 120 }).bold().center();
    docs.Styles.createParagraphStyle("heading5", "Heading 5").spacing({ before: 150, after: 120 }).bold().center();

    docs.addParagraph(new Paragraph("Monthly Hours Summary Report").title().center());
    docs.addParagraph(this.createHeading("Name of Project")); //Name of Project
    docs.addParagraph(this.createHeading(  " - ")); //Start and end date of report

    docs.addParagraph(this.createSubHeading("Project Type : T&M Upper cap")); 

    docs.addParagraph(this.createSubHeading("Accomplishment :"));
    //for (let accomplishment of someArray) {
    //  docs.addParagraph(this.createBullet(accomplishment));
    //}
    docs.addParagraph(this.createBullet("Phase III requirement analysis "));
    docs.addParagraph(this.createBullet("Phase III Desgn"));
    docs.addParagraph(this.createBullet("Power BI research"));
    docs.addParagraph(this.createBullet("Chart research"));

    docs.addParagraph(this.createSubHeading("CR :"));
    docs.addTableOfContents(this.createTableCR(reportCRDetails));

    docs.addParagraph(this.createSubHeading("Activities due this/next week:"));
    docs.addTableOfContents(this.createTableActivities(reportActivityDetails));

    docs.addParagraph(this.createSubHeading("Awaiting information from client:"));
    //for (let accomplishment of someArray) {
    //  docs.addParagraph(this.createBullet(accomplishment));
    //}

    docs.addParagraph(this.createSubHeading("Billing:"));
    docs.addTableOfContents(this.createBillDetails(reportSummery));

    docs.addParagraph(this.createSubHeading("Notes:"));
    //for (let accomplishment of someArray) {
    //  docs.addParagraph(this.createBullet(accomplishment));
    //}

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
        i ++;
      }
      return table1;
    }
  }

  createBillDetails(reportSummery) {
    const table2 = new Document().createTable(7, 2).setWidth(WidthType.AUTO, "auto");
    table2.getCell(0, 0).addContent(new Paragraph("Activities").heading3());
    table2.getCell(0, 1).addContent(new Paragraph("Duration (in hrs.)").heading5());
    table2.getCell(1, 0).addContent(new Paragraph("Total On-Shore Hours ").heading3());
    table2.getCell(1, 1).addContent(new Paragraph(reportSummery.onShoreTotalHrs).heading3());
    table2.getCell(2, 0).addContent(new Paragraph("On-Shore Hours Till Last Week").heading3());
    table2.getCell(2, 1).addContent(new Paragraph(reportSummery.onShoreHrsTillLastWeek).heading3());
    table2.getCell(3, 0).addContent(new Paragraph("On-Shore Hours This Week").heading3());
    table2.getCell(3, 1).addContent(new Paragraph(reportSummery.onShoreHrsCurrentWeek).heading3());
    table2.getCell(4, 0).addContent(new Paragraph("Total Off-Shore Hours ").heading3());
    table2.getCell(4, 1).addContent(new Paragraph(reportSummery.offShoreTotalHrs).heading3());
    table2.getCell(5, 0).addContent(new Paragraph("Off-Shore Hours Till Last Week").heading3());
    table2.getCell(5, 1).addContent(new Paragraph(reportSummery.offShoreHrsTillLastWeek).heading3());
    table2.getCell(6, 0).addContent(new Paragraph("Off-Shore Hours This Week").heading3());
    table2.getCell(6, 1).addContent(new Paragraph(reportSummery.offShoreHrsCurrentWeek).heading3());
    
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
