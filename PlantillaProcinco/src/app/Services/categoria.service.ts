import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Categoria } from '../Models/CategoriasViewModel';
import {ServiceService} from './service.service'

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCategoria = this.service.urlLocalhost + 'Categoria/Listado';

  getCategoria() {
  return this.http.get<Categoria[]>(this.UrlCategoria);
  }
}
