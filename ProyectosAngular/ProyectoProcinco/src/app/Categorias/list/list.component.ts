import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { Categoria } from 'src/app/Models/CategoriaViewModel';
import {ServiceService} from '../../Services/service.service';



@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  categoria!:Categoria[];
  constructor(private service: ServiceService, private router: Router) { }

  ngOnInit(): void {

    this.service.getCategorias().subscribe((data: any)=> {
      console.log(data);
      this.categoria = data;

    }, error=>{
      console.log(error);
    }
  )}

}
