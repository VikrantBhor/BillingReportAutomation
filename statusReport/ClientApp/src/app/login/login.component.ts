import { Component, OnInit } from '@angular/core';
import { AdalService } from 'adal-angular4';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private adalService: AdalService) {
    adalService.init(environment.config);
  }

  ngOnInit() {
    debugger;
    this.adalService.handleWindowCallback();
    debugger;
    const user = this.adalService.getUser();
    console.log(this.adalService.userInfo);
  }

  login() {
    this.adalService.clearCache();
    console.log(this.adalService.userInfo);
    debugger;
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

}
