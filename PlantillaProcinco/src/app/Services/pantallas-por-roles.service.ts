import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { Observable } from 'rxjs';
import { PantallaPorRol } from '../Models/PantallasPorRolesViewModel';
@Injectable({
  providedIn: 'root'
})
export class PantallasPorRolesService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlPantalla = this.service.urlLocalhost + 'PantallaPorRol/';


  getPantallaporrRol() {
    return this.http.get<PantallaPorRol[]>(`${this.UrlPantalla}Listado`);
  }

  insertPantallaPorRol(ParoInsertar: PantallaPorRol): Observable<any> {
    return this.http.post<any>(`${this.UrlPantalla}PantallaPorRolCrear`,ParoInsertar);
  } 

  
  editPantallaPorRol(UsuarioEdit: PantallaPorRol): Observable<any>{
    return this.http.put<any>(`${this.UrlPantalla}PantallaPorRolEditar`,UsuarioEdit);
  }

  fillPantallaPorRol(id: Number): Observable<any>{
    return this.http.get<any>(`${this.UrlPantalla}PantallaPorRolBuscar/${id}`);
  }

  deletePantallaPorRol(ID): Observable<any>{
    return this.http.delete<any>(`${this.UrlPantalla}PantallaPorRolEliminar/${ID}`)
  }

}
