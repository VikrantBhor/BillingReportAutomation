import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { reportCR } from '../DTO/ReportCR';
import { Observable } from 'rxjs';
import { Response } from '@angular/http';
import { reportList } from '../DTO/ReportList';
import { ReportSummery } from '../DTO/ReportSummery';
import { reportActivity } from '../DTO/ReportActivity';
import { IClientList, IProgramList } from '../DTO/ClientInfo';
import { IReportDetail } from '../../app/DTO/ReportSummery';
import { formatDate } from '@angular/common';



@Injectable({
  providedIn: 'root'
})
export class ReportService {
  Baseurl: string;
  reportCRList: reportCR[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.Baseurl = baseUrl;
  }

  //need to pass reportID
  getCRdetails(reportId: number): Observable<reportCR[]> {
    //debugger;
    return this.http.get<reportCR[]>(this.Baseurl + 'api/ReportSummery/getCRDetails/' + reportId);
  }

  //need to pass reportID
  getActivitydetails(reportId: number): Observable<reportActivity[]> {
    return this.http.get<reportActivity[]>(this.Baseurl + 'api/ReportSummery/getActivityDetails/' + reportId);
  }

  getReportSummeryDetails(reportId: number): Observable<ReportSummery> {
    //debugger;
    return this.http.get<ReportSummery>(this.Baseurl + 'api/ReportSummery/getReportSummeryDetails/' + reportId);
  }


  saveReportDetails(reportSummery: ReportSummery): Observable<any> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    let options = {
      headers: headers
    }; 
    return this.http.post(this.Baseurl + 'api/ReportSummery/saveReportSummery', reportSummery, options);
  } 

  getClientList(): Observable<IClientList[]> {
    return this.http.get<IClientList[]>(this.Baseurl + 'api/Report/GetClientList');
  }
  getReports(role,reportStatus): Observable<reportList[]> {
    return this.http.get<reportList[]>(this.Baseurl + 'api/Report/reportStatus/' + role + '/' + reportStatus);
  }

  getweekComments(projectId, reportDate): Observable<string> {
    return this.http.get<string>(this.Baseurl + 'api/ReportSummery/GetWeekComments/' + projectId + '/' + reportDate);
  }

  getMonthComments(projectId, reportDate): Observable<string> {
    return this.http.get<string>(this.Baseurl + 'api/ReportSummery/GetMonthComments/' + projectId + '/' + reportDate);
  }

  getcurrentWkHrs(projectId, reportDate): Observable<number> {
    return this.http.get<number>(this.Baseurl + 'api/ReportSummery/getCurrentWeekHrs/' + projectId + '/' + reportDate);
  }

  getLastWkHrs(projectId, reportDate): Observable<number> {
    return this.http.get<number>(this.Baseurl + 'api/ReportSummery/getLastWeekHrs/' + projectId + '/' + reportDate);
  }

  getcurrentMonthHrs(projectId, reportDate): Observable<number> {
    return this.http.get<number>(this.Baseurl + 'api/ReportSummery/getCurrentMonthHrs/' + projectId + '/' + reportDate);
  }

  getLastMonthHrs(projectId, reportDate): Observable<number> {
    return this.http.get<number>(this.Baseurl + 'api/ReportSummery/getLastMonthHrs/' + projectId + '/' + reportDate);
  }


  rejectReport(id, remark): Observable<void> {
    debugger;
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    let options = {
      headers: headers
    };
    //const formData: FormData = new FormData();
    //formData.append('remark', remark);
    return this.http.put<void>(`${this.Baseurl}/api/ReportSummery/rejectReport/${ id }/${remark}`,options);
  }
  getProgramType(id): Observable<IProgramList[]> {
    return this.http.get<IProgramList[]>(this.Baseurl + 'api/Report/GetProgramType/' + id);
  }

  saveReport(reportDetail: IReportDetail): Observable<any> {
    debugger;
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    let options = {
      headers: headers
    };
    return this.http.post(this.Baseurl + 'api/Report/SaveReportDetails',reportDetail,options);    
  } 
}
