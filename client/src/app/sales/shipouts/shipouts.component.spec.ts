import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShipoutsComponent } from './shipouts.component';

describe('ShipoutsComponent', () => {
  let component: ShipoutsComponent;
  let fixture: ComponentFixture<ShipoutsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShipoutsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShipoutsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
