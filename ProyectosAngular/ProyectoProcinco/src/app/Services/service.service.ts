import { Injectable } from '@angular/core';
import {Categoria} from '../Models/CategoriaViewModel';
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


}
