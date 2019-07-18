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
import { SharedObject } from '../../DTO/SharedObject';
import { DataService } from '../../services/SharedDataService';
import { DATE } from 'ngx-bootstrap/chronos/units/constants';
//import { IReportDetail } from '../../app/DTO/ReportSummery';

@Component({
  selector: 'app-report-create',
  templateUrl: './report-create.component.html',
  styleUrls: ['./report-create.component.css']
})

export class ReportCreateComponent implements OnInit {
  sharedData: SharedObject = new SharedObject('','','','','','','','','','');
  clientList: IClientList[];
  user: any;
  maxDate: Date;

  showLoader: boolean=true;
  projectID: string;
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

  constructor(private adalService: AdalService, private reportservice: ReportService, private _router: Router, private toastr: ToastrService, private data: DataService) {
    debugger;
    this.maxDate = new Date();
  }


  ngOnInit() {    
    debugger;
    this.maxDate = new Date();
    this.user = this.adalService.userInfo;
    this.GetClientList();
    this.reportForm = new FormGroup({
      clientName: new FormControl('0', Validators.required),
      projectType: new FormControl('0', Validators.required),
      projectDuration: new FormControl('0', Validators.required),
      projectDate: new FormControl('', Validators.required)
    });
    this.data.currentSharedData.subscribe(sharedData => this.sharedData = sharedData);
    console.log("this.sharedData", this.sharedData)
  }


  SubmitReport() {
    debugger;
    var a = this.reportForm.controls["clientName"].value;
    var b = this.reportForm.controls["projectType"].value;
    var c = this.reportForm.controls["projectDuration"].value;
    //this.reportForm.controls["projectType"].value
    if (this.reportForm.valid == true && a!="0" && b!="0" && c!="0") {
        this.AssignValues(this.reportDetail);      
    } else {
      this.toastr.error('Please fill in all required(*) details', 'Error!');
    }
    
  }


  AssignValues(detail: IReportDetail) {
    try {
    debugger;
      detail.ClientName = this.clientList.find(x => x.id == parseInt(this.reportDetail.ClientName)).name;
      this.projectID = this.reportDetail.ProjectName;
    detail.ProjectName = this.programTypeList.find(x => x.id == parseInt(this.reportDetail.ProjectName)).name;
    this.ReportProjectType = this.reportDetail.ProjectType;
    detail.ProjectType = this.ReportProjectType;
     detail.CreatedBy = this.user.profile.name;
     detail.CreatedByEmail = this.user.userName;

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

      //To save in DB 
      //this.reportservice.saveReport(detail).subscribe((data: number) => {
      //  debugger;
      //  this._router.navigate(['reportSummery/', data]).then(x => {
      //    this.toastr.success('Report Created successfully !', 'Success');
      //  });
      //}, error => {
      //  this.toastr.error('Error! Please Try Again', 'Error');
      //  });


      //To save data in Shared Service
      this.sharedData.clientName = detail.ClientName;
      this.sharedData.projectId = this.projectID;
      this.sharedData.reportId = '0';
      this.sharedData.reportType = this.reportDetail.ProjectType == "Weekly" ? "Week" : "Month";
      this.sharedData.reportDate = today.toJSON().split('T')[0];
      this.sharedData.reportStartDate = detail.ReportStartDate;//  this.StartDate.toJSON().split('T')[0];
      this.sharedData.reportEndDate = detail.ReportEndDate; //this.EndDate.toJSON().split('T')[0];
      this.sharedData.projectName = detail.ProjectName;
      this.sharedData.createdByEmail = this.user.userName;
      this.sharedData.createdBy = this.user.profile.name;
      this.data.changeMessage(this.sharedData);
      this._router.navigate(['reportSummery/', 0]).then(x => {
        //this.toastr.success('Report Created successfully !', 'Success');
      });

    } catch (e) {
      this.toastr.error('Please fill in all required(*) details', 'Error!');
    }

  }



  GetClientList() {
    debugger;
    this.reportservice.getClientList().subscribe((response: any) => {
      this.clientList = response;
      this.showLoader = false;
    });
  }

  OnClientChange(event: any) {
    this.showLoader = true;
    this.reportservice.getProgramType(event.target.value).subscribe((response: any) => {
      this.programTypeList = response;
      this.showLoader = false;
    });
  }


}
