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
    public class PantallasPorRolesRepostory : IRepository<tbPantallasPorRoles>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.PantallasPorRolesListar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("PaPr_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbPantallasPorRoles> Find(int? id)
        {
            string sql = ScriptsDatabase.PantallasPorRolesBuscar;
            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("PaPr_Id", id);
                result = db.Query<tbPantallasPorRoles>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbPantallasPorRoles item)
        {
            string sql = ScriptsDatabase.PantallasPorRolesCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Pant_Id", item.Pant_Id);
                parametro.Add("@Role_Id", item.Role_Id);
                parametro.Add("@PaPr_UsuarioCreacion", item.PaPr_UsuarioCreacion);
                parametro.Add("@PaPr_FechaCreacion", item.PaPr_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbPantallasPorRoles> List()
        {
            string sql = ScriptsDatabase.PantallasPorRolesListar;

            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbPantallasPorRoles>(sql, commandType: System.Data.CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbPantallasPorRoles> List1(int Role_Id)
        {
            string sql = ScriptsDatabase.PantallasPorRolesListar;

            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Role_Id", Role_Id);
                result = db.Query<tbPantallasPorRoles>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
        public RequestStatus Update(tbPantallasPorRoles item)
        {
            string sql = ScriptsDatabase.PantallasPorRolesActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@PaPr_Id", item.PaPr_Id);
                parametro.Add("@Pant_Id", item.Pant_Id);
                parametro.Add("@Role_Id", item.Role_Id);
                parametro.Add("@PaPr_UsuarioModificacion", item.PaPr_UsuarioModificacion);
                parametro.Add("@PaPr_FechaModificacion", item.PaPr_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
