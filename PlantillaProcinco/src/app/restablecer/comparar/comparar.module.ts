import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompararRoutingModule } from './comparar-routing.module';
import { CompararComponent } from './comparar.component'; 
import { ButtonModule } from 'primeng/button';
import { CheckboxModule } from 'primeng/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PasswordModule } from 'primeng/password';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
    imports: [
        CommonModule,
        CompararRoutingModule,
        ReactiveFormsModule,
        ButtonModule,
        CheckboxModule,
        InputTextModule,
        FormsModule,
        PasswordModule
    ],
    declarations: [CompararComponent]
})
export class CompararModule { }
