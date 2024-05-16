import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ParticipantesPorCursoComponent } from './participantes-por-curso.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ParticipantesPorCursoComponent }
	])],
	exports: [RouterModule]
})
export class ParticipantesPorCursoRoutingModule { }
