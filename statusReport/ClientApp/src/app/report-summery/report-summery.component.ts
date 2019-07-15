import { Component, OnInit } from '@angular/core';
import { FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ReportService } from '../services/report.service';
import { reportCR } from '../DTO/ReportCR';
import { ReportSummery } from '../DTO/ReportSummery';
import { error } from '@angular/compiler/src/util';
import { reportActivity } from '../DTO/ReportActivity';
import { generate, from } from 'rxjs';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SharedObject } from '../DTO/SharedObject';
import { DataService } from '../services/SharedDataService';
import { parse } from 'querystring';
import { AdalService } from 'adal-angular4';
import { Packer } from 'docx';
import { saveAs } from 'file-saver/FileSaver';
import { GenerateReport } from '../generate-report/generateReport.component';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Num } from 'docx/build/file/numbering/num';



@Component({
  selector: 'app-report-summery',
  templateUrl: './report-summery.component.html',
  styleUrls: ['./report-summery.component.css']
})
export class ReportSummeryComponent implements OnInit {
  sharedData: SharedObject;
  reportType: string = 'Week';
  ReportSummery: FormGroup;
  reportCRDetails: reportCR[] = [];
  reportActivityDetails: reportActivity[]=[];
  reportSummery: ReportSummery;
  showLoader: boolean = true;
  addCRBtn: boolean = true;
  showCRDiv: boolean = true;

  addActBtn: boolean = true;
  showActDiv: boolean = true;

  closeResult: string;
  comment: string;
  remark: string;

  //Mapping parameters
  // map report id here
  reportId: number = 22;
  projectId: number = 1041;
  reportDate: number = 20190617;
  //repoStartDate: number = 20190401;
  //repoEndDate: number = 20190430;
  repoStartDate: string = '';
  repoEndDate: string = '';
  createdByEmail: string;
  createdBy: string;
  cName: string ='';
  prName: string='';
  prType: string=''
  isManager: boolean = false;
  isTL: boolean = true;

  accomplishment: any;
  currentHrs: any;
  lastHrs : any
  remainingHoursOffShore: number;
  remainingHoursOnShore: number;
  formData: any = {
    data: '',
    reportType: '',
    reportStartDate: '',
    reportEndDate: '',
    projectName:''
  };

  newCRDetails: reportCR = {
    crName: '',
    estimateHrs: 0,
    actualHrs: 0,
    status: ''
  };

  newActivityDetails: reportActivity = {
    milestones: '',
    eta: 0
  }

  saveReportCRDetails: reportCR[] = [];
  saveReportActivityDetails: reportActivity[] = []
  

  public e: ReportSummery = {
    id: 0,
    clientName: this.cName,
    projectName: this.prName,
    projectType: this.prType,
    accomp: this.accomplishment,
    crDetails: this.saveReportCRDetails,
    activityDetails: this.saveReportActivityDetails,
    clientAwtInfo: '',
    onShoreTotalHrs: null,
    onShoreHrsTillLastWeek: null,
    onShoreHrsCurrentWeek: null,
    offShoreTotalHrs: null,
    offShoreHrsTillLastWeek: this.lastHrs,
    offShoreHrsCurrentWeek: this.currentHrs,
    notes: '',
    reportStartDate: '',
    reportEndDate: '',
    createdByEmail: '',
    createdBy: '',
    //offhoreTotalHrs: 0,
    //OffShoreHrsUtilized: 0,
    //OnShoreHrsUtilized: 0
  }

  saveReportSummery: ReportSummery = {
    id: this.reportId != null ? this.reportId : 0,
    clientName: '',
    projectName: '',
    projectType: '',
    accomp: this.accomplishment,
    crDetails: this.saveReportCRDetails,
    activityDetails: this.saveReportActivityDetails,
    clientAwtInfo: '',
    onShoreTotalHrs: 0,
    onShoreHrsTillLastWeek:0,
    onShoreHrsCurrentWeek: 0,
    offShoreTotalHrs: 0,
    offShoreHrsTillLastWeek: this.lastHrs,
    offShoreHrsCurrentWeek: this.currentHrs,
    notes: '',
    reportStartDate: '',
    reportEndDate: '',
    createdByEmail: '',
    createdBy: '',
    //offhoreTotalHrs: 0,
    //OffShoreHrsUtilized: 0,
    //OnShoreHrsUtilized: 0
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
        eta: ""
      }
    ]
  }

  constructor(private fb: FormBuilder, private reportservice: ReportService, private modalService: NgbModal, private route: ActivatedRoute, private _router: Router, private toastr: ToastrService, private dataservice: DataService,private adalService: AdalService,) {
    
    this.GetReportDetail();
    this.ReportSummery = this.fb.group({
      clientName: [this.cName],
      projectName: [this.prName],
      projectType: [this.prType],
      accomp: [this.accomplishment, Validators.required],
      crDetails: this.fb.array([]),
      activityDetails: this.fb.array([]),
      clientAwtInfo: [''],
      onShoreTotalHrs: [null, Validators.required],
      onShoreHrsTillLastWeek: [null, Validators.required],
      onShoreHrsCurrentWeek: [null, Validators.required],
      onShoreHrsUtilized: [null],
      onShoreHrsRemaining:[null],
      offShoreTotalHrs: [null, Validators.required],
      offShoreHrsTillLastWeek: [this.lastHrs, Validators.required],
      offShoreHrsCurrentWeek: [this.currentHrs, Validators.required],
      OffShoreHrsUtilized: [null],
      OffShoreHrsRemaining: [null],
      notes: ['']
    })

    this.setCrDetails();
    this.setActivityDetails();
   
  }

  ngOnInit() {
    
    if (this.adalService.userInfo.userName.indexOf('Ankur') == 0) { // This block is for Rumana
      
      this.isManager = true;
      this.isTL = false;
    }
    else {
      this.isManager = false;
      this.isTL = true;
    }
    var repoData = this.dataservice.currentSharedData.subscribe(sharedData => this.sharedData = sharedData);
    //Mapping parameters
    // map report id here
    
    this.projectId = parseInt(this.sharedData.projectId);
    this.e.projectName = this.sharedData.projectName;
    this.e.projectType = this.sharedData.reportType;
    this.reportType = this.sharedData.reportType;
    this.e.clientName = this.sharedData.clientName;
    this.e.projectName = this.sharedData.projectName;
    this.reportDate = parseInt(this.sharedData.reportDate.replace("-","").replace("-",""));
    //this.repoStartDate = parseInt(this.sharedData.reportStartDate.replace("-", "").replace("-", ""));
    //this.repoEndDate = parseInt(this.sharedData.reportEndDate.replace("-", "").replace("-", ""));
    this.repoStartDate = (this.sharedData.reportStartDate.replace("-", "").replace("-", ""));
    this.repoEndDate = (this.sharedData.reportEndDate.replace("-", "").replace("-", ""));
    this.createdByEmail = this.sharedData.createdByEmail;
    this.createdBy = this.sharedData.createdBy;

    //
    console.log(this.route.snapshot.data['reportId']);
    this.reportId = +this.route.snapshot.paramMap.get('reportId');

    if (this.reportId == 0)
    {
      if (this.reportType == 'Week') {
        //
        this.reportservice.getweekComments(this.projectId, this.reportDate).subscribe((res: any) => {
          //
          this.e.accomp = res.weekComments;
          console.log(res);
          console.log(this.e);
          console.log(this.e.accomp);

          this.reportservice.getcurrentWkHrs(this.projectId, this.reportDate).subscribe((resp: any) => {
            //
            this.e.offShoreHrsCurrentWeek = resp.currentWKHrs;
            console.log(resp);
            console.log(this.e);
            console.log(this.e.offShoreHrsCurrentWeek);

            this.reportservice.getLastWkHrs(this.projectId, this.reportDate).subscribe((respn: any) => {
              
              this.e.offShoreHrsTillLastWeek = respn.lastWKHrs;
              this.showLoader = false;
              console.log(respn);
              console.log(this.e);
              console.log(this.e.offShoreHrsTillLastWeek);

            }, error => console.log(error))

          }, error => console.log(error))

        }, error => console.log(error))

        //
        console.log(this.reportCRDetails);

      }
      else if (this.reportType == 'Month') {

        this.reportservice.getMonthComments(this.projectId, this.reportDate).subscribe((res: any) => {
          //
          this.e.accomp = res.monthComments;
          console.log(res);

          this.reportservice.getcurrentMonthHrs(this.projectId, this.reportDate).subscribe((resp: any) => {
            //
            this.e.offShoreHrsCurrentWeek = resp.currentMnthHrs;
            console.log(resp);

            this.reportservice.getLastMonthHrs(this.projectId, this.reportDate).subscribe((respn: any) => {
              
              this.e.offShoreHrsTillLastWeek = respn.lastMnthHrs;
              this.showLoader = false;
              console.log(respn);
            }, error => console.log(error))

          }, error => console.log(error))

        }, error => console.log(error))

      } else {
        
        this.showLoader = false;
      }

    }
    else
    {

      this.reportservice.getCRdetails(this.reportId).subscribe(res => {
        this.reportCRDetails = res;
        console.log(res);
      }, error => console.log(error))

      this.reportservice.getActivitydetails(this.reportId).subscribe(res => {
        this.reportActivityDetails = res;
        console.log(res);
      }, error => console.log(error))

      this.reportservice.getReportSummeryDetails(this.reportId).subscribe(res => {
        
        this.reportSummery = res;
        this.reportType = res.projectType;
        console.log(res);
        this.e = res
        this.showLoader = false;
        //this.generateForm();
      }, error => console.log(error))

    }
  

    //this.reportservice.getCRdetails(this.reportId).subscribe(res => {
    //  this.reportCRDetails = res;
    //  console.log(res);
    //}, error => console.log(error))

    //this.reportservice.getActivitydetails(this.reportId).subscribe(res => {
    //  this.reportActivityDetails = res;
    //  console.log(res);
    //}, error => console.log(error))

    //
    //this.reportservice.getweekComments(this.projectId, this.reportDate).subscribe((res: any) => {
    //  
    //  this.e.accomp = res.comments;
    // // this.accomplishment = res.comments;
    //  console.log(res.comments);
    //}, error => console.log(error))

    //
    //if (this.reportId != 0)
    //{
    //  this.reportservice.getReportSummeryDetails(this.reportId).subscribe(res => {
    //    this.reportSummery = res;
    //    console.log(res);
    //    this.e = res

    //    //this.generateForm();
    //  }, error => console.log(error))
    //}
  }

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      
      if (result == "Save click") {
        this.remark = this.comment;
        this.rejectReport(this.reportId, this.remark);
      }
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
      });    
  }

  private getDismissReason(reason: any): string {
    
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  //generateForm() {
  //  
  //  console.log(this.reportSummery.clientName); 

  //  //this.ReportSummery = new FormGroup({
  //  //  clientName: new FormControl({ value: this.reportSummery.clientName }),
  //  //  projectName: new FormControl({ value: this.reportSummery.projectName }),
  //  //  projectType: new FormControl({ value: this.reportSummery.projectType }),
  //  //  accomp: new FormControl({ value: this.reportSummery.accomp }),
  //  //  //crDetails: this.fb.array([]),
  //  //  // crDetails: new FormArray({  values: this.reportCRDetails }),
  //  //  //activityDetails: this.fb.array([]),
  //  //  clientAwtInfo: new FormControl({ value: this.reportSummery.clientAwtInfo }),
  //  //  onShoreTotalHrs: new FormControl({ value: this.reportSummery.onShoreTotalHrs }),
  //  //  onShoreHrsTillLastWeek: new FormControl({ value: this.reportSummery.onShoreHrsTillLastWeek }),
  //  //  onShoreHrsCurrentWeek: new FormControl({ value: this.reportSummery.onShoreHrsCurrentWeek }),
  //  //  offShoreTotalHrs: new FormControl({ value: this.reportSummery.offShoreTotalHrs }),
  //  //  offShoreHrsTillLastWeek: new FormControl({ value: this.reportSummery.offShoreHrsTillLastWeek }),
  //  //  offShoreHrsCurrentWeek: new FormControl({ value: this.reportSummery.offShoreHrsCurrentWeek }),
  //  //  notes: new FormControl({ value: this.reportSummery.notes })
  //  //})

  //  //this.ReportSummery.setControl('crDetails', this.fb.array(this.reportCRDetails));
  //  //this.ReportSummery.setControl('activityDetails', this.fb.array(this.reportActivityDetails));
  //}


  GetReportDetail() {
    var repoData = this.dataservice.currentSharedData.subscribe(sharedData => this.sharedData = sharedData);
    //Mapping parameters
    // map report id here
    
    this.projectId = parseInt(this.sharedData.projectId);
    this.prType = this.sharedData.reportType;
    this.reportType = this.sharedData.reportType;
    this.cName = this.sharedData.clientName;
    this.prName = this.sharedData.projectName;
    this.reportDate = parseInt(this.sharedData.reportDate.replace("-", "").replace("-", ""));
    //this.repoStartDate = parseInt(this.sharedData.reportStartDate.replace("-", "").replace("-", ""));
    //this.repoEndDate = parseInt(this.sharedData.reportEndDate.replace("-", "").replace("-", ""));
    this.repoStartDate = (this.sharedData.reportStartDate.replace("-", "").replace("-", ""));
    this.repoEndDate = (this.sharedData.reportEndDate.replace("-", "").replace("-", ""));    
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


  SetRemainingOffShoreHours() {
    this.remainingHoursOffShore = (this.e.onShoreTotalHrs) - (this.e.offShoreHrsTillLastWeek + this.e.offShoreHrsCurrentWeek);  
  }

  SetRemainingOnShoreHours() {
    this.remainingHoursOnShore = (this.e.onShoreTotalHrs) - (this.e.onShoreHrsTillLastWeek + this.e.onShoreHrsCurrentWeek);
  }


  onSubmit() {
    console.log(this.ReportSummery.value);
    
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
    this.saveReportSummery.reportStartDate = this.reportSummery == undefined ? this.repoStartDate : this.reportSummery.reportStartDate;
    this.saveReportSummery.reportEndDate = this.reportSummery == undefined ? this.repoEndDate : this.reportSummery.reportEndDate;
    this.saveReportSummery.createdByEmail = this.reportSummery == undefined ? this.createdByEmail : this.reportSummery.createdByEmail;
    this.saveReportSummery.createdBy = this.reportSummery == undefined ? this.createdBy : this.reportSummery.createdBy;

    console.log(this.saveReportSummery);

    // if newreport is created.
    this.reportservice.saveReportDetails(this.saveReportSummery).subscribe(data => {
      //
      this._router.navigate(['report/']).then(x => {
        this.toastr.success('Report Submitted successfully !', 'Success');
      });
      
      //alert("Succesfully Added Product details");
    }, error => {
      console.log(error);
      this.toastr.warning('failed while Submitting report !', 'Warning');
      alert("failed while adding product details");
    })

    // console.log(this.saveReportSummery);

  }

  saveForm() {
    //alert("Report have been saved successfully");

    //
    //console.log(this.ReportSummery.controls.clientName.valid);


    console.log(this.ReportSummery.value);
    
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
    this.saveReportSummery.reportStartDate = this.reportSummery == undefined ? this.repoStartDate : this.reportSummery.reportStartDate;
    this.saveReportSummery.reportEndDate = this.reportSummery == undefined ? this.repoEndDate : this.reportSummery.reportEndDate;
    this.saveReportSummery.createdByEmail = this.reportSummery == undefined ? this.createdByEmail : this.reportSummery.createdByEmail;
    this.saveReportSummery.createdBy = this.reportSummery == undefined ? this.createdBy : this.reportSummery.createdBy;
    //this.reportId = 
    console.log(this.saveReportSummery);

    // if newreport is created.
    this.reportservice.draftReportDetails(this.saveReportSummery).subscribe(data => {
      
      this.reportId = data;
      this.toastr.success('Report Drafted successfully !', 'Success');
      //alert("Succesfully Added Product details");
    }, error => {
      
      console.log(error);
      this.toastr.warning('Please fill all the inputs!', 'Warning');
      //alert("failed while adding product details");
    })

   // console.log(this.saveReportSummery);


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
    //
    console.log(this.reportCRDetails);
    //let control = <FormArray>this.ReportSummery.controls.crDetails;
    //control.removeAt(index)
    this.reportCRDetails.splice(index, 1)
  }

  deleteActivity(index) {
    //
    console.log(this.reportActivityDetails);
    //let control = <FormArray>this.ReportSummery.controls.crDetails;
    //control.removeAt(index)
    this.reportActivityDetails.splice(index, 1)
  }

  saveCRDetails() {
    
    console.log(this.reportCRDetails);
    console.log(this.ReportSummery.controls.crDetails.value[0].Name.valid)
    console.log(this.ReportSummery.controls.crDetails.value[0]);

    

    //this.newCRDetails.crName = this.ReportSummery.controls.crDetails.value[0].Name;
    //this.newCRDetails.estimateHrs = this.ReportSummery.controls.crDetails.value[0].estimateHrs;
    //this.newCRDetails.actualHrs = this.ReportSummery.controls.crDetails.value[0].actualHrs;
    //this.newCRDetails.status = this.ReportSummery.controls.crDetails.value[0].status;

    //this.reportCRDetails.push(this.newCRDetails);

    this.reportCRDetails.push({
      'crName': this.ReportSummery.controls.crDetails.value[0].Name,
      'estimateHrs': this.ReportSummery.controls.crDetails.value[0].estimateHrs,
      'actualHrs': this.ReportSummery.controls.crDetails.value[0].actualHrs,
      'status': this.ReportSummery.controls.crDetails.value[0].status
    });

    this.addCRBtn = true;
    this.showCRDiv = true;

    console.log(this.reportCRDetails)
  }

  cancelCR() {
    this.addCRBtn = true;
    this.showCRDiv = true;
  }

  saveActivityDetails() {
    //
    console.log(this.ReportSummery.controls.activityDetails.value[0]);
    //this.newActivityDetails.milestones = this.ReportSummery.controls.activityDetails.value[0].milestones;
    //this.newActivityDetails.eta = this.ReportSummery.controls.activityDetails.value[0].eta;

    //this.reportActivityDetails.push(this.newActivityDetails);

    this.reportActivityDetails.push({ 'milestones': this.ReportSummery.controls.activityDetails.value[0].milestones, 'eta': this.ReportSummery.controls.activityDetails.value[0].eta});

    this.addActBtn = true;
    this.showActDiv = true;

    console.log(this.reportActivityDetails)
  }

  cancelActivity() {
    this.addActBtn = true;
    this.showActDiv = true;
  }

  rejectReport(id, remark) {
    
    this.reportservice.rejectReport(id, remark).subscribe(data => {
      
      this._router.navigate(['/report/']).then(x => {
        this.toastr.success('Report rejected successfully !', 'Success');
      });
    })
  }

  public downloadDocs(): void {
    this.showLoader = true;
    const clientName = "Atidan";
    const projectName = "StatusReport";
    var date = new Date().getMonth() + 1;
    var year = new Date().getFullYear();
    const statusReport = new GenerateReport();
    
    const doc = statusReport.generateReport(this.reportSummery,this.reportCRDetails,this.reportActivityDetails);
    const packer = new Packer();

    //packer.toBlob(doc).then(blob => {
    //  
    //  console.log(blob);
    //  saveAs(blob, "weekly_" + clientName + "_" + projectName + "_" + date + "_" + year + ".docx");
    //  console.log("Document created successfully");
    //});

    //packer.toBuffer(doc).then((buffer) => {
    //  fs.writeFileSync("My Document.docx", buffer);
    //});

    packer.toBase64String(doc).then((string) => {
      var reqHeader = new Headers({
        'Content-Type': 'application/zip'
      });
      //const formData: FormData = new FormData();
      //formData.append('logo', string);
      this.formData.data = string;
      this.formData.reportType = this.reportType;
      this.formData.reportStartDate = this.reportSummery.reportStartDate;
      this.formData.reportEndDate = this.reportSummery.reportEndDate;
      this.formData.projectName = this.reportSummery.projectName;

      
      this.reportservice.postData(this.formData).subscribe(data => {
        
        this.showLoader = false;


        this.reportservice.uploadReport(this.reportId).subscribe(data => {
          
          this.showLoader = false;
          this.toastr.success('Report uploaded successfully !', 'Success');
          //this.generateForm();
        }, error => console.log(error))


        //this.toastr.success('Report uploaded successfully !', 'Success');
        //alert("Succesfully Added Product details");
      }, error => {
        console.log(error);
        this.showLoader = false;
        this.toastr.warning('Failed while uploading report !', 'Warning');
        //alert("failed while adding product details");
      })
    });

    //const docx = require("docx");
    ////const doc = new docx.Document();
    //const exporter = new docx.StreamPacker(doc);
    //const stream = exporter.pack();
  }
}


