import { Injectable } from '@angular/core';
import {Role} from '../Models/RolesViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlRol = this.service.urlLocalhost + 'Rol/Listado';

  getRol() {
  return this.http.get<Role[]>(this.UrlRol);
  }
}
