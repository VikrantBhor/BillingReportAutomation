import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ProjectComponent } from './project/project.component';

import { AdalService, AdalGuard, AdalInterceptor } from 'adal-angular4';
import { ReactiveFormsModule } from '@angular/forms';

import { LoginComponent } from './login/login.component';
import { ReportComponent } from './report/report.component';
import { ReportSummeryComponent } from './report-summery/report-summery.component';
import { ReportCRComponent } from './report-cr/report-cr.component';
import { ReportCreateComponent } from './report/CreateReport/report-create.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ProjectComponent,
    LoginComponent,
    ReportComponent,
    ReportSummeryComponent,
    ReportCRComponent,
    ReportCreateComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ReportComponent, canActivate: [AdalGuard], pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'project', component: ProjectComponent },
      { path: 'reportSummery', component: ReportSummeryComponent, canActivate: [AdalGuard] },
      { path: 'reportCr', component: ReportCRComponent },
      { path: 'reportCreate', component: ReportCreateComponent },
    ]),
    BsDatepickerModule.forRoot()
  ],
  providers: [
    AdalService,
    AdalGuard,
    { provide: HTTP_INTERCEPTORS, useClass: AdalInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
