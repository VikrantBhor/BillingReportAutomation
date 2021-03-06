import { Component, OnInit } from '@angular/core';
import { AdalService } from 'adal-angular4';
import { HttpClient } from '@angular/common/http';
import { FilterPipe } from 'ngx-filter-pipe';
import { ReportService } from '../services/report.service';
import { reportList } from '../DTO/ReportList';
import { Router } from '@angular/router';


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
  text = "Saved";
  showLoader = true;
  userEmail: string;
  col: number = 3;
  manager: any;

  constructor(private adalService: AdalService, protected http: HttpClient, private reportservice: ReportService, private router: Router) {
    //debugger;
  }

  ngOnInit() {
    this.user = this.adalService.userInfo;
    this.userEmail = this.adalService.userInfo.userName;
    //debugger;
    this.showLoader = true;
    this.user.token = this.user.token.substring(0, 10) + '...';
    console.log(this.user.token);
    this.getManager();
    debugger;
    
    //if (this.user.userName.indexOf('Dhruv') == 0) { // This block is for Rumana
    //  this.role = "Manager";
    //  this.getSubmittedReports();
    //}
    //else {
    //  this.role = "TL";
    //  this.getSavedReports();
    //}
    
    
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
    this.col = 3;
    this.btnPendingClicked = false;
    this.text = "Saved";
    this.reportservice.getReports(this.role, this.statusReport, this.userEmail).subscribe(res => {
      //debugger;
      this.showLoader = false;
      this.reports = res;
      console.log(res);
    }, error => console.log(error))
  }

  getSubmittedReports() {
    this.statusReport = 1;
    this.btnPendingClicked = false;
    this.text = "Submitted";
    this.col = 4;
    this.reportservice.getReports(this.role, this.statusReport, this.userEmail).subscribe(res => {
      //debugger;
      this.showLoader = false;
      this.reports = res;
      console.log(res);
    }, error => console.log(error))
  }

  getPendingReports() {
    this.btnPendingClicked = true;
    this.text = "Pending";
    this.statusReport = 2;
    this.col = 4;
    this.reportservice.getReports(this.role, this.statusReport, this.userEmail).subscribe(res => {
      //debugger;
      this.showLoader = false;
      this.reports = res;
      console.log(res);
    }, error => console.log(error))
  }

  goToReport(url, id) {
    //debugger;
    var myurl = `${url}/${id}`;
    this.router.navigateByUrl(myurl).then(e => {
      if (e) {
        console.log("Navigation is successful!");
      } else {
        console.log("Navigation has failed!");
      }
    });

  }

  getManager() {
    this.reportservice.getManager().subscribe(res => {
      debugger;
      this.manager = res;
      
      if (this.user.userName == this.manager.managerEmail) { // This block is for Rumana
        this.role = "Manager";
        this.getSubmittedReports();
      }
      else {
        this.role = "TL";
        this.getSavedReports();
      }
      console.log(res);
    }, error => console.log(error))
  }
}
