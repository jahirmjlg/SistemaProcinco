import { NgModule } from '@angular/core';
import { RouterModule,Routes } from '@angular/router';
import { AuthGuard } from 'src/app/auth.guard';


const routes: Routes = [
    { path: 'crud', loadChildren: () => import('./crud/crud.module').then(m => m.CrudModule), canActivate: [AuthGuard] },

    { path: 'empty', loadChildren: () => import('./empty/emptydemo.module').then(m => m.EmptyDemoModule), canActivate: [AuthGuard] },

    { path: 'timeline', loadChildren: () => import('./timeline/timelinedemo.module').then(m => m.TimelineDemoModule), canActivate: [AuthGuard] },

    { path: 'estados', data: { breadcrumb: 'Estados' }, loadChildren: () => import('../../../Estados/list-estados/list-estados.module').then(m => m.ListEstadosModule), canActivate: [AuthGuard] },

    { path: 'ciudades', data: { breadcrumb: 'Ciudades' }, loadChildren: () => import('../../../Ciudades/list-ciudades/list-ciudades.module').then(m => m.ListCiudadesModule), canActivate: [AuthGuard] },

    { path: 'contenido', data: { breadcrumb: 'Contenido' }, loadChildren: () => import('../../../Contenido/list-contenido/list-contenido.module').then(m => m.ListContenidoModule), canActivate: [AuthGuard] },

    { path: 'informesempleados', data: { breadcrumb: 'InformesEmpleados' }, loadChildren: () => import('../../../InformeEmpleados/list-informesempleados/list-informesempleados.module').then(m => m.ListInformesEmpleadosModule), canActivate: [AuthGuard] },

    { path: 'titulos', data: { breadcrumb: 'Titulos' }, loadChildren: () => import('../../../Titulos/list-titulos/list-titulos.module').then(m => m.ListTitulosModule), canActivate: [AuthGuard] },

    { path: 'cargos', data: { breadcrumb: 'Cargos' }, loadChildren: () => import('../../../Cargos/list-cargos/list.cargos.module').then(m => m.ListCargosModule), canActivate: [AuthGuard] },

    { path: 'empleados', data: { breadcrumb: 'Empleados' }, loadChildren: () => import('../../../Empleados/list-empleados/list-empleados.module').then(m => m.ListEmpleadosModule), canActivate: [AuthGuard] },

    { path: 'estadosciviles', data: { breadcrumb: 'EstadosCiviles' }, loadChildren: () => import('../../../EstadosCiviles/list-estadosciviles/list-estadosciviles.module').then(m => m.ListEstadosCivilesModule), canActivate: [AuthGuard] },

    { path: 'roles', data: { breadcrumb: 'Roles' }, loadChildren: () => import('../../../Roles/list-roles/list-roles.module').then(m => m.ListRolesModule), canActivate: [AuthGuard] },

    { path: 'usuarios', data: { breadcrumb: 'Usuarios' }, loadChildren: () => import('../../../Usuarios/list-usuarios/list-usuarios.module').then(m => m.ListUsuariosModule), canActivate: [AuthGuard] },

    { path: 'cursos', data: { breadcrumb: 'Cursos' }, loadChildren: () => import('../../../Cursos/list-curso/list-curso.module').then(m => m.ListCursoModule), canActivate: [AuthGuard] },

    { path: 'cursosimp', data: { breadcrumb: 'CursosImpartidos' }, loadChildren: () => import('../../../CursosImpartidos/list-cursosimpartidos/list-cursosimpartidos.module').then(m => m.ListCursosImpartidosModule), canActivate: [AuthGuard] },

    { path: 'enviarcodigo', data: { breadcrumb: 'EnviarCodigo' }, loadChildren: () => import('../../../restablecer/validacion/validacion.module').then(m => m.ValidacionModule), canActivate: [AuthGuard] },

    { path: 'compararcodigo', data: { breadcrumb: 'CompararCodigo' }, loadChildren: () => import('../../../restablecer/comparar/comparar.module').then(m => m.CompararModule), canActivate: [AuthGuard] },

    { path: 'restablecer', data: { breadcrumb: 'Restablecer' }, loadChildren: () => import('../../../restablecer/restablecer/restablecer.module').then(m => m.restablecerModule), canActivate: [AuthGuard] },

    { path: 'categorias', data: { breadcrumb: 'Categorias' }, loadChildren: () => import('../../../Categorias/list-categoria/list-categoria.module').then(m => m.ListCategoriaModule), canActivate: [AuthGuard] },

    { path: 'drag', data: { breadcrumb: 'DragDrop' }, loadChildren: () => import('../../../CursosImpartidosPdf/listado-cursos-impartidos-pdf/list-mostrarDrop-routing.module').then(m => m.ListMostrarDropRoutingModule), canActivate: [AuthGuard] },

    { path: 'contenidoporcurso', data: { breadcrumb: 'ContenidoPorCurso' }, loadChildren: () => import('../../../ContenidoPorCurso/list-contenidoporcurso/list-contenidoporcursos.module').then(m => m.ListContenidoPorCursosModule), canActivate: [AuthGuard] },
    { path: 'treecontenidoporcurso', data: { breadcrumb: 'treeContenidoPorCurso' }, loadChildren: () => import('../../../ContenidoPorCursoT/tree-contenidoPorCurso.module').then(m => m.TreeContenidoPorCursoModule), canActivate: [AuthGuard] },

    { path: '**', redirectTo: '/notfound' }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PagesRoutingModule { }

