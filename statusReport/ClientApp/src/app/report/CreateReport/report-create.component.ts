import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AdalService } from 'adal-angular4';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
import { ReportService } from '../../services/report.service';
import { IClientList, IProgramList } from '../../DTO/ClientInfo';
import { IReportDetail } from '../../DTO/ReportSummery';
import { parseDate } from 'ngx-bootstrap/chronos/public_api';
import { getLocaleDateTimeFormat } from '@angular/common';
//import { IReportDetail } from '../../app/DTO/ReportSummery';

@Component({
  selector: 'app-report-create',
  templateUrl: './report-create.component.html',
  styleUrls: ['./report-create.component.css']
})

export class ReportCreateComponent implements OnInit {
  clientList: IClientList[];
  user: any;
  programTypeList: IProgramList[];
  reportForm: FormGroup;
  reportDetail: IReportDetail = {
    ClientName : '0',
    ProjectName: '0',
    ProjectType: '0',
    CreatedBy: '',
    CreatedByEmail: '',
    ReportStartDate: ''   
  } ;

  constructor(private adalService: AdalService, private reportservice: ReportService) {
    
  }


  ngOnInit() {
    debugger;
    this.user = this.adalService.userInfo;
    this.GetClientList();
    this.reportForm = new FormGroup({
      clientName: new FormControl(),
      projectType: new FormControl(),
      projectDuration: new FormControl(),
      projectDate: new FormControl()
    });

  }


   SubmitReport() {
     this.AssignValues(this.reportDetail);
  }


   AssignValues(detail: IReportDetail) {
     detail.ClientName = this.clientList.find(x => x.id == parseInt(this.reportDetail.ClientName)).name;
     detail.ProjectName = this.programTypeList.find(x => x.id == parseInt(this.reportDetail.ProjectName)).name;
     detail.ProjectType = this.reportDetail.ProjectType;
     detail.CreatedBy = this.user.profile.name;
     detail.CreatedByEmail = this.user.userName;
     let date = new Date(this.reportDetail.ReportStartDate).toLocaleDateString();
     detail.ReportStartDate = date;

     this.reportservice.saveReport(detail).subscribe((data: any) => {
       alert ("Success");
     }, error => {
       alert( "error");
     })

}

  GetClientList() {
    this.reportservice.getClientList().subscribe((response: any) => {
      this.clientList = response;
    });
  }

  OnClientChange(event:any) {
    this.reportservice.getProgramType(event.target.value).subscribe((response: any) => {
      this.programTypeList = response;
    });
  }


}
