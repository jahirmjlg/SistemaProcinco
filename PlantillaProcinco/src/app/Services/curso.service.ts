import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Curso, Cursoo, Fill } from '../Models/CursosViewModel';
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
  UrlContenidoPorCurso = this.service.urlLocalhost + 'ContenidoPorCurso/';



        getCurso() {
        return this.http.get<Curso[]>(`${this.UrlCurso}Listado`);
        }


      //INSERTAR
    
      insertCurso(cursoInsert: Curso): Observable<any> {
        return this.http.post<any>(`${this.UrlCurso}CursosCrear`,cursoInsert);
        }

//deviuelve el id
// https://localhost:44358/Cursos/CursosCrearId

        insertCursoId(cursoInsert: Curso): Observable<any> {
          return this.http.post<any>(`${this.UrlCurso}CursosCrearId`,cursoInsert);
          }
  
        //EDITAR
        editCurso(cursoEdit: Curso): Observable<any> {
            return this.http.put<any>(`${this.UrlCurso}CursosEditar`,cursoEdit);
            }

        //LLENAR && DETALLE
        fillCurso(id: String): Observable<any> {
            return this.http.get<any>(`${this.UrlCurso}CursosBuscar/${id}`);
            }


               //LLENAR CURSOS POR CATEGORIA
               fillCursoPorCategoria(id: number): Observable<any> {
                return this.http.get<any>(`${this.UrlCurso}CursosPorCategoriaBuscar/${id}`);
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








          // PROBANDO TREEVIEWWWWWWWWWWWWWWWW
          EnviarCurso(formData: any): Observable<any> {
            return this.http.post<any>(this.UrlContenidoPorCurso  + 'Create/', formData).pipe(
              map(response => {
                return response;
              }),
            );
          }
          getFill(codigo: string): Observable<Fill> {
            return this.http.get<Fill>(`${this.UrlContenidoPorCurso  + 'Fill/' + codigo}`);
          }
          getDetalles(codigo: string): Observable<Fill> {
            return this.http.get<Fill>(`${this.UrlContenidoPorCurso  + 'FillDetalles/' + codigo}`);
          }
          EliminarCurso(ID): Observable<any>{
            return this.http.delete<any>(`${this.UrlContenidoPorCurso  + 'Delete/' + ID}`)
          }
          ActualizarCurso(formData: any): Observable<any> {
            return this.http.put<any>(this.UrlContenidoPorCurso + 'Edit/', formData);
          }
          
          

          getContenidosPorCurso(cursoId: string): Observable<any> {
            return this.http.get(`${this.UrlContenidoPorCurso}Fill/${cursoId}`);
          }




}
