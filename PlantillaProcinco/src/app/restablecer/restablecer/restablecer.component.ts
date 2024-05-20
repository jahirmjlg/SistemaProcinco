import { Component } from '@angular/core';
import { RestablecerService } from 'src/app/Services/restablecer.service';
import { Contra } from 'src/app/Models/loginViewModel';
import { Router } from '@angular/router';

import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, MessageService } from 'primeng/api';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-restablecer',
  templateUrl: './restablecer.component.html',
  styleUrls: ['./restablecer.component.scss'],
  providers: [ConfirmationService, MessageService]
})
export class RestablecerComponent {
  restaForm: FormGroup;

  isSubmit:boolean = false;

  cols: any[] = [];
  statuses: any[] = [];
  rowsPerPageOptions = [5, 10, 20];
  schemas = [
      CUSTOM_ELEMENTS_SCHEMA
    ];

    contra!:Contra[];



  constructor(private messageService: MessageService, private formBuilder: FormBuilder, private contraservice: RestablecerService, private router:Router, private cookieService: CookieService) {}
   errorMessage: string;

   ngOnInit() {

    this.restaForm = new FormGroup({
      usua_VerificarCorreo: new FormControl("",Validators.required),
      usua_Contraseña: new FormControl("",Validators.required),
    });

    this.schemas = [
      CUSTOM_ELEMENTS_SCHEMA
    ];
   }

   onSubmitEdit(): void {

    this.isSubmit = true;

    if (this.restaForm.valid) {
      const ciudadData: Contra = this.restaForm.value;
      this.contraservice.postrestablecer(ciudadData).subscribe(
        response => {

            if (response.code == 200) {


                this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Contraseña Reestablecida Exitosamente', life: 3000 });
                console.log(response)
                // this.router.navigate(['/pages/estados']);
                  this.router.navigate(['/pages/empty']);


            } else {

            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo reestablecer la contraseña', life: 3000 });
            }

        },
        error => {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo reestablecer la contraseña', life: 3000 });
            console.log(error);
        }
      );
    } else {
      console.log('Formulario inválido');
    }

}


}
