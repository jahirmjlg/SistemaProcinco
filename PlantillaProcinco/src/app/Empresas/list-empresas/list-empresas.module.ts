import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListEmpresasComponent, } from './list-empresas.component';
import { ListEmpresasRoutingModule } from './list-empresas-routing.module';

import { TableModule } from 'primeng/table';
import { FileUploadModule } from 'primeng/fileupload';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { RatingModule } from 'primeng/rating';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputNumberModule } from 'primeng/inputnumber';
import { DialogModule } from 'primeng/dialog';


import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { DragDropModule } from '@angular/cdk/drag-drop';

import { MultiDragDropComponent } from '../MultiDrag/multi-drag-drop.component';



@NgModule({
    imports: [
        CommonModule,
        TableModule,
        FileUploadModule,
        FormsModule,
        ListEmpresasRoutingModule,
        ReactiveFormsModule,

        DragDropModule,

        ButtonModule,
        RippleModule,
        ToastModule,
        ToolbarModule,
        RatingModule,
        InputTextModule,
        InputTextareaModule,
        DropdownModule,
        RadioButtonModule,
        InputNumberModule,
        DialogModule
    ],
    declarations: [ListEmpresasComponent, MultiDragDropComponent],
    bootstrap:    [ ListEmpresasComponent ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class ListEmpresasModule { }
