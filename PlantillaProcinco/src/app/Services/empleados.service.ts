import { Injectable } from '@angular/core';
import {Empleado} from '../Models/EmpleadosViewModel';
import {Estado} from '../Models/EstadoViewModel';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ServiceService } from './service.service';
import { Cargo } from '../Models/CargosViewModel';
import { EstadoCivil } from '../Models/EstadosCivilesViewModel';
import { Ciudad } from '../Models/CiudadViewModel';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlEstados = this.service.urlLocalhost + 'Estado/ddl';
  UrlCargos = this.service.urlLocalhost + 'Cargo/ddl';
  UrlEstadosCiviles = this.service.urlLocalhost + 'Estadocivil/ddl';
  UrlCiudadesPorEstados = this.service.urlLocalhost + 'Ciudad/ddl/';


  UrlEmpleado = this.service.urlLocalhost + 'Empleado/';

  getEmpleado() {
  return this.http.get<Empleado[]>(`${this.UrlEmpleado}Listado`);
  }


  insertEmpleado(empleadoInsert: Empleado): Observable<any> {
    return this.http.post<any>(`${this.UrlEmpleado}EmpleadoCrear`,empleadoInsert);
    }

    //EDITAR
    editEmpleado(empleadoEdit: Empleado): Observable<any> {
        return this.http.put<any>(`${this.UrlEmpleado}EmpleadoEditar`,empleadoEdit);
        }

    //LLENAR && DETALLE
    fillEmpleado(id: number): Observable<any> {
        return this.http.get<any>(`${this.UrlEmpleado}EmpleadoBuscar/${id}`);
        }

    //ELIMINAR
    deleteEmpleado(ID): Observable<any>{
        return this.http.delete<any>(`${this.UrlEmpleado}EmpleadoEliminar/${ID}`)
        }


    //DDL
    getDdlEstados(): Observable<any> {
        return this.http.get<Estado[]>(this.UrlEstados);
    }

        //DDL
    getDdlCargos(): Observable<any> {
         return this.http.get<Cargo[]>(this.UrlCargos);
     }

            //DDL
    getDdlEstadosCiviles(): Observable<any> {
        return this.http.get<EstadoCivil[]>(this.UrlEstadosCiviles);
    }

        //DDL
    getDdlCiudades(id) {
        return this.http.get<Ciudad[]>(this.UrlCiudadesPorEstados + id);
    }



}
