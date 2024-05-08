import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListContenidoporcursoComponent } from './list-contenidoporcurso.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListContenidoporcursoComponent }
	])],
	exports: [RouterModule]
})
export class ListContenidoPorCursosRoutingModule { }
