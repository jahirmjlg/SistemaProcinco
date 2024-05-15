import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Categoria } from '../Models/CategoriasViewModel';
import {ServiceService} from './service.service'
import { Observable, map } from 'rxjs';
import { Empresa } from '../Models/EmpresaViewModel';
import { FormGroup } from '@angular/forms';
import { Ciudad } from '../Models/CiudadViewModel';
import { Estado } from '../Models/EstadoViewModel';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlCurso = this.service.urlLocalhost + 'Cursos/cargarImagen';
  UrlEmpresaddl = this.service.urlLocalhost + 'Empresa/ddl';
  UrlCategoria = this.service.urlLocalhost + 'Categoria/';

  UrlEstados = this.service.urlLocalhost + 'Estado/ddl';
  UrlCiudadesPorEstados = this.service.urlLocalhost + 'Ciudad/ddl/';

  UrlEmpresa = this.service.urlLocalhost + 'Empresa/';



        //DDL
        getDdlEmpresas(): Observable<any> {
            return this.http.get<Categoria[]>(this.UrlEmpresaddl);
        }



    getEmpresas() {
        return this.http.get<Empresa[]>(`${this.UrlEmpresa}Listado`);
        }


        insertEmpresa(Insert: Empresa): Observable<any> {

            return this.http.post<any>(`${this.UrlEmpresa}EmpresaCrear`, Insert);
        }

        editEmpresa(Edit: Empresa): Observable<any> {

            return this.http.put<any>(`${this.UrlEmpresa}EmpresaEditar`, Edit);
        }

        //LLENAR && DETALLE
        fillEmpresa(id: number): Observable<any> {
            return this.http.get<any>(`${this.UrlEmpresa}EmpresaBuscar/${id}`);
            }

        //ELIMINAR
        deleteEmpresa(ID): Observable<any>{
            return this.http.delete<any>(`${this.UrlEmpresa}EmpresaEliminar/${ID}`)
            }



            getDdlEstados(): Observable<any> {
                return this.http.get<Estado[]>(this.UrlEstados);
            }

            getDdlCiudades(id) {
                return this.http.get<Ciudad[]>(this.UrlCiudadesPorEstados + id);
            }

}
