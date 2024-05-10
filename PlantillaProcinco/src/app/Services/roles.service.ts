import { Injectable } from '@angular/core';
import {Role, RoleWithScreens} from '../Models/RolesViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';

import { PantallaPorRol } from '../Models/PantallasPorRolesViewModel';
import { Observable } from 'rxjs';
import { FormGroup } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class RolesService {


  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlRol = this.service.urlLocalhost + 'Rol/';


  UrlPantalla = this.service.urlLocalhost + 'Pantalla/';



        getRol() {
        return this.http.get<Role[]>(`${this.UrlRol}Listado`);
        }


       //INSERTAR

        insertRol(rolInsert: FormGroup): Observable<any> {

            console.log(rolInsert)

            return this.http.post<any>(`${this.UrlRol}RolCrear`, rolInsert);
        }

        editRol(rolEdit: FormGroup): Observable<any> {

            return this.http.put<any>(`${this.UrlRol}RolEditar`, rolEdit);
        }

        //LLENAR && DETALLE
        fillRol(id: number): Observable<any> {
            return this.http.get<any>(`${this.UrlRol}Buscar/${id}`);
            }

        //ELIMINAR
        deleteRol(ID): Observable<any>{
            return this.http.delete<any>(`${this.UrlRol}RolEliminar/${ID}`)
            }




            //PANTALLAS

            getPantallas(): Observable<{ pant_Id: number, pant_Descripcion: string }[]> {
                return this.http.get<{ pant_Id: number, pant_Descripcion: string }[]>(`${this.UrlPantalla}PantallasListado`);
              }

              getPantallasFiltro(idRoll: Number): Observable<{ pant_Id: number, pant_Descripcion: string }[]> {
                return this.http.get<{ pant_Id: number, pant_Descripcion: string }[]>(`${this.UrlPantalla}PantallasFiltro/${idRoll}`);
              }


              getPantallasPorRol(idRoll: Number): Observable<{ pant_Id: number, pant_Descripcion: string }[]> {
                return this.http.get<{ pant_Id: number, pant_Descripcion: string }[]>(`${this.UrlRol}PantallasRoles/${idRoll}`);
              }

}
