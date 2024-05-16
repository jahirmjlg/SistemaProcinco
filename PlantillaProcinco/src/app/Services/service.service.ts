import { Injectable } from '@angular/core';

import {Estado} from '../Models/EstadoViewModel';
import {Ciudad} from '../Models/CiudadViewModel';
import {Login} from '../Models/loginViewModel';


import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';


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


        urlPreview = this.urlLocalhost + 'CursosImpartidos/Preview';

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
            return this.http.get<string>(`${this.urlPreview}/${usuario},${fechaInicio},${fechaFin}`, { responseType: 'text' as 'json' });
          }



    }
