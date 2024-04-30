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
            string sql = ScriptsDatabase.EstadosCivilesBuscar;
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
            string sql = ScriptsDatabase.EstadosCivilesCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Estc_Descripcion", item.Estc_Descripcion);
                parametro.Add("@Estc_UsuarioCreacion", item.Estc_UsuarioCreacion);
                parametro.Add("@Estc_FechaCreacion", item.Estc_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbPantallasPorRoles> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbPantallasPorRoles item)
        {
            throw new NotImplementedException();
        }
    }
}
