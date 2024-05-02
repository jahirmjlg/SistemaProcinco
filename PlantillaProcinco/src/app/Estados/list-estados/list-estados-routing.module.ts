import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListEstadosComponent } from './list-estados.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListEstadosComponent }
	])],
	exports: [RouterModule]
})
export class ListEstadosRoutingModule { }
