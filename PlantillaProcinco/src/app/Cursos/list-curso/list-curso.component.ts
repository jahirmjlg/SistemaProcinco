import { Component, ViewChild} from '@angular/core';
import {CursoService} from '../../Services/curso.service';
import {Curso} from 'src/app/Models/CursosViewModel';
import {Router} from '@angular/router';

import { Product } from 'src/app/demo/api/product';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { dropCategorias } from 'src/app/Models/CategoriasViewModel';
import { FileUpload } from 'primeng/fileupload';

@Component({
  selector: 'app-list-curso',
  templateUrl: './list-curso.component.html',
  providers: [MessageService],
  template: `
  <input type="file" (change)="onFileSelected($event)">
  <button (click)="onUpload()">Upload</button>
`

})
export class ListCursoComponent {

    @ViewChild('fileupload') fileupload: FileUpload;

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
                deleteCursoBool: boolean = false;


        //VARIABLE EN LA QUE ITERA EL DDL
    dropCategorias: any[] = [];

    //File
    selectedFile: File;


    // DETALLE
    cursoID: String = "";
    cursoDescripcion: String = "";
    cursoDuracion: String = "";
    cursoImagen: String = "";
    categoria: String = "";
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
    curso!:Curso[];

    //CREAR EL FORMGROUP EN EL QUE SE CREAN LAS PROPIEDADES
    crearCursoForm: FormGroup
    editarCursoForm: FormGroup




    constructor(private cursoservice: CursoService, private router: Router,
                private formBuilder: FormBuilder, private cookieService: CookieService,
                private messageService: MessageService) {


     }


     Cancel()
     {
        this.Collapse=false;
        this.Tabla=true;
        this.isSubmitEdit=false;
        this.fileupload.clear();

     }


      onUpload(event) {
        const file: File = event.files[0];
        if (file) {
            const uniqueSuffix = Date.now() + '-' + Math.round(Math.random() * 1E9);
            const uniqueFileName = uniqueSuffix + '-' + file.name;

            this.crearCursoForm.get('curso_Imagen').setValue(uniqueFileName);
            const formData: FormData = new FormData();

            formData.append('file', file, uniqueFileName);
            this.cursoservice.upload(formData).subscribe(
              response => {
                console.log('Carga exitosa', response);
                if (response.code == 200) {
                  this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Imagen Subida', life: 3000 });
                } else {
                  this.messageService.add({ severity: 'success', summary: 'Error', detail: 'Suba una imagen', life: 3000 });
                }
              },
              error => {
                console.error('Error al cargar imagen', error);
              }
            );
          }
      }

    ngOnInit() {

        //INICIALIZAR EL FORMULARIO
        this.crearCursoForm = this.formBuilder.group({
            curso_Descripcion: ['', [Validators.required]],
            curso_DuracionHoras: ['', [Validators.required]],
            curso_Imagen: ['', [Validators.required]],
            cate_Id: ['0', [Validators.required]],

          });

          this.editarCursoForm = new FormGroup({
            curso_Id: new FormControl("",Validators.required),
            curso_Descripcion: new FormControl("",Validators.required),
            curso_DuracionHoras: new FormControl("",Validators.required),
            curso_Imagen: new FormControl("",Validators.required),
            cate_Id: new FormControl("0",Validators.required),
        });

        this.cursoservice.getDdlCategorias().subscribe((data: dropCategorias[]) => {
            this.dropCategorias = data;
            console.log(data);
        }, error => {
            console.log(error);
        });


        // Respuesta de la api
        this.cursoservice.getCurso().subscribe((Response: any)=> {
            console.log(Response.data);
            this.curso = Response.data;

          }, error=>{
            console.log(error);
          });

          //


        this.schemas = [
            CUSTOM_ELEMENTS_SCHEMA
          ];
    }




    //INSERTAR
    onSubmitInsert(): void {

        this.isSubmit = true;

            const errorSpan = document.getElementById('error-span');
        if (this.crearCursoForm.valid) {
          const cursoData: Curso = this.crearCursoForm.value;
          this.cursoservice.insertCurso(cursoData).subscribe(
            response => {

                if (response.code == 200) {

                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.cursoservice.getCurso().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.curso = Response.data;
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

        if (this.editarCursoForm.valid) {
          const cursoData: Curso = this.editarCursoForm.value;
          this.cursoservice.editCurso(cursoData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.cursoservice.getCurso().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.curso = Response.data;

                      }, error=>{
                        console.log(error);
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

        this.cursoservice.fillCurso(id).subscribe({
            next: (data: Curso) => {
               this.cursoID = data[0].curso_Id,
               this.cursoDescripcion = data[0].curso_Descripcion,
               this.cursoDuracion = data[0].curso_DuracionHoras,
               this.cursoImagen = data[0].curso_Imagen,
               this.categoria = data[0].categoria,
               this.UsuarioCreacion = data[0].creacion,
               this.FechaCreacion = data[0].curso_FechaCreacion
               this.UsuarioModificacion = data[0].modificacion
               this.FechaModificacion = data[0].curso_FechaModificacion

            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }




    //DELETE
    deleteCurso(codigo) {
        this.deleteCursoBool = true;
        this.cursoID = codigo;
        console.log("ID" + codigo);
    }

    confirmDelete() {
        this.cursoservice.deleteCurso(this.cursoID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.cursoservice.getCurso().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.curso = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });

                    this.Tabla=true;

                    this.deleteCursoBool = false;

                   }
                else{
                    console.log(response)
                this.deleteCursoBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
            }
        },
    });

    }





    //LLENAR EDITAR && DETALLE
    Fill(id) {
        this.cursoservice.fillCurso(id).subscribe({
            next: (data: Curso) => {
                this.editarCursoForm = new FormGroup({
                    curso_Id: new FormControl(data[0].curso_Id,Validators.required),
                    curso_Descripcion: new FormControl(data[0].curso_Descripcion,Validators.required),
                    curso_DuracionHoras: new FormControl(data[0].curso_DuracionHoras,Validators.required),
                    curso_Imagen: new FormControl(data[0].curso_Imagen,Validators.required),
                    cate_Id: new FormControl(data[0].cate_Id,Validators.required),
                });

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
          });

    }



}
