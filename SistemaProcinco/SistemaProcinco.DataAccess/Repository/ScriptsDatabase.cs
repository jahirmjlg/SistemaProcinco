﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.DataAccess.Repository
{
    class ScriptsDatabase

    {

        #region Participantes
        public static string ParticipanteListar = "[Grl].[SP_Participantes_Seleccionar]";
        public static string ParticipanteInsertar = "[Grl].[SP_Participantes_Insertar]";
        public static string ParticipanteActualizar = "[Grl].[SP_Participantes_Actualizar]";
        public static string ParticipanteLlenar = "[Grl].[SP_Participantes_LlenarEditar]";
        public static string ParticipanteEliminar = "[Grl].[SP_Participantes_Eliminar]";

        #endregion


        #region Empresas
        public static string EmpresaListar = "Grl.[SP_Empresas_Seleccionar]";

        public static string EmpresaInsertar = "[Grl].[SP_Empresas_Insertar]";
        public static string EmpresaActualizar = "[Grl].[SP_Empresas_Actualizar]";
        public static string EmpresaLlenar = "[Grl].[SP_Empresas_LlenarEditar]";
        public static string EmpresaEliminar = "[Grl].[SP_Empresas_Eliminar]";


        #endregion

        #region Pantallas 
        public static string PantallasFiltrar = "[Acc].[SP_Pantallas_Listado]";

        public static string PantallasListar = "[Acc].[SP_Pantallas_Seleccionar]";
        public static string PantallasCrear = "[Acc].[SP_Pantallas_Insertar]";
        public static string PantallasEliminar = "[Acc].[SP_Pantallas_Eliminar]";
        public static string PantallasActualizar = "[Acc].[SP_Pantallas_Actualizar]";
        public static string PantallasBuscar = "[Acc].[SP_Pantallas_LlenarEditar]";

        public static string PantallasRolFiltro = "[Acc].[SP_Pantallas_Filtrado]";

        #endregion

        #region PantallasPorRoles
        public static string PantallasPorRolesListar = "[Acc].[SP_PantallasPorRoles_Mostrar]";
        public static string PantallasPorRolesCrear = "[Acc].[SP_PantallasPorRoles_Insertar]";
        public static string PantallasPorRolesActualizar = "[Acc].[SP_PantallasPorRoles_Actualizar]";
        public static string PantallasPorRolesEliminar = "[Acc].[SP_PantallasPorRoles_Eliminar]";
        public static string PantallasPorRolesLlenarEditar = "[Acc].[SP_PantallasPorRoles_LlenarEditar]";
        public static string PantallasPorRolesBuscar = "[Acc].[SP_PantallasPorRoles_LlenarEditar]";

        public static string PantallasPorRoll = "[Acc].[SP_PantallasPorRoles_Seleccionar]";

        #endregion

        #region Roles
        public static string RolesCrear = "[Acc].[SP_Roles_Insertar]";
        public static string RolesActualizar = "[Acc].[SP_Roles_Actualizar]";
        public static string RolesEliminar = "[Acc].[SP_Roles_Eliminar]";
        public static string RolesListar = "[Acc].[SP_Roles_Seleccionar]";
        public static string RolesLlenar = "[Acc].[SP_Roles_LLenar]";
        public static string RolesLlenarEditar = "[Acc].[SP_Roles_LlenarEditar]";
        public static string RolesBuscar = "";
        #endregion

        #region Usuarios
        public static string UsuariosListar = "[Acc].[SP_Usuarios_Seleccionar] ";
        public static string UsuariosCrear = "[Acc].[SP_Usuarios_Insertar]";
        public static string UsuariosActualizar = "[Acc].[SP_Usuarios_Actualizar]";
        public static string UsuariosEliminar = "[Acc].[SP_Usuarios_Eliminar]";
        public static string UsuariosDetalle = "[Acc].[SP_Usuarios_Detalles]";
        public static string UsuariosInicioSesion = "[Acc].[SP_UsuariosValidarInicioSesion]";
        public static string UsuariosLlenarEditar = "[Acc].[SP_Usuarios_LlenarEditar]";
        public static string UsuariosRestablecerContra = "[Acc].[SP_Usuarios_Reestablecer]";
        public static string UsuariosValidarInsertar = "[Acc].[SP_Usuarios_InsertarValidar]";
        public static string UsuariosEnviarCodigo = "[Acc].[SP_Usuarios_EnviarCorreo]";
        public static string UsuariosIngresarCodigo = "[Acc].[sp_Usuarios_IngresarCodigo]";
        public static string UsuariosValidarCodigo = "[Acc].[SP_Usuarios_ValidarCodigo]";
        #endregion

        #region Ciudades 
        public static string CiudadesListar = "[Grl].[SP_Ciudades_Seleccionar]";
        public static string CiudadesCrear = "[Grl].[SP_Ciudades_Insertar]";
        public static string CiudadesActualizar = "[Grl].[SP_Ciudades_Actualizar]";
        public static string CiudadesEliminar = "[Grl].[SP_Ciudades_Eliminar]";
        public static string CiudadesLlenarEditar = "[Grl].[SP_Ciudades_LlenarEditar]";
        public static string CiudadesPorEstados = "[Grl].[SP_CiudadesPorEstados]";
        public static string CiudadesPorEstadosSeleccionar = "[Grl].[SP_CiudadesPorEstados_Seleccionar]";
        #endregion

        #region Empleados
        public static string EmpleadosListar = "[Grl].[SP_Empleados_Seleccionar]";
        public static string EmpleadosLlenarEditar = "[Grl].[SP_Empleados_LlenarEditar]";
        public static string EmpleadosCrear = "[Grl].[SP_Empleados_Insertar]";
        public static string EmpleadosActualizar = "[Grl].[SP_Empleados_Actualizar]";
        public static string EmpleadosEliminar = "[Grl].[SP_Empleados_Eliminar]";
        #endregion


        #region Estados
        public static string EstadosListar = "[Grl].[SP_Estados_Seleccionar]";
        public static string EstadosCrear = "[Grl].[SP_Estados_Insertar]";
        public static string EstadosActualizar = "[Grl].[SP_Estados_Actualizar]";
        public static string EstadosEliminar = "[Grl].[SP_Estados_Eliminar]";
        public static string EstadosBuscar = "[Grl].[SP_Estados_LlenarEditar]";
        #endregion

        #region EstadosCiviles
        public static string EstadosCivilesListar = "[Grl].[SP_EstadosCiviles_Seleccionar]";
        public static string EstadosCivilesCrear = "[Grl].[SP_EstadosCiviles_Insertar]";
        public static string EstadosCivilesActualizar = "[Grl].[SP_EstadosCiviles_Actualizar]";
        public static string EstadosCivilesEliminar = "[Grl].[SP_EstadosCiviles_Eliminar]";
        public static string EstadosCivilesBuscar = "[Grl].[SP_EstadosCiviles_LlenarEditar]";
        #endregion

        #region Cargos
        public static string CargosListar = "[Pro].[SP_Cargos_Seleccionar]";
        public static string CargosCrear = "[Pro].[SP_Cargos_Insertar]";
        public static string CargosActualizar = "[Pro].[SP_Cargos_Actualizar]";
        public static string CargosEliminar = "[Pro].[SP_Cargos_Eliminar]";
        public static string CargosBuscar = "[Pro].[SP_Cargos_LlenarEditar]";
        #endregion

        #region Categorias
        public static string CategoriasListar = "[Pro].[SP_Categoria_Seleccionar]";
        public static string CategoriasCrear = "[Pro].[SP_Categoria_Insertar]";
        public static string CategoriasActualizar = "[Pro].[SP_Categoria_Actualizar]";
        public static string CategoriasEliminar = "[Pro].[SP_Categoria_Eliminar]";
        public static string CategoriasBuscar = "[Pro].[SP_Categoria_Buscar]";
        #endregion
        #region Contenido
        public static string ContenidoPorCategoriaBuscar = "[Pro].[SP_ContenidoPorCategoria_Seleccionar]";
        public static string ContenidoListar = "[Pro].[SP_Contenido_Seleccionar]";
        public static string ContenidoCrear = "[Pro].[SP_Contenido_Insertar]";
        public static string ContenidoActualizar = "[Pro].[SP_Contenido_Actualizar]";
        public static string ContenidoEliminar = "[Pro].[SP_Contenido_Eliminar]";
        public static string ContenidoBuscar = "[Pro].[SP_Contenido_Buscar]";
        #endregion

        #region Contenido por curso
        public static string ContenidoPorCursoListar = "[Pro].[SP_ContenidoPorCurso_Seleccionar]";
        public static string ContenidoPorCursoCrear = "[Pro].[SP_ContenidoPorCurso_Insertar]";
        public static string ContenidoPorCursoActualizar = "[Pro].[SP_ContenidoPorCurso_Actualizar]";
        public static string ContenidoPorCursoEliminar = "[Pro].[SP_ContenidoPorCurso_Eliminar]";
        public static string ContenidoPorCursoEliminarEliminado = "[Pro].[SP_ContenidoPorCursoEliminado_Eliminar]";

        public static string ContenidoPorCursoBuscar = "[Pro].[SP_ContenidoPorCurso_Buscar]";
        public static string CPCCursoBuscar = "[Pro].[SP_ContenidoPorCurso_BuscarCurso]";
        public static string CPCContenidosBuscar = "[Pro].[SP_ContenidoPorCurso_BuscarContenido]";

        #endregion

        #region Cursos
        public static string CursosCrearId = "[Pro].[SP_CursoId_Insertar]";
        public static string CursosListar = "[Pro].[SP_Curso_Seleccionar]";
        public static string CursosCrear = "[Pro].[SP_Curso_Insertar]";
        public static string CursosActualizar = "[Pro].[SP_Curso_Actualizar]";
        public static string CursosEliminar = "[Pro].[SP_Curso_Eliminar]";
        public static string CursosPorCategoriaBuscar = "Pro.SP_CursosPorCategoria_Seleccionar";
        public static string CursosBuscar = "[Pro].[SP_Curso_Buscar]";
        #endregion

        #region CursosImpartidos
        public static string CursosImpartidosListar = "[Pro].[SP_CursosImpartidos_Seleccionar]";
        public static string CursosImpartidosCrear = "[Pro].[SP_CursoImpartido_Insertar]";
        public static string CursosImpartidosActualizar = "[Pro].[SP_CursoImpartido_Actualizar]";
        public static string CursosImpartidosEliminar = "[Pro].[SP_CursoImpartido_Eliminar]";
        public static string CursosImpartidosBuscar = "[Pro].[SP_CursosImpartidos_Buscar]";

        public static string CursosImpartidosFinalizar = "[Pro].[SP_CursoImpartido_Finalizar]";
        public static string CursosImpartidosBuscarFactura = "[Pro].[SP_CursosImpartidos_Buscar1]";

        public static string CursosImpartidosParticipantes = "[Pro].[SP_CursosImpartidos_Participantes]";


        public static string CursosImpartidosBuscarEmpleado = "[Pro].[SP_CursosImpartidos_BuscarEmpleado]";
        public static string CursosImpartidosBuscarCurso = "[Pro].[SP_CursosImpartidos_BuscarCurso]";


        public static string CursosImpartidosMES = "[Pro].[ObtenerCursosPorMes]";


        public static string CursosImpartidosEntreMeses = "[Pro].[SP_CursosImpartidos_EntreFechas]";
        public static string CursosImpartidosEntreFechas = "Pro.SP_CursosImpartidosPorCategoria_EntreFechas";


        public static string CursosImpartidosFiltroEmpleados = "[Pro].[SP_CursosImpartidos_FiltroEmpleados]";

        public static string ParticipantesFiltro = "[Grl].[SP_Participantes_FiltroCursos]";
        public static string FechasPorCursoDDL = "[Grl].[SP_FechasPorCurso]";


        public static string CursosImpartidosTop5Mes = "Pro.SP_CursosImpartidos_Top5";
        public static string CursosImpartidosTop5PorMeses = "Pro.SP_CursosImpartidos_Top5_MES";

        public static string CursosImpartidosCategorias = "Pro.SP_CursosImpartidos_Categorias";
        public static string CursosImpartidosCategoriasMES = "Pro.SP_CursosImpartidos_Categorias_MES";

        public static string EmpleadosMejorPagados = "Pro.SP_Empleados_MejorPagados";
        public static string EmpleadosMejorPagadosFiltro = "Pro.SP_Empleados_MejorPagadosFiltro";

        public static string HorasImpartidasPorCategoria = "Pro.SP_HorasImpartidasPorCategoria";
        public static string HorasImpartidasPorCategoriaFiltrado = "Pro.SP_HorasImpartidasPorCategoriaFiltrado";



        #endregion

        #region Informe Empleados
        public static string InformeEmpleadosListar = "[Pro].[SP_InformeEmpleados_Seleccionar]";
        public static string InformeEmpleadosCrear = "[Pro].[SP_InformeEmpleado_Insertar]";
        public static string InformeEmpleadosActualizar = "[Pro].[SP_InformeEmpleado_Actualizar]";
        public static string InformeEmpleadosEliminar = "[Pro].[SP_InformeEmpleado_Eliminar]";
        public static string InformeEmpleadosBuscar = "[Pro].[SP_InformeEmpleados_Buscar]";
        #endregion

        #region Titulos
        public static string TitulosListar = "[Pro].[SP_Titulos_Seleccionar]";
        public static string TitulosCrear = "[Pro].[SP_Titulo_Insertar]";
        public static string TitulosActualizar = "[Pro].[SP_Titulo_Actualizar]";
        public static string TitulosEliminar = "[Pro].[SP_Titulo_Eliminar]";
        public static string TitulosBuscar = "[Pro].[SP_Titulos_Buscar]";
        #endregion

        #region Titulos Por Empleados
        public static string TitulosPorEmpleadosListar = "[Pro].[SP_Titulos_Seleccionar]";
        public static string TitulosPorEmpleadosCrear = "[Pro].[SP_TituloPorEmpleado_Insertar]";
        public static string TitulosPorEmpleadosActualizar = "[Pro].[SP_TituloPorEmpleado_Actualizar]";
        public static string TitulosPorEmpleadosBuscar = "[Pro].[SP_TitulosPorEmpleado_Buscar]";
        public static string TitulosPorEmpleadosEliminarrr = "[Pro].[SP_TituloPorEmpleadoo_Eliminar]";

        #endregion




        #region titulospor empleado
        public static string TitulosPorEmpleadosListadoFiltrado = "[Pro].[SP_Titulos_Filtrado]";
        public static string TitulosPorEmpleadosEliminar = "[Pro].[SP_TituloPorEmpleadoo_Eliminar]";


        public static string TitulosPorEmpleadosFiltrado1 = "[Pro].[SP_Titulos_Filtrar1]";

        #endregion







        #region titulosPorEmpleado
        public static string titulosSeleccionar = "[Pro].[SP_Titulos_Seleccionar]";
        public static string titulosFiltrar = "[Pro].[SP_Titulos_Filtrar1]";


        public static string titulosporempleadoFiltro = "[Pro].[SP_Titulos_Filtrado]";
        public static string titulosPorEmpleadoEliminar = "[Pro].[SP_TituloPorEmpleadoo_Eliminar]";
        public static string empeladosActualizar = "[Grl].[SP_Empleados_Actualizar]";
        public static string empleadosLlenasEditar = "[Grl].[SP_Empleados_LlenarEditar1]";
        public static string empleadosEliminar = "[Grl].[SP_Empleados_Eliminar]";


        #endregion



        #region participantesporcurso
        public static string participantePorCursoImpartidoBuscar = "[Pro].[SP_ParticipantesPorCursoImpartido_Buscar]";

        public static string participantePorCursoBuscar = "[Pro].[SP_ParticipantesPorCurso_Buscar]";
        public static string participantePorCursoActualizado = "Pro.ParticipantesPorCurso_Actualizar";
        public static string participantePorCursoEliminado = "[Pro].[SP_ParticipantesPorCursoEliminado_Eliminar]";




        #endregion










    }
}
