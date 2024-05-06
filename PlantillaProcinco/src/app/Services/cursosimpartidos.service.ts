import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CursosImpartidos } from '../Models/CursosImpartidos';
import {ServiceService} from './service.service'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CursosImpartidosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCursosImpMes = this.service.urlLocalhost + 'CursosImpartidos/CursosMes';



  UrlCursoImp = this.service.urlLocalhost + 'CursosImpartidos/Listado';



  getCursosImpartidos() {
  return this.http.get<CursosImpartidos[]>(this.UrlCursoImp);
  }

  getCursoPorMesData(): Observable<any[]> {
    return this.http.get<any[]>(this.UrlCursosImpMes);
  }
}
