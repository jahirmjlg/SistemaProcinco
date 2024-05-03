import { Component } from '@angular/core';
import { LayoutService } from 'src/app/layout/service/app.layout.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../../../../Services/service.service';
import { Login } from '../../../../Models/loginViewModel';
import { emptyInputValidator } from './CustomValidatorss';

import { Router } from '@angular/router';

import { CookieService } from 'ngx-cookie-service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    // styles: [`
    //     :host ::ng-deep .pi-eye,
    //     :host ::ng-deep .pi-eye-slash {
    //         transform:scale(1.6);
    //         margin-right: 1rem;
    //         color: var(--primary-color) !important;
    //     }
    // `],
    styleUrls: ['./login.scss']

})
export class LoginComponent {

    // valCheck: string[] = ['remember'];

    // password!: string;

    loginForm: FormGroup;

    constructor(public layoutService: LayoutService, private formBuilder: FormBuilder, private service: ServiceService, private router:Router, private cookieService: CookieService) {

        this.loginForm = this.formBuilder.group({
            usuario: ['', [Validators.required, emptyInputValidator()]],
            contra: ['', [Validators.required, emptyInputValidator()]],
            rememberMe: [false]
          });

     }
     errorMessage: string;




     onSubmit(): void {

        var errorSpan = document.getElementById('error-span');
        var validarusu = document.getElementById('validarusu');
        var validarcontra = document.getElementById('validarcontra');




        if(this.loginForm.get('usuario').value == '' )
            {
                validarusu.classList.remove('collapse');

            }
            else
            {
                validarusu.classList.add('collapse');

            }

            if(this.loginForm.get('contra').value == '' )
                {
                    validarcontra.classList.remove('collapse');

                }
                else
                {
                    validarcontra.classList.add('collapse');

                }


        if(this.loginForm.get('usuario').value != '' && this.loginForm.get('contra').value != '' )
            {

            const errorSpan = document.getElementById('error-span');
        if (this.loginForm.valid) {
          const loginData: Login = this.loginForm.value;
          this.service.login(loginData).subscribe(
            response => {

                if (response.code == 200) {

                    this.cookieService.set('namee', response.data.empl_Nombre);

                    console.log(response)
                    this.router.navigate(['/pages/empty']);
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
