import { ChangeDetectorRef, Component, ElementRef, ViewChild } from '@angular/core';
import {RolesService} from '../../Services/roles.service';
import {Role} from 'src/app/Models/RolesViewModel';
import {Router} from '@angular/router';
import { PantallasService } from 'src/app/Services/pantallas.service';
import { Pantalla } from 'src/app/Models/PantallasViewModel';
import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, AfterContentInit } from '@angular/core';
import { FormBuilder, FormControl, FormArray, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { PantallasPorRolesService } from 'src/app/Services/pantallas-por-roles.service';
import { PantallaPorRol } from 'src/app/Models/PantallasPorRolesViewModel';

@Component({
  selector: 'app-list-roles',
  templateUrl: './list-roles.component.html',
  styleUrls: ['./list-roles.component.scss'],
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

    itemsGroup1: { pant_Id: number, pant_Descripcion: string }[] = [];
    itemsGroup2: { pant_Id: number, pant_Descripcion: string }[] = [];

    itemsGroup1Edit: { pant_Id: number, pant_Descripcion: string }[] = [];
    itemsGroup2Edit: { pant_Id: number, pant_Descripcion: string }[] = [];


  cols: any[] = [];
  statuses: any[] = [];
  rowsPerPageOptions = [5, 10, 20];
  schemas = [
      CUSTOM_ELEMENTS_SCHEMA
    ];

  //   variable para iterar
  role!:Role[];
  pantalla!:Pantalla[];

  crearRolForm: FormGroup
  editarRolForm: FormGroup


  //Detalle
  roleId : Number = 0;
  roleDescripcion : String = "";
  roleFechaCreacion: String = "";
  roleFechaModificacion: String = "";
  usuariocreacion: String = "";
  usuariomodificacion: String = "";



  //ultimos dos
  constructor(private cdRef: ChangeDetectorRef, private messageService: MessageService, private service: RolesService, private router: Router, private formBuilder: FormBuilder, private cookieService: CookieService, private pantallaservice: PantallasService, private paroservice : PantallasPorRolesService ) { }

  ngOnInit() {
    this.crearRolForm = this.formBuilder.group({
        role_Descripcion: ['', [Validators.required]],
        screens: this.formBuilder.array([])
    });

    this.editarRolForm = new FormGroup({
        role_Id: new FormControl("",Validators.required),
        role_Descripcion: new FormControl("", Validators.required),
        screens: this.formBuilder.array([])
    })

    // Respuesta de la api
    this.service.getRol().subscribe((Response: any)=> {
        console.log(Response.data);
        this.role = Response.data;
    }, error=>{
        console.log(error);
    });

    this.pantallaservice.getPantalla().subscribe((Response: any)=>{
        console.log(Response.data);
        this.pantalla = Response.data;
    });
        //


        this.service.getPantallas().subscribe(data => {
            this.itemsGroup1 = data;
            console.log(data);
          });



      this.schemas = [
          CUSTOM_ELEMENTS_SCHEMA
        ];
  }

  getScreensArray(): FormArray {
    return this.crearRolForm.get('screens') as FormArray;
}

  addScreen(screen): void {
    this.getScreensArray().push(
        this.formBuilder.group({
            pant_Id: [screen.pant_Id, Validators.required],
            pant_Description: [screen.pant_Description, Validators.required]
        })
    );
}


getScreensArrayEdit(): FormArray {
    return this.editarRolForm.get('screens') as FormArray;
}

  addScreenEdit(screen): void {
    this.getScreensArrayEdit().push(
        this.formBuilder.group({
            pant_Id: [screen.pant_Id, Validators.required],
            pant_Description: [screen.pant_Description, Validators.required]
        })
    );
}


  onSubmitInsert(): void {

    this.isSubmit = true;

    const errorSpan = document.getElementById('error-span');
    if (this.crearRolForm.valid) {
      const contenidoData: Role = this.crearRolForm.value;
      this.itemsGroup2.forEach(screen => this.addScreen(screen));


      console.log(contenidoData);
      this.service.insertRol(this.crearRolForm.value).subscribe(
       response => {
        if (response.code == 200)
        {
            this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Rol Insertado Exitosamente', life: 3000 });

            console.log(response)
            this.service.getRol().subscribe((Response: any)=> {
                console.log(Response.data);
                this.role = Response.data;
            });

                this.Collapse = false;
                this.Tabla = true;
        } else {

            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Agregar el Rol', life: 3000 });
            }

        },
        error => {
            console.log(error)
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
          this.itemsGroup2Edit.forEach(screen => this.addScreenEdit(screen));


          console.log(this.editarRolForm.value);
          this.service.editRol(this.editarRolForm.value).subscribe(
           response => {
            if (response.code == 200)
            {
                this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Rol Editado Exitosamente', life: 3000 });

                console.log(response)
                this.service.getRol().subscribe((Response: any)=> {
                    console.log(Response.data);
                    this.role = Response.data;
                });

                    this.CollapseEdit = false;
                    this.Tabla = true;
                    // window.location.reload();

                    this.editarRolForm = new FormGroup({
                        role_Id: new FormControl("",Validators.required),
                        role_Descripcion: new FormControl("", Validators.required),
                        screens: this.formBuilder.array([])
                    })

            } else {

                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Editar el Rol', life: 3000 });
                }

            },
            error => {
                console.log(error)
            }
            );
            } else {
            console.log('Formulario inválido');
            console.log('Invalido: ' + this.editarRolForm.get('role_Id').value +
             ' 2: ' + this.editarRolForm.get('role_Descripcion').value + ' 3: ' +
             this.editarRolForm.get('screens').value)


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


    //EVENTOS DRAG

    itemsRemoved(ev, list) {
        if (list === 1) {
          // Mover de la primera tabla a la segunda.
          this.itemsGroup2.push(...ev.filter(item => !this.itemsGroup2.some(existing => existing.pant_Id === item.pant_Id)));
          this.itemsGroup1 = this.itemsGroup1.filter(item => !ev.some(removedItem => removedItem.pant_Id === item.pant_Id));
        } else {
          // Mover de la segunda tabla a la primera.
          this.itemsGroup1.push(...ev.filter(item => !this.itemsGroup1.some(existing => existing.pant_Id === item.pant_Id)));
          this.itemsGroup2 = this.itemsGroup2.filter(item => !ev.some(removedItem => removedItem.pant_Id === item.pant_Id));
        }
      }

      itemsAdded(ev: any[], list: number) {

        if (list === 1) {
            ev.forEach(item => {
                if (!this.itemsGroup1.some(existing => existing.pant_Id === item.pant_Id)) {
                    this.itemsGroup1.push(item);
                }
            });
        } else {
            ev.forEach(item => {
                if (!this.itemsGroup2.some(existing => existing.pant_Id === item.pant_Id)) {
                    this.itemsGroup2.push(item);
                }
            });
        }

        if (list === 1) {
            this.itemsGroup2 = this.itemsGroup2.filter(item => !ev.some(addedItem => addedItem.pant_Id === item.pant_Id));
        } else {
            this.itemsGroup1 = this.itemsGroup1.filter(item => !ev.some(addedItem => addedItem.pant_Id === item.pant_Id));
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
          this.itemsGroup2Edit.push(...ev.filter(item => !this.itemsGroup2Edit.some(existing => existing.pant_Id === item.pant_Id)));
          this.itemsGroup1Edit = this.itemsGroup1Edit.filter(item => !ev.some(removedItem => removedItem.pant_Id === item.pant_Id));
        } else {
          // Mover de la segunda tabla a la primera.
          this.itemsGroup1Edit.push(...ev.filter(item => !this.itemsGroup1Edit.some(existing => existing.pant_Id === item.pant_Id)));
          this.itemsGroup2Edit = this.itemsGroup2Edit.filter(item => !ev.some(removedItem => removedItem.pant_Id === item.pant_Id));
        }
        }

      itemsAddedEdit(ev: any[], list: number) {

        if (list === 1) {
            ev.forEach(item => {
                if (!this.itemsGroup1Edit.some(existing => existing.pant_Id === item.pant_Id)) {
                    this.itemsGroup1Edit.push(item);
                }
            });
        } else {
            ev.forEach(item => {
                if (!this.itemsGroup2Edit.some(existing => existing.pant_Id === item.pant_Id)) {
                    this.itemsGroup2Edit.push(item);
                }
            });
        }

        if (list === 1) {
            this.itemsGroup2Edit = this.itemsGroup2Edit.filter(item => !ev.some(addedItem => addedItem.pant_Id === item.pant_Id));
        } else {
            this.itemsGroup1Edit = this.itemsGroup1Edit.filter(item => !ev.some(addedItem => addedItem.pant_Id === item.pant_Id));
        }
        }


      Fill(id) {
        this.itemsGroup1Edit = [];
    this.itemsGroup2Edit = [];
    this.editarRolForm.reset();

        this.service.fillRol(id).subscribe({
            next: (data: Role) => {
                this.service.getPantallasFiltro(id).subscribe((Response: any)=>{
                    var pantallas = Response;
                            pantallas.forEach(item => {
                                this.itemsGroup1Edit.push({
                                    pant_Id: item.pant_Id,
                                    pant_Descripcion: item.pant_Descripcion
                                })

                            });
                            this.cdRef.detectChanges();

                });

                        this.service.getPantallasPorRol(id).subscribe((Response: any)=>{
                            var pantallasfiltro = Response;
                            pantallasfiltro.forEach(item => {
                                this.itemsGroup2Edit.push({
                                    pant_Id: item.pant_Id,
                                    pant_Descripcion: item.pant_Descripcion
                                })

                            });
                        });




                this.editarRolForm.get('role_Id').setValue(data[0].role_Id);
                this.editarRolForm.get('role_Descripcion').setValue(data[0].role_Descripcion);

                setTimeout(() => {
                    document.getElementById('miInput').click();
                  }, 250);

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
        this.itemsGroup1Edit = []
        this.itemsGroup2Edit = []

    }


    detalles(id){

        this.service.fillRol(id).subscribe({
            next: (data: Role) => {
               this.roleId = data[0].role_Id,
               this.roleDescripcion = data[0].role_Descripcion,
               this.usuariocreacion = data[0].usuarioCreacion,
               this.usuariomodificacion = data[0].usuarioModificacion,
               this.roleFechaCreacion = data[0].role_FechaCreacion,
               this.roleFechaModificacion = data[0].role_FechaModificacion
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }


}
