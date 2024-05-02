import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListTitulosComponent } from './list-titulos.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListTitulosComponent }
	])],
	exports: [RouterModule]
})
export class ListTitulosRoutingModule { }
