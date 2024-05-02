import { Component } from '@angular/core';
import { LayoutService } from 'src/app/layout/service/app.layout.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../../../../Services/service.service';
import { Login } from '../../../../Models/loginViewModel';
import { emptyInputValidator } from './CustomValidatorss';

import { Router } from '@angular/router';

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

    constructor(public layoutService: LayoutService, private formBuilder: FormBuilder, private service: ServiceService, private router:Router) {

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

        const usuario = document.getElementById('usuaa');
        const contra = document.getElementById('contraa');



        if(usuario == null && contra == null )
            {
                validarusu.classList.remove('collapse');
                validarcontra.classList.remove('collapse');

            }
            else if(usuario == null )
                {
                    validarusu.classList.remove('collapse');

                }
            else if(contra == null )
                {
                    validarcontra.classList.remove('collapse');

                }
        else
        {

            const errorSpan = document.getElementById('error-span');
        if (this.loginForm.valid) {
          const loginData: Login = this.loginForm.value;
          this.service.login(loginData).subscribe(
            response => {

                if (response.code == 200) {

                    this.router.navigate(['/dash']);
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
