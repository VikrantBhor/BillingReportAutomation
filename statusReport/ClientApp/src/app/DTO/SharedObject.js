"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SharedObject = /** @class */ (function () {
    function SharedObject(reportId, projectId, projectName, clientName, reportType, reportDate, reportStartDate, reportEndDate, createdByEmail, createdBy) {
        this.reportId = reportId;
        this.projectId = projectId;
        this.projectName = projectName;
        this.clientName = clientName;
        this.reportType = reportType;
        this.reportDate = reportDate;
        this.reportStartDate = reportStartDate;
        this.reportEndDate = reportEndDate;
        this.createdByEmail = createdByEmail;
        this.createdBy = createdBy;
    }
    return SharedObject;
}());
exports.SharedObject = SharedObject;
//# sourceMappingURL=SharedObject.js.map