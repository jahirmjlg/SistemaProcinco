import { Injectable } from '@angular/core';
import {Role} from '../Models/RolesViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlRol = this.service.urlLocalhost + 'Rol/';

  getRol() {
  return this.http.get<Role[]>(`${this.UrlRol}Listado`);
  }

  CrearRol(RolesInsert: Role): Observable<any>{
    return this.http.post<any>(`${this.UrlRol}RolCrear`,RolesInsert);
  }

  editRol(RolesEdit : Role): Observable<any>{
    return this.http.put<any>(`${this.UrlRol}RolEditar`,RolesEdit);
  }

  deleteRol(ID): Observable<any>{
    return this.http.delete<any>(`${this.UrlRol}RolEliminar/${ID}`);
  }

}
