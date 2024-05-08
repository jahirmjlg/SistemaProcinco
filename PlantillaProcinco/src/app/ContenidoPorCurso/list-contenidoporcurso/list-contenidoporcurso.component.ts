import { Component } from '@angular/core';
import { ContenidoporcursoService } from 'src/app/Services/contenidoporcurso.service';
import { ContenidoPorCursos } from 'src/app/Models/ContenidoPorCursosViewModel';

import {Router} from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-list-contenidoporcurso',
  templateUrl: './list-contenidoporcurso.component.html',
  styleUrls: ['./list-contenidoporcurso.component.scss'],
  providers: [ConfirmationService, MessageService]
})
export class ListContenidoporcursoComponent {
  Tabla: boolean = true;

  Collapse: boolean = false;
  isSubmit: boolean = false;


  CollapseEdit: boolean = false;
  isSubmitEdit: boolean = false;

  CollapseDetalle: boolean = false;

  //BOOLEAN DELETE
  deleteContenidoPorCursoBool: boolean = false;


  ImagenEncontrada: boolean = false;

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

  cols: any[] = [];
  statuses: any[] = [];
  rowsPerPageOptions = [5, 10, 20];
  schemas = [
    CUSTOM_ELEMENTS_SCHEMA
  ];

  contenidoPcurso !: ContenidoPorCursos[];

  crearContenidoPorCursoForm: FormGroup;
  editarContenidoPorCursoForm : FormGroup;

  constructor(private messageService: MessageService, private contenidoPorCursosService : ContenidoporcursoService, private router: Router, private formBuilder: FormBuilder, private cookieService: CookieService) { }

  ngOnInit() {
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

    this.schemas = [
      CUSTOM_ELEMENTS_SCHEMA
    ];
  }

  onSubmitInsert(): void {

      this.isSubmit = true;

      if (this.crearContenidoPorCursoForm.valid) {
        const cursoimpData: ContenidoPorCursos = this.crearContenidoPorCursoForm.value;
        this.contenidoPorCursosService.insertContenidoPorCurso(cursoimpData).subscribe(
          response => {

              if (response.code == 200) {

                  this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                  // this.cookieService.set('namee', response.data.empl_Nombre);

                  console.log(response)
                  // this.router.navigate(['/pages/estados']);
                  this.contenidoPorCursosService.getContenidoPorCurso().subscribe((Response: any)=> {
                      console.log(Response.data);
                      this.contenidoPcurso = Response.data;
                    });

                  this.Collapse = false;
                  this.Tabla = true;
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

  onSubmitEdit(): void {

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



  detalles(id){
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

  onCursocrearChange(curso){

    this.contenidoPorCursosService.BuscarCurso(curso).subscribe({
        next: (data: ContenidoPorCursos) => {
            this.crearContenidoPorCursoForm.get('curso_Id').setValue(data[0].curso_Id);
            this.crearContenidoPorCursoForm.get('curso_Descripcion').setValue(data[0].curso_Descripcion);
            this.crearContenidoPorCursoForm.get('curso_DuracionHoras').setValue(data[0].curso_DuracionHoras);
            this.crearContenidoPorCursoForm.get('cate_Descripcion').setValue(data[0].cate_Descripcion);
            this.crearContenidoPorCursoForm.get('curso_Imagen').setValue(data[0].curso_Imagen);

                   this.ImagenEncontrada = true;
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

        this.ImagenEncontrada = true;
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

  Fill(id) {
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

  deleteContenidoporCurso(codigo) {
    this.deleteContenidoPorCursoBool = true;
    this.ID = codigo;
  }


  confirmDelete() {
    this.contenidoPorCursosService.deleteContenidoPorCurso(this.ID).subscribe({
        next: (response) => {
            if(response.code == 200){
                this.contenidoPorCursosService.getContenidoPorCurso().subscribe((Response: any)=> {
                    console.log(Response.data);
                    this.contenidoPcurso = Response.data;
                });
                this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
                this.Tabla=true;
                this.deleteContenidoPorCursoBool = false;

            }
            else{
                console.log(response)
            this.deleteContenidoPorCursoBool = false;
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
            }
        },
    });
}
}