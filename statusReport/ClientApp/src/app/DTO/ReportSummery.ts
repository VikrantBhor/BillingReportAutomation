import { reportCR } from "./ReportCR";
import { reportActivity } from "./ReportActivity";

export interface ReportSummery {
  id: number,
  clientName: string,
  projectName: string,
  projectType: string,
  accomp: string,
  crDetails: reportCR[], 
  activityDetails: reportActivity[],  
  clientAwtInfo: string,
  onShoreTotalHrs: number,
  onShoreHrsTillLastWeek: number,
  onShoreHrsCurrentWeek: number,
  offShoreTotalHrs: number,
  offShoreHrsTillLastWeek: number,
  offShoreHrsCurrentWeek: number,
  notes: string
}
export interface IReportDetail {
  ClientName: string;
  ProjectName: string;
  ProjectType: string;
  ReportStartDate: string;
  ReportEndDate: string;
  CreatedBy: string;
  CreatedByEmail: string;
  ReportStatus: number;
}
