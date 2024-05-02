import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cargo } from '../Models/CargosViewModel';
import {ServiceService} from './service.service'


@Injectable({
  providedIn: 'root'
})
export class CargosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCargo = this.service.urlLocalhost + 'Cargo/CargoListado';

  getCargo() {
  return this.http.get<Cargo[]>(this.UrlCargo);
  }
}
