import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListEstadoscivilesComponent } from './list-estadosciviles.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListEstadoscivilesComponent }
	])],
	exports: [RouterModule]
})
export class ListEstadosCivilesRoutingModule { }
