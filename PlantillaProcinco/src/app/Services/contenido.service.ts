import { Injectable } from '@angular/core';
import {Contenido} from '../Models/ContenidoViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContenidoService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlContenido = this.service.urlLocalhost + 'Contenido/';

  getContenido() {
  return this.http.get<Contenido[]>(`${this.UrlContenido}Listado`);
  }

  insertContenido(contenidoInsert: Contenido): Observable<any> {
  return this.http.post<any>(`${this.UrlContenido}ContenidoCrear`,contenidoInsert);
  } 

  editContenido(ContenidoEdit: Contenido): Observable<any>{
  return this.http.put<any>(`${this.UrlContenido}ContenidoEditar`,ContenidoEdit);
  }

  fillContenido(id: Number): Observable<any>{
    return this.http.get<any>(`${this.UrlContenido}ContenidoBuscar/${id}`);
  }

  deleteContenido(ID): Observable<any>{
    return this.http.delete<any>(`${this.UrlContenido}ContenidoEliminar/${ID}`)
  }

}
