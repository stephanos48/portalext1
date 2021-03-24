import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from 'src/app/_models/pagination';
import { PoPlan } from 'src/app/_models/poplan';
import { GeneralService } from 'src/app/_services/general.service';
import { environment } from 'src/environments/environment';
import { PoplanModalComponent } from '../poplan-modal/poplan-modal.component';

@Component({
  selector: 'app-received',
  templateUrl: './received.component.html',
  styleUrls: ['./received.component.css']
})
export class ReceivedComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  baseUrl = environment.apiUrl;
  poplans: PoPlan[];
  poplan: PoPlan = JSON.parse(localStorage.getItem('poplan'));
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  pagination: Pagination;
  bsModalRef: BsModalRef;

  constructor(private generalService: GeneralService, private toastr: ToastrService, http: HttpClient, private fb: FormBuilder,
    private route: ActivatedRoute, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getReceived();

    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }


  getReceived() {
    this.generalService.getReceived().subscribe((poplans: PoPlan[]) => {
      this.poplans = poplans;
    }, error => {
      console.log(error);
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.getReceived();
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

  editPoPlansModal(poplan: PoPlan) {
    const initialState = {
      poplan
    };
    this.bsModalRef = this.modalService.show(PoplanModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedPoPlan.subscribe(response => {
      console.log('Po Updated', response);
      this.toastr.success('PO updated successfully');
      }, error => {
        console.log(error);
      });
    }

}
