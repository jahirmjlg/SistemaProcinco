import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContenidoPorCursos } from '../Models/ContenidoPorCursosViewModel'; 
import { Observable } from 'rxjs';
import {ServiceService} from './service.service'

@Injectable({
  providedIn: 'root'
})
export class ContenidoporcursoService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlContenidoPorCurso = this.service.urlLocalhost + 'ContenidoPorCurso/';

  getContenidoPorCurso() {
    return this.http.get<ContenidoPorCursos[]>(`${this.UrlContenidoPorCurso}Listado`);
  }

  insertContenidoPorCurso(contenidoInsert: ContenidoPorCursos): Observable<any> {
    return this.http.post<any>(`${this.UrlContenidoPorCurso}ContenidoPorCursoCrear`,contenidoInsert);
  }


  editContenidoPorCurso(contenidocursoEditar: ContenidoPorCursos): Observable<any> {
    return this.http.put<any>(`${this.UrlContenidoPorCurso}ContenidoPorCursoEditar`, contenidocursoEditar);
  }

  fillContenidoPorCurso(id: String): Observable<any> {
    return this.http.get<any>(`${this.UrlContenidoPorCurso}ContenidoPorCursoBuscar/${id}`);
  }

  deleteContenidoPorCurso(ID): Observable<any>{
    return this.http.delete<any>(`${this.UrlContenidoPorCurso}ContenidoPorCursoEliminar/${ID}`)
  }

  BuscarCurso(Curso: String): Observable<any>{
    return this.http.get<any>(`${this.UrlContenidoPorCurso}CPCCursoBuscar/${Curso}`);
  }

  BuscarContenido(Contenido: String): Observable<any>{
    return this.http.get<any>(`${this.UrlContenidoPorCurso}CPCContenidoBuscar/${Contenido}`);
  }
}
