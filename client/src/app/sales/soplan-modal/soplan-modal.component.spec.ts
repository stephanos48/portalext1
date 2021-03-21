import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoplanModalComponent } from './soplan-modal.component';

describe('SoplanModalComponent', () => {
  let component: SoplanModalComponent;
  let fixture: ComponentFixture<SoplanModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SoplanModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SoplanModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
