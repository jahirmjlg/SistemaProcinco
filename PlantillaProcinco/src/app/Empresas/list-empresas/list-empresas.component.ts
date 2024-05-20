import { ChangeDetectorRef, Component, ElementRef, ViewChild } from '@angular/core';
import {RolesService} from '../../Services/roles.service';
import {Role} from 'src/app/Models/RolesViewModel';
import {Router} from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, AfterContentInit } from '@angular/core';
import { FormBuilder, FormControl, FormArray, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { PantallasPorRolesService } from 'src/app/Services/pantallas-por-roles.service';
import { PantallaPorRol } from 'src/app/Models/PantallasPorRolesViewModel';
import { Empresa } from 'src/app/Models/EmpresaViewModel';
import { EmpresaService } from 'src/app/Services/empresa.service';
import { dropEstados } from 'src/app/Models/EstadoViewModel';

@Component({
  selector: 'app-list-empresas',
  templateUrl: './list-empresas.component.html',
  styleUrl: './list-empresas.component.scss',
  providers: [ConfirmationService, MessageService]
})
export class ListEmpresasComponent {

    Tabla: boolean = true;

    Collapse: boolean = false;
    isSubmit: boolean = false;

    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;

    CollapseDetalle: boolean = false;

    deleteRolBool: boolean = false;

    ID: String = "";

    ciudadID: String = "";


    estadosddl: any[] = [];
    ciudadesddl: any[] = [];


  cols: any[] = [];
  statuses: any[] = [];
  rowsPerPageOptions = [5, 10, 20];
  schemas = [
      CUSTOM_ELEMENTS_SCHEMA
    ];

  //   variable para iterar
  empresa!:Empresa[];


  crearEmpresaForm: FormGroup
  editarEmpresaForm: FormGroup


  //Detalle
  empreId : number = 0;
  empreDescripcion  : string = "";
  empreDireccion  : string;
  ciudad  : String = "";
  UsuarioCreacion : String = "";
  FechaCreacion : string = "";
  UsuarioModificacion : String = "";
  FechaModificacion : string = "";


  constructor(
    private cdRef: ChangeDetectorRef,
     private messageService: MessageService,
     private serviceEmp: EmpresaService,
     private router: Router,
     private formBuilder: FormBuilder,
      private cookieService: CookieService,
       private paroservice : PantallasPorRolesService ) { }

  ngOnInit() {
    this.crearEmpresaForm = this.formBuilder.group({
        empre_Descripcion: ['', [Validators.required]],
        empre_Direccion: ['', [Validators.required]],
        ciud_Id: ['', [Validators.required]],
        esta_Id: ['0', [Validators.required]],


    });

    this.editarEmpresaForm = new FormGroup({
        empre_Id: new FormControl("",Validators.required),
        empre_Descripcion: new FormControl("", Validators.required),
        empre_Direccion: new FormControl("", Validators.required),
        ciud_Id: new FormControl("", Validators.required),
        esta_Id: new FormControl("", Validators.required),




    })

    // Respuesta de la api
    this.serviceEmp.getEmpresas().subscribe((Response: any)=> {
        console.log(Response.data);
        this.empresa = Response.data;
    }, error=>{
        console.log(error);
    });



    this.serviceEmp.getDdlEstados().subscribe((data: dropEstados[]) => {
        this.estadosddl = data;
        console.log(data);
    }, error => {
        console.log(error);
    });


      this.schemas = [
          CUSTOM_ELEMENTS_SCHEMA
        ];
  }


  cancel()
  {
    this.crearEmpresaForm = this.formBuilder.group({
        empre_Descripcion: ['', [Validators.required]],
        empre_Direccion: ['', [Validators.required]],
        ciud_Id: ['', [Validators.required]],
        esta_Id: ['0', [Validators.required]],


    });

    this.Collapse=false;
    this.Tabla=true;
    this.isSubmit=false
  }

onSubmitInsert(): void {

    this.isSubmit = true;

        const errorSpan = document.getElementById('error-span');
    if (this.crearEmpresaForm.valid) {
      const Data: Empresa = this.crearEmpresaForm.value;
      this.serviceEmp.insertEmpresa(Data).subscribe(
        response => {

            if (response.code == 200) {

                this.crearEmpresaForm = this.formBuilder.group({
                    empre_Descripcion: ['', [Validators.required]],
                    empre_Direccion: ['', [Validators.required]],
                    ciud_Id: ['', [Validators.required]],
                    esta_Id: ['0', [Validators.required]],


                });

                this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                // this.cookieService.set('namee', response.data.empl_Nombre);

                console.log(response)
                // this.router.navigate(['/pages/estados']);
                this.serviceEmp.getEmpresas().subscribe((Response: any)=> {
                    console.log(Response.data);
                    this.empresa = Response.data;
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

        if (this.editarEmpresaForm.valid) {
          const empresaData: Empresa = this.editarEmpresaForm.value;
          this.serviceEmp.editEmpresa(empresaData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.serviceEmp.getEmpresas().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.empresa = Response.data;
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
        this.serviceEmp.deleteEmpresa(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.serviceEmp.getEmpresas().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.empresa = Response.data;
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



    onEstadoChange(estadoID) {
        if (estadoID !== '0') {
          this.serviceEmp.getDdlCiudades(estadoID).subscribe(
            (data: any) => {
              this.ciudadesddl = data;
              this.crearEmpresaForm.get('ciud_Id').setValue('0');
            },
            error => {
              console.error('Errorr:', error);
            }
          );
        } else {
          this.ciudadesddl = [];
        }
      }




        Fill(id) {
            this.serviceEmp.fillEmpresa(id).subscribe({
              next: (data: Empresa) => {
                this.editarEmpresaForm = new FormGroup({
                    empre_Id: new FormControl(data[0].empre_Id,Validators.required),
                    empre_Descripcion: new FormControl(data[0].empre_Descripcion, Validators.required),
                    empre_Direccion: new FormControl(data[0].empre_Direccion, Validators.required),
                    ciud_Id: new FormControl(data[0].ciud_Id, Validators.required),
                    esta_Id: new FormControl(data[0].esta_Id,Validators.required),
                });

                this.ciudadID = data[0].ciud_Id;
                console.log("LA DATA: " + data[0] + " ID CIUDAD: " + this.ciudadID)
                this.serviceEmp.getDdlCiudades(data[0].esta_Id).subscribe(
                    (data: any) => {
                      this.ciudadesddl = data;
                      this.editarEmpresaForm.get('ciud_Id').setValue(this.ciudadID);
                    }
                  );



              this.CollapseEdit = true;
              this.Tabla=false;

              console.log(data)

              }
            });
          }


    cancelar()
    {
        this.CollapseEdit=false;
        this.Tabla=true;
        this.isSubmitEdit=false

    }


    detalles(id){

        this.serviceEmp.fillEmpresa(id).subscribe({
            next: (data: Role) => {
               this.empreId = data[0].empre_Id,
               this.empreDescripcion = data[0].empre_Descripcion,
               this.empreDireccion = data[0].empre_Direccion,
               this.ciudad = data[0].ciud_Descripcion,
               this.UsuarioCreacion = data[0].UsuarioCreacion,
               this.FechaCreacion = data[0].empre_FechaCreacion,
               this.UsuarioModificacion = data[0].UsuarioModificacion,
               this.FechaModificacion = data[0].empre_FechaModificacion
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }


}

