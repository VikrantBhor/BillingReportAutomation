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
import { FilterPipeModule } from 'ngx-filter-pipe'; 
import { NgxPaginationModule } from 'ngx-pagination';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';

import { LoginComponent } from './login/login.component';
import { ReportComponent } from './report/report.component';
import { ReportSummeryComponent } from './report-summery/report-summery.component';
import { ReportCRComponent } from './report-cr/report-cr.component';

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
    ReportCRComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    FilterPipeModule,
    NgxPaginationModule,
    NgbModule,
    ToastrModule.forRoot(), // ToastrModule added
    RouterModule.forRoot([
      { path: '', component: ReportComponent, canActivate: [AdalGuard], pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'project', component: ProjectComponent },
      { path: 'reportSummery', component: ReportSummeryComponent },
      { path: 'report', component: ReportComponent },
      { path: 'reportCr', component: ReportCRComponent },
      
    ])
  ],
  providers: [
    AdalService,
    AdalGuard,
    { provide: HTTP_INTERCEPTORS, useClass: AdalInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
