import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ContenidoporcursoService } from 'src/app/Services/contenidoporcurso.service';
import { CursoService } from 'src/app/Services/curso.service';
import { CategoriaService } from 'src/app/Services/categoria.service';
import { ContenidoService } from '../Services/contenido.service';
import { EmpresaService } from '../Services/empresa.service';
import { TreeNode } from 'primeng/api';
import { ContenidoPorCursos } from 'src/app/Models/ContenidoPorCursosViewModel';
import { Curso } from 'src/app/Models/CursosViewModel';
import { dropCategorias } from 'src/app/Models/CategoriasViewModel';
import { dropEmpresas } from 'src/app/Models/EmpresaViewModel';

@Component({
    selector: 'app-list-curso',
    templateUrl: './tree-contenidoPorCurso.component.html',
    providers: [MessageService],
})
export class treeContendioPorCursoComponent implements OnInit {
    @ViewChild('fileupload') fileupload: any;
    Tabla: boolean = true;
    Collapse: boolean = false;
    CollapseEdit: boolean = false;
    isSubmit: boolean = false;
    isSubmitEdit: boolean = false;
    CollapseDetalle: boolean = false;
    deleteCursoBool: boolean = false;

    dropCategorias: any[] = [];
    dropEmpresas: any[] = [];
    selectedFile: File;

    cursoID: string = "";
    cursoDescripcion: string = "";
    cursoDuracion: number = 0;
    cursoImagen: string = "";
    categoria: string = "";
    UsuarioCreacion: string = "";
    UsuarioModificacion: string = "";
    FechaCreacion: string = "";
    FechaModificacion: string = "";
    empresa: string = "";

    conPc_Id: string = "";
    cont_Id: string = "";
    cont_Descripcion: string = "";
    curso_Id: string = "";
    cont_DuracionHoras: string = "";
    curso_DuracionHoras: number = 0;
    curso_Imagen: string = "";
    cate_Descripcion: string = "";
    conPc_FechaCreacion: string = "";
    conPc_FechaModificacion: string = "";
    creacion: string = "";
    modificacon: string = "";
    ID: string = "";


    contenidoPcurso!: ContenidoPorCursos[];
    curso!: Curso[];
    crearCursoForm: FormGroup;
    editarCursoForm: FormGroup;
    categoriasConContenidos: TreeNode[] = [];
    selectedFiles1: any[] = [];
    selectedFilesEdit: TreeNode[] = [];
    cursoId: string;

    cols: any[];

    constructor(
        private contenidoPorCursoService: ContenidoporcursoService,
        private categoriaService: CategoriaService,
        private contenidoService: ContenidoService,
        private empresaservice: EmpresaService,
        private cursoService: CursoService,
        private formBuilder: FormBuilder,
        private messageService: MessageService
    ) {}

    ngOnInit() {
        this.crearCursoForm = this.formBuilder.group({
            curso_Descripcion: ['', [Validators.required]],
            curso_DuracionHoras: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
            curso_Imagen: ['', [Validators.required]],
            cate_Id: ['0', [Validators.required]],
            empre_Id: ['0', [Validators.required]],
        });

        this.editarCursoForm = this.formBuilder.group({
            curso_Id: ['', Validators.required],
            curso_Descripcion: ['', Validators.required],
            curso_DuracionHoras: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
            curso_Imagen: ['', Validators.required],
            empre_Id: ['0', Validators.required],
            cate_Id: ['0', Validators.required],
          });


        this.cursoService.getDdlCategorias().subscribe(
            (data: dropCategorias[]) => {
                this.dropCategorias = data;
            },
            (error) => {
                console.log(error);
            }
        );

        this.empresaservice.getDdlEmpresas().subscribe(
            (data: dropEmpresas[]) => {
                this.dropEmpresas = data;
            },
            (error) => {
                console.log(error);
            }
        );

        this.cursoService.getCurso().subscribe(
            (Response: any) => {
                this.curso = Response.data;
            },
            (error) => {
                console.log(error);
            }
        );

        this.getCategorias();

        this.cols = [
            { field: 'curso_Id', header: 'ID' },
            { field: 'curso_Descripcion', header: 'Descripcion' },
            { field: 'curso_DuracionHoras', header: 'Duracion' },
            { field: 'curso_Imagen', header: 'Imagen' },
            { field: 'categoria', header: 'Categoria' }
        ];
    }

    onUpload(event) {
        const file: File = event.files[0];
        if (file) {
            const uniqueSuffix = Date.now() + '-' + Math.round(Math.random() * 1E9);
            const uniqueFileName = uniqueSuffix + '-' + file.name;

            this.crearCursoForm.get('curso_Imagen').setValue(uniqueFileName);
            const formData: FormData = new FormData();

            formData.append('file', file, uniqueFileName);
            this.cursoService.upload(formData).subscribe(
                (response) => {
                    if (response.message == "Success") {
                        this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Imagen Subida', life: 3000 });
                    } else {
                        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Suba una imagen', life: 3000 });
                    }
                },
                (error) => {
                    console.error('Error al cargar imagen', error);
                }
            );
        }
    }

    onSubmitInsert(): void {
        this.isSubmit = true;

        if (this.crearCursoForm.valid) {
            const formData = {
                txtCurso: this.crearCursoForm.value.curso_Descripcion,
                txtxEmpresa: Number(this.crearCursoForm.value.empre_Id),
                txtxHoras: Number(this.crearCursoForm.value.curso_DuracionHoras),
                txtImagen: this.crearCursoForm.value.curso_Imagen,
                txtCategoria: Number(this.crearCursoForm.value.cate_Id),
                contenidosSeleccionados: this.selectedFiles1.map(node => node.data?.cont_Id).filter(id => id != null)
            };
            console.log('Datos enviados:', formData);

            this.cursoService.EnviarCurso(formData).subscribe(
                (response) => {
                    if (response.success) {
                        this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                        this.cursoService.getCurso().subscribe(
                            (Response: any) => {
                                this.curso = Response.data;
                            },
                            (error) => {
                                console.log(error);
                            })

                        this.Collapse = false;
                        this.Tabla = true;



                    } else {
                        this.messageService.add({ severity: 'error', summary: 'Error', detail: response.message, life: 3000 });
                    }
                },
                (error) => {
                    console.error('Error al insertar curso:', error);
                    console.log('Detalles del error:', error.error);
                }
            );
        } else {
            console.log('Formulario inválido');
        }
    }



    onUploadEdit(event) {
        const file: File = event.files[0];
        if (file) {
            const uniqueSuffix = Date.now() + '-' + Math.round(Math.random() * 1E9);
            const uniqueFileName = uniqueSuffix + '-' + file.name;

            this.editarCursoForm.get('curso_Imagen').setValue(uniqueFileName);
            const formData: FormData = new FormData();

            formData.append('file', file, uniqueFileName);
            this.cursoService.upload(formData).subscribe(
                (response) => {
                    if (response.message == "Success") {
                        this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Imagen Subida', life: 3000 });
                    } else {
                        console.log(response)
                        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Suba una imagen', life: 3000 });
                    }
                },
                (error) => {
                    console.error('Error al cargar imagen', error);
                }
            );
        }
    }


    onSubmitEdit(): void {
        this.isSubmitEdit = true;

        if (this.editarCursoForm.valid) {
          const formData = {
            Curso_Id: this.editarCursoForm.value.curso_Id,
            txtCurso: this.editarCursoForm.value.curso_Descripcion,
            txtxEmpresa: Number(this.editarCursoForm.value.empre_Id),
            txtxHoras: Number(this.editarCursoForm.value.curso_DuracionHoras),
            txtImagen: this.editarCursoForm.value.curso_Imagen,
            txtCategoria: Number(this.editarCursoForm.value.cate_Id),
            contenidosSeleccionados: this.selectedFilesEdit.map((node) => node.data?.cont_Id).filter((id) => id != null),
          };
          console.log('Datos enviados para editar:', formData);

          this.cursoService.ActualizarCurso(formData).subscribe(
            (response) => {
              if (response.success) {
                this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });

                this.CollapseEdit = false;
                this.Tabla = true;

                this.cursoService.getCurso().subscribe(
                    (Response: any) => {
                        this.curso = Response.data;
                    },
                    (error) => {
                        console.log(error);
                    })


              } else {
                this.messageService.add({ severity: 'error', summary: 'Error', detail: response.message, life: 3000 });
              }
            },
            (error) => {
              console.error('Error al editar curso:', error);
              this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo editar el curso.', life: 3000 });
            }
          );
        } else {
          console.log('Formulario inválido');
        }
      }











updateSelectedFilesEdit() {
  this.selectedFilesEdit = [];
  this.updateSelectedNodes(this.categoriasConContenidos);
}


updateSelectedNodes(nodes: TreeNode[]) {
  nodes.forEach(node => {
      if (node.partialSelected || this.selectedFilesEdit.includes(node)) {
          this.selectedFilesEdit.push(node);
      }
      if (node.children && node.children.length > 0) {
          this.updateSelectedNodes(node.children);
      }
  });
}




  toggleNodeSelection(node: TreeNode, isSelected: boolean) {
    node.partialSelected = !isSelected;
    node.expanded = isSelected;

    if (node.children && node.children.length > 0) {
        node.children.forEach(child => {
            this.toggleNodeSelection(child, isSelected);
        });
    }

    if (isSelected) {
        if (!this.selectedFilesEdit.includes(node)) {
            this.selectedFilesEdit.push(node);
        }
    } else {
        const index = this.selectedFilesEdit.indexOf(node);
        if (index > -1) {
            this.selectedFilesEdit.splice(index, 1);
        }
    }
}





      Fill(id: string) {
        this.cursoService.getDetalles(id).subscribe({
            next: (data: any) => {
                console.log('Detalles del curso:', data);
                const curso = data[0];
                this.editarCursoForm.setValue({
                    curso_Id: curso.curso_Id,
                    curso_Descripcion: curso.curso_Descripcion,
                    curso_DuracionHoras: curso.curso_DuracionHoras,
                    curso_Imagen: curso.curso_Imagen,
                    empre_Id: curso.empre_Id,
                    cate_Id: curso.cate_Id,
                });

                this.cursoService.getContenidosPorCurso(id).subscribe({
                    next: (contenidos: any) => {
                        console.log('Contenidos del curso:', contenidos);
                        const selectedIds = contenidos.map(c => c.cont_Id);
                        console.log('Selected IDs:', selectedIds); // Asegúrate de que esto imprime los IDs correctos
                        this.selectedFilesEdit = [];
                        this.markSelectedNodes(this.categoriasConContenidos, selectedIds);
                        console.log('Nodos seleccionados:', this.selectedFilesEdit);
                        this.CollapseEdit = true;
                        this.Tabla = false;
                    },
                    error: (err) => {
                        console.error('Error al obtener contenidos:', err);
                        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudieron obtener los contenidos del curso.', life: 3000 });
                    }
                });
            },
            error: (err) => {
                console.error('Error al obtener detalles del curso:', err);
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudieron obtener los detalles del curso.', life: 3000 });
            }
        });
    }








    onNodeSelect(event) {
      const node = event.node;
      if (node) {
          this.selectNodeAndChildren(node, true);
          this.updateParentSelection(node);
          console.log('ID seleccionado:', node.data?.cont_Id);
      }
  }

  onNodeUnselect(event) {
      const node = event.node;
      if (node) {
          this.selectNodeAndChildren(node, false);
          this.updateParentSelection(node);
          console.log('ID deseleccionado:', node.data?.cont_Id);
      }
  }

  selectNodeAndChildren(node: TreeNode, isSelected: boolean) {
      if (node.children && node.children.length > 0) {
          node.children.forEach(child => {
              this.selectNodeAndChildren(child, isSelected);
          });
      }

      if (isSelected) {
          if (!this.selectedFilesEdit.includes(node)) {
              this.selectedFilesEdit.push(node);
          }
      } else {
          const index = this.selectedFilesEdit.indexOf(node);
          if (index > -1) {
              this.selectedFilesEdit.splice(index, 1);
          }
      }

      node.partialSelected = false;
  }

  updateParentSelection(node: TreeNode) {
      if (node.parent) {
          const parent = node.parent;
          const allChildrenSelected = parent.children.every(child => this.selectedFilesEdit.includes(child));
          const noChildSelected = parent.children.every(child => !this.selectedFilesEdit.includes(child));

          if (allChildrenSelected) {
              if (!this.selectedFilesEdit.includes(parent)) {
                  this.selectedFilesEdit.push(parent);
              }
              parent.partialSelected = false;
          } else if (noChildSelected) {
              const index = this.selectedFilesEdit.indexOf(parent);
              if (index > -1) {
                  this.selectedFilesEdit.splice(index, 1);
              }
              parent.partialSelected = false;
          } else {
              const index = this.selectedFilesEdit.indexOf(parent);
              if (index > -1) {
                  this.selectedFilesEdit.splice(index, 1);
              }
              parent.partialSelected = true;
          }

          this.updateParentSelection(parent);
      }
  }



      markSelectedNodes(nodes: TreeNode[], selectedIds: number[]) {
        nodes.forEach(node => {
            if (node.children && node.children.length > 0) {
                this.markSelectedNodes(node.children, selectedIds);

                // Check if all children are selected
                const allChildrenSelected = node.children.every(child => selectedIds.includes(child.data.cont_Id));
                if (allChildrenSelected) {
                    node.partialSelected = false;
                    node.expanded = true;
                    node.children.forEach(child => {
                        child.partialSelected = false;
                        child.expanded = true;
                    });
                    this.selectedFilesEdit.push(node);
                } else {
                    // If not all children are selected, only expand the node and check the selected children
                    node.expanded = node.children.some(child => child.partialSelected || selectedIds.includes(child.data.cont_Id));
                }
            } else if (selectedIds.includes(node.data.cont_Id)) {
                node.partialSelected = true;
                node.expanded = true;
                this.selectedFilesEdit.push(node);
            }
        });
        console.log('Nodos después de marcar:', nodes);
    }




      getSelectedNodes(nodes: TreeNode[], selectedIds: number[]): TreeNode[] {
        const selectedNodes: TreeNode[] = [];
        nodes.forEach((node) => {
          if (node.children && node.children.length > 0) {
            const selectedChildren = this.getSelectedNodes(node.children, selectedIds);
            if (selectedChildren.length > 0) {
              selectedNodes.push(...selectedChildren);
            }
          } else if (selectedIds.includes(node.data.cont_Id)) {
            selectedNodes.push(node);
          }
        });
        return selectedNodes;
      }




      detalles(id){

        this.cursoService.fillCurso(id).subscribe({
            next: (data: Curso) => {
               this.cursoID = data[0].curso_Id,
               this.cursoDescripcion = data[0].curso_Descripcion,
               this.cursoDuracion = data[0].curso_DuracionHoras,
               this.cursoImagen = data[0].curso_Imagen,
               this.categoria = data[0].categoria,
               this.empresa = data[0].empre_Id,
               this.UsuarioCreacion = data[0].creacion,
               this.FechaCreacion = data[0].curso_FechaCreacion
               this.UsuarioModificacion = data[0].modificacion
               this.FechaModificacion = data[0].curso_FechaModificacion
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
          this.cursoService.EliminarCurso(this.cursoID).subscribe({
              next: (response) => {
                  if(response.code == 200){
                      this.cursoService.getCurso().subscribe((Response: any)=> {
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
                  this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
                }
          },
      });

      }



      getCategorias() {
        this.categoriaService.getCategoria().subscribe(
          (response: any) => {
            const categorias = response.data;
            if (categorias.length > 0) {
              categorias.forEach((categoria) => {
                this.fillContenidosPorCurso(categoria.cate_Id, categoria.cate_Descripcion);
              });
            } else {
              console.log('No se encontraron categorías disponibles.');
            }
          },
          (error) => {
            console.log(error);
          }
        );
      }

      fillContenidosPorCurso(categoriaId: number, categoriaNombre: string) {
        this.contenidoService.fillContenidoPorCategoria(categoriaId).subscribe(
          (response: any) => {
            if (response && response.length > 0) {
              const contenidoNodes = response.map((contenido) => ({
                label: contenido.cont_Descripcion,
                data: { cont_Id: contenido.cont_Id },
              }));
              const categoriaNode = { label: categoriaNombre, children: contenidoNodes };
              this.categoriasConContenidos.push(categoriaNode);
            } else {
              console.log(`No hay contenido para esa categoría ${categoriaId}.`);
            }
          },
          (error) => {
            console.log(error);
          }
        );
      }
    }
