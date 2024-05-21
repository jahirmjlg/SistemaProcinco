import {ChangeDetectorRef,  Component } from '@angular/core';
import {EmpleadosService} from '../../Services/empleados.service';
import {Empleado} from 'src/app/Models/EmpleadosViewModel';
import {Router} from '@angular/router';
import { Product } from 'src/app/demo/api/product';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { TitulosporempleadoService } from 'src/app/Services/titulosporempleado.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { dropEstados } from 'src/app/Models/EstadoViewModel';
import { dropCargos } from 'src/app/Models/CargosViewModel';
import { dropEstadosCiviles } from 'src/app/Models/EstadosCivilesViewModel';
import { dropCiudades } from 'src/app/Models/CiudadViewModel';
import { Titulo } from 'src/app/Models/TitulosViewModel';
import { TitulosService } from 'src/app/Services/titulos.service';


@Component({
  selector: 'app-list-empleados',
  templateUrl: './list-empleados.component.html',
  styleUrls: ['./list-empleados.component.scss'],
  providers: [MessageService, ConfirmationService]
})
export class ListEmpleadosComponent {


    Tabla: boolean = true;

  //   variable para iterar

    empleado! : Empleado[];
    titulos! : Titulo[];

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


                ID: String = "";

                itemsGroup1: { titl_Id: number, titl_Descripcion: string }[] = [];
                itemsGroup2: { titl_Id: number, titl_Descripcion: string }[] = [];

                itemsGroup1Edit: { titl_Id: number, titl_Descripcion: string }[] = [];
                itemsGroup2Edit: { titl_Id: number, titl_Descripcion: string }[] = [];




        //VARIABLE EN LA QUE ITERA EL DDL
    estadosddl: any[] = [];
    cargosddl: any[] = [];
    estadosCivilesddl: any[] = [];
    ciudadesddl: any[] = [];

    ciudadID: String = "";

    titulo!:Titulo[];



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
    ciudad: String = "";
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


      emple! : Empleado;
      title! : Titulo;



    //CREAR EL FORMGROUP EN EL QUE SE CREAN LAS PROPIEDADES
    crearEmpleadoForm: FormGroup
    editarEmpleadoForm: FormGroup




    constructor(
               private cdRef: ChangeDetectorRef,
               private messageService: MessageService,
                private empleadoservice: EmpleadosService,
                private router: Router,
                private formBuilder: FormBuilder,
                private cookieService: CookieService,
                 private tituloService: TitulosService,
               private tituloporempleadoservice: TitulosporempleadoService,
              ) {}

     validarNumeros(event: KeyboardEvent) {
      const errorSpan = document.getElementById('error-span');
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


validarTextoAlfa(event: KeyboardEvent) {
  if (!/^[a-zA-Z0-9 ]+$/.test(event.key) && event.key !== 'Backspace' && event.key !== 'Tab' && event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') {
      event.preventDefault();
  }
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
            screens: this.formBuilder.array([])


          });

          this.editarEmpleadoForm = this.formBuilder.group({
            empl_Id: ['', Validators.required],
            empl_DNI: ['', Validators.required],
            carg_Id: ['', Validators.required],
            empl_Nombre: ['', Validators.required],
            empl_Apellido: ['', Validators.required],
            empl_Correo: ['', Validators.required],
            empl_FechaNacimiento: ['', Validators.required],
            empl_Sexo: ['', Validators.required],
            estc_Id: ['', Validators.required],
            empl_Direccion: ['', Validators.required],
            esta_Id: ['', Validators.required],
            ciud_Id: ['', Validators.required],
            screens: this.formBuilder.array([])
        });
    


        this.empleadoservice.getDdlEstados().subscribe((data: dropEstados[]) => {
            this.estadosddl = data;
            console.log(data);
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


        this.tituloService.getTitulos().subscribe((Response: any)=>{
          console.log('RESPUESTA API: ' + Response.data);
          this.itemsGroup1 = Response.data;
      });


 
      this.empleadoservice.getTitulos().subscribe(data => {
        this.itemsGroup1 = data;
        console.log(data);
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



    cancel()
    {
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
            screens: this.formBuilder.array([])


          });

          this.Collapse=false;
          this.Tabla=true;
          this.isSubmit=false
    }


    gettitlesArray(): FormArray {
      return this.crearEmpleadoForm.get('screens') as FormArray;
  }

    addTitle(screens): void {
      this.gettitlesArray().push(
          this.formBuilder.group({
              titl_Id: [screens.titl_Id, Validators.required],
              titl_Descripcion: [screens.titl_Descripcion, Validators.required]
          })
      );
  }


  getScreensArrayEdit(): FormArray {
      return this.editarEmpleadoForm.get('screens') as FormArray;
  }

    addScreenEdit(screens): void {
      this.getScreensArrayEdit().push(
          this.formBuilder.group({
            titl_Id: [screens.titl_Id, Validators.required],
            titl_Descripcion: [screens.titl_Descripcion, Validators.required]
          })
      );
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
          this.itemsGroup2.forEach(screen => this.addTitle(screen));
          console.log(empleadoData[0]);
          this.empleadoservice.insertEmpleado(this.crearEmpleadoForm.value).subscribe(
            response => {

                if (response.code == 200) {

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
                        screens: this.formBuilder.array([])


                      });

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
          const contenidoData: Empleado = this.editarEmpleadoForm.value;
          this.itemsGroup2Edit.forEach(screen => this.addScreenEdit(screen));
  
          console.log(this.editarEmpleadoForm.value);
          this.empleadoservice.editEmpleado(this.editarEmpleadoForm.value).subscribe(
              response => {
                  if (response.code == 200) {
                      this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Rol Editado Exitosamente', life: 3000 });
                      console.log(response);
                      this.empleadoservice.getEmpleado().subscribe((Response: any) => {
                          console.log(Response.data);
                          this.empleado = Response.data;
                      });
  
                      this.CollapseEdit = false;
                      this.Tabla = true;
  
                      this.editarEmpleadoForm.reset();
                  } else {
                      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Editar el Empleado', life: 3000 });
                  }
              },
              error => {
                  console.log(error);
              }
          );
      } else {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Editar el Empleado', life: 3000 });

          // console.log('Formulario inválido');
          // console.log('Invalido: ' + this.editarEmpleadoForm.get('empl_Id')?.value +
          //     ' 2: ' + this.editarEmpleadoForm.get('empl_Nombre')?.value + ' 3: ' +
          //     this.editarEmpleadoForm.get('screens')?.value);
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
               this.ciudad = data[0].ciud_Descripcion;
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
    deleteEmpleado(id) {
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
        this.itemsGroup1Edit = [];
        this.itemsGroup2Edit = [];
        this.editarEmpleadoForm.reset();

        this.empleadoservice.fillEmpleado(id).subscribe({
            next: (data: Empleado) => {


                this.tituloService.getTitulosFiltro(id).subscribe((Response: any)=>{
                    var titulos = Response;
                    titulos.forEach(item => {
                        this.itemsGroup1Edit.push({
                            titl_Id: item.titl_Id,
                            titl_Descripcion: item.pant_Descripcion
                        })

                    });
                    this.cdRef.detectChanges();

        });



                this.editarEmpleadoForm = new FormGroup({
                    empl_Id: new FormControl(id,Validators.required),
                    empl_DNI: new FormControl(data[0].empl_DNI,Validators.required),
                    carg_Id: new FormControl(data[0].carg_Id,Validators.required),
                    empl_Nombre: new FormControl(data[0].empl_Nombre,Validators.required),
                    empl_Apellido: new FormControl(data[0].empl_Apellido,Validators.required),
                    empl_Correo: new FormControl(data[0].empl_Correo,Validators.required),
                    empl_FechaNacimiento: new FormControl(data[0].empl_FechaNacimiento,Validators.required),
                    empl_Sexo: new FormControl(data[0].empl_Sexo,Validators.required),
                    estc_Id: new FormControl(data[0].estc_Id,Validators.required),
                    empl_Direccion: new FormControl(data[0].empl_Direccion,Validators.required),
                    esta_Id: new FormControl(data[0].esta_Id,Validators.required),
                    ciud_Id: new FormControl(data[0].ciud_Id,Validators.required),
                });
                this.ciudadID = data[0].ciud_Id;
                console.log("LA DATA: " + data[0] + " ID CIUDAD: " + this.ciudadID)
                this.empleadoservice.getDdlCiudades(data[0].esta_Id).subscribe(
                    (data: any) => {
                      this.ciudadesddl = data;
                      this.editarEmpleadoForm.get('ciud_Id').setValue(this.ciudadID);
                    }
                  );


                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
          });

    }







      //EVENTOS DRAG

      itemsRemoved(ev, list) {
        if (list === 1) {
            console.log("SI entra")
          this.itemsGroup2.push(...ev.filter(item => !this.itemsGroup2.some(existing => existing.titl_Id === item.titl_Id)));
          this.itemsGroup1 = this.itemsGroup1.filter(item => !ev.some(removedItem => removedItem.titl_Id === item.titl_Id));
        } else {
          this.itemsGroup1.push(...ev.filter(item => !this.itemsGroup1.some(existing => existing.titl_Id === item.titl_Id)));
          this.itemsGroup2 = this.itemsGroup2.filter(item => !ev.some(removedItem => removedItem.titl_Id === item.titl_Id));
        }
      }

      itemsAdded(ev: any[], list: number) {

        if (list === 1) {
            ev.forEach(item => {
                if (!this.itemsGroup1.some(existing => existing.titl_Id === item.titl_Id)) {
                    this.itemsGroup1.push(item);
                }
            });
        } else {
            ev.forEach(item => {
                if (!this.itemsGroup2.some(existing => existing.titl_Id === item.titl_Id)) {
                    this.itemsGroup2.push(item);
                }
            });
        }

        if (list === 1) {
            this.itemsGroup2 = this.itemsGroup2.filter(item => !ev.some(addedItem => addedItem.titl_Id === item.titl_Id));
        } else {
            this.itemsGroup1 = this.itemsGroup1.filter(item => !ev.some(addedItem => addedItem.titl_Id === item.titl_Id));
        }
    }
      itemsUpdated(ev, list) {
      }

      selectionChanged(ev, list) {
      }







      ///EDITAR

      itemsRemovedEdit(ev, list) {
        if (list === 1) {
          // Mover de la primera tabla a la segunda.
          this.itemsGroup2Edit.push(...ev.filter(item => !this.itemsGroup2Edit.some(existing => existing.titl_Id === item.titl_Id)));
          this.itemsGroup1Edit = this.itemsGroup1Edit.filter(item => !ev.some(removedItem => removedItem.titl_Id === item.titl_Id));
        } else {
          // Mover de la segunda tabla a la primera.
          this.itemsGroup1Edit.push(...ev.filter(item => !this.itemsGroup1Edit.some(existing => existing.titl_Id === item.titl_Id)));
          this.itemsGroup2Edit = this.itemsGroup2Edit.filter(item => !ev.some(removedItem => removedItem.titl_Id === item.titl_Id));
        }
        }

      itemsAddedEdit(ev: any[], list: number) {

        if (list === 1) {
            ev.forEach(item => {
                if (!this.itemsGroup1Edit.some(existing => existing.titl_Id === item.titl_Id)) {
                    this.itemsGroup1Edit.push(item);
                }
            });
        } else {
            ev.forEach(item => {
                if (!this.itemsGroup2Edit.some(existing => existing.titl_Id === item.titl_Id)) {
                    this.itemsGroup2Edit.push(item);
                }
            });
        }

        if (list === 1) {
            this.itemsGroup2Edit = this.itemsGroup2Edit.filter(item => !ev.some(addedItem => addedItem.titl_Id === item.titl_Id));
        } else {
            this.itemsGroup1Edit = this.itemsGroup1Edit.filter(item => !ev.some(addedItem => addedItem.titl_Id === item.titl_Id));
        }
        }




        Fill1(id) {
          this.itemsGroup1Edit = [];
          this.itemsGroup2Edit = [];
          this.editarEmpleadoForm.reset();
      
          this.empleadoservice.fillEmpleado(id).subscribe({
              next: (data: Empleado) => {
                  this.empleadoservice.getTitulosFiltro(id).subscribe((Response: any) => {
                      var pantallas = Response;
                      pantallas.forEach(item => {
                          this.itemsGroup1Edit.push({
                              titl_Id: item.titl_Id,
                              titl_Descripcion: item.titl_Descripcion
                          });
                      });
                      this.cdRef.detectChanges();
                  });
      
                  this.empleadoservice.getTitulosPorRol(id).subscribe((Response: any) => {
                      var titulosfiltro = Response;
                      titulosfiltro.forEach(item => {
                          this.itemsGroup2Edit.push({
                              titl_Id: item.titl_Id,
                              titl_Descripcion: item.titl_Descripcion
                          });
                      });
                  });
      
                  this.editarEmpleadoForm.patchValue({
                      empl_Id: id,
                      empl_DNI: data[0]?.empl_DNI || '',
                      carg_Id: data[0]?.carg_Id || '',
                      empl_Nombre: data[0]?.empl_Nombre || '',
                      empl_Apellido: data[0]?.empl_Apellido || '',
                      empl_Correo: data[0]?.empl_Correo || '',
                      empl_FechaNacimiento: data[0]?.empl_FechaNacimiento || '',
                      empl_Sexo: data[0]?.empl_Sexo || '',
                      estc_Id: data[0]?.estc_Id || '',
                      empl_Direccion: data[0]?.empl_Direccion || '',
                      esta_Id: data[0]?.esta_Id || '',
                      ciud_Id: data[0]?.ciud_Id || ''
                  });
      
                  this.ciudadID = data[0]?.ciud_Id || '';
                  this.empleadoservice.getDdlCiudades(data[0]?.esta_Id).subscribe(
                      (data: any) => {
                          this.ciudadesddl = data;
                          this.editarEmpleadoForm.get('ciud_Id')?.setValue(this.ciudadID);
                      }
                  );
      
                  setTimeout(() => {
                      const inputElement = document.getElementById('miInput');
                      if (inputElement) {
                          inputElement.click();
                      } else {
                          console.warn("Element with id 'miInput' not found.");
                      }
                  }, 250);
      
                  this.CollapseEdit = true;
                  this.Tabla = false;
      
                  console.log(data);
              }
          });
      }
      



      cancelar()
      {
          this.CollapseEdit=false;
          this.Tabla=true;
          this.isSubmitEdit=false
          this.itemsGroup1Edit = []
          this.itemsGroup2Edit = []

      }




}
