import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Estado } from '../Models/EstadoViewModel';
import { Observable } from 'rxjs';
import {ServiceService} from './service.service'

@Injectable({
  providedIn: 'root'
})
export class EstadoService {

    constructor(private http:HttpClient, private service:ServiceService) {}

    //#region General

    UrlEstados = this.service.urlLocalhost + 'Estado/';

    getEstados() {
    return this.http.get<Estado[]>(`${this.UrlEstados}Listado`);
    }


    insertEstados(estadoInsert: Estado): Observable<any> {
      return this.http.post<any>(`${this.UrlEstados}EstadoCrear`,estadoInsert);
      }
  
      //EDITAR
      editEstados(estadoEdit: Estado): Observable<any> {
          return this.http.put<any>(`${this.UrlEstados}EstadoEditar`,estadoEdit);
          }
  
      //LLENAR && DETALLE
      fillEstado(id: String): Observable<any> {
          return this.http.get<any>(`${this.UrlEstados}EstadoBuscar/${id}`);
          }
  
      //ELIMINAR
      deleteEstado(ID): Observable<any>{
          return this.http.delete<any>(`${this.UrlEstados}EstadoEliminar/${ID}`)
          }

}
