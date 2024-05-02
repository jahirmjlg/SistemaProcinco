import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListInformesempleadosComponent } from './list-informesempleados.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListInformesempleadosComponent }
	])],
	exports: [RouterModule]
})
export class ListInformesEmpleadosRoutingModule { }
