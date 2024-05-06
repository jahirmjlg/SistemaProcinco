import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Categoria } from '../Models/CategoriasViewModel';
import {ServiceService} from './service.service'
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCurso = this.service.urlLocalhost + 'Cursos/cargarImagen';


  UrlCategoria = this.service.urlLocalhost + 'Categoria/';

  getCategoria() {
  return this.http.get<Categoria[]>(`${this.UrlCategoria}Listado`);
  }


  //INSERTAR

  insertCategoria(categoriaInsert: Categoria): Observable<any> {
    return this.http.post<any>(`${this.UrlCategoria}CategoriaCrear`,categoriaInsert);
    }

    //EDITAR
    editCategoria(categoriaEdit: Categoria): Observable<any> {
        return this.http.put<any>(`${this.UrlCategoria}CategoriaEditar`,categoriaEdit);
        }

    //LLENAR && DETALLE
    fillCategoria(id: number): Observable<any> {
        return this.http.get<any>(`${this.UrlCategoria}CategoriaBuscar/${id}`);
        }

    //ELIMINAR
    deleteCategoria(ID): Observable<any>{
        return this.http.delete<any>(`${this.UrlCategoria}CategoriaEliminar/${ID}`)
        }

        upload(file: any): Observable<any>{
            console.log('file: ' + file)
            return this.http.post<Categoria[]>(this.UrlCurso, file).pipe(
                map(response => {
                    return response;
                  }),
            );
          }


}
