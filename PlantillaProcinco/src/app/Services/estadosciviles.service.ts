import { Injectable } from '@angular/core';
import {EstadoCivil} from '../Models/EstadosCivilesViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EstadoscivilesService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlEstadoCivil = this.service.urlLocalhost + 'Estadocivil/';

  getEstadoCivil() {
  return this.http.get<EstadoCivil[]>(`${this.UrlEstadoCivil}Listado`);
  }

  insertEstadoCivil(estadoC: EstadoCivil): Observable<any> {
    return this.http.post<any>(`${this.UrlEstadoCivil}EstadoCivilCrear`,estadoC);
  }

  editEstadoCivil(estadoCEdit: EstadoCivil): Observable<any> {
    return this.http.put<EstadoCivil[]>(`${this.UrlEstadoCivil}EstadoCivilEditar`,estadoCEdit);
  }

  fillEstadoCivil(id: String): Observable<any> {
    return this.http.get<EstadoCivil[]>(`${this.UrlEstadoCivil}EstadosCivilesBuscar/${id}`);
  }

  deleteEstadoCivil(ID): Observable<any> {
    return this.http.delete<EstadoCivil[]>(`${this.UrlEstadoCivil}EstadoCivilEliminar/${ID}`);
  }
}
