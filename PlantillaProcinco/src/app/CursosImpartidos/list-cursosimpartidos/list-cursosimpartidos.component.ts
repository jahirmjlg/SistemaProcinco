import { Component, ViewChild  } from '@angular/core';
import {CursosImpartidosService} from '../../Services/cursosimpartidos.service';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CursosImpartidos } from 'src/app/Models/CursosImpartidos';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { Table, TableModule } from 'primeng/table';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { ServiceService } from 'src/app/Services/service.service';
import { ParticipantesService } from 'src/app/Services/participante.service';
import { CursoService } from 'src/app/Services/curso.service';


@Component({
  selector: 'app-list-cursosimpartidos',
  templateUrl: './list-cursosimpartidos.component.html',
  styleUrl: './list-cursosimpartidos.component.scss',
  providers: [ConfirmationService, MessageService]
})
export class ListCursosimpartidosComponent {

    Tabla: boolean = true;

    Collapse: boolean = false;
    isSubmit: boolean = false;


    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;

    CollapseDetalle: boolean = false;

    //BOOLEAN DELETE
    deleteCursoImpartidoBool: boolean = false;
    finalizarCursoImpartidoBool: boolean = false;
    imprimirFacturaBool: boolean = false;


    showPdf: boolean = false;

    ImagenEncontrada: boolean = false;



    curIm_Id: String = "";
    curso_Id: String = "";
    empl_Id: String = "";
    curIm_FechaInicio: String = "";
    curIm_FechaFin: String = "";
    curIm_Finalizar: String = "";
    creacion: String = "";
    curIm_FechaCreacion: String = "";
    modificacion: String = "";
    curIm_FechaModificacion: String = "";
    ID: String = "";

    IDFinalizar: String = "";

    IDFactura: String = "";

    public safeUrl: SafeResourceUrl;




    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];

    //   variable para iterar
    cursosimpartidos!:CursosImpartidos[];


    @ViewChild('dt') table: Table;
    displayParticipantes: boolean = false;
    globalFilter: any = null;
    participantes!:CursosImpartidos[];
    selectedParticipantes: CursosImpartidos[] = [];


    crearCursosImpartidosForm: FormGroup
    editarCursosImpartidosForm: FormGroup
 cursosTop5Mes: any[] = [];
  cursosCategorias: any[] = [];
  empleadosMejorPagados: any[] = [];
  horasPorCategoria: any[] = [];
    constructor(private messageService: MessageService, private cursosimpartidosservice: CursosImpartidosService, private router: Router,
         private formBuilder: FormBuilder, private cookieService: CookieService, private tablemodule:TableModule,
         private sanitizer: DomSanitizer, private service: ServiceService,
         private participanteService: ParticipantesService, private cursosService: CursoService) { }




         getSafeUrl(url: string) {
            return this.sanitizer.bypassSecurityTrustResourceUrl(url);
          }



          //METODO AUTOCOMPLETADO
          cursos: any[] = [];
          filteredCursos: any[] = [];

          filterCursos(event: any) {
            const filtered: any[] = [];
            const query = event.query;
            for (let i = 0; i < this.cursos.length; i++) {
                const cursoss = this.cursos[i];
                if (cursoss.curso_Descripcion.toLowerCase().indexOf(query.toLowerCase()) == 0) {
                    filtered.push(cursoss);
                    this.onCursoChange(cursoss.curso_Descripcion);
                }
            }

            this.filteredCursos = filtered;
        }


        filterCursosEdit(event: any) {
            const filtered: any[] = [];
            const query = event.query;
            for (let i = 0; i < this.cursos.length; i++) {
                const cursoss = this.cursos[i];
                if (cursoss.curso_Descripcion.toLowerCase().indexOf(query.toLowerCase()) == 0) {
                    filtered.push(cursoss);
                    this.onCursoChangeEdit(cursoss.curso_Descripcion);
                }
            }

            this.filteredCursos = filtered;
        }

        /////////////

    ngOnInit() {

        this.cursosService.getCurso().subscribe((Response: any)=> {
            console.log(Response.data);
            this.cursos = Response.data;

          }, error=>{
            console.log(error);
          });


        this.crearCursosImpartidosForm = this.formBuilder.group({
            curso_Id: ['', [Validators.required]],
            empl_Id: ['', [Validators.required]],
            curIm_FechaInicio: ['', [Validators.required]],
            curIm_FechaFin: ['', [Validators.required]],
            empl_DNI: ['', [Validators.required]],
            empl_Nombre: ['', [Validators.required]],
            curso_DuracionHoras: ['', [Validators.required]],
            cate_Descripcion: ['', [Validators.required]],
            curso_Descripcion: ['', [Validators.required]],
            curso_Imagen: ['', [Validators.required]],


          });

          this.editarCursosImpartidosForm = new FormGroup({
            curIm_Id: new FormControl("",Validators.required),
            curso_Id: new FormControl("",Validators.required),
            empl_Id: new FormControl("",Validators.required),
            curIm_FechaInicio: new FormControl("",Validators.required),
            curIm_FechaFin: new FormControl("",Validators.required),
            empl_DNI: new FormControl("",Validators.required),
            empl_Nombre: new FormControl("",Validators.required),
            curso_DuracionHoras: new FormControl("",Validators.required),
            cate_Descripcion: new FormControl("",Validators.required),
            curso_Descripcion: new FormControl("",Validators.required),
            curso_Imagen: new FormControl("",Validators.required),

        });


        this.cursosimpartidosservice.getCursosImpartidosTop5Mes().subscribe((response: any) => {
          this.cursosTop5Mes = response;
        }, error => {
          console.log(error);
        });



        this.cursosimpartidosservice.getCursosImpartidosCategorias().subscribe((response: any) => {
          this.cursosCategorias = response;
        }, error => {
          console.log(error);
        });

        this.cursosimpartidosservice.getEmpleadosMejorPagados().subscribe((response: any) => {
          this.empleadosMejorPagados = response;
        }, error => {
          console.log(error);
        });

        this.cursosimpartidosservice.getHorasImpartidasPorCategoria().subscribe((response: any) => {
          this.horasPorCategoria = response;
        }, error => {
          console.log(error);
        });

        // Respuesta de la api
        this.cursosimpartidosservice.getCursosImpartidos().subscribe((Response: any)=> {
            console.log(Response.data);
            this.cursosimpartidos = Response.data;

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
        this.crearCursosImpartidosForm = this.formBuilder.group({
            curso_Id: ['', [Validators.required]],
            empl_Id: ['', [Validators.required]],
            curIm_FechaInicio: ['', [Validators.required]],
            curIm_FechaFin: ['', [Validators.required]],
            empl_DNI: ['', [Validators.required]],
            empl_Nombre: ['', [Validators.required]],
            curso_DuracionHoras: ['', [Validators.required]],
            cate_Descripcion: ['', [Validators.required]],
            curso_Descripcion: ['', [Validators.required]],
            curso_Imagen: ['', [Validators.required]],


          });

          this.Collapse=false;
          this.Tabla=true;
          this.isSubmit=false;
          this.ImagenEncontrada = false;
    }



    onAddParticipant(participant: CursosImpartidos) {
      this.selectedParticipantes.push(participant);
      this.participantes = this.participantes.filter(p => p.part_Id !== participant.part_Id);
    }

    onRemoveParticipant(participant: CursosImpartidos) {
      this.participantes.push(participant);
      this.selectedParticipantes = this.selectedParticipantes.filter(p => p.part_Id !== participant.part_Id);
    }



    onSubmitInsert(): void {
      this.isSubmit = true;

      if (this.crearCursosImpartidosForm.valid) {
        const formData = {
          txtCurso: this.crearCursosImpartidosForm.get('curso_Id').value,
          txtempleado: this.crearCursosImpartidosForm.get('empl_Id').value,
          txtfechainicio: this.crearCursosImpartidosForm.get('curIm_FechaInicio').value,
          txtfechafinal: this.crearCursosImpartidosForm.get('curIm_FechaFin').value,
          participantesSeleccionados: this.selectedParticipantes.map(p => p.part_Id)
        };

        this.participanteService.EnviarCurso(formData).subscribe(
          response => {
            if (response.success) {
              this.crearCursosImpartidosForm.reset();
              this.selectedParticipantes = [];
              this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

              this.cursosimpartidosservice.getCursosImpartidos().subscribe((Response: any) => {
                this.cursosimpartidos = Response.data;
              });

              this.Collapse = false;
              this.Tabla = true;
              this.ImagenEncontrada = false;
            } else {
              this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Agregar el Registro', life: 3000 });
            }
          },
          error => {
            console.log('El error: ' + error.data);
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Ocurrió un error al intentar insertar el registro', life: 3000 });
          }
        );
      } else {
        console.log('Formulario inválido');
      }
    }




    onSubmitEdit(): void {

        this.isSubmitEdit = true;
            const errorSpan = document.getElementById('error-span');

        if (this.editarCursosImpartidosForm.valid) {
          const cursoimpData: CursosImpartidos = this.editarCursosImpartidosForm.value;
          this.cursosimpartidosservice.editCursosIm(cursoimpData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.cursosimpartidosservice.getCursosImpartidos().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.cursosimpartidos = Response.data;

                      }, error=>{
                        console.log(error);
                      });

                    this.CollapseEdit = false;
                    this.Tabla = true;
                    this.ImagenEncontrada = false;

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




    detalles(id){

        this.cursosimpartidosservice.fillCursosIm(id).subscribe({
            next: (data: CursosImpartidos) => {
               this.curIm_Id = data[0].curIm_Id,
               this.curso_Id = data[0].cursos,
               this.curIm_FechaInicio = data[0].curIm_FechaInicio,
               this.curIm_FechaFin = data[0].curIm_FechaFin,
               this.creacion = data[0].creacion,
               this.empl_Id = data[0].nombre,
               this.curIm_Finalizar = data[0].curIm_Finalizar,
               this.curIm_FechaCreacion = data[0].curIm_FechaCreacion,
               this.modificacion = data[0].modificacion,
               this.curIm_FechaModificacion = data[0].curIm_FechaModificacion,
                console.log(data);
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }


    onDNIChange(dni){

        this.cursosimpartidosservice.BuscarEmpleado(dni).subscribe({
            next: (data: CursosImpartidos) => {
                this.crearCursosImpartidosForm.get('empl_Id').setValue(data[0].empl_Id);
                this.crearCursosImpartidosForm.get('empl_Nombre').setValue(data[0].empl_Nombre);
                    }
                });
                }

                showDialog() {
                    this.displayParticipantes = true;
                  }

                  applyFilter(value: string) {
                    if (this.table) {
                      console.log('Filtrando por:', value);
                      this.table.filterGlobal(value, 'contains');
                    } else {
                      console.log("Table not initialized");
                    }
                  }


    onCursoChange(curso){

        this.cursosimpartidosservice.BuscarCurso(curso).subscribe({
            next: (data: CursosImpartidos) => {
                this.crearCursosImpartidosForm.get('curso_Id').setValue(data[0].curso_Id);
                this.crearCursosImpartidosForm.get('curso_DuracionHoras').setValue(data[0].curso_DuracionHoras);
                this.crearCursosImpartidosForm.get('cate_Descripcion').setValue(data[0].cate_Descripcion);
                this.crearCursosImpartidosForm.get('curso_Imagen').setValue(data[0].curso_Imagen);

                       this.ImagenEncontrada = true;
                    }
                });


                        this.cursosimpartidosservice.BuscarParticipantes(curso).subscribe((Response: any)=> {
                            console.log(Response);
                            this.participantes = Response;

                          }, error=>{
                            console.log(error);
                          });

                }


                ////////////////////

                onDNIChangeEdit(dni){

                        this.cursosimpartidosservice.BuscarEmpleado(dni).subscribe({
                            next: (data: CursosImpartidos) => {
                                console.log("lo que trae: " + data[0].empl_Nombre)
                                this.editarCursosImpartidosForm.get('empl_Id').setValue(data[0].empl_Id);
                                this.editarCursosImpartidosForm.get('empl_Nombre').setValue(data[0].empl_Nombre);
                                    }
                                });
                            }


                onCursoChangeEdit(curso){

                        this.cursosimpartidosservice.BuscarCurso(curso).subscribe({
                            next: (data: CursosImpartidos) => {
                                console.log("lo que trae: " + data[0].curso_Imagen)
                                this.editarCursosImpartidosForm.get('curso_Id').setValue(data[0].curso_Id);
                                this.editarCursosImpartidosForm.get('curso_DuracionHoras').setValue(data[0].curso_DuracionHoras);
                                this.editarCursosImpartidosForm.get('cate_Descripcion').setValue(data[0].cate_Descripcion);
                                this.editarCursosImpartidosForm.get('curso_Imagen').setValue(data[0].curso_Imagen);

                                       this.ImagenEncontrada = true;
                                    }
                                });

                                this.cursosimpartidosservice.BuscarParticipantes(curso).subscribe((Response: any)=> {
                                    console.log(Response);
                                    this.participantes = Response;

                                  }, error=>{
                                    console.log(error);
                                  });
                            }




    Fill(id) {
        this.cursosimpartidosservice.fillCursosIm(id).subscribe({
            next: (data: CursosImpartidos) => {
                this.editarCursosImpartidosForm = new FormGroup({
                    curIm_Id: new FormControl(data[0].curIm_Id),
                    curso_Id: new FormControl(data[0].curso_Id,Validators.required),
                    curIm_FechaInicio: new FormControl(data[0].curIm_FechaInicio,Validators.required),
                    curIm_FechaFin: new FormControl(data[0].curIm_FechaFin,Validators.required),
                    empl_Id: new FormControl(data[0].empl_Id,Validators.required),

                    empl_DNI: new FormControl(data[0].empl_DNI,Validators.required),
                    empl_Nombre: new FormControl("",Validators.required),
                    curso_DuracionHoras: new FormControl("",Validators.required),
                    cate_Descripcion: new FormControl("",Validators.required),
                    curso_Descripcion: new FormControl(data[0].cursos,Validators.required),
                    curso_Imagen: new FormControl("",Validators.required),

                });

                this.onDNIChangeEdit(data[0].empl_DNI)

                this.onCursoChangeEdit(data[0].cursos)
                console.log(this.ID);

                this.CollapseEdit = true;
                this.Tabla=false;
                this.ImagenEncontrada = true;

                console.log(data)

            }
        });
    }

    deleteCursoImpartido(codigo) {
        this.deleteCursoImpartidoBool = true;
        this.ID = codigo;
    }


    confirmDelete() {
        this.cursosimpartidosservice.deleteCursosIm(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.cursosimpartidosservice.getCursosImpartidos().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.cursosimpartidos = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
                    this.Tabla=true;
                    this.deleteCursoImpartidoBool = false;

                }
                else{
                    console.log(response)
                this.deleteCursoImpartidoBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
                }
            },
        });
    }




    finalizarCursoImpartido(ID) {
        const roleId = Number.parseInt(this.cookieService.get('roleID'));
        if(roleId == 16)
            {
        this.finalizarCursoImpartidoBool = true;
        this.IDFinalizar = ID;
            }
            else
            {
            this.messageService.add({ severity: 'warn', summary: 'Acción no Válida', detail: 'No tienes los permisos requeridos', life: 3000 });

            }
    }


    finalizar() {
        this.cursosimpartidosservice.finalizarCursosIm(this.IDFinalizar).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.cursosimpartidosservice.getCursosImpartidos().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.cursosimpartidos = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Curso Finalizado Exitosamente', life: 3000 });

                    this.finalizarCursoImpartidoBool = false;


                }
                else{
                    console.log(response)
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Finalizar el Curso', life: 3000 });
                }
            },
        });
    }


    showPDF()
    {
        this.showPdf = true;
        this.imprimirFacturaBool = false;

    }


    imprimirFactura(ID) {
        const roleId = Number.parseInt(this.cookieService.get('roleID'));
        if(roleId == 17)
            {
                this.imprimirFacturaBool = true;
                this.IDFactura = ID;
                this.cursosimpartidosservice.getPreviewFacturaUrl(this.IDFactura)

                this.cursosimpartidosservice.getPreviewFacturaUrl(this.IDFactura).subscribe(
                    (url) => {
                      this.safeUrl = this.getSafeUrl(url);
                    },
                    (error) => {
                      console.error('Error al obtener la URL del PDF:', error);
                    }
                  );

            }
            else
            {
            this.messageService.add({ severity: 'warn', summary: 'Acción no Válida', detail: 'No tienes los permisos requeridos', life: 3000 });

            }
    }


}
