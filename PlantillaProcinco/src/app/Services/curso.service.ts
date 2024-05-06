import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Curso } from '../Models/CursosViewModel';
import {ServiceService} from './service.service'
import { Observable, map } from 'rxjs';
import { Categoria } from '../Models/CategoriasViewModel';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCategorias = this.service.urlLocalhost + 'Categoria/ddl';

  UrlCurso = this.service.urlLocalhost + 'Cursos/';


        getCurso() {
        return this.http.get<Curso[]>(`${this.UrlCurso}Listado`);
        }


      //INSERTAR

      insertCurso(cursoInsert: Curso): Observable<any> {
        return this.http.post<any>(`${this.UrlCurso}CursosCrear`,cursoInsert);
        }

        //EDITAR
        editCurso(cursoEdit: Curso): Observable<any> {
            return this.http.put<any>(`${this.UrlCurso}CursosEditar`,cursoEdit);
            }

        //LLENAR && DETALLE
        fillCurso(id: String): Observable<any> {
            return this.http.get<any>(`${this.UrlCurso}CursosBuscar/${id}`);
            }

        //ELIMINAR
        deleteCurso(ID): Observable<any>{
            return this.http.delete<any>(`${this.UrlCurso}CursosEliminar/${ID}`)
            }


        //DDL
        getDdlCategorias(): Observable<any> {
            return this.http.get<Categoria[]>(this.UrlCategorias);
        }


        //CARGA DE IMAGENES
        upload(file: any): Observable<any>{
            return this.http.post<Curso[]>(this.UrlCurso + 'cargarImagen', file).pipe(
                map(response => {
                    return response;
                  }),
            );
          }


}
