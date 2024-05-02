import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListCategoriaComponent } from './list-categoria.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListCategoriaComponent }
	])],
	exports: [RouterModule]
})
export class ListCategoriaRoutingModule { }
