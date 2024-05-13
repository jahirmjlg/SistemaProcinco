import { Injectable } from '@angular/core';
import {Titulo} from '../Models/TitulosViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class TitulosporempleadoService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlTitulos = this.service.urlLocalhost + 'Empleado/';


  getTitulos() {
  return this.http.get<Titulo[]>(`${this.UrlTitulos}Listado`);
  }

  insertTitulo(tituloInsert: Titulo): Observable<any> {
    return this.http.post<any>(`${this.UrlTitulos}EmpleadoCrear`,tituloInsert);
  }

  editTitulo(tituloEdit: Titulo): Observable<any> {
    return this.http.put<any>(`${this.UrlTitulos}EmpleadoEditar`,tituloEdit);
  }

  fillTitulo(id: Number): Observable<any>{
    return this.http.get<any>(`${this.UrlTitulos}EmpleadoEliminar/${id}`);
  }

  deleteTitulo(ID): Observable<any> {
    return this.http.delete<any>(`${this.UrlTitulos}EmpleadoBuscar/${ID}`);
  }

  getTitulosPorEmpleado() {
    return this.http.get<Titulo[]>(`${this.UrlTitulos}ListadoTitulos`);
    }


    filtrarTitulos(ID) {
        return this.http.get<Titulo[]>(`${this.UrlTitulos}FiltrarTitulos/${ID}`);
        }

//   -----------------------------------------------------------------------



            //titulos

            getTituloss(): Observable<{ titl_Id: number, titl_Descripcion: string }[]> {
              return this.http.get<{ titl_Id: number, titl_Descripcion: string }[]>(`${this.UrlTitulos}ListadoTitulos`);
            }

            getTitulosFiltro(idempll: Number): Observable<{ titl_Id: number, titl_Descripcion: string }[]> {
              return this.http.get<{ titl_Id: number, titl_Descripcion: string }[]>(`${this.UrlTitulos}FiltrarTitulos/${idempll}`);
            }


            getTitulosPorEmpleadoo(idempll: Number): Observable<{ titl_Id: number, titl_Descripcion: string }[]> {
              return this.http.get<{ titl_Id: number, titl_Descripcion: string }[]>(`${this.UrlTitulos}ListadoTitulos/${idempll}`);
            }

}
