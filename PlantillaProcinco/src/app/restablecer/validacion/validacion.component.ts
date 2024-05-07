import { Component } from '@angular/core';
import { LayoutService } from 'src/app/layout/service/app.layout.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidarService } from 'src/app/Services/validar.service'; 
import { Login } from 'src/app/Models/loginViewModel'; 
import { emptyInputValidator } from 'src/app/demo/components/auth/login/CustomValidatorss'; 

import { Router } from '@angular/router';

import { CookieService } from 'ngx-cookie-service';

@Component({
    selector: 'app-validacion',
    templateUrl: './validacion.component.html',
    styleUrl: './validacion.component.scss'
})
export class ValidacionComponent {

    // valCheck: string[] = ['remember'];

    // password!: string;

    loginForm: FormGroup;

    constructor(public layoutService: LayoutService, private formBuilder: FormBuilder, private service: ValidarService, private router:Router, private cookieService: CookieService) {

        this.loginForm = this.formBuilder.group({
            usuario: ['', [Validators.required, emptyInputValidator()]],
            rememberMe: [false]
          });

     }
     errorMessage: string;




     onSubmit(): void {

        var errorSpan = document.getElementById('error-span');
        var validarusu = document.getElementById('validarusu');




        if(this.loginForm.get('usuario').value == '' )
            {
                validarusu.classList.remove('collapse');

            }
            else
            {
                validarusu.classList.add('collapse');

            }


        if(this.loginForm.get('usuario').value != '')
            {

            const errorSpan = document.getElementById('error-span');
        if (this.loginForm.valid) {
          const loginData: Login = this.loginForm.value;
          this.service.getcorreo(loginData).subscribe(
            response => {

                if (response.code == 200) {

                    this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    this.router.navigate(['/pages/compararcodigo']);
                } else {

                    errorSpan.classList.remove('collapse');

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

      }
}
