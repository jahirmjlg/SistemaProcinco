import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListUsuariosComponent } from './list-usuarios.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListUsuariosComponent }
	])],
	exports: [RouterModule]
})
export class ListUsuariosRoutingModule { }
