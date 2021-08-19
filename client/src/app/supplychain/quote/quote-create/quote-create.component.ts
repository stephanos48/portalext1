import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { Supplier } from 'src/app/_models/supplier';
import { GeneralService } from 'src/app/_services/general.service';

@Component({
  selector: 'app-quote-create',
  templateUrl: './quote-create.component.html',
  styleUrls: ['./quote-create.component.css']
})
export class QuoteCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  model: any = {};
  bsConfig: Partial<BsDatepickerConfig>;
  supplierList: Supplier[];

  constructor(private generalService: GeneralService, private http: HttpClient,
    private router: Router, private Toastr: ToastrService) { }

  ngOnInit(): void {
    this.generalService.getSuppliers().subscribe((data: Supplier[]) => {this.supplierList = data; });
    this.bsConfig = {
      containerClass: 'theme-red'
    };
  }

  create() {
    this.generalService.createQuote(this.model).subscribe(() => {
      console.log('created successfully');
    }, error => {
      this.Toastr.error(error);
    }, () => {
      this.router.navigate(['/quote']);
    });
  }

  cancel() {
    this.cancelCreate.emit(false);
    console.log('cancelled');
  }

}
