import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { PoPlan } from 'src/app/_models/poplan';
import { GeneralService } from 'src/app/_services/general.service';

@Component({
  selector: 'app-poplan-modal',
  templateUrl: './poplan-modal.component.html',
  styleUrls: ['./poplan-modal.component.css']
})
export class PoplanModalComponent implements OnInit {
  @Output() updateSelectedPoPlan = new EventEmitter();
  poplan: PoPlan;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(public bsModalRef: BsModalRef, private generalService: GeneralService,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  updatePoPlan() {
    this.generalService.updatePoPlan(this.poplan.poPlanId, this.poplan)
      .subscribe(response => {
        console.log('Server Response: Update Successful', response);
        this.updateSelectedPoPlan.emit(this.poplan);
        this.bsModalRef.hide();
      });
  }

}
