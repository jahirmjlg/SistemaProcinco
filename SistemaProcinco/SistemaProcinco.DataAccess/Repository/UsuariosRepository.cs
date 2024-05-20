using Dapper;
using Microsoft.Data.SqlClient;
using SistemaProcinco.DataAcces.Repository;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.DataAccess.Repository
{
    public class UsuariosRepository : IRepository<tbUsuarios>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.UsuariosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Usua_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbUsuarios> Find(int? id)
        {
            string sql = ScriptsDatabase.UsuariosDetalle;
            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Usua_Id", id);
                result = db.Query<tbUsuarios>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();

                return result;

            }
        }

        public RequestStatus Insert(tbUsuarios item)
        {
            string sql = ScriptsDatabase.UsuariosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Usua_Usuario", item.Usua_Usuario);
                parametro.Add("@Usua_Contraseña", item.Usua_Contraseña);
                parametro.Add("@Usua_EsAdmin", item.Usua_EsAdmin);
                parametro.Add("@Empl_Id", item.Empl_Id);
                parametro.Add("@Role_Id", item.Role_Id);
                parametro.Add("@Usua_UsuarioCreacion", item.Usua_UsuarioCreacion);
                parametro.Add("@Usua_FechaCreacion", item.Usua_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = ""};

            }
        }

        public IEnumerable<tbUsuarios> List()
        {
            string sql = ScriptsDatabase.UsuariosListar;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbUsuarios>(sql, commandType: CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbUsuarios item)
        {
            string sql = ScriptsDatabase.UsuariosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Usua_Id", item.Usua_Id);
                parametro.Add("@Usua_Usuario", item.Usua_Usuario);
                parametro.Add("@Usua_EsAdmin", item.Usua_EsAdmin);
                parametro.Add("@Empl_Id", item.Empl_Id);
                parametro.Add("@Role_Id", item.Role_Id);
                parametro.Add("@Usua_UsuarioModificacion", item.Usua_UsuarioModificacion);
                parametro.Add("@Usua_FechaModificacion", item.Usua_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public tbUsuarios Login(string Usuario, string Contra)
        {
            string sql = ScriptsDatabase.UsuariosInicioSesion;

            tbUsuarios result = new tbUsuarios();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Usuario", Usuario);
                parameters.Add("@Contraseña", Contra);
                result = db.QueryFirstOrDefault<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<tbUsuarios> EnviarCodigo(string Usuario)
        {
            string sql = ScriptsDatabase.UsuariosEnviarCodigo;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add( "@UsuarioCorreo", Usuario );
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public IEnumerable<tbUsuarios> IngresarCodigo(string codigo, int usua_id)
        {
            string sql = ScriptsDatabase.UsuariosIngresarCodigo;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Usua_Id", usua_id);
                parameters.Add("@Usua_VerificarCorreo", codigo);
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbUsuarios> ValidarCodigo(string codigo)
        {
            string sql = ScriptsDatabase.UsuariosValidarCodigo;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Usua_VerificarCorreo", codigo);
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public RequestStatus RestablecerContra(tbUsuarios item)
        {
            string sql = ScriptsDatabase.UsuariosRestablecerContra;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Usua_VerificarCorreo", item.Usua_VerificarCorreo);
                parametro.Add("@Usua_Contraseña", item.Usua_Contraseña);
                parametro.Add("@Usua_UsuarioModificacion", item.Usua_UsuarioModificacion);
                parametro.Add("@Usua_FechaModificacion", item.Usua_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
