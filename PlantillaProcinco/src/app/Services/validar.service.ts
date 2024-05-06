import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import {Login} from '../Models/loginViewModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ValidarService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  Urlcorreo = this.service.urlLocalhost + 'Usuario/EnviarCorreo/';

  getcorreo(loginData: Login): Observable<any> {
    return this.http.get<any>(`${this.Urlcorreo}${loginData.usuario}`, {});

    }

}
