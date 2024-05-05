import { Component } from '@angular/core';
import {UsuariosService} from '../../Services/usuarios.service';
import {Usuario} from 'src/app/Models/UsuariosViewModel';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { dropRoles } from 'src/app/Models/RolesViewModel';
import { dropEmpleados } from 'src/app/Models/EmpleadosViewModel';

@Component({
  selector: 'app-list-usuarios',
  styleUrls: ['./list-usuarios.scss'],
  templateUrl: './list-usuarios.component.html',
  providers: [ConfirmationService, MessageService]
})
export class ListUsuariosComponent {

    Tabla: boolean = true;

    Collapse: boolean = false;
    isSubmit: boolean = false;

    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;

    CollapseDetalle: boolean = false;

    deleteUsaurioBool: boolean = false;

    roles: any[] = [];
    empleados: any[] = [];

    
    usua_Id: String = "";
    usua_Usuario: String = "";
    usua_Contraseña : String = "";
    usua_EsAdmin  : Boolean;
    role_Id  : String = "";
    empl_Id : String = ""; 
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
  usuario!:Usuario[];

    crearUsuarioForm: FormGroup
    editarUsuarioForm: FormGroup
  //ultimos dos
  constructor( private messageService: MessageService, private service: UsuariosService, private router: Router,  private formBuilder: FormBuilder, private cookieService: CookieService) { }

  ngOnInit() {

    this.crearUsuarioForm = this.formBuilder.group({
        usua_Usuario: ['', [Validators.required]],
        usua_Contraseña: ['', [Validators.required]],
        usua_EsAdmin: [false, [Validators.required]],
        role_Id: ['0', [Validators.required]],
        empl_Id: ['0', [Validators.required]],

      });

      this.editarUsuarioForm = new FormGroup({
        usua_Id: new FormControl("",Validators.required),
        usua_Usuario: new FormControl("",Validators.required),
        usua_EsAdmin: new FormControl("",Validators.required),
        role_Id: new FormControl("0", Validators.required),
        empl_Id: new FormControl("0", Validators.required),
    });



    this.service.getDdlRoles().subscribe((data: dropRoles[]) => {
        this.roles = data;
        console.log(data);
    }, error => {
        console.log(error);
    });

    this.service.getDdlEmpleado().subscribe((data: dropEmpleados[]) => {
        this.empleados = data;
        console.log(data);
    }, error => {
        console.log(error);
    });

      // Respuesta de la api
    this.service.getUsuario().subscribe((Response: any)=> {
        console.log(Response.data);
        this.usuario = Response.data;

    }, error=>{
        console.log(error);
    });

      this.schemas = [
          CUSTOM_ELEMENTS_SCHEMA
        ];
  }


    //INSERTAR
    onSubmitInsert(): void {

        this.isSubmit = true;

            const errorSpan = document.getElementById('error-span');
        if (this.crearUsuarioForm.valid) {
          const ciudadData: Usuario = this.crearUsuarioForm.value;
          console.log(ciudadData);
          this.service.insertUsuario(ciudadData).subscribe(
            response => {

                if (response.code == 200) {

                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.service.getUsuario().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.usuario = Response.data;
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

        if (this.editarUsuarioForm.valid) {
          const ciudadData: Usuario = this.editarUsuarioForm.value;
          this.service.editUsuario(ciudadData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.service.getUsuario().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.usuario = Response.data;
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

        this.service.fillUsuario(id).subscribe({
            next: (data: Usuario) => {
               this.usua_Id = data[0].usua_Id,
               this.usua_Usuario = data[0].usua_Usuario,
               this.usua_EsAdmin = data[0].usua_EsAdmin,
               this.role_Id = data[0].role_Descripcion,
               this.empl_Id = data[0].empl_Nombre,
               this.UsuarioCreacion = data[0].usuarioCreacion,
               this.UsuarioModificacion = data[0].usuarioModificacion,
               this.FechaCreacion = data[0].usua_FechaCreacion,
               this.FechaModificacion = data[0].usua_FechaModificacion
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
        this.service.deleteUsuario(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.service.getUsuario().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.usuario = Response.data;
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

  //LLENAR EDITAR && DETALLE
    Fill(id) {
    this.service.fillUsuario(id).subscribe({
        next: (data: Usuario) => {
            this.editarUsuarioForm = new FormGroup({
                usua_Id: new FormControl(data[0].usua_Id,Validators.required),
                usua_Usuario: new FormControl(data[0].usua_Usuario,Validators.required),
                usua_EsAdmin: new FormControl(data[0].usua_EsAdmin,Validators.required),
                empl_Id: new FormControl(data[0].empl_Id,Validators.required),
                role_Id: new FormControl(data[0].role_Id,Validators.required),
            });

            this.CollapseEdit = true;
            this.Tabla=false;

            console.log(data)

        }
      });

    }


}

