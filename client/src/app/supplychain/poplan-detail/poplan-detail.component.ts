import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PoPlan } from 'src/app/_models/poplan';

@Component({
  selector: 'app-poplan-detail',
  templateUrl: './poplan-detail.component.html',
  styleUrls: ['./poplan-detail.component.css']
})
export class PoplanDetailComponent implements OnInit {
  extreme: any = '../assets/img/extreme.png';
  poplan: PoPlan;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.poplan = data.poplan;
  })
}

}
