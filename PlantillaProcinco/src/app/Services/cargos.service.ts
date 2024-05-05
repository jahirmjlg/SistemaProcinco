import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cargo } from '../Models/CargosViewModel';
import { Observable } from 'rxjs';
import {ServiceService} from './service.service'


@Injectable({
  providedIn: 'root'
})
export class CargosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCargo = this.service.urlLocalhost + 'Cargo/';

  getCargo() {
  return this.http.get<Cargo[]>(`${this.UrlCargo}CargoListado`);
  }

  insertCargos(cargoInsert: Cargo): Observable<any> {
    return this.http.post<any>(`${this.UrlCargo}CargoCrear`,cargoInsert);
    }

  editCargos(cargoEditar: Cargo) {
    return this.http.put<any>(`${this.UrlCargo}CargoEditar`, cargoEditar);
  }

  fillCargos(id: String): Observable<any> {
    return this.http.get<any>(`${this.UrlCargo}CargoBuscar/${id}`);
    }

  deleteCargo(ID): Observable<any>{
    return this.http.delete<any>(`${this.UrlCargo}CargoEliminar/${ID}`)
  }
}
