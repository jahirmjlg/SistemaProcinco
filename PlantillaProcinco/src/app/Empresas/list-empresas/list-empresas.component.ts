// import { ChangeDetectorRef, Component, ElementRef, ViewChild } from '@angular/core';
// import {RolesService} from '../../Services/roles.service';
// import {Role} from 'src/app/Models/RolesViewModel';
// import {Router} from '@angular/router';
// import { PantallasService } from 'src/app/Services/pantallas.service';
// import { Pantalla } from 'src/app/Models/PantallasViewModel';
// import { ConfirmationService, MessageService } from 'primeng/api';
// import { NgModule, CUSTOM_ELEMENTS_SCHEMA, AfterContentInit } from '@angular/core';
// import { FormBuilder, FormControl, FormArray, FormGroup, Validators } from '@angular/forms';
// import { CookieService } from 'ngx-cookie-service';
// import { PantallasPorRolesService } from 'src/app/Services/pantallas-por-roles.service';
// import { PantallaPorRol } from 'src/app/Models/PantallasPorRolesViewModel';
// import { Empresa } from 'src/app/Models/EmpresaViewModel';
// import { EmpresaService } from 'src/app/Services/empresa.service';
// @Component({
//   selector: 'app-list-empresas',
//   templateUrl: './list-empresas.component.html',
//   styleUrl: './list-empresas.component.scss',
//   providers: [ConfirmationService, MessageService]
// })
// export class ListEmpresasComponent {

//     Tabla: boolean = true;

//     Collapse: boolean = false;
//     isSubmit: boolean = false;

//     CollapseEdit: boolean = false;
//     isSubmitEdit: boolean = false;

//     CollapseDetalle: boolean = false;

//     deleteRolBool: boolean = false;

//     ID: String = "";

//     itemsGroup1: { part_Id: number, part_Descripcion: string }[] = [];
//     itemsGroup2: { part_Id: number, part_Descripcion: string }[] = [];

//     itemsGroup1Edit: { part_Id: number, part_Descripcion: string }[] = [];
//     itemsGroup2Edit: { part_Id: number, part_Descripcion: string }[] = [];


//   cols: any[] = [];
//   statuses: any[] = [];
//   rowsPerPageOptions = [5, 10, 20];
//   schemas = [
//       CUSTOM_ELEMENTS_SCHEMA
//     ];

//   //   variable para iterar
//   empresa!:Empresa[];

//   //CAMBIAR POR PARTICIPANTE
//   participantes!:Pantalla[];

//   crearEmpresaForm: FormGroup
//   editarEmpresaForm: FormGroup


//   //Detalle
//   empreId : number = 0;
//   empreDescripcion  : string = "";
//   empreDireccion  : string;
//   ciudad  : String = "";
//   UsuarioCreacion : String = "";
//   FechaCreacion : string = "";
//   UsuarioModificacion : String = "";
//   FechaModificacion : string = "";


//   constructor(
//     private cdRef: ChangeDetectorRef,
//      private messageService: MessageService,
//      private serviceEmp: EmpresaService,
//      private router: Router,
//      private formBuilder: FormBuilder,
//       private cookieService: CookieService,
//        private pantallaservice: PantallasService, //PARTICIPANTE
//        private paroservice : PantallasPorRolesService ) { }

//   ngOnInit() {
//     this.crearEmpresaForm = this.formBuilder.group({
//         role_Descripcion: ['', [Validators.required]],
//         screens: this.formBuilder.array([])
//     });

//     this.editarEmpresaForm = new FormGroup({
//         role_Id: new FormControl("",Validators.required),
//         role_Descripcion: new FormControl("", Validators.required),
//         screens: this.formBuilder.array([])
//     })

//     // Respuesta de la api
//     this.serviceEmp.getEmpresas().subscribe((Response: any)=> {
//         console.log(Response.data);
//         this.empresa = Response.data;
//     }, error=>{
//         console.log(error);
//     });

//     //CAMBIAR POR PARTICIPANTE
//     this.pantallaservice.getPantalla().subscribe((Response: any)=>{
//         console.log(Response.data);
//         this.participantes = Response.data;
//     });




//       this.schemas = [
//           CUSTOM_ELEMENTS_SCHEMA
//         ];
//   }



// onSubmitInsert(): void {

//     this.isSubmit = true;

//         const errorSpan = document.getElementById('error-span');
//     if (this.crearEmpresaForm.valid) {
//       const ciudadData: Estado = this.crearEmpresaForm.value;
//       this.serviceEmp.insertEmpresas(ciudadData).subscribe(
//         response => {

//             if (response.code == 200) {

//                 this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Insertado Exitosamente', life: 3000 });

//                 // this.cookieService.set('namee', response.data.empl_Nombre);

//                 console.log(response)
//                 // this.router.navigate(['/pages/estados']);
//                 this.serviceEmp.getEmpresas().subscribe((Response: any)=> {
//                     console.log(Response.data);
//                     this.empresa = Response.data;
//                 });

//                 this.Collapse = false;
//                 this.Tabla = true;
//             } else {

//             this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Agregar el Registro', life: 3000 });


//             }

//         },
//         error => {
//             errorSpan.classList.remove('collapse');
//         }
//       );
//     } else {
//       console.log('Formulario inválido');
//     }

// }


//     onSubmitEdit(): void {

//         this.isSubmitEdit = true;

//         if (this.editarEmpresaForm.valid) {
//           const ciudadData: Estado = this.editarEmpresaForm.value;
//           this.serviceEmp.editEmpresa(ciudadData).subscribe(
//             response => {

//                 if (response.code == 200) {


//                     this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Editado Exitosamente', life: 3000 });
//                     console.log(response)
//                     // this.router.navigate(['/pages/estados']);
//                     this.serviceEmp.getEmpresas().subscribe((Response: any)=> {
//                         console.log(Response.data);
//                         this.empresa = Response.data;
//                     });

//                     this.CollapseEdit = false;
//                     this.Tabla = true;

//                 } else {

//                 this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Editar el Registro', life: 3000 });


//                 }

//             },
//             error => {
//                 console.log(error);
//             }
//           );
//         } else {
//           console.log('Formulario inválido');
//         }

//     }


//     deleteRol(codigo) {
//         this.deleteRolBool = true;
//         this.ID = codigo;
//         console.log("ID" + codigo);
//     }


//     confirmDelete() {
//         this.serviceEmp.deleteEmpresa(this.ID).subscribe({
//             next: (response) => {
//                 if(response.code == 200){
//                     this.serviceEmp.getEmpresa().subscribe((Response: any)=> {
//                         console.log(Response.data);
//                         this.empresa = Response.data;
//                     });
//                     this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Registro Eliminado Exitosamente', life: 3000 });
//                     this.Tabla=true;
//                     this.deleteRolBool = false;

//                 }
//                 else{
//                     console.log(response)
//                 this.deleteRolBool = false;
//                 this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo Eliminar el Registro', life: 3000 });
//                 }
//             },
//         });
//     }






//         Fill(id) {
//             this.serviceEmp.fillEmpresa(id).subscribe({
//               next: (data: Empresa) => {
//                 this.editarEmpresaForm = new FormGroup({
//                   empre_Id: new FormControl(data[0].empre_Id,Validators.required),
//                   empre_Descripcion: new FormControl(data[0].empre_Descripcion,Validators.required),
//                 });

//               this.CollapseEdit = true;
//               this.Tabla=false;

//               console.log(data)

//               }
//             });
//           }


//     cancelar()
//     {
//         this.CollapseEdit=false;
//         this.Tabla=true;
//         this.isSubmitEdit=false
//         this.itemsGroup1Edit = []
//         this.itemsGroup2Edit = []

//     }


//     detalles(id){

//         this.serviceEmp.fillEmpresa(id).subscribe({
//             next: (data: Role) => {
//                this.empreId = data[0].role_Id,
//                this.empreDescripcion = data[0].role_Descripcion,
//                this.empreDireccion = data[0].usuarioCreacion,
//                this.ciudad = data[0].usuarioModificacion,
//                this.UsuarioCreacion = data[0].role_FechaCreacion,
//                this.FechaCreacion = data[0].role_FechaModificacion,
//                this.UsuarioModificacion = data[0].role_FechaCreacion,
//                this.FechaModificacion = data[0].role_FechaCreacion
//             }
//           });
//           this.CollapseDetalle = true;
//           this.Tabla=false;
//     }


// }

