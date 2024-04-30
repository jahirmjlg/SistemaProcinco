using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.DataAccess.Repository
{
    class ScriptsDatabase
    {
        #region Pantallas 
        public static string PantallasListar = "";
        public static string PantallasBuscar = "[Acc].[SP_Pantallas_Seleccionar]";
        #endregion

        #region PantallasPorRoles
        public static string PantallasPorRolesListar = "";
        public static string PantallasPorRolesCrear = "[Acc].[SP_PantallasPorRoles_Insertar]";
        public static string PantallasPorRolesActualizar = "[Acc].[SP_PantallasPorRoles_Actualizar]";
        public static string PantallasPorRolesEliminar = "[Acc].[SP_PantallasPorRoles_Eliminar]";
        public static string PantallasPorRolesLlenarEditar = "[Acc].[SP_PantallasPorRoles_LlenarEditar]";
        public static string PantallasPorRolesBuscar = "[Acc].[SP_PantallasPorRoles_Seleccionar]";
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
        public static string UsuariosRestablecerContra = "[Acc].[SP_Usuarios_ReestablecerContraseña]";
        public static string UsuariosRestablecer = "[Acc].[SP_Usuarios_Reestablecer]";
        public static string UsuariosValidarInsertar = "[Acc].[SP_Usuarios_InsertarValidar]";
        public static string UsuariosObtenerCorreo= "[Acc].[SP_Usuarios_ObtenerCorreo]";
        public static string UsuariosIngresarCodigo = "";
        public static string UsuariosValidarCodigo = "";
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

    }
}
