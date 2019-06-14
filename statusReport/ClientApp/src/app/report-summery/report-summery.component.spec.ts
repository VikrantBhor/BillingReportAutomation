import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportSummeryComponent } from './report-summery.component';

describe('ReportSummeryComponent', () => {
  let component: ReportSummeryComponent;
  let fixture: ComponentFixture<ReportSummeryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportSummeryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportSummeryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
