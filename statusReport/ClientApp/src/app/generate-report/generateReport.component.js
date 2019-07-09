"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var docx_1 = require("docx");
var GenerateReport = /** @class */ (function () {
    function GenerateReport() {
    }
    GenerateReport.prototype.generateReport = function () {
        var docs = new docx_1.Document();
        docs.Styles.createParagraphStyle("heading1", "Heading 1").spacing({ before: 150, after: 120 }).size(40).bold().color('999989');
        docs.Styles.createParagraphStyle("title", "Title").spacing({ before: 150 }).size(50).bold();
        docs.Styles.createParagraphStyle("heading2", "Heading 2").spacing({ before: 150, after: 120 }).size(30).color('999980').bold();
        docs.Styles.createParagraphStyle("heading3", "Heading 3").spacing({ before: 150, after: 120 }).bold().center();
        docs.Styles.createParagraphStyle("heading5", "Heading 5").spacing({ before: 150, after: 120 }).bold().center();
        docs.addParagraph(new docx_1.Paragraph("Monthly Hours Summary Report").title().center());
        docs.addParagraph(this.createHeading("Name of Project")); //Name of Project
        docs.addParagraph(this.createHeading("Duration, start to End")); //Name of Project
        docs.addParagraph(this.createSubHeading("Project Type : T&M Upper cap"));
        docs.addParagraph(this.createSubHeading("Accomplishment :"));
        //for (let accomplishment of someArray) {
        //  docs.addParagraph(this.createBullet(accomplishment));
        //}
    };
    GenerateReport.prototype.createHeading = function (text) {
        return new docx_1.Paragraph(text).heading1().center();
    };
    GenerateReport.prototype.createSubHeading = function (text) {
        return new docx_1.Paragraph(text).heading2().left();
    };
    GenerateReport.prototype.splitParagraphIntoBullets = function (text) {
        return text.split("\n\n");
    };
    GenerateReport.prototype.createBullet = function (text) {
        return new docx_1.Paragraph(text).bullet();
    };
    return GenerateReport;
}());
exports.GenerateReport = GenerateReport;
//# sourceMappingURL=generateReport.component.js.map