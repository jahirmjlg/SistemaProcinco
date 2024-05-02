import { Component, OnInit } from '@angular/core';
import {ServiceService} from '../../Services/service.service';
import { Estado } from 'src/app/Models/EstadoViewModel';
import {Router} from '@angular/router';

@Component({
  selector: 'app-list-estados',
  templateUrl: './list-estados.component.html',
  styleUrls: ['./list-estados.component.css']
})
export class ListEstadosComponent implements OnInit {

  estado!:Estado[];
  constructor(private service: ServiceService, private router: Router) { }

  ngOnInit(): void {

    this.service.getEstados().subscribe((Response: any)=> {
      console.log(Response.data);
      this.estado = Response.data;

    }, error=>{
      console.log(error);
    }
  )}

}
