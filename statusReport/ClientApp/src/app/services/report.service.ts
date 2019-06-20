import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { reportCR } from '../DTO/ReportCR';
import { Observable } from 'rxjs';
import { Response } from '@angular/http';
import { reportList } from '../DTO/ReportList';



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

  getReports(role,reportStatus): Observable<reportList[]> {
    return this.http.get<reportList[]>(this.Baseurl + 'api/Report/reportStatus/' + role + '/' + reportStatus);
  }

}
