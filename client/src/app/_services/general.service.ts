import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PoPlan } from '../_models/poplan';
import { TxQoh } from '../_models/txqoh';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {
  baseUrl = environment.apiUrl;
  formData: TxQoh;
  formData1: PoPlan;

  constructor(private http: HttpClient) { }

  Form: FormGroup = new FormGroup({
    $key: new FormControl(null),
    pn: new FormControl(''),
    partDescription: new FormControl(''),
    qoh: new FormControl(''),
    location: new FormControl(''),
    notes: new FormControl('')
  });

  /*getResponsibles() {
    return this.http.get(this.baseUrl + 'responsibles/getResponsibles');
  }*/

  getTxQohs() {
    return this.http.get(this.baseUrl + 'txqoh/getTxQohs');
  }

  updateTxQoh(id: number, txqoh: TxQoh) {
    return this.http.put(this.baseUrl + 'txqoh/' + id, txqoh);
  }

  createTxQoh(txqoh: TxQoh) {
    return this.http.post(this.baseUrl + 'txqoh/createTxQoh', txqoh);
  }

  getTxQoh(id): Observable<TxQoh> {
    return this.http.get<TxQoh>(this.baseUrl + 'txqoh/' + id);
  }

  deleteTxQoh(id: number, txqoh: TxQoh) {
    return this.http.post(this.baseUrl + 'txqoh/' + id, txqoh);
  }



  getPoPlans() {
    return this.http.get(this.baseUrl + 'poplans/getPoPlans');
  }

  updatePoPlan(id: number, poplan: PoPlan) {
    return this.http.put(this.baseUrl + 'poplans/' + id, poplan);
  }

  createPoPlan(poplan: PoPlan) {
    return this.http.post(this.baseUrl + 'poplans/createPoPlan', poplan);
  }

  getPoPlan(id): Observable<PoPlan> {
    return this.http.get<PoPlan>(this.baseUrl + 'poplans/' + id);
  }

  deletePoPlan(id: number, poplan: PoPlan) {
    return this.http.post(this.baseUrl + 'poplans/' + id, poplan);
  }

  

}