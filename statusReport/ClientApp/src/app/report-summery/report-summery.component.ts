import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';


@Component({
  selector: 'app-report-summery',
  templateUrl: './report-summery.component.html',
  styleUrls: ['./report-summery.component.css']
})
export class ReportSummeryComponent implements OnInit {

  reportType: string = 'Monthly';
  ReportSummery: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit() {

    this.ReportSummery = this.fb.group({


    })


  }

}
