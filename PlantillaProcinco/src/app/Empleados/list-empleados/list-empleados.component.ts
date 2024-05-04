import { Component } from '@angular/core';
import {EmpleadosService} from '../../Services/empleados.service';
import {Empleado} from 'src/app/Models/EmpleadosViewModel';
import {Router} from '@angular/router';

import { Product } from 'src/app/demo/api/product';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { dropEstados } from 'src/app/Models/EstadoViewModel';
import { dropCargos } from 'src/app/Models/CargosViewModel';
import { dropEstadosCiviles } from 'src/app/Models/EstadosCivilesViewModel';
import { dropCiudades } from 'src/app/Models/CiudadViewModel';

@Component({
  selector: 'app-list-empleados',
  templateUrl: './list-empleados.component.html',
  providers: [MessageService]
})
export class ListEmpleadosComponent {


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
                deleteEmpleadoBool: boolean = false;


        //VARIABLE EN LA QUE ITERA EL DDL
    estadosddl: any[] = [];
    cargosddl: any[] = [];
    estadosCivilesddl: any[] = [];
    ciudadesddl: any[] = [];


    // DETALLE
    empID: number = 0;
    empDNI: String = "";
    cargo: String = "";
    empNombre: String = "";
    empApellido: String = "";
    empCorreo: String = "";
    empFechaNacimiento: String = "";
    empSexo: String = "";
    estadoCivil: String = "";
    empDireccion: String = "";
    empSalarioHora: number = 0;
    ciudades: String = "";
    UsuarioCreacion: String = "";
    UsuarioModificacion: String = "";
    FechaCreacion: String = "";
    FechaModificacion: String = "";



    //IGNORAR (DESTACAR QUE ES LO UNICO NECESARIO(DEPURAR TODO LO DEMAS))
    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];


    //   variable para iterar
    empleado!:Empleado[];

    //CREAR EL FORMGROUP EN EL QUE SE CREAN LAS PROPIEDADES
    crearEmpleadoForm: FormGroup
    editarEmpleadoForm: FormGroup




    constructor(private empleadoservice: EmpleadosService, private router: Router,
                private formBuilder: FormBuilder, private cookieService: CookieService,
                private messageService: MessageService) {


     }

    ngOnInit() {

        //INICIALIZAR EL FORMULARIO
        this.crearEmpleadoForm = this.formBuilder.group({
            empl_DNI: ['', [Validators.required]],
            carg_Id: ['0', [Validators.required]],
            empl_Nombre: ['', [Validators.required]],
            empl_Apellido: ['', [Validators.required]],
            empl_Correo: ['', [Validators.required]],
            empl_FechaNacimiento: ['', [Validators.required]],
            empl_Sexo: ['', [Validators.required]],
            estc_Id: ['0', [Validators.required]],
            empl_Direccion: ['', [Validators.required]],
            ciud_Id: ['0', [Validators.required]],
            esta_Id: ['0', [Validators.required]],
          });

          this.editarEmpleadoForm = new FormGroup({
            empl_Id: new FormControl("",Validators.required),
            empl_DNI: new FormControl("",Validators.required),
            carg_Id: new FormControl("0",Validators.required),
            empl_Nombre: new FormControl("",Validators.required),
            empl_Apellido: new FormControl("",Validators.required),
            empl_Correo: new FormControl("",Validators.required),
            empl_FechaNacimiento: new FormControl("",Validators.required),
            empl_Sexo: new FormControl("",Validators.required),
            estc_Id: new FormControl("0",Validators.required),
            empl_Direccion: new FormControl("",Validators.required),
            ciud_Id: new FormControl("0",Validators.required),
        });


        var ddlestado = document.getElementById('esta_Id');

        this.empleadoservice.getDdlEstados().subscribe((data: dropEstados[]) => {
            this.estadosddl = data;
            console.log(data);
            ddlestado.nodeValue = "0";

        }, error => {
            console.log(error);
        });

        this.empleadoservice.getDdlCargos().subscribe((data: dropCargos[]) => {
            this.cargosddl = data;
            console.log(data);
        }, error => {
            console.log(error);
        });

        this.empleadoservice.getDdlEstadosCiviles().subscribe((data: dropEstadosCiviles[]) => {
            this.estadosCivilesddl = data;
            console.log(data);
        }, error => {
            console.log(error);
        });

        // this.empleadoservice.getDdlCiudades().subscribe((data: dropCiudades[]) => {
        //     this.ciudadesddl = data;
        //     console.log(data);
        // }, error => {
        //     console.log(error);
        // });



        // Respuesta de la api
        this.empleadoservice.getEmpleado().subscribe((Response: any)=> {
            console.log(Response.data);
            this.empleado = Response.data;

          }, error=>{
            console.log(error);
          });

          //




        this.schemas = [
            CUSTOM_ELEMENTS_SCHEMA
          ];
    }


    onEstadoChange(estadoID) {
        if (estadoID !== '0') {
          this.empleadoservice.getDdlCiudades(estadoID).subscribe(
            (data: any) => {
              this.ciudadesddl = data;
              this.crearEmpleadoForm.get('ciud_Id').setValue('0');
            },
            error => {
              console.error('Errorr:', error);
            }
          );
        } else {
          this.ciudadesddl = []; // Clear municipios if the department is invalid or reset
        }
      }



    //INSERTAR
    onSubmitInsert(): void {

        this.isSubmit = true;

            const errorSpan = document.getElementById('error-span');
        if (this.crearEmpleadoForm.valid) {
          const empleadoData: Empleado = this.crearEmpleadoForm.value;
          this.empleadoservice.insertEmpleado(empleadoData).subscribe(
            response => {

                if (response.code == 200) {

                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.empleadoservice.getEmpleado().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.empleado = Response.data;
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

        if (this.editarEmpleadoForm.valid) {
          const empleadoData: Empleado = this.editarEmpleadoForm.value;
          this.empleadoservice.editEmpleado(empleadoData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.empleadoservice.getEmpleado().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.empleado = Response.data;
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
        this.empleadoservice.fillEmpleado(id).subscribe({
            next: (data: Empleado) => {
               this.empID = data[0].empl_Id;
               this.empDNI = data[0].empl_DNI;
               this.cargo = data[0].cargo;
               this.empNombre = data[0].empl_Nombre;
               this.empApellido = data[0].empl_Apellido;
               this.empCorreo = data[0].empl_Correo;
               this.empFechaNacimiento = data[0].empl_FechaNacimiento;
               this.empSexo = data[0].empl_Sexo;
               this.estadoCivil = data[0].estadoCivil;
               this.empDireccion = data[0].empl_Direccion;
               this.empSalarioHora = data[0].empl_SalarioHora;
               this.ciudades = data[0].ciudades;
               this.UsuarioCreacion = data[0].usuarioCreacion;
               this.UsuarioModificacion = data[0].usuarioModificacion;
               this.FechaCreacion = data[0].empl_FechaCreacion;
               this.FechaModificacion = data[0].empl_FechaModificacion;
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }




    //DELETE
    deleteCiudad(id) {
        this.deleteEmpleadoBool = true;
        this.empID = id;
        console.log("ID" + id);
    }

    confirmDelete() {
        this.empleadoservice.deleteEmpleado(this.empID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.empleadoservice.getEmpleado().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.empleado = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });

                    this.Tabla=true;

                    this.deleteEmpleadoBool = false;

                   }
                else{
                    console.log(response)
                this.deleteEmpleadoBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
            }
        },
    });

    }





    //LLENAR EDITAR && DETALLE
    Fill(id) {
        this.empleadoservice.fillEmpleado(id).subscribe({
            next: (data: Empleado) => {
                this.editarEmpleadoForm = new FormGroup({
                    empl_Id: new FormControl(data[0].empl_Id,Validators.required),
                    empl_DNI: new FormControl(data[0].empl_DNI,Validators.required),
                    carg_Id: new FormControl(data[0].carg_Id,Validators.required),
                    empl_Nombre: new FormControl(data[0].empl_Nombre,Validators.required),
                    empl_Apellido: new FormControl(data[0].empl_Apellido,Validators.required),
                    empl_Correo: new FormControl(data[0].empl_Correo,Validators.required),
                    empl_FechaNacimiento: new FormControl(data[0].empl_FechaNacimiento,Validators.required),
                    empl_Sexo: new FormControl(data[0].empl_Sexo,Validators.required),
                    estc_Id: new FormControl(data[0].estc_Id,Validators.required),
                    empl_Direccion: new FormControl(data[0].empl_Direccion,Validators.required),
                    ciud_Id: new FormControl(data[0].ciud_Id,Validators.required),
                });

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
          });

    }

}
