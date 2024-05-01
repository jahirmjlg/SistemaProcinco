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
    public class RolesRepository : IRepository<tbRoles>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.RolesEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Role_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbRoles> Find(int? id)
        {
            string sql = ScriptsDatabase.RolesLlenarEditar;
            List<tbRoles> result = new List<tbRoles>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Role_Id", id);
                result = db.Query<tbRoles>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public (RequestStatus, int) Insert(tbRoles item)
        {
            string sql = ScriptsDatabase.RolesCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Role_Descripcion", item.Role_Descripcion);
                parametro.Add("@Role_UsuarioCreacion", item.Role_UsuarioCreacion);
                parametro.Add("@Role_FechaCreacion", item.Role_FechaCreacion);
                parametro.Add("@role_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                int roleId = parametro.Get<int>("@role_id");

                string mensaje = (result == 1) ? "exito" : "error";
                return (new RequestStatus { CodeStatus = result, MessageStatus = "" }, roleId);
            }
        }

        public IEnumerable<tbRoles> List()
        {
            string sql = ScriptsDatabase.RolesListar;

            List<tbRoles> result = new List<tbRoles>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbRoles>(sql, commandType: System.Data.CommandType.Text).ToList();

                return result;
            }
        }

        public RequestStatus Update(tbRoles item)
        {
            string sql = ScriptsDatabase.RolesActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Role_Id", item.Role_Id);
                parametro.Add("@Role_Descripcion", item.Role_Descripcion);
                parametro.Add("@Role_UsuarioModificacion", item.Role_UsuarioModificacion);
                parametro.Add("@Role_FechaModificacion", item.Role_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        RequestStatus IRepository<tbRoles>.Insert(tbRoles item)
        {
            throw new NotImplementedException();
        }
    }
}
