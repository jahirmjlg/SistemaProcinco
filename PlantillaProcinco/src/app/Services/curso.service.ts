import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Curso } from '../Models/CursosViewModel';
import {ServiceService} from './service.service'

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCurso = this.service.urlLocalhost + 'Cursos/Listado';

  getCurso() {
  return this.http.get<Curso[]>(this.UrlCurso);
  }
}
