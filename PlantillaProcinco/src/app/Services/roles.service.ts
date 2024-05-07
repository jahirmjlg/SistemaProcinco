import { Injectable } from '@angular/core';
import {Role} from '../Models/RolesViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { PantallasPorRolesView } from '../Models/PantallasPorRolesViewModel';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class RolesService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlRol = this.service.urlLocalhost + 'Rol/Listado';

  UrlPantallasRoles = this.service.urlLocalhost + 'PantallaPorRol/'


        getRol() {
        return this.http.get<Role[]>(this.UrlRol);
        }


       //INSERTAR

       insertRol(rolInsert: Role): Observable<any> {
        return this.http.post<any>(`${this.UrlRol}CursosCrear`,rolInsert);
        }

        //EDITAR
        editRol(rolEdit: Role): Observable<any> {
            return this.http.put<any>(`${this.UrlRol}RolEditar`,rolEdit);
            }

        //LLENAR && DETALLE
        fillRol(id: number): Observable<any> {
            return this.http.get<any>(`${this.UrlRol}RolBuscar/${id}`);
            }

        //ELIMINAR
        deleteRol(ID): Observable<any>{
            return this.http.delete<any>(`${this.UrlRol}RolEliminar/${ID}`)
            }



}
