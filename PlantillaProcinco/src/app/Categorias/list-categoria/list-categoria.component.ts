import { Component, ViewChild } from '@angular/core';
import {CategoriaService} from '../../Services/categoria.service';
import { Categoria } from 'src/app/Models/CategoriasViewModel';
import {Router} from '@angular/router';
//
import { Product } from 'src/app/demo/api/product';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { FileUpload } from 'primeng/fileupload';

@Component({
  selector: 'app-list-categoria',
  templateUrl: './list-categoria.component.html',
  providers: [MessageService]

})
export class ListCategoriaComponent {


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
                deleteBool: boolean = false;



    //File
    selectedFile: File;

    // DETALLE
    cateID: String = "";
    cateDescripcion: String = "";
    cateImagen: String = "";
    UsuarioCreacion: String = "";
    UsuarioModificacion: String = "";
    FechaCreacion: String = "";
    FechaModificacion: String = "";

    //NAMEFILE
    subida:String = "";
    subidaIf: boolean = false




    //IGNORAR (DESTACAR QUE ES LO UNICO NECESARIO(DEPURAR TODO LO DEMAS))
    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];


    //   variable para iterar
    categoria!:Categoria[];

    //CREAR EL FORMGROUP EN EL QUE SE CREAN LAS PROPIEDADES
    crearCategoriaForm: FormGroup
    editarCategoriaForm: FormGroup




    constructor(private categoriaservice: CategoriaService, private router: Router,
                private formBuilder: FormBuilder, private cookieService: CookieService,
                private messageService: MessageService) {


     }


     Cancel()
     {

        this.crearCategoriaForm = this.formBuilder.group({
            cate_Descripcion: ['', [Validators.required]],
            cate_Imagen: ['', [Validators.required]],
          });

        this.Collapse=false;
        this.Tabla=true;
        this.isSubmit=false;
        this.fileupload.clear();
        this.subidaIf = false;


     }


      onUpload(event) {
        const file: File = event.files[0];
        if (file) {
            const uniqueSuffix = Date.now() + '-' + Math.round(Math.random() * 1E9);
            const uniqueFileName = uniqueSuffix + '-' + file.name;

            this.crearCategoriaForm.get('cate_Imagen').setValue(uniqueFileName);
            const formData: FormData = new FormData();

            formData.append('file', file, uniqueFileName);
            this.categoriaservice.upload(formData).subscribe(
              response => {
                console.log('Carga exitosa', response);
                if (response.message == "Success") {
                    this.subidaIf = true;
                    this.subida = uniqueFileName;
                  this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Imagen Subida', life: 3000 });
                } else {
                  this.messageService.add({ severity: 'success', summary: 'Error', detail: 'Imagen Requerida', life: 3000 });
                }
              },
              error => {
                console.error('Error al cargar imagen', error);
              }
            );
          }
      }


      onUploadEdit(event) {
        const file: File = event.files[0];
        if (file) {
            const uniqueSuffix = Date.now() + '-' + Math.round(Math.random() * 1E9);
            const uniqueFileName = uniqueSuffix + '-' + file.name;

            this.editarCategoriaForm.get('cate_Imagen').setValue(uniqueFileName);
            const formData: FormData = new FormData();

            formData.append('file', file, uniqueFileName);
            this.categoriaservice.upload(formData).subscribe(
              response => {
                console.log('Carga exitosa', response);
                if (response.message == "Success") {
                    this.subidaIf = true;
                    this.subida = uniqueFileName;
                  this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Imagen Subida', life: 3000 });
                } else {
                  this.messageService.add({ severity: 'success', summary: 'Error', detail: 'Imagen Requerida', life: 3000 });
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
        this.crearCategoriaForm = this.formBuilder.group({
            cate_Descripcion: ['', [Validators.required]],
            cate_Imagen: ['', [Validators.required]],


          });

          this.editarCategoriaForm = new FormGroup({
            cate_Id: new FormControl("",Validators.required),
            cate_Descripcion: new FormControl("",Validators.required),
            cate_Imagen: new FormControl("",Validators.required),
        });


      // Respuesta de la api
      this.categoriaservice.getCategoria().subscribe((Response: any)=> {
        console.log(Response.data);
        this.categoria = Response.data;

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
        if (this.crearCategoriaForm.valid) {
          const categData: Categoria = this.crearCategoriaForm.value;
          this.categoriaservice.insertCategoria(categData).subscribe(
            response => {

                if (response.code == 200) {

                    this.crearCategoriaForm = this.formBuilder.group({
                        cate_Descripcion: ['', [Validators.required]],
                        cate_Imagen: ['', [Validators.required]],
                      });

                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                    // this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.categoriaservice.getCategoria().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.categoria = Response.data;

                      }, error=>{
                        console.log(error);
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

        if (this.editarCategoriaForm.valid) {
          const categData: Categoria = this.editarCategoriaForm.value;
          this.categoriaservice.editCategoria(categData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.categoriaservice.getCategoria().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.categoria = Response.data;

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

        this.categoriaservice.fillCategoria(id).subscribe({
            next: (data: Categoria) => {
               this.cateID = data[0].cate_Id,
               this.cateDescripcion = data[0].cate_Descripcion,
               this.cateImagen = data[0].cate_Imagen,
               this.UsuarioCreacion = data[0].creacion,
               this.FechaCreacion = data[0].cate_Fechacreacion
               this.UsuarioModificacion = data[0].modificacion
               this.FechaModificacion = data[0].cate_FechaModificacion
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }




    //DELETE
    deleteCategoria(codigo) {
        this.deleteBool = true;
        this.cateID = codigo;
        console.log("ID" + codigo);
    }

    confirmDelete() {
        this.categoriaservice.deleteCategoria(this.cateID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.categoriaservice.getCategoria().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.categoria = Response.data;

                      }, error=>{
                        console.log(error);
                      });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });

                    this.Tabla=true;

                    this.deleteBool = false;

                   }
                else{
                    console.log(response)
                this.deleteBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
            }
        },
    });

    }


    validarTexto(event: KeyboardEvent) {
      if (!/^[a-zA-Z\s]+$/.test(event.key) && event.key !== 'Backspace' && event.key !== 'Tab' && event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') {
          event.preventDefault();
      }
    }





    //LLENAR EDITAR && DETALLE
    Fill(id) {
        this.categoriaservice.fillCategoria(id).subscribe({
            next: (data: Categoria) => {
                this.editarCategoriaForm = new FormGroup({
                    cate_Id: new FormControl(data[0].cate_Id,Validators.required),
                    cate_Descripcion: new FormControl(data[0].cate_Descripcion,Validators.required),
                    cate_Imagen: new FormControl(data[0].cate_Imagen,Validators.required),
                });

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
          });

    }
}

