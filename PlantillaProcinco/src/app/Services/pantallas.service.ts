import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { ServiceService } from './service.service';
import { Observable } from 'rxjs';
import { Pantalla } from '../Models/PantallasViewModel';
@Injectable({
  providedIn: 'root'
})
export class PantallasService {

  constructor(private http:HttpClient, private service:ServiceService) { }


  UrlPantalla = this.service.urlLocalhost + 'Pantalla/';

  getPantalla() {
    return this.http.get<Pantalla[]>(`${this.UrlPantalla}PantallasListado`);
    }

}
