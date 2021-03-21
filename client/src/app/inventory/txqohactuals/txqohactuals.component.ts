import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Output, EventEmitter, ViewChild, ChangeDetectorRef, OnDestroy, AfterViewInit,
  Inject, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Pagination } from 'src/app/_models/pagination';
import { environment } from 'src/environments/environment';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { MatHeaderRow } from '@angular/material/table';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatDialog } from '@angular/material/dialog';
import { MatDialogRef } from '@angular/material/dialog';
import { MatInput } from '@angular/material/input';
import { MatFormField } from '@angular/material/form-field';
import { TxQohActual } from 'src/app/_models/txqohactual';
import { GeneralService } from 'src/app/_services/general.service';
import { ToastrService } from 'ngx-toastr';
import { TxqohModalComponent } from '../txqoh-modal/txqoh-modal.component';
import { TxQoh } from 'src/app/_models/txqoh';

@Component({
  selector: 'app-txqohactuals',
  templateUrl: './txqohactuals.component.html',
  styleUrls: ['./txqohactuals.component.css']
})
export class TxqohactualsComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  baseUrl = environment.apiUrl;
  txqohactuals: TxQohActual[];
  txqohactual: TxQohActual = JSON.parse(localStorage.getItem('txqohactual'));
  txqohs: TxQoh[];
  txqoh: TxQoh = JSON.parse(localStorage.getItem('txqoh'));
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  customerParams: any = {};
  pagination: Pagination;
  bsModalRef: BsModalRef;

  constructor(private generalService: GeneralService, private toastr: ToastrService, http: HttpClient, private fb: FormBuilder,
    private route: ActivatedRoute, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getTxQohs();

    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  
  getActualQohs() {
    this.generalService.getActualQohs().subscribe((txqohactual: TxQohActual[]) => {
      this.txqohactuals = txqohactual;
    }, error => {
      console.log(error);
    });
  }

  getTxQohs() {
    this.generalService.getTxQohs().subscribe((txqohs: TxQohActual[]) => {
      this.txqohactuals = txqohs;
    }, error => {
      console.log(error);
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.getTxQohs();
  }
/*
  resetFilters() {
    this.customerParams.country = this.txqoh.country === 'USA';
    this.getCustomers();
  }
*/

  createToggle() {
    this.createMode = true;
  }

  cancelCreateMode(createMode: boolean) {
    this.createMode = createMode;
  }

  
  cancel() {
    this.cancelCreate.emit(false);
  }

  editTxQohsModal(txqoh: TxQoh) {
    const initialState = {
      txqoh
    };
    this.bsModalRef = this.modalService.show(TxqohModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedTxQoh.subscribe(response => {
      console.log('UPDATED QOH', response);
      this.toastr.success('Customer updated successfully');
      }, error => {
        console.log(error);
      });
    }
  }


