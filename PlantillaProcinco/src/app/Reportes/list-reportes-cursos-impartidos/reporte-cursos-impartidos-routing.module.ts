import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReportesCursosImpartidosComponent } from './reportes-cursos-impartidos.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ReportesCursosImpartidosComponent }
	])],
	exports: [RouterModule]
})
export class ReportesCursosImpartidosRoutingModule { }
