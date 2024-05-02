import { Injectable } from '@angular/core';
import {Contenido} from '../Models/ContenidoViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';

@Injectable({
  providedIn: 'root'
})
export class ContenidoService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlContenido = this.service.urlLocalhost + 'Contenido/Listado';

  getContenido() {
  return this.http.get<Contenido[]>(this.UrlContenido);
  }
}
