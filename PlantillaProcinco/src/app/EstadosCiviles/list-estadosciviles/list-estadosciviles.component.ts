import { Component } from '@angular/core';
import {EstadoscivilesService} from '../../Services/estadosciviles.service';
import { EstadoCivil } from 'src/app/Models/EstadosCivilesViewModel';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-list-estadosciviles',
  templateUrl: './list-estadosciviles.component.html',
  providers: [ConfirmationService, MessageService]
})
export class ListEstadoscivilesComponent {

    Tabla: boolean = true;

    Collapse: boolean = false;
    isSubmit: boolean = false;

    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;

    CollapseDetalle: boolean = false;

    deleteContenidoBool: boolean = false;


  estc_Id: String = "";
  estc_Descripcion: String = "";
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
  estadocivil!:EstadoCivil[];

  crearEstaciCivilForm: FormGroup
  editarEstadoCivilForm: FormGroup

  //ultimos dos
  constructor( private messageService: MessageService, private estadoscivilesservice: EstadoscivilesService, private router: Router, private formBuilder: FormBuilder, private cookieService: CookieService ) { }

  ngOnInit() {

    this.crearEstaciCivilForm = this.formBuilder.group({
        estc_Descripcion: ['', [Validators.required]],
    });

    this.editarEstadoCivilForm = new FormGroup({
        estc_Id: new FormControl("",Validators.required),
        estc_Descripcion: new FormControl("", Validators.required),
     })

      // Respuesta de la api
      this.estadoscivilesservice.getEstadoCivil().subscribe((Response: any)=> {
          console.log(Response.data);
          this.estadocivil = Response.data;

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
    this.crearEstaciCivilForm = this.formBuilder.group({
        estc_Descripcion: ['', [Validators.required]],
    });

    this.Collapse=false;
    this.Tabla=true;
    this.isSubmit=false
  }

  onSubmitInsert(): void {

    this.isSubmit = true;

    const errorSpan = document.getElementById('error-span');
    if (this.crearEstaciCivilForm.valid) {
      const contenidoData: EstadoCivil = this.crearEstaciCivilForm.value;
      this.estadoscivilesservice.insertEstadoCivil(contenidoData).subscribe(
       response => {

        if (response.code == 200)
        {
            this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                // this.cookieService.set('namee', response.data.empl_Nombre);

            console.log(response)
                // this.router.navigate(['/pages/estados']);
            this.estadoscivilesservice.getEstadoCivil().subscribe((Response: any)=> {
                console.log(Response.data);
                this.estadocivil = Response.data;
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

        if (this.editarEstadoCivilForm.valid) {
          const contenidoData: EstadoCivil = this.editarEstadoCivilForm.value;
          this.estadoscivilesservice.editEstadoCivil(contenidoData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.estadoscivilesservice.getEstadoCivil().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.estadocivil = Response.data;
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

        this.estadoscivilesservice.fillEstadoCivil(id).subscribe({
            next: (data: EstadoCivil) => {
               this.estc_Id = data[0].estc_Id,
               this.estc_Descripcion = data[0].estc_Descripcion,
               this.UsuarioCreacion = data[0].usuarioCreacion,
               this.UsuarioModificacion = data[0].usuarioModificacion,
               this.FechaCreacion = data[0].estc_FechaCreacion,
               this.FechaModificacion = data[0].estc_FechaModificacion
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

    validarTexto(event: KeyboardEvent) {

        if (!/^[a-zA-Z\s]+$/.test(event.key) && event.key !== 'Backspace' && event.key !== 'Tab' && event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') {
            event.preventDefault();
        }
    }



    confirmDelete() {
        this.estadoscivilesservice.deleteEstadoCivil(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.estadoscivilesservice.getEstadoCivil().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.estadocivil = Response.data;
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
        this.estadoscivilesservice.fillEstadoCivil(id).subscribe({
            next: (data: EstadoCivil) => {
                this.ID = data[0].estc_Id,
                this.editarEstadoCivilForm = new FormGroup({
                    estc_Id: new FormControl(data[0].estc_Id),
                    estc_Descripcion: new FormControl(data[0].estc_Descripcion,Validators.required),
                });
                console.log(this.ID);

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
        });
    }

}
