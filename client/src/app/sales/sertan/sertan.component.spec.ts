import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SertanComponent } from './sertan.component';

describe('SertanComponent', () => {
  let component: SertanComponent;
  let fixture: ComponentFixture<SertanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SertanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SertanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
