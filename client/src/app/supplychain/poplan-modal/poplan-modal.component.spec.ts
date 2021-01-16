import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PoplanModalComponent } from './poplan-modal.component';

describe('PoplanModalComponent', () => {
  let component: PoplanModalComponent;
  let fixture: ComponentFixture<PoplanModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PoplanModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PoplanModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
