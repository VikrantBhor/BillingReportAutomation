import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { AdalService } from 'adal-angular4';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReportService } from '../../services/report.service';
import { IClientList, IProgramList } from '../../DTO/ClientInfo';
import { IReportDetail } from '../../DTO/ReportSummery';
import { parseDate } from 'ngx-bootstrap/chronos/public_api';
import { getLocaleDateTimeFormat } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
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
    ReportStartDate: '',
    ReportStatus: null,
    ReportEndDate:''
  } ;

  ReportProjectType: string = '';
  StartDate: Date;
  EndDate: Date;

  constructor(private adalService: AdalService, private reportservice: ReportService, private _router: Router, private toastr: ToastrService) {
    
  }


  ngOnInit() {
    debugger;
    this.user = this.adalService.userInfo;
    this.GetClientList();
    this.reportForm = new FormGroup({
      clientName: new FormControl('0', Validators.required),
      projectType: new FormControl('0', Validators.required),
      projectDuration: new FormControl('0', Validators.required),
      projectDate: new FormControl('', Validators.required)
    });

  }


  SubmitReport() {

    if (this.reportForm.valid == true) {
      this.AssignValues(this.reportDetail);
    } else {
      this.toastr.error('Please fill all the required(*) field', 'Error');
    }
    
  }


  AssignValues(detail: IReportDetail) {
    try {

   
    debugger;
     detail.ClientName = this.clientList.find(x => x.id == parseInt(this.reportDetail.ClientName)).name;
    detail.ProjectName = this.programTypeList.find(x => x.id == parseInt(this.reportDetail.ProjectName)).name;
    this.ReportProjectType = this.reportDetail.ProjectType;
    detail.ProjectType = this.ReportProjectType;
     detail.CreatedBy = this.user.profile.name;
     detail.CreatedByEmail = this.user.userName;
    let date = new Date(this.reportDetail.ReportStartDate).toLocaleDateString();
 

    let today = new Date(this.reportDetail.ReportStartDate)
     
      if (this.ReportProjectType == "Monthly") {  //Get Monthly Start Date and EndDate
      var y = today.getFullYear(), m = today.getMonth();
      this.StartDate = new Date(y, m, 1);
      this.EndDate = new Date(y, m + 1, 0);
    }
      else if (this.ReportProjectType == "Weekly") {  //Get Weekly Start Date and EndDate
      var start = 0;
      var day = today.getDay() - start;
      var datetm = today.getDate() - day + 1;    
      // Grabbing Start/End Dates
      this.StartDate = new Date(today.setDate(datetm));
      this.EndDate = new Date(today.setDate(datetm + 6));
      
    }
    else {   

    }
      console.log("This is " + this.ReportProjectType + " and starts from" + this.StartDate + " to " + this.EndDate);

      detail.ReportStartDate = this.StartDate.toDateString();
      detail.ReportEndDate = this.EndDate.toDateString();
      debugger;
      detail.ReportStatus = 4;
      this.reportservice.saveReport(detail).subscribe((data: number) => {
        debugger;        
          this._router.navigate(['reportSummery/',data]).then(x => {
        this.toastr.success('Report Created successfully !', 'Success');
      });      
    }, error => {
      this.toastr.error('Error! Please Try Again','Error');
        })

    } catch (e) {
      this.toastr.error('Error! Please Try Again', 'Error');
    }

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
