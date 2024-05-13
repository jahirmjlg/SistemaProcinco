import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CursosImpartidos } from '../Models/CursosImpartidos';
import {ServiceService} from './service.service'
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root'
})
export class CursosImpartidosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCursosImpMes = this.service.urlLocalhost + 'CursosImpartidos/CursosMes';



  UrlCursoImp = this.service.urlLocalhost + 'CursosImpartidos/';



  getCursosImpartidos() {
  return this.http.get<CursosImpartidos[]>(`${this.UrlCursoImp}Listado`);
  }

  getCursoPorMesData(): Observable<any[]> {
    return this.http.get<any[]>(this.UrlCursosImpMes);
  }

  insertCursosIm(cursosImpatidoscrear: CursosImpartidos): Observable<any>{
    return this.http.post<any>(`${this.UrlCursoImp}Crear`,cursosImpatidoscrear);
  }

  editCursosIm(cursosImpartidoseditar: CursosImpartidos): Observable<any>{
    return this.http.put<any>(`${this.UrlCursoImp}Editar`,cursosImpartidoseditar)
  }

  fillCursosIm(id: Number): Observable<any>{
    return this.http.get<any>(`${this.UrlCursoImp}Buscar/${id}`);
  }

  deleteCursosIm(ID): Observable<any>{
    return this.http.delete<any>(`${this.UrlCursoImp}Eliminar/${ID}`);
  }


  BuscarEmpleado(DNI: String): Observable<any>{
    return this.http.get<any>(`${this.UrlCursoImp}BuscarEmpleado/${DNI}`);
  }

  BuscarCurso(Curso: String): Observable<any>{
    return this.http.get<any>(`${this.UrlCursoImp}BuscarCurso/${Curso}`);
  }



  BuscarParticipantes(Curso: String) {
    return this.http.get<CursosImpartidos[]>(`${this.UrlCursoImp}BuscarParticipante/${Curso}`);
    }


}
