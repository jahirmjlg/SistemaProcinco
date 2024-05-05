import { Injectable } from '@angular/core';
import {Usuario} from '../Models/UsuariosViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { Observable } from 'rxjs';
import { Role, dropRoles } from '../Models/RolesViewModel';
import { Empleado, dropEmpleados } from '../Models/EmpleadosViewModel';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlUsuario = this.service.urlLocalhost + 'Usuario/';
  UrlRoles = this.service.urlLocalhost + 'Rol/ddl';
  UrlEmpleado = this.service.urlLocalhost + 'Empleado/ddl';

  getUsuario() {
  return this.http.get<Usuario[]>(`${this.UrlUsuario}Listado`);
  }

  insertUsuario(UsuarioInsert: Usuario): Observable<any> {
    return this.http.post<any>(`${this.UrlUsuario}UsuarioCrear`,UsuarioInsert);
  } 

  editUsuario(UsuarioEdit: Usuario): Observable<any>{
    return this.http.put<any>(`${this.UrlUsuario}UsuarioEditar`,UsuarioEdit);
  }
    
  fillUsuario(id: Number): Observable<any>{
    return this.http.get<any>(`${this.UrlUsuario}Buscar/${id}`);
  }

  deleteUsuario(ID): Observable<any>{
    return this.http.delete<any>(`${this.UrlUsuario}UsuarioEliminar/${ID}`)
  }

   //DDL
   getDdlRoles(): Observable<any> {
    return this.http.get<Role[]>(this.UrlRoles);
  }

  getDdlEmpleado(): Observable<any> {
    return this.http.get<Empleado[]>(this.UrlEmpleado);
  }

}
