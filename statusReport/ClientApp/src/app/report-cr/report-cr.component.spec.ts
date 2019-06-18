import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportCRComponent } from './report-cr.component';

describe('ReportCRComponent', () => {
  let component: ReportCRComponent;
  let fixture: ComponentFixture<ReportCRComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportCRComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportCRComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
