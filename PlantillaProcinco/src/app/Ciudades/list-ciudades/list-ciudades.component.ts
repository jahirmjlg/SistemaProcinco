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
import { dropEstados } from 'src/app/Models/EstadoViewModel';


@Component({
  selector: 'app-list-estados',
  //
  templateUrl: './list-ciudades.component.html',
  styleUrls: ['./list-ciudades.scss'],
  providers: [MessageService]

})
export class ListCiudadesComponent implements OnInit {


    //Collapse
    Collapse: boolean = false;
    Tabla: boolean = true;

    estados: any[] = [];

    esta_Id = "0";


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


     }

    ngOnInit() {

        this.crearCiudadForm = this.formBuilder.group({
            ciud_Id: ['', [Validators.required]],
            ciud_Descripcion: ['', [Validators.required]],
            esta_Id: ['0', [Validators.required]],

          });

        this.ciudadservice.getDdlEstados().subscribe((data: dropEstados[]) => {
            this.estados = data;
            console.log("exito");
        }, error => {
            console.log(error);
        });


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





            const errorSpan = document.getElementById('error-span');
        if (this.crearCiudadForm.valid) {
          const ciudadData: Ciudad = this.crearCiudadForm.value;
          this.ciudadservice.insertCiudades(ciudadData).subscribe(
            response => {

                if (response.code == 200) {

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    this.router.navigate(['/pages/empty']);
                } else {

                    errorSpan.classList.remove('collapse');

                }

            },
            error => {
                errorSpan.classList.remove('collapse');
            }
          );
        } else {
          console.log('Formulario inválido');
        }



    }



}
