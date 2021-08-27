import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from 'src/app/_models/pagination';
import { SoPlan } from 'src/app/_models/soplan';
import { GeneralService } from 'src/app/_services/general.service';
import { ConfirmService } from '../../_services/confirm.service';
import { environment } from 'src/environments/environment';
import { SoplanModalComponent } from '../soplan-modal/soplan-modal.component';

@Component({
  selector: 'app-sales-list',
  templateUrl: './sales-list.component.html',
  styleUrls: ['./sales-list.component.css']
})
export class SalesListComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  baseUrl = environment.apiUrl;
  soplans: SoPlan[];
  soplan: SoPlan = JSON.parse(localStorage.getItem('soplan'));
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  pagination: Pagination;
  bsModalRef: BsModalRef;

  constructor(private generalService: GeneralService, private toastr: ToastrService, http: HttpClient, private fb: FormBuilder,
    private route: ActivatedRoute, private modalService: BsModalService, private confirmService: ConfirmService) { }

  ngOnInit(): void {
    this.getOpenSoPlans();
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  getOpenSoPlans() {
    this.generalService.getOpenSoPlans().subscribe((soplans: SoPlan[]) => {
      this.soplans = soplans;
    }, error => {
      console.log(error);
    });
  }

  deleteSoPlan(id: number) {
    this.confirmService.confirm('Confirm delete message', 'This cannot be undone').subscribe(result => {
      if (result) {
        this.generalService.deleteSoPlan(id).subscribe(() => {
          this.soplans.splice(this.soplans.findIndex(m => m.soPlanId === id), 1);
        })
      }
    })
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.getOpenSoPlans();
  }

  createToggle() {
    this.createMode = true;
  }

  cancelCreateMode(createMode: boolean) {
    this.createMode = createMode;
  }

  cancel() {
    this.cancelCreate.emit(false);
  }

  editSoPlansModal(soplan: SoPlan) {
    const initialState = {
      soplan
    };
    this.bsModalRef = this.modalService.show(SoplanModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedSoPlan.subscribe(response => {
      console.log('So Updated', response);
      this.toastr.success('SO updated successfully');
      }, error => {
        console.log(error);
      });
    }

}
