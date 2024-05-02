import { Injectable } from '@angular/core';
import {Categoria} from '../Models/CategoriaViewModel';
import {Estado} from '../Models/EstadoViewModel';

import {HttpClient} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http:HttpClient) {}

    Url = 'https://api.thecatapi.com/v1/categories';

    getCategorias() {
      return this.http.get<Categoria[]>(this.Url);
    }


    UrlEstados = 'https://localhost:44358/Estado/Listado';

    getEstados() {
      return this.http.get<Estado[]>(this.UrlEstados);
    }

    //#region
    si = 1
    //#endregion


}
