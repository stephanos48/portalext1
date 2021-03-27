import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PoplanDetailComponent } from './poplan-detail.component';

describe('PoplanDetailComponent', () => {
  let component: PoplanDetailComponent;
  let fixture: ComponentFixture<PoplanDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PoplanDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PoplanDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
