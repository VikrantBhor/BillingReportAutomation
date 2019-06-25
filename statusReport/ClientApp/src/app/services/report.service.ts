import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { reportCR } from '../DTO/ReportCR';
import { Observable } from 'rxjs';
import { Response } from '@angular/http';
import { reportList } from '../DTO/ReportList';
import { ReportSummery } from '../DTO/ReportSummery';
import { reportActivity } from '../DTO/ReportActivity';
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

  getReports(role,reportStatus): Observable<reportList[]> {
    return this.http.get<reportList[]>(this.Baseurl + 'api/Report/reportStatus/' + role + '/' + reportStatus);
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
}
