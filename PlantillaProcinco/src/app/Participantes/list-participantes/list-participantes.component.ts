import {ChangeDetectorRef,  Component } from '@angular/core';
import {ParticipantesService} from '../../Services/participante.service';
import {Participante} from 'src/app/Models/ParticipanteViewModel';
import {Router} from '@angular/router';
import { MessageService, ConfirmationService } from 'primeng/api';
import { Table } from 'primeng/table';
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
  selector: 'app-list-participantes',
  templateUrl: './list-participantes.component.html',
  styleUrl: './list-participantes.component.scss',
  providers: [MessageService, ConfirmationService]
})
export class ListParticipantesComponent {

    Tabla: boolean = true;


    participante! : Participante[];
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
                deleteParticipanteBool: boolean = false;


                ID: Number = 0;



        //VARIABLE EN LA QUE ITERA EL DDL
    estadosddl: any[] = [];
    empresasddl: any[] = [];
    estadosCivilesddl: any[] = [];
    ciudadesddl: any[] = [];

    ciudadID: String = "";




    // DETALLE
    partID: number = 0;
    partDNI: String = "";
    empresa: String = "";
    partNombre: String = "";
    partApellido: String = "";
    partCorreo: String = "";
    partFechaNacimiento: String = "";
    partSexo: String = "";
    estadoCivil: String = "";
    partDireccion: String = "";
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


      part! : Participante;



    //CREAR EL FORMGROUP EN EL QUE SE CREAN LAS PROPIEDADES
    crearParticipanteForm: FormGroup
    editarParticipanteForm: FormGroup




    constructor(
               private cdRef: ChangeDetectorRef,
               private messageService: MessageService,
                private Participanteservice: ParticipantesService,
                private router: Router,
                private formBuilder: FormBuilder,
                private cookieService: CookieService,
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
        this.crearParticipanteForm = this.formBuilder.group({
            part_DNI: ['', [Validators.required]],
            empre_Id: ['0', [Validators.required]],
            part_Nombre: ['', [Validators.required]],
            part_Apellido: ['', [Validators.required]],
            part_Correo: ['', [Validators.required]],
            part_FechaNacimiento: ['', [Validators.required]],
            part_Sexo: ['', [Validators.required]],
            estc_Id: ['0', [Validators.required]],
            part_Direccion: ['', [Validators.required]],
            ciud_Id: ['0', [Validators.required]],
            esta_Id: ['0', [Validators.required]],


          });

          this.editarParticipanteForm = new FormGroup({
            part_Id: new FormControl("",Validators.required),
            part_DNI: new FormControl("",Validators.required),
            empre_Id: new FormControl("0",Validators.required),
            part_Nombre: new FormControl("",Validators.required),
            part_Apellido: new FormControl("",Validators.required),
            part_Correo: new FormControl("",Validators.required),
            part_FechaNacimiento: new FormControl("",Validators.required),
            part_Sexo: new FormControl("",Validators.required),
            estc_Id: new FormControl("0",Validators.required),
            part_Direccion: new FormControl("",Validators.required),
            ciud_Id: new FormControl("0",Validators.required),
            esta_Id: new FormControl(this.ciudadID,Validators.required),
        });


        this.Participanteservice.getDdlEstados().subscribe((data: dropEstados[]) => {
            this.estadosddl = data;
            console.log(data);
        }, error => {
            console.log(error);
        });


        this.Participanteservice.getDdlEmpresas().subscribe((data: dropCargos[]) => {
            this.empresasddl = data;
            console.log(data);
        }, error => {
            console.log(error);
        });

        this.Participanteservice.getDdlEstadosCiviles().subscribe((data: dropEstadosCiviles[]) => {
            this.estadosCivilesddl = data;
            console.log(data);
        }, error => {
            console.log(error);
        });



        // this.Participanteservice.getDdlCiudades().subscribe((data: dropCiudades[]) => {
        //     this.ciudadesddl = data;
        //     console.log(data);
        // }, error => {
        //     console.log(error);
        // });



        // Respuesta de la api
        this.Participanteservice.getParticipante().subscribe((Response: any)=> {
            console.log(Response.data);
            this.participante = Response.data;

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
        this.crearParticipanteForm = this.formBuilder.group({
            part_DNI: ['', [Validators.required]],
            empre_Id: ['0', [Validators.required]],
            part_Nombre: ['', [Validators.required]],
            part_Apellido: ['', [Validators.required]],
            part_Correo: ['', [Validators.required]],
            part_FechaNacimiento: ['', [Validators.required]],
            part_Sexo: ['', [Validators.required]],
            estc_Id: ['0', [Validators.required]],
            part_Direccion: ['', [Validators.required]],
            ciud_Id: ['0', [Validators.required]],
            esta_Id: ['0', [Validators.required]],


          });

          this.Collapse=false;
          this.Tabla=true;
          this.isSubmit=false
    }



    onEstadoChange(estadoID) {
        if (estadoID !== '0') {
          this.Participanteservice.getDdlCiudades(estadoID).subscribe(
            (data: any) => {
              this.ciudadesddl = data;
              this.crearParticipanteForm.get('ciud_Id').setValue('0');
            },
            error => {
              console.error('Errorr:', error);
            }
          );
        } else {
          this.ciudadesddl = [];
        }
      }



    //INSERTAR
    onSubmitInsert(): void {

        this.isSubmit = true;

            const errorSpan = document.getElementById('error-span');
        if (this.crearParticipanteForm.valid) {
          const ParticipanteData: Participante = this.crearParticipanteForm.value;
          this.Participanteservice.insertParticipante(ParticipanteData).subscribe(
            response => {

                if (response.code == 200) {

                    this.crearParticipanteForm = this.formBuilder.group({
                        part_DNI: ['', [Validators.required]],
                        empre_Id: ['0', [Validators.required]],
                        part_Nombre: ['', [Validators.required]],
                        part_Apellido: ['', [Validators.required]],
                        part_Correo: ['', [Validators.required]],
                        part_FechaNacimiento: ['', [Validators.required]],
                        part_Sexo: ['', [Validators.required]],
                        estc_Id: ['0', [Validators.required]],
                        part_Direccion: ['', [Validators.required]],
                        ciud_Id: ['0', [Validators.required]],
                        esta_Id: ['0', [Validators.required]],


                      });

                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.part_Nombre);
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.Participanteservice.getParticipante().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.participante = Response.data;
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

        if (this.editarParticipanteForm.valid) {
          const ParticipanteData: Participante = this.editarParticipanteForm.value;

          this.Participanteservice.editParticipante(ParticipanteData).subscribe(

            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.Participanteservice.getParticipante().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.participante = Response.data;
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
        this.Participanteservice.fillParticipante(id).subscribe({
            next: (data: Participante) => {
               this.partID = data[0].part_Id;
               this.partDNI = data[0].part_DNI;
               this.empresa = data[0].empre_Descripcion;
               this.partNombre = data[0].part_Nombre;
               this.partApellido = data[0].part_Apellido;
               this.partCorreo = data[0].part_Correo;
               this.partFechaNacimiento = data[0].part_FechaNacimiento;
               this.partSexo = data[0].sexo;
               this.estadoCivil = data[0].estadoCivil;
               this.partDireccion = data[0].part_Direccion;
               this.ciudad = data[0].ciud_Descripcion;
               this.UsuarioCreacion = data[0].usuarioCreacion;
               this.UsuarioModificacion = data[0].usuarioModificacion;
               this.FechaCreacion = data[0].part_FechaCreacion;
               this.FechaModificacion = data[0].part_FechaModificacion;
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }




    //DELETE
    deleteParticipante(id) {
        this.deleteParticipanteBool = true;
        this.ID = id;
        console.log("ID" + id);
    }

    confirmDelete() {
        this.Participanteservice.deleteParticipante(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.Participanteservice.getParticipante().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.participante = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });

                    this.Tabla=true;

                    this.deleteParticipanteBool = false;

                   }
                else{
                    console.log(response)
                this.deleteParticipanteBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
            }
        },
    });

    }





    //LLENAR EDITAR && DETALLE
    Fill(id) {
        this.editarParticipanteForm.reset();

        this.Participanteservice.fillParticipante(id).subscribe({
            next: (data: Participante) => {

                this.editarParticipanteForm = new FormGroup({
                    part_Id: new FormControl(id,Validators.required),
                    part_DNI: new FormControl(data[0].part_DNI,Validators.required),
                    empre_Id: new FormControl(data[0].empre_Id,Validators.required),
                    part_Nombre: new FormControl(data[0].part_Nombre,Validators.required),
                    part_Apellido: new FormControl(data[0].part_Apellido,Validators.required),
                    part_Correo: new FormControl(data[0].part_Correo,Validators.required),
                    part_FechaNacimiento: new FormControl(data[0].part_FechaNacimiento,Validators.required),
                    part_Sexo: new FormControl(data[0].part_Sexo,Validators.required),
                    estc_Id: new FormControl(data[0].estc_Id,Validators.required),
                    part_Direccion: new FormControl(data[0].part_Direccion,Validators.required),
                    esta_Id: new FormControl(data[0].esta_Id,Validators.required),
                    ciud_Id: new FormControl(data[0].ciud_Id,Validators.required),
                });
                this.ciudadID = data[0].ciud_Id;
                this.Participanteservice.getDdlCiudades(data[0].esta_Id).subscribe(
                    (data: any) => {
                      this.ciudadesddl = data;
                      this.editarParticipanteForm.get('ciud_Id').setValue(this.ciudadID);
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

      }




}
