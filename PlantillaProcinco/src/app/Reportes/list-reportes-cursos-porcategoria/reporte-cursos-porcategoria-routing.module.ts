import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReportesCursosPorCategoriaComponent } from './reportes-cursos-porcategoria.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ReportesCursosPorCategoriaComponent }
	])],
	exports: [RouterModule]
})
export class ReportesCursosImpartidosRoutingModule { }
