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

    { path: 'informesdeempleados', data: { breadcrumb: 'InformesEmpleados' }, loadChildren: () => import('../../../InformeEmpleados/list-informesempleados/list-informesempleados.module').then(m => m.ListInformesEmpleadosModule), canActivate: [AuthGuard] },

    { path: 'titulos', data: { breadcrumb: 'Titulos' }, loadChildren: () => import('../../../Titulos/list-titulos/list-titulos.module').then(m => m.ListTitulosModule), canActivate: [AuthGuard] },

    { path: 'cargos', data: { breadcrumb: 'Cargos' }, loadChildren: () => import('../../../Cargos/list-cargos/list.cargos.module').then(m => m.ListCargosModule), canActivate: [AuthGuard] },

    { path: 'empleados', data: { breadcrumb: 'Empleados' }, loadChildren: () => import('../../../Empleados/list-empleados/list-empleados.module').then(m => m.ListEmpleadosModule), canActivate: [AuthGuard] },

    { path: 'empresas', data: { breadcrumb: 'Empresas' }, loadChildren: () => import('../../../Empresas/list-empresas/list-empresas.module').then(m => m.ListEmpresasModule), canActivate: [AuthGuard] },

    { path: 'participantes', data: { breadcrumb: 'Participantes' }, loadChildren: () => import('../../../Participantes/list-participantes/list-participantes.module').then(m => m.ListParticipantesModule), canActivate: [AuthGuard] },



    { path: 'estadosciviles', data: { breadcrumb: 'EstadosCiviles' }, loadChildren: () => import('../../../EstadosCiviles/list-estadosciviles/list-estadosciviles.module').then(m => m.ListEstadosCivilesModule), canActivate: [AuthGuard] },

    { path: 'roles', data: { breadcrumb: 'Roles' }, loadChildren: () => import('../../../Roles/list-roles/list-roles.module').then(m => m.ListRolesModule), canActivate: [AuthGuard] },

    { path: 'usuarios', data: { breadcrumb: 'Usuarios' }, loadChildren: () => import('../../../Usuarios/list-usuarios/list-usuarios.module').then(m => m.ListUsuariosModule), canActivate: [AuthGuard] },

    { path: 'cursos', data: { breadcrumb: 'Cursos' }, loadChildren: () => import('../../../Cursos/list-curso/list-curso.module').then(m => m.ListCursoModule), canActivate: [AuthGuard] },

    { path: 'asignarcursos', data: { breadcrumb: 'AsignarCursos' }, loadChildren: () => import('../../../CursosImpartidos/list-cursosimpartidos/list-cursosimpartidos.module').then(m => m.ListCursosImpartidosModule), canActivate: [AuthGuard] },

    { path: 'categorias', data: { breadcrumb: 'Categorias' }, loadChildren: () => import('../../../Categorias/list-categoria/list-categoria.module').then(m => m.ListCategoriaModule), canActivate: [AuthGuard] },

    { path: 'drag', data: { breadcrumb: 'DragDrop' }, loadChildren: () => import('../../../CursosImpartidosPdf/listado-cursos-impartidos-pdf/list-mostrarDrop-routing.module').then(m => m.ListMostrarDropRoutingModule), canActivate: [AuthGuard] },

    { path: 'contenidoporcurso', data: { breadcrumb: 'ContenidoPorCurso' }, loadChildren: () => import('../../../ContenidoPorCurso/list-contenidoporcurso/list-contenidoporcursos.module').then(m => m.ListContenidoPorCursosModule), canActivate: [AuthGuard] },
    { path: 'treecontenidoporcurso', data: { breadcrumb: 'treeContenidoPorCurso' }, loadChildren: () => import('../../../ContenidoPorCursoT/tree-contenidoPorCurso.module').then(m => m.TreeContenidoPorCursoModule), canActivate: [AuthGuard] },
    { path: 'reporteporempleado', data: { breadcrumb: 'ReportePorEmpleado' }, loadChildren: () => import('../../../Reportes/reportes-por-empleado/reportes-por-empleado.module').then(m => m.ReportesPorEmpleadoModule), canActivate: [AuthGuard] },

    { path: 'participantesporcurso', data: { breadcrumb: 'ParticipantesPorCurso' }, loadChildren: () => import('../../../Reportes/participantes-por-curso/participantes-por-curso.module').then(m => m.ParticipantesPorCursoModule), canActivate: [AuthGuard] },



    { path: 'reportecursosimp', data: { breadcrumb: 'ReporteCursosImp' }, loadChildren: () => import('../../../Reportes/list-reportes-cursos-impartidos/reportes-cursos-impartidos.module').then(m => m.ReportesCursosImpartidosModule) },
    { path: 'reportecursosporcategoria', data: { breadcrumb: 'ReporteCursosCategoria' }, loadChildren: () => import('../../../Reportes/list-reportes-cursos-porcategoria/reportes-cursos-porcategoria.module').then(m => m.ReportesCursosPorCategoriaModule) },



    { path: '**', redirectTo: '/notfound' }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PagesRoutingModule { }

