import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { validacionRoutingModule } from './validacion-routing.module';
import { ValidacionComponent } from './validacion.component'; 
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PasswordModule } from 'primeng/password';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
    imports: [
        CommonModule,
        validacionRoutingModule,
        ReactiveFormsModule,
        ButtonModule,
        CheckboxModule,
        InputTextModule,
        FormsModule,
        PasswordModule
    ],
    declarations: [ValidacionComponent]
})
export class ValidacionModule { }
