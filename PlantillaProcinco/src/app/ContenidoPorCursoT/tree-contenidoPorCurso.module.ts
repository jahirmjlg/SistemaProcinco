import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { treeContendioPorCursoComponent } from './tree-contenidoPorCurso.component';
import { TreeContenidoPorCursoRoutingModule } from './tree-contenidoPorCurso-routing.module';
import { TreeModule } from 'primeng/tree';
import { TreeTableModule } from 'primeng/treetable';
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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListDemoRoutingModule } from 'src/app/demo/components/uikit/list/listdemo-routing.module';


@NgModule({
	imports: [
		CommonModule,
		TreeContenidoPorCursoRoutingModule,
		FormsModule,
        ReactiveFormsModule,
		TreeModule,
		TreeTableModule,
		TableModule,
        FileUploadModule,
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
	declarations: [treeContendioPorCursoComponent],
})
export class TreeContenidoPorCursoModule { }
