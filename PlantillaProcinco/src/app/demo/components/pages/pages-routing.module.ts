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

        { path: 'contenido', data: { breadcrumb: 'Contenido' }, loadChildren: () => import('../../../Contenido/list-contenido/list-contenido.module').then(m => m.ListContenidoModule) },

        { path: 'informesempleados', data: { breadcrumb: 'InformesEmpleados' }, loadChildren: () => import('../../../InformeEmpleados/list-informesempleados/list-informesempleados.module').then(m => m.ListInformesEmpleadosModule) },

        { path: 'titulos', data: { breadcrumb: 'Titulos' }, loadChildren: () => import('../../../Titulos/list-titulos/list-titulos.module').then(m => m.ListTitulosModule) },

        { path: 'cargos', data: { breadcrumb: 'Cargos' }, loadChildren: () => import('../../../Cargos/list-cargos/list.cargos.module').then(m => m.ListCargosModule) },
        
        { path: 'empleados', data: { breadcrumb: 'Empleados' }, loadChildren: () => import('../../../Empleados/list-empleados/list-empleados.module').then(m => m.ListEmpleadosModule) },
        
        { path: 'estadosciviles', data: { breadcrumb: 'EstadosCiviles' }, loadChildren: () => import('../../../EstadosCiviles/list-estadosciviles/list-estadosciviles.module').then(m => m.ListEstadosCivilesModule) },
        
        { path: 'roles', data: { breadcrumb: 'Roles' }, loadChildren: () => import('../../../Roles/list-roles/list-roles.module').then(m => m.ListRolesModule) },
        
        { path: 'usuarios', data: { breadcrumb: 'Usuarios' }, loadChildren: () => import('../../../Usuarios/list-usuarios/list-usuarios.module').then(m => m.ListUsuariosModule) },
        
        

        { path: '**', redirectTo: '/notfound' }
    ])],
    exports: [RouterModule]
})
export class PagesRoutingModule { }
