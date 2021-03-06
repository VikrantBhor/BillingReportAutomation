import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { reportCR } from '../DTO/ReportCR';
import { Observable } from 'rxjs';
import { Response, RequestOptions, URLSearchParams } from '@angular/http';
import { reportList } from '../DTO/ReportList';
import { ReportSummery } from '../DTO/ReportSummery';
import { reportActivity } from '../DTO/ReportActivity';
import { IClientList, IProgramList } from '../DTO/ClientInfo';
import { IReportDetail } from '../../app/DTO/ReportSummery';
import { formatDate } from '@angular/common';
import { Options } from 'selenium-webdriver';
import { Http } from '@angular/http';
import { type } from 'os';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  Baseurl: string;
  reportCRList: reportCR[];
  form: string;
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
    debugger;
    return this.http.post(this.Baseurl + 'api/ReportSummery/saveReportSummery', reportSummery, options);
  }


  draftReportDetails(reportSummery: ReportSummery): Observable<any> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    let options = {
      headers: headers
    };
    debugger;
    return this.http.post(this.Baseurl + 'api/ReportSummery/draftReportSummery', reportSummery, options);
  } 

  postData(formData): Observable<any> {
    //let headers = new HttpHeaders({
    //  'Content-Type': 'application/json',
    //  'Accept': 'application/json',
    //  'Access-Control-Allow-Headers': 'Content-Type'
    //});
    //let options = {
    //  headers: headers
    //};
    let hdrs = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': 'POST',
      'Access-Control-Allow-Headers': 'X-Requested-With,Content-Type',
      'Access-Control-Allow-Credentials':'true'
    });
    //let headers = {
    //  headers: new HttpHeaders({
    //    'Content-Type': 'application/json'
    //  })
    //};

    var value = "Val";
    this.form = formData.data;
    //let body = JSON.stringify({ formData }); 
    debugger;
    return this.http.post('http://billingauto.atidanmumbai.com:2142/api/UploadReport/Post/', formData, { headers: hdrs });
    //return this.http.post('http://localhost:2142/api/UploadReport/Post/', formData, { headers: hdrs });
    
  } 

  getClientList(): Observable<IClientList[]> {
    return this.http.get<IClientList[]>(this.Baseurl + 'api/Report/GetClientList');
  }

  getReports(role, reportStatus, userEmail): Observable<reportList[]> {
    return this.http.get<reportList[]>(this.Baseurl + 'api/Report/reportStatus/' + role + '/' + reportStatus + '/' + userEmail);
  }

  getweekComments(projectId, reportDate, clientId): Observable<string> {
    return this.http.get<string>(this.Baseurl + 'api/ReportSummery/GetWeekComments/' + projectId + '/' + reportDate + '/' + clientId);
  }

  getMonthComments(projectId, reportDate,clientId): Observable<string> {
    return this.http.get<string>(this.Baseurl + 'api/ReportSummery/GetMonthComments/' + projectId + '/' + reportDate + '/' + clientId);
  }

  getcurrentWkHrs(projectId, reportDate): Observable<number> {
    return this.http.get<number>(this.Baseurl + 'api/ReportSummery/getCurrentWeekHrs/' + projectId + '/' + reportDate);
  }

  getLastWkHrs(projectId, reportDate, type): Observable<number> {
    return this.http.get<number>(this.Baseurl + 'api/ReportSummery/getLastWeekHrs/' + projectId + '/' + reportDate + '/' + type);
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
    return this.http.get<void>(this.Baseurl + '/api/ReportSummery/rejectReport/' + id +'/'+ remark);
  }

  changeStatus(id): Observable<void> {
    debugger;
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    let options = {
      headers: headers
    };
    return this.http.get<void>(this.Baseurl+ 'api/ReportSummery/changeStatus/' +id);
  }

  uploadReport(id): Observable<void> {
    debugger;
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    let options = {
      headers: headers
    };
    return this.http.get<void>(this.Baseurl + 'api/ReportSummery/uploadReport/' + id);
    //return this.http.put<void>(`${this.Baseurl}/api/ReportSummery/uploadReport/${id}`, options);

  }

  getProgramType(id): Observable<IProgramList[]> {
    return this.http.get<IProgramList[]>(this.Baseurl + 'api/Report/GetProgramType/' + id);
  }

  getAllowedUsers(): Observable<any>{
    return this.http.get<any>(this.Baseurl + 'api/Users/allowedUsers');
  }

  getManager(): Observable<any> {
    return this.http.get<any>(this.Baseurl + 'api/Users/manager');
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
