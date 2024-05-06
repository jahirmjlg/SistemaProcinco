import { Component, OnInit } from '@angular/core';
import {CiudadService} from '../../Services/ciudad.service';
//
import { Ciudad } from 'src/app/Models/CiudadViewModel';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { dropEstados } from 'src/app/Models/EstadoViewModel';


@Component({
  selector: 'app-list-estados',
  //
  templateUrl: './list-ciudades.component.html',
  styleUrls: ['./list-ciudades.scss'],
  providers: [ConfirmationService, MessageService]

})
export class ListCiudadesComponent implements OnInit {



    Tabla: boolean = true;

    //BOOLEANS INSERTAR
    Collapse: boolean = false;
    isSubmit: boolean = false;

        //BOOLEANS EDITAR
        CollapseEdit: boolean = false;
        isSubmitEdit: boolean = false;

        //BOOLEAN DETALLE
        CollapseDetalle: boolean = false;

                //BOOLEAN DELETE
                deleteCiudadBool: boolean = false;


        //VARIABLE EN LA QUE ITERA EL DDL
    estados: any[] = [];


    // DETALLE
    Ciudad: String = "";
    codigo: String = "";
    estado: String = "";
    UsuarioCreacion: String = "";
    UsuarioModificacion: String = "";
    FechaCreacion: String = "";
    FechaModificacion: String = "";
    ID: String = "";



    //IGNORAR (DESTACAR QUE ES LO UNICO NECESARIO(DEPURAR TODO LO DEMAS))
    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];


    //   variable para iterar
    ciudad!:Ciudad[];

    //CREAR EL FORMGROUP EN EL QUE SE CREAN LAS PROPIEDADES
    crearCiudadForm: FormGroup
    editarCiudadForm: FormGroup




    constructor(private ciudadservice: CiudadService, private router: Router,
                private formBuilder: FormBuilder, private cookieService: CookieService,
                private messageService: MessageService) {


     }

    ngOnInit() {

        //INICIALIZAR EL FORMULARIO
        this.crearCiudadForm = this.formBuilder.group({
            ciud_Id: ['', [Validators.required]],
            ciud_Descripcion: ['', [Validators.required]],
            esta_Id: ['0', [Validators.required]],

          });

          this.editarCiudadForm = new FormGroup({
            ciud_Id: new FormControl("",Validators.required),
            ciud_Descripcion: new FormControl("",Validators.required),
            esta_Id: new FormControl("0",Validators.required),
        });


        this.ciudadservice.getDdlEstados().subscribe((data: dropEstados[]) => {
            this.estados = data;
            console.log(data);
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




    //INSERTAR
    onSubmitInsert(): void {

        this.isSubmit = true;

            const errorSpan = document.getElementById('error-span');
        if (this.crearCiudadForm.valid) {
          const ciudadData: Ciudad = this.crearCiudadForm.value;
          this.ciudadservice.insertCiudades(ciudadData).subscribe(
            response => {
                console.log(response.code)

                if (response.code == 200) {

                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.ciudadservice.getCiudades().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.ciudad = Response.data;
                    });

                    this.Collapse = false;
                    this.Tabla = true;
                } else {

                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Agregar el Registro', life: 3000 });


                }

            },
            error => {
                console.log(error)
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'El Registro ya existe', life: 3000 });

            }
          );
        } else {
          console.log('Formulario inválido');
        }

    }



    //EDITAR
    onSubmitEdit(): void {

        this.isSubmitEdit = true;

        if (this.editarCiudadForm.valid) {
          const ciudadData: Ciudad = this.editarCiudadForm.value;
          this.ciudadservice.editCiudades(ciudadData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.ciudadservice.getCiudades().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.ciudad = Response.data;
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

        this.ciudadservice.fillCiudad(id).subscribe({
            next: (data: Ciudad) => {
               this.Ciudad = data[0].ciud_Descripcion,
               this.codigo = data[0].ciud_Id,
               this.estado = data[0].esta_Descripcion,
               this.UsuarioCreacion = data[0].usuarioCreacion,
               this.UsuarioModificacion = data[0].usuarioModificacion,
               this.FechaCreacion = data[0].ciud_FechaCreacion,
               this.FechaModificacion = data[0].ciud_FechaModificacion
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }




    //DELETE
    deleteCiudad(codigo) {
        this.deleteCiudadBool = true;
        this.ID = codigo;
        console.log("ID" + codigo);
    }

    confirmDelete() {
        this.ciudadservice.deleteCiudad(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.ciudadservice.getCiudades().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.ciudad = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });

                    this.Tabla=true;

                    this.deleteCiudadBool = false;

                   }
                else{
                    console.log(response)
                this.deleteCiudadBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
            }
        },
    });

    }





    //LLENAR EDITAR && DETALLE
    Fill(id) {
        this.ciudadservice.fillCiudad(id).subscribe({
            next: (data: Ciudad) => {
                this.editarCiudadForm = new FormGroup({
                    ciud_Id: new FormControl(data[0].ciud_Id,Validators.required),
                    ciud_Descripcion: new FormControl(data[0].ciud_Descripcion,Validators.required),
                    esta_Id: new FormControl(data[0].esta_Id,Validators.required),
                });

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
          });

    }



}
