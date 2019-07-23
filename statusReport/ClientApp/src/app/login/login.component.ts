import { Component, OnInit } from '@angular/core';
import { AdalService } from 'adal-angular4';
import { environment } from 'src/environments/environment';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ReportService } from '../services/report.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  isAuthenticated: boolean = false;
  allowedUsers: string;

  constructor(private adalService: AdalService, private _router: Router, private toastr: ToastrService,private reportService: ReportService) {
    adalService.init(environment.config);
  }

  ngOnInit() {
    //debugger;
    this.adalService.handleWindowCallback();
    debugger;
    this.getAllowedUsers();
   /*if (this.adalService.userInfo.userName.trim().length != 0) {
      const authenticatedUser = ["Ankur.Gautam@atidan.com", "Ashfaque.Sayed@razor-tech.com", "Dhruv.Bilakhia@razor-tech.com", "Munifa.Khan@razor-tech.com"];
      for (let user of authenticatedUser) {
        if (user == this.adalService.userInfo.userName) {
          this.isAuthenticated = true;
          this.adalService.userInfo.authenticated;
        }
      }
      if (this.isAuthenticated == false) {
        this._router.navigate(['unauthorized/']).then(x => {

        });
        this.adalService.userInfo.authenticated = false;
        this.toastr.error('Not Authorized !', 'error');
        this.adalService.userInfo.authenticated;
      }
    }
    else {
      this.adalService.userInfo.authenticated = false;
      this.adalService.userInfo.authenticated;
    }

    const user = this.adalService.getUser();
    console.log(this.adalService.userInfo); */
  }

  login() {
    debugger;
    this.adalService.clearCache();
    console.log(this.adalService.userInfo);
    //debugger;
    this.adalService.logOut();
    const user = this.adalService.getUser();
    //const roles = user.roles; // Returns [ "User" ]
    this.adalService.login();
  }

  logout() {


    this.adalService.clearCache();
    this.adalService.logOut();
    console.log(this.adalService.userInfo);

    // this.adalService.init(environment.config);
  }

  get authenticated(): boolean {
    return this.adalService.userInfo.authenticated;
  }

  getAllowedUsers() {
    this.reportService.getAllowedUsers().subscribe(res => {
      this.allowedUsers = res.users;
      debugger;
      if (this.adalService.userInfo.userName.trim().length != 0) {
        //const authenticatedUser = ["Ankur.Gautam@atidan.com", "Ashfaque.Sayed@razor-tech.com", "Dhruv.Bilakhia@razor-tech.com", "Munifa.Khan@razor-tech.com"];
        for (let user of this.allowedUsers.split(',')) {
          if (user == this.adalService.userInfo.userName) {
            this.isAuthenticated = true;
            this.adalService.userInfo.authenticated;
          }
        }
        if (this.isAuthenticated == false) {
          this._router.navigate(['unauthorized/']).then(x => {

          });
          this.adalService.userInfo.authenticated = false;
          this.toastr.error('Not Authorized !', 'error');
          this.adalService.userInfo.authenticated;
        }
      }
      else {
        this.adalService.userInfo.authenticated = false;
        this.adalService.userInfo.authenticated;
      }

      const user = this.adalService.getUser();
      console.log(this.adalService.userInfo);

    }, error => console.log(error));
  }
}
