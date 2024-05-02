import { Injectable } from '@angular/core';

import {Estado} from '../Models/EstadoViewModel';
import {Ciudad} from '../Models/CiudadViewModel';
import {Login} from '../Models/loginViewModel';


import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

    constructor(private http:HttpClient) {}

        urlLocalhost = 'https://localhost:44358/'

        //#region General

        //#endregion

        //#region Acceso
        UrlLogin = this.urlLocalhost + 'Usuario/UsuarioLogin/';


        login(loginData: Login): Observable<any> {
            return this.http.get<any>(`${this.UrlLogin}${loginData.usuario},${loginData.contra}`, {});
          }

        //#endregion



    }