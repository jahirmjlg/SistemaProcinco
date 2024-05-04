import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ciudad } from '../Models/CiudadViewModel';
import {ServiceService} from './service.service';
import { Observable } from 'rxjs';
import { Estado } from '../Models/EstadoViewModel';


@Injectable({
  providedIn: 'root'
})
export class CiudadService {

    constructor(private http:HttpClient, private service:ServiceService) {}

    //#region General
    UrlEstados = this.service.urlLocalhost + 'Estado/ddl';


    UrlCiudades = this.service.urlLocalhost + 'Ciudad/';

    //LISTAR
    getCiudades() {
    return this.http.get<Ciudad[]>(`${this.UrlCiudades}CiudadListado`);
    }

    //INSERTAR

    insertCiudades(ciudadInsert: Ciudad): Observable<any> {
    return this.http.post<any>(`${this.UrlCiudades}CiudadCrear`,ciudadInsert);
    }

    //EDITAR
    editCiudades(ciudadEdit: Ciudad): Observable<any> {
        return this.http.put<any>(`${this.UrlCiudades}CiudadEditar`,ciudadEdit);
        }

    //LLENAR && DETALLE
    fillCiudad(id: String): Observable<any> {
        return this.http.get<any>(`${this.UrlCiudades}CiudadBuscar/${id}`);
        }

    //ELIMINAR
    deleteCiudad(ID): Observable<any>{
        return this.http.delete<any>(`${this.UrlCiudades}CiudadEliminar/${ID}`)
        }


    //DDL
    getDdlEstados(): Observable<any> {
        return this.http.get<Estado[]>(this.UrlEstados);
    }

}

