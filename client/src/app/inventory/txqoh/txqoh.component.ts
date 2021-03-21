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
  selector: 'app-txqoh',
  templateUrl: './txqoh.component.html',
  styleUrls: ['./txqoh.component.css']
})
export class TxqohComponent implements OnInit {
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
  
  /*
  @Output() cancelCreate = new EventEmitter();
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(MatTable, {static: true}) table: MatTable<any>;
  @ViewChild('filter', { static: true }) filter: ElementRef;

  displayedColumns: string [] = [ 'Pn', 'PartDescription', 'Qoh', 'Location', 'Notes' ];
  txqohs: TxQoh[];
  dataSource = new MatTableDataSource();
  baseUrl = environment.apiUrl;
  txqoh: TxQoh = JSON.parse(localStorage.getItem('txqoh'));
  createForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  createMode = false;
  scrumParams: any = {};
  pagination: Pagination;
  bsModalRef: BsModalRef;
  //ResponsibleList: Responsible [];
  isTxQohDataLoaded: boolean;
  statusList = [{value: 'new', display: 'New'}, {value: 'inprocess', display: 'InProcess'}, {value: 'late', display: 'Late'}];
*/

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

/*
  createTxQohForm() {
    this.createForm = this.fb.group({
      pn: ['', Validators.required],
      partDescription: ['', Validators.required],
      qoh: ['', Validators.required],
      location: ['', Validators.required],
      notes: ['',],
    });
  }

  createTxQoh() {
    if (this.createForm.valid) {
      this.txqoh = Object.assign({}, this.createForm.value);
      this.generalService.createTxQoh(this.txqoh).subscribe(() => {
        this.toastr.success('Customer created successfully');
      }, error => {
        this.toastr.error(error);
      });
    }
    // this.authService.register(this.model).subscribe(() => {
    //   this.alertify.success('registration successful');
    // }, error => {
    //   this.alertify.error(error);
    // });
    // console.log(this.registerForm.value);
  }
*/

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

  /*
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getTxQohs() {
    this.generalService.getTxQohs().subscribe((txqohs: TxQoh[]) => {
      //this.generalService.getResponsibles().subscribe((Response1: Responsible[]) => {
        //this.ResponsibleList = Response1;
        this.isTxQohDataLoaded = true;
        this.txqohs = this.formatData(txqohs);
        this.dataSource.data = this.txqohs;
      //});
         // this.scrums = scrums;
    }, error => {
      console.log(error);
    });
  }

  // to loop thru responsibles and show name instead of id
  formatData(txqohs: TxQoh[]): TxQoh[] {
    for (let i = 0 ; i < txqohs.length; i++)    {
    //txqohs[i].responsible =  this.ResponsibleList.filter(x => x.responsibleId === txqohs[i].responsibleId)[0].employeeName;
    }
    return txqohs;
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

  // to truncate date to just MM-DD-YYYY
  formatDate(date: string): string {
    const parsedDate = new Date(date);
  const formattedDate = (parsedDate.getMonth() + 1) + '-' + parsedDate.getDate() + '-' + parsedDate.getFullYear();
    return formattedDate;
  }

  editTxQohsModal(txqoh: TxQoh) {
  //txqoh.dueDate = new Date(txqoh.dueDate);
  // scrum.dueDate =   this.formatDate(scrum.dueDate);
    const initialState = {
      txqoh
    };
    this.bsModalRef = this.modalService.show(TxqohModalComponent, {initialState});
    this.bsModalRef.content.updateSelectedScrum.subscribe(response => {
      console.log('UPDATED QOH', response);
      //this.alertify.success('TxQoh updated successfully');
      }, error => {
        console.log(error);
      });
    }
*/

