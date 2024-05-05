import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import {Contra} from '../Models/loginViewModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RestablecerService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  Urlcontra = this.service.urlLocalhost + 'Usuario/RestablacerContrasena';

  postrestablecer(codigoData: Contra): Observable<any> {
    return this.http.put<any>(`${this.Urlcontra}`,codigoData);

    }
}
