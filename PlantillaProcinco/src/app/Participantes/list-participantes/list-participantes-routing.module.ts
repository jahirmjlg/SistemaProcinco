import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ListParticipantesComponent } from './list-participantes.component';

@NgModule({
	imports: [RouterModule.forChild([
		{ path: '', component: ListParticipantesComponent }
	])],
	exports: [RouterModule]
})
export class ListParticipantesRoutingModule { }
