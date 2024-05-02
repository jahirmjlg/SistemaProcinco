import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ListComponent} from './Categorias/list/list.component';
import { ListEstadosComponent } from './Estados/list-estados/list-estados.component';

const routes: Routes = [{path: 'index', component: ListComponent},
                        {path: 'indexEstados', component: ListEstadosComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
