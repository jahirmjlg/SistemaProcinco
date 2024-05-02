import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListCursosimpartidosComponent } from './list-cursosimpartidos.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListCursosimpartidosComponent }
	])],
	exports: [RouterModule]
})
export class ListCursosImpartidosRoutingModule { }
