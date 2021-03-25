import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SlottedComponent } from './slotted.component';

describe('SlottedComponent', () => {
  let component: SlottedComponent;
  let fixture: ComponentFixture<SlottedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SlottedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SlottedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
