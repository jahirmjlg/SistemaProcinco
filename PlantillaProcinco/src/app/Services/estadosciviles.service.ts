import { Injectable } from '@angular/core';
import {EstadoCivil} from '../Models/EstadosCivilesViewModel';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';

@Injectable({
  providedIn: 'root'
})
export class EstadoscivilesService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlEstadoCivil = this.service.urlLocalhost + 'Estadocivil/Listado';

  getEstadoCivil() {
  return this.http.get<EstadoCivil[]>(this.UrlEstadoCivil);
  }
}
