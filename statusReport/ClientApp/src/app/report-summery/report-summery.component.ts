import { Component, OnInit } from '@angular/core';
import { FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ReportService } from '../services/report.service';
import { reportCR } from '../DTO/ReportCR';
import { ReportSummery } from '../DTO/ReportSummery';
import { error } from '@angular/compiler/src/util';
import { reportActivity } from '../DTO/ReportActivity';
import { generate } from 'rxjs';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

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

  // map report id here
  reportId: number = 22;

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
  saveReportActivityDetails: reportActivity[] = []


  public e: ReportSummery = {
    id:0,
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
    notes: ''
  }

  saveReportSummery: ReportSummery = {
    id: this.reportId != null ? this.reportId:0,
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

  constructor(private fb: FormBuilder, private reportservice: ReportService, private modalService: NgbModal, private _router: Router, private toastr: ToastrService) {
    this.ReportSummery = this.fb.group({
      clientName: [''],
      projectName: [''],
      projectType: [''],
      accomp: ['', Validators.required],
      crDetails: this.fb.array([]),
      activityDetails: this.fb.array([]),
      clientAwtInfo: [''],
      onShoreTotalHrs: [0, Validators.required],
      onShoreHrsTillLastWeek: [0, Validators.required],
      onShoreHrsCurrentWeek: [0, Validators.required],
      offShoreTotalHrs: [0, Validators.required],
      offShoreHrsTillLastWeek: [0, Validators.required],
      offShoreHrsCurrentWeek: [0, Validators.required],
      notes: ['']
    })

    this.setCrDetails();
    this.setActivityDetails();
  }

  ngOnInit() {
    

    this.reportservice.getCRdetails(this.reportId).subscribe(res => {
      this.reportCRDetails = res;
      console.log(res);
    }, error => console.log(error))

    this.reportservice.getActivitydetails(this.reportId).subscribe(res => {
      this.reportActivityDetails = res;
      console.log(res);
    }, error => console.log(error))

    //debugger;
    if (this.reportId != 0)
    {
      this.reportservice.getReportSummeryDetails(this.reportId).subscribe(res => {
        this.reportSummery = res;
        console.log(res);
        this.e = res

        //this.generateForm();
      }, error => console.log(error))
    }
  }

  open(content) {
    debugger;
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      debugger;
      if (result == "Save click") {
        this.remark = this.comment;
        this.rejectReport(1, this.remark);
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

  generateForm() {
    debugger;
    console.log(this.reportSummery.clientName); 

    this.ReportSummery = new FormGroup({
      clientName: new FormControl({ value: this.reportSummery.clientName }),
      projectName: new FormControl({ value: this.reportSummery.projectName }),
      projectType: new FormControl({ value: this.reportSummery.projectType }),
      accomp: new FormControl({ value: this.reportSummery.accomp }),
      //crDetails: this.fb.array([]),
      // crDetails: new FormArray({  values: this.reportCRDetails }),
      //activityDetails: this.fb.array([]),
      clientAwtInfo: new FormControl({ value: this.reportSummery.clientAwtInfo }),
      onShoreTotalHrs: new FormControl({ value: this.reportSummery.onShoreTotalHrs }),
      onShoreHrsTillLastWeek: new FormControl({ value: this.reportSummery.onShoreHrsTillLastWeek }),
      onShoreHrsCurrentWeek: new FormControl({ value: this.reportSummery.onShoreHrsCurrentWeek }),
      offShoreTotalHrs: new FormControl({ value: this.reportSummery.offShoreTotalHrs }),
      offShoreHrsTillLastWeek: new FormControl({ value: this.reportSummery.offShoreHrsTillLastWeek }),
      offShoreHrsCurrentWeek: new FormControl({ value: this.reportSummery.offShoreHrsCurrentWeek }),
      notes: new FormControl({ value: this.reportSummery.notes })
    })

    //this.ReportSummery.setControl('crDetails', this.fb.array(this.reportCRDetails));
    //this.ReportSummery.setControl('activityDetails', this.fb.array(this.reportActivityDetails));
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
    this.saveReportSummery.id = this.reportId != null ? this.reportId : 0;
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

    // if newreport is created.
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
        Name: ['', Validators.required],
        estimateHrs: ['', Validators.required],
        actualHrs: ['', Validators.required],
        status: ['', Validators.required]
      })
    )

    this.addCRBtn = false;
    this.showCRDiv = false;
  }

  addNewActivity() {
    let control = <FormArray>this.ReportSummery.controls.activityDetails;
    control.push(
      this.fb.group({
        milestone: ['', Validators.required],
        ETA: ['', Validators.required],
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

  rejectReport(id, remark) {
    debugger;
    this.reportservice.rejectReport(id, remark).subscribe(data => {
      debugger;
      this._router.navigate(['/report/']).then(x => {
        this.toastr.success('Report rejected successfully !', 'Success');
      });
    })
  }
}


