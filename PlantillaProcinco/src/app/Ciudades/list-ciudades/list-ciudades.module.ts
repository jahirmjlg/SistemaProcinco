import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListCiudadesComponent } from './list-ciudades.component';
import { ListCiudadesRoutingModule } from './list-ciudades-routing.module';

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
import { ListDemoRoutingModule } from 'src/app/demo/components/uikit/list/listdemo-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MessageService } from 'primeng/api';

@NgModule({
    imports: [
        CommonModule,
        TableModule,
        FileUploadModule,
        FormsModule,
        ListCiudadesRoutingModule,
        ReactiveFormsModule,
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
    declarations: [ListCiudadesComponent]
})
export class ListCiudadesModule { }
