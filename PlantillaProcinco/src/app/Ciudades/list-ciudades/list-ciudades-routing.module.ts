import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListCiudadesComponent } from './list-ciudades.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListCiudadesComponent }
	])],
	exports: [RouterModule]
})
export class ListCiudadesRoutingModule { }
