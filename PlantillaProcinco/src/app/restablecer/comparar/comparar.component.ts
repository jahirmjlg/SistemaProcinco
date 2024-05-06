import { Component } from '@angular/core';
import { LayoutService } from 'src/app/layout/service/app.layout.service';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompararService } from 'src/app/Services/comparar.service'; 
import { Codigo } from 'src/app/Models/loginViewModel'; 
import { emptyInputValidator } from 'src/app/demo/components/auth/login/CustomValidatorss'; 

import { Router } from '@angular/router';

import { CookieService } from 'ngx-cookie-service';
@Component({
  selector: 'app-comparar',
  templateUrl: './comparar.component.html',
  styleUrl: './comparar.component.scss'
})
export class CompararComponent {

    // valCheck: string[] = ['remember'];

    // password!: string;

    compararForm: FormGroup;

    constructor(public layoutService: LayoutService, private formBuilder: FormBuilder, private compararservice: CompararService, private router:Router, private cookieService: CookieService) {

        this.compararForm = this.formBuilder.group({
            codigo: ['', [Validators.required, emptyInputValidator()]],
          });

     }
     errorMessage: string;




     onSubmit(): void {

        var errorSpan = document.getElementById('error-span');
        var validarcodi = document.getElementById('validarcodi');




        if(this.compararForm.get('codigo').value == '' )
            {
              validarcodi.classList.remove('collapse');

            }
            else
            {
              validarcodi.classList.add('collapse');

            }


        if(this.compararForm.get('codigo').value != '')
            {
            const errorSpan = document.getElementById('error-span');
        if (this.compararForm.valid) {
          const codigoData: Codigo = this.compararForm.value;
          this.compararservice.getcodigo(codigoData).subscribe(
            response => {

                if (response.code == 200) {

                    console.log(response)
                    this.router.navigate(['/pages/restablecer']);
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
