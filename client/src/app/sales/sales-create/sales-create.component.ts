import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { GeneralService } from 'src/app/_services/general.service';

@Component({
  selector: 'app-sales-create',
  templateUrl: './sales-create.component.html',
  styleUrls: ['./sales-create.component.css']
})
export class SalesCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  //poplan: PoPlan;
  model: any = {};
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(private generalService: GeneralService, private http: HttpClient,
    private router: Router, private Toastr: ToastrService) { }

  ngOnInit(): void {
  }

  create() {
    this.generalService.createSoPlan(this.model).subscribe(() => {
      console.log('created successfully');
    }, error => {
      this.Toastr.error(error);
    }, () => {
      this.router.navigate(['/sales']);
    });
  }

  cancel() {
    this.cancelCreate.emit(false);
    console.log('cancelled');
  }

}
