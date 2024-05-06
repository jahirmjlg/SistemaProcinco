import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import {Codigo} from '../Models/loginViewModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompararService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  Urlcodigo = this.service.urlLocalhost + 'Usuario/ValidarCodigo/';

  getcodigo(codigoData: Codigo): Observable<any> {
    return this.http.get<any>(`${this.Urlcodigo}${codigoData.usua_VerificarCorreo}`, {});

    }

}
