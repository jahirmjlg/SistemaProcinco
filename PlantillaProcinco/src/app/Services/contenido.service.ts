import { Injectable } from '@angular/core';
import {Contenido} from '../Models/ContenidoViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { Observable } from 'rxjs';
import { Categoria } from '../Models/CategoriasViewModel';

@Injectable({
  providedIn: 'root'
})
export class ContenidoService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlContenido = this.service.urlLocalhost + 'Contenido/';
  UrlCategorias = this.service.urlLocalhost + 'Categoria/ddl';
      //DDL
      getDdlCategorias(): Observable<any> {
        return this.http.get<Categoria[]>(this.UrlCategorias);
    }
  getContenido() {
  return this.http.get<Contenido[]>(`${this.UrlContenido}Listado`);
  }
        //LLENAR CONTENIDOS POR CATEGORIA
        fillContenidoPorCategoria(id: number): Observable<any> {
                                      //  https://localhost:44358/Contenido/ContenidoPorCategoriaBuscar/3

                                   
          return this.http.get<any>(`${this.UrlContenido}ContenidoPorCategoriaBuscar/${id}`);
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
