import { Component } from '@angular/core';
import {CursosImpartidosService} from '../../Services/cursosimpartidos.service';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CursosImpartidos } from 'src/app/Models/CursosImpartidos';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-list-cursosimpartidos',
  templateUrl: './list-cursosimpartidos.component.html',
  styleUrl: './list-cursosimpartidos.component.scss',
  providers: [ConfirmationService, MessageService]
})
export class ListCursosimpartidosComponent {

    Tabla: boolean = true;

    Collapse: boolean = false;
    isSubmit: boolean = false;


    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;
    
    CollapseDetalle: boolean = false;

    //BOOLEAN DELETE
    deleteCursoImpartidoBool: boolean = false;


    curIm_Id: String = "";
    curso_Id: String = "";
    empl_Id: String = "";
    curIm_FechaInicio: String = "";
    curIm_FechaFin: String = "";
    curIm_Finalizar: String = "";
    creacion: String = "";
    curIm_FechaCreacion: String = "";
    modificacion: String = "";
    curIm_FechaModificacion: String = "";
    ID: String = "";

    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];

    //   variable para iterar
    cursosimpartidos!:CursosImpartidos[];

    crearCursosImpartidosForm: FormGroup
    editarCursosImpartidosForm: FormGroup

    constructor(private messageService: MessageService, private cursosimpartidosservice: CursosImpartidosService, private router: Router, private formBuilder: FormBuilder, private cookieService: CookieService) { }

    ngOnInit() {


        // Respuesta de la api
        this.cursosimpartidosservice.getCursosImpartidos().subscribe((Response: any)=> {
            console.log(Response.data);
            this.cursosimpartidos = Response.data;

          }, error=>{
            console.log(error);
          });

          //

        this.schemas = [
            CUSTOM_ELEMENTS_SCHEMA
          ];
    }

    detalles(id){

        this.cursosimpartidosservice.fillCursosIm(id).subscribe({
            next: (data: CursosImpartidos) => {
               this.curIm_Id = data[0].curIm_Id,
               this.curso_Id = data[0].cursos,
               this.curIm_FechaInicio = data[0].curIm_FechaInicio,
               this.curIm_FechaFin = data[0].curIm_FechaFin,
               this.creacion = data[0].creacion,
               this.empl_Id = data[0].nombre,
               this.curIm_Finalizar = data[0].curIm_Finalizar,
               this.curIm_FechaCreacion = data[0].curIm_FechaCreacion,
               this.modificacion = data[0].modificacion,
               this.curIm_FechaModificacion = data[0].curIm_FechaModificacion,
                console.log(data);            
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }


    Fill(id) {
        this.cursosimpartidosservice.fillCursosIm(id).subscribe({
            next: (data: CursosImpartidos) => {
                this.ID = data[0].titl_Id,
                this.editarCursosImpartidosForm = new FormGroup({
                    curIm_Id: new FormControl(data[0].curIm_Id),
                    curso_Id: new FormControl(data[0].curso_Id,Validators.required),
                    curIm_FechaInicio: new FormControl(data[0].curIm_FechaInicio,Validators.required),
                    curIm_FechaFin: new FormControl(data[0].curIm_FechaFin,Validators.required),
                    empl_Id: new FormControl(data[0].empl_Id,Validators.required),
                    curIm_Finalizar: new FormControl(data[0].curIm_Finalizar,Validators.required),
                });
                console.log(this.ID);

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
        });
    }

    deleteCursoImpartido(codigo) {
        this.deleteCursoImpartidoBool = true;
        this.ID = codigo;
    }


    confirmDelete() {
        this.cursosimpartidosservice.deleteCursosIm(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.cursosimpartidosservice.getCursosImpartidos().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.cursosimpartidos = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
                    this.Tabla=true;
                    this.deleteCursoImpartidoBool = false;

                }
                else{
                    console.log(response)
                this.deleteCursoImpartidoBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
                }
            },
        });
    }


}
