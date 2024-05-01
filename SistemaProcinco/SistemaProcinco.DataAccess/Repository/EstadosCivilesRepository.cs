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
    public class EstadosCivilesRepository : IRepository<tbEstadosCiviles>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.EstadosCivilesEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Estc_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbEstadosCiviles> Find(int? id)
        {
            string sql = ScriptsDatabase.EstadosCivilesBuscar;
            List<tbEstadosCiviles> result = new List<tbEstadosCiviles>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Estc_Id", id);
                result = db.Query<tbEstadosCiviles>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbEstadosCiviles item)
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

        public IEnumerable<tbEstadosCiviles> List()
        {
            string sql = ScriptsDatabase.EstadosCivilesListar;

            List<tbEstadosCiviles> result = new List<tbEstadosCiviles>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbEstadosCiviles>(sql, commandType: System.Data.CommandType.Text).ToList();

                return result;
            }
        }

        public RequestStatus Update(tbEstadosCiviles item)
        {
            string sql = ScriptsDatabase.EstadosCivilesActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Estc_Id", item.Estc_Id);
                parametro.Add("@Estc_Descripcion", item.Estc_Descripcion);
                parametro.Add("@Estc_UsuarioModificacion", item.Estc_UsuarioModificacion);
                parametro.Add("@Estc_FechaModificacion", item.Estc_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
