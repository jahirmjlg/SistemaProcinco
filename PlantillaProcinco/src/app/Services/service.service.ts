import { Injectable } from '@angular/core';

import {Estado} from '../Models/EstadoViewModel';
import {Ciudad} from '../Models/CiudadViewModel';
import {Login} from '../Models/loginViewModel';


import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Empleado } from '../Models/EmpleadosViewModel';
import { Curso } from '../Models/CursosViewModel';


interface Pantalla {
    pantalla: string;
}

@Injectable({
  providedIn: 'root'
})
export class ServiceService {


    constructor(private http:HttpClient) {}

        urlLocalhost = 'https://localhost:44358/'

        //#region General

        //#endregion

        UrlPantallasRoles = this.urlLocalhost + 'PantallaPorRol/'


        urlPreview = this.urlLocalhost + 'CursosImpartidos/';

        urlddl = this.urlLocalhost + 'Empleado/ddl';

        urlddlCursos = this.urlLocalhost + 'CursosImpartidos/ddlCursos';

        urlddlFechas = this.urlLocalhost + 'CursosImpartidos/fechasDDL';


        //#region Acceso
        UrlLogin = this.urlLocalhost + 'Usuario/UsuarioLogin/';


        login(loginData: Login): Observable<any> {
            return this.http.get<any>(`${this.UrlLogin}${loginData.usuario},${loginData.contra}`, {});
          }

          getPantallasDeRol(idRoll: Number) {
            return this.http.get<Pantalla[]>(`${this.UrlPantallasRoles}Listado/${idRoll}`);
          }




        //#endregion

        getPreviewPdfUrl(usuario:String,fechaInicio:String,fechaFin:String ): Observable<string> {
            return this.http.get<string>(`${this.urlPreview}Preview/${usuario},${fechaInicio},${fechaFin}`, { responseType: 'text' as 'json' });
          }

          getPreviewPdfcategoriaUrl(usuario:String,fechaInicio:String,fechaFin:String ): Observable<string> {
            return this.http.get<string>(`${this.urlPreview}PreviewCategorias/${usuario},${fechaInicio},${fechaFin}`, { responseType: 'text' as 'json' });
          }

          getPreviewPdfEmpleado(usuario:String,Empleado:Number ): Observable<string> {
            return this.http.get<string>(`${this.urlPreview}PreviewPorEmpleado/${usuario},${Empleado}`, { responseType: 'text' as 'json' });
          }

          getDdlEmpleados(): Observable<any> {
            return this.http.get<Empleado[]>(this.urlddl);
        }


        getDdlCursos(): Observable<any> {
            return this.http.get<Curso[]>(this.urlddlCursos);
        }

        getDdlFechas(id) {
            return this.http.get<Ciudad[]>(`${this.urlddlFechas}/${id}`);
        }


        getPreviewPdfParticipante(usuario:String,curso:Number, fecha:String ): Observable<string> {
            return this.http.get<string>(`${this.urlPreview}PreviewParticipantesFiltro/${usuario},${curso},${fecha}`, { responseType: 'text' as 'json' });
          }

    }
