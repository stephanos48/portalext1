import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { GeneralService } from 'src/app/_services/general.service';

@Component({
  selector: 'app-poplan-create',
  templateUrl: './poplan-create.component.html',
  styleUrls: ['./poplan-create.component.css']
})
export class PoplanCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  model: any = {};
  bsConfig: Partial<BsDatepickerConfig>;
  
  constructor(private generalService: GeneralService, private http: HttpClient,
    private router: Router, private Toastr: ToastrService) { }

  ngOnInit(): void {
  }

  create() {
    this.generalService.createPoPlan(this.model).subscribe(() => {
      console.log('created successfully');
    }, error => {
      this.Toastr.error(error);
    }, () => {
      this.router.navigate(['/poplan']);
    });
  }

  cancel() {
    this.cancelCreate.emit(false);
    console.log('cancelled');
  }

}
