import { Component, OnInit } from '@angular/core';
import {EstadoService} from '../../Services/estado.service';

import { Estado } from 'src/app/Models/EstadoViewModel';
import {Router} from '@angular/router';

import { Product } from 'src/app/demo/api/product';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-list-estados',
  styleUrls: ['./list-estados.scss'],
  templateUrl: './list-estados.component.html',
  providers: [ConfirmationService, MessageService]

})
export class ListEstadosComponent implements OnInit {

    Tabla: boolean = true;

    Collapse: boolean = false;
    isSubmit: boolean = false;


    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;
    
    CollapseDetalle: boolean = false;

    //BOOLEAN DELETE
    deleteEstadoBool: boolean = false;

    // DETALLE
    codigo: String = "";
    estadoo: String = "";
    UsuarioCreacion: String = "";
    UsuarioModificacion: String = "";
    FechaCreacion: String = "";
    FechaModificacion: String = "";
    ID: String = "";


    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];

    //   variable para iterar
    estado!:Estado[];

    crearEstadoForm: FormGroup
    editarEstadoForm: FormGroup

    //ultimos dos
    constructor(private messageService: MessageService, private estadoservice: EstadoService, private router: Router,
        private formBuilder: FormBuilder, private cookieService: CookieService) { }

    ngOnInit() {


        this.crearEstadoForm = this.formBuilder.group({
            esta_Id: ['', [Validators.required]],
            esta_Descripcion: ['', [Validators.required]],

          });

          this.editarEstadoForm = new FormGroup({
            esta_Id: new FormControl("",Validators.required),
            esta_Descripcion: new FormControl("",Validators.required),
        });

        // Respuesta de la api
        this.estadoservice.getEstados().subscribe((Response: any)=> {
            console.log(Response.data);
            this.estado = Response.data;

          }, error=>{
            console.log(error);
          });

          //

        this.schemas = [
            CUSTOM_ELEMENTS_SCHEMA
          ];
    }

    onSubmitInsert(): void {

        this.isSubmit = true;

            const errorSpan = document.getElementById('error-span');
        if (this.crearEstadoForm.valid) {
          const ciudadData: Estado = this.crearEstadoForm.value;
          this.estadoservice.insertEstados(ciudadData).subscribe(
            response => {

                if (response.code == 200) {

                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.estadoservice.getEstados().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.estadoo = Response.data;
                    });

                    this.Collapse = false;
                    this.Tabla = true;
                } else {

                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Agregar el Registro', life: 3000 });


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

    onSubmitEdit(): void {

        this.isSubmitEdit = true;

        if (this.editarEstadoForm.valid) {
          const ciudadData: Estado = this.editarEstadoForm.value;
          this.estadoservice.editEstados(ciudadData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.estadoservice.getEstados().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.estadoo = Response.data;
                    });

                    this.CollapseEdit = false;
                    this.Tabla = true;

                } else {

                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Editar el Registro', life: 3000 });


                }

            },
            error => {
                console.log(error);
            }
          );
        } else {
          console.log('Formulario inválido');
        }

    }

    detalles(id){

        this.estadoservice.fillEstado(id).subscribe({
            next: (data: Estado) => {
               this.codigo = data[0].esta_Id,
               this.estadoo = data[0].esta_Descripcion,
               this.UsuarioCreacion = data[0].usuarioCreacion,
               this.UsuarioModificacion = data[0].usuarioModificacion,
               this.FechaCreacion = data[0].esta_FechaCreacion,
               this.FechaModificacion = data[0].esta_FechaModificacion
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }

  //DELETE
    deleteEstado(codigo) {
        this.deleteEstadoBool = true;
        this.ID = codigo;
        console.log("ID" + codigo);
    }

    confirmDelete() {
        this.estadoservice.deleteEstado(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.estadoservice.getEstados().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.estado = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });

                    this.Tabla=true;

                    this.deleteEstadoBool = false;

                   }
                else{
                    console.log(response)
                this.deleteEstadoBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
            }
        },
    });

    }

    Fill(id) {
        this.estadoservice.fillEstado(id).subscribe({
            next: (data: Estado) => {
                this.editarEstadoForm = new FormGroup({
                    esta_Id: new FormControl(data[0].esta_Id,Validators.required),
                    esta_Descripcion: new FormControl(data[0].esta_Descripcion,Validators.required),
                });

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
          });

    }

}

