import { Injectable } from '@angular/core';
import {InformeEmpleado} from '../Models/InformesEmpleadosViewModel';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ServiceService } from './service.service';
import { Empleado, dropEmpleados } from '../Models/EmpleadosViewModel';
import { dropCursos } from '../Models/CursosViewModel';

@Injectable({
  providedIn: 'root'
})
export class InformeEmpleadosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlInformeEmpleado = this.service.urlLocalhost + 'InformeEmpleado/';
  UrlEmpleado = this.service.urlLocalhost + 'Empleado/ddl';
  UrlCurso = this.service.urlLocalhost + 'Cursos/ddl';

  getInformeEmpleado() {
  return this.http.get<InformeEmpleado[]>(`${this.UrlInformeEmpleado}Listado`);
  }

  getDdlEmpleado(): Observable<any> {
    return this.http.get<Empleado[]>(this.UrlEmpleado);
  }

  getDdlCurso(): Observable<any> {
    return this.http.get<dropCursos[]>(this.UrlCurso);
  }

  insertInformeEmpleado(EmplInInsert: InformeEmpleado): Observable<any> {
    return this.http.post<any>(`${this.UrlInformeEmpleado}ImformeEmpleadoCrear`,EmplInInsert);
  } 


  editInformeEmpleado(EmplInEdit: InformeEmpleado): Observable<any>{
    return this.http.put<any>(`${this.UrlInformeEmpleado}InformeEmpladoEditar`,EmplInEdit);
  }
     
  fillInformeEmpleado(id: Number): Observable<any>{
    return this.http.get<any>(`${this.UrlInformeEmpleado}InformeEmpleadoBuscar/${id}`);
  }

  
  deleteInformeEmpleado(ID): Observable<any>{
    return this.http.delete<any>(`${this.UrlInformeEmpleado}InfomeEmpleadoEliminar/${ID}`)
  }

}
