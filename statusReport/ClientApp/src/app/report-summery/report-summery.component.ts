import { Component, OnInit } from '@angular/core';
import { FormGroup, FormArray } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ReportService } from '../services/report.service';
import { reportCR } from '../DTO/ReportCR';
import { ReportSummery } from '../DTO/ReportSummery';
import { error } from '@angular/compiler/src/util';
import { reportActivity } from '../DTO/ReportActivity';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-report-summery',
  templateUrl: './report-summery.component.html',
  styleUrls: ['./report-summery.component.css']
})
export class ReportSummeryComponent implements OnInit {

  reportType: string = 'Monthly';
  ReportSummery: FormGroup;
  reportCRDetails: reportCR[];
  reportActivityDetails: reportActivity[];
  reportSummery: ReportSummery;

  addCRBtn: boolean = true;
  showCRDiv: boolean = true;

  addActBtn: boolean = true;
  showActDiv: boolean = true;

  closeResult: string;
  comment: string;
  remark: string;

  newCRDetails: reportCR = {
    crName: '',
    estimateHrs: 0,
    actualHrs: 0,
    status:''
  };

  newActivityDetails: reportActivity = {
    milestones: '',
    eta:0
  }

  saveReportCRDetails: reportCR[] = [];
  saveReportActivityDetails: reportActivity[] =[]

  saveReportSummery: ReportSummery = {
    clientName: '',
    projectName: '',
    projectType: '',
    accomp: '',
    crDetails: this.saveReportCRDetails,
    activityDetails: this.saveReportActivityDetails,
    clientAwtInfo: '',
    onShoreTotalHrs: 0,
    onShoreHrsTillLastWeek: 0,
    onShoreHrsCurrentWeek: 0,
    offShoreTotalHrs: 0,
    offShoreHrsTillLastWeek: 0,
    offShoreHrsCurrentWeek: 0,
    notes:''
  }

  data = {
    crDetails: [
      {
        Name: "",
        estimateHrs: "",
        actualHrs: "",
        status: ""
      }
    ],
    activityDetails: [
      {
        milestones: "",
        eta:""
      }
    ]
  }

  constructor(private fb: FormBuilder, private reportservice: ReportService, private modalService: NgbModal) {
    this.ReportSummery = this.fb.group({
      clientName: [''],
      projectName: [''],
      projectType: [''],
      accomp: [''],
      crDetails: this.fb.array([]),
      activityDetails: this.fb.array([]),
      clientAwtInfo: [''],
      onShoreTotalHrs: [0],
      onShoreHrsTillLastWeek: [0],
      onShoreHrsCurrentWeek: [0],
      offShoreTotalHrs: [0],
      offShoreHrsTillLastWeek: [0],
      offShoreHrsCurrentWeek: [0],
      notes: ['']
    })

    this.setCrDetails();
    this.setActivityDetails();
  }

  ngOnInit() {


    //this.reportservice.getReportSummeryDetails().subscribe(res => {
    //  this.reportSummery = res;
    //  console.log(res);
    //}, error => console.log(error))

    this.reportservice.getCRdetails().subscribe(res => {
      this.reportCRDetails = res;
      console.log(res);
    }, error => console.log(error))

    this.reportservice.getActivitydetails().subscribe(res => {
      this.reportActivityDetails = res;
      console.log(res);
    }, error => console.log(error))

  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      debugger;
      if (result == "Save click") {
        this.remark = this.comment;

      }
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    debugger;
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  setCrDetails() {
    let control = <FormArray>this.ReportSummery.controls.crDetails;
    this.data.crDetails.forEach(x => {
      control.push(this.fb.group({
        Name: x.Name,
        estimateHrs: x.estimateHrs,
        actualHrs: x.actualHrs,
        status: x.status
      }))
    })
  }

  setActivityDetails() {
    let control = <FormArray>this.ReportSummery.controls.activityDetails;
    this.data.activityDetails.forEach(x => {
      control.push(this.fb.group({
        milestones: x.milestones,
        eta: x.eta
      }))
    })
  }


  onSubmit() {
    console.log(this.ReportSummery.value);
    debugger;
    this.saveReportSummery.clientName = this.ReportSummery.controls.clientName.value;
    this.saveReportSummery.projectName = this.ReportSummery.controls.projectName.value;
    this.saveReportSummery.projectType = this.ReportSummery.controls.projectType.value;
    this.saveReportSummery.accomp = this.ReportSummery.controls.accomp.value;
    this.saveReportSummery.clientAwtInfo = this.ReportSummery.controls.clientAwtInfo.value;
    this.saveReportSummery.onShoreTotalHrs = this.ReportSummery.controls.onShoreTotalHrs.value;
    this.saveReportSummery.onShoreHrsTillLastWeek = this.ReportSummery.controls.onShoreHrsTillLastWeek.value;
    this.saveReportSummery.onShoreHrsCurrentWeek = this.ReportSummery.controls.onShoreHrsCurrentWeek.value;
    this.saveReportSummery.offShoreTotalHrs = this.ReportSummery.controls.offShoreTotalHrs.value;
    this.saveReportSummery.offShoreHrsTillLastWeek = this.ReportSummery.controls.offShoreHrsTillLastWeek.value;
    this.saveReportSummery.offShoreHrsCurrentWeek = this.ReportSummery.controls.offShoreHrsCurrentWeek.value;
    this.saveReportSummery.crDetails = this.reportCRDetails;
    this.saveReportSummery.activityDetails = this.reportActivityDetails;
    this.saveReportSummery.notes = this.ReportSummery.controls.notes.value;


    console.log(this.saveReportSummery);


    this.reportservice.saveReportDetails(this.saveReportSummery).subscribe(data => {
      //debugger;
      alert("Succesfully Added Product details");
    }, error => {
      console.log(error);
      alert("failed while adding product details");
    })

   // console.log(this.saveReportSummery);
  }

  saveForm() {
    alert("Report have been saved successfully");
  }

  rejectForm() {
    alert(" Report have been rejected");
  }


  addNewCR() {
    let control = <FormArray>this.ReportSummery.controls.crDetails;
    control.push(
      this.fb.group({
        Name: [''],
        estimateHrs: [''],
        actualHrs: [''],
        status:['']
      })
    )

    this.addCRBtn = false;
    this.showCRDiv = false;
  }

  addNewActivity() {
    let control = <FormArray>this.ReportSummery.controls.activityDetails;
    control.push(
      this.fb.group({
        milestone: [''],
        ETA: [''],
      })
    )

    this.addActBtn = false;
    this.showActDiv = false;
  }


  deleteCR(index) {
    //debugger;
    console.log(this.reportCRDetails);
    //let control = <FormArray>this.ReportSummery.controls.crDetails;
    //control.removeAt(index)
    this.reportCRDetails.splice(index,1)
  }


  deleteActivity(index) {
    //debugger;
    console.log(this.reportActivityDetails);
    //let control = <FormArray>this.ReportSummery.controls.crDetails;
    //control.removeAt(index)
    this.reportActivityDetails.splice(index, 1)
  }

  saveCRDetails() {
    console.log(this.ReportSummery.controls.crDetails.value[0]);
    this.newCRDetails.crName = this.ReportSummery.controls.crDetails.value[0].Name;
    this.newCRDetails.estimateHrs = this.ReportSummery.controls.crDetails.value[0].estimateHrs;
    this.newCRDetails.actualHrs = this.ReportSummery.controls.crDetails.value[0].actualHrs;
    this.newCRDetails.status = this.ReportSummery.controls.crDetails.value[0].status;

    this.reportCRDetails.push(this.newCRDetails);

    this.addCRBtn = true;
    this.showCRDiv = true;

    console.log(this.reportCRDetails)
  }

  saveActivityDetails() {
    //debugger;
    console.log(this.ReportSummery.controls.activityDetails.value[0]);
    this.newActivityDetails.milestones = this.ReportSummery.controls.activityDetails.value[0].milestones;
    this.newActivityDetails.eta = this.ReportSummery.controls.activityDetails.value[0].eta;
    
    this.reportActivityDetails.push(this.newActivityDetails);

    this.addActBtn = true;
    this.showActDiv = true;

    console.log(this.reportActivityDetails)
  }

}
