import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListMostrarDropComponent } from './list-mostrarDrop.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListMostrarDropComponent }
	])],
	exports: [RouterModule]
})
export class ListMostrarDropRoutingModule { }
