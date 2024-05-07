import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Curso } from '../Models/CursosViewModel';
import {ServiceService} from './service.service'
import { Observable, map } from 'rxjs';
import { PantallasPorRolesView } from '../Models/PantallasPorRolesViewModel';

@Injectable({
  providedIn: 'root'
})
export class PantallasPorRolesService {

  constructor(private http:HttpClient, private service:ServiceService) { }


//   UrlPantallasRol = this.service.urlLocalhost + 'Cursos/';


        // getPantallasRoles() {
        // return this.http.get<Curso[]>(`${this.UrlPantallasRol}Listado`);
        // }


    //   //INSERTAR

    //   insertPantallasRoles(cursoInsert: Curso): Observable<any> {
    //     return this.http.post<any>(`${this.UrlPantallasRol}CursosCrear`,cursoInsert);
    //     }

    //     //EDITAR
    //     editPantallasRoles(cursoEdit: Curso): Observable<any> {
    //         return this.http.put<any>(`${this.UrlPantallasRol}CursosEditar`,cursoEdit);
    //         }

    //     //LLENAR && DETALLE
    //     fillPantallasRoles(id: String): Observable<any> {
    //         return this.http.get<any>(`${this.UrlPantallasRol}CursosBuscar/${id}`);
    //         }

    //     //ELIMINAR
    //     deletePantallasRoles(ID): Observable<any>{
    //         return this.http.delete<any>(`${this.UrlPantallasRol}CursosEliminar/${ID}`)
    //         }


}
