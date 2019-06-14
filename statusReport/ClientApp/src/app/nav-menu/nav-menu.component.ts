import { Component, Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpClientModule } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': 'true',
  })
};

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  baseurl: string;
  data: any;

  constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseurl = baseUrl;

  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  login() {

    window.location.href = this.baseurl + 'api/Auth/Login';
   // return this._http.get(this.baseurl + 'api/Auth/Login', httpOptions).subscribe(result => {
   //   debugger;

   //   this.data = result;
      
   // }, error => {
   //   debugger;
     // console.error(error);
     // });

  }

}
