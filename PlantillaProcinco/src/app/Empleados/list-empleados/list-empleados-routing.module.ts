import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListEmpleadosComponent } from './list-empleados.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListEmpleadosComponent }
	])],
	exports: [RouterModule]
})
export class ListEmpleadosRoutingModule { }
