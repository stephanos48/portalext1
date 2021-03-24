import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PoPlan } from '../_models/poplan';
import { SoPlan } from '../_models/soplan';
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

  getActualQohs() {
    return this.http.get(this.baseUrl + 'txqoh/getActualQohs');
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

  deleteTxQoh(id: number) {
    return this.http.delete(this.baseUrl + 'txqoh/deletePn' + id);
  }

  getPoPlans() {
    return this.http.get(this.baseUrl + 'poplans/getPoPlans');
  }

  getNotReceived() {
    return this.http.get(this.baseUrl + 'poplans/getNotReceived');
  }

  getReceived() {
    return this.http.get(this.baseUrl + 'poplans/getReceived');
  }

  getTransit() {
    return this.http.get(this.baseUrl + 'poplans/getTransit');
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

  updatePoPlan(id: number, poplan: PoPlan) {
    return this.http.put(this.baseUrl + 'poplans/' + id, poplan);
  }


  getSoPlans() {
    return this.http.get(this.baseUrl + 'soplans/getSoPlans');
  }

  getSoPlan(id): Observable<SoPlan> {
    return this.http.get<SoPlan>(this.baseUrl + 'soplans/' + id);
  }

  updateSoPlan(id: number, soplan: SoPlan) {
    return this.http.put(this.baseUrl + 'soplans/' + id, soplan);
  }

  createSoPlan(soplan: SoPlan) {
    return this.http.post(this.baseUrl + 'soplans/createSoPlan', soplan);
  }

  deleteSoPlan(id: number, soplan: SoPlan) {
    return this.http.post(this.baseUrl + 'soplans/' + id, soplan);
  }
  

}