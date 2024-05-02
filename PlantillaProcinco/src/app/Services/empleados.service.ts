import { Injectable } from '@angular/core';
import {Empleado} from '../Models/EmpleadosViewModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ServiceService } from './service.service';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlEmpleado = this.service.urlLocalhost + 'Empleado/Listado';

  getEmpleado() {
  return this.http.get<Empleado[]>(this.UrlEmpleado);
  }
}
