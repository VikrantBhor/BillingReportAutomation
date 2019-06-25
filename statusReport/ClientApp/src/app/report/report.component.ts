import { Component, OnInit } from '@angular/core';
import { AdalService } from 'adal-angular4';
import { HttpClient } from '@angular/common/http';
import { FilterPipe } from 'ngx-filter-pipe';
import { ReportService } from '../services/report.service';
import { reportList } from '../DTO/ReportList';


@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  user: any;
  profile: any;
  reports: reportList[];
  role: string;
  statusReport: number;
  p: number = 1;
  searchTerm: any = { clientName: '' };;
  btnPendingClicked = false;
  showLoader = true;

  constructor(private adalService: AdalService, protected http: HttpClient, private reportservice: ReportService) {
    //debugger;
  }

  ngOnInit() {
    this.user = this.adalService.userInfo;
    debugger;
    this.showLoader = true;
    this.user.token = this.user.token.substring(0, 10) + '...';
    console.log(this.user.token);
    //var r = Configuration["IdentityServerAddress"];
    if (this.user.userName.indexOf('Rumana') == 0) { // This block is for Rumana
      this.role = "Manager";
      this.getSubmittedReports();
    }
    else {
      this.role = "TL";
      this.getSavedReports();
    }
    
    
}

  public getProfile() {
    console.log('Get Profile called');
    return this.http.get("https://graph.microsoft.com/v1.0/me");
  } 

  public profileClicked() {
    this.getProfile().subscribe({
      next: result => {
        console.log('Profile Response Received');
        this.profile = result;
      }
    });
  }

  getSavedReports() {
    this.statusReport = 0;
    this.btnPendingClicked = false;
    this.reportservice.getReports(this.role, this.statusReport).subscribe(res => {
      debugger;
      this.showLoader = false;
      this.reports = res;
      console.log(res);
    }, error => console.log(error))
  }

  getSubmittedReports() {
    this.statusReport = 1;
    this.btnPendingClicked = false;
    this.reportservice.getReports(this.role, this.statusReport).subscribe(res => {
      debugger;
      this.showLoader = false;
      this.reports = res;
      console.log(res);
    }, error => console.log(error))
  }

  getPendingReports() {
    this.btnPendingClicked = true;
    this.statusReport = 3;
    this.reportservice.getReports(this.role, this.statusReport).subscribe(res => {
      debugger;
      this.showLoader = false;
      this.reports = res;
      console.log(res);
    }, error => console.log(error))
  }

}
