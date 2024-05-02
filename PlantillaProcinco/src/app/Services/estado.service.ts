import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Estado } from '../Models/EstadoViewModel';

import {ServiceService} from './service.service'

@Injectable({
  providedIn: 'root'
})
export class EstadoService {

    constructor(private http:HttpClient, private service:ServiceService) {}

    //#region General

    UrlEstados = this.service.urlLocalhost + 'Estado/Listado';

    getEstados() {
    return this.http.get<Estado[]>(this.UrlEstados);
    }
}
