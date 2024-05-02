import { Injectable } from '@angular/core';

import {InformeEmpleado} from '../Models/InformesEmpleadosViewModel';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

import { ServiceService } from './service.service';

@Injectable({
  providedIn: 'root'
})
export class InformeEmpleadosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlInformeEmpleado = this.service.urlLocalhost + 'InformeEmpleado/Listado';

  getInformeEmpleado() {
  return this.http.get<InformeEmpleado[]>(this.UrlInformeEmpleado);
  }
}
