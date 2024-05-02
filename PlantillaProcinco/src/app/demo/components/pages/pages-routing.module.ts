import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [RouterModule.forChild([
        { path: 'crud', loadChildren: () => import('./crud/crud.module').then(m => m.CrudModule) },
        { path: 'empty', loadChildren: () => import('./empty/emptydemo.module').then(m => m.EmptyDemoModule) },
        { path: 'timeline', loadChildren: () => import('./timeline/timelinedemo.module').then(m => m.TimelineDemoModule) },

        //
        { path: 'estados', data: { breadcrumb: 'Estados' }, loadChildren: () => import('../../../Estados/list-estados/list-estados.module').then(m => m.ListEstadosModule) },

        { path: 'ciudades', data: { breadcrumb: 'Ciudades' }, loadChildren: () => import('../../../Ciudades/list-ciudades/list-ciudades.module').then(m => m.ListCiudadesModule) },




        { path: '**', redirectTo: '/notfound' }
    ])],
    exports: [RouterModule]
})
export class PagesRoutingModule { }
