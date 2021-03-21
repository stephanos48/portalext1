import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {
  jap: any = '../assets/img/jap.jpg';
  
  constructor() { }

  ngOnInit(): void {
  }

}
