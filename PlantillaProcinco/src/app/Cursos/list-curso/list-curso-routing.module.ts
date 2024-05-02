import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListCursoComponent } from './list-curso.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListCursoComponent }
	])],
	exports: [RouterModule]
})
export class ListCursoRoutingModule { }
