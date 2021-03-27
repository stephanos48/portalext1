import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-poplan-detail',
  templateUrl: './poplan-detail.component.html',
  styleUrls: ['./poplan-detail.component.css']
})
export class PoplanDetailComponent implements OnInit {
  extreme: any = '../assets/img/extreme.png';

  constructor() { }

  ngOnInit(): void {
  }

}
