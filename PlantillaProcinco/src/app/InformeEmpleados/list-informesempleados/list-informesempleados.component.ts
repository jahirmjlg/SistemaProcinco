import { Component, OnInit } from '@angular/core';
import { InformeEmpleadosService } from '../../Services/informe-emplados.service';
import { InformeEmpleado } from 'src/app/Models/InformesEmpleadosViewModel';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { dropEmpleados } from 'src/app/Models/EmpleadosViewModel';
import { dropCursos } from 'src/app/Models/CursosViewModel';

@Component({
  selector: 'app-list-informeempleados',
  styleUrls: ['./list-informesempleados.scss'],
  templateUrl: './list-informesempleados.component.html',
  providers: [ConfirmationService, MessageService]

})
export class ListInformesempleadosComponent implements OnInit {


    Tabla: boolean = true;
    Collapse: boolean = false;
    isSubmit: boolean = false;
    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;
    CollapseDetalle: boolean = false;
    deleteUsaurioBool: boolean = false;



    empleados: any[] = [];
    cursos: any[] = [];

    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];

    infoE_Id: String = "";
    infoE_Calificacion: String = "";
    empl_Id  : String = "";
    curso_Id : String = "";
    infoE_Observaciones: String = "";
    infoE_Usuariocreacion: String = "";
    infoE_FechaCreacion: String = "";
    infoE_UsuarioModificacion: String = "";
    infoE_FechaModificacion: String = "";
    ID: String = "";

    //   variable para iterar
    informeempleado!:InformeEmpleado[];
    crearInformeEmpleadoForm: FormGroup
    editarInformeEmpleadoForm: FormGroup

    //ultimos dos
    constructor( private messageService: MessageService, private informesempleadosservice: InformeEmpleadosService, private router: Router,  private formBuilder: FormBuilder, private cookieService: CookieService) { }


    ngOnInit() {

        this.crearInformeEmpleadoForm = this.formBuilder.group({
            infoE_Calificacion: ['0', [Validators.required]],
            curso_Id: ['0', [Validators.required]],
            empl_Id: ['0', [Validators.required]],
            infoE_Observaciones: ['', [Validators.required]],

        });

        this.editarInformeEmpleadoForm = new FormGroup({
            infoE_Id: new FormControl("",Validators.required),
            infoE_Calificacion: new FormControl("",Validators.required),
            empl_Id: new FormControl("0", Validators.required),
            curso_Id: new FormControl("0", Validators.required),
            infoE_Observaciones: new FormControl(true,Validators.required),
        });

        this.informesempleadosservice.getDdlEmpleado().subscribe((data: dropEmpleados[]) => {
            this.empleados = data;
            console.log(data);
        }, error => {
            console.log(error);
        });

        this.informesempleadosservice.getDdlCurso().subscribe((data: dropCursos[]) => {
            this.cursos = data;
            console.log(data);
        }, error => {
            console.log(error);
        });


        // Respuesta de la api
        this.informesempleadosservice.getInformeEmpleado().subscribe((Response: any)=> {
            console.log(Response.data);
            this.informeempleado = Response.data;

          }, error=>{
            console.log(error);
        });
          //



        this.schemas = [
            CUSTOM_ELEMENTS_SCHEMA
          ];
    }


    cancel()
    {
        this.crearInformeEmpleadoForm = this.formBuilder.group({
            infoE_Calificacion: ['0', [Validators.required]],
            curso_Id: ['0', [Validators.required]],
            empl_Id: ['0', [Validators.required]],
            infoE_Observaciones: ['', [Validators.required]],

        });

        this.Collapse=false;
        this.Tabla=true;
        this.isSubmit=false
    }

    //INSERTAR
    onSubmitInsert(): void {


        this.isSubmit = true;

            const errorSpan = document.getElementById('error-span');
        if (this.crearInformeEmpleadoForm.valid) {
          const ciudadData: InformeEmpleado = this.crearInformeEmpleadoForm.value;
          console.log(ciudadData);
          this.informesempleadosservice.insertInformeEmpleado(ciudadData).subscribe(
            response => {

                if (response.code == 200) {

                    this.crearInformeEmpleadoForm = this.formBuilder.group({
                        infoE_Calificacion: ['0', [Validators.required]],
                        curso_Id: ['0', [Validators.required]],
                        empl_Id: ['0', [Validators.required]],
                        infoE_Observaciones: ['', [Validators.required]],

                    });

                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.informesempleadosservice.getInformeEmpleado().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.informeempleado = Response.data;
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


    //EDITAR
    onSubmitEdit(): void {

        this.isSubmitEdit = true;


        if (this.editarInformeEmpleadoForm.valid) {
          const ciudadData: InformeEmpleado = this.editarInformeEmpleadoForm.value;
          this.informesempleadosservice.editInformeEmpleado(ciudadData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.informesempleadosservice.getInformeEmpleado().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.informeempleado = Response.data;
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

        this.informesempleadosservice.fillInformeEmpleado(id).subscribe({
            next: (data: InformeEmpleado) => {
               this.infoE_Id = data[0].infoE_Id,
               this.infoE_Calificacion = data[0].infoE_Calificacion,
               this.curso_Id = data[0].cursos,
               this.empl_Id = data[0].nombre,
               this.infoE_Observaciones = data[0].infoE_Observaciones,
               this.infoE_Usuariocreacion = data[0].creacion,
               this.infoE_FechaCreacion = data[0].infoE_FechaCreacion,
               this.infoE_UsuarioModificacion = data[0].modificacion,
               this.infoE_FechaModificacion = data[0].infoE_FechaModificacion
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }


    //DELETE
    deleteUsuario(codigo) {
        this.deleteUsaurioBool = true;
        this.ID = codigo;
        console.log("ID" + codigo);
    }


    confirmDelete() {
        this.informesempleadosservice.deleteInformeEmpleado(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.informesempleadosservice.getInformeEmpleado().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.informeempleado = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });

                    this.Tabla=true;

                    this.deleteUsaurioBool = false;

                   }
                else{
                    console.log(response)
                this.deleteUsaurioBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
                }
            },
        });
    }
    validarNumeros(event: KeyboardEvent) {

        if (!/^[a-zA-Z0-9 ]+$/.test(event.key) && event.key !== 'Backspace' && event.key !== 'Tab' && event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') {
          event.preventDefault();
        }
        else{
        }
      }

      validarTexto(event: KeyboardEvent) {
        if (!/^[a-zA-Z\s]+$/.test(event.key) && event.key !== 'Backspace' && event.key !== 'Tab' && event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') {
            event.preventDefault();
        }
      }
  //LLENAR EDITAR && DETALLE
  Fill(id) {
    this.informesempleadosservice.fillInformeEmpleado(id).subscribe({
        next: (data: InformeEmpleado) => {
            this.editarInformeEmpleadoForm = new FormGroup({
                infoE_Id: new FormControl(data[0].infoE_Id,Validators.required),
                infoE_Calificacion: new FormControl(data[0].infoE_Calificacion,Validators.required),
                empl_Id: new FormControl(data[0].empl_Id,Validators.required),
                curso_Id: new FormControl(data[0].curso_Id,Validators.required),
                infoE_Observaciones: new FormControl(data[0].infoE_Observaciones,Validators.required),
            });
            this.CollapseEdit = true;
            this.Tabla=false;
            console.log(data)
        }
      });
    }
}

