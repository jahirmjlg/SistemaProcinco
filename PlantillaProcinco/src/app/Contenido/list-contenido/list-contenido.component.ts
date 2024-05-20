import { Component, OnInit } from '@angular/core';
import {ContenidoService} from '../../Services/contenido.service';
import {Contenido} from 'src/app/Models/ContenidoViewModel';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { dropCategorias } from 'src/app/Models/CategoriasViewModel';

@Component({
  selector: 'app-list-contenido',
  styleUrls: ['./list-contenido.scss'],
  templateUrl: './list-contenido.component.html',
  providers: [ConfirmationService, MessageService]

})
export class ListContenidoComponent implements OnInit {

    Tabla: boolean = true;

    Collapse: boolean = false;
    isSubmit: boolean = false;

    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;

    CollapseDetalle: boolean = false;
    dropCategorias: any[] = [];

    deleteContenidoBool: boolean = false;

    cont_Id: String = "";
    Contenido: String = "";
    ContenidoDuracion: String = "";
    UsuarioCreacion: String = "";
    UsuarioModificacion: String = "";
    FechaCreacion: String = "";
    FechaModificacion: String = "";
    ID: String = "";
    categoria: String = "";


    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];

    //   variable para iterar
    contenido!:Contenido[];


    crearContenidoForm: FormGroup
    editarContenidoForm: FormGroup
    //ultimos dos
    constructor(private messageService: MessageService, private contenidoservice: ContenidoService, private router: Router,
        private formBuilder: FormBuilder,
        private cookieService: CookieService) { }

    ngOnInit() {


        this.crearContenidoForm = this.formBuilder.group({
            cont_Descripcion: ['', [Validators.required]],
            cate_Id: ['0', [Validators.required]],

          cont_DuracionHoras: ['0', [Validators.required]],
        });

        this.editarContenidoForm = new FormGroup({
            ID: new FormControl("",Validators.required),
            cont_Descripcion: new FormControl("", Validators.required),
            cate_Id: new FormControl("0",Validators.required),
            cont_DuracionHoras: new FormControl("", Validators.required),
         })



         this.contenidoservice.getDdlCategorias().subscribe((data: dropCategorias[]) => {
            this.dropCategorias = data;
            console.log(data);
        }, error => {
            console.log(error);
        });

        // Respuesta de la api
        this.contenidoservice.getContenido().subscribe((Response: any)=> {

            console.log(Response.data);
            this.contenido = Response.data;

          }, error=>{
            console.log(error);
          });



        //   this.contenidoservice.getDdlCategorias

          this.contenidoservice.getDdlCategorias().subscribe((data: dropCategorias[]) => {
            this.dropCategorias = data;
            console.log(data);
        }, error => {
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
        if (this.crearContenidoForm.valid) {
          const contenidoData: Contenido = this.crearContenidoForm.value;
          this.contenidoservice.insertContenido(contenidoData).subscribe(
           response => {

            if (response.code == 200)
            {

                this.crearContenidoForm = this.formBuilder.group({
                    cont_Descripcion: ['', [Validators.required]],
                    cate_Id: ['0', [Validators.required]],

                  cont_DuracionHoras: ['0', [Validators.required]],
                });

                this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                console.log(response)
                    // this.router.navigate(['/pages/estados']);
                this.contenidoservice.getContenido().subscribe((Response: any)=> {
                    console.log(Response.data);
                    this.contenido = Response.data;
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

        if (this.editarContenidoForm.valid) {
          const contenidoData: Contenido = this.editarContenidoForm.value;
          this.contenidoservice.editContenido(contenidoData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.contenidoservice.getContenido().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.contenido = Response.data;
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



    cancel()
    {
        this.crearContenidoForm = this.formBuilder.group({
            cont_Descripcion: ['', [Validators.required]],
            cate_Id: ['0', [Validators.required]],

          cont_DuracionHoras: ['0', [Validators.required]],
        });

        this.Collapse=false;
        this.Tabla=true;
        this.isSubmit=false
    }




    detalles(id){

        this.contenidoservice.fillContenido(id).subscribe({
            next: (data: Contenido) => {
                this.categoria = data[0].categoria,
                this.cont_Id = data[0].cont_Id,
               this.Contenido = data[0].cont_Descripcion,
               this.ContenidoDuracion = data[0].cont_DuracionHoras,
               this.UsuarioCreacion = data[0].usuarioCreacion,
               this.UsuarioModificacion = data[0].usuarioModificacion,
               this.FechaCreacion = data[0].cont_FechaCreacion,
               this.FechaModificacion = data[0].cont_FechaModificacion
                console.log(data);
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }

    deleteContenido(codigo) {
        this.deleteContenidoBool = true;
        this.ID = codigo;
        console.log("ID" + codigo);
    }

    confirmDelete() {
        this.contenidoservice.deleteContenido(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.contenidoservice.getContenido().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.contenido = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
                    this.Tabla=true;
                    this.deleteContenidoBool = false;

                }
                else{
                    console.log(response)
                this.deleteContenidoBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
                }
            },
        });
    }

    Fill(id) {
        this.contenidoservice.fillContenido(id).subscribe({
            next: (data: Contenido) => {
                this.ID = data[0].cont_Id,
                this.editarContenidoForm = new FormGroup({
                    cate_Id: new FormControl(data[0].cate_Id,Validators.required),

                    cont_Id: new FormControl(data[0].cont_Id),
                    cont_Descripcion: new FormControl(data[0].cont_Descripcion,Validators.required),
                    cont_DuracionHoras: new FormControl(data[0].cont_DuracionHoras,Validators.required),
                });
                console.log(this.ID);

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
        });
    }

}

