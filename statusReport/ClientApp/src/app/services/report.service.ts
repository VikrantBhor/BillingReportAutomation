import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { reportCR } from '../DTO/ReportCR';
import { Observable } from 'rxjs';
import { Response } from '@angular/http';
import { IClientList, IProgramList } from '../DTO/ClientInfo';
import { IReportDetail } from '../../app/DTO/ReportSummery';



@Injectable({
  providedIn: 'root'
})
export class ReportService {
  Baseurl: string;
  reportCRList: reportCR[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.Baseurl = baseUrl;
  }

  getCRdetails(): Observable<reportCR[]> {
    return this.http.get<reportCR[]>(this.Baseurl + 'api/ReportSummery/getCRDetails');
  }

  getActivitydetails(): Observable<reportCR[]> {
    return this.http.get<reportCR[]>(this.Baseurl + 'api/ReportSummery/getActivityDetails');
  }

  getClientList(): Observable<IClientList[]> {
    return this.http.get<IClientList[]>(this.Baseurl + 'api/Report/GetClientList');
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
