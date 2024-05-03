import { Component, OnInit } from '@angular/core';
import {CiudadService} from '../../Services/ciudad.service';
//
import { Ciudad } from 'src/app/Models/CiudadViewModel';
import {Router} from '@angular/router';

import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';


@Component({
  selector: 'app-list-estados',
  //
  templateUrl: './list-ciudades.component.html',
  providers: [MessageService]

})
export class ListCiudadesComponent implements OnInit {


    //Collapse
    Collapse: boolean = false;
    Tabla: boolean = true;


    cols: any[] = [];

    statuses: any[] = [];

    rowsPerPageOptions = [5, 10, 20];

    display: boolean = false;


    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];

    //   variable para iterar
    ciudad!:Ciudad[];

    crearCiudadForm: FormGroup



    constructor(private ciudadservice: CiudadService, private router: Router,  private formBuilder: FormBuilder, private cookieService: CookieService) {

        this.crearCiudadForm = this.formBuilder.group({
            ciud_Id: ['', [Validators.required]],
            ciud_Descripcion: ['', [Validators.required]],
            esta_Id: ['', [Validators.required]],

          });
     }

    ngOnInit() {


        // Respuesta de la api
        this.ciudadservice.getCiudades().subscribe((Response: any)=> {
            console.log(Response.data);
            this.ciudad = Response.data;

          }, error=>{
            console.log(error);
          });

          //




        this.schemas = [
            CUSTOM_ELEMENTS_SCHEMA
          ];
    }

    openNew() {

        this.display = true;
    }

    onSubmit(): void {

    }



}
