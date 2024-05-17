import { Component, OnInit,  ViewChild , ElementRef, ChangeDetectorRef } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser'; 
import { ContenidoPorCursos, Curso, CursoEnviar  } from 'src/app/Models/ContenidoPorCursosViewModel'; 
import { ContenidoporcursoService } from 'src/app/Services/contenidoporcurso.service';
import { CursoService } from 'src/app/Services/curso.service';
import { CategoriaService } from 'src/app/Services/categoria.service'; 
import { Categoria } from 'src/app/Models/CategoriasViewModel';
import { TreeNodee } from 'src/app/Models/TreeViewModel'; 
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
import { NodeService } from 'src/app/demo/service/node.service';
import { Cursoo, Fill } from 'src/app/Models/CursosViewModel';
import { TreeNode} from 'primeng/api';


@Component({
  selector: 'app-list-curso',
  templateUrl: './tree-contenidoPorCurso.component.html',
  styleUrls: ['./tree-contenidoPorCurso.component.scss'],
  providers: [MessageService]
})



export class treeContendioPorCursoComponent implements OnInit {
  @ViewChild('fileupload') fileupload: FileUpload;

  // Variables
  Tabla: boolean = true;
  Collapse: boolean = false;
  isSubmit: boolean = false;
  CollapseEdit: boolean = false;
  isSubmitEdit: boolean = false;
  CollapseDetalle: boolean = false;
  deleteCursoBool: boolean = false;
  dropCategorias: any[] = [];
  dropEmpresas: any[] = [];
  selectedFile: File;
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
  cols: any[] = [];
  statuses: any[] = [];
  rowsPerPageOptions = [5, 10, 20];
  schemas = [CUSTOM_ELEMENTS_SCHEMA];
  curso!: Curso[];
  crearCursoForm: FormGroup;
  editarCursoForm: FormGroup;
  categoriasConContenidos: any[] = [];
  selectedFiles1: any[] = [];

  constructor(
    private cursoservice: CursoService,
    private router: Router,
    private formBuilder: FormBuilder,
    private cookieService: CookieService,
    private empresaservice: EmpresaService,
    private messageService: MessageService,
    private cdRef: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.inicializarFormularios();
    this.cargarDropdowns();
    this.cargarCursos();
  }

  inicializarFormularios() {
    this.crearCursoForm = this.formBuilder.group({
      curso_Descripcion: ['', [Validators.required]],
      curso_DuracionHoras: ['', [Validators.required]],
      curso_Imagen: ['', [Validators.required]],
      cate_Id: ['0', [Validators.required]],
      empre_Id: ['0', [Validators.required]]
    });

    this.editarCursoForm = this.formBuilder.group({
      curso_Id: ['', [Validators.required]],
      curso_Descripcion: ['', [Validators.required]],
      curso_DuracionHoras: ['', [Validators.required]],
      cate_Id: ['', [Validators.required]],
      curso_Imagen: ['', [Validators.required]],
      empre_Id: ['', [Validators.required]],
      contenidosSeleccionados: this.formBuilder.array([]) // Aquí se almacenarán los contenidos seleccionados
    });
  }

  cargarDropdowns() {
    this.cursoservice.getDdlCategorias().subscribe(
      (data: dropCategorias[]) => {
        this.dropCategorias = data;
      },
      error => {
        console.log(error);
      }
    );

    this.empresaservice.getDdlEmpresas().subscribe(
      (data: dropEmpresas[]) => {
        this.dropEmpresas = data;
      },
      error => {
        console.log(error);
      }
    );
  }

  cargarCursos() {
    this.cursoservice.getCurso().subscribe(
      (Response: any) => {
        this.curso = Response.data;
      },
      error => {
        console.log(error);
      }
    );
  }

  Cancel() {
    this.Collapse = false;
    this.Tabla = true;
    this.isSubmitEdit = false;
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
          if (response.code == 200) {
            this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Imagen Subida', life: 3000 });
          } else {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Suba una imagen', life: 3000 });
          }
        },
        error => {
          console.error('Error al cargar imagen', error);
        }
      );
    }
  }

  onSubmitInsert() {
    this.isSubmit = true;
    const errorSpan = document.getElementById('error-span');
    if (this.crearCursoForm.valid) {
      const cursoData: Curso = this.crearCursoForm.value;
      this.cursoservice.insertCurso(cursoData).subscribe(
        response => {
          if (response.code == 200) {
            this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });
            this.cursoservice.getCurso().subscribe((Response: any) => {
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

  onSubmitEdit() {
    this.isSubmitEdit = true;
    if (this.editarCursoForm.valid) {
      const cursoData = this.editarCursoForm.value;
      cursoData.contenidosSeleccionados = this.selectedFiles1.map(c => c.key);
      this.cursoservice.ActualizarCurso(cursoData).subscribe(
        response => {
          if (response.success) {
            this.messageService.add({ severity: 'success', summary: 'Éxito', detail: 'Curso actualizado exitosamente', life: 3000 });
            this.CollapseEdit = false;
            this.Tabla = true;
          } else {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo actualizar el curso', life: 3000 });
          }
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Ocurrió un error al actualizar el curso', life: 3000 });
        }
      );
    }
  }

  Fill(cursoId: string) {
    this.cursoservice.getContenidosPorCurso(cursoId).subscribe((data: any) => {
      this.editarCursoForm.patchValue({
        curso_Id: data.curso_Id,
        curso_Descripcion: data.curso_Descripcion,
        curso_DuracionHoras: data.curso_DuracionHoras,
        cate_Id: data.cate_Id,
        curso_Imagen: data.curso_Imagen,
        empre_Id: data.empre_Id
      });

      this.cursoservice.getContenidosPorCurso(cursoId).subscribe((contenidos: any) => {
        this.selectedFiles1 = contenidos.map((contenido: any) => {
          return {
            key: contenido.cont_Id,
            label: contenido.cont_Descripcion
          };
        });

        this.updateTreeviewSelection();
        this.CollapseEdit = true;
        this.Tabla = false;
        this.cdRef.detectChanges();
      });
    });
  }

  updateTreeviewSelection() {
    this.categoriasConContenidos.forEach((categoria: any) => {
      if (categoria.children) {
        categoria.children.forEach((contenido: any) => {
          contenido.selected = this.selectedFiles1.some(selected => selected.key === contenido.key);
        });
      }
    });
  }

  detalles(id) {
    this.cursoservice.fillCurso(id).subscribe({
      next: (data: Curso) => {
        this.cursoID = data[0].curso_Id;
        this.cursoDescripcion = data[0].curso_Descripcion;
        this.cursoDuracion = data[0].curso_DuracionHoras;
        this.cursoImagen = data[0].curso_Imagen;
        this.categoria = data[0].categoria;
        this.UsuarioCreacion = data[0].creacion;
        this.FechaCreacion = data[0].curso_FechaCreacion;
        this.UsuarioModificacion = data[0].modificacion;
        this.FechaModificacion = data[0].curso_FechaModificacion;
      }
    });
    this.CollapseDetalle = true;
    this.Tabla = false;
  }

  deleteCurso(codigo) {
    this.deleteCursoBool = true;
    this.cursoID = codigo;
  }

  confirmDelete() {
    this.cursoservice.deleteCurso(this.cursoID).subscribe({
      next: (response) => {
        if (response.code == 200) {
          this.cursoservice.getCurso().subscribe((Response: any) => {
            this.curso = Response.data;
          });
          this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
          this.Tabla = true;
          this.deleteCursoBool = false;
        } else {
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
          this.deleteCursoBool = false;
        }
      }
    });
  }
}