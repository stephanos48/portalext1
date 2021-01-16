import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PoplanCreateComponent } from './poplan-create.component';

describe('PoplanCreateComponent', () => {
  let component: PoplanCreateComponent;
  let fixture: ComponentFixture<PoplanCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PoplanCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PoplanCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
