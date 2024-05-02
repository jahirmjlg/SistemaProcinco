import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CreateEstadosComponent } from './create-estados.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: CreateEstadosComponent }
	])],
	exports: [RouterModule]
})
export class CreateEstadosRoutingModule { }
