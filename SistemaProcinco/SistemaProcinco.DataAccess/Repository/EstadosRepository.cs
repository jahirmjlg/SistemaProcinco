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
    public class EstadosRepository : IRepository<tbEstados>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.EstadosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Esta_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public RequestStatus Delete1(string? id)
        {
            string sql = ScriptsDatabase.EstadosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Esta_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };

            }
        }

        public IEnumerable<tbEstados> Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEstados> Find1(string id)
        {
            string sql = ScriptsDatabase.EstadosBuscar;
            List<tbEstados> result = new List<tbEstados>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Esta_Id ", id);
                result = db.Query<tbEstados>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public RequestStatus Insert(tbEstados item)
        {
            string sql = ScriptsDatabase.EstadosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Esta_Id", item.Esta_Id);
                parametro.Add("@Esta_Descripcion", item.Esta_Descripcion);
                parametro.Add("@Esta_UsuarioCreacion", item.Esta_UsuarioCreacion);
                parametro.Add("@Esta_FechaCreacion", item.Esta_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbEstados> List()
        {
            string sql = ScriptsDatabase.EstadosListar;

            List<tbEstados> result = new List<tbEstados>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbEstados>(sql, commandType: System.Data.CommandType.Text).ToList();

                return result;
            }
        }

        public RequestStatus Update(tbEstados item)
        {
            string sql = ScriptsDatabase.EstadosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Esta_Id", item.Esta_Id);
                parametro.Add("@Esta_Descripcion", item.Esta_Descripcion);
                parametro.Add("@Esta_UsuarioModificacion", item.Esta_UsuarioModificacion);
                parametro.Add("@Esta_FechaModificacion", item.Esta_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
