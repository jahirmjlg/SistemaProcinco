import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReportesPorEmpleadoComponent } from './reportes-por-empleado.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ReportesPorEmpleadoComponent }
	])],
	exports: [RouterModule]
})
export class ReportesPorEmpleadoRoutingModule { }
