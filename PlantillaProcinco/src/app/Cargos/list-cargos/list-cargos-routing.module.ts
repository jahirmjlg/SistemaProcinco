import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListCargosComponent } from './list-cargos.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListCargosComponent }
	])],
	exports: [RouterModule]
})
export class ListCargosRoutingModule { }
