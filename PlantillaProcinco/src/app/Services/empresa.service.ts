import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Categoria } from '../Models/CategoriasViewModel';
import {ServiceService} from './service.service'
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCurso = this.service.urlLocalhost + 'Cursos/cargarImagen';
  UrlEmpresa = this.service.urlLocalhost + 'Empresa/ddl';


  UrlCategoria = this.service.urlLocalhost + 'Categoria/';


        //DDL
        getDdlEmpresas(): Observable<any> {
            return this.http.get<Categoria[]>(this.UrlEmpresa);
        }


}
