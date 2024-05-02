import { Injectable } from '@angular/core';

import {Titulo} from '../Models/TitulosViewModel';


import {HttpClient} from '@angular/common/http';

import { ServiceService } from './service.service';


@Injectable({
  providedIn: 'root'
})
export class TitulosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlTitulos = this.service.urlLocalhost + 'Titulo/Listado';

  getTitulos() {
  return this.http.get<Titulo[]>(this.UrlTitulos);
  }
}
