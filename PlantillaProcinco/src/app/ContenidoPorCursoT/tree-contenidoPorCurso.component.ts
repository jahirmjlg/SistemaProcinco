import { Component, OnInit,  ViewChild } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser'; 
import { ContenidoPorCursos } from 'src/app/Models/ContenidoPorCursosViewModel'; 
import { ContenidoporcursoService } from 'src/app/Services/contenidoporcurso.service';
import { CursoService } from 'src/app/Services/curso.service';
import { CategoriaService } from 'src/app/Services/categoria.service'; 
import { Categoria } from 'src/app/Models/CategoriasViewModel';
import { TreeNode } from 'src/app/Models/TreeViewModel'; 
import {Curso} from 'src/app/Models/CursosViewModel';
import {Contenido} from 'src/app/Models/ContenidoViewModel';
import {Router} from '@angular/router';
import { Product } from 'src/app/demo/api/product';
import { ConfirmationService,MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ProductService } from 'src/app/demo/service/product.service';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { dropCategorias } from 'src/app/Models/CategoriasViewModel';
import { FileUpload } from 'primeng/fileupload';
import { ContenidoService } from '../Services/contenido.service';
import {EmpresaService} from '../Services/empresa.service';
import { dropEmpresas } from 'src/app/Models/EmpresaViewModel';


@Component({
    selector: 'app-list-curso',
    templateUrl: './tree-contenidoPorCurso.component.html',
    providers: [ConfirmationService, MessageService],
    template: `
    <input type="file" (change)="onFileSelected($event)">
    <button (click)="onUpload()">Upload</button>
  `
})
export class treeContendioPorCursoComponent 





implements OnInit {



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
    dropEmpresas: any[] = [];

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

    empresa: String = "";





    //propiedades contenido  

    conPc_Id :String = "";
  cont_Id :String = "";
  cont_Descripcion :String = "";
  curso_Id :String = "";
  curso_Descripcion :String = "";
  cont_DuracionHoras : String = "";
  curso_DuracionHoras :String = "";
  curso_Imagen :String = "";
  cate_Descripcion :String = "";
  conPc_FechaCreacion :String = "";
  conPc_FechaModificacion :String = "";
  creacion : String = "";
  modificacon :String = "";
  ID: String = "";


    //IGNORAR (DESTACAR QUE ES LO UNICO NECESARIO(DEPURAR TODO LO DEMAS))
    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
        CUSTOM_ELEMENTS_SCHEMA
      ];



    //   cursos por compone te
    contenidoPcurso !: ContenidoPorCursos[];

  crearContenidoPorCursoForm: FormGroup;
  editarContenidoPorCursoForm : FormGroup;


    //   variable para iterar
    curso!:Curso[];

    //CREAR EL FORMGROUP EN EL QUE SE CREAN LAS PROPIEDADES
    crearCursoForm: FormGroup
    editarCursoForm: FormGroup






    categoriasConContenidos: TreeNode[] = [];

    categoriasConCursos: TreeNode[] = [];
    contenidosConNodos: TreeNode[] = [];

    selectedFiles1: any[] = []; 
    idCategorias: number[] = [];

    
    constructor(
        private contenidoPorCursoService: ContenidoporcursoService,
        private categoriaService: CategoriaService,
        private contenidoService: ContenidoService,
        private empresaservice: EmpresaService,
        private cursoService: CursoService,        
        private sanitizer: DomSanitizer,
        private cursoservice: CursoService,
        private contenidoPorCursosService : ContenidoporcursoService, 
        private router: Router,
        private formBuilder: FormBuilder, 
        private cookieService: CookieService,
        private messageService: MessageService) {
        this.categoriasConCursos = [];
        this.contenidosConNodos = [];
        this.categoriasConContenidos = [];

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
            empre_Id: ['0', [Validators.required]],

          });

          this.editarCursoForm = new FormGroup({
            curso_Id: new FormControl("",Validators.required),
            curso_Descripcion: new FormControl("",Validators.required),
            curso_DuracionHoras: new FormControl("",Validators.required),
            curso_Imagen: new FormControl("",Validators.required),
            empre_Id: new FormControl("0",Validators.required),
            cate_Id: new FormControl("0",Validators.required),
        });

        this.cursoservice.getDdlCategorias().subscribe((data: dropCategorias[]) => {
            this.dropCategorias = data;
            console.log(data);
        }, error => {
            console.log(error);
        });


        this.empresaservice.getDdlEmpresas().subscribe((data: dropEmpresas[]) => {
            this.dropEmpresas = data;
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

          //CONTENIDO POR CURSO/////////////////////////////////////////////////////////


          this.crearContenidoPorCursoForm = this.formBuilder.group({
            cont_Id: ['',[Validators.required]],
            curso_Id: ['',[Validators.required]],
            cont_Descripcion: ['',[Validators.required]],
            cont_DuracionHoras: ['',[Validators.required]],
            cate_Descripcion: ['',[Validators.required]],
            curso_DuracionHoras: ['',[Validators.required]],
            curso_Descripcion: ['',[Validators.required]],
            curso_Imagen: ['',[Validators.required]],
          })


          this.editarContenidoPorCursoForm = this.formBuilder.group({
            conPc_Id: new FormControl("",Validators.required),
            cont_Id: new FormControl("",Validators.required),
            curso_Id: new FormControl("",Validators.required)
          })
      
          this.contenidoPorCursosService.getContenidoPorCurso().subscribe((Response: any)=> {
            console.log(Response.data);
            this.contenidoPcurso = Response.data;
      
          }, error=>{
            console.log(error);
          });

          //CONTENIDO POR CURSO/////////////////////////////////////////////////////////



        this.schemas = [
            CUSTOM_ELEMENTS_SCHEMA
          ];
        this.getCategorias();
        this.getCategorias1();
        

    }


    



    onSubmitInsertcontenidoPorCursos(): void {
      this.isSubmit = true;
  
      if (this.crearContenidoPorCursoForm.valid) {
          const contenidoCursoData: ContenidoPorCursos = this.crearContenidoPorCursoForm.value;
          const cursoId = this.crearCursoForm.get('curso_Id').value;
  
          contenidoCursoData.curso_Id = cursoId; // Asignar el ID del curso
  
          this.contenidoPorCursosService.insertContenidoPorCurso(contenidoCursoData).subscribe(
              response => {
                  if (response.code == 200) {
                      this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });
                      console.log(response);
                      // Actualizar la lista de contenidos por cursos
                      this.contenidoPorCursoService.getContenidoPorCurso().subscribe((Response: any)=> {
                          console.log(Response.data);
                          this.contenidoPcurso = Response.data;
                      });
                  } else {
                      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Agregar el Registro', life: 3000 });
                  }
              },
              error => {
                  console.log('El error: ' + error.data)
              }
          );
      } else {
          console.log('Formulario inválido');
      }
  }
  




    onSubmitEditcontenidoPorCursos(): void {
  
      this.isSubmitEdit = true;
          const errorSpan = document.getElementById('error-span');
  
      if (this.editarContenidoPorCursoForm.valid) {
        const cursoimpData: ContenidoPorCursos = this.editarContenidoPorCursoForm.value;
        this.contenidoPorCursosService.editContenidoPorCurso(cursoimpData).subscribe(
          response => {
  
            if (response.code == 200) {
                  this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                  console.log(response)
                  // this.router.navigate(['/pages/estados']);
                  this.contenidoPorCursosService.getContenidoPorCurso().subscribe((Response: any)=> {
                      console.log(Response.data);
                      this.contenidoPcurso = Response.data;
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
  
    validarTexto(event: KeyboardEvent) {
      if (!/^[a-zA-Z\s]+$/.test(event.key) && event.key !== 'Backspace' && event.key !== 'Tab' && event.key !== 'ArrowLeft' && event.key !== 'ArrowRight') {
          event.preventDefault();
      }
    }
  
  
  
    detallescontenidoPorCursos(id){
      this.contenidoPorCursosService.fillContenidoPorCurso(id).subscribe({
          next: (data: ContenidoPorCursos) => {
             this.conPc_Id = data[0].conPc_Id,
             this.cont_Descripcion = data[0].cont_Descripcion,
             this.cont_DuracionHoras = data[0].cont_DuracionHoras,
             this.curso_Descripcion = data[0].curso_Descripcion,
             this.curso_DuracionHoras = data[0].curso_DuracionHoras,
             this.curso_Imagen = data[0].curso_Imagen,
             this.cate_Descripcion = data[0].cate_Descripcion,
             this.creacion = data[0].creacion,
             this.conPc_FechaCreacion = data[0].conPc_FechaCreacion,
             this.modificacon = data[0].modificacon,
             this.conPc_FechaModificacion = data[0].conPc_FechaModificacion,
              console.log(data);
          }
        });
        this.CollapseDetalle = true;
        this.Tabla=false;
    }
  

// AQUIII
    // oncursochange(curso){

    //     this.cursoService.insertCursoId(curso).subscribe({
    //         next: (data: ContenidoPorCursos) => {
    //             this.crearCursoForm.get('curso_Id').setValue(data[0].curso_Id);
            
    //                 //    this.ImagenEncontrada = true;
    //                 }
    //             });
    //   }


    oncursochange(curso) {
      // Obtener los IDs de los contenidos seleccionados en el treeview
      const selectedContentIds = this.selectedFiles1.map(node => node.data.id);
  
      // Asociar los IDs de los contenidos al curso seleccionado
      this.contenidoPorCursosService.BuscarCurso(curso).subscribe({
          next: (data: ContenidoPorCursos) => {
              this.crearContenidoPorCursoForm.get('curso_Id').setValue(data[0].curso_Id);
              this.crearContenidoPorCursoForm.get('curso_Descripcion').setValue(data[0].curso_Descripcion);
              this.crearContenidoPorCursoForm.get('curso_DuracionHoras').setValue(data[0].curso_DuracionHoras);
              this.crearContenidoPorCursoForm.get('cate_Descripcion').setValue(data[0].cate_Descripcion);
              this.crearContenidoPorCursoForm.get('curso_Imagen').setValue(data[0].curso_Imagen);
              this.crearContenidoPorCursoForm.get('cont_Id').setValue(selectedContentIds); // Asignar los IDs de los contenidos al formulario
  
              //    this.ImagenEncontrada = true;
          }
      });
  }
  




    onCursocrearChange(curso){

        this.contenidoPorCursosService.BuscarCurso(curso).subscribe({
            next: (data: ContenidoPorCursos) => {
                this.crearContenidoPorCursoForm.get('curso_Id').setValue(data[0].curso_Id);
                this.crearContenidoPorCursoForm.get('curso_Descripcion').setValue(data[0].curso_Descripcion);
                this.crearContenidoPorCursoForm.get('curso_DuracionHoras').setValue(data[0].curso_DuracionHoras);
                this.crearContenidoPorCursoForm.get('cate_Descripcion').setValue(data[0].cate_Descripcion);
                this.crearContenidoPorCursoForm.get('curso_Imagen').setValue(data[0].curso_Imagen);
    
                    //    this.ImagenEncontrada = true;
                    }
                });
      }
    
      onCursoeditarChange(curso){
    
        this.contenidoPorCursosService.BuscarCurso(curso).subscribe({
          next: (data: ContenidoPorCursos) => {
            this.editarContenidoPorCursoForm.get('curso_Id').setValue(data[0].curso_Id);
            this.editarContenidoPorCursoForm.get('curso_DuracionHoras').setValue(data[0].curso_DuracionHoras);
            this.editarContenidoPorCursoForm.get('cate_Descripcion').setValue(data[0].cate_Descripcion);
            this.editarContenidoPorCursoForm.get('curso_Imagen').setValue(data[0].curso_Imagen);
    
            // this.ImagenEncontrada = true;
          }
        });
      }
    
    
      onContenidoChange(contenido){
    
        this.contenidoPorCursosService.BuscarContenido(contenido).subscribe({
          next: (data: ContenidoPorCursos) => {
            this.crearContenidoPorCursoForm.get('cont_Id').setValue(data[0].cont_Id);
            this.crearContenidoPorCursoForm.get('cont_Descripcion').setValue(data[0].cont_Descripcion);
            this.crearContenidoPorCursoForm.get('cont_DuracionHoras').setValue(data[0].cont_DuracionHoras);
    
          }
        });
      }
    
    
      onContenidoeditarChange(contenido){
        this.contenidoPorCursosService.BuscarContenido(contenido).subscribe({
          next: (data: ContenidoPorCursos) => {
            this.editarContenidoPorCursoForm.get('cont_Id').setValue(data[0].cont_Id);
            this.editarContenidoPorCursoForm.get('cont_Descripcion').setValue(data[0].cont_Descripcion);
    
          }
        });
      }
    
      FillContenidoPorCurso(id) {
        this.contenidoPorCursosService.fillContenidoPorCurso(id).subscribe({
            next: (data: ContenidoPorCursos) => {
                this.editarContenidoPorCursoForm = new FormGroup({
                  conPc_Id: new FormControl(data[0].conPc_Id),
                    curso_Id: new FormControl(data[0].curso_Id,Validators.required),
                    cont_Id: new FormControl(data[0].cont_Id,Validators.required),
                    cont_Descripcion: new FormControl("",Validators.required),
                    curso_DuracionHoras: new FormControl("",Validators.required),
                    cate_Descripcion: new FormControl("",Validators.required),
                    curso_Descripcion: new FormControl("",Validators.required),
                });
                console.log(this.ID);
                this.CollapseEdit = true;
                this.Tabla=false;
    
                console.log(data)
            }
        });
      }
    
    //   deleteContenidoporCurso(codigo) {
    //     this.deleteContenidoPorCursoBool = true;
    //     this.ID = codigo;
    //   }
    
    



    /////////////////CONTENIDO POR CURSO//////////////////////////////////
    

    // response => {
    //     if (response.code == 200) {
    
    //         // Asignar el ID del curso al label
    //         const cursoIdLabel = document.getElementById('cursoIdLabel');
    //         if (cursoIdLabel) {
    //             cursoIdLabel.innerText = response.data.CursoId; // Asegúrate de que la respuesta contenga el ID del curso correctamente
    //         }
    
    //         // Resto del código...
    //     }
    // }
    
    //INSERTAR
    onSubmitInsert(): void {
      this.isSubmit = true;
      const errorSpan = document.getElementById('error-span');
  
      if (this.crearCursoForm.valid) {
          const cursoData: Curso = this.crearCursoForm.value;
          this.cursoservice.insertCursoId(cursoData).subscribe(
              response => {
                  if (response.code == 200) {
                      // Curso insertado exitosamente
                      this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });
                      console.log(response);
  
                      const cursoId = response.data.curso_Id; 
                      this.crearCursoForm.get('curso_Id').setValue(cursoId);
  
                      this.crearCursoForm.disable();
  
                      console.log('ID del curso creado actualmente: ' + cursoId);
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
                    empre_Id: new FormControl(data[0].empre_Id,Validators.required),
                   
                    cate_Id: new FormControl(data[0].cate_Id,Validators.required),
                });

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
          });

    }


    getCategorias() {
        this.categoriaService.getCategoria().subscribe((response: any) => {
            console.log("Categorias:", response);
            const categorias = response.data; 
            if (categorias.length > 0) {
                categorias.forEach(categoria => {
                    this.idCategorias.push(Number(categoria.cate_Id)); 
                    this.fillCursosPorCategoria(categoria.cate_Id, categoria.cate_Descripcion);
                });
            } else {
                console.log("No se encontraron categorías disponibles.");
            }
        });
    }
    
    
    fillCursosPorCategoria(categoriaId: number, categoriaNombre: string) {
        console.log("Categoria ID:", categoriaId); 
        this.cursoService.fillCursoPorCategoria(categoriaId).subscribe((response: any) => {
            console.log("Cursos de la categoria", categoriaId, ":", response);
            if (response && response.length > 0) {
                const cursos = response.map(curso => new TreeNode(curso.curso_Descripcion));
                const categoriaNode = new TreeNode(categoriaNombre, cursos);
                this.categoriasConCursos.push(categoriaNode);
            } else {
                console.log(`No hay cursos para esa categoria ${categoriaId}.`);
            }
        });
    }




    getCategorias1() {
        this.categoriaService.getCategoria().subscribe((response: any) => {
            console.log("Categorias:", response);
            const categorias = response.data; 
            if (categorias.length > 0) {
                categorias.forEach(categoria => {
                    this.idCategorias.push(Number(categoria.cate_Id)); 
                    this.fillContenidosPorCurso(categoria.cate_Id, categoria.cate_Descripcion);
                });
            } else {
                console.log("No se encontraron categorías CON CURSOS DISPONIBLES");
            }
        });
    }


    fillContenidosPorCurso(categoriaId: number, categoriaNombre: string) {
        console.log("Categoria ID:", categoriaId); 
        this.contenidoService.fillContenidoPorCategoria(categoriaId).subscribe((response: any) => {
            console.log("contenidos de la categoria", categoriaId, ":", response);
            if (response && response.length > 0) {
                const contenido = response.map(contenido => new TreeNode(contenido.cont_Descripcion));
                const categoriaNode = new TreeNode(categoriaNombre, contenido);
                this.categoriasConContenidos.push(categoriaNode);
            } else {
                console.log(`No hay contenido para ese contenido ${categoriaId}.`);
            }
        });
    }

    convertToArray(obj: any): any[] {
        return Object.values(obj);
    }
}
