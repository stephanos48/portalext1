import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { SoPlan } from 'src/app/_models/soplan';
import { GeneralService } from 'src/app/_services/general.service';

@Component({
  selector: 'app-soplan-modal',
  templateUrl: './soplan-modal.component.html',
  styleUrls: ['./soplan-modal.component.css']
})
export class SoplanModalComponent implements OnInit {
  @Output() updateSelectedSoPlan = new EventEmitter();
  soplan: SoPlan;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(public bsModalRef: BsModalRef, private generalService: GeneralService,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }
  
  updateSoPlan() {
    this.generalService.updateSoPlan(this.soplan.soPlanId, this.soplan)
      .subscribe(response => {
        console.log('Server Response: Update Successful', response);
        this.updateSelectedSoPlan.emit(this.soplan);
        this.bsModalRef.hide();
      });
  }


}
