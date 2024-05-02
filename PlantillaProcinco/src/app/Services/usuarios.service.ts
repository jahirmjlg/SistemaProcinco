import { Injectable } from '@angular/core';
import {Usuario} from '../Models/UsuariosViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlUsuario = this.service.urlLocalhost + 'Usuario/Listado';

  getUsuario() {
  return this.http.get<Usuario[]>(this.UrlUsuario);
  }
}
