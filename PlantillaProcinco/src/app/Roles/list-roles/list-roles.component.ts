import { Component } from '@angular/core';
import {RolesService} from '../../Services/roles.service';
import {Role} from 'src/app/Models/RolesViewModel';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-list-roles',
  templateUrl: './list-roles.component.html',
  providers: [ConfirmationService, MessageService]
})
export class ListRolesComponent {

    Tabla: boolean = true;

    Collapse: boolean = false;
    isSubmit: boolean = false;

    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;

    CollapseDetalle: boolean = false;

    deleteRolBool: boolean = false;

    ID: String = "";

  cols: any[] = [];
  statuses: any[] = [];
  rowsPerPageOptions = [5, 10, 20];
  schemas = [
      CUSTOM_ELEMENTS_SCHEMA
    ];

  //   variable para iterar
  role!:Role[];

  crearRolForm: FormGroup
  editarRolForm: FormGroup

  //ultimos dos
  constructor(private messageService: MessageService, private service: RolesService, private router: Router, private formBuilder: FormBuilder, private cookieService: CookieService ) { }

  ngOnInit() {


    this.crearRolForm = this.formBuilder.group({
        role_Descripcion: ['', [Validators.required]],
    });

    this.editarRolForm = new FormGroup({
        role_Id: new FormControl("",Validators.required),
        role_Descripcion: new FormControl("", Validators.required),
     })

      // Respuesta de la api
      this.service.getRol().subscribe((Response: any)=> {
          console.log(Response.data);
          this.role = Response.data;

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
    if (this.crearRolForm.valid) {
      const contenidoData: Role = this.crearRolForm.value;
      this.service.CrearRol(contenidoData).subscribe(
       response => {

        if (response.code == 200) 
        {
            this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

            console.log(response)
            this.service.getRol().subscribe((Response: any)=> {
                console.log(Response.data);
                this.role = Response.data;
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

        if (this.editarRolForm.valid) {
          const contenidoData: Role = this.editarRolForm.value;
          this.service.editRol(contenidoData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.service.getRol().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.role = Response.data;
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

 
    deleteRol(codigo) {
        this.deleteRolBool = true;
        this.ID = codigo;
        console.log("ID" + codigo);
    }
    

    confirmDelete() {
        this.service.deleteRol(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.service.getRol().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.role = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
                    this.Tabla=true;
                    this.deleteRolBool = false;

                }
                else{
                    console.log(response)
                this.deleteRolBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
                }
            },
        });
    }

    // Fill(id) {
    //     this.service.fillEstadoCivil(id).subscribe({
    //         next: (data: Role) => {
    //             this.ID = data[0].estc_Id,
    //             this.editarRolForm = new FormGroup({
    //                 role_Id: new FormControl(data[0].role_Id),
    //                 role_Descripcion: new FormControl(data[0].role_Descripcion,Validators.required),
    //             });
    //             console.log(this.ID);

    //             this.CollapseEdit = true;
    //             this.Tabla=false;

    //             console.log(data)

    //         }
    //     });
    // }
}
