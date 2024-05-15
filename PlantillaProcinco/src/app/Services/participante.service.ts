import { Injectable } from '@angular/core';
import {Participante} from '../Models/ParticipanteViewModel';
import {Estado} from '../Models/EstadoViewModel';

import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ServiceService } from './service.service';
import { EstadoCivil } from '../Models/EstadosCivilesViewModel';
import { Ciudad } from '../Models/CiudadViewModel';
import { FormGroup } from '@angular/forms';
import { Empresa } from '../Models/EmpresaViewModel';

@Injectable({
  providedIn: 'root'
})
export class ParticipantesService {

  constructor(private http:HttpClient, private service:ServiceService) { }

  UrlEstados = this.service.urlLocalhost + 'Estado/ddl';
  UrlEmpresas = this.service.urlLocalhost + 'Empresa/ddl';
  UrlEstadosCiviles = this.service.urlLocalhost + 'Estadocivil/ddl';
  UrlCiudadesPorEstados = this.service.urlLocalhost + 'Ciudad/ddl/';


  UrlParticipante = this.service.urlLocalhost + 'Participante/';

  getParticipante() {
  return this.http.get<Participante[]>(`${this.UrlParticipante}Listado`);
  }


  insertParticipante(Insert: Participante): Observable<any> {
    return this.http.post<any>(`${this.UrlParticipante}ParticipanteCrear`,Insert);
    }

    //EDITAR
    editParticipante(Edit: Participante): Observable<any> {
        return this.http.put<any>(`${this.UrlParticipante}ParticipanteEditar`,Edit);
        }

    //LLENAR && DETALLE
    fillParticipante(id: number): Observable<any> {
        return this.http.get<any>(`${this.UrlParticipante}ParticipanteBuscar/${id}`);
        }

    //ELIMINAR
    deleteParticipante(ID): Observable<any>{
        return this.http.delete<any>(`${this.UrlParticipante}ParticipanteEliminar/${ID}`)
        }


    //DDL
    getDdlEstados(): Observable<any> {
        return this.http.get<Estado[]>(this.UrlEstados);
    }

        //DDL
    getDdlEmpresas(): Observable<any> {
         return this.http.get<Empresa[]>(this.UrlEmpresas);
     }

            //DDL
    getDdlEstadosCiviles(): Observable<any> {
        return this.http.get<EstadoCivil[]>(this.UrlEstadosCiviles);
    }

        //DDL
    getDdlCiudades(id) {
        return this.http.get<Ciudad[]>(this.UrlCiudadesPorEstados + id);
    }



}
