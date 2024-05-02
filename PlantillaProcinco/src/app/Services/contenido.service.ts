import { Injectable } from '@angular/core';

import {Contenido} from '../Models/ContenidoViewModel';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

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
