import { Component } from '@angular/core';
import {CargosService} from '../../Services/cargos.service';
import {Cargo} from 'src/app/Models/CargosViewModel';
import {Router} from '@angular/router';

import { Message, ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-list-cargos',
  styleUrls: ['./list-cargos.scss'],
  templateUrl: './list-cargos.component.html',
  providers: [ConfirmationService, MessageService]

})
export class ListCargosComponent {
    
  Tabla: boolean = true;

  Collapse: boolean = false;
  isSubmit: boolean = false;
  msgs: Message[] = [];


  CollapseEdit: boolean = false;
  isSubmitEdit: boolean = false;
    
  CollapseDetalle: boolean = false;

    //BOOLEAN DELETE
  deleteCargoBool: boolean = false;

  cols: any[] = [];
  statuses: any[] = [];
  rowsPerPageOptions = [5, 10, 20];
  schemas = [
      CUSTOM_ELEMENTS_SCHEMA
    ];


    // DETALLE
    carg_Id: String = "";
    Cargo: String = "";
    UsuarioCreacion: String = "";
    UsuarioModificacion: String = "";
    FechaCreacion: String = "";
    FechaModificacion: String = "";
    ID: String = "";

  //   variable para iterar
  cargo!:Cargo[];


  crearCargoForm: FormGroup
  editarCargoForm: FormGroup
  //ultimos dos
  constructor(private messageService: MessageService, private cargoservice: CargosService, private router: Router, private formBuilder: FormBuilder, private cookieService: CookieService) { }

  ngOnInit() {


    this.crearCargoForm = this.formBuilder.group({
      carg_Descripcion: ['', [Validators.required]],

      });

      this.editarCargoForm = new FormGroup({
        carg_Id: new FormControl("",Validators.required),
        carg_Descripcion: new FormControl("",Validators.required),
    });

      // Respuesta de la api
      this.cargoservice.getCargo().subscribe((Response: any)=> {
          console.log(Response.data);
          this.cargo = Response.data;

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
        if (this.crearCargoForm.valid) {
        const cargoData: Cargo = this.crearCargoForm.value;
        this.cargoservice.insertCargos(cargoData).subscribe(
            response => {

                if (response.code == 200) {

                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.cargoservice.getCargo().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.cargo = Response.data;
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

        if (this.editarCargoForm.valid) {
          const contenidoData: Cargo = this.editarCargoForm.value;
          this.cargoservice.editCargos(contenidoData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.cargoservice.getCargo().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.cargo = Response.data;
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

    validarTexto(event: KeyboardEvent) {

      if (!/^[a-zA-Z\s]+$/.test(event.key) && event.key !== 'Backspace' && event.key !== 'Tab' && event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') {
          event.preventDefault();
      }
    else{
      console.log("error");
    }
  }


    detalles(id){

        this.cargoservice.fillCargos(id).subscribe({
            next: (data: Cargo) => {
               this.carg_Id = data[0].carg_Id,
               this.Cargo = data[0].carg_Descripcion,
               this.UsuarioCreacion = data[0].usuarioCreacion,
               this.UsuarioModificacion = data[0].usuarioModificacion,
               this.FechaCreacion = data[0].carg_FechaCreacion,
               this.FechaModificacion = data[0].carg_FechaModificacion
                console.log(data);            
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }

    deleteContenido(codigo) {
        this.deleteCargoBool = true;
        this.ID = codigo;
        console.log("ID" + codigo);
    }

    confirmDelete() {
        this.cargoservice.deleteCargo(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.cargoservice.getCargo().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.cargo = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
                    this.Tabla=true;
                    this.deleteCargoBool = false;

                }
                else{
                    console.log(response)
                this.deleteCargoBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
                }
            },
        });
    }

    Fill(id) {
      this.cargoservice.fillCargos(id).subscribe({
          next: (data: Cargo) => {
              this.ID = data[0].cont_Id,
              this.editarCargoForm = new FormGroup({
                  carg_Id: new FormControl(data[0].carg_Id),
                  carg_Descripcion: new FormControl(data[0].carg_Descripcion,Validators.required),
              });
              console.log(this.ID);

              this.CollapseEdit = true;
              this.Tabla=false;

              console.log(data)

          }
      });
  }

}
