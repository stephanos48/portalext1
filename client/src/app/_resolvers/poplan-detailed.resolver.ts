import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { PoPlan } from '../_models/poplan';
import { GeneralService } from '../_services/general.service';

@Injectable({
    providedIn: 'root'
})
export class PoPlanDetailedResolver implements Resolve<PoPlan> {

    constructor(private generalService: GeneralService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<PoPlan> {
        return this.generalService.getPoPlan(route.paramMap.get('id'));
    }

} 