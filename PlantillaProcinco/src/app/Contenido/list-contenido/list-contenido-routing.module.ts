import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListContenidoComponent } from './list-contenido.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListContenidoComponent }
	])],
	exports: [RouterModule]
})
export class ListContenidoRoutingModule { }
