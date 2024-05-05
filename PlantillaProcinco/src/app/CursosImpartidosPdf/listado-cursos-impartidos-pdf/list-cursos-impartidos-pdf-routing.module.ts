import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListadoCursosImpartidosPdfComponent } from './listado-cursos-impartidos-pdf.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListadoCursosImpartidosPdfComponent }
	])],
	exports: [RouterModule]
})
export class ListCursosImpartidosPdfRoutingModule { }
