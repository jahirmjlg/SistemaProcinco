import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ciudad } from '../Models/CiudadViewModel';
import {ServiceService} from './service.service'


@Injectable({
  providedIn: 'root'
})
export class CiudadService {

    constructor(private http:HttpClient, private service:ServiceService) {}

    urlLocalhost = 'https://localhost:44358/'

    //#region General

    UrlCiudades = this.service.urlLocalhost + 'Ciudad/CiudadListado';

    getCiudades() {
    return this.http.get<Ciudad[]>(this.UrlCiudades);
    }
}
