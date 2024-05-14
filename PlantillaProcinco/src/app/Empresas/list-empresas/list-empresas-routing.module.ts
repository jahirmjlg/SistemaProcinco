import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListEmpresasComponent } from './list-empresas.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListEmpresasComponent }
	])],
	exports: [RouterModule]
})
export class ListEmpresasRoutingModule { }
