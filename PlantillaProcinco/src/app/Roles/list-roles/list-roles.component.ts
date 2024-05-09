import { Component } from '@angular/core';
import {RolesService} from '../../Services/roles.service';
import {Role} from 'src/app/Models/RolesViewModel';
import {Router} from '@angular/router';
import { PantallasService } from 'src/app/Services/pantallas.service';
import { Pantalla } from 'src/app/Models/PantallasViewModel';
import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
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
  crearParoForm: FormGroup

  //ultimos dos
  constructor(private messageService: MessageService, private service: RolesService, private router: Router, private formBuilder: FormBuilder, private cookieService: CookieService, private pantallaservice: PantallasService, private paroservice : PantallasPorRolesService ) { }

  ngOnInit() {
    this.crearRolForm = this.formBuilder.group({
        role_Descripcion: ['', [Validators.required]],
        screens: this.formBuilder.array([])
    });

    this.editarRolForm = new FormGroup({
        role_Id: new FormControl("",Validators.required),
        role_Descripcion: new FormControl("", Validators.required),
    })

    this.crearParoForm = this.formBuilder.group({
        role_Id: [0, [Validators.required]],
        checkboxes: this.formBuilder.group({})
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

   onCheckboxChange(checked: boolean, id: number) {
    const checkboxGroup = this.crearParoForm.get('checkboxes') as FormGroup;

    if (checked) {
      checkboxGroup.addControl(id.toString(), this.formBuilder.control(true));
      console.log(checkboxGroup);
    } else {
      checkboxGroup.removeControl(id.toString());
    }
  }

  submitForm(): void {
    if (this.crearParoForm.valid) {
      const pantallasSeleccionadas = Object.keys(this.crearParoForm.get('checkboxes').value);

      // Crear un objeto PantallaPorRol para cada checkbox seleccionado y enviarlo
      pantallasSeleccionadas.forEach(id => {
        const paroInsertar: PantallaPorRol = {
          paPr_Id: null,
          pant_Id: id,
          pantalla: '', // Debes llenar este campo con el valor correspondiente
          role_Id: 7,
          rol: '', // Debes llenar este campo con el valor correspondiente
          paPr_UsuarioCreacion: 1, // Debes llenar este campo con el valor correspondiente
          paPr_FechaCreacion: '', // Debes llenar este campo con el valor correspondiente
          paPr_UsuarioModificacion: null,
          paPr_FechaModificacion: '', // Debes llenar este campo con el valor correspondiente
          paPr_Estado: null,
          creacion: '', // Debes llenar este campo con el valor correspondiente
          modificacion: '' // Debes llenar este campo con el valor correspondiente
        };

        // Llamar al servicio para insertar el registro de PantallaPorRol
        this.paroservice.insertPantallaPorRol(paroInsertar).subscribe(
          response => {
      console.log("NO ENTRA ESTA MIERDA");
      // Manejar la respuesta del servicio
          },
          error => {
            console.error('Error al insertar el registro de PantallaPorRol:', error);
          }
        );
      });
    } else {
      console.log('Formulario inválidoo');

    }
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
        // Aquí puedes manejar si necesitas una lógica adicional para los datos actualizados.
      }

      selectionChanged(ev, list) {
        // Opcional: manejar cambios en la selección.
      }






//     events = [];

//   clearEvents(): void {
//     this.events = [];
//   }

//   itemsRemoved(ev, list) {
//     this.events.push({text: `itemsRemoved from ${list}`, ev: JSON.stringify(ev)});
//   }

//   itemsAdded(ev, list) {
//     this.events.push({text: `itemsAdded to ${list}`, ev: JSON.stringify(ev)});
//   }

//   itemsUpdated(ev, list) {
//     this.events.push({text: `itemsUpdated in ${list}`, ev: JSON.stringify(ev)});
//   }

//   selectionChanged(ev, list) {
//     this.events.push({text: `selectionChanged in ${list}`, ev: JSON.stringify(ev)});
//   }

}
