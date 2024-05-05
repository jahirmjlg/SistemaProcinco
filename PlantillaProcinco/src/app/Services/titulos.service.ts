import { Injectable } from '@angular/core';
import {Titulo} from '../Models/TitulosViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class TitulosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlTitulos = this.service.urlLocalhost + 'Titulo/';

  getTitulos() {
  return this.http.get<Titulo[]>(`${this.UrlTitulos}Listado`);
  }

  insertTitulo(tituloInsert: Titulo): Observable<any> {
    return this.http.post<any>(`${this.UrlTitulos}TituloCrear`,tituloInsert);
  }

  editTitulo(tituloEdit: Titulo): Observable<any> {
    return this.http.put<any>(`${this.UrlTitulos}TituloEditar`,tituloEdit);
  }

  fillTitulo(id: Number): Observable<any>{
    return this.http.get<any>(`${this.UrlTitulos}TitulosBuscar/${id}`);
  }

  deleteTitulo(ID): Observable<any> {
    return this.http.delete<any>(`${this.UrlTitulos}TitulosEliminar/${ID}`);
  }

}
