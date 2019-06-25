import { Component, OnInit } from '@angular/core';
import { reportCR } from '../DTO/ReportCR';
import { ReportService } from '../services/report.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-report-cr',
  templateUrl: './report-cr.component.html',
  styleUrls: ['./report-cr.component.css']
})
export class ReportCRComponent implements OnInit {

  reportCR: reportCR[];
  reportSummery: FormGroup;
  newAttribute: any = {};

  constructor(private reportservice: ReportService, private fb: FormBuilder) { }

  ngOnInit() {

    this.reportSummery = this.fb.group({
      clientName: ['', [Validators.required]],
      //projectName: ['', [Validators.required]],
      //projectType: [''],
      //accomplishment: ['', [Validators.required]],
      //clientAwtInfo: [''],
      //offshoreTotalHrs: [''],
      //offshoreLastWeekHrs: [''],
      //offshoreCurrentWeekHrs: [''],
      //onshoreTotalHrs: [''],
      //onshoreLastWeekHrs: [''],
      //onshoreCurrentWeekHrs: [''],
      //Notes: [''],
      CRdetails: this.reportCR
    })

    //this.reportservice.getCRdetails().subscribe(res => {
    //  this.reportCR = res;
    //  console.log(res);
    //}, error => console.log(error))

  }

  addFieldValue() {
    this.reportCR.push(this.newAttribute)
    this.newAttribute = {};
  }

  deleteFieldValue(index) {
    this.reportCR.splice(index, 1);
  }


  buildActivity(): FormGroup {
    return this.fb.group({
      CRName: ['home', Validators.required],
      EstimateHrs: ['', Validators.required],
      ActualHrs: ['', Validators.required],
      Status: ['', Validators.required]
      });
  }


  buildCR(): FormGroup {
    return this.fb.group({
      Milestone: ['home', Validators.required],
      ETA: ['', Validators.required],
      
    });

  }

  //addAddress(): void {
  //  this.crac.push(this.buildAddress());
  //}


  save() {
    console.log(this.reportSummery);
    console.log('Saved: ' + JSON.stringify(this.reportSummery.value));
  }

}
