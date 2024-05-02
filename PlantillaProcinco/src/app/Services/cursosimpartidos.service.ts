import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CursosImpartidos } from '../Models/CursosImpartidos';
import {ServiceService} from './service.service'

@Injectable({
  providedIn: 'root'
})
export class CursosImpartidosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCursoImp = this.service.urlLocalhost + 'CursosImpartidos/Listado';

  getCursosImpartidos() {
  return this.http.get<CursosImpartidos[]>(this.UrlCursoImp);
  }
}
