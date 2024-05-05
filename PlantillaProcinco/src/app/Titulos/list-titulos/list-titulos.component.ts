import { Component, OnInit } from '@angular/core';
import { TitulosService } from '../../Services/titulos.service';
import { Titulo } from 'src/app/Models/TitulosViewModel';
import {Router} from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-list-titulos',
  styleUrls: ['./list-titulos.scss'],
  templateUrl: './list-titulos.component.html',
  providers: [ConfirmationService, MessageService]

})
export class ListTitulosComponent implements OnInit{

    Tabla: boolean = true;

    Collapse: boolean = false;
    isSubmit: boolean = false;


    CollapseEdit: boolean = false;
    isSubmitEdit: boolean = false;
    
    CollapseDetalle: boolean = false;

    //BOOLEAN DELETE
    deleteTituloBool: boolean = false;

    titl_Id: String = "";
    Titulo: String = "";
    valor: String = "";
    UsuarioCreacion: String = "";
    UsuarioModificacion: String = "";
    FechaCreacion: String = "";
    FechaModificacion: String = "";
    ID: String = "";
        
    cols: any[] = [];
    statuses: any[] = [];
    rowsPerPageOptions = [5, 10, 20];
    schemas = [
      CUSTOM_ELEMENTS_SCHEMA
    ];

  //   variable para iterar
  titulo!:Titulo[];


  crearTituloForm: FormGroup
  editarTituloForm: FormGroup
  //ultimos dos
  constructor(private messageService: MessageService, private tituloservice: TitulosService, private router: Router,
    private formBuilder: FormBuilder, private cookieService: CookieService) { }

  ngOnInit() {

    this.crearTituloForm = this.formBuilder.group({
        titl_Descripcion: ['', [Validators.required]],
        titl_ValorMonetario: ['0', [Validators.required]],
    });

    this.editarTituloForm = new FormGroup({
        ID: new FormControl("",Validators.required),
        titl_Descripcion: new FormControl("", Validators.required),
        titl_ValorMonetario: new FormControl("", Validators.required),
     })
    
      // Respuesta de la api
      this.tituloservice.getTitulos().subscribe((Response: any)=> {
          console.log(Response.data);
          this.titulo = Response.data;

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
    if (this.crearTituloForm.valid) {
      const contenidoData: Titulo = this.crearTituloForm.value;
      this.tituloservice.insertTitulo(contenidoData).subscribe(
       response => {

        if (response.code == 200) 
        {
            this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

                // this.cookieService.set('namee', response.data.empl_Nombre);

            console.log(response)
                // this.router.navigate(['/pages/estados']);
            this.tituloservice.getTitulos().subscribe((Response: any)=> {
                console.log(Response.data);
                this.titulo = Response.data;
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

        if (this.editarTituloForm.valid) {
          const contenidoData: Titulo = this.editarTituloForm.value;
          this.tituloservice.editTitulo(contenidoData).subscribe(
            response => {

                if (response.code == 200) {


                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
                    console.log(response)
                    // this.router.navigate(['/pages/estados']);
                    this.tituloservice.getTitulos().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.titulo = Response.data;
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

        this.tituloservice.fillTitulo(id).subscribe({
            next: (data: Titulo) => {
               this.titl_Id = data[0].titl_Id,
               this.Titulo = data[0].titl_Descripcion,
               this.valor = data[0].titl_ValorMonetario,
               this.UsuarioCreacion = data[0].usuarioCreacion,
               this.UsuarioModificacion = data[0].usuarioModificacion,
               this.FechaCreacion = data[0].titl_FechaCreacion,
               this.FechaModificacion = data[0].titl_FechaModificacion
                console.log(data);            
            }
          });
          this.CollapseDetalle = true;
          this.Tabla=false;
    }

    deleteTitulo(codigo) {
        this.deleteTituloBool = true;
        this.ID = codigo;
        console.log("ID" + codigo);
    }

    confirmDelete() {
        this.tituloservice.deleteTitulo(this.ID).subscribe({
            next: (response) => {
                if(response.code == 200){
                    this.tituloservice.getTitulos().subscribe((Response: any)=> {
                        console.log(Response.data);
                        this.titulo = Response.data;
                    });
                    this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
                    this.Tabla=true;
                    this.deleteTituloBool = false;

                }
                else{
                    console.log(response)
                this.deleteTituloBool = false;
                this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
                }
            },
        });
    }

    Fill(id) {
        this.tituloservice.fillTitulo(id).subscribe({
            next: (data: Titulo) => {
                this.ID = data[0].titl_Id,
                this.editarTituloForm = new FormGroup({
                    titl_Id: new FormControl(data[0].titl_Id),
                    titl_Descripcion: new FormControl(data[0].titl_Descripcion,Validators.required),
                    titl_ValorMonetario: new FormControl(data[0].titl_ValorMonetario,Validators.required),
                });
                console.log(this.ID);

                this.CollapseEdit = true;
                this.Tabla=false;

                console.log(data)

            }
        });
    }

}
