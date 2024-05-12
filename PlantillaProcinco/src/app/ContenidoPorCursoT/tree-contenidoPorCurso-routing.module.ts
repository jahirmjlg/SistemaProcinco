import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { treeContendioPorCursoComponent } from './tree-contenidoPorCurso.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: treeContendioPorCursoComponent }
	])],
	exports: [RouterModule]
})
export class TreeContenidoPorCursoRoutingModule { }
